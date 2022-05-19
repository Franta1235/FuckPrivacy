using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using FuckPrivacy.Users;
using MySql.Data.MySqlClient;


namespace Server
{
    public class Server
    {
        private MySqlServer _sqlServer;

        public Server() {
            _sqlServer = new MySqlServer();
        }
    }
}