using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourBestPWrBack.Services
{
    public interface IAuthRepo
    {
        public AccessType GetAccessType(string username);
        public Task<AccessType> GetAccessTypeAsync(string username);
        public string Auth(string username, string passwordHash);
        public void DeAuth(string username);
    }
}
