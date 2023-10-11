using System.Text.Json.Serialization;

namespace Tpcly.Canvas.Abstractions.GraphQl;

public record GraphQlQueryResponse(
    [property: JsonPropertyName("data")] GraphQlSchema? Data
);