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
        [HttpGet]
        public async Task<IActionResult> GetAccessLevel(string username)
        {
            var accessType = await _authRepo.GetAccessTypeAsync(username);
            return Ok(accessType);
        }

        [HttpPost]
        public void Post([FromBody] AuthRequest authRequest)
        {
            Console.WriteLine($"{authRequest.Username}, {authRequest.PasswordHash}");
        }

        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
