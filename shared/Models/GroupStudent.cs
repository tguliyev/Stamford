using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class GroupStudent
    {
        public int Id { get; set; }
        public int Groupid { get; set; }
        public int Studentid { get; set; }
        public int Lastpaymenttime { get; set; }
        public int Paymentamount { get; set; }
        public int PaidAmount { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
