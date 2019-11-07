using System.Threading.Tasks;
using ApiTest.Core.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTest.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = ContainerConfig.Configure();

            var studentManager = serviceProvider.GetService<IStudentManager>();
            var studentApiClient = serviceProvider.GetService<IStudentApiClient>();
            var formatter = serviceProvider.GetService<IOutputFormatter>();

            var students = await studentApiClient.GetAllStudentsAsync();

            var aggregatedStatistics = studentManager.CalculateStudentsStatistics(students);

            formatter.PrintResult(aggregatedStatistics);
            await studentApiClient.SubmitResult(aggregatedStatistics);
        }
    }
}
