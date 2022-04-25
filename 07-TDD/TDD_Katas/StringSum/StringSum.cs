using System;

namespace StringSum
{
    public class StringSum
    {
        public string Sum(string num1, string num2)
        {
            if (string.IsNullOrEmpty(num1) || string.IsNullOrEmpty(num2))
            {
                throw new ArgumentException();
            }

            if (!int.TryParse(num1, out int number1))
            {
                number1 = 0;
            }

            if (!int.TryParse(num2, out int number2))
            {
                number2 = 0;
            }

            var result = (number1 + number2).ToString();
            return result;
        }
    }
}
