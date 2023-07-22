using System.Text.Json.Serialization;

namespace NetCore.Canvas.Abstractions.GraphQl;

public record SubmissionHistory(
    [property: JsonPropertyName("attempt")] int? Attempt,
    [property: JsonPropertyName("submittedAt")] DateTime? SubmittedAt,
    [property: JsonPropertyName("assignment")] Assignment? Assignment,
    [property: JsonPropertyName("rubricAssessmentsConnection")] GraphQlConnection<RubricAssessment>? RubricAssessments
);