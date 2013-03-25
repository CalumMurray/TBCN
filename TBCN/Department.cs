using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TBCN
{
    //Entity DAO class representing a Room Department domain business object
    public class Department
    {
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
        public Decimal WeeklyFee { get; set; }
        public Decimal DailyFee { get; set; }
        public Decimal TeaFee { get; set; }
        public int MinimumRatio { get; set; }

    }
}
