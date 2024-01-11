using System.Net.Http.Json;
using Tpcly.Canvas.Abstractions.GraphQl;

namespace Tpcly.Canvas.GraphQl;

public class CanvasGraphQlApi : ICanvasGraphQlApi
{
    private readonly HttpClient _client;

    public CanvasGraphQlApi(HttpClient client)
    {
        _client = client;
    }

    public async Task<GraphQlSchema?> Query(string query, IDictionary<string, object>? variables = null)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "/api/graphql")
        {
            Content = JsonContent.Create(new GraphQlQuery(query, variables)),
        };

        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var queryResponse = await response.Content.ReadFromJsonAsync<GraphQlQueryResponse>();
        return queryResponse?.Data;
    }
}