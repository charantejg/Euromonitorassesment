using Ecommerce.Core.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Ecommerce.IntegrationTests
{
    public class HttpTests : IClassFixture<AppTestFixture>, IDisposable
    {
        readonly AppTestFixture _fixture;
        readonly HttpClient _client;

        public HttpTests(AppTestFixture fixture, ITestOutputHelper output)
        {
            _fixture = fixture;
            fixture.Output = output;
            _client = fixture.CreateClient();
        }

        public void Dispose() => _fixture.Output = null;

        
        [Theory]
        [InlineData("/api/User/GetAllUsers")]
        public async Task CanCallApi(string apiPath)
        {
           
            var result = await _client.GetAsync(apiPath);

            result.EnsureSuccessStatusCode();

            //var content = await result.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task LoginTest_WhenCalled_ReturnToken()
        {
            var loginUser = new LoginUser
            {
                Email = "test1@gmail.com",
                Password = "Test"
            };
            var myContent = JsonConvert.SerializeObject(loginUser);

            var content = new StringContent(myContent, Encoding.UTF8, "application/json");
            var result = await _client.PostAsync("/api/User/Login", content);


            result.EnsureSuccessStatusCode();

            var contentText = await result.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
