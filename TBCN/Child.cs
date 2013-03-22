using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TBCN
{
    //Entity DAO class representing a Child domain business object
    class Child
    {
        public String BirthCertNumber { get; set; } //TODO: replace with ID?
        public String FirstName { get; set; }
        public String LastName { get; set; }
        //public blob image { get; set;};
        public char Gender { get; set; }
        public Date DOB { get; set; }   //Date?
        public String FirstLanguage { get; set; }
        public Room RoomAttending { get; set; }
        public Parent Parent { get; set; }
        public EmergencyContact EmerContact { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime DateLeft { get; set; }
        public List<char> Attendance { get; set; }
        public int ExtraDays { get; set; }
        public int Teas { get; set; }
        public MedicalInformation Medical { get; set; }


    }
}
