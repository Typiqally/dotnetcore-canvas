using System.Net;
using Moq;
using Moq.Contrib.HttpClient;
using NUnit.Framework;
using Tpcly.Canvas.Abstractions.Rest;
using Tpcly.Canvas.Rest;

namespace Tpcly.Canvas.Tests.Rest;

public class PageEndpointTests
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
    public async Task When_GetAllPages_Then_ReturnAllPages()
    {
        // Arrange
        var pageMock = new Page("0") { Body = "test" };
        var pagesMock = new[] { pageMock, pageMock };

        _httpMessageHandlerMock.SetupRequest(HttpMethod.Get, static _ => true)
            .ReturnsJsonResponse(HttpStatusCode.OK, pagesMock);

        var pageEndpoint = new PageEndpoint(_httpClientMock);

        // Act
        var pages = await pageEndpoint.GetAll(0, Array.Empty<string>());

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(pages, Is.Not.Null);
            Assert.That(pages, Is.EqualTo(pagesMock));
        });

        _httpMessageHandlerMock.VerifyAnyRequest(Times.Exactly(1));
    }
    
    [Test]
    public async Task When_GetPageById_Then_ReturnPage()
    {
        // Arrange
        var pageMock = new Page("0") { Body = "test" };

        _httpMessageHandlerMock.SetupRequest(HttpMethod.Get, static _ => true)
            .ReturnsJsonResponse(HttpStatusCode.OK, pageMock);

        var pageEndpoint = new PageEndpoint(_httpClientMock);

        // Act
        var page = await pageEndpoint.GetPage(0, "0");

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(page, Is.Not.Null);
            Assert.That(page, Is.EqualTo(pageMock));
        });

        _httpMessageHandlerMock.VerifyAnyRequest(Times.Exactly(1));
    }
    
    [Test]
    public async Task When_CreatePage_Then_ReturnCreatedPage()
    {
        // Arrange
        var pageMock = new Page("0") { Body = "test" };
        
        _httpMessageHandlerMock.SetupRequest(HttpMethod.Post, static _ => true)
            .ReturnsJsonResponse(HttpStatusCode.Created, pageMock);

        var pageEndpoint = new PageEndpoint(_httpClientMock);

        // Act
        var page = await pageEndpoint.CreatePage(0, pageMock);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(page, Is.Not.Null);
            Assert.That(page, Is.EqualTo(pageMock));
        });

        _httpMessageHandlerMock.VerifyAnyRequest(Times.Exactly(1));
    }
    
    [Test]
    public async Task Given_PageExists_When_UpdateOrCreatePage_Then_ReturnUpdatedPage()
    {
        // Arrange
        var pageMock = new Page("0") { Body = "test" };

        _httpMessageHandlerMock.SetupRequest(HttpMethod.Get, static _ => true)
            .ReturnsJsonResponse(HttpStatusCode.OK, pageMock);
        
        _httpMessageHandlerMock.SetupRequest(HttpMethod.Put, static _ => true)
            .ReturnsJsonResponse(HttpStatusCode.OK, pageMock);
        
        _httpMessageHandlerMock.SetupRequest(HttpMethod.Post, static _ => true)
            .ReturnsJsonResponse(HttpStatusCode.OK, pageMock);

        var pageEndpoint = new PageEndpoint(_httpClientMock);

        // Act
        var page = await pageEndpoint.UpdateOrCreatePage(0, pageMock);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(page, Is.Not.Null);
            Assert.That(page, Is.EqualTo(pageMock));
        });

        _httpMessageHandlerMock.VerifyRequest(HttpMethod.Get, static _ => true, Times.Exactly(1));
        _httpMessageHandlerMock.VerifyRequest(HttpMethod.Put, static _ => true, Times.Exactly(1));
        _httpMessageHandlerMock.VerifyRequest(HttpMethod.Post, static _ => true, Times.Exactly(0));
    }
    
    [Test]
    public async Task Given_PageDoesntExist_When_UpdateOrCreatePage_Then_ReturnCreatedPage()
    {
        // Arrange
        var pageMock = new Page("0") { Body = "test" };

        _httpMessageHandlerMock.SetupRequest(HttpMethod.Get, static _ => true)
            .ReturnsResponse(HttpStatusCode.NotFound);
        
        _httpMessageHandlerMock.SetupRequest(HttpMethod.Put, static _ => true)
            .ReturnsJsonResponse(HttpStatusCode.OK, pageMock);
        
        _httpMessageHandlerMock.SetupRequest(HttpMethod.Post, static _ => true)
            .ReturnsJsonResponse(HttpStatusCode.OK, pageMock);

        var pageEndpoint = new PageEndpoint(_httpClientMock);

        // Act
        var page = await pageEndpoint.UpdateOrCreatePage(0, pageMock);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(page, Is.Not.Null);
            Assert.That(page, Is.EqualTo(pageMock));
        });

        _httpMessageHandlerMock.VerifyRequest(HttpMethod.Get, static _ => true, Times.Exactly(1));
        _httpMessageHandlerMock.VerifyRequest(HttpMethod.Put, static _ => true, Times.Exactly(0));
        _httpMessageHandlerMock.VerifyRequest(HttpMethod.Post, static _ => true, Times.Exactly(1));
    }
}