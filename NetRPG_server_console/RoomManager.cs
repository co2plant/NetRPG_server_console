using System.Net.Sockets;
using System.Text;

namespace NetRPG_server_console;

public class RoomManager
{
    private Dictionary<string, Room> _rooms = new();

    public Room GetOrCreateRoom(string title)
    {
        if (!_rooms.ContainsKey(title))
        {
            _rooms[title] = new Room(title);
            Console.WriteLine("Room created: " + title);
        }
        return _rooms[title];
    }

    public async Task BroadcastMessageAsync(string roomTitle, string message)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        foreach (var user in _rooms[roomTitle].Users)
        {
            NetworkStream stream = user.Client.GetStream();
            await stream.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}