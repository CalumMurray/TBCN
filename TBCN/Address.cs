using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TBCN
{
    //Entity DAO class representing an HomeAddress domain business object
    public class Address
    {
        public String Address1 { get; set; } 
        public String City { get; set; }
        public String County { get; set; }
        public String PostCode { get; set; }
        public String Country { get; set; }

    }
}
