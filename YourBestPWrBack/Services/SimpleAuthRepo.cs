using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public class SimpleAuthRepo : IAuthRepo
    {

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
            var accessType = await Task.Run(() => GetAccessType(token));
            return accessType;
        }

        public string Auth(User user)
        {
            var guid = Guid.NewGuid().ToString();

            _authorizations.Add(new Authorization
            {
                IssuedOn = DateTime.Now,
                User = user,
                AccessType = user.AccessType,
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

        public User GetUserForToken(string token)
            => _authorizations.Where(a => a.Token == token).FirstOrDefault()?.User;
    }
}
