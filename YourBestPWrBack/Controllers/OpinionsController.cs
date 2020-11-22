using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using YourBestPWrBack.Extensions;
using YourBestPWrBack.Models;
using YourBestPWrBack.Services;

namespace YourBestPWrBack.Controllers
{
    public class OpinionsController : ControllerBase
    {
        private readonly ILecturerRepo _lecturerRepo;
        private readonly IAuthRepo _authRepo;

        public OpinionsController(ILecturerRepo lecturerRepo, IAuthRepo authRepo)
        {
            _lecturerRepo = lecturerRepo;
            _authRepo = authRepo;
        }

        [HttpPost]
        public async Task<IActionResult> GetOpinionsForLecturer(string token, BsonObjectId id)
        {
            var accessType = await _authRepo.GetAccessTypeAsync(token);
            if (accessType < AccessType.Basic)
                return Unauthorized();

            var opinions = await _lecturerRepo.GetOpinionsForLecturerAsync(id);
            return Ok(opinions);
        }

        [HttpPost]
        public async Task<IActionResult> AddOpinion(string token, string lecturerId, Opinion opinion)
        {
            var accessType = await _authRepo.GetAccessTypeAsync(token);
            if (accessType < AccessType.User)
                return Unauthorized();

            var bsonId = new BsonObjectId(new ObjectId(lecturerId));
            _lecturerRepo.AddOpinion(bsonId, opinion);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddLecturer(string token, LecturerBasic lecturer)
        {

            var accessType = await _authRepo.GetAccessTypeAsync(token);
            if (accessType < AccessType.Admin)
                return Unauthorized();

            Console.WriteLine($"{lecturer.FirstName} {lecturer.LastName}");
            _lecturerRepo.AddLecturer(lecturer.ToLecturer());
            return Ok();
        }

        public async Task<IActionResult> GetLecturers()
        {
            var lecturers = await _lecturerRepo.GetLecturersAsync();
            return Ok(lecturers);
        }
    }
}
