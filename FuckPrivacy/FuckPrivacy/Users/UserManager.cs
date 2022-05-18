using System;
using System.IO;
using System.Net.NetworkInformation;

namespace FuckPrivacy.Users
{
    public static class UserManager
    {
        public static AUser Login(string email, string password) {
            // TODO
            if (email != "koznar.franta@gmail.com" || password != "Frantisek1235.") throw new ArgumentException();
            return GetUser(email);
        }

        public static AUser SignIn(string email, string password1, string password2) {
            if (UserExist(email)) throw new ArgumentException("User exist");
            if (password1 != password2) throw new ArgumentException("Passwords must be same");

            // TODO Save user to database
            return GetUser(email);
        }

        public static bool UserExist(string email) {
            // TODO 
            //return Directory.Exists($@"C:\Users\Fanda\RiderProjects\FuckPrivacy\FuckPrivacy\FuckPrivacy\Users\Data\{email}");
            return email == "koznar.franta@gmail.com";
        }

        private static User GetUser(string username) {
            var user = new User() {
                Username = username,
                ProfilePicture = GetProfilePicture(username)
            };
            return user;
        }

        private static string GetProfilePicture(string username) {
            // TODO
            return "beerIcon";
        }
    }
}