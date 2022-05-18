namespace FuckPrivacy.Users
{
    public abstract class AUser
    {
        public string Username { get; }
        private string Password { get; }
        public string ProfilePicture { get; }
        public abstract void HomePage();

        protected AUser(string username, string password) {
            Username = username;
            ProfilePicture = "beerIcon";
            this.Password = password;
        }

        public bool CorrectPassword(string ps) {
            return ps == Password;
        }
    }
}