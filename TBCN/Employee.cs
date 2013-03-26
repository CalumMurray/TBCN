using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TBCN
{
    //Entity DAO class representing an Employee domain business object
    public class Employee
    {
        public String NINo { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Position { get; set; }
        //public Blob Image { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateFinished { get; set; }
        public DateTime PVGDate { get; set; }
        public char Gender { get; set; }
        public int HolidaysEntitled {get; set;}
        public int HolidaysTaken { get; set; }
        public int WeeksHours { get; set; }
        public String MobilePhone { get; set; }
        public String HomePhone { get; set; }
        public Decimal Salary { get; set; }
        public Address Address { get; set; }
        public String Email { get; set; }
        public EmergencyContact EmergencyContact { get; set; }
        public MedicalInformation Medical { get; set; }
        public String Training { get; set; }

    }
}
