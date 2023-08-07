using System.Net.Http.Headers;
using FluentAssertions;
using IdentityModel.Client;
using LibraryManagementSystem.Domain;
using LibraryManagementSystem.Features.Book;
using LibraryManagementSystem.Infrastructure.Token;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Test;

public class BookTest : IClassFixture<TestBase> // now, you can inherit another class if you want
{
    private readonly TestBase _base;

    public BookTest(TestBase @base)
    {
        _base = @base;
    }

    [Fact]
    public async void Check_Book_Create()
    {
        var applicationFactory = new WebApplicationFactory<Program>();
        var client = applicationFactory.CreateClient();
        var copyBookDto = new Create.CopyBookDto
        {
            ISBN = "12314555",
            PublisherId = new Guid("58fd4e76-6882-4b0e-82d1-c560e5da838a")
            

        };
        var bookDtos = new Create.BookDto
        {
            AuthorIds = new List<Guid>
            {
                new("10a5a0b7-ba46-46e7-a172-3d62f5f45dea")
                
            },
            BookTypeIds = new List<Guid>
            { 
                new("c350d8c3-bfb4-4165-a88a-4aec32c739f5")
            },
            CopyBookDtos = new List<Create.CopyBookDto>
            {
                copyBookDto
            },
            Name = "IntegrationTest",
            HasSeries = false,
            ReleaseDate = DateTime.UtcNow,
            SeriesNumber = 0

        };
        var request = new Create.Request
        {
            BookDtos = bookDtos,
        };
        var token = await _base.GetToken();
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("Authorization","Bearer " + token);
        var stringContent = _base.GetStringContent(request);
        var response = await client.PostAsync("api/book/create", stringContent);
        var result = await _base.GetResultAsync<Create.Response>(response);

        result.Should().NotBeNull();

    }
}