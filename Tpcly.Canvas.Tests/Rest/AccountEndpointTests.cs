using System.Net;
using Moq;
using Moq.Contrib.HttpClient;
using NUnit.Framework;
using Tpcly.Canvas.Abstractions.Rest;
using Tpcly.Canvas.Rest;

namespace Tpcly.Canvas.Tests.Rest;

public class AccountEndpointTests
{
    [Test]
    public async Task Given_Authorized_When_GetTerms_Then_ReturnTerms()
    {
        // Arrange
        var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        var httpClientMock = httpMessageHandlerMock.CreateClient();
        httpClientMock.BaseAddress = new Uri("http://localhost/");

        var termMock = new EnrollmentTerm("test", DateTime.Now, DateTime.Now);
        
        httpMessageHandlerMock.SetupAnyRequest()
            .ReturnsJsonResponse(HttpStatusCode.OK, new EnrollmentTermCollection(new []
            {
                termMock,
                termMock,
            }));
        
        var accountEndpoint = new AccountEndpoint(httpClientMock);
        
        // Act
        var terms = await accountEndpoint.GetTerms(0);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(terms, Is.Not.Null);
            Assert.That(terms.Count(), Is.GreaterThanOrEqualTo(1));
        });
    }
    
    [Test]
    public async Task Given_UnAuthorized_When_GetTerms_Then_ThrowException()
    {
        // Arrange
        var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        var httpClientMock = httpMessageHandlerMock.CreateClient();
        httpClientMock.BaseAddress = new Uri("http://localhost/");
        
        httpMessageHandlerMock.SetupAnyRequest()
            .ReturnsResponse(HttpStatusCode.Unauthorized);
        
        var accountEndpoint = new AccountEndpoint(httpClientMock);
        
        // Act
        // Assert
        Assert.ThrowsAsync<HttpRequestException>(async () => await accountEndpoint.GetTerms(0));
    }
}