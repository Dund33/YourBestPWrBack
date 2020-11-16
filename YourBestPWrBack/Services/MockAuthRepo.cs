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

        private readonly List<Authorization> _authorizations = new List<Authorization>();

        public AccessType GetAccessType(string token)
        {
            var matchingAuthorization = _authorizations
                .SingleOrDefault(auth => auth.Token == token);
            var accessLevel = matchingAuthorization?.AccessType ?? AccessType.Basic;

            return accessLevel;
        }

        public async Task<AccessType> GetAccessTypeAsync(string token)
        {
            var accessType = await Task.Run(()=>GetAccessType(token));
            return accessType;
        }

        public string Auth(string username, string passwordHash)
        {
            var matchingUser = _users
                .Where(user => user.Name == username)
                .SingleOrDefault(user => user.PasswordHash == passwordHash);

            if (matchingUser is null)
                return string.Empty;

            var guid = Guid.NewGuid().ToString();

            _authorizations.Add(new Authorization
            {
                IssuedOn = DateTime.Now,
                User = matchingUser,
                AccessType = matchingUser.AccessType,
                Token = guid
            });

            return guid;
        }

        public void DeAuth(string token)
        {
            var matchingAuthorization = _authorizations
                .Single(auth => auth.Token == token);
            _authorizations.Remove(matchingAuthorization);
        }

        public bool IsAuthorized(string token) 
            => _authorizations.Any(auth => auth.Token == token);

        public async Task<bool> IsAuthorizedAsync(string username) 
            => await Task.Run(() => IsAuthorized(username));
    
    }
}
