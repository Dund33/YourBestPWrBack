using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Common;
using NUnit.Framework;
using YourBestPWrBack.Services;

namespace Tests
{
    internal class RepoTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestUnknownUser()
        {
            var repo = new MockAuthRepo();
            var accessType = repo.GetAccessType("unknownuser");
            accessType.IsSameOrEqualTo(0);
        }

        [Test]
        public void TestKnownUser()
        {

        }
    }
}
