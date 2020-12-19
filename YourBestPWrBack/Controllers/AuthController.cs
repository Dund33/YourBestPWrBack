using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YourBestPWrBack.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YourBestPWrBack.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;
        private readonly IUserRepo _userRepo;
        public AuthController(IAuthRepo authRepo, IUserRepo userRepo)
        {
            _authRepo = authRepo;
            _userRepo = userRepo;
        }

        //HTTP GET /api/Auth/GetAccessLevel?username=<username>
        [HttpPost]
        public async Task<IActionResult> GetAccessLevel(string token)
        {
            var accessType = await _authRepo.GetAccessTypeAsync(token);
            return Ok(accessType);
        }

        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            var matchingUser = _userRepo.GetUser(username);

            if (matchingUser is null)
                return Unauthorized();

            var passwordHashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password ?? string.Empty));
            var passwordHash = BitConverter.ToString(passwordHashBytes).Replace("-", string.Empty);

            var passwordsMatchIngoreCase = string.Equals(matchingUser.PasswordHash, passwordHash, StringComparison.InvariantCultureIgnoreCase);

            if (!passwordsMatchIngoreCase)
                return Unauthorized();

            var token = _authRepo.Auth(matchingUser);
            return Ok(token);
        }

        [HttpPost]
        public void DeAuth(string token)
        {
            _authRepo.DeAuth(token);
        }
    }
}
