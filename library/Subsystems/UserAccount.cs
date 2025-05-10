namespace EBookLibrary.Subsystems
{
    public class UserAccount
    {
        public string Login(string username) => $"User {username} logged in";
        public string Logout(string username) => $"User {username} logged out";
    }
}