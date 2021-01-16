using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourBestPWrBack.Factories;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public class RelationalLecturerRepo : ILecturerRepo
    {
        private const string GetLecturersSQL = "SELECT * FROM Lecturers;";
        private const string GetOpinionsSQL = "SELECT * FROM Opinions;";
        private const string InsertLecturerSQL = "INSERT INTO Lecturers(FirstName, LastName, Title) VALUES (@FirstName, @LastName, @Title);";
        private const string InsertOpinionSQL = "INSERT INTO Opinions(Rating, Description, Date, LecturerId, UserId, CourseId) VALUES (@Rating, @Description, @Date, @LecturerId, @UserId, @CourseId);";
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public RelationalLecturerRepo(SqlConnectionFactory connectionFactory)
        {
            _sqlConnectionFactory = connectionFactory;
        }

        public void AddLecturer(LecturerBasic lecturer)
        {
            using var connection = _sqlConnectionFactory.Create();
            connection.Execute(InsertLecturerSQL, lecturer);
        }

        public void AddOpinion(Opinion opinion)
        {
            using var connection = _sqlConnectionFactory.Create();
            connection.Execute(InsertOpinionSQL, opinion);
        }

        public IEnumerable<LecturerBasic> GetLecturers()
        {
            using var connection = _sqlConnectionFactory.Create();
            var lecturers = connection.Query<LecturerBasic>(GetLecturersSQL);
            return lecturers;
        }

        public async Task<IEnumerable<LecturerBasic>> GetLecturersAsync()
        {
            await using var connection = _sqlConnectionFactory.Create();
            var lecturers = await connection.QueryAsync<LecturerBasic>(GetLecturersSQL);
            return lecturers;
        }

        public IEnumerable<Opinion> GetOpinionsForLecturer(int lecturerId)
        {
            using var connection = _sqlConnectionFactory.Create();
            var opinions = connection.Query<Opinion>(GetOpinionsSQL)
                .Where(o => o.LecturerId == lecturerId);
            return opinions;
        }

        public async Task<IEnumerable<Opinion>> GetOpinionsForLecturerAsync(int lecturerId)
        {
            await using var connection = _sqlConnectionFactory.Create();
            var opinions = await connection.QueryAsync<Opinion>(GetOpinionsSQL);
            return opinions;
        }
    }
}
