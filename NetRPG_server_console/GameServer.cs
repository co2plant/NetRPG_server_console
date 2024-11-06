using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetRPG_server_console
{
    public class GameServer
    {
        private TcpListener listener;
        private Dictionary<string, List<TcpClient>> rooms = new();

        public GameServer(string ipAddress, int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
        }

        public async Task StartAsync()
        {
            listener.Start();
            Console.WriteLine("Game server started...");

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                Task.Run(() => HandleClientAsync(client));
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string roomName = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            if (!rooms.ContainsKey(roomName))
            {
                rooms[roomName] = new List<TcpClient>();
            }

            if (rooms[roomName].Count < 4)
            {
                rooms[roomName].Add(client);
                await BroadcastMessageAsync(roomName, $"{client.Client.RemoteEndPoint} joined the room.");
            }
            else
            {
                byte[] message = Encoding.UTF8.GetBytes("Room is full.");
                await stream.WriteAsync(message, 0, message.Length);
                client.Close();
            }
        }

        private async Task BroadcastMessageAsync(string roomName, string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            foreach (var client in rooms[roomName])
            {
                NetworkStream stream = client.GetStream();
                await stream.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }
}