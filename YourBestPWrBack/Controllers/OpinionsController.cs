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
        public IActionResult GetOpinionsForLecturer(int id)
        {
            var opinions = _opinionRepo.GetOpinionsForLecturer(id);
            return Ok(opinions);
        }

        public void AddOpinion(int id, Opinion opinion)
        {
            _opinionRepo.AddOpinion(id, opinion);
        }

        [HttpPost]
        public void AddLecturer(Lecturer lecturer)
        {
            _opinionRepo.AddLecturer(lecturer);
        }
    }
}
