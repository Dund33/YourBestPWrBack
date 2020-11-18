using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    interface IOpinionRepo
    {
        public IEnumerable<Opinion> GetOpinionsForLecturer(Lecturer lecturer);
        public IEnumerable<Lecturer> GetLecturers();
        public Task<IEnumerable<Opinion>> GetOpinionsForLecturerAsync(Lecturer lecturer);
        public Task<IEnumerable<Lecturer>> GetLecturersAsync();
    }
}
