using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public class OpinionRepo: IOpinionRepo
    {
        private readonly MongoClient _mongoClient;
        private const string PipelineString = "{ $project: { \"Id\":1 , \"firstName\":1, \"lastName\":1} }";
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

        private Lecturer GetLecturerById(BsonObjectId lecturerId)
        {
            var database = _mongoClient.GetDatabase("db1");
            var collection = database.GetCollection<Lecturer>("lecturers");
            //TODO: Fix later. Should work for now
            var cursor = collection
                .FindSync(l => l.Id== lecturerId);
            cursor.MoveNext();
            var lecturerFromDb = cursor
                .Current
                .FirstOrDefault();
            return lecturerFromDb;
        }

        private async Task<Lecturer> GetLecturerByIdASync(BsonObjectId lecturerId)
        {
            var collection = GetLecturerCollection();
            //TODO: Fix later. Should work for now
            var cursor = await collection
                .FindAsync(l => l.Id == lecturerId);
            await cursor.MoveNextAsync();
            var lecturerFromDb = cursor
                .Current
                .FirstOrDefault();
            return lecturerFromDb;
        }

        public IEnumerable<Opinion> GetOpinionsForLecturer(BsonObjectId lecturerId)
        {
            var lecturerFromDb = GetLecturerById(lecturerId);
            return lecturerFromDb?.Opinions;
        }

        public IEnumerable<Lecturer> GetLecturers()
        {
            var collection = GetLecturerCollection();
            var list = collection.Aggregate().ToList();
            return list;
        }

        public async Task<IEnumerable<Lecturer>> GetLecturersAsync()
        {
            var collection = GetLecturerCollection();
            var aggregate = await collection.AggregateAsync(PipelineDefinition<Lecturer,Lecturer>.Create(PipelineString));
            var lecturers = await aggregate.ToListAsync();
            return lecturers;
        }

        public void AddLecturer(Lecturer lecturer)
        {
            var collection = GetLecturerCollection();
            collection.InsertOne(lecturer);
        }

        public void AddOpinion(BsonObjectId lecturerId, Opinion opinion)
        {
            var collection = GetLecturerCollection();
            var lecturerFromDb = GetLecturerById(lecturerId);
            lecturerFromDb.Opinions.Add(opinion);
            collection.ReplaceOne(lecturer => lecturer.Id == lecturerId, lecturerFromDb);
        }

        public async Task<IEnumerable<Opinion>> GetOpinionsForLecturerAsync(BsonObjectId lecturerId)
        {
            var lecturer = await GetLecturerByIdASync(lecturerId);
            return lecturer.Opinions;
        }

    }
}
