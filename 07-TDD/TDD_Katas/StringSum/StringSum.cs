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

            if (!Int32.TryParse(num1, out int number1))
            {
                number1 = 0;
            }

            if (!Int32.TryParse(num2, out int number2))
            {
                number2 = 0;
            }

            return number1 + number2;
        }
    }
}
