using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GENTECH_PROJECTPUPSIS
{

    public class DbConnection
    {
        private static string connectionString =
            "server=127.0.0.1;port=3306;database=gentechdb;uid=root;pwd=Netan123;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
