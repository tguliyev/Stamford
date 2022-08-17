using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Exams = new HashSet<Exam>();
        }

        public int Id { get; set; }
        public int Groupid { get; set; }
        public DateTime Lessontime { get; set; }
        public byte Studentcount { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
