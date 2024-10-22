using System.Net;
using System.Net.Sockets;

namespace ServerTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 7000);
            listener.Start();

            byte[] buff = new byte[1024];

            while (true)
            {
                TcpClient tc = listener.AcceptTcpClient();

                NetworkStream stream = tc.GetStream();

                int nbytes;

                while ((nbytes = stream.Read(buff, 0, buff.Length)) > 0)
                {
                    stream.Write(buff, 0, nbytes);
                }
            
                stream.Close();
                tc.Close();
            }
        }
    }
}
