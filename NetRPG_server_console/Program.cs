using System.Net;
using System.Threading.Tasks;

namespace NetRPG_server_console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ChatServer chatServer = new ChatServer(IPAddress.Any, 7000);
            GameServer gameServer = new GameServer(IPAddress.Any, 7001);

            Task chatTask = chatServer.StartAsync();
            Task gameTask = gameServer.StartAsync();

            await Task.WhenAll(chatTask, gameTask);
        }
    }
}