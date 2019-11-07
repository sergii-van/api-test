using System.Collections.Generic;
using System.Linq;
using ApiTest.Core.Helpers;
using ApiTest.Core.Models;

namespace ApiTest.Core.Managers
{
    public class StudentManager : IStudentManager
    {
        public StudentAggregate CalculateStudentsStatistics(IEnumerable<Student> students)
        {
            var attendanceDictionary = new Dictionary<int, int>();
            var annualGpaDictionary = new Dictionary<int, IList<float>>();
            var bestStudents = new SortedDictionary<float, IList<Student>>(new GpaComparer());
            Student mostInconsistentStudent = null;
            float maxInconsistency = -1;

            foreach (var student in students)
            {
                AttendanceHelper.AddStudentAttendance(student, attendanceDictionary);
                GpaHelper.AddStudentToBestStudents(student, bestStudents);
                GpaHelper.AddStudentGradesToAnnualGpa(student, annualGpaDictionary);
                float inconsistency = student.CalculateGradesInconsistency();
                if (maxInconsistency < inconsistency)
                {
                    maxInconsistency = inconsistency;
                    mostInconsistentStudent = student;
                }
            }

            var statistics = new StudentAggregate();
            statistics.YearWithHighestAttendance = AttendanceHelper.FindMostAttendedYear(attendanceDictionary);
            statistics.StudentIdMostInconsistent = (mostInconsistentStudent?.Id).GetValueOrDefault();
            statistics.YearWithHighestOverallGpa = GpaHelper.GetHighestsAnnualGpaYear(annualGpaDictionary);
            statistics.Top10StudentIdsWithHighestGpa = GpaHelper.GetBestStudents(bestStudents, Constants.TopStudentsToSubmit).Select(x => x.Id).ToArray();

            return statistics;
        }
    }
}
