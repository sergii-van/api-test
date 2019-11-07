using System.Collections.Generic;
using ApiTest.Core.Models;

namespace ApiTest.Core.Managers
{
    public interface IStudentManager
    {
        StudentAggregate CalculateStudentsStatistics(IEnumerable<Student> students);
    }
}