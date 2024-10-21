using NetRPG_server_console;

class Program
{
    static void Main(string[] args)
    {
        TcpListenerConsole tcpListenerConsole = new TcpListenerConsole();
        tcpListenerConsole.Start();
    }
}