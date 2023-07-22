using System.Text.Json.Serialization;

namespace NetCore.Canvas.Abstractions.GraphQl;

public record RubricAssessment(
    [property: JsonPropertyName("assessmentRatings")] IReadOnlyList<AssessmentRating?>? AssessmentRatings
);