using System;

namespace LeapYearKata
{
    public class LeapYear
    {
        public bool IsLeapYear(int number)
        {
            bool result = default;
            if (number % 4 != 0)
            {
                result = false;
            }

            return result;
        }
    }
}
