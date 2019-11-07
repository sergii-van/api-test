using ApiTest.Core.Models;

namespace ApiTest.Core.Managers
{
    public interface IOutputFormatter
    {
        void PrintResult(StudentAggregate studentAggregate);
    }
}
