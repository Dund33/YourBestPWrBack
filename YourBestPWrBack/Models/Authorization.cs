using System;

namespace YourBestPWrBack.Models
{
    public class Authorization : IEquatable<Authorization>
    {

        public DateTime IssuedOn { get; set; }
        public User User { get; set; }
        public AccessType AccessType { get; set; }
        public string Token { get; set; }

        public bool Equals(Authorization other)
        {
            if (other is null)
                return false;
            var sameUser = User == other.User;
            var sameTime = (IssuedOn - other.IssuedOn).TotalSeconds < 1;
            return sameUser && sameTime;
        }

        public override int GetHashCode()
        {
            return User.GetHashCode();
        }
    }
}
