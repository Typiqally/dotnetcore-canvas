using System.Text.Json.Serialization;

namespace NetCore.Canvas.Abstractions.GraphQl;

public record AssessmentRating(
    [property: JsonPropertyName("criterion")] Criterion? Criterion,
    [property: JsonPropertyName("points")] double? Points
)
{
    public bool IsMastery => Points >= Criterion?.MasteryPoints;
}