using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TBCN
{
    //Entity DAO class representing a Parent domain business object
    class Parent
    {
        public int Parent_ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Title { get; set; }
        public char Gender { get; set; }
        public String WorkPhone { get; set; }
        public String HomePhone { get; set; }
        public String MobilePhone { get; set; }
        public Address Address { get; set; }
        public Parent Spouse { get; set; }
        public String Email { get; set; }
        public List<Child> ChildrenAttending { get; set; }
        public Invoice invoice{ get; set; }

    }
}
