using System.Text.Json.Serialization;

namespace Tpcly.Canvas.Abstractions.GraphQl;

public record Outcome(
    [property: JsonPropertyName("_id")] int Id,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("masteryPoints")] double? MasteryPoints
);