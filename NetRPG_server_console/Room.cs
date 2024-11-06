namespace NetRPG_server_console
{
    public class Room
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }

        public Room(string name)
        {
            Name = name;
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
    }
}

