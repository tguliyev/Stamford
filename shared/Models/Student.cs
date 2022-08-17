using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool? LessonPermission { get; set; }
        public byte? AbsentCount { get; set; }
        public int Imageid { get; set; }
    }
}
