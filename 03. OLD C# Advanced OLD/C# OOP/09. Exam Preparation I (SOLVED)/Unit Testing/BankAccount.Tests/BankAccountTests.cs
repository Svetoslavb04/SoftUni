using System;
using NUnit.Framework;

namespace BankAccount.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_InitializeCorrectlyBankAccountName()
        {
            //Arrange Act
            var bankAccount = new BankAccount("pesho", 20);

            Assert.That("pesho", Is.EqualTo(bankAccount.Name));
        }

        [Test]
        public void Constructor_InitializeCorrectlyBankAccountBalance()
        {
            //Arrange Act
            var bankAccount = new BankAccount("pesho", 20);

            Assert.That(20, Is.EqualTo(bankAccount.Balance));
        }

        [Test]
        [TestCase("p")]
        [TestCase("pe")]
        [TestCase("peeeeeeeeeeeeeeeeeeeeeeeee")]
        [TestCase("peeeeeeeeeeeeeeeeeeeeeeeeee")]
        public void Setter_NameThrowsArgumentExceptionOnInvalidName(string name)
        {
            //Act Assert
            Assert.Throws<ArgumentException>(() => new BankAccount(name, 20));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-214124)]
        [TestCase(-2313)]
        public void Setter_BalanceThrowsArgumentExceptionOnInvalidValue(int value)
        {
            //Act Assert
            Assert.Throws<ArgumentException>(() => new BankAccount("Pesho", value));
        }

        [Test]
        public void Deposit_BalanceIsIncreasedWithAmount()
        {
            //Arrange
            var bankAccount = new BankAccount("pesho", 20);

            //Act
            bankAccount.Deposit(200);

            //Assert
            Assert.AreEqual(220, bankAccount.Balance);
        }

        [Test]
        public void Deposit_ThrowsInvalidOperationExceptionOnInvalidAmount()
        {
            //Arrange
            var bankAccount = new BankAccount("pesho", 20);

            //Act Assert
            Assert.Throws<InvalidOperationException>(() =>  bankAccount.Deposit(-200));
        }

        [Test]
        public void Withdraw_BalanceIsDecreased()
        {
            //Arrange
            var bankAccount = new BankAccount("pesho", 20);

            //Act
            bankAccount.Withdraw(2);

            //Assert
            Assert.AreEqual(18, bankAccount.Balance);
        }

        [Test]
        public void Withdraw_ThrowsInvalidOperationExceptionOnInvalidAmount()
        {
            //Arrange
            var bankAccount = new BankAccount("pesho", 20);

            //Act Assert
            Assert.Throws<InvalidOperationException>(() =>bankAccount.Withdraw(-23));
            
        }

        [Test]
        public void Withdraw_ThrowsInvalidOperationExceptionOnBiggerAmountThanBalance()
        {
            //Arrange
            var bankAccount = new BankAccount("pesho", 20);

            //Act Assert
            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(200));
        }
    }
}