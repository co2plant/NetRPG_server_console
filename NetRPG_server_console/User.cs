using System.Net.Sockets;

namespace NetRPG_server_console
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TcpClient Client { get; set; }

        public User(int id, string name, TcpClient client)
        {
            Id = id;
            Name = name;
            Client = client;
        }
    }
}

