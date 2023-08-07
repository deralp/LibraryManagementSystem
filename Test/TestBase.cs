using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text;
using LibraryManagementSystem.Features.Auth;
using LibraryManagementSystem.Infrastructure.Token;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Test
{
    public class TestBase 
    {
        public StringContent GetStringContent<TRequest>(TRequest request)
        {
            string stringRequest = JsonSerializer.Serialize(request);
            return new StringContent(stringRequest, Encoding.UTF8, "application/json");
        }

        public async Task<TResponse?> GetResultAsync<TResponse>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<TResponse>(stringResponse, options);
        }

        public async Task<string> GetToken()
        {
            var applicationFactory = new WebApplicationFactory<Program>();
            var client = applicationFactory.CreateClient();
            var request = new Login.Request
            {
                UserName = "admin",
                Password = "admin"
            };

            var stringContent = GetStringContent(request);
            var response = await client.PostAsync("api/auth/login", stringContent);
            var result = await GetResultAsync<Login.Response>(response);
            return result.AccessToken.AccsessToken;
        }

    }
}