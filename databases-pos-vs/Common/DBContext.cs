using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace databases_pos_vs.Common
{
    public class DBContext
    {

        /// <summary>
		/// connect to database
		/// </summary>
		public static string ConnectionString
        {
            get
            {
                return "Server=databases-project-db.c0vzuhjaxhpo.us-east-1.rds.amazonaws.com;Database=Pos_Prod;Uid=admin;Pwd=Linuxmasterrace4#;CharSet=utf8;";
            }
        }

        /// <summary>
        /// execute sql command
        /// </summary>
        public static int ExecuteNonQuery(string cmdText)
        {
            int num = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {

                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = cmdText;
                    cmd.CommandType = CommandType.Text;
                    num = cmd.ExecuteNonQuery();
                    conn.Close();
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                num = -1;
            }
            return num;
        }

        /// <summary>
        /// Search
        /// </summary>
        public static MySqlDataReader ExecuteReader(string cmdText)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return rdr;
            }
            catch (Exception ex)
            {
                conn.Close();
                cmd.Dispose();
                return null;
            }
        }

    }
}
