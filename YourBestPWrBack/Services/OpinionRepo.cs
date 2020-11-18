using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            settings.RetryWrites = false;
            settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
            _mongoClient = new MongoClient(settings);
        }

        public IEnumerable<Opinion> GetOpinionsForLecturer(int lecturerId)
        {
            var database = _mongoClient.GetDatabase("db1");
            var collection = database.GetCollection<Lecturer>("lecturers");
            //TODO: Fix later. Should work for now
            var lecturerFromDb = collection
                .FindSync(l => l.Id == lecturerId)
                .Current
                .FirstOrDefault();
            return lecturerFromDb?.Opinions;
        }

        public IEnumerable<Lecturer> GetLecturers()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Opinion>> GetOpinionsForLecturerAsync(int lecturerId)
        {
            var database = _mongoClient.GetDatabase("db1");
            var collection = database.GetCollection<Lecturer>("lecturers");
            //TODO: Fix later. Should work for now
            var cursor = await collection.FindAsync(l => l.Id == lecturerId);
            await cursor.MoveNextAsync();
            var lecturerFromDb = cursor.Current.FirstOrDefault();
            return lecturerFromDb?.Opinions;

        }

        public async Task<IEnumerable<Lecturer>> GetLecturersAsync()
        {
            throw new NotImplementedException();
        }

        public void AddLecturer(Lecturer lecturer)
        {
            var database = _mongoClient.GetDatabase("db1");
            var collection = database.GetCollection<Lecturer>("lecturers");
            collection.InsertOne(lecturer);
        }

        public void AddOpinion(int lecturerId, Opinion opinion)
        {
            var database = _mongoClient.GetDatabase("db1");
            var collection = database.GetCollection<Lecturer>("lecturers");
            //TODO: Fix later. Should work for now
            var cursor =  collection.Find(l => l.Id == lecturerId).Limit(1).ToCursor();
            var lecturerFromDb = cursor.Current.FirstOrDefault();
            collection.ReplaceOne(lecturer => lecturer.Id == lecturerId, lecturerFromDb);

        }
    }
}
