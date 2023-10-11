using System.Text.Json.Serialization;

namespace Tpcly.Canvas.Abstractions.GraphQl;

public record Enrollment(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("user")] User User
);