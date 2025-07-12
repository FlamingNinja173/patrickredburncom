using ResumeSite.Web.Services;
using System.Net;
using System.Text;

namespace ResumeSite.Tests.Web
{
    public class EducationServiceTests
    {
        [Fact]
        public async Task GetEducation_ReturnsData()
        {
            var json = "[{\"School\":\"UCO\",\"Degree\":\"BS\",\"StartDate\":\"2018-01-01\",\"EndDate\":\"2020-01-01\"}]";
            var handler = new FakeHandler(json);
            var http = new HttpClient(handler) { BaseAddress = new Uri("http://localhost") };
            IEducationService service = new EducationService(http);

            var result = await service.GetEducation();

            Assert.Single(result);
            Assert.Equal("UCO", result[0].School);
            Assert.Equal("BS", result[0].Degree);
        }

        private class FakeHandler : HttpMessageHandler
        {
            private readonly string response;

            public FakeHandler(string response)
            {
                this.response = response;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(response, Encoding.UTF8, "application/json")
                };
                return Task.FromResult(msg);
            }
        }
    }
}