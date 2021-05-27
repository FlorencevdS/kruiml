using Newtonsoft.Json;
using Repository.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Xunit;

namespace IntegrationTests
{
    public class RecipeControllerIntegrationTest : IClassFixture<CustomWebApplicationFactory<recipe_read_service.Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<recipe_read_service.Startup> _factory;

        public RecipeControllerIntegrationTest(CustomWebApplicationFactory<recipe_read_service.Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async void Test_Get_All_Recipes()
        {
            var response = await _client.GetAsync("https://localhost:8081/recipe");
            var content = await response.Content.ReadAsStringAsync();

            var recipe = JsonConvert.DeserializeObject<List<Recipe>>(content);

            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal("Hummus", recipe[0].Title);
        }

        [Fact]
        public async void Test_Get_Recipe_By_Id()
        {
            var response = await _client.GetAsync("https://localhost:8081/recipe/1");
            var content = await response.Content.ReadAsStringAsync();

            var recipe = JsonConvert.DeserializeObject<Recipe>(content);

            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal("Hummus", recipe.Title);
        }
    }
}
