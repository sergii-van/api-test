using System;
using System.Collections.Generic;
using System.Linq;
using ApiTest.Core.Models;

namespace ApiTest.Core.Helpers
{
    public static class GpaHelper
    {
        public static void AddStudentToBestStudents(Student student, IDictionary<float, IList<Student>> bestStudents)
        {
            float overallGpa = student.CalculateOverallGpa();
            if (bestStudents.ContainsKey(overallGpa))
            {
                bestStudents[overallGpa].Add(student);
            }
            else
            {
                bestStudents.Add(overallGpa, new List<Student> { student });
            }
        }

        public static void AddStudentGradesToAnnualGpa(Student student, IDictionary<int, IList<float>> annualGpaDictionary)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (student.StartYear > student.EndYear)
            {
                throw new ArgumentException($"Student {student.Id}: Start year {student.StartYear} is greated than end year {student.EndYear}");
            }

            // 2004-2004 - 1 year
            if (student.EndYear - student.StartYear + 1 != student.GPARecord.Length)
            {
                throw new ArgumentException($"Attendance years {student.StartYear} - {student.EndYear} do not match to number of GPAs {student.GPARecord.Length}");
            }

            for (int year = student.StartYear, index = 0; year <= student.EndYear; year++, index++)
            {
                if (annualGpaDictionary.ContainsKey(year))
                {
                    annualGpaDictionary[year].Add(student.GPARecord[index]);
                }
                else
                {
                    annualGpaDictionary.Add(year, new List<float> { student.GPARecord[index] });
                }
            }
        }

        public static int GetHighestsAnnualGpaYear(IDictionary<int, IList<float>> annualGpaDictionary)
        {
            float maxGpa = -1;
            int year = -1;
            foreach (var annualGpa in annualGpaDictionary)
            {
                float average = annualGpa.Value.Average();
                if (maxGpa < average)
                {
                    maxGpa = average;
                    year = annualGpa.Key;
                }
            }

            return year;
        }

        public static IEnumerable<Student> GetBestStudents(IDictionary<float, IList<Student>> bestStudents, int count)
        {
            var topStudents = new List<Student>(count);
            foreach (var students in bestStudents)
            {
                if (students.Value.Count > count)
                {
                    topStudents.AddRange(students.Value.Take(count));
                    break;
                }

                topStudents.AddRange(students.Value);
                count -= students.Value.Count;
            }

            return topStudents;
        }
    }
}
