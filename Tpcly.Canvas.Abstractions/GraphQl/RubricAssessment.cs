using System.Text.Json.Serialization;

namespace Tpcly.Canvas.Abstractions.GraphQl;

public record RubricAssessment(
    [property: JsonPropertyName("assessmentRatings")] IReadOnlyList<AssessmentRating?>? AssessmentRatings
);