using FluentAssertions;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourBestPWrBack.Models;
using YourBestPWrBack.Services;

namespace Tests
{
    class AuthRepoTests
    {
        private IAuthRepo _authRepo;
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

        private void AddDummyAuth(User user)
        {
            _authRepo.Auth(user);
        }

        [SetUp]
        public void Setup()
        {
            var sqlConnString = File.ReadAllText("Properties/SQLString.txt");
            _authRepo = new SimpleAuthRepo();
            var serviceProvider = CreateServices(sqlConnString);

            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            using var scope = serviceProvider.CreateScope();
            RebuildDB(scope.ServiceProvider);
        }

        [Test]
        public void TestUnauthorized()
        {
            _authRepo.IsAuthorized(string.Empty).Should().BeFalse();
        }

        [Test]
        public void TestAuthorized()
        {
            var username = "asdfg";
            var token = _authRepo.Auth(new User { UserName = username });
            _authRepo.IsAuthorized(token).Should().BeTrue();
        }
    }
}
