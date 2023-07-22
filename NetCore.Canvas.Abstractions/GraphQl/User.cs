using System.Text.Json.Serialization;

namespace NetCore.Canvas.Abstractions.GraphQl;

public record User(
    [property: JsonPropertyName("_id")] string? LegacyId,
    [property: JsonPropertyName("name")] string? Name,
    [property: JsonPropertyName("avatarUrl")] Uri? AvatarUrl
);