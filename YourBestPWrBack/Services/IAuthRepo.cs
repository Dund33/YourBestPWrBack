using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourBestPWrBack.Services
{
    interface IAuthRepo
    {
        public string Auth(string username, string passwordHash);
        public void DeAuth(string username);
    }
}
