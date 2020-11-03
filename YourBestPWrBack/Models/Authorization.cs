using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace YourBestPWrBack.Models
{
    public class Authorization: IEquatable<Authorization>
    {
        
        public DateTime IssuedOn { get; set; }
        public User User { get; set; }
        public AccessType AccessType { get; set; }

        public bool Equals(Authorization other)
        {
            return User == other?.User;
        }

        public override int GetHashCode()
        {
            return User.GetHashCode();
        }
    }
}
