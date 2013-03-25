using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TBCN
{
    //Entity DAO class representing a person's Medical Information -  domain business object
    public class MedicalInformation
    {
        public int MedicalID { get; set; }
        public List<String> Allergies { get; set; }
        public List<String> Medication { get; set; }
        //public int Doctor { get; set; }
    }
}
