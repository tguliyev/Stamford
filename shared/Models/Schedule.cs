using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public int Groupid { get; set; }
        public DateTime Lessontime { get; set; }
        public byte Studentcount { get; set; }
    }
}
