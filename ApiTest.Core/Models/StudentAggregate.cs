using ApiTest.Core.Helpers;

namespace ApiTest.Core.Models
{
    public class StudentAggregate
    {
        public string YourName => Constants.Author;

        public string YourEmail => Constants.AuthorEmail;

        public int YearWithHighestAttendance { get; set; }

        public int YearWithHighestOverallGpa { get; set; }

        public int[] Top10StudentIdsWithHighestGpa { get; set; }

        public int StudentIdMostInconsistent { get; set; }
    }
}
