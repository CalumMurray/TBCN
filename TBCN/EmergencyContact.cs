using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TBCN
{
    //Entity DAO class representing an Emergency Contact domain business object
    public class EmergencyContact
    {
        public int ContactID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Title { get; set; }
        public char Gender { get; set; }
        public String Relationship { get; set; }
        public String WorkPhone { get; set; }
        public String HomePhone { get; set; }
        public String MobilePhone { get; set; }
        public Address HomeAddress { get; set; }
        public Address WorkAddress { get; set; }
        public String Email { get; set; }


    }
}
