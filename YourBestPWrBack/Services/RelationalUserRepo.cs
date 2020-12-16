using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public class RelationalUserRepo : IUserRepo
    {
        private const string AddUserSQL = "INSERT INTO Users(Username, PasswordHash, GenderId) VALUES (@UserName, @PasswordHash, @GenderId);";
        private const string GetUserSQL = "SELECT * FROM Users";
        private readonly string _connectionString;
        public RelationalUserRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddUser(User user)
        {
            using var connection = new MySqlConnection(_connectionString);
            using var transaction = connection.BeginTransaction();
            var rowsAffected = connection.Execute(AddUserSQL, user);
            
            if (rowsAffected != 1)
                transaction.Rollback();
            else
                transaction.Commit();
        }

        public User GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
