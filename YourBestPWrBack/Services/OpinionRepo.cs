using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using MongoDB.Driver;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public class OpinionRepo: IOpinionRepo
    {
        private readonly MongoClient _mongoClient;

        public OpinionRepo(string connectionString)
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
            _mongoClient = new MongoClient(settings);
        }


        public IEnumerable<Opinion> GetOpinionsForLecturer(Lecturer lecturer)
        {
            var database = _mongoClient.GetDatabase("db1");
            var collection = database.GetCollection<Lecturer>("lecturers");
            //TODO: Fix later. Should work for now
            var lecturerFromDb = collection
                .FindSync(l => l.ID == lecturer.ID)
                .Current
                .FirstOrDefault();
            return lecturerFromDb?.Opinions;
        }

        public IEnumerable<Lecturer> GetLecturers()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Opinion>> GetOpinionsForLecturerAsync(Lecturer lecturer)
        {
            var database = _mongoClient.GetDatabase("db1");
            var collection = database.GetCollection<Lecturer>("lecturers");
            //TODO: Fix later. Should work for now
            var cursor = await collection.FindAsync(l => l.ID == lecturer.ID);
            var lecturerFromDb = cursor.Current.FirstOrDefault();
            return lecturerFromDb?.Opinions;

        }

        public async Task<IEnumerable<Lecturer>> GetLecturersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
