using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Exam
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = null!;
        public string ExamName { get; set; } = null!;
        public byte Mark { get; set; }
        public string? StudentCode { get; set; }
    }
}
