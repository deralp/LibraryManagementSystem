using System.Net.Http;
using System.Net.Http.Headers;
using FluentAssertions;
using IdentityModel.Client;
using LibraryManagementSystem.Domain;
using LibraryManagementSystem.Features;
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
        var bookDto = new Create.BookDto
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
            BookDto = bookDto,
        };

        var token = await _base.GetToken();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        var stringContent = _base.GetStringContent(request);
        var response = await client.PostAsync("api/book/create", stringContent);
        var result = await _base.GetResultAsync<Create.Response>(response);

        result.Should().NotBeNull();
        result!.Success.Should().BeTrue();
    }

    [Fact]
    public async void Check_Books_Get()
    {
        var applicationFactory = new WebApplicationFactory<Program>();
        var client = applicationFactory.CreateClient();

        var token = await _base.GetToken();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        var response = await client.GetAsync("api/book/get");
        var result = await _base.GetResultAsync<Get.Response>(response);

        result.Should().NotBeNull();
    }

    [Fact]
    public async void Check_Book_Update()
    {
        var applicationFactory = new WebApplicationFactory<Program>();
        var client = applicationFactory.CreateClient();

        var copyBookDto = new Create.CopyBookDto
        {
            ISBN = "12314555",
            PublisherId = new Guid("58fd4e76-6882-4b0e-82d1-c560e5da838a")
        };
        var bookDto = new Create.BookDto
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
        var requestCreate = new Create.Request
        {
            BookDto = bookDto,
        };

        var token = await _base.GetToken();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        var stringContentCreate = _base.GetStringContent(requestCreate);
        var responseCreate = await client.PostAsync("api/book/create", stringContentCreate);
        var resultCreate = await _base.GetResultAsync<Create.Response>(responseCreate);

        var copyBookDtoForUpdate = new Update.CopyBookDto
        {
            ISBN = "12314555",
            PublisherId = new Guid("58fd4e76-6882-4b0e-82d1-c560e5da838a")
        };
        var bookDtoForUpdate = new Update.BookDto
        {
            AuthorIds = new List<Guid>
            {
                new("10a5a0b7-ba46-46e7-a172-3d62f5f45dea")
            },
            BookTypeIds = new List<Guid>
            {
                new("c350d8c3-bfb4-4165-a88a-4aec32c739f5")
            },
            CopyBookDtos = new List<Update.CopyBookDto>
            {
                copyBookDtoForUpdate
            },
            Name = "IntegrationTestUpdated",
            HasSeries = false,
            ReleaseDate = DateTime.UtcNow,
            SeriesNumber = 0,
            Id = resultCreate!.Id
        };
        var requestForUpdate = new Update.Request
        {
            BookDto = bookDtoForUpdate,
        };
        
        var stringContentForUpdate = _base.GetStringContent(requestForUpdate);
        var responseUpdate = await client.PostAsync("api/book/update", stringContentForUpdate);
        var resultForUpdate = await _base.GetResultAsync<Update.Response>(responseUpdate);


        resultForUpdate.Should().NotBeNull();
        resultForUpdate!.Success.Should().BeTrue();
    }
}