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
    public class OpinionsController : ControllerBase
    {
        private IOpinionRepo _opinionRepo;

        public OpinionsController(IOpinionRepo opinionRepo)
        {
            _opinionRepo = opinionRepo;
        }

        [HttpPost]
        public async Task<IActionResult> GetOpinionsForLecturer(int id)
        {
            var opinions = await _opinionRepo.GetOpinionsForLecturerAsync(id);
            return Ok(opinions);
        }

        [HttpPost]
        public void AddLecturer(Lecturer lecturer)
        {
            _opinionRepo.AddLecturer(lecturer);
        }
    }
}
