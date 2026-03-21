using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

public class TestEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TestEndpointTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GET_test_should_return_200()
    {
        var response = await _client.GetAsync("/test");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}