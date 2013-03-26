using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TBCN
{
    //Entity DAO class representing a Child domain business object
    public class Child
    {
        public int ChildID { get; set; } 
        public String FirstName { get; set; }
        public String LastName { get; set; }
        //public blob image { get; set;};
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
        public int MedicalID { get; set; }

        //??
        public List<int> Parents { get; set; }
        public List<int> EmergencyContacts { get; set; }


        public Child()
        {
            Attendance = new bool[5];
            //TODO: Initialise others?
        }
    }
}
