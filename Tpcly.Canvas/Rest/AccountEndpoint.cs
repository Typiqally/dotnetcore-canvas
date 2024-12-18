using System.Net.Http.Json;
using Tpcly.Canvas.Abstractions.Rest;

namespace Tpcly.Canvas.Rest;

public class AccountEndpoint : IAccountEndpoint
{
    private readonly HttpClient _client;

    public AccountEndpoint(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<EnrollmentTerm>?> GetTerms(int accountId, int limit = 100)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"v1/accounts/{accountId}/terms?per_page={limit}");
        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        
        var collection = await response.Content.ReadFromJsonAsync<EnrollmentTermCollection>();

        return collection?.Terms;
    }
    
    
    public async Task<IEnumerable<User>?> GetUsers(int accountId, string searchQuery)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"v1/accounts/{accountId}/users?search_term={searchQuery}");
        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        
        var collection = await response.Content.ReadFromJsonAsync<IEnumerable<User>>();

        return collection;
    }
}