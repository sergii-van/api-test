using System;
using ApiTest.Core.Managers;
using ApiTest.Core.Models;

namespace ApiTest.App.Helpers
{
    public class ConsoleOutputFormatter : IOutputFormatter
    {
        public void PrintResult(StudentAggregate studentAggregate)
        {
            Console.WriteLine($"YourName: {studentAggregate.YourName}");
            Console.WriteLine($"YourEmail: {studentAggregate.YourEmail}");
            Console.WriteLine($"YearWithHighestAttendance: {studentAggregate.YearWithHighestAttendance}");
            Console.WriteLine($"YearWithHighestOverallGpa: {studentAggregate.YearWithHighestOverallGpa}");
            Console.WriteLine($"Top10StudentIdsWithHighestGpa: {string.Join(",", studentAggregate.Top10StudentIdsWithHighestGpa)}");
            Console.WriteLine($"StudentIdMostInconsistent: {studentAggregate.StudentIdMostInconsistent}");
        }
    }
}
