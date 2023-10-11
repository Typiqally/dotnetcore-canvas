using System.Text.Json.Serialization;

namespace Tpcly.Canvas.GraphQl;

public record GraphQlQuery(
    [property: JsonPropertyName("query")] string Query,
    [property: JsonPropertyName("variables")] IDictionary<string, object>? Variables
);