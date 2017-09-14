using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Task3.Tests
{
    [TestFixture]
    public class PrimeNumbersTest
    {
        private PrimeNumbers _primeNumbers;

        [SetUp]
        public void RunBeforeAnyTests()
        {
            _primeNumbers = new PrimeNumbers();
        }

        [Test, Description("Should check if is the candidate integer is a prime number")]
        public void IsCandidatePrime()
        {
            const int candidateNumber = 5;

            bool actualResult = _primeNumbers.IsPrime(candidateNumber);

            Assert.IsTrue(actualResult);
        }

        [Test, Description("Should check if is the candidate integer is not a prime number")]
        public void IsCandidateNotPrime()
        {
            const int candidateNumber = 10;

            bool actualResult = _primeNumbers.IsPrime(candidateNumber);

            Assert.IsFalse(actualResult);
        }

        [Test, Description("Should check if is zero is not a prime and not a composite number")]
        public void IsZeroNotPrimeAndNotComposite()
        {
            const int candidateNumber = 0;

            bool actualResult = _primeNumbers.IsPrime(candidateNumber);
            IEnumerable<int> actualPrimeFactorsResult = _primeNumbers.GetPrimeFactors(candidateNumber);

            Assert.IsFalse(actualResult);
            Assert.IsFalse(actualPrimeFactorsResult.Any());
        }

        [Test, Description("Should check if is zero is not a prime and not a composite number")]
        public void IsNegativeIntegerNotPrimeAndNotComposite()
        {
            const int candidateNumber = -10;

            bool actualResult = _primeNumbers.IsPrime(candidateNumber);
            IEnumerable<int> actualPrimeFactorsResult = _primeNumbers.GetPrimeFactors(candidateNumber);

            Assert.IsFalse(actualResult);
            Assert.IsFalse(actualPrimeFactorsResult.Any());
        }

        [Test, Description("Should check if is prime fatorization is correct")]
        public void IsPrimeFactorsCalculationCorrect()
        {
            const int candidateNumber = 40;

            var expectedResult = new List<int>
            {
                2, 2, 2, 5
            };

            IEnumerable<int> actualResult = _primeNumbers.GetPrimeFactors(candidateNumber);

            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }

        [TearDown]
        public void TestTearDown()
        {
            _primeNumbers = null;
        }
    }
}
