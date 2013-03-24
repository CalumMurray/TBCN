using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;


namespace TBCN
{
    class ChildDBConnection : DatabaseConnection
    {

        public void addChild(Child childToAdd, Parent parent, EmergencyContact ec)
        {
            OpenConnection();
            //TODO: Atomic Transaction?
            MySqlCommand childCommand = new MySqlCommand(null, connection);
            MySqlCommand ParentChildLinkCommand = new MySqlCommand(null, connection);
            MySqlCommand parentCommand = new MySqlCommand(null, connection);
            MySqlCommand ecCommand = new MySqlCommand(null, connection);
            MySqlCommand ecChildLinkCommand = new MySqlCommand(null, connection);

            // Create and prepare an SQL statement.
            childCommand.CommandText = @"INSERT INTO Child (First_Name, Last_Name, Gender, DOB, First_Language, Room_Attending, Sibling, Date_Applied, Date_Left, Days_Per_Week, Extra_Days, Teas, Medical_Information) 
                                   VALUES (@firstname, @lastname, @gender, @dob, @firstlanguage, @roomattending, @sibling, @dateapplied, @dateleft, @attendance, @extra, @teas, @medical)"; 
            
            MySqlParameter fNameParam = new MySqlParameter("@firstname", childToAdd.FirstName);
            MySqlParameter lNameParam = new MySqlParameter("@lastname", childToAdd.LastName);
            MySqlParameter genderParam = new MySqlParameter("@gender", childToAdd.Gender);
            //MySqlParameter dobParam = new MySqlParameter("@dob", childToAdd.DOB);
            MySqlParameter languageParam = new MySqlParameter("@firstlanguage", childToAdd.FirstLanguage);
            MySqlParameter roomParam = new MySqlParameter("@roomattending", childToAdd.RoomAttending); //?
            MySqlParameter siblingParam = new MySqlParameter("@sibling", childToAdd.Sibling.ChildID);//?
            MySqlParameter dateAppliedParam = new MySqlParameter("@dateapplied", childToAdd.DateApplied);
            MySqlParameter dateLeftParam = new MySqlParameter("@dateleft", childToAdd.DateLeft);
            MySqlParameter attendanceParam = new MySqlParameter("@attendance", childToAdd.Attendance);//?
            MySqlParameter extraParam = new MySqlParameter("@extra", childToAdd.ExtraDays);
            MySqlParameter teasParam = new MySqlParameter("@teas", childToAdd.Teas);
            MySqlParameter medicalParam = new MySqlParameter("@medical", childToAdd.Medical);

            childCommand.Parameters.Add(fNameParam);
            childCommand.Parameters.Add(lNameParam);
            childCommand.Parameters.Add(genderParam);
            //childCommand.Parameters.Add(dobParam);
            childCommand.Parameters.Add(languageParam);
            childCommand.Parameters.Add(roomParam);
            childCommand.Parameters.Add(siblingParam);
            childCommand.Parameters.Add(dateAppliedParam);
            childCommand.Parameters.Add(dateLeftParam);
            childCommand.Parameters.Add(attendanceParam);
            childCommand.Parameters.Add(extraParam);
            childCommand.Parameters.Add(teasParam);
            childCommand.Parameters.Add(medicalParam);

            // Call Prepare after setting the Commandtext and Parameters.
            childCommand.Prepare();
            childCommand.ExecuteNonQuery();

            CloseConnection();
        }

        public void addParent(Parent parentToAdd)
        {

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

    }
}
