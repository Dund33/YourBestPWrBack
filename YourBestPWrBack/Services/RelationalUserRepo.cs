using Dapper;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public class RelationalUserRepo : IUserRepo
    {
        private const string AddUserSQL = "INSERT INTO Users(Username, PasswordHash, GenderId) VALUES (@UserName, @PasswordHash, @GenderId);";
        private const string GetUserSQL = "SELECT * FROM Users WHERE Username = @Username";
        private const string RemoveUserSQL = "DELETE FROM Users WHERE Username = @UserName";
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
            using var connection = new MySqlConnection(_connectionString);
            return connection.Query<User>(GetUserSQL).FirstOrDefault();
        }

        public async Task<User> GetUserAsync(string username)
        {
            using var connection = new MySqlConnection(_connectionString);
            var users = await connection.QueryAsync<User>(GetUserSQL);
            return users.FirstOrDefault();
        }

        public void RemoveUser(string username)
        {
            var data = new { UserName = username };
            using var connection = new MySqlConnection(_connectionString);
            var users = connection.Execute(RemoveUserSQL, data);
        }
    }
}
