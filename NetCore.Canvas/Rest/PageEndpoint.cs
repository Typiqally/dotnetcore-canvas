using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using NetCore.Canvas.Abstractions.Rest;

namespace NetCore.Canvas.Rest;

public class PageEndpoint : IPageEndpoint
{
    private static readonly JsonSerializerOptions s_serializerOptions = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault, };

    private readonly HttpClient _client;

    public PageEndpoint(HttpClient client)
    {
        _client = client;
    }

    public async Task<Page?> GetPage(int courseId, string id)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"v1/courses/{courseId}/pages/{id}");
        using var response = await _client.SendAsync(request);

        return response.StatusCode == HttpStatusCode.OK
            ? await response.Content.ReadFromJsonAsync<Page>()
            : null;
    }

    public async Task<IEnumerable<Page>?> GetAll(int courseId, IEnumerable<string> include)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"v1/courses/{courseId}/pages");
        using var response = await _client.SendAsync(request);

        return response.StatusCode == HttpStatusCode.OK
            ? await response.Content.ReadFromJsonAsync<IEnumerable<Page>>()
            : null;
    }

    public async Task<Page?> CreatePage(int courseId, Page page)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, $"v1/courses/{courseId}/pages")
        {
            Content = JsonContent.Create(new PageMutation(page), options: s_serializerOptions),
        };

        using var response = await _client.SendAsync(request);

        return response.StatusCode == HttpStatusCode.OK
            ? await response.Content.ReadFromJsonAsync<Page?>()
            : null;
    }

    public async Task<Page?> UpdatePage(int courseId, Page page)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, $"v1/courses/{courseId}/pages/{page.Id}")
        {
            Content = JsonContent.Create(new PageMutation(page), options: s_serializerOptions),
        };

        using var response = await _client.SendAsync(request);

        return response.StatusCode == HttpStatusCode.OK
            ? await response.Content.ReadFromJsonAsync<Page?>()
            : null;
    }

    public async Task<Page?> UpdateOrCreatePage(int courseId, Page page)
    {
        var existingPage = await GetPage(courseId, page.Id);

        if (existingPage == null)
        {
            return await CreatePage(courseId, page);
        }

        return await UpdatePage(courseId, page);
    }
}