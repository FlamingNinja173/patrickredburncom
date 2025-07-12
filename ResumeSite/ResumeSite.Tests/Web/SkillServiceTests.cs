using ResumeSite.Web.Services;
using System.Net;
using System.Text;

namespace ResumeSite.Tests.Web
{
    public class SkillServiceTests
    {
        [Fact]
        public async Task GetSkills_ReturnsData()
        {
            var json = "[{\"Name\":\"C#\",\"Description\":\"Lang\",\"Proficiency\":4}]";
            var handler = new FakeHandler(json);
            var http = new HttpClient(handler) { BaseAddress = new Uri("http://localhost") };
            ISkillService service = new SkillService(http);

            var result = await service.GetSkills();

            Assert.Single(result);
            Assert.Equal("C#", result[0].Name);
            Assert.Equal(Constants.SkillProficiency.Expert, result[0].Proficiency);
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