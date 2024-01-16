using System.Net;
using System.Text.Json;
using Moq;
using Moq.Contrib.HttpClient;
using NUnit.Framework;
using Tpcly.Canvas.Abstractions.GraphQl;
using Tpcly.Canvas.GraphQl;

namespace Tpcly.Canvas.Tests.GraphQl;

public class CanvasGraphQlApiTests
{
    private Mock<HttpMessageHandler> _httpMessageHandlerMock = null!;
    private HttpClient _httpClientMock = null!;

    [SetUp]
    public void Setup()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        _httpClientMock = _httpMessageHandlerMock.CreateClient();
        _httpClientMock.BaseAddress = new Uri("http://localhost/");
    }

    [Test]
    public async Task Given_AuthorizedAndQueryValid_When_QueryIsSuccessful_Then_ReturnRequestedData()
    {
        // Arrange
        var courseMock = new Course("test_course", null, null, null, null);

        _httpMessageHandlerMock.SetupAnyRequest()
            .ReturnsJsonResponse(HttpStatusCode.OK, new GraphQlQueryResponse(
                new GraphQlSchema(
                    new[] { courseMock },
                    courseMock,
                    null
                )
            ));

        var api = new CanvasGraphQlApi(_httpClientMock);

        // Act
        var result = await api.Query("test");

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Courses.Count(), Is.GreaterThanOrEqualTo(1));
            Assert.That(courseMock, Is.EqualTo(result.Course));
        });

        _httpMessageHandlerMock.VerifyAnyRequest(Times.Exactly(1));
    }

    [Test]
    public async Task Given_UnauthorizedAndQueryValid_When_Query_Then_ReturnNull()
    {
        // Arrange
        _httpMessageHandlerMock.SetupAnyRequest()
            .ReturnsResponse(HttpStatusCode.Unauthorized);

        var api = new CanvasGraphQlApi(_httpClientMock);

        // Act
        Assert.ThrowsAsync<HttpRequestException>(async () => await api.Query("test"));

        // Assert
        _httpMessageHandlerMock.VerifyAnyRequest(Times.Exactly(1));
    }

    [Test]
    public async Task Given_AuthorizedAndQueryValid_When_QueryHasUnknownData_Then_ReturnNull()
    {
        // Arrange
        _httpMessageHandlerMock.SetupAnyRequest()
            .ReturnsResponse(HttpStatusCode.OK);

        var api = new CanvasGraphQlApi(_httpClientMock);

        // Act
        Assert.ThrowsAsync<JsonException>(async () => await api.Query("test"));

        // Assert
        _httpMessageHandlerMock.VerifyAnyRequest(Times.Exactly(1));
    }
}