using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourBestPWrBack.Models;
using YourBestPWrBack.Services;

namespace YourBestPWrBack.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IAuthRepo _authRepo;

        public UsersController(IUserRepo userRepo, IAuthRepo authRepo)
        {
            _userRepo = userRepo;
            _authRepo = authRepo;
        }

        [HttpPost]
        public IActionResult AddUser(string token, User user)
        {
            var accessLevel = _authRepo.GetAccessType(token);

            if (accessLevel < AccessType.Admin)
                return Unauthorized();

            if (!ModelState.IsValid)
                return BadRequest();

            _userRepo.AddUser(user);

            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveUser(string token, string username)
        {
            var accessLevel = _authRepo.GetAccessType(token);

            if (accessLevel < AccessType.Admin)
                return Unauthorized();

            _userRepo.RemoveUser(username);

            return Ok();
        }
    }
}
