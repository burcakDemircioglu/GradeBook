using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Burcak's Grade Book");

            book.AddGrade(34.5);
            book.AddGrade(40.5);
            book.AddGrade(23);

            var stats = book.GetStatistics();

            Console.WriteLine($"The highest grade is {stats.High:n1}");
            Console.WriteLine($"The lowest grade is {stats.Low:n1}");
            Console.WriteLine($"The average grade is {stats.Average:n1}");
        }
    }
}