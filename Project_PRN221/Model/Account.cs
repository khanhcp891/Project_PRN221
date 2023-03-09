using System;
using System.Collections.Generic;

namespace Project_PRN221.Model
{
    public partial class Account
    {
        public int IdAccount { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }
        public string? Email { get; set; }
    }
}
