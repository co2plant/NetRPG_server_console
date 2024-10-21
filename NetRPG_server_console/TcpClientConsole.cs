using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetRPG_server_console
{
   
    internal class TcpClientConsole
    {
        private TcpClient tc;
        public void Init()
        {
            tc = new TcpClient("127.0.0.1", 7000);
        }
        public void sendMessage(string message)
        {
            NetworkStream ns = tc.GetStream();

            var buffer = Encoding.UTF8.GetBytes(message);

            ns.Write(buffer);
        }
    }
}
