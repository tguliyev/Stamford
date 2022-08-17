using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class ExamStudent
    {
        public int Id { get; set; }
        public int Studentid { get; set; }
        public int Examid { get; set; }
        public byte Mark { get; set; }
    }
}
