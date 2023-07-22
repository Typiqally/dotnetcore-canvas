using System.Text.Json.Serialization;

namespace NetCore.Canvas.Abstractions.GraphQl;

public record Submission(
    [property: JsonPropertyName("postedAt")] DateTime? PostedAt,
    [property: JsonPropertyName("submittedAt")] DateTime? SubmittedAt,
    [property: JsonPropertyName("assignment")] Assignment? Assignment,
    [property: JsonPropertyName("submissionHistoriesConnection")] GraphQlConnection<SubmissionHistory>? SubmissionHistories,
    [property: JsonPropertyName("rubricAssessmentsConnection")] GraphQlConnection<RubricAssessment>? RubricAssessments
);