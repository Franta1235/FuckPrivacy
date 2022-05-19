using System;
using System.Collections.Generic;
using System.Linq;
using FuckPrivacy.Users;
using MySql.Data.MySqlClient;

namespace Server.Servers
{
    public class MySqlServer
    {
        private readonly MySqlConnection _connection;

        /// <summary>
        /// Initializes server and MySQL connection
        /// </summary>
        public MySqlServer() {
            const string server = "localhost";
            const string databaseName = "FuckPrivacy";
            const string userName = "root";
            const string password = "Frantisek1235.";
            var connString = $"Server={server}; database={databaseName}; UID={userName}; password={password}";
            _connection = new MySqlConnection(connString);
            _connection.Open();
        }

        /// <summary>
        /// Inserts user to database users
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void AddUser(string username, string password) {
            var sqlCommand = $"INSERT INTO users (username, password) value ('{username}','{password}')";
            var cmd = new MySqlCommand(sqlCommand, _connection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Finds user in database users
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <exception cref="ArgumentNullException">If user does not exist in database</exception>
        /// <exception cref="ArgumentException">If is passed wrong password</exception>
        /// <exception cref="NotImplementedException"></exception>
        public User GetUser(string username, string password) {
            if (UserExist(username) == false) throw new ArgumentNullException();
            var sqlCommand = $"Select * from users where username='{username}'";
            var cmd = new MySqlCommand(sqlCommand, _connection);
            using (var reader = cmd.ExecuteReader()) {
                while (reader.Read()) {
                    var un = reader["username"].ToString();
                    var ps = reader["password"].ToString();
                    if (password != ps) throw new ArgumentException();
                    throw new NotImplementedException();
                }
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if user exist in database users
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool UserExist(string username) {
            var users = GetUsers();
            return users.Any(user => user[0] == username);
        }

        /// <summary>
        /// Fetches user's username and password to list of arrays
        /// </summary>
        /// <returns></returns>
        private IEnumerable<string[]> GetUsers() {
            var users = new List<string[]>();
            const string sqlCommand = "Select * from users";
            var cmd = new MySqlCommand(sqlCommand, _connection);
            using (var reader = cmd.ExecuteReader()) {
                while (reader.Read()) {
                    var username = reader["username"].ToString();
                    var password = reader["password"].ToString();
                    users.Add(new[] {username, password});
                }
            }

            return users;
        }
    }
}