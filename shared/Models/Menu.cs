using System;
using System.Collections.Generic;

namespace Stamford.Models
{
    public partial class Menu
    {
        public string Name { get; set; } = null!;
        public int Id { get; set; }
        public int Order { get; set; }
        public string Action { get; set; } = null!;
    }
}
