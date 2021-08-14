using NUnit.Framework;
using Skeleton;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummysHealthReduces()
    {
        //Arrange
        Dummy dummy = new Dummy(10, 10);
        //Act
        dummy.TakeAttack(3);
        //Assert
        Assert.That(dummy.Health, Is.EqualTo(7));
    }

    [Test]
    public void DeadDummyCantTakeDamage()
    {
        //Arrange
        Dummy dummy = new Dummy(0,5);
        //Act
        //Assert
        Assert.That(() => dummy.TakeAttack(3), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyGivesXp()
    {
        //Arrange
        Dummy dummy = new Dummy(0, 10);
        //Act
        //Assert
        Assert.That(dummy.GiveExperience(), Is.EqualTo(10));
    }

    [Test]
    public void AliveDummyCantGiveXp()
    {
        //Arrange
        Dummy dummy = new Dummy(1, 5);
        //Act
        //Assert
        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
