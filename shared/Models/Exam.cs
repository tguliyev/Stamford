using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Exam
    {
        public int Id { get; set; }
        public int Subjectid { get; set; }
        public int Scheduleid { get; set; }
    }
}
