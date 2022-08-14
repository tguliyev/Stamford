using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupStudents = new HashSet<GroupStudent>();
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Teacherid { get; set; }
        public int Subjectid { get; set; }
        public DateTime Startdate { get; set; }

        public virtual Subject Subject { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
        public virtual ICollection<GroupStudent> GroupStudents { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
