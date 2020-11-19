using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using YourBestPWrBack.Models;
using YourBestPWrBack.Services;

namespace YourBestPWrBack.Controllers
{
    public class OpinionsController : ControllerBase
    {
        private IOpinionRepo _opinionRepo;

        public OpinionsController(IOpinionRepo opinionRepo)
        {
            _opinionRepo = opinionRepo;
        }

        [HttpPost]
        public async Task<IActionResult> GetOpinionsForLecturer(BsonObjectId id)
        {
            var opinions = await _opinionRepo.GetOpinionsForLecturerAsync(id);
            return Ok(opinions);
        }

        [HttpPost]
        public void AddOpinion(string id, Opinion opinion)
        {
            var bsonId = new BsonObjectId(new ObjectId(id));
            _opinionRepo.AddOpinion(bsonId, opinion);
        }

        [HttpPost]
        public void AddLecturer(Lecturer lecturer)
        {
            Console.WriteLine($"{lecturer.FirstName} {lecturer.LastName}");
            _opinionRepo.AddLecturer(lecturer);
        }

        public async Task<IActionResult> GetLecturers()
        {
            var lecturers = await _opinionRepo.GetLecturersAsync();
            return Ok(lecturers);
        }
    }
}
