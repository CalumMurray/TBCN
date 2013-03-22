using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TBCN
{
    //Entity DAO class representing an Emergency Contact domain business object
    class EmergencyContact
    {
        public int Contact_ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Title { get; set; }
        public char Gender { get; set; }
        public String Relationship { get; set; }
        public String WorkPhone { get; set; }
        public String HomePhone { get; set; }
        public String MobilePhone { get; set; }
        public Address Address { get; set; }
        public Address WorkAddress { get; set; }
        public Parent Spouse { get; set; }
        public String Email { get; set; }
        public Employee EmployeeContact { get; set; }
        public Child ChildContact { get; set; }

    }
}
