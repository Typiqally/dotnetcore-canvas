using Tpcly.Canvas.Abstractions.Rest;

namespace Tpcly.Canvas.Rest;

public class FileEndpoint : IFileEndpoint
{
    private readonly HttpClient _client;

    public FileEndpoint(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<byte>?> GetByteArray(Uri url)
    {
        return await _client.GetByteArrayAsync(url);
    }
}