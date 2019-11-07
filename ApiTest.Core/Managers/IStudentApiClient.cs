using System.Collections.Generic;
using System.Threading.Tasks;
using ApiTest.Core.Models;

namespace ApiTest.Core.Managers
{
    public interface IStudentApiClient
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();

        Task SubmitResult(StudentAggregate aggregate);
    }
}
