namespace WebAPI.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }

        public User() { }

        public User(int iD, string name, string email, string dOB)
        {
            ID = iD;
            Name = name;
            Email = email;
            DOB = dOB;
        }
    }
}
