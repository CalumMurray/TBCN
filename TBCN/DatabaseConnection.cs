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
        private MySqlCommand deleteCommand;

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
        //TODO: Locks/Logs/Priveleges/VIEWS
        //TODO: Transactions!

        //TODO: Generate Invoices!
        //TODO: Notify children should be moved up room

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
                insertCommand.CommandText = @"INSERT INTO child
                                            VALUES (@id, @firstname, @lastname, @gender, @dob, @firstlanguage, @roomattending, @sibling, @dateapplied, @dateleft, @extra, @teas, @medical)
                                            ON DUPLICATE KEY UPDATE;";

                //Fill in prepared statement parameters
                MySqlParameter idParam = new MySqlParameter("@id", childToAdd.ChildID);
                MySqlParameter fNameParam = new MySqlParameter("@firstname", childToAdd.FirstName);
                MySqlParameter lNameParam = new MySqlParameter("@lastname", childToAdd.LastName);
                MySqlParameter genderParam = new MySqlParameter("@gender", childToAdd.Gender);
                MySqlParameter dobParam = new MySqlParameter("@dob", childToAdd.DOB);
                MySqlParameter languageParam = new MySqlParameter("@firstlanguage", childToAdd.FirstLanguage);
                MySqlParameter roomParam = new MySqlParameter("@roomattending", childToAdd.RoomAttending); 
                MySqlParameter siblingParam = new MySqlParameter("@sibling", childToAdd.Sibling.ChildID);
                MySqlParameter dateAppliedParam = new MySqlParameter("@dateapplied", childToAdd.DateApplied);
                MySqlParameter dateLeftParam = new MySqlParameter("@dateleft", childToAdd.DateLeft);
                MySqlParameter extraParam = new MySqlParameter("@extra", childToAdd.ExtraDays);
                MySqlParameter teasParam = new MySqlParameter("@teas", childToAdd.Teas);
                MySqlParameter medicalParam = new MySqlParameter("@medical", childToAdd.MedicalInfo.MedicalID);

                insertCommand.Parameters.Add(fNameParam);
                insertCommand.Parameters.Add(lNameParam);
                insertCommand.Parameters.Add(genderParam);
                insertCommand.Parameters.Add(dobParam);
                insertCommand.Parameters.Add(languageParam);
                insertCommand.Parameters.Add(roomParam);
                insertCommand.Parameters.Add(siblingParam);
                insertCommand.Parameters.Add(dateAppliedParam);
                insertCommand.Parameters.Add(dateLeftParam);
                insertCommand.Parameters.Add(extraParam);
                insertCommand.Parameters.Add(teasParam);
                insertCommand.Parameters.Add(medicalParam);

                // Prepare statement
                Console.WriteLine("Executing: [ " + insertCommand.ToString() + "].");
                insertCommand.Prepare();
                insertCommand.ExecuteNonQuery();


                //childID = (int)idCommand.ExecuteScalar();
                //insertAttendance(childToAdd);
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

            return (CloseConnection()); //Successful or not

        }

        public void insertParent(Parent parentToAdd)
        {
            insertCommand.Connection = connection;
            insertCommand.CommandText = @"INSERT INTO parent_guardian 
                                        VALUES (@id, @firstname, @lastname, @title, @gender, @workphone, @homephone, @mobilephone, @homeaddress, @workaddress, @spouse, @email)
                                        ON DUPLICATE KEY UPDATE;";

            MySqlParameter idParam = new MySqlParameter("@id", parentToAdd.ParentID);
            MySqlParameter fNameParam = new MySqlParameter("@firstname", parentToAdd.FirstName);
            MySqlParameter lNameParam = new MySqlParameter("@lastname", parentToAdd.LastName);
            MySqlParameter genderParam = new MySqlParameter("@gender", parentToAdd.Gender);
            MySqlParameter titleParam = new MySqlParameter("@title", parentToAdd.Title);
            MySqlParameter workPhoneParam = new MySqlParameter("@workphone", parentToAdd.WorkPhone); 
            MySqlParameter homePhoneParam = new MySqlParameter("@homephone", parentToAdd.HomePhone);
            MySqlParameter mobilePhoneParam = new MySqlParameter("@mobilephone", parentToAdd.MobilePhone);
            MySqlParameter homeAddrParam = new MySqlParameter("@homeaddress", parentToAdd.HomeAddress.Address1);
            MySqlParameter workAddrParamParam = new MySqlParameter("@workaddress", parentToAdd.WorkAddress.Address1);
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
            insertCommand.CommandText = "INSERT INTO child_has_parent_guardian VALUES (@contactID, @childID);";
            insertCommand.Parameters.Add(new MySqlParameter("@contactID", parentID));
            insertCommand.Parameters.Add(new MySqlParameter("@childID", childID));

            Console.WriteLine("Executing: [ " + insertCommand.ToString() + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();
        }

        public void insertEmergencyContact(EmergencyContact ecToAdd)
        {
            insertCommand.Connection = connection;
            insertCommand.CommandText = @"INSERT INTO emergency_contact
                                        VALUES (@id, @firstname, @lastname, @title, @gender, @relationship, @homephone, @workphone, @mobilephone, @homeaddress, @workaddress, @email)
                                        ON DUPLICATE KEY UPDATE;";

            MySqlParameter idParam = new MySqlParameter("@id", ecToAdd.ContactID);
            MySqlParameter fNameParam = new MySqlParameter("@firstname", ecToAdd.FirstName);
            MySqlParameter lNameParam = new MySqlParameter("@lastname", ecToAdd.LastName);
            MySqlParameter genderParam = new MySqlParameter("@gender", ecToAdd.Gender);
            MySqlParameter titleParam = new MySqlParameter("@title", ecToAdd.Title);
            MySqlParameter relParam = new MySqlParameter("@relationship", ecToAdd.Relationship);
            MySqlParameter workPhoneParam = new MySqlParameter("@workphone", ecToAdd.WorkPhone); 
            MySqlParameter homePhoneParam = new MySqlParameter("@homephone", ecToAdd.HomePhone);
            MySqlParameter mobilePhoneParam = new MySqlParameter("@mobilephone", ecToAdd.MobilePhone);
            MySqlParameter homeAddrParam = new MySqlParameter("@homeaddress", ecToAdd.HomeAddress.Address1);
            MySqlParameter workAddrParamParam = new MySqlParameter("@workaddress", ecToAdd.WorkAddress.Address1);
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
            insertCommand.CommandText = @"INSERT INTO attendance VALUES (@child, @monday, @tuesday, @wednesday, @thursday, @friday)
                                        ON DUPLICATE KEY UPDATE;";

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

        public void insertAddress(Address addressToAdd)
        {
            insertCommand.Connection = connection;
            insertCommand.CommandText = @"INSERT INTO address VALUES (@address1, @city, @county, @postcode, @country)
                                        ON DUPLICATE KEY UPDATE;";

            insertCommand.Parameters.Add(new MySqlParameter("@address1", addressToAdd.Address1));
            insertCommand.Parameters.Add(new MySqlParameter("@city", addressToAdd.City));
            insertCommand.Parameters.Add(new MySqlParameter("@county", addressToAdd.County));
            insertCommand.Parameters.Add(new MySqlParameter("@postcode", addressToAdd.PostCode));
            insertCommand.Parameters.Add(new MySqlParameter("@country", addressToAdd.Country));

            Console.WriteLine("Executing: [ " + insertCommand.ToString() + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();
        }

        public void insertMedical(MedicalInformation medicalToAdd)
        {
            insertCommand.Connection = connection;
            insertCommand.CommandText = @"INSERT INTO medical_information VALUES (@medicalid, @allergies, @medication, @other, @doctor, @doctoraddress)
                                        ON DUPLICATE KEY UPDATE;";

            insertCommand.Parameters.Add(new MySqlParameter("@medicalid", medicalToAdd.MedicalID));
            insertCommand.Parameters.Add(new MySqlParameter("@allergies", medicalToAdd.Allergies));
            insertCommand.Parameters.Add(new MySqlParameter("@medication", medicalToAdd.Medication));
            insertCommand.Parameters.Add(new MySqlParameter("@other", medicalToAdd.Other));
            insertCommand.Parameters.Add(new MySqlParameter("@doctor", medicalToAdd.Doctor));
            insertCommand.Parameters.Add(new MySqlParameter("@doctoraddress", medicalToAdd.DoctorAddress.Address1));

            Console.WriteLine("Executing: [ " + insertCommand.ToString() + "].");
            insertCommand.Prepare();
            insertCommand.ExecuteNonQuery();
        }

        public bool insertEmployee(Employee employeeToAdd)
        {
            if (!OpenConnection())
                return false;

            try
            {

                insertCommand.Connection = connection;

                // Create and prepare an SQL statement.
                insertCommand.CommandText = @"INSERT INTO employee 
                                            VALUES (@nino, @firstname, @lastname, @position, @gender, @datestarted, @datefinished, @pvgdate, @holidaysentitled, @holidaystaken, @hours, @address, @dob, @salary, @homephone, @mobilephone, @email, @training, @medical, @ec)
                                            ON DUPLICATE KEY UPDATE;";

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
                MySqlParameter addressParam = new MySqlParameter("@holidaysentitled", employeeToAdd.Address.Address1);
                MySqlParameter dobParam = new MySqlParameter("@dob", employeeToAdd.DOB);
                MySqlParameter salaryParam = new MySqlParameter("@salary", employeeToAdd.Salary); 
                MySqlParameter homePhoneParam = new MySqlParameter("@homephone", employeeToAdd.HomePhone);
                MySqlParameter mobilePhoneParam = new MySqlParameter("@homephone", employeeToAdd.MobilePhone);
                MySqlParameter emailParam = new MySqlParameter("@email", employeeToAdd.Email);
                MySqlParameter trainingParam = new MySqlParameter("@training", employeeToAdd.Training);
                MySqlParameter medicalParam = new MySqlParameter("@medical", employeeToAdd.Medical.MedicalID);
                MySqlParameter ecParam = new MySqlParameter("@ec", employeeToAdd.EmergencyContact.ContactID);

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
                //newChild.Sibling = childReader.Get7
                newChild.DateApplied = childReader.GetDateTime(8);
                newChild.DateLeft = childReader.GetDateTime(9);
                newChild.Attendance = selectAttendance(newChild.ChildID);
                newChild.ExtraDays = childReader.GetInt16(11);
                newChild.Teas = childReader.GetInt16(12);
                newChild.MedicalInfo = selectMedicalInformation(childReader.GetInt16(13));

                //Get parents
                foreach (int parentID in selectChildsParentIDs(newChild.ChildID))
                    newChild.Parents.Add(selectParent(parentID));

                //Get Emergency Contacts
                foreach (int contactID in selectChildsContactIDs(newChild.ChildID))
                    newChild.EmergencyContacts.Add(selectEmergencyContact(contactID)); 

            }
            childReader.Close();

            CloseConnection();

            return newChild;
        }

        private List<int> selectChildsParentIDs(int childID)
        {
            if (!OpenConnection())
                return null;

            selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM child_has_parent_guardian WHERE Child_ID = @childID;";
            selectCommand.Parameters.Add(new MySqlParameter("@childID", childID));

            Console.WriteLine("Executing: [ " + selectCommand.ToString() + "].");
            selectCommand.Prepare();
            MySqlDataReader parentReader = selectCommand.ExecuteReader();

            //Package into Child domain entity object
            List<int> parentIDs = new List<int>();
            while (parentReader.Read())
            {
                parentIDs.Add(parentReader.GetInt32(0));
            }
            return parentIDs;
        }

        private List<int> selectChildsContactIDs(int childID)
        {
            if (!OpenConnection())
                return null;

            selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM child_has_emergency_contact WHERE Child_ID = @childID;";
            selectCommand.Parameters.Add(new MySqlParameter("@childID", childID));

            Console.WriteLine("Executing: [ " + selectCommand.ToString() + "].");
            selectCommand.Prepare();
            MySqlDataReader ecReader = selectCommand.ExecuteReader();

            //Package into Child domain entity object
            List<int> contactIDs = new List<int>();
            while (ecReader.Read())
            {
                contactIDs.Add(ecReader.GetInt32(0));
            }
            return contactIDs;
        }

        private MedicalInformation selectMedicalInformation(int medicalID)
        {
            if (!OpenConnection())
                return null;

            selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM medical_information WHERE Medical_ID = @medicalID;";
            selectCommand.Parameters.Add(new MySqlParameter("@medicalID", medicalID));

            selectCommand.Prepare();
            MySqlDataReader medicalReader = selectCommand.ExecuteReader();

            MedicalInformation newMedical = new MedicalInformation();
            while (medicalReader.Read())
            {
                newMedical.MedicalID = medicalID;
                newMedical.Allergies = medicalReader.GetString(1);
                newMedical.Medication = medicalReader.GetString(2);
                newMedical.Other = medicalReader.GetString(3);
                newMedical.Doctor = medicalReader.GetString(4);
                newMedical.DoctorAddress = selectAddress(medicalReader.GetString(5));
            }
            return newMedical;
        }

        private Address selectAddress(String address1)
        {
            if (!OpenConnection())
                return null;

            selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM address WHERE Address_1 = @address1;";
            selectCommand.Parameters.Add(new MySqlParameter("@address1", address1));

            selectCommand.Prepare();
            MySqlDataReader addressReader = selectCommand.ExecuteReader();

            Address newAddress = new Address();
            while (addressReader.Read())
            {
                newAddress.Address1 = address1;
                newAddress.City = addressReader.GetString(1);
                newAddress.County = addressReader.GetString(2);
                newAddress.PostCode = addressReader.GetString(3);
                newAddress.Country = addressReader.GetString(4);
            }
            return newAddress;
        }

        public Parent selectParent(int parentIDToSelect)
        {
            if (!OpenConnection())
                return null;

            selectCommand = new MySqlCommand(null, connection);
            selectCommand.CommandText = "SELECT * FROM parent_guardian WHERE ParentID = @contactID;";
            selectCommand.Parameters.Add(new MySqlParameter("@contactID", parentIDToSelect));

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
                newParent.HomeAddress = selectAddress(parentReader.GetString(8));
                newParent.WorkAddress = selectAddress(parentReader.GetString(9));
                //newParent.Spouse = parentReader.GetInt16(10);
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
                newEC.HomeAddress = selectAddress(ECReader.GetString(8));
                newEC.WorkAddress = selectAddress(ECReader.GetString(9));
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
                newEmployee.Address = selectAddress(employeeReader.GetString(10));
                newEmployee.DOB = employeeReader.GetDateTime(11);
                newEmployee.Salary = employeeReader.GetDecimal(12);
                newEmployee.HomePhone = employeeReader.GetString(13);
                newEmployee.MobilePhone = employeeReader.GetString(14);
                newEmployee.Email = employeeReader.GetString(15);
                newEmployee.Training = employeeReader.GetString(16);
                newEmployee.Medical = selectMedicalInformation(employeeReader.GetInt32(17));
                //newEmployee.EmergencyContacts = GetInt32(18)
            }
            employeeReader.Close();

            CloseConnection();

            return newEmployee;
        }

        /*---------------------DELETES----------------------------*/
        //TODO: Check Foreign Key Constraints.  May not allow deletions in certain order.

        public bool deleteChild(int childID)
        {
            if (!OpenConnection())
                return false;

            deleteCommand = new MySqlCommand(null, connection);
            deleteCommand.CommandText = "DELETE FROM child WHERE Child_ID = @childid;";
            deleteCommand.Parameters.Add(new MySqlParameter("@childid", childID));

            deleteCommand.Prepare();
            deleteCommand.ExecuteNonQuery();

            return (CloseConnection());
        }

        public bool deleteParent(int parentID)
        {
            if (!OpenConnection())
                return false;

            deleteCommand = new MySqlCommand(null, connection);
            deleteCommand.CommandText = "DELETE FROM parent_guardian WHERE Parent_ID = @parentid;";
            deleteCommand.Parameters.Add(new MySqlParameter("@parentid", parentID));

            deleteCommand.Prepare();
            deleteCommand.ExecuteNonQuery();

            return (CloseConnection());
        }

        public bool deleteEmergencyContact(int contactID)
        {
            if (!OpenConnection())
                return false;

            deleteCommand = new MySqlCommand(null, connection);
            deleteCommand.CommandText = "DELETE FROM emergency_contact WHERE Contact_ID = @contactid;";
            deleteCommand.Parameters.Add(new MySqlParameter("@contactid", contactID));

            deleteCommand.Prepare();
            deleteCommand.ExecuteNonQuery();

            return (CloseConnection());
        }

        public bool deleteEmployee(String nino)
        {
            if (!OpenConnection())
                return false;

            deleteCommand = new MySqlCommand(null, connection);
            deleteCommand.CommandText = "DELETE FROM employee WHERE National_Insurance_Number = @nino;";
            deleteCommand.Parameters.Add(new MySqlParameter("@nino", nino));

            deleteCommand.Prepare();
            deleteCommand.ExecuteNonQuery();

            return (CloseConnection());
        }

    }
}
