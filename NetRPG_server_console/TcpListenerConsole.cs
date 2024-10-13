using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetRPG_server_console
{
    internal class TcpListenerConsole
    {
        private TcpListener tcpListener;

        public async void test()
        {
            tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            tcpListener.Start();

            while (true)
            {
                TcpClient tc = await tcpListener.AcceptTcpClientAsync();

                _ = HandleClient(tc);
            }
            
        }
            
        private async Task HandleClient(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] buffer = new byte[1024];
            int read;

            while ((read = await ns.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                read = await ns.ReadAsync(buffer, 0, buffer.Length);

                string message = Encoding.UTF8.GetString(buffer, 0, read);

                Console.WriteLine(message);//for test
            }
        }
    }
}
