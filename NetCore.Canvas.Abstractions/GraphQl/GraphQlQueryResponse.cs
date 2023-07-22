using System.Text.Json.Serialization;

namespace NetCore.Canvas.Abstractions.GraphQl;

public record GraphQlQueryResponse(
    [property: JsonPropertyName("data")] GraphQlSchema? Data
);