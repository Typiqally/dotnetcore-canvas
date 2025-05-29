namespace Tpcly.Canvas.Abstractions.Rest;

public interface ICanvasRestApi
{
    public IAccountEndpoint Accounts { get; }

    public IFileEndpoint Files { get; }

    public IPageEndpoint Pages { get; }

    public Task<HttpResponseMessage> Request(HttpMethod method, string path, HttpContent? body);

}