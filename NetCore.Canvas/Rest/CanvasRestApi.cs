using NetCore.Canvas.Abstractions.Rest;

namespace NetCore.Canvas.Rest;

public class CanvasRestApi : ICanvasRestApi
{
    public CanvasRestApi(IAccountEndpoint accounts, IFileEndpoint files, IPageEndpoint pages)
    {
        Accounts = accounts;
        Files = files;
        Pages = pages;
    }

    public IAccountEndpoint Accounts { get; }
    public IFileEndpoint Files { get; }
    public IPageEndpoint Pages { get; }
}