using System.Net;
using System.Text;

namespace ResumeSite.Tests
{
    public class CertificationServiceTests
    {
        [Fact]
        public async Task GetCertifications_ReturnsData()
        {
            var json = "[{\"Name\":\"Test\",\"Issuer\":\"Issuer\",\"DateEarned\":\"2024-01-01\",\"ImageUrl\":\"url\",\"CredentialUrl\":\"cred\"}]";
            var handler = new FakeHandler(json);
            var http = new HttpClient(handler) { BaseAddress = new Uri("http://localhost") };
            var service = new CertificationService(http);

            var result = await service.GetCertifications();

            Assert.Single(result);
            Assert.Equal("Test", result[0].Name);
            Assert.Equal("cred", result[0].CredentialUrl);
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
