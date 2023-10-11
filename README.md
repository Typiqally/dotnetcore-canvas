# .NET Core Canvas

An easy-to-use .NET Core compatible API interface for the Canvas Learning Management System (LMS)
from Instructure.

## Configuration

The easiest way to configure the .NET Core Canvas API is to use the standard dependency injection from Microsoft.
This process will be made easier in the future through the use of extensions. 

```csharp
// Add default HTTP client
const string canvasHttpClient = "CanvasHttpClient";

services.AddHttpClient(
    canvasHttpClient,
    static (provider, client) =>
    {
        client.BaseAddress = "https://canvas.instructure.com/api";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Token");
    });

// Add REST services
services.AddScoped<ICanvasRestApi, CanvasRestApi>();
services.AddHttpClient<IPageEndpoint, PageEndpoint>(canvasHttpClient);
services.AddHttpClient<IFileEndpoint, FileEndpoint>(canvasHttpClient);
services.AddHttpClient<IAccountEndpoint, AccountEndpoint>(canvasHttpClient);

// Add GraphQL services
services.AddHttpClient<ICanvasGraphQlApi, CanvasGraphQlApi>(canvasHttpClient);
```

## Contributors

<a href = "https://github.com/Typiqally/dotnetcore-canvas/graphs/contributors">
  <img src = "https://contrib.rocks/image?repo=Typiqally/dotnetcore-canvas"/>
</a>

## License

.NET Core Canvas is licensed under the terms of GPL v3. See [LICENSE](LICENSE) for details.