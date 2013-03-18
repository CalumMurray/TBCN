using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace TBCN
{
    //
    class DatabaseConnection
    {
        private const string connStr = "SERVER=arlia.computing.dundee.ac.uk;USER=12ac3u03;DATABASE=12ac3d03;PORT=3306;PASSWORD=ab123c;";

        public void connect()
        {
            
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                // Perform database operations
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }

    }
}
