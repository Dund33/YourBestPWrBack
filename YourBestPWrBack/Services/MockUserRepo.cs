using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public class MockUserRepo : IUserRepo
    {
        private readonly List<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                AccessType = AccessType.Admin,
                UserName = "Adi2024",
                PasswordHash = "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8", // password
            },
            new User
            {
                Id = 2,
                AccessType = AccessType.User,
                UserName = "Manyana",
                PasswordHash = "8B807AA0505A00B3EF49E26A2ADE8E31FCD6C700D1A3AEEE971B49D73DA8E8FF" //password23
            },
            new User{
                Id = 3,
                AccessType = AccessType.Basic,
                UserName = "Skid",
                PasswordHash = "93FF4D79302417D6912B8C2620C1A5FCB8DBE305C1A351A8F3CD7560E3F4D4F2" //password234
            }
        };

        public void AddUser(User user)
        {
            if (_users.Contains(user))
                return;
            _users.Add(user);
        }

        public void RemoveUser(string username)
        {
            _users.RemoveAll(user => user.UserName == username);
        }

        public User GetUser(string username)
            => _users.FirstOrDefault(user => user.UserName == username);

        public async Task<User> GetUserAsync(string username)
            => GetUser(username);
    }
}
