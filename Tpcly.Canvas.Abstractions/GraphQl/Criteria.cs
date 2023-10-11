using System.Text.Json.Serialization;

namespace Tpcly.Canvas.Abstractions.GraphQl;

public record Criteria(
    [property: JsonPropertyName("outcome")] Outcome? Outcome
);