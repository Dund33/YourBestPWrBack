using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourBestPWrBack.Services
{
    public interface IAuthRepo
    {
        public AccessType GetAccessType(string token);
        public Task<AccessType> GetAccessTypeAsync(string token);
        public string Auth(string username, string passwordHash);
        public void DeAuth(string token);
        public bool IsAuthorized(string token);
        public Task<bool> IsAuthorizedAsync(string token);
    }
}
