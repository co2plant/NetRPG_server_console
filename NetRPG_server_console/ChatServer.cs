using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetRPG_server_console
{
    public class ChatServer
    {
        private TcpListener _listener;
        private RoomManager _roomManager;
        public ChatServer(IPAddress ipAddress, int port)
        {
            _listener = new TcpListener(ipAddress, port);
            _roomManager = new RoomManager();
        }

        public async Task StartAsync()
        {
            _listener.Start();
            Console.WriteLine("Chat server started...");
            while (true)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();
                Task.Run(() => HandleClientAsync(client));
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string roomTitle = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Room room = _roomManager.GetOrCreateRoom(roomTitle);

            if (!room.IsFull)
            {
                User user = new User(GenerateUserId(), "User" + GenerateUserId(), client);
                room.AddUser(user);
                await _roomManager.BroadcastMessageAsync(roomTitle, $"{client.Client.RemoteEndPoint} joined the room.");
            }
            else
            {
                byte[] message = Encoding.UTF8.GetBytes("Room is full.");
                await stream.WriteAsync(message, 0, message.Length);
                client.Close();
            }
        }

        private int GenerateUserId()
        {
            return new Random().Next(1, 1000);
        }
    }
}