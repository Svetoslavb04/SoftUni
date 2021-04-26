using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Skeleton
{
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            //Arange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(5, 5);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.AreEqual(9, axe.DurabilityPoints);
        }

        [Test]
        public void ThrowsInvalidOperationExceptionOnAttackWithBrokenAxe()
        {
            //Arange
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(5, 5);

            //ActAssert
            Assert.Throws<InvalidOperationException>( () => axe.Attack(dummy));
        }
    }
}
