using Tpcly.Canvas.Abstractions.Rest;

namespace Tpcly.Canvas.Rest;

public class CanvasRestApi : ICanvasRestApi
{
    public CanvasRestApi(IAccountEndpoint accounts, IFileEndpoint files, IPageEndpoint pages, HttpClient client)
    {
        Accounts = accounts;
        Files = files;
        Pages = pages;
        _client = client;
    }
    
    private readonly HttpClient _client;

    public IAccountEndpoint Accounts { get; }
    public IFileEndpoint Files { get; }
    public IPageEndpoint Pages { get; }

    public async Task<HttpResponseMessage> Request(HttpMethod method, string path, HttpContent? body)
    {
        using var request = new HttpRequestMessage(method, path);
        request.Content = body;
        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return response;
    }
}