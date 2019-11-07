using System;
using System.Collections.Generic;
using ApiTest.Core.Models;

namespace ApiTest.Core.Helpers
{
    public static class AttendanceHelper
    {
        public static void AddStudentAttendance(Student student, IDictionary<int, int> attendanceDictionary)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (student.StartYear > student.EndYear)
            {
                throw new ArgumentException($"Student {student.Id}: Start year {student.StartYear} is greater than end year {student.EndYear}");
            }

            // 2004-2004 - 1 year
            for (int year = student.StartYear; year <= student.EndYear; year++)
            {
                if (attendanceDictionary.ContainsKey(year))
                {
                    attendanceDictionary[year]++;
                }
                else
                {
                    attendanceDictionary.Add(year, 1);
                }
            }
        }

        public static int FindMostAttendedYear(IDictionary<int, int> attendanceDictionary)
        {
            int year = int.MaxValue;
            int maxAttendance = -1;
            foreach (var attendance in attendanceDictionary)
            {
                if (maxAttendance <= attendance.Value)
                {
                    maxAttendance = attendance.Value;
                    year = Math.Min(year, attendance.Key);
                }
            }

            return year;
        }
    }
}
