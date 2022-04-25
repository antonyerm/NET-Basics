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
    }
}