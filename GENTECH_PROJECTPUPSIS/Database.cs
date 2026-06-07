using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GENTECH_PROJECTPUPSIS;
using MySqlConnector;  // Make sure this is consistent



namespace GENTECH_PROJECTPUPSIS
{
    public class DbConnection
    {
        private static string connectionString =
            "server=localhost;uid=appuser;pwd=app123;database=gentech-db;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}