using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GENTECH_PROJECTPUPSIS;
using MySqlConnector;  



namespace GENTECH_PROJECTPUPSIS
{
    public class DbConnection
    {
        private static string connectionString =
            "server=localhost;uid=root;pwd=1234;database=gentechdb_admin;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}