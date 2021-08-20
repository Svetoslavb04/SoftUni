using NUnit.Framework;
using System;

namespace Robots
{

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ConstructorCreatesProperRobot()
        {
            Robot robot = new Robot("Pesho", 100);

            Assert.That(robot.Name, Is.EqualTo("Pesho"));
            Assert.That(robot.Battery, Is.EqualTo(100));
            Assert.That(robot.MaximumBattery, Is.EqualTo(100));
        }

        [Test]
        public void ConstructorCreatesProperRobotManager()
        {
            RobotManager robotManager = new RobotManager(10);

            Assert.That(robotManager.Capacity, Is.EqualTo(10));
            Assert.That(robotManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void ConstructorThrowsProperExceptionOnInvalidInput()
        {
            Assert.That(() => new RobotManager(-10), Throws.ArgumentException.With.Message.EqualTo("Invalid capacity!"));
        }

        [Test]
        public void RobotManagerAddsProperly()
        {
            Robot robot = new Robot("Pesho", 100);
            RobotManager robotManager = new RobotManager(10);

            robotManager.Add(robot);
            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void ThrowsExceptionOnFullManager()
        {
            Robot robot = new Robot("Pesho", 100);
            Robot robotOne = new Robot("Peshoo", 100);
            RobotManager robotManager = new RobotManager(1);

            robotManager.Add(robot);
            
            Assert.That(() => robotManager.Add(robotOne), Throws.InvalidOperationException.With.Message.EqualTo("Not enough capacity!"));

        }

        [Test]
        public void ThrowsExceptionOnAddingSameRobot()
        {
            Robot robot = new Robot("Pesho", 100);
            RobotManager robotManager = new RobotManager(1);

            robotManager.Add(robot);

            Assert.That(() => robotManager.Add(robot), Throws.InvalidOperationException.With.Message.EqualTo($"There is already a robot with name {robot.Name}!"));
        }

        [Test]
        public void RobotManagerRemovesProperly()
        {
            Robot robot = new Robot("Pesho", 100);
            RobotManager robotManager = new RobotManager(10);

            robotManager.Add(robot);
            robotManager.Remove(robot.Name);
            Assert.That(robotManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void RobotManagerThorowsExceptionOnInvalidNameToRemove()
        {
            RobotManager robotManager = new RobotManager(10);

            Assert.That(() => robotManager.Remove("Goso"), Throws.InvalidOperationException.With.Message.EqualTo($"Robot with the name Goso doesn't exist!"));
        }

        [Test]
        public void RobotManagerWorksProperly()
        {
            Robot robot = new Robot("Pesho", 100);
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(robot);

            robotManager.Work(robot.Name, "do stuff", 20);

            Assert.That(robot.Battery, Is.EqualTo(80));
        }

        [Test]
        public void ThrowsExceptionOnWorkingNonExistedRobot()
        {
            RobotManager robotManager = new RobotManager(1);

            Assert.That(() => robotManager.Work("d","d", 2), Throws.InvalidOperationException.With.Message.EqualTo($"Robot with the name d doesn't exist!"));
        }

        [Test]
        public void ThrowsExceptionOnWorkingWithoutBattery()
        {
            Robot robot = new Robot("Pesho", 100);
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(robot);
            Assert.That(() => robotManager.Work(robot.Name, "d", 200), Throws.InvalidOperationException.With.Message.EqualTo($"{robot.Name} doesn't have enough battery!"));
        }

        [Test]
        public void RobotManagerChargesProperly()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Pesho", 100);
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "da", 100);

            robotManager.Charge(robot.Name);

            Assert.That(robot.Battery, Is.EqualTo(robot.MaximumBattery));
        }

        [Test]
        public void ThrowsExceptionOnChargingNullRobot()
        {
            RobotManager robotManager = new RobotManager(1);

            Assert.That(() => robotManager.Charge("d"), Throws.InvalidOperationException.With.Message.EqualTo($"Robot with the name d doesn't exist!"));

        }
    }
}
