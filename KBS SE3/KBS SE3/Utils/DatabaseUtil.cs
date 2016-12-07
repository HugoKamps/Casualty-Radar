using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Utils
{
    class DatabaseUtil
    {
        private static DatabaseUtil _dbInstance;
        private static MySqlConnection connection = new MySqlConnection(
           "Server=studiomajestic.nl;user id=studiop52_radar;password=koffie;database=studiop52_radar;");

        public static DatabaseUtil getDbInstance()
        {
            if (_dbInstance == null)
            {
                _dbInstance = new DatabaseUtil();
            }
            return _dbInstance;
        }

        public void SetDBConnection()
        {
            try
            {
                connection.Open();
            }
            catch (SqlException e)
            {
            }
        }

        public MySqlConnection GetDBConnection() {
            return connection;
        }
    }
}
