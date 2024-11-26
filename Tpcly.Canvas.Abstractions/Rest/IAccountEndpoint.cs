namespace Tpcly.Canvas.Abstractions.Rest;

public interface IAccountEndpoint
{
    public Task<IEnumerable<EnrollmentTerm>?> GetTerms(int accountId, int limit = 100);
    public Task<IEnumerable<User>?> GetUsers(int accountId, string searchQuery);
}