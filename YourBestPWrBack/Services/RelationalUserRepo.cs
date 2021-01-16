﻿using Dapper;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;
using YourBestPWrBack.Factories;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public class RelationalUserRepo : IUserRepo
    {
        private const string AddUserSQL = "INSERT INTO Users(Username, PasswordHash, GenderId) VALUES (@UserName, @PasswordHash, @GenderId);";
        private const string GetUserSQL = "SELECT * FROM Users WHERE Username = @UserName";
        private const string RemoveUserSQL = "DELETE FROM Users WHERE Username = @UserName";
        private readonly SqlConnectionFactory _sqlConnectionFactory;
        public RelationalUserRepo(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public void AddUser(User user)
        {
            using var connection = _sqlConnectionFactory.Create();
            connection.Open();
            using var transaction = connection.BeginTransaction();
            var rowsAffected = connection.Execute(AddUserSQL, user);

            if (rowsAffected != 1)
                transaction.Rollback();
            else
                transaction.Commit();
        }

        public User GetUser(string username)
        {
            using var connection = _sqlConnectionFactory.Create();
            return connection.Query<User>(GetUserSQL, new { UserName = username }).FirstOrDefault();
        }

        public async Task<User> GetUserAsync(string username)
        {
            using var connection = _sqlConnectionFactory.Create();
            var users = await connection.QueryAsync<User>(GetUserSQL, new { UserName = username });
            return users.FirstOrDefault();
        }

        public void RemoveUser(string username)
        {
            var data = new { UserName = username };
            using var connection = _sqlConnectionFactory.Create();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            var rowsAffected = connection.Execute(RemoveUserSQL, data);

            if (rowsAffected != 1)
                transaction.Rollback();
            else
                transaction.Commit();
        }
    }
}
