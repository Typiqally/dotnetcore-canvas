using System.Text.Json.Serialization;

namespace Tpcly.Canvas.Abstractions.GraphQl;

public record Rubric(
    [property: JsonPropertyName("criteria")] IEnumerable<Criteria>? Criteria
);