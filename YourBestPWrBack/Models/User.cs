using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace YourBestPWrBack.Models
{
    public class User: IEquatable<User>
    {
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public AccessType AccessType { get; set; }

        public static bool operator==(User user1, User user2)
        {
            return user1?.Name == user2?.Name;
        }

        public static bool operator !=(User user1, User user2)
        {
            return user1?.Name != user2?.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (other is User user)
            {
                return Name == user.Name;
            }
            else
            {
                return false;
            }
        }

        public bool Equals([AllowNull] User other)
        {
            throw new NotImplementedException();
        }
    }
}
