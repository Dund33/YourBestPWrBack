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

        private IMongoCollection<Lecturer> GetLecturerCollection()
        {
            var database = _mongoClient.GetDatabase("db1");
            var collection = database.GetCollection<Lecturer>("lecturers");
            return collection;
        }

        public OpinionRepo(string connectionString)
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.RetryWrites = false;
            settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
            _mongoClient = new MongoClient(settings);
        }

        public Lecturer GetLecturerById(int lecturerId)
        {
            var database = _mongoClient.GetDatabase("db1");
            var collection = database.GetCollection<Lecturer>("lecturers");
            //TODO: Fix later. Should work for now
            var cursor = collection
                .FindSync(l => l.Id == lecturerId);
            cursor.MoveNext();
            var lecturerFromDb = cursor
                .Current
                .FirstOrDefault();
            return lecturerFromDb;
        }

        public IEnumerable<Opinion> GetOpinionsForLecturer(int lecturerId)
        {
            var lecturerFromDb = GetLecturerById(lecturerId);
            return lecturerFromDb?.Opinions;
        }

        public IEnumerable<Lecturer> GetLecturers()
        {
            throw new NotImplementedException();
        }

        public void AddLecturer(Lecturer lecturer)
        {
            var collection = GetLecturerCollection();
            collection.InsertOne(lecturer);
        }

        public void AddOpinion(int lecturerId, Opinion opinion)
        {
            var collection = GetLecturerCollection();
            var lecturerFromDb = GetLecturerById(lecturerId);
            lecturerFromDb.Opinions.Add(opinion);
            collection.ReplaceOne(lecturer => lecturer.Id == lecturerId, lecturerFromDb);
        }
    }
}
