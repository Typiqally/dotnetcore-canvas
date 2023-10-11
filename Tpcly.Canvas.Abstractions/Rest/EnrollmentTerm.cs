using System.Text.Json.Serialization;

namespace Tpcly.Canvas.Abstractions.Rest;

public record EnrollmentTerm(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("start_at")] DateTime? StartAt,
    [property: JsonPropertyName("end_at")] DateTime? EndAt
);