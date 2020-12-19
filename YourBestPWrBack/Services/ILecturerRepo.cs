using System.Collections.Generic;
using System.Threading.Tasks;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public interface ILecturerRepo
    {
        public IEnumerable<Opinion> GetOpinionsForLecturer(int lecturerId);
        public Task<IEnumerable<Opinion>> GetOpinionsForLecturerAsync(int lecturerId);
        public IEnumerable<LecturerBasic> GetLecturers();
        public Task<IEnumerable<LecturerBasic>> GetLecturersAsync();
        public void AddLecturer(LecturerBasic lecturer);
        public void AddOpinion(Opinion opinion);

    }
}
