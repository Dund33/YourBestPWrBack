using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourBestPWrBack.Models;
using YourBestPWrBack.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YourBestPWrBack.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;
        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        //HTTP GET /api/Auth/GetAccessLevel?username=<username>
        [HttpPost]
        public async Task<IActionResult> GetAccessLevel(string token)
        {
            var accessType = await _authRepo.GetAccessTypeAsync(token);
            return Ok(accessType);
        }

        [HttpPost]
        public string Auth(string username, string passwordHash)
        {
            var token = _authRepo.Auth(username, passwordHash);
            return token;
        }

        [HttpPost]
        public void DeAuth(string token)
        {
            _authRepo.DeAuth(token);
        }
    }
}
