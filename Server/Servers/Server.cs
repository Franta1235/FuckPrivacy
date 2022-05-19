using System;
using FuckPrivacy.Users;

namespace Server.Servers
{
    public class Server
    {
        private readonly MySqlServer _sqlServer;

        public Server() {
            _sqlServer = new MySqlServer();
        }

        public void AddUser(string username, string password) {
            _sqlServer.AddUser(username, password);
        }

        public bool UserExist(string username) {
            return _sqlServer.UserExist(username);
        }

        public User GetUser(string username, string password) {
            try {
                return _sqlServer.GetUser(username, password);
            }
            catch (ArgumentNullException) {
                Console.WriteLine("User does not exist.");
            }
            catch (ArgumentException) {
                Console.WriteLine("Wrong password.");
            }

            throw new NotImplementedException();
        }
    }
}