using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace projekt
{
    internal class Database
    {
        static readonly string server = "127.0.0.1";
        static readonly string user = "root";
        static readonly string password = "";
        static readonly string database = "bdproj";
        public static string connection_string = "server='" + server + "'; user='" + user + "'; database= '"+database+"'; password= '"+password+ "'; Convert Zero Datetime=True; Allow Zero Datetime=True";
        public MySqlConnection mySqlConnection = new MySqlConnection(connection_string);

        public bool connect_db()
        {
            try
            {
                mySqlConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool close_db()
        {
            try
            {
                mySqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public static DataTable GetDataTable(string query)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connection_string))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }
    }
}
