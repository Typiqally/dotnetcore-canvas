using System.Text.Json.Serialization;

namespace NetCore.Canvas.Abstractions.GraphQl;

public record Criteria(
    [property: JsonPropertyName("outcome")] Outcome? Outcome
);