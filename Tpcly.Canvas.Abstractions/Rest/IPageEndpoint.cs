namespace Tpcly.Canvas.Abstractions.Rest;

public interface IPageEndpoint
{
    Task<Page?> GetPage(int courseId, string id);
    
    Task<IEnumerable<Page>?> GetAll(int courseId, IEnumerable<string> include);

    Task<Page?> CreatePage(int courseId, Page page);

    Task<Page?> UpdatePage(int courseId, Page page);
    
    Task<Page?> UpdateOrCreatePage(int courseId, Page page);
}