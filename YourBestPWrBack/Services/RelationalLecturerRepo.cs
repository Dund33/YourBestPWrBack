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
        const string GetOpinionsSQL = "SELECT * FROM OPINIONS";
        private readonly string _connectionString;

        public RelationalLecturerRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddLecturer(Lecturer lecturer)
        {
            throw new NotImplementedException();
        }

        public void AddOpinion(int lecturerId, Opinion opinion)
        {
            throw new NotImplementedException();
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
