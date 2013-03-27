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
        public String Allergies { get; set; }
        public String Medication { get; set; }
        public String Other { get; set; }
        public String Doctor { get; set; }
        public Address DoctorAddress { get; set; }

        
        public override String ToString()
        {
            return "Allergies: " + Allergies + "\nMedication: " + Medication + "\nDoctor: " + Doctor + "\nAddress: " + DoctorAddress;
                           
            
        }
    }
}
