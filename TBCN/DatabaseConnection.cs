using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace TBCN
{

    public class Database
    {
        private const string connStr = "SERVER=arlia.computing.dundee.ac.uk;USER=12ac3u03;DATABASE=12ac3d03;PORT=3306;PASSWORD=ab123c;";
        //private MySqlConnection connection;
        //private MySqlCommand insertCommand;
        //private MySqlCommand selectCommand;
        //private MySqlCommand deleteCommand;

        private int childID;
        private int parentID;
        private int contactID;


        public Database()
        {
            //connection = new MySqlConnection(connStr);
            //insertCommand = new MySqlCommand(); 
        }

        public MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            return connection;
        }

        public bool CloseConnection(MySqlConnection connection)
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
        //TODO: Locks/Logs/Priveleges

        //TODO: STORED PROCEDURES!
        //TODO: VIEWS for levels of access!

        //TODO: TRANSACTIONS!
        //TODO: Joins instead of multiple selects?


        /*--------------INSERTS/UPDATES---------------*/

        public bool insertChild(Child childToAdd)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return false;

            MySqlTransaction transaction = connection.BeginTransaction();
            try
            {
                MySqlCommand insertCommand = new MySqlCommand(null, connection);
                MySqlCommand idCommand = new MySqlCommand("SELECT LAST_INSERT_ID()", connection);
                
                //insertCommand.Transaction = transaction;

                // Create and prepare an SQL statement.
                insertCommand.CommandText = @"INSERT INTO child (First_Name, Last_Name, Gender, DOB, First_Language, Room_Attending, Sibling, Date_Applied, Date_Left, Attendance, Extra_Days, Teas, Medical_Information)
                                            VALUES (@firstname, @lastname, @gender, @dob, @firstlanguage, @roomattending, @sibling, @dateapplied, @dateleft, @attendance, @extra, @teas, @medical);";
                
                //insertMedical(childToAdd.MedicalInfo);
                //int medicalID = (int)idCommand.ExecuteScalar();

               // //Fill in prepared statement parameters
               //// MySqlParameter idParam = new MySqlParameter("@id", childToAdd.ChildID);
               // MySqlParameter fNameParam = new MySqlParameter("@firstname", childToAdd.FirstName);
               // MySqlParameter lNameParam = new MySqlParameter("@lastname", childToAdd.LastName);
               // MySqlParameter genderParam = new MySqlParameter("@gender", childToAdd.Gender);
               // MySqlParameter dobParam = new MySqlParameter("@dob", childToAdd.DOB);
               // MySqlParameter languageParam = new MySqlParameter("@firstlanguage", childToAdd.FirstLanguage);
               // MySqlParameter roomParam = new MySqlParameter("@roomattending", childToAdd.RoomAttending); 
               // //MySqlParameter siblingParam = new MySqlParameter("@sibling", childToAdd.Sibling.ChildID);
               // MySqlParameter dateAppliedParam = new MySqlParameter("@dateapplied", childToAdd.DateApplied);
               // MySqlParameter dateLeftParam = new MySqlParameter("@dateleft", null);
               // MySqlParameter attendanceParam = new MySqlParameter("@attenance", null);
               // MySqlParameter extraParam = new MySqlParameter("@extra", childToAdd.ExtraDays);
               // MySqlParameter teasParam = new MySqlParameter("@teas", childToAdd.Teas);
               // MySqlParameter medicalParam = new MySqlParameter("@medical", 1/*medicalID*/);

                insertCommand.Parameters.AddWithValue("@firstname", childToAdd.FirstName);
                insertCommand.Parameters.AddWithValue("@lastname", childToAdd.LastName);
                insertCommand.Parameters.AddWithValue("@gender", childToAdd.Gender);
                insertCommand.Parameters.AddWithValue("@dob", childToAdd.DOB);
                insertCommand.Parameters.AddWithValue("@firstlanguage", childToAdd.FirstLanguage);
                insertCommand.Parameters.AddWithValue("@roomattending", childToAdd.RoomAttending);
                //insertCommand.Parameters.Add(siblingParam);
                insertCommand.Parameters.AddWithValue("@dateapplied", childToAdd.DateApplied);
                insertCommand.Parameters.AddWithValue("@dateleft", null);
                insertCommand.Parameters.AddWithValue("@attendance", 1/*childToAdd.Attendance*/);
                insertCommand.Parameters.AddWithValue("@extra", childToAdd.ExtraDays);
                insertCommand.Parameters.AddWithValue("@teas", childToAdd.Teas);
                insertCommand.Parameters.AddWithValue("@medical", 1/*medicalID*/);

                // Prepare statement
                Console.WriteLine("Executing: [ " + insertCommand.CommandText + "].");
                insertCommand.Prepare();
                Console.WriteLine("Executing: [ " + insertCommand.CommandText + "].");
                insertCommand.ExecuteNonQuery();


                childID = (int)idCommand.ExecuteScalar();
                insertAttendance(childToAdd);
                //insertMedical(childToAdd.MedicalInfo);
                //insertMedical(childToAdd.MedicalInfo);
                //insertParent(parent);
                //parentID = (int)idCommand.ExecuteScalar();
                //linkParentChild(childToAdd, parent);

                //insertEmergencyContact(ec);
                //contactID = (int)idCommand.ExecuteScalar();

                //linkECChild(ec, childToAdd);

                //Perform transaction
                transaction.Commit();
            }
            catch (MySqlException mysqle)
            {
                transaction.Rollback(); //Something went wrong, rollback
                return false;
            }

            return (CloseConnection(connection)); //Successful or not

        }

        public void insertParent(Parent parentToAdd)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return;

            MySqlCommand insertCommand = new MySqlCommand(null, connection);
            insertCommand.CommandText = @"INSERT INTO parent_guardian (First_Name, Last_Name, Title, Gender, Work_Phone, Home_Phone, Mobile_Phone, Home_Address, Work_Address, Spouse, Email)
                                        VALUES (@firstname, @lastname, @title, @gender, @workphone, @homephone, @mobilephone, @homeaddress, @workaddress, @spouse, @email);";

            //MySqlParameter idParam = new MySqlParameter("@id", parentToAdd.ParentID);
            //MySqlParameter fNameParam = new MySqlParameter("@firstname", parentToAdd.FirstName);
            //MySqlParameter lNameParam = new MySqlParameter("@lastname", parentToAdd.LastName);
            //MySqlParameter genderParam = new MySqlParameter("@gender", parentToAdd.Gender);
            //MySqlParameter titleParam = new MySqlParameter("@title", parentToAdd.Title);
            //MySqlParameter workPhoneParam = new MySqlParameter("@workphone", parentToAdd.WorkPhone); 
            //MySqlParameter homePhoneParam = new MySqlParameter("@homephone", parentToAdd.HomePhone);
            //MySqlParameter mobilePhoneParam = new MySqlParameter("@mobilephone", parentToAdd.MobilePhone);
            //MySqlParameter homeAddrParam = new MySqlParameter("@homeaddress", parentToAdd.HomeAddress.Address1);
            //MySqlParameter workAddrParamParam = new MySqlParameter("@workaddress", parentToAdd.WorkAddress.Address1);
            //MySqlParameter spouseParam = new MySqlParameter("@spouse", parentToAdd.Spouse);
            //MySqlParameter emailParam = new MySqlParameter("@email", parentToAdd.Email);

            insertCommand.Parameters.AddWithValue("@firstname", parentToAdd.FirstName);
            insertCommand.Parameters.AddWithValue("@lastname", parentToAdd.LastName);
            insertCommand.Parameters.AddWithValue("@gender", parentToAdd.Gender);
            insertCommand.Parameters.AddWithValue("@title", parentToAdd.Title);
            insertCommand.Parameters.AddWithValue("@workphone", parentToAdd.WorkPhone);
            insertCommand.Parameters.AddWithValue("@homephone", parentToAdd.HomePhone);
            insertCommand.Parameters.AddWithValue("@mobilephone", parentToAdd.MobilePhone);
            insertCommand.Parameters.AddWithValue("@homeaddress", parentToAdd.HomeAddress.Address1);
            insertCommand.Parameters.AddWithValue("@workaddress", parentToAdd.WorkAddress.Address1);
            insertCommand.Parameters.AddWithValue("@spouse", parentToAdd.Spouse);
            insertCommand.Parameters.AddWithValue("@email", parentToAdd.Email);

            // Call Prepare after setting the Commandtext and Parameters.
            Console.WriteLine("Executing: [ " + insertCommand.CommandText + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();

            CloseConnection(connection);
        }

        public void linkParentChild(Child childToAdd, Parent parent)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return;

            MySqlCommand insertCommand = new MySqlCommand(null, connection);
            insertCommand.CommandText = "INSERT INTO child_has_parent_guardian VALUES (@childID, @parentID);";
            insertCommand.Parameters.AddWithValue("@childID", childToAdd.ChildID);
            insertCommand.Parameters.AddWithValue("@parentID", parent.ParentID);

            Console.WriteLine("Executing: [ " + insertCommand.CommandText + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();

            CloseConnection(connection);
        }

        public void insertEmergencyContact(EmergencyContact ecToAdd)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return;


           
            MySqlCommand insertCommand = new MySqlCommand(null, connection);
            insertCommand.CommandText = @"INSERT INTO emergency_contact (Title, First_Name, Last_Name, Relationship, Home_Phone, Work_Phone, Mobile_Phone, Home_Address, Work_Address, Gender, Email)
                                        VALUES (@title, @firstname, @lastname, @relationship, @homephone, @workphone, @mobilephone, @homeaddress, @workaddress, @gender, @email);";

