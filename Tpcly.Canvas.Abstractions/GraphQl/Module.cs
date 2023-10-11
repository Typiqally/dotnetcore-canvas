using System.Text.Json.Serialization;

namespace Tpcly.Canvas.Abstractions.GraphQl;

public record Module(
    [property: JsonPropertyName("name")] string Name
);