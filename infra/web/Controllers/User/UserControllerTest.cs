using Application.UseCases.User.Commands.CreateUserCommand;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CleanArch.Controllers;

public class UserControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    HttpClient _client;

    public UserControllerTest(WebApplicationFactory<Program> webApplicationFactory)
    {
        _client = webApplicationFactory.CreateClient();
    }

    [Fact]
    public async Task CreateUser()
    {
        var createUserCommand = new CreateUserCommand("test name", "test@gmail.com", true, null, null);
        var response = await _client.PostAsJsonAsync("/api/user/", createUserCommand);
    }
}