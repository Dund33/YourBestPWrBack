using System.Threading.Tasks;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public interface IAuthRepo
    {
        public AccessType GetAccessType(string token);
        public Task<AccessType> GetAccessTypeAsync(string token);
        public string Auth(User user);
        public void DeAuth(string token);
        public bool IsAuthorized(string token);
        public Task<bool> IsAuthorizedAsync(string token);
    }
}
