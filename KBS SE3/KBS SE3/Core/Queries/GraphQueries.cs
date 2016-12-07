using KBS_SE3.Models.Graph.DbGraph;
using KBS_SE3.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS_SE3.Core.Queries {
   static class GraphQueries {
        private static MySqlConnection _conn = DatabaseUtil.getDbInstance().GetDBConnection();
        

        //Function for returning a list with all database nodes
        public static List<Node> SelectAllNodes() {
            List<Node> nodeList = new List<Node>();
            lock (_conn) {
                using (var command = new MySqlCommand("SELECT * FROM node", _conn)) {
                    command.Prepare();
                    using (var reader = command.ExecuteReader())
                        while (reader.Read()) 
                            nodeList.Add(new Node(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2)));
                }
            }
            return nodeList;
        }
    }
}
