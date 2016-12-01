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
        MySqlConnection connection = new MySqlConnection(
           "Server=studiomajestic.nl;user id=studiop52_radar;password=koffie;database=studiop52_radar;");

        public static DatabaseUtil getDbInstance()
        {
            if (_dbInstance == null)
            {
                _dbInstance = new DatabaseUtil();
            }
            return _dbInstance;
        }

        public void GetDBConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connected");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Not connected : " + e.ToString());
            }
        }

        public void selectAllNodeId()
        {
            lock (connection)
            {
                using (var command = new MySqlCommand("SELECT id FROM node", connection))
                {
                    command.Prepare();
                    using (var reader = command.ExecuteReader())
                        while (reader.Read())
                        {
                            Console.WriteLine("id: " + reader.GetInt32(0));
                        }
                }
            }
        }

    }
}
