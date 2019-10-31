using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;

        public string Name;

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
        }

        public void AddLetterGrade(char letter)
        {
            // if (letter == 'A')
            // {
            //     AddGrade(90);
            // }
            // else if (letter == 'B')
            // {
            //     AddGrade(80);
            // }

            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for (var index = 0; index < grades.Count; index++)
            {
                if (grades[index] == 42.1)
                {
                    break;
                    // goto done;
                    // continue;
                }

                result.High = Math.Max(result.High, grades[index]);
                result.Low = Math.Min(result.Low, grades[index]);
                // done:
                result.Average += grades[index];
            }

            // var index = 0;
            // while (index < grades.Count)
            // {
            //     result.High = Math.Max(result.High, grades[index]);
            //     result.Low = Math.Min(result.Low, grades[index]);
            //     result.Average += grades[index];
            //     index++;
            // }

            // foreach (var grade in grades)
            // {
            //     result.High = Math.Max(result.High, grade);
            //     result.Low = Math.Min(result.Low, grade);
            //     result.Average += grade;
            // }

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }
            
            return result;
        }
    }
}