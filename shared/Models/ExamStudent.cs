using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class ExamStudent
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = null!;
        public string ExamName { get; set; } = null!;
        public byte Mark { get; set; }
        public string Code { get; set; } = null!;
    }
}
