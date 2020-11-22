using MongoDB.Driver;
using System.Linq;
using System.Security.Authentication;
using YourBestPWrBack.Models;

namespace YourBestPWrBack.Services
{
    public class UserRepo : IUserRepo
    {
        private readonly MongoClient _mongoClient;
        private const string Name = "db1";
        private const string CollectionName = "users";

        public UserRepo(string connectionString)
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.RetryWrites = false;
            settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
            _mongoClient = new MongoClient(settings);
        }

        private IMongoCollection<User> GetUserCollection()
        {
            var database = _mongoClient.GetDatabase(Name);
            var collection = database.GetCollection<User>(CollectionName);
            return collection;
        }
        public void AddUser(User user)
        {
            var collection = GetUserCollection();
            collection.InsertOne(user);
        }

        public User GetUser(string username)
        {
            var collection = GetUserCollection();
            var user = collection
                .Find(user => user.UserName == username)
                .First();
            return user;
        }

        public void RemoveUser(string username)
        {
            var collection = GetUserCollection();
            var user = collection
                .FindOneAndDelete(user => user.UserName == username);
        }
    }
}
