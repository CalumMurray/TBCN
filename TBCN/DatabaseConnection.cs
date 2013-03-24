using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace TBCN
{
    
    class DatabaseConnection
    {
        private const string connStr = "SERVER=arlia.computing.dundee.ac.uk;USER=12ac3u03;DATABASE=12ac3d03;PORT=3306;PASSWORD=ab123c;";
        protected MySqlConnection connection;

        public DatabaseConnection()
        {
            connection = new MySqlConnection(connStr);
        }

        public void OpenConnection()
        {
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        public void CloseConnection()
        {
            try
            {
                connection.Close();
                Console.WriteLine("MySQL connection closed.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        //TODO: Entity Framework and Linq?

        //TODO: Indexes
        //TODO: Prepared Statements!
        //TODO: Stored Procedures!
        //TODO: Locks/Logs/Priveleges/Views

        //ExecuteNonQuery(): Used to execute a childCommand that will not return any data, for example Insert, update or delete.
        //ExecuteReader(): Returns 0 or more results e.g. SELECT


        //INSERT statement
        public void Insert(String sqlInsertString)
        {

            //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            try
            {
                //open connection
                OpenConnection();

                //create childCommand and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(sqlInsertString, connection);

                //Execute childCommand
                Console.WriteLine("Executing Insert: [ " + sqlInsertString + "].");
                cmd.ExecuteNonQuery();
                
                //close connection
                this.CloseConnection();
            }
            catch (MySqlException msqle)
            {
                Console.WriteLine(msqle.ToString());
            }
        }

        //UPDATE statement
        public void Update(String sqlUpdateString)
        {
            try
            {
                //open connection
                OpenConnection();

                //create childCommand and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(sqlUpdateString, connection);

                //Execute childCommand
                Console.WriteLine("Executing Update: [ " + sqlUpdateString + "].");
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
            catch (MySqlException msqle)
            {
                Console.WriteLine(msqle.ToString());
            }
        }

        //DELETE statement
        public void Delete(String sqlDeleteString)
        {
            try
            {
                //open connection
                OpenConnection();

                //create childCommand and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(sqlDeleteString, connection);

                //Execute childCommand
                Console.WriteLine("Executing Delete: [ " + sqlDeleteString + "].");
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
            catch (MySqlException msqle)
            {
                Console.WriteLine(msqle.ToString());
            }
        }

        //SELECT statement
        public List<string>[] Select(String sqlSelectString)
        {

            //Create a list to store the result
            List< string >[] list = new List< string >[3];
            list[0] = new List< string >();
            list[1] = new List< string >();
            list[2] = new List< string >();

            try
            {
                OpenConnection();

                //Prepared Statement
                //MySqlCommand cmd = new MySqlCommand("SELECT * FROM admin WHERE admin_username=@val1 AND admin_password=PASSWORD(@val2)", connection);
                //cmd.Parameters.AddWithValue("@val1", tboxUserName.Text);
                //cmd.Parameters.AddWithValue("@val2", tboxPassword.Text);
                //cmd.Prepare();

                //Create Command
                MySqlCommand cmd = new MySqlCommand(sqlSelectString, connection);
                
                //Create a data reader and Execute the childCommand
                Console.WriteLine("Executing Select: [ " + sqlSelectString + "].");
                MySqlDataReader dataReader = cmd.ExecuteReader();

                MySqlDataAdapter mysqlAdapater = new MySqlDataAdapter();
                DataSet ds = new DataSet();
                
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        list[i].Add(dataReader[dataReader.GetName(i)].ToString());
                        //dataReader.GetString(columnNumber);
                        //list[0].Add(dataReader["id"].ToString());
                        //list[1].Add(dataReader["name"].ToString());
                        //list[2].Add(dataReader["age"].ToString());
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            catch (MySqlException msqle)
            {
                Console.WriteLine(msqle.ToString());
            }

            return null;
        }

        //count statement
        public int Count(String query)
        {
            
            int count = -1;

            //Open Connection
            try
            {
                OpenConnection();

                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                count = int.Parse(cmd.ExecuteScalar().ToString());

                //close Connection
                CloseConnection();

                return count;
            }
            catch (MySqlException msqle)
            {
                Console.WriteLine(msqle.ToString());
            }
            return -1;
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
    }
}
