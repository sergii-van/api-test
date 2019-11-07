using System;
using ApiTest.App.Helpers;
using ApiTest.Core.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTest.App
{
    public static class ContainerConfig
    {
        public static IServiceProvider Configure()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IStudentManager, StudentManager>();
            serviceCollection.AddTransient<IStudentApiClient, StudentApiClient>();
            serviceCollection.AddTransient<IOutputFormatter, ConsoleOutputFormatter>();

            serviceCollection.AddHttpClient("ApiTestClient", c =>
            {
                c.BaseAddress = new Uri("http://apitest.sertifi.net/api/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
