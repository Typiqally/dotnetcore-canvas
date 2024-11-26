using System.Text.Json.Serialization;

namespace Tpcly.Canvas.Abstractions.Rest;

public record User(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("login_id")] string LoginId
);