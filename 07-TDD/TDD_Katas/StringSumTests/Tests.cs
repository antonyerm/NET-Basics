//## String Sum Kata

//*Write a simple String Sum utility with a function <em>string Sum(string num1, string num2)</ em >, which can accept only natural numbers and will return their sum. Replace entered number with <em>0 (zero)</ em > if entered number is not a natural number.
//   * Stat with a simplest test case with an empty string
//* Create a simple method <em>string Sum(string num1, string num2)</ em >
//*Write a test to pass small numbers and refactor, if test passed
//* try to write more code and refactor

using NUnit.Framework;
using System;

namespace StringSum
{
    public class Tests
    {
        [Test]
        public void Sum_EmptyStrings_ThrowsException()
        {
            //arrange
            var num1 = string.Empty;
            var num2 = string.Empty;
            var stringSum = new StringSum();

            //act & assert
            Assert.Throws<ArgumentException>(() => { stringSum.Sum(num1, num2); });
        }

        [Test]
        public void Sum_SmallNaturalNumbers_ReturnsTheirSum()
        {
            //arrange
            var num1 = "5";
            var num2 = "1";
            var stringSum = new StringSum();
            var expected = 6;

            //act
            var actual = stringSum.Sum(num1, num2);

            //assert
            Assert.That(expected == actual);
        }

        [Test]
        public void Sum_NotANumberAndNaturalNumber_ReturnsSecondNumber()
        {
            //arrange
            var num1 = "5";
            var num2 = "abc";
            var stringSum = new StringSum();
            var expected = 5;

            //act
            var actual = stringSum.Sum(num1, num2);

            //assert
            Assert.That(expected == actual);
        }

    }
}