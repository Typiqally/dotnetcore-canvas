using System.Text.Json.Serialization;

namespace NetCore.Canvas.Abstractions.GraphQl;

public record Rubric(
    [property: JsonPropertyName("criteria")] IEnumerable<Criteria>? Criteria
);