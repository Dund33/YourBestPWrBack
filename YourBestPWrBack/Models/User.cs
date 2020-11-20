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
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public AccessType AccessType { get; set; }

        public static bool operator==(User user1, User user2)
        {
            return user1?.UserName == user2?.UserName;
        }

        public static bool operator!=(User user1, User user2)
        {
            return user1?.UserName != user2?.UserName;
        }

        public override int GetHashCode()
        {
            return UserName.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (other is User user)
            {
                return UserName == user.UserName;
            }

            return false;
        }

        public bool Equals([AllowNull] User other)
        {
            throw new NotImplementedException();
        }
    }
}
