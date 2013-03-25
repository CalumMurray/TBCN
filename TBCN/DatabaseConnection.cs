using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace TBCN
{

    public class Database
    {
        private const string connStr = "SERVER=arlia.computing.dundee.ac.uk;USER=12ac3u03;DATABASE=12ac3d03;PORT=3306;PASSWORD=ab123c;";
        private MySqlConnection connection;
        private MySqlCommand insertCommand;

        public Database()
        {
            connection = new MySqlConnection(connStr);
            insertCommand = new MySqlCommand();
        }

        public bool OpenConnection()
        {
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                Console.WriteLine("MySQL connection closed.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
            
        }

        //TODO: Entity Framework and Linq?

        //TODO: Indexes
        //TODO: Prepared Statements!
        //TODO: Stored Procedures!
        //TODO: Locks/Logs/Priveleges/Views

        //ExecuteNonQuery(): Used to execute a insertCommand that will not return any data, for example Insert, update or delete.
        //ExecuteReader(): Returns 0 or more results e.g. SELECT


        public bool addChild(Child childToAdd, Parent parent/*, EmergencyContact ec*/)
        {
            if (!OpenConnection())
                return false;

            MySqlTransaction transaction = connection.BeginTransaction();
            try
            {

                insertCommand.Connection = connection;
                MySqlCommand ParentChildLinkCommand = new MySqlCommand(null, connection);
                MySqlCommand parentCommand = new MySqlCommand(null, connection);
                MySqlCommand ecCommand = new MySqlCommand(null, connection);
                MySqlCommand ecChildLinkCommand = new MySqlCommand(null, connection);
                insertCommand.Transaction = transaction;
                ParentChildLinkCommand.Transaction = transaction;
                parentCommand.Transaction = transaction;
                ecCommand.Transaction = transaction;
                ecChildLinkCommand.Transaction = transaction;

                // Create and prepare an SQL statement.
                insertCommand.CommandText = @"INSERT INTO Child (First_Name, Last_Name, Gender, DOB, First_Language, Room_Attending, Sibling, Date_Applied, Date_Left, Days_Per_Week, Extra_Days, Teas, Medical_Information) 
                                             VALUES (@firstname, @lastname, @gender, @dob, @firstlanguage, @roomattending, @sibling, @dateapplied, @dateleft, @attendance, @extra, @teas, @medical)";

                MySqlParameter fNameParam = new MySqlParameter("@firstname", childToAdd.FirstName);
                MySqlParameter lNameParam = new MySqlParameter("@lastname", childToAdd.LastName);
                MySqlParameter genderParam = new MySqlParameter("@gender", childToAdd.Gender);
                MySqlParameter dobParam = new MySqlParameter("@dob", childToAdd.DOB);
                MySqlParameter languageParam = new MySqlParameter("@firstlanguage", childToAdd.FirstLanguage);
                MySqlParameter roomParam = new MySqlParameter("@roomattending", childToAdd.RoomAttending); //?
                MySqlParameter siblingParam = new MySqlParameter("@sibling", childToAdd.Sibling.ChildID);//?
                MySqlParameter dateAppliedParam = new MySqlParameter("@dateapplied", childToAdd.DateApplied);
                MySqlParameter dateLeftParam = new MySqlParameter("@dateleft", childToAdd.DateLeft);
                MySqlParameter attendanceParam = new MySqlParameter("@attendance", childToAdd.Attendance);//?
                MySqlParameter extraParam = new MySqlParameter("@extra", childToAdd.ExtraDays);
                MySqlParameter teasParam = new MySqlParameter("@teas", childToAdd.Teas);
                MySqlParameter medicalParam = new MySqlParameter("@medical", childToAdd.MedicalID);

                insertCommand.Parameters.Add(fNameParam);
                insertCommand.Parameters.Add(lNameParam);
                insertCommand.Parameters.Add(genderParam);
                insertCommand.Parameters.Add(dobParam);
                insertCommand.Parameters.Add(languageParam);
                insertCommand.Parameters.Add(roomParam);
                insertCommand.Parameters.Add(siblingParam);
                insertCommand.Parameters.Add(dateAppliedParam);
                insertCommand.Parameters.Add(dateLeftParam);
                insertCommand.Parameters.Add(attendanceParam);
                insertCommand.Parameters.Add(extraParam);
                insertCommand.Parameters.Add(teasParam);
                insertCommand.Parameters.Add(medicalParam);

                // Call Prepare after setting the Commandtext and Parameters.
                insertCommand.Prepare();
                insertCommand.ExecuteNonQuery();

                addParent(parent);

                transaction.Commit();
            }
            catch (MySqlException mysqle)
            {
                transaction.Rollback();
                return false;
            }

            return (CloseConnection()); //Successful or not

        }

        public void addParent(Parent parentToAdd)
        {
            insertCommand.Connection = connection;
            insertCommand.CommandText = @"INSERT INTO parent_guardian (First_Name, Last_Name, Title, Gender, Work_Phone, Home_Phone, Mobil_Phone, Home_Address, Work_Address, Spouse, Email)
                                         VALUES (@firstname, @lastname, @title, @gender, @workphone, @homephone, @mobilephone, @homeaddress, @workaddress, @spouse, @email)";

            MySqlParameter fNameParam = new MySqlParameter("@firstname", parentToAdd.FirstName);
            MySqlParameter lNameParam = new MySqlParameter("@lastname", parentToAdd.LastName);
            MySqlParameter genderParam = new MySqlParameter("@gender", parentToAdd.Gender);
            MySqlParameter titleParam = new MySqlParameter("@title", parentToAdd.Title);
            MySqlParameter workPhoneParam = new MySqlParameter("@workphone", parentToAdd.WorkPhone); //?
            MySqlParameter homePhoneParam = new MySqlParameter("@homephone", parentToAdd.HomePhone);//?
            MySqlParameter mobilePhoneParam = new MySqlParameter("@mobilephone", parentToAdd.MobilePhone);
            MySqlParameter homeAddrParam = new MySqlParameter("@homeaddress", parentToAdd.HomeAddress);
            MySqlParameter workAddrParamParam = new MySqlParameter("@workaddress", parentToAdd.WorkAddress);//?
            MySqlParameter spouseParam = new MySqlParameter("@spouse", parentToAdd.Spouse);
            MySqlParameter emailParam = new MySqlParameter("@teas", parentToAdd.Email);

            insertCommand.Parameters.Add(fNameParam);
            insertCommand.Parameters.Add(lNameParam);
            insertCommand.Parameters.Add(genderParam);
            insertCommand.Parameters.Add(titleParam);
            insertCommand.Parameters.Add(workPhoneParam);
            insertCommand.Parameters.Add(homePhoneParam);
            insertCommand.Parameters.Add(mobilePhoneParam);
            insertCommand.Parameters.Add(homeAddrParam);
            insertCommand.Parameters.Add(workAddrParamParam);
            insertCommand.Parameters.Add(spouseParam);
            insertCommand.Parameters.Add(emailParam);

            // Call Prepare after setting the Commandtext and Parameters.
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();
        }

        public void addEmergencyContact(EmergencyContact ecToAdd)
        {

        }

        public void linkParentChild(Parent parentToAdd, Child childToAdd)
        {


        }

        public void linkECChild(EmergencyContact ecToAdd, Child childToAdd)
        {


        }








































        //INSERT statement
        public void Insert(String sqlInsertString)
        {

            //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            try
            {
                //open connection
                OpenConnection();

                //create insertCommand and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(sqlInsertString, connection);

                //Execute insertCommand
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

                //create insertCommand and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(sqlUpdateString, connection);

                //Execute insertCommand
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

                //create insertCommand and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(sqlDeleteString, connection);

                //Execute insertCommand
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
                
                //Create a data reader and Execute the insertCommand
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
