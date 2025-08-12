using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingAutomation
{
    internal class TestDesignTechniques
    {
    }
    public class PasswordValidator
    {
        public bool IsValid(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;
            if (password.Length < 6 || password.Length > 12)
                return false;
            if (!password.Any(char.IsDigit))
                return false;
            if (password.Contains(' '))
                return false;
            return true;
        }
    }

    [TestFixture]
    public class PasswordTests
    {
        private PasswordValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new PasswordValidator();
        }

        // Equivalence Partitioning
        [TestCase("Pass123", true)]   // valid
        [TestCase("Pas1", false)]     // too short
        [TestCase("Password123456", false)] // too long
        [TestCase("Password", false)] // no digit
        [TestCase("Pass 123", false)] // space
        public void TestEquivalencePartitioning(string input, bool expected)
        {
            Assert.That(_validator.IsValid(input), Is.EqualTo(expected));
        }

        // Boundary Value Analysis
        [TestCase("Pass12", true)]       // 6 chars
        [TestCase("Pass1", false)]       // 5 chars
        [TestCase("Pass12345678", true)] // 12 chars
        [TestCase("Pass123456789", false)] // 13 chars
        public void TestBoundaryValues(string input, bool expected)
        {
            Assert.That(_validator.IsValid(input), Is.EqualTo(expected));
        }
    }
}
