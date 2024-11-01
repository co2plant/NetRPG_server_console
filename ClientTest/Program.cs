using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            TcpClient tc = new TcpClient("141.164.39.201", 7000);

            string msg = "Hello World!";
            byte[] buff = Encoding.UTF8.GetBytes(msg);

            NetworkStream stream = tc.GetStream();
                    
            stream.Write(buff, 0, buff.Length);

            byte[] outbuff = new byte[1024];
            int nbytes = stream.Read(outbuff, 0, outbuff.Length);
            string output = Encoding.UTF8.GetString(outbuff, 0, nbytes);

            stream.Close();
            tc.Close();
                    
            Console.WriteLine($"{nbytes} bytes : {output}");
        }
    }
}
