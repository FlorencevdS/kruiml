using System.Net;
using System.Net.Http;
using Xunit;

namespace IntegrationTests
{
    public class RecipeControllerIntegrationTest
    {
        [Fact]
        public async void Test_Get_All()
        {
            var httpclient = new HttpClient();
            var response = await httpclient.GetAsync("https://localhost:8081/recipe");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
