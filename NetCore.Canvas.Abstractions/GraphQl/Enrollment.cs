using System.Text.Json.Serialization;

namespace NetCore.Canvas.Abstractions.GraphQl;

public record Enrollment(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("user")] User User
);