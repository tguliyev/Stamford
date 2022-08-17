using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Exam
    {
        public Exam()
        {
            ExamStudents = new HashSet<ExamStudent>();
        }

        public int Id { get; set; }
        public int Subjectid { get; set; }
        public int Scheduleid { get; set; }

        public virtual Schedule Schedule { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
        public virtual ICollection<ExamStudent> ExamStudents { get; set; }
    }
}
