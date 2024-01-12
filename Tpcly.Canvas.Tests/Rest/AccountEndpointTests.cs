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
    public async Task When_GetTerms_Then_ReturnListOfTerms()
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
}