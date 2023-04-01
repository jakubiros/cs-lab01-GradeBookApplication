using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook:BaseGradeBook
    {
        public  RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            int totalStudents = Students.Count;
            int top20Percent = (int)Math.Round(totalStudents * 0.2);
            int top40Percent = (int)Math.Round(totalStudents * 0.4);
            int top60Percent = (int)Math.Round(totalStudents * 0.6);
            int top80Percent = (int)Math.Round(totalStudents * 0.8);
            List<Student> sortedStudents = Students.OrderByDescending(s => s.AverageGrade).ToList();
            List<double> sortedGrades=new List<double>();
            foreach (Student student in sortedStudents)
            {
                sortedGrades.Add(student.AverageGrade);
            }
            int? index = null;
            ind:
            index = sortedGrades.FindIndex(s => s == averageGrade);

            if (index < 0)
            {
                sortedGrades.Add(averageGrade);
                sortedGrades = sortedGrades.OrderByDescending(s => s).ToList();
                goto ind;
            }

            if (index < top20Percent)
                return 'A';
            else if (index < top40Percent)
                return 'B';
            else if (index < top60Percent)
                return 'C';
            else if (index < top80Percent)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count <5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStatistics();
        }
    }
}
