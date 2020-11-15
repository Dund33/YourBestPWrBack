using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public class MockAuthRepo : IAuthRepo
    {

        private IReadOnlyList<User> _users = new[]
        {
            new User
            {
                AccessType = AccessType.Admin,
                Name = "Adi2024",
                PasswordHash = "5f4dcc3b5aa765d61d8327deb882cf99", // password
            },
            new User
            {
                AccessType = AccessType.User,
                Name = "Manyana",
                PasswordHash = "1f82cdf9195b31244721c6026587fb78" //password23
            },
            new User{
                AccessType = AccessType.Basic,
                Name = "Skid",
                PasswordHash = "a21992c8f0aca8b8961b06c8e30eff6c" //password234
            }
        };

        private List<string> tokens = new List<string>();

        private readonly List<Authorization> authorizations = new List<Authorization>();

        public AccessType GetAccessType(string username)
        {
            var matchingUser = _users.SingleOrDefault(user => user.Name == username);
            return matchingUser?.AccessType ?? AccessType.Basic;
        }

        public async Task<AccessType> GetAccessTypeAsync(string username)
        {
            var accessType = await Task.Run(()=>
            {
                var matchingUser = _users.SingleOrDefault(user => user.Name == username);
                return matchingUser?.AccessType ?? AccessType.Basic;
            });
            return accessType;
        }

        public string Auth(string username, string passwordHash)
        {
            var matchingUser = _users.Single(user => user.Name == username);
            var guid = Guid.NewGuid().ToString();

            authorizations.Add(new Authorization
            {
                IssuedOn = DateTime.Now,
                User = matchingUser,
                AccessType = matchingUser.AccessType
            });

            return guid;
        }

        public void DeAuth(string username)
        {
            var matchingUser = _users.Single(user => user.Name == username);
            authorizations.Remove(new Authorization
            {
                User = matchingUser
            });
        }
    }
}
