using System.Threading.Tasks;

namespace NetRPG_server_console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ChatServer chatServer = new ChatServer("127.0.0.1", 7000);
            GameServer gameServer = new GameServer("127.0.0.1", 7001);

            Task chatTask = chatServer.StartAsync();
            Task gameTask = gameServer.StartAsync();

            await Task.WhenAll(chatTask, gameTask);
        }
    }
}