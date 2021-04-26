using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Skeleton
{
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);

            //Act
            dummy.TakeAttack(2);

            //Assert
            Assert.That(8, Is.EqualTo(dummy.Health));
        }

        [Test]
        public void DeadDummyThrowsInvalidOperationExceptionIfAttacked()
        {
            //Arrange
            Dummy dummy = new Dummy(0, 10);

            //Act Assert
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(2));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            //Arange
            Dummy dummy = new Dummy(0, 5);

            //Act
            int result = dummy.GiveExperience();

            //Assert
            Assert.That(5, Is.EqualTo(result));
        }

        [Test]
        public void AliveDummyCannotGiveXP()
        {
            //Arange
            Dummy dummy = new Dummy(5, 5);

            //Act Assert
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
