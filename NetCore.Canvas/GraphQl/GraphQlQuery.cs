using System.Text.Json.Serialization;

namespace NetCore.Canvas.GraphQl;

public record GraphQlQuery(
    [property: JsonPropertyName("query")] string Query,
    [property: JsonPropertyName("variables")] IDictionary<string, object>? Variables
);