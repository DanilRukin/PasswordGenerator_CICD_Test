using PasswordGeneratorCICD.Api;
using PasswordGeneratorCICD.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorCICD.IntegrationTests.ApiControllers
{
    public class PasswordGeneratorControllerTests : IClassFixture<CustomWebApplicationFactory<WebMarker>>
    {
        private HttpClient _httpClient;
        private CustomWebApplicationFactory<WebMarker> _factory;
        private static string _api = "api/PasswordGenerator";

        public PasswordGeneratorControllerTests(CustomWebApplicationFactory<WebMarker> factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task CreatePassword_PasswordCreated_ReturnsOkStatusCode()
        {
            PasswordOptionsDto options = new()
            {
                Length = 8, CountOfCharacters = 5, CountOfNumbers = 3, LowerCaseOnly = false, UpperCaseOnly = false
            };
            var response = await _httpClient.PostAsJsonAsync(Post.CreatePassword(), options);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Assert.NotNull(result);
            Assert.Equal(options.Length, result.Length);
        }

        [Fact]
        public async Task CreatePassword_InavalidOptions_ReturnsBadRequestStatusCodeWithMessage()
        {
            PasswordOptionsDto options = new()
            {
                Length = 4,
                CountOfCharacters = 5,
                CountOfNumbers = 3,
                LowerCaseOnly = false,
                UpperCaseOnly = false
            };
            
            string message = $"It is not possible to set the length ({options.Length}) less than the sum of the" +
                    $" number of digits ({options.CountOfNumbers}), the number of characters ({options.CountOfCharacters}) and" +
                    $" the number of special characters ({(options.SpecialSymbols == null ? 0 : options.SpecialSymbols.Count)})";
            var response = await _httpClient.PostAsJsonAsync(Post.CreatePassword(), options);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            var result = await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(message, result.First());
        }

        private static class Post
        {
            internal static string CreatePassword() => $"{_api}";
        }
    }
}