//MySqlParameter idParam = new MySqlParameter("@id", ecToAdd.ContactID);
            //MySqlParameter fNameParam = new MySqlParameter("@firstname", ecToAdd.FirstName);
            //MySqlParameter lNameParam = new MySqlParameter("@lastname", ecToAdd.LastName);
            //MySqlParameter genderParam = new MySqlParameter("@gender", ecToAdd.Gender);
            //MySqlParameter titleParam = new MySqlParameter("@title", ecToAdd.Title);
            //MySqlParameter relParam = new MySqlParameter("@relationship", ecToAdd.Relationship);
            //MySqlParameter workPhoneParam = new MySqlParameter("@workphone", ecToAdd.WorkPhone); 
            //MySqlParameter homePhoneParam = new MySqlParameter("@homephone", ecToAdd.HomePhone);
            //MySqlParameter mobilePhoneParam = new MySqlParameter("@mobilephone", ecToAdd.MobilePhone);
            //MySqlParameter homeAddrParam = new MySqlParameter("@homeaddress", ecToAdd.HomeAddress.Address1);
            //MySqlParameter workAddrParamParam = new MySqlParameter("@workaddress", ecToAdd.WorkAddress.Address1);
            //MySqlParameter emailParam = new MySqlParameter("@email", ecToAdd.Email);

            insertCommand.Parameters.AddWithValue("@title", ecToAdd.Title);
            insertCommand.Parameters.AddWithValue("@firstname", ecToAdd.FirstName);
            insertCommand.Parameters.AddWithValue("@lastname", ecToAdd.LastName);
            insertCommand.Parameters.AddWithValue("@relationship", ecToAdd.Relationship);
            insertCommand.Parameters.AddWithValue("@homephone", ecToAdd.HomePhone);
            insertCommand.Parameters.AddWithValue("@workphone", ecToAdd.WorkPhone);
            insertCommand.Parameters.AddWithValue("@mobilephone", ecToAdd.MobilePhone);
            insertCommand.Parameters.AddWithValue("@homeaddress", ecToAdd.HomeAddress.Address1);
            insertCommand.Parameters.AddWithValue("@workaddress", ecToAdd.WorkAddress.Address1);
            insertCommand.Parameters.AddWithValue("@gender", ecToAdd.Gender);
            insertCommand.Parameters.AddWithValue("@email", ecToAdd.Email);
            

            Console.WriteLine("Executing: [ " + insertCommand.CommandText + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();

            CloseConnection(connection);
        }

        public void linkECChild(EmergencyContact ecToAdd, Child childToAdd)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return;

            MySqlCommand insertCommand = new MySqlCommand(null, connection);
            insertCommand.CommandText = "INSERT INTO child_has_emergency_contact VALUES (@contactID, @childID);";

            insertCommand.Parameters.AddWithValue("@contactID", ecToAdd.ContactID);
            insertCommand.Parameters.AddWithValue("@childID", childToAdd.ChildID);

            Console.WriteLine("Executing: [ " + insertCommand.CommandText + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();

            CloseConnection(connection);
        }

        public void insertAttendance(Child childToAdd)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return;

            MySqlCommand insertCommand = new MySqlCommand(null, connection);
            insertCommand.CommandText = @"INSERT INTO attendance VALUES (@child, @monday, @tuesday, @wednesday, @thursday, @friday);";

            insertCommand.Parameters.AddWithValue("@child", childToAdd.ChildID);
            insertCommand.Parameters.AddWithValue("@monday", childToAdd.Attendance[0]);
            insertCommand.Parameters.AddWithValue("@tuesday", childToAdd.Attendance[1]);
            insertCommand.Parameters.AddWithValue("@wednesday", childToAdd.Attendance[2]);
            insertCommand.Parameters.AddWithValue("@thursday", childToAdd.Attendance[3]);
            insertCommand.Parameters.AddWithValue("@friday", childToAdd.Attendance[4]);

            Console.WriteLine("Executing: [ " + insertCommand.CommandText + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();

            CloseConnection(connection);
        }

        public void insertAddress(Address addressToAdd)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return;

            MySqlCommand insertCommand = new MySqlCommand(null, connection);
            insertCommand.CommandText = @"INSERT INTO address VALUES (@address1, @city, @county, @postcode, @country);";

            insertCommand.Parameters.AddWithValue("@address1", addressToAdd.Address1);
            insertCommand.Parameters.AddWithValue("@city", addressToAdd.City);
            insertCommand.Parameters.AddWithValue("@county", addressToAdd.County);
            insertCommand.Parameters.AddWithValue("@postcode", addressToAdd.PostCode);
            insertCommand.Parameters.AddWithValue("@country", "UK");

            Console.WriteLine("Executing: [ " + insertCommand.CommandText + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();

            CloseConnection(connection);
        }

        public void insertMedical(MedicalInformation medicalToAdd)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return;

            MySqlCommand insertCommand = new MySqlCommand(null, connection);
            insertCommand.CommandText = @"INSERT INTO medical_information VALUES (@medicalid, @allergies, @medication, @other, @doctor, @doctoraddress);";

            insertCommand.Parameters.AddWithValue("@medicalid", medicalToAdd.MedicalID);
            insertCommand.Parameters.AddWithValue("@allergies", medicalToAdd.Allergies);
            insertCommand.Parameters.AddWithValue("@medication", medicalToAdd.Medication);
            insertCommand.Parameters.AddWithValue("@other", medicalToAdd.Other);
            insertCommand.Parameters.AddWithValue("@doctor", medicalToAdd.Doctor);
            insertCommand.Parameters.AddWithValue("@doctoraddress", medicalToAdd.DoctorAddress.Address1);

            Console.WriteLine("Executing: [ " + insertCommand.CommandText + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();

            CloseConnection(connection);
        }

        public bool insertEmployee(Employee employeeToAdd)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return false;

            try
            {

                MySqlCommand insertCommand = new MySqlCommand(null, connection);

                // Create and prepare an SQL statement.
                insertCommand.CommandText = @"INSERT INTO employee 
                                            VALUES (@nino, @firstname, @lastname, @position, @gender, @datestarted, @datefinished, @pvgdate, @holidaysentitled, @holidaystaken, @hours, @address, @dob, @salary, @homephone, @mobilephone, @email, @training, @medical, @ec);";

                //Fill in prepared statement parameters
                

                insertCommand.Parameters.AddWithValue("@nino", employeeToAdd.NINo);
                insertCommand.Parameters.AddWithValue("@firstname", employeeToAdd.FirstName);
                insertCommand.Parameters.AddWithValue("@lastname", employeeToAdd.LastName);
                insertCommand.Parameters.AddWithValue("@position", employeeToAdd.Position);
                insertCommand.Parameters.AddWithValue("@gender", employeeToAdd.Gender);
                insertCommand.Parameters.AddWithValue("@datestarted", employeeToAdd.DateStarted);
                insertCommand.Parameters.AddWithValue("@datefinished", employeeToAdd.DateFinished);
                insertCommand.Parameters.AddWithValue("@pvgdate", employeeToAdd.PVGDate);
                insertCommand.Parameters.AddWithValue("@holidaysentitled", employeeToAdd.HolidaysEntitled);
                insertCommand.Parameters.AddWithValue("@holidaystaken", employeeToAdd.HolidaysTaken);
                insertCommand.Parameters.AddWithValue("@hours", employeeToAdd.WeeksHours);
                insertCommand.Parameters.AddWithValue("@address", employeeToAdd.Address.Address1);
                insertCommand.Parameters.AddWithValue("@salary", employeeToAdd.Salary);
                insertCommand.Parameters.AddWithValue("@homephone", employeeToAdd.HomePhone);
                insertCommand.Parameters.AddWithValue("@mobile", employeeToAdd.MobilePhone);
                insertCommand.Parameters.AddWithValue("@email", employeeToAdd.Email);
                insertCommand.Parameters.AddWithValue("@training", employeeToAdd.Training);
                insertCommand.Parameters.AddWithValue("@medical", employeeToAdd.Medical.MedicalID);
                //insertCommand.Parameters.AddWithValue("@ec", employeeToAdd.EmergencyContact.ContactID);

                // Prepare statement
                Console.WriteLine("Executing: [ " + insertCommand.CommandText + "].");
                insertCommand.Prepare();
                insertCommand.ExecuteNonQuery();

            }
            catch (MySqlException mysqle)
            {
                return false;
            }

            return (CloseConnection(connection)); //Successful or not

        }

        /*--------------SELECTS---------------*/

        public List<Child> selectAllChildren()
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = @"SELECT *, child_has_parent_guardian.child_id as parent_child, child_has_parent_guardian.parent_id as child_parent ,
                                        child_has_emergency_contact.child_id as contact_child, child_has_emergency_contact.contact_id as child_contact
                                        FROM child 
                                        INNER JOIN attendance ON child.attendance = attendance.child_id
                                        INNER JOIN medical_information ON child.medical_information = medical_information.Medical_ID
                                        INNER JOIN child_has_parent_guardian ON child.Child_ID = child_has_parent_guardian.Child_ID
                                        INNER JOIN child_has_emergency_contact ON child.Child_ID = child_has_emergency_contact.Child_ID
                                        INNER JOIN address ON Doctor_Address = address.Address_1;";

            Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
            MySqlDataReader childReader = selectCommand.ExecuteReader();

            List<Child> allChildren = new List<Child>();
            while(childReader.Read())
            {
                Child newChild = constructChild(childReader);
                //TODO: This work for multiple columns?
                newChild.ParentsIDs.Add(childReader.GetInt16("child_parent"));
                newChild.EmergencyContactsIDs.Add(childReader.GetInt16("child_contact"));

                allChildren.Add(newChild);
            }

            return allChildren;
        }

        //TODO: Check multiple "Address_!" columns?
        public List<Parent> selectAllParents()
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = @"SELECT *, homeAddr.Address_1 as home1, homeAddr.City as homeCity, homeAddr.County as homeCounty, homeAddr.PostCode as homePostCode, 
                                        workAddr.Address_1 as work1, workAddr.City as workCity, workAddr.County as workCounty, workAddr.PostCode as workPostCode
                                        FROM parent_guardian
                                        INNER JOIN address homeAddr ON parent_guardian.Home_Address = homeAddr.Address_1
                                        INNER JOIN address workAddr ON parent_guardian.Work_Address = workAddr.Address_1
                                        INNER JOIN child_has_parent_guardian ON parent_guardian.Parent_ID = child_has_parent_guardian.Parent_ID;";

            Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
            MySqlDataReader parentReader = selectCommand.ExecuteReader();

            List<Parent> allParents = new List<Parent>();
            while (parentReader.Read())
            {
                Parent newParent = constructParent(parentReader);

                newParent.ChildrenAttending.Add(parentReader.GetInt16("Child_ID"));
                allParents.Add(newParent);
            }

            return allParents;
        }

        public List<Employee> selectAllStaff()
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = @"SELECT * FROM employee
                                        INNER JOIN address ON employee.home_address = address.Address_1
                                        INNER JOIN medical_information ON employee.medical_information = medical_information.Medical_ID;";

            Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
            MySqlDataReader staffReader = selectCommand.ExecuteReader();

            List<Employee> allStaff = new List<Employee>();
            while (staffReader.Read())
            {
                Employee newEmployee = constructEmployee(staffReader);
                allStaff.Add(newEmployee);
            }

            return allStaff;
        }

        

        //public Child searchChildrenByID(int childIDToSelect)
        //{
        //    MySqlConnection connection = OpenConnection();
        //    if (connection == null)
        //        return null;

        //    MySqlCommand selectCommand = new MySqlCommand(null, connection);
        //    selectCommand.CommandText = @"SELECT * FROM child WHERE Child_ID = @childid;";
        //    selectCommand.Parameters.Add(new MySqlParameter("@childid", childIDToSelect));

        //    Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
        //    selectCommand.Prepare();
        //    MySqlDataReader childReader = selectCommand.ExecuteReader();

        //    //Package into Child domain entity object
        //    Child newChild = new Child();
        //    while (childReader.Read())
        //    {
        //        //TODO: Use "employeeReader["ChildID"]" syntax instead?

        //        newChild.ChildID = childReader.GetInt32(0);
        //        newChild.FirstName = childReader.GetString(1);
        //        newChild.LastName = childReader.GetString(2);
        //        newChild.Gender = childReader.GetChar(3);
        //        newChild.DOB = childReader.GetDateTime(4);
        //        newChild.FirstLanguage = childReader.GetString(5);
        //        newChild.RoomAttending = childReader.GetString(6);
        //        //newChild.Sibling = childReader.Get7
        //        newChild.DateApplied = childReader.GetDateTime(8);
        //        newChild.DateLeft = childReader.GetDateTime(9);
        //        newChild.Attendance = selectAttendance(newChild.ChildID);
        //        newChild.ExtraDays = childReader.GetInt16(11);
        //        newChild.Teas = childReader.GetInt16(12);
        //        newChild.MedicalInfo = selectMedicalInformation(childReader.GetInt16(13));

        //        //Get parents
        //        foreach (int parentID in selectChildsParentIDs(newChild.ChildID))
        //            newChild.Parents.Add(selectParent(parentID));

        //        //Get Emergency Contacts
        //        foreach (int contactID in selectChildsContactIDs(newChild.ChildID))
        //            newChild.EmergencyContacts.Add(selectEmergencyContact(contactID)); 

        //    }
        //    childReader.Close();

        //    CloseConnection(connection);

        //    return newChild;
        //}

        private List<int> selectChildsParentIDs(int childID)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;


            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM child_has_parent_guardian WHERE Child_ID = @childID;";
            selectCommand.Parameters.AddWithValue("@childID", childID);

            Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
            selectCommand.Prepare();
            MySqlDataReader parentReader = selectCommand.ExecuteReader();

            //Get list of parent ids
            List<int> parentIDs = new List<int>();
            while (parentReader.Read())
            {
                parentIDs.Add(parentReader.GetInt32(0));
            }

            CloseConnection(connection);
            return parentIDs;
        }

        private List<int> selectParentsChildIDs(int parentID)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM child_has_parent_guardian WHERE Parent_ID = @parentID;";
            selectCommand.Parameters.AddWithValue("@parentID", parentID);

            Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
            selectCommand.Prepare();
            MySqlDataReader childReader = selectCommand.ExecuteReader();

            //Get list of Child ids
            List<int> childIDs = new List<int>();
            while (childReader.Read())
            {
                childIDs.Add(childReader.GetInt32(1));
            }

            CloseConnection(connection);
            return childIDs;            
        }

        private List<int> selectChildsContactIDs(int childID)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM child_has_emergency_contact WHERE Child_ID = @childID;";
            selectCommand.Parameters.AddWithValue("@childID", childID);

            Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
            selectCommand.Prepare();
            MySqlDataReader ecReader = selectCommand.ExecuteReader();

            //Get list of emergency contact ids
            List<int> contactIDs = new List<int>();
            while (ecReader.Read())
            {
                contactIDs.Add(ecReader.GetInt32(0));
            }

            CloseConnection(connection);
            return contactIDs;

            
        }

        private List<int> selectContactsChildIDs(int contactID)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM child_has_emergency_contact WHERE Contact_ID = @contactID;";
            selectCommand.Parameters.AddWithValue("@contactID", contactID);

            Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
            selectCommand.Prepare();
            MySqlDataReader childReader = selectCommand.ExecuteReader();

            //get list of child ids
            List<int> childIDs = new List<int>();
            while (childReader.Read())
            {
                childIDs.Add(childReader.GetInt32(1));
            }

            CloseConnection(connection);
            return childIDs;

            
        }

        private MedicalInformation selectMedicalInformation(int medicalID)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM medical_information WHERE Medical_ID = @medicalID;";
            selectCommand.Parameters.AddWithValue("@medicalID", medicalID);

            selectCommand.Prepare();
            MySqlDataReader medicalReader = selectCommand.ExecuteReader();

            MedicalInformation newMedical = new MedicalInformation();
            while (medicalReader.Read())
            {
                newMedical = constructMedical(medicalReader);
            }

            CloseConnection(connection);
            return newMedical;

        }

        private Address selectAddress(String address1)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM address WHERE Address_1 = @address1;";
            selectCommand.Parameters.AddWithValue("@address1", address1);

            selectCommand.Prepare();
            MySqlDataReader addressReader = selectCommand.ExecuteReader();

            Address newAddress = new Address();
            while (addressReader.Read())
            {
                newAddress = constructAddress(addressReader);
            }

            CloseConnection(connection);


            return newAddress;

            
        }

        public Parent selectParent(int parentIDToSelect)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = @"SELECT * FROM parent_guardian WHERE Parent_ID = @parentID
                                        INNER JOIN address homeAddr ON parent_guardian.Home_Address = homeAddr.Address_1
                                        INNER JOIN address workAddr ON parent_guardian.Work_Address = wordAddr.Address_1
                                        INNER JOIN child_has_parent_guardian ON parent_guardian.Parent_ID = child_has_parent_guardian.Parent_ID
                                        WHERE parent_guardian.Parent_ID = @parentID;";
            selectCommand.Parameters.AddWithValue("@parentID", parentIDToSelect);

            Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
            selectCommand.Prepare();
            MySqlDataReader parentReader = selectCommand.ExecuteReader();

            //Package into Parent domain entity object
            Parent newParent = new Parent();
            while (parentReader.Read())
            {
                newParent = constructParent(parentReader);
                newParent.ChildrenAttending.Add(parentReader.GetInt16("Child_ID"));
            }
            parentReader.Close();

            CloseConnection(connection);

            return newParent;
        }

        public EmergencyContact selectEmergencyContact(int ecIDToSelect)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = @"SELECT * , homeAddr.Address_1 as home1, homeAddr.City as homeCity, homeAddr.County as homeCounty,  homeAddr.PostCode as homePostCode, 
                                        workAddr.Address_1 as work1, workAddr.City as workCity, workAddr.County as workCounty,  workAddr.PostCode as workPostCode
                                        FROM emergency_contact
                                        INNER JOIN address homeAddr ON emergency_contact.Home_Address = homeAddr.Address_1
                                        INNER JOIN address workAddr ON emergency_contact.Work_Address = workAddr.Address_1
                                        WHERE emergency_contact.Contact_ID = @contactID;";
            selectCommand.Parameters.AddWithValue("@contactID", ecIDToSelect);

            Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
            selectCommand.Prepare();
            MySqlDataReader ECReader = selectCommand.ExecuteReader();

            //Package into EmergencyContact domain entity object
            EmergencyContact newEC = new EmergencyContact();
            while (ECReader.Read())
            {
                newEC = constructEmergencyContact(ECReader);
                
            }
            ECReader.Close();

            CloseConnection(connection);

            return newEC;
        }

        //public Employee selectContactsEmployee(int contactID)
        //{
        //    if (!OpenConnection())
        //        return null;

        //    selectCommand = new MySqlCommand(null, connection);
        //    selectCommand.CommandText = "SELECT * FROM emergency_contact WHERE Contact_ID = @contactID;";
        //    selectCommand.Parameters.Add(new MySqlParameter("@contactID", contactID));

        //    Console.WriteLine("Executing: [ " + selectCommand.CommandText+ "].");
        //    selectCommand.Prepare();
        //    MySqlDataReader ECReader = selectCommand.ExecuteReader();

        //    //Package into EmergencyContact domain entity object
        //    EmergencyContact newEC = new EmergencyContact();
        //    while (ECReader.Read())
        //    {
        //        newEC.ContactID = ECReader.GetInt32(0);
        //        newEC.Title = ECReader.GetString(1);
        //        newEC.FirstName = ECReader.GetString(2);
        //        newEC.LastName = ECReader.GetString(3);
        //        newEC.Relationship = ECReader.GetString(4);
        //        newEC.HomePhone = ECReader.GetString(5);
        //        newEC.WorkPhone = ECReader.GetString(6);
        //        newEC.MobilePhone = ECReader.GetString(7);
        //        newEC.HomeAddress = selectAddress(ECReader.GetString(8));
        //        newEC.WorkAddress = selectAddress(ECReader.GetString(9));
        //        newEC.Gender = ECReader.GetChar(10);
        //        newEC.Email = ECReader.GetString(11);

        //        //Get children
        //        foreach (int childID in selectContactsChildIDs(newEC.ContactID))
        //            newEC.ChildrenAttending.Add(searchChildrenByName(childID));

        //        //newEC.Employee = selectEmployee(ECReader.GetString(5)
        //    }
        //    ECReader.Close();

        //    CloseConnection();

        //    return newEC;
        //}

        //Get a child's attendance

        public bool[] selectAttendance(int childID)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM attendance WHERE Child_ID = @childID;";
            selectCommand.Parameters.AddWithValue("@childID", childID);

            Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
            selectCommand.Prepare();
            MySqlDataReader attendanceReader = selectCommand.ExecuteReader();

            //Package into list of bools for Child domain entity object
            bool[] attendanceArray = new bool[5];
            while (attendanceReader.Read())
            {
                attendanceArray = constructAttendance(attendanceReader);
            }
            attendanceReader.Close();

            CloseConnection(connection);

            return attendanceArray;
        }

        //TODO:
        public Room selectRoom(int minAge, int maxAge)
        {
            return null;

        }

        public Employee selectEmployee(String employeeNINo)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = @"SELECT * FROM employee 
                                        INNER JOIN address ON employee.Home_Address = address.Address_1
                                        INNER JOIN medical_information ON employee.Medical_Information = medical_information.Medical_ID
                                        WHERE National_Insurance_Number = @nino;";
            selectCommand.Parameters.AddWithValue("@nino", employeeNINo);

            Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
            selectCommand.Prepare();
            MySqlDataReader employeeReader = selectCommand.ExecuteReader();

            //Package into Employee domain entity object
            Employee newEmployee = new Employee();
            while (employeeReader.Read())
            {
                newEmployee = constructEmployee(employeeReader);
            }
            employeeReader.Close();

            CloseConnection(connection);

            return newEmployee;

        }

        private Child constructChild(MySqlDataReader childrenReader)
        {
            Child newChild = new Child();
            newChild.ChildID = childrenReader.GetInt32("Child_Id");
            newChild.FirstName = childrenReader.GetString("First_Name");
            newChild.LastName = childrenReader.GetString("Last_Name");
            newChild.Gender = childrenReader.GetChar("Gender");
            newChild.DOB = childrenReader.GetDateTime("DOB");
            
            newChild.FirstLanguage = childrenReader.GetString("First_Language");
            newChild.RoomAttending = childrenReader.GetString("Room_Attending");
            //newChild.Sibling = SafeGetInt(childrenReader, "Sibling");
            newChild.DateApplied = childrenReader.GetDateTime("Date_Applied");
            newChild.DateLeft = SafeGetDateTime(childrenReader, "Date_Left");
            newChild.Attendance = constructAttendance(childrenReader);
            newChild.ExtraDays = childrenReader.GetInt16("Extra_Days");
            newChild.Teas = childrenReader.GetInt16("Teas");
            newChild.MedicalInfo = constructMedical(childrenReader);

            //newChild.ParentsIDs.Add(childrenReader.GetInt16(16));
            //newChild.EmergencyContactsIDs.Add(childrenReader.GetInt16(16));
            //Get parents
            //foreach (int parentID in selectChildsParentIDs(newChild.ChildID))
            //    newChild.Parents.Add(constructParent(childrenReader, 16));

            ////Get Emergency Contacts
            //foreach (int contactID in selectChildsContactIDs(newChild.ChildID))
            //    newChild.EmergencyContacts.Add(selectEmergencyContact(contactID), 30);
            return newChild;
        }

        private EmergencyContact constructEmergencyContact(MySqlDataReader ECReader)
        {
            EmergencyContact newEC = new EmergencyContact();
            newEC.ContactID = ECReader.GetInt32("Contact_ID");
            newEC.Title = ECReader.GetString("Title");
            newEC.FirstName = ECReader.GetString("First_Name");
            newEC.LastName = ECReader.GetString("Last_Name");
            newEC.Relationship = ECReader.GetString("Relationship");
            newEC.HomePhone = ECReader.GetString("Home_Phone");
            newEC.WorkPhone = ECReader.GetString("Work_Phone");
            newEC.MobilePhone = ECReader.GetString("Mobile_Phone");
            newEC.HomeAddress = constructMultipleAddress(ECReader, "home");
            newEC.WorkAddress = constructMultipleAddress(ECReader, "work");
            newEC.Gender = ECReader.GetChar("Gender");
            newEC.Email = ECReader.GetString("Email");

            return newEC;
        }

        private Employee constructEmployee(MySqlDataReader staffReader)
        {
            Employee newEmployee = new Employee();
            newEmployee.NINo = staffReader.GetString("National_Insurance_Number");
            newEmployee.FirstName = staffReader.GetString("First_Name");
            newEmployee.LastName = staffReader.GetString("Last_Name");
            newEmployee.Position = staffReader.GetString("Position");
            newEmployee.Gender = staffReader.GetChar("Gender");
            newEmployee.DateStarted = staffReader.GetDateTime("Date_Started");
            newEmployee.DateFinished = SafeGetDateTime(staffReader, "Date_Finished");
            newEmployee.PVGDate = staffReader.GetDateTime("PVG_Date");
            newEmployee.HolidaysEntitled = staffReader.GetInt16("Holidays_Entitled");
            newEmployee.HolidaysTaken = staffReader.GetInt16("Holidays_Taken");
            newEmployee.WeeksHours = staffReader.GetInt16("Hours");
            newEmployee.Address = constructAddress(staffReader);
            newEmployee.DOB = staffReader.GetDateTime("DOB");
            newEmployee.Salary = staffReader.GetDecimal("Salary");
            newEmployee.HomePhone = staffReader.GetString("Home_Phone");
            newEmployee.MobilePhone = staffReader.GetString("Mobile_Phone");
            newEmployee.Email = staffReader.GetString("Email");
            newEmployee.Training = SafeGetString(staffReader, "Training");
            newEmployee.Medical = constructMedical(staffReader);
            //EC...
            return newEmployee;
        }

        private Parent constructParent(MySqlDataReader parentReader)
        {
            Parent newParent = new Parent();
            newParent.ParentID = parentReader.GetInt32("Parent_ID");
            newParent.FirstName = parentReader.GetString("First_Name");
            newParent.LastName = parentReader.GetString("Last_Name");
            newParent.Title = parentReader.GetString("Title");
            newParent.Gender = parentReader.GetChar("Gender");
            newParent.HomePhone = parentReader.GetString("Home_Phone");
            newParent.WorkPhone = parentReader.GetString("Work_Phone");
            newParent.MobilePhone = parentReader.GetString("Mobile_Phone");
            newParent.HomeAddress = constructMultipleAddress(parentReader, "home");
            newParent.WorkAddress = constructMultipleAddress(parentReader, "work");
            //newParent.Spouse = childReader.GetInt16(10);
            newParent.Email = parentReader.GetString("Email");

            //Neglecting list of children?

            return newParent;
        }

        private MedicalInformation constructMedical(MySqlDataReader medicalReader)
        {
            MedicalInformation newMedical = new MedicalInformation();
            newMedical.MedicalID = medicalReader.GetInt16("Medical_ID");
            newMedical.Allergies = SafeGetString(medicalReader, "Allergies");
            newMedical.Medication = SafeGetString(medicalReader, "Medication");
            newMedical.Other = SafeGetString(medicalReader, "Other");
            newMedical.Doctor = medicalReader.GetString("Doctor");
            newMedical.DoctorAddress = constructAddress(medicalReader);
            return newMedical;

        }

        private Address constructAddress(MySqlDataReader addressReader)
        {
            Address newAddress = new Address();
            newAddress.Address1 = addressReader.GetString("Address_1");
            newAddress.City = addressReader.GetString("City");
            newAddress.County = addressReader.GetString("County");
            newAddress.PostCode = addressReader.GetString("PostCode");
            newAddress.Country = SafeGetString(addressReader, "Country");
            return newAddress;
        }

        private Address constructMultipleAddress(MySqlDataReader addressReader, String prefix)
        {
            Address newAddress = new Address();
            newAddress.Address1 = addressReader.GetString(prefix + "1");
            newAddress.City = addressReader.GetString(prefix + "City");
            newAddress.County = addressReader.GetString(prefix + "County");
            newAddress.PostCode = addressReader.GetString(prefix + "PostCode");
            newAddress.Country = "UK";
            return newAddress;
        }

        private bool[] constructAttendance(MySqlDataReader attendanceReader)
        {
            bool[] attendanceArray = new bool[5];
            
            attendanceArray[0] = attendanceReader.GetBoolean("Monday");
            attendanceArray[1] = attendanceReader.GetBoolean("Tuesday");
            attendanceArray[2] = attendanceReader.GetBoolean("Wednesday");
            attendanceArray[3] = attendanceReader.GetBoolean("Thursday");
            attendanceArray[4] = attendanceReader.GetBoolean("Friday");

            return attendanceArray;
        }

        public List<Employee> searchStaff(string staffSearchString)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            String[] names = new String[2];
            if (staffSearchString.Contains(' '))
                names = staffSearchString.Split(' ');

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = @"SELECT * FROM employee WHERE First_Name = @searchString
                                        OR Last_Name = @searchString
                                        OR (First_Name = @firstname
                                            AND Last_Name = @lastname)
                                        OR National_Insurance_Number = @searchString;";
            selectCommand.Parameters.AddWithValue("@name", staffSearchString);
            selectCommand.Parameters.AddWithValue("@firstname", names[0]);
            selectCommand.Parameters.AddWithValue("@lastname", names[1]);

            Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
            selectCommand.Prepare();
            MySqlDataReader staffReader = selectCommand.ExecuteReader();

            //Package into Employee domain entity object
            List<Employee> staff = new List<Employee>();
            while (staffReader.Read())
            {
                Employee newEmployee = constructEmployee(staffReader);
                staff.Add(newEmployee);
            }
            staffReader.Close();
            CloseConnection(connection);
            return staff;
        }

        //TODO:
        public List<Parent> searchParent(string parentSearchString)
        {
            throw new NotImplementedException();
        }

        public List<Child> searchChildrenByName(string childName)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            String[] names = new String[2];
            if (childName.Contains(' '))
                names = childName.Split(' ');

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = @"SELECT * FROM child
                                        INNER JOIN child_has_parent_guardian ON child.child_id = child_has_parent_guardian.child_id
                                        INNER JOIN parent_guardian ON parent_guardian.parent_id = child_has_parent_guardian.parent_id
                                        INNER JOIN child_has_emergency_contact ON child.child_id = child_has_emergency_contact.child_id
                                        INNER JOIN emergency_contact ON emergency_contact.contact_id = child_has_emergency_contact.contact_id
                                        INNER JOIN attendance ON attendance.child_id = child.child_id
                                        INNER JOIN address ON parent_guardian.home_address AND parent_guardian.work_address = address.address_1
                                        WHERE child.child_id = @name OR child.First_Name = @name OR child.Last_Name = @name OR (child.First_Name = @firstname AND child.Last_Name = @lastname);";
            //selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@name", childName);
            selectCommand.Parameters.AddWithValue("@firstname", names[0]);
            selectCommand.Parameters.AddWithValue("@lastname", names[1]);

            Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
            selectCommand.Prepare();
            MySqlDataReader childrenReader = selectCommand.ExecuteReader();

            List<Child> children = new List<Child>();
            try
            {
                //Package into list of children

                while (childrenReader.Read())
                {
                    Child newChild = constructChild(childrenReader);

                    //TODO: This work for multiple columns?
                    newChild.ParentsIDs.Add(childrenReader.GetInt16("Parent_Id"));
                    newChild.EmergencyContactsIDs.Add(childrenReader.GetInt16("ContactID"));

                    children.Add(newChild);
                }

                CloseConnection(connection);


            }
            catch (SqlNullValueException sqlnve)
            { }
            return children;
        }
        

        /*---------------------DELETES----------------------------*/
        //TODO: Check Foreign Key Constraints.  May not allow deletions in certain order. Transaction?

        public bool deleteChild(int childID)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return false;

            MySqlCommand deleteCommand = new MySqlCommand(null, connection);
            deleteCommand.CommandText = "DELETE FROM child WHERE Child_ID = @childid;";
            deleteCommand.Parameters.AddWithValue("@childid", childID);

            deleteCommand.Prepare();
            deleteCommand.ExecuteNonQuery();

            return (CloseConnection(connection));
        }

        public bool deleteParent(int parentID)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return false;

            MySqlCommand deleteCommand = new MySqlCommand(null, connection);
            deleteCommand.CommandText = "DELETE FROM parent_guardian WHERE Parent_ID = @parentid;";
            deleteCommand.Parameters.AddWithValue("@parentid", parentID);

            deleteCommand.Prepare();
            deleteCommand.ExecuteNonQuery();

            return (CloseConnection(connection));
        }

        public bool deleteEmergencyContact(int contactID)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return false;

            MySqlCommand deleteCommand = new MySqlCommand(null, connection);
            deleteCommand.CommandText = "DELETE FROM emergency_contact WHERE Contact_ID = @contactid;";
            deleteCommand.Parameters.AddWithValue("@contactid", contactID);

            deleteCommand.Prepare();
            deleteCommand.ExecuteNonQuery();

            return (CloseConnection(connection));
        }

        public bool deleteEmployee(String nino)
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return false;

            MySqlCommand deleteCommand = new MySqlCommand(null, connection);
            deleteCommand.CommandText = "DELETE FROM employee WHERE National_Insurance_Number = @nino;";
            deleteCommand.Parameters.AddWithValue("@nino", nino);

            deleteCommand.Prepare();
            deleteCommand.ExecuteNonQuery();

            return (CloseConnection(connection));
        }

        /*----------------------UTILITY------------------------*/
        public static String SafeGetString(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            else
                return string.Empty;
        }

        public static String SafeGetString(MySqlDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetString(colName);
            else
                return string.Empty;
        }

        public static int SafeGetInt(MySqlDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetInt32(colName);
            else
                return default(int);
        }

        public static DateTime SafeGetDateTime(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDateTime(colIndex);
            else
                return default(DateTime);
        }

        public static DateTime SafeGetDateTime(MySqlDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
                return reader.GetDateTime(colName);
            else
                return default(DateTime);
        }


        /*--------------------SPECIFIC----------------------*/

        public List<Child> childrenToMoveRoom()
        {
            MySqlConnection connection = OpenConnection();
            if (connection == null)
                return null;

            MySqlCommand selectCommand = new MySqlCommand(null, connection);
            //selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = @"SELECT child.*, child_age 
                                        FROM child 
                                        INNER JOIN ( 
	                                        SELECT DATE_FORMAT(NOW(), '%Y') - DATE_FORMAT(child.DOB, '%Y') - (DATE_FORMAT(NOW(), '00-%m-%d') < DATE_FORMAT(child.DOB, '00-%m-%d')) AS child_age
	                                        FROM child 
                                        ) 
                                        AS child_age
                                        INNER JOIN room ON child.Room_Attending = room.`Name`
                                        WHERE child_age > room.Maximum_Age;";

            Console.WriteLine("Executing: [ " + selectCommand.CommandText + "].");
            selectCommand.Prepare();
            MySqlDataReader childReader = selectCommand.ExecuteReader();

            List<Child> olderChildren = new List<Child>();
            while (childReader.Read())
            {
                olderChildren.Add(constructChild(childReader));
            }
            return olderChildren;
        }

        public List<Invoice> generateInvoices()
        {
            return null;
        }

        public List<Employee> pvgRenewals()
        {
            return null;
        }


        
    }
}
