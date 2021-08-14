using NUnit.Framework;
using Skeleton;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeReduceDurability()
    {
        //Arrange
        Axe axe = new Axe(5, 5);
        //Act
        axe.Attack(new Dummy(4, 3));
        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(4));
    }

    [Test]
    public void BrokenAxeAttack()
    {
        //Arrange
        Axe axe = new Axe(3, 0);
        //Act
        //Assert
        Assert.That(() => axe.Attack(new Dummy(4, 3)), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}