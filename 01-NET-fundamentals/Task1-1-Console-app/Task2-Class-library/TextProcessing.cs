using System;

namespace Task2_Class_library
{
    public static class TextProcessing
    {
        public static string CreateGreeting(string userName)
        {
            var currentTime = DateTime.Now;
            var result = $"{currentTime:g} Hello, {userName}!";
            return result;
        }
    }
}
