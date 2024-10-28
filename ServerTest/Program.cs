using System.Net.Sockets;
using System.Net;
using System;
using System.Threading.Tasks;
using System.Text;

namespace ServerTest
{
    class Program
    {
        private List<TcpClient> clients = new();
        static void Main(string[] args)
        {
            AysncEchoServer().Wait();
        }
 
        async static Task AysncEchoServer()
        {           
            TcpListener listener = new TcpListener(IPAddress.Any, 7000);
            listener.Start();            
            while (true)
            {
                TcpClient tc = await listener.AcceptTcpClientAsync().ConfigureAwait(false);                
                 
                Task.Factory.StartNew(AsyncTcpProcess, tc);                
            }
        }
 
        async static void AsyncTcpProcess(object o)
        {
            TcpClient tc = (TcpClient)o;
 
            int MAX_SIZE = 1024;  // 가정
            NetworkStream stream = tc.GetStream();
            try
            {
                while (true)
                {
                    var buff = new byte[MAX_SIZE];
                    var nbytes = await stream.ReadAsync(buff, 0, buff.Length).ConfigureAwait(false);
                    if (nbytes > 0)
                    {
                        string msg = Encoding.ASCII.GetString(buff, 0, nbytes);
                        Console.WriteLine($"{msg} at {DateTime.Now}");

                        // 비동기 송신
                        await stream.WriteAsync(buff, 0, nbytes).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception : {ex.Message}");
            }
            finally
            {
                stream.Close();
                tc.Close();
            }
            
        }
    }
}
