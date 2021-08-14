using Database;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database data;

        [SetUp]
        public void Setup()
        {
            data = new Database.Database();
        }

        [Test]
        public void ConstructorCreatesProperDatabase()
        {
            Assert.That(data.Count == 0);
        }
    }
}