using System.Text.Json.Serialization;

namespace NetCore.Canvas.Abstractions.GraphQl;

public record Module(
    [property: JsonPropertyName("name")] string Name
);