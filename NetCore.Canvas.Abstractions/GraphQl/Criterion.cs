using System.Text.Json.Serialization;

namespace NetCore.Canvas.Abstractions.GraphQl;

public record Criterion(
    [property: JsonPropertyName("masteryPoints")] double? MasteryPoints,
    [property: JsonPropertyName("outcome")] Outcome? Outcome
);