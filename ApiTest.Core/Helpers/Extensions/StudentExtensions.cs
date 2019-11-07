using System;
using System.Linq;
using ApiTest.Core.Models;

namespace ApiTest.Core.Helpers
{
    public static class StudentExtensions
    {
        public static float CalculateOverallGpa(this Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (student.GPARecord.Length == 0)
            {
                return 0;
            }

            return student.GPARecord.Average();
        }

        public static float CalculateGradesInconsistency(this Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (student.GPARecord.Length < 2)
            {
                return 0;
            }

            float minGPA = student.GPARecord[0];
            float maxGPA = student.GPARecord[0];
            for (int index = 1; index < student.GPARecord.Length; index++)
            {
                minGPA = Math.Min(minGPA, student.GPARecord[index]);
                maxGPA = Math.Max(maxGPA, student.GPARecord[index]);
            }

            return maxGPA - minGPA;
        }
    }
}
