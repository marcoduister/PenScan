using System;
using System.Collections.Generic;
using System.Text;

namespace PenScan.Models
{
    class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
