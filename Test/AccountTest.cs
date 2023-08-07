using FluentAssertions;
using LibraryManagementSystem.Features.Auth;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Test
{
    public class AccountTest : IClassFixture<TestBase>
    {
        private readonly TestBase _base;

        public AccountTest(TestBase @base)
        {
            _base = @base;
        }

        [Fact]
        public async void Check_Account_Login()
        {
            
            var applicationFactory = new WebApplicationFactory<Program>();
            var client = applicationFactory.CreateClient();
            var request = new Login.Request
            {
                UserName = "admin",
                Password = "admin"
            };

            var stringContent = _base.GetStringContent(request);

            // Act, Action
            var response = await client.PostAsync("api/auth/login", stringContent);

            // (arrange)
            var result = await _base.GetResultAsync<Login.Response>(response);

            // Assert
            result.Should().NotBeNull();
            result?.AccessToken.Should().NotBeNull();
        }
    }
}
