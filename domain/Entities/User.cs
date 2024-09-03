using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class User
    {
        public User()
        {
            Name = string.Empty;
            Role = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
