using System.Net;
using Moq;
using Moq.Contrib.HttpClient;
using NUnit.Framework;
using Tpcly.Canvas.Rest;

namespace Tpcly.Canvas.Tests.Rest;

public class FileEndpointTests
{
    [Test]
    public async Task When_GetByteArray_Then_ReturnByteArray()
    {
        // Arrange
        var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        var httpClientMock = httpMessageHandlerMock.CreateClient();

        var bytesMock = new byte[] { 0, 1, 2 };

        httpMessageHandlerMock.SetupAnyRequest()
            .ReturnsResponse(HttpStatusCode.OK, bytesMock);

        var fileEndpoint = new FileEndpoint(httpClientMock);

        // Act
        var bytes = await fileEndpoint.GetByteArray(new Uri("http://localhost/"));

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(bytes, Is.Not.Null);
            Assert.That(bytes, Is.EqualTo(bytesMock));
        });
        
        httpMessageHandlerMock.VerifyAnyRequest(Times.Exactly(1));
    }
    
    [Test]
    public async Task When_GetByteArrayIsUnauthorized_Then_ReturnNull()
    {
        // Arrange
        var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        var httpClientMock = httpMessageHandlerMock.CreateClient();

        httpMessageHandlerMock.SetupAnyRequest()
            .ReturnsResponse(HttpStatusCode.Unauthorized);

        var fileEndpoint = new FileEndpoint(httpClientMock);

        // Act
        Assert.ThrowsAsync<HttpRequestException>(async () => await fileEndpoint.GetByteArray(new Uri("http://localhost/")));
        
        // Assert
        httpMessageHandlerMock.VerifyAnyRequest(Times.Exactly(1));
    }
}