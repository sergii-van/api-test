using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiTest.Core.Models;
using Newtonsoft.Json;

namespace ApiTest.Core.Managers
{
    public class StudentApiClient : IStudentApiClient
    {
        private readonly IHttpClientFactory _clientFactory;

        public StudentApiClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            using (var client = _clientFactory.CreateClient("ApiTestClient"))
            {
                using (var response = await client.GetAsync("Students"))
                {
                    response.EnsureSuccessStatusCode();

                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var sr = new StreamReader(responseStream))
                        {
                            using (var jsonTextReader = new JsonTextReader(sr))
                            {
                                var serializer = new JsonSerializer();
                                var students = serializer.Deserialize<IEnumerable<Student>>(jsonTextReader);

                                return students;
                            }
                        }
                    }
                }
            }
        }

        public async Task SubmitResult(StudentAggregate aggregate)
        {
            using (var client = _clientFactory.CreateClient("ApiTestClient"))
            {
                using (var stringContent = new StringContent(JsonConvert.SerializeObject(aggregate)))
                {
                    stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    using (var response = await client.PutAsync("StudentAggregate", stringContent))
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
        }
    }
}
