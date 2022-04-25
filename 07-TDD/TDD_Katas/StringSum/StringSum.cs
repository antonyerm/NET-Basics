using System;

namespace StringSum
{
    public class StringSum
    {
        public int Sum(string num1, string num2)
        {
            if (string.IsNullOrEmpty(num1) || string.IsNullOrEmpty(num2))
            {
                throw new ArgumentException();
            }

            var number1 = Int32.Parse(num1);
            var number2 = Int32.Parse(num2);

            return number1 + number2;
        }
    }
}
