namespace FuckPrivacy.Users
{
    public abstract class AUser
    {
        public string Username { get; }
        public abstract void StartPage();

        protected AUser(string username) {
            Username = username;
        }
    }
}