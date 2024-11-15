namespace NetRPG_server_console
{
    public class Room
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<User> Users { get; set; }

        public Room(string title)
        {
            Title = title;
            Users = new List<User>();
        }

        public bool IsFull => Users.Count >= 4;

        public void AddUser(User user)
        {
            if (!IsFull)
            {
                Users.Add(user);
            }
        }

        public void RemoveUser(User user)
        {
            if (Users.Contains(user))
            {
                Users.Remove(user);
            }
        }
    }
}

