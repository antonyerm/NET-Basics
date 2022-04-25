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

            return 0;
        }
    }
}
