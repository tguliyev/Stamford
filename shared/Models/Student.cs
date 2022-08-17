using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Student
    {
        public Student()
        {
            ExamStudents = new HashSet<ExamStudent>();
            GroupStudents = new HashSet<GroupStudent>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool? LessonPermission { get; set; }
        public byte? AbsentCount { get; set; }
        public int Imageid { get; set; }

        public virtual Asset Image { get; set; } = null!;
        public virtual ICollection<ExamStudent> ExamStudents { get; set; }
        public virtual ICollection<GroupStudent> GroupStudents { get; set; }
    }
}
