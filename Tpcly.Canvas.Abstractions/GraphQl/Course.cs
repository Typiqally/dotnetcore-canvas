using System.Text.Json.Serialization;

namespace Tpcly.Canvas.Abstractions.GraphQl;

public record Course(
    [property: JsonPropertyName("_id")] string? Id,
    [property: JsonPropertyName("name")] string? Name,
    [property: JsonPropertyName("term")] EnrollmentTerm? Term,
    [property: JsonPropertyName("submissionsConnection")] GraphQlConnection<Submission>? Submissions,
    [property: JsonPropertyName("enrollmentsConnection")] GraphQlConnection<Enrollment>? Enrollments
);