namespace DSA.Common.Infrastructure.Login
{
    public class UserCredentials
    {
        public UserCredentials(string username,string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
