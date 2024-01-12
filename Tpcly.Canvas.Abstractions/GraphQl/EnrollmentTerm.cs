using System.Text.Json.Serialization;

namespace Tpcly.Canvas.Abstractions.GraphQl;

public record EnrollmentTerm(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("startAt")] DateTime? StartAt,
    [property: JsonPropertyName("endAt")] DateTime? EndAt
);