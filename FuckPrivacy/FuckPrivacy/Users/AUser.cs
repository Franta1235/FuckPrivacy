﻿namespace FuckPrivacy.Users
{
    public abstract class AUser
    {
        public string Username { get; }
        private string Password { get; }
        public abstract void HomePage();

        protected AUser(string username, string password) {
            Username = username;
            this.Password = password;
        }

        public bool CorrectPassword(string ps) {
            return ps == Password;
        }
    }
}