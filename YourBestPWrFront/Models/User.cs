using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace YourBestPWrFront.Models
{
    public class User : IEquatable<User>
    {
        public int Id { get; init; }
        [NotNull]
        [Required]
        public string UserName { get; set; }
        [NotNull]
        [Required]
        public string PasswordHash { get; set; }
        [NotNull]
        [Required]
        public AccessType AccessType { get; set; }
        public int? GenderId { get; set; }

        public static bool operator ==(User user1, User user2)
        {
            return user1?.UserName == user2?.UserName;
        }

        public static bool operator !=(User user1, User user2)
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
            return UserName == other?.UserName;
        }
    }
}
