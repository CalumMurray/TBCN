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
        private MySqlCommand selectCommand;

        private int childID;
        private int parentID;
        private int contactID;


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
        //TODO: Transactions!

        /*--------------INSERTS---------------*/

        public bool insertChild(Child childToAdd, Parent parent, EmergencyContact ec)
        {
            if (!OpenConnection())
                return false;

            MySqlTransaction transaction = connection.BeginTransaction();
            try
            {

                insertCommand.Connection = connection;
                MySqlCommand idCommand = new MySqlCommand("SELECT LAST_INSERT_ID()", connection);
                
                insertCommand.Transaction = transaction;

                // Create and prepare an SQL statement.
                insertCommand.CommandText = @"INSERT INTO Child (First_Name, Last_Name, Gender, DOB, First_Language, Room_Attending, Sibling, Date_Applied, Date_Left, Days_Per_Week, Extra_Days, Teas, Medical_Information) 
                                             VALUES (@firstname, @lastname, @gender, @dob, @firstlanguage, @roomattending, @sibling, @dateapplied, @dateleft, @attendance, @extra, @teas, @medical);";

                //Fill in prepared statement parameters
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

                // Prepare statement
                Console.WriteLine("Executing: [ " + insertCommand.ToString() + "].");
                insertCommand.Prepare();
                insertCommand.ExecuteNonQuery();

                

                childID = (int)idCommand.ExecuteScalar();
                insertParent(parent);
                parentID = (int)idCommand.ExecuteScalar();
                linkParentChild(childToAdd, parent);

                insertEmergencyContact(ec);
                contactID = (int)idCommand.ExecuteScalar();

                linkECChild(ec, childToAdd);

                //Perform transaction
                transaction.Commit();
            }
            catch (MySqlException mysqle)
            {
                transaction.Rollback(); //Something went wrong, rollback
                return false;
            }

            return (CloseConnection()); //Successful or not

        }

        public void insertParent(Parent parentToAdd)
        {
            insertCommand.Connection = connection;
            insertCommand.CommandText = @"INSERT INTO parent_guardian (First_Name, Last_Name, Title, Gender, Work_Phone, Home_Phone, Mobil_Phone, Home_Address, Work_Address, Spouse, Email)
                                         VALUES (@firstname, @lastname, @title, @gender, @workphone, @homephone, @mobilephone, @homeaddress, @workaddress, @spouse, @email);";

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
            MySqlParameter emailParam = new MySqlParameter("@email", parentToAdd.Email);

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
            Console.WriteLine("Executing: [ " + insertCommand.ToString() + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();

            
        }

        public void linkParentChild(Child childToAdd, Parent parent)
        {
            insertCommand.Connection = connection;
            insertCommand.CommandText = "INSERT INTO child_has_parent_guardian VALUES (@parentID, @childID);";
            insertCommand.Parameters.Add(new MySqlParameter("@parentID", parentID));
            insertCommand.Parameters.Add(new MySqlParameter("@childID", childID));

            Console.WriteLine("Executing: [ " + insertCommand.ToString() + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();
        }

        public void insertEmergencyContact(EmergencyContact ecToAdd)
        {
            insertCommand.Connection = connection;
            insertCommand.CommandText = @"INSERT INTO emergency_contact (First_Name, Last_Name, Title, Gender, Relationship, Home_Phone, Work_Phone, Mobile_Phone, Home_Address, Work_Address, Email)
                                         VALUES (@firstname, @lastname, @title, @gender, @relationship, @homephone, @workphone, @mobilephone, @homeaddress, @workaddress, @email);";


            MySqlParameter fNameParam = new MySqlParameter("@firstname", ecToAdd.FirstName);
            MySqlParameter lNameParam = new MySqlParameter("@lastname", ecToAdd.LastName);
            MySqlParameter genderParam = new MySqlParameter("@gender", ecToAdd.Gender);
            MySqlParameter titleParam = new MySqlParameter("@title", ecToAdd.Title);
            MySqlParameter relParam = new MySqlParameter("@relationship", ecToAdd.Relationship);
            MySqlParameter workPhoneParam = new MySqlParameter("@workphone", ecToAdd.WorkPhone); 
            MySqlParameter homePhoneParam = new MySqlParameter("@homephone", ecToAdd.HomePhone);
            MySqlParameter mobilePhoneParam = new MySqlParameter("@mobilephone", ecToAdd.MobilePhone);
            MySqlParameter homeAddrParam = new MySqlParameter("@homeaddress", ecToAdd.HomeAddress);
            MySqlParameter workAddrParamParam = new MySqlParameter("@workaddress", ecToAdd.WorkAddress);
            MySqlParameter emailParam = new MySqlParameter("@email", ecToAdd.Email);

            insertCommand.Parameters.Add(fNameParam);
            insertCommand.Parameters.Add(lNameParam);
            insertCommand.Parameters.Add(genderParam);
            insertCommand.Parameters.Add(titleParam);
            insertCommand.Parameters.Add(relParam);
            insertCommand.Parameters.Add(workPhoneParam);
            insertCommand.Parameters.Add(homePhoneParam);
            insertCommand.Parameters.Add(mobilePhoneParam);
            insertCommand.Parameters.Add(homeAddrParam);
            insertCommand.Parameters.Add(workAddrParamParam);
            insertCommand.Parameters.Add(emailParam);

            Console.WriteLine("Executing: [ " + insertCommand.ToString() + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();
        }

        public void linkECChild(EmergencyContact ecToAdd, Child childToAdd)
        {
            insertCommand.Connection = connection;
            insertCommand.CommandText = "INSERT INTO child_has_emergency_contact VALUES (@contactID, @childID);";

            insertCommand.Parameters.Add(new MySqlParameter("@contactID", contactID));
            insertCommand.Parameters.Add(new MySqlParameter("@childID", childID));

            Console.WriteLine("Executing: [ " + insertCommand.ToString() + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();
        }

        public void insertAttendance(Child childToAdd)
        {
            insertCommand.Connection = connection;
            insertCommand.CommandText = "INSERT INTO attendance VALUES (@child, @monday, @tuesday, @wednesday, @thursday, @friday);";

            insertCommand.Parameters.Add(new MySqlParameter("@child", childID));
            insertCommand.Parameters.Add(new MySqlParameter("@monday", childToAdd.Attendance[0]));
            insertCommand.Parameters.Add(new MySqlParameter("@tuesday", childToAdd.Attendance[1]));
            insertCommand.Parameters.Add(new MySqlParameter("@wednesday", childToAdd.Attendance[2]));
            insertCommand.Parameters.Add(new MySqlParameter("@thursday", childToAdd.Attendance[3]));
            insertCommand.Parameters.Add(new MySqlParameter("@friday", childToAdd.Attendance[4]));

            Console.WriteLine("Executing: [ " + insertCommand.ToString() + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();
        }

        /*--------------SELECTS---------------*/

        public Child selectChild(Child childToSelect)
        {
            if (!OpenConnection())
                return null;

            selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM child WHERE Child_ID = @childID;";
            selectCommand.Parameters.Add(new MySqlParameter("@childID", childToSelect.ChildID));

            Console.WriteLine("Executing: [ " + selectCommand.ToString() + "].");
            selectCommand.Prepare();
            MySqlDataReader childReader = selectCommand.ExecuteReader();

            //Package into Child domain entity object
            Child newChild = new Child();
            while (childReader.Read())
            {
                //TODO: Use "childReader["ChildID"]" syntax instead?

                newChild.ChildID = childReader.GetInt32(0);
                newChild.FirstName = childReader.GetString(1);
                newChild.LastName = childReader.GetString(2);
                newChild.Gender = childReader.GetChar(3);
                newChild.DOB = childReader.GetDateTime(4);
                newChild.FirstLanguage = childReader.GetString(5);
                newChild.RoomAttending = childReader.GetString(6);
                //newChild.Sibling = childReader.Get7
                newChild.DateApplied = childReader.GetDateTime(8);
                newChild.DateLeft = childReader.GetDateTime(9);
               // newChild.Attendance = childReader.GetInt32(10);
                newChild.ExtraDays = childReader.GetInt16(11);
                newChild.Teas = childReader.GetInt16(12);
                //newChild.MedicalInformation = childReader.GetIny(13);
               // newChild.Parents = 
                //newChild.EmergencyContacts = 
            }
            childReader.Close();

            CloseConnection();

            return newChild;
        }

        public Parent selectParent(Parent parentToSelect)
        {
            if (!OpenConnection())
                return null;

            selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM parent_guardian WHERE ParentID = @parentID;";
            selectCommand.Parameters.Add(new MySqlParameter("@parentID", parentToSelect.ParentID));

            Console.WriteLine("Executing: [ " + selectCommand.ToString() + "].");
            selectCommand.Prepare();
            MySqlDataReader parentReader = selectCommand.ExecuteReader();

            //Package into Child domain entity object
            Parent newParent = new Parent();
            while (parentReader.Read())
            {
                newParent.ParentID = parentReader.GetInt32(0);
                newParent.FirstName = parentReader.GetString(1);
                newParent.LastName = parentReader.GetString(2);
                newParent.Title = parentReader.GetString(3);
                newParent.Gender = parentReader.GetChar(4);
                newParent.HomePhone = parentReader.GetString(5);
                newParent.WorkPhone = parentReader.GetString(6);
                newParent.MobilePhone = parentReader.GetString(7);
               // newEC.HomeAddress = attendanceReader.GetString(8);
                //newEC.WorkAddress = attendanceReader.GetString(9);
                //newEC.Spouse = attendanceReader.GetInt16(10);
                newParent.Email = parentReader.GetString(11);
            }
            parentReader.Close();

            CloseConnection();

            return newParent;
        }

        public EmergencyContact selectEmergencyContact(EmergencyContact ecToSelect)
        {
            if (!OpenConnection())
                return null;

            selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM emergency_contact WHERE ContactID = @contactID;";
            selectCommand.Parameters.Add(new MySqlParameter("@contactID", ecToSelect.ContactID));

            Console.WriteLine("Executing: [ " + selectCommand.ToString() + "].");
            selectCommand.Prepare();
            MySqlDataReader ECReader = selectCommand.ExecuteReader();

            //Package into Child domain entity object
            EmergencyContact newEC = new EmergencyContact();
            while (ECReader.Read())
            {
                newEC.ContactID = ECReader.GetInt32(0);
                newEC.Title = ECReader.GetString(1);
                newEC.FirstName = ECReader.GetString(2);
                newEC.LastName = ECReader.GetString(3);
                newEC.Relationship = ECReader.GetString(4);
                newEC.HomePhone = ECReader.GetString(5);
                newEC.WorkPhone = ECReader.GetString(6);
                newEC.MobilePhone = ECReader.GetString(7);
                //newEC.HomeAddress = attendanceReader.GetString(8);
                //newEC.WorkAddress = attendanceReader.GetString(9);
                newEC.Gender = ECReader.GetChar(10);
                newEC.Email = ECReader.GetString(11);
            }
            ECReader.Close();

            CloseConnection();

            return newEC;
        }


        //Get a child's attendance
        public bool[] selectAttendance(int childID)
        {
            if (!OpenConnection())
                return null;

            selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM attendance WHERE ChildID = @childID;";
            selectCommand.Parameters.Add(new MySqlParameter("@childID", childID));

            Console.WriteLine("Executing: [ " + selectCommand.ToString() + "].");
            selectCommand.Prepare();
            MySqlDataReader attendanceReader = selectCommand.ExecuteReader();

            //Package into Child domain entity object
            bool[] attendanceArray = new bool[5];
            while (attendanceReader.Read())
            {
                for (int i = 0; i < attendanceArray.Length; i++)
                    attendanceArray[i] = attendanceReader.GetBoolean(i);
            }
            attendanceReader.Close();

            CloseConnection();

            return attendanceArray;
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



    }
}
