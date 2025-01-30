using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPRA.Models
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Pass { get; set; }

        public string ConfirmPassword { get; set; }

        public bool Verified { get; set; } = false;
    }
}
