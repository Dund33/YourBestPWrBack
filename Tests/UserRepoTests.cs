using FluentAssertions;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.IO;
using YourBestPWrBack.Services;

namespace Tests
{
    internal class UserRepoTests
    {

        private IUserRepo _userRepo;
        private static IServiceProvider CreateServices(string sqlConnString)
        {
            return new ServiceCollection().AddLogging(c => c.AddFluentMigratorConsole())
               .AddFluentMigratorCore()
               .ConfigureRunner(c => c
               .AddMySql5()
               .WithGlobalConnectionString(sqlConnString)
               .ScanIn(AppDomain.CurrentDomain.Load("YourBestPWrBack")).For.All())
               .BuildServiceProvider(false);
        }

        private static void RebuildDB(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateDown(0);
            runner.MigrateUp(1);
        }

        private void AddDummyUser(string username)
        {
            _userRepo.AddUser(new YourBestPWrBack.Models.User
            {
                UserName = username,
                AccessType = YourBestPWrBack.AccessType.User,
                PasswordHash = "asd",
                GenderId = null
            });
        }

        [SetUp]
        public void Setup()
        {
            var sqlConnString = File.ReadAllText("Properties/SQLString.txt");
            _userRepo = new RelationalUserRepo(sqlConnString);
            var serviceProvider = CreateServices(sqlConnString);

            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            using var scope = serviceProvider.CreateScope();
            RebuildDB(scope.ServiceProvider);
        }

        [Test]
        public void TestUnknownUserAsync()
        {
            var user = _userRepo.GetUserAsync("random_username").Result;
            user.Should().BeNull();
        }

        [Test]
        public void TestUnknownUser()
        {
            var user = _userRepo.GetUser("random_username");
            user.Should().BeNull();
        }

        [Test]
        public void TestAddUserAsync()
        {
            var username = "random_username";
            AddDummyUser(username);
            var user = _userRepo.GetUserAsync(username).Result;
            user.Should().NotBeNull();
        }

        [Test]
        public void TestAddUser()
        {
            var username = "random_username";
            AddDummyUser(username);
            var user = _userRepo.GetUser(username);
            user.Should().NotBeNull();
        }
    }
}
