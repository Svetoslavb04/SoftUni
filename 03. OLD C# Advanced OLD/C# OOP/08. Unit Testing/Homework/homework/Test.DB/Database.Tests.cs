using DB;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.DB
{
    public class Tests
    {
        private Database database;

        [Test]
        public void IfConstructorsThrowsInvalidOperationOnMoreThanCapacity()
        {
            //Act
            Assert.Throws<InvalidOperationException>(() => database = new Database(new int[17]));
        }

        [Test]
        public void IfConstructorsCreateInstanceCorrectly()
        {
            //Arange
            this.database = new Database(12, 12, 43, 12, 53, 12, 54, 12, 2);

            //Act
            var dbCopy = database.Fetch();

            //Assert
            Assert.That(9, Is.EqualTo(dbCopy.Length));
        }
    }
}
