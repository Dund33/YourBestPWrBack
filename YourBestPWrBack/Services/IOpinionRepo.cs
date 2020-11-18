using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public interface IOpinionRepo
    {
        public IEnumerable<Opinion> GetOpinionsForLecturer(int lecturerId);
        public IEnumerable<Lecturer> GetLecturers();
        public void AddLecturer(Lecturer lecturer);
        public void AddOpinion(int lecturerId, Opinion opinion);
    }
}
