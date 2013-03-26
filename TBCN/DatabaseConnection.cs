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
                insertCommand.CommandText = @"INSERT INTO child (First_Name, Last_Name, Gender, DOB, First_Language, Room_Attending, Sibling, Date_Applied, Date_Left, Days_Per_Week, Extra_Days, Teas, Medical_Information) 
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

        public bool insertEmplyee(Employee employeeToAdd)
        {
            if (!OpenConnection())
                return false;

            try
            {

                insertCommand.Connection = connection;

                // Create and prepare an SQL statement.
                insertCommand.CommandText = @"INSERT INTO employee (National_Insurance_Number, First_Name, Last_Name, Position, Gender, Date_Started, Date_Finished, PVG_Date, Holidays_Entitled, Holidays_Taken, Hours, Home_Address, DOB, Salary, Home_Phone, Mobile_Phone, Email, Training, Medical_Information, Emergency_Contact) 
                                             VALUES (@nino, @firstname, @lastname, @position, @gender, @datestarted, @datefinished, @pvgdate, @holidaysentitled, @holidaystaken, @hours, @address, @dob, @salary, @homephone, @mobilephone, @email, @training, @medical, @ec);";

                //Fill in prepared statement parameters
                MySqlParameter ninoParam = new MySqlParameter("@nino", employeeToAdd.NINo);
                MySqlParameter fNameParam = new MySqlParameter("@firstname", employeeToAdd.FirstName);
                MySqlParameter lNameParam = new MySqlParameter("@lastname", employeeToAdd.LastName);
                MySqlParameter positionParam = new MySqlParameter("@position", employeeToAdd.Position);
                MySqlParameter genderParam = new MySqlParameter("@gender", employeeToAdd.Gender);
                MySqlParameter dateAppliedParam = new MySqlParameter("@datestarted", employeeToAdd.DateStarted);
                MySqlParameter dateLeftParam = new MySqlParameter("@datefinished", employeeToAdd.DateFinished);
                MySqlParameter pvgParam = new MySqlParameter("@pvgdate", employeeToAdd.PVGDate);
                MySqlParameter entitledParam = new MySqlParameter("@holidaysentitled", employeeToAdd.HolidaysEntitled);
                MySqlParameter takenParam = new MySqlParameter("@holidaystaken", employeeToAdd.HolidaysTaken);
                MySqlParameter hoursParam = new MySqlParameter("@hours", employeeToAdd.WeeksHours);
                MySqlParameter addressParam = new MySqlParameter("@holidaysentitled", employeeToAdd.Address);
                MySqlParameter dobParam = new MySqlParameter("@dob", employeeToAdd.DOB);
                MySqlParameter salaryParam = new MySqlParameter("@salary", employeeToAdd.Salary); 
                MySqlParameter homePhoneParam = new MySqlParameter("@homephone", employeeToAdd.HomePhone);
                MySqlParameter mobilePhoneParam = new MySqlParameter("@homephone", employeeToAdd.MobilePhone);
                MySqlParameter emailParam = new MySqlParameter("@email", employeeToAdd.Email);//?
                MySqlParameter trainingParam = new MySqlParameter("@training", employeeToAdd.Training);
                MySqlParameter medicalParam = new MySqlParameter("@medical", employeeToAdd.Medical);
                MySqlParameter ecParam = new MySqlParameter("@ec", employeeToAdd.EmergencyContact);

                insertCommand.Parameters.Add(fNameParam);
                insertCommand.Parameters.Add(lNameParam);
                insertCommand.Parameters.Add(positionParam);
                insertCommand.Parameters.Add(genderParam);
                insertCommand.Parameters.Add(dateAppliedParam);
                insertCommand.Parameters.Add(dateLeftParam);
                insertCommand.Parameters.Add(pvgParam);
                insertCommand.Parameters.Add(entitledParam);
                insertCommand.Parameters.Add(takenParam);
                insertCommand.Parameters.Add(hoursParam);
                insertCommand.Parameters.Add(addressParam);
                insertCommand.Parameters.Add(dobParam);
                insertCommand.Parameters.Add(salaryParam);
                insertCommand.Parameters.Add(homePhoneParam);
                insertCommand.Parameters.Add(mobilePhoneParam);
                insertCommand.Parameters.Add(emailParam);
                insertCommand.Parameters.Add(trainingParam);
                insertCommand.Parameters.Add(medicalParam);
                insertCommand.Parameters.Add(ecParam);

                // Prepare statement
                Console.WriteLine("Executing: [ " + insertCommand.ToString() + "].");
                insertCommand.Prepare();
                insertCommand.ExecuteNonQuery();

            }
            catch (MySqlException mysqle)
            {
                return false;
            }

            return (CloseConnection()); //Successful or not

        }

        /*--------------SELECTS---------------*/

        public Child selectChild(int childIDToSelect)
        {
            if (!OpenConnection())
                return null;

            selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM child WHERE Child_ID = @childID;";
            selectCommand.Parameters.Add(new MySqlParameter("@childID", childIDToSelect));

            Console.WriteLine("Executing: [ " + selectCommand.ToString() + "].");
            selectCommand.Prepare();
            MySqlDataReader childReader = selectCommand.ExecuteReader();

            //Package into Child domain entity object
            Child newChild = new Child();
            while (childReader.Read())
            {
                //TODO: Use "employeeReader["ChildID"]" syntax instead?

                newChild.ChildID = childReader.GetInt32(0);
                newChild.FirstName = childReader.GetString(1);
                newChild.LastName = childReader.GetString(2);
                newChild.Gender = childReader.GetChar(3);
                newChild.DOB = childReader.GetDateTime(4);
                newChild.FirstLanguage = childReader.GetString(5);
                newChild.RoomAttending = childReader.GetString(6);
                //newEmployee.Sibling = employeeReader.Get7
                newChild.DateApplied = childReader.GetDateTime(8);
                newChild.DateLeft = childReader.GetDateTime(9);
               // newEmployee.Attendance = employeeReader.GetInt32(10);
                newChild.ExtraDays = childReader.GetInt16(11);
                newChild.Teas = childReader.GetInt16(12);
                //newEmployee.MedicalInformation = employeeReader.GetIny(13);
               // newEmployee.Parents = 
                //newEmployee.EmergencyContacts = 
            }
            childReader.Close();

            CloseConnection();

            return newChild;
        }

        public Parent selectParent(int parentIDToSelect)
        {
            if (!OpenConnection())
                return null;

            selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM parent_guardian WHERE ParentID = @parentID;";
            selectCommand.Parameters.Add(new MySqlParameter("@parentID", parentIDToSelect));

            Console.WriteLine("Executing: [ " + selectCommand.ToString() + "].");
            selectCommand.Prepare();
            MySqlDataReader parentReader = selectCommand.ExecuteReader();

            //Package into Parent domain entity object
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

        public EmergencyContact selectEmergencyContact(int ecIDToSelect)
        {
            if (!OpenConnection())
                return null;

            selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM emergency_contact WHERE ContactID = @contactID;";
            selectCommand.Parameters.Add(new MySqlParameter("@contactID", ecIDToSelect));

            Console.WriteLine("Executing: [ " + selectCommand.ToString() + "].");
            selectCommand.Prepare();
            MySqlDataReader ECReader = selectCommand.ExecuteReader();

            //Package into EmergencyContact domain entity object
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

            //Package into list of bools for Child domain entity object
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


        public Employee selectEmployee(String employeeNINo)
        {
            if (!OpenConnection())
                return null;

            selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM employee WHERE National_Insurance_Number = @nino;";
            selectCommand.Parameters.Add(new MySqlParameter("@nino", employeeNINo));

            Console.WriteLine("Executing: [ " + selectCommand.ToString() + "].");
            selectCommand.Prepare();
            MySqlDataReader employeeReader = selectCommand.ExecuteReader();

            //Package into Employee domain entity object
            Employee newEmployee = new Employee();
            while (employeeReader.Read())
            {
                //TODO: Use "employeeReader["ChildID"]" syntax instead?

                newEmployee.NINo = employeeReader.GetString(0);
                newEmployee.FirstName = employeeReader.GetString(1);
                newEmployee.LastName = employeeReader.GetString(2);
                newEmployee.Gender = employeeReader.GetChar(3);
                newEmployee.DateStarted = employeeReader.GetDateTime(4);
                newEmployee.DateFinished = employeeReader.GetDateTime(5);
                newEmployee.PVGDate = employeeReader.GetDateTime(6);
                newEmployee.HolidaysEntitled = employeeReader.GetInt32(7);
                newEmployee.HolidaysTaken = employeeReader.GetInt32(8);
                newEmployee.WeeksHours = employeeReader.GetInt32(9);
                //newEmployee.Address = employeeReader.GetString(10);
                newEmployee.DOB = employeeReader.GetDateTime(11);
                newEmployee.Salary = employeeReader.GetDecimal(12);
                newEmployee.HomePhone = employeeReader.GetString(13);
                newEmployee.MobilePhone = employeeReader.GetString(14);
                newEmployee.Email = employeeReader.GetString(15);

                newEmployee.Training = employeeReader.GetString(16);
                //newEmployee.MedicalInformation = employeeReader.GetInt(17);
               

                //newEmployee.EmergencyContacts = GetInt32(18)
            }
            employeeReader.Close();

            CloseConnection();

            return newEmployee;
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
