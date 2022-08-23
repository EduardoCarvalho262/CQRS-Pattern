using System.Text.Json.Serialization;

namespace CustomerDomain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(string FirstName, string LastName, string UserName, string Password, string Role)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Username = UserName;
            this.Password = Password;
            this.Role = Role;
        }
    }
}