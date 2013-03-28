using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace TBCN
{
    //Entity DAO class representing a Child domain business object
    public class Child
    {
        public int ChildID { get; set; } 
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Image image { get; set;}
        public char Gender { get; set; }
        public DateTime DOB { get; set; }   //Date?
        public Child Sibling { get; set; }
        public String FirstLanguage { get; set; }
        public String RoomAttending { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime DateLeft { get; set; }
        public bool[] Attendance { get; set; }     
        public int ExtraDays { get; set; }
        public int Teas { get; set; }
        public MedicalInformation MedicalInfo { get; set; }

        //??
        public List<int> ParentsIDs { get; set; }
        public List<int> EmergencyContactsIDs { get; set; }


        public Child()
        {
            Attendance = new bool[5];
            ParentsIDs = new List<int>(2);
            EmergencyContactsIDs = new List<int>(2);
        }
    }
}
