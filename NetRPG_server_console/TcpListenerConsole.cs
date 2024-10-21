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
        private List<TcpClient> clients = new List<TcpClient>();

        public async void Start()
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
            byte[] bufferSize = new byte[4];
            int read;

            while (true)
            {
                read = await ns.ReadAsync(bufferSize, 0, bufferSize.Length);
                if (read == 0) break;

                int size = BitConverter.ToInt32(bufferSize);
                byte[] buffer = new byte[size];

                read = await ns.ReadAsync(buffer, 0, buffer.Length);
                if (read == 0) break;

                string message = Encoding.UTF8.GetString(buffer, 0, read);
                Console.WriteLine(message);//for test
            }
        }
    }
}
