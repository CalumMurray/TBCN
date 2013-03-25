using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TBCN
{
    //Entity DAO class representing an Invoice domain business object
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public Child Child { get; set; }
        public Parent PayingParent { get; set; }
        public DateTime MonthBeginning { get; set; }
        public Decimal WeeklyFee { get; set; }
        public int NoOfWeeks { get; set; }
        public Decimal PercentageDiscount { get; set; }
        public Decimal Discount { get; set; }
        public Decimal NetFee { get; set; }
        public int ExtraDays { get; set; }
        public int Teas { get; set; }
        public Decimal LatePay { get; set; }
        public Decimal Arrears { get; set; }
        public String PaymentMethod{ get; set; }
        public Decimal Total { get; set; }
    }
}
