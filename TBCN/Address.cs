using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TBCN
{
    //Entity DAO class representing an Address domain business object
    public class Address
    {
        public String Address1 { get; set; } //TODO: replace with ID?
        public String City { get; set; }
        public String County { get; set; }
        public String PostCode { get; set; }

    }
}
