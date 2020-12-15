﻿using Dapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public class RelationalLecturerRepo : ILecturerRepo
    {
        const string GetLecturersSQL = "SELECT * FROM LECTURERS;";
        const string GetOpinionsSQL = "SELECT * FROM OPINIONS;";
        const string InsertLecturerSQL = "INSERT INTO Lecturers(FirstName, LastName, Title) VALUES (@FirstName, @LastName, @Title);";
        const string InsertOpinionSQL = "INSERT INTO Opinions(Rating, Description, Date, LecturerId, UserId, CourseId);";
        private readonly string _connectionString;

        public RelationalLecturerRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddLecturer(LecturerBasic lecturer)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(InsertLecturerSQL, lecturer);
        }

        public void AddOpinion(Opinion opinion)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(InsertOpinionSQL, opinion);
        }

        public IEnumerable<LecturerBasic> GetLecturers()
        {
            using var connection = new SqlConnection(_connectionString);
            var lecturers = connection.Query<LecturerBasic>(GetLecturersSQL);
            return lecturers;
        }

        public async Task<IEnumerable<LecturerBasic>> GetLecturersAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            var lecturers = await connection.QueryAsync<LecturerBasic>(GetLecturersSQL);
            return lecturers;
        }

        public IEnumerable<Opinion> GetOpinionsForLecturer(int lecturerId)
        {
            using var connection = new SqlConnection(_connectionString);
            var opinions = connection.Query<Opinion>(GetOpinionsSQL);
            return opinions;
        }

        public async Task<IEnumerable<Opinion>> GetOpinionsForLecturerAsync(int lecturerId)
        {
            using var connection = new SqlConnection(_connectionString);
            var opinions = await connection.QueryAsync<Opinion>(GetOpinionsSQL);
            return opinions;
        }
    }
}
