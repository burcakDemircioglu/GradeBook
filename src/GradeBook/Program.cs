using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Burcak's Grade Book");

            // Use ? to be able to assign null to the variable:
            // Book? book = new DiskBook("");
            
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            // Console.WriteLine(InMemoryBook.CATEGORY);
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The highest grade is {stats.High:n1}");
            Console.WriteLine($"The lowest grade is {stats.Low:n1}");
            Console.WriteLine($"The average grade is {stats.Average:n1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit.");
                var input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade is added.");
        }
    }
}