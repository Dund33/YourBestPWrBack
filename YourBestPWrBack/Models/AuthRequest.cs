using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourBestPWrBack.Models
{
    public class AuthRequest
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
