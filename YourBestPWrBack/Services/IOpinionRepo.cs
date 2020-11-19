using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public interface IOpinionRepo
    {
        public IEnumerable<Opinion> GetOpinionsForLecturer(BsonObjectId lecturerId);
        public Task<IEnumerable<Opinion>> GetOpinionsForLecturerAsync(BsonObjectId lecturerId);
        public IEnumerable<Lecturer> GetLecturers();
        public Task<IEnumerable<LecturerBasic>> GetLecturersAsync();
        public void AddLecturer(Lecturer lecturer);
        public void AddOpinion(BsonObjectId lecturerId, Opinion opinion);

    }
}
