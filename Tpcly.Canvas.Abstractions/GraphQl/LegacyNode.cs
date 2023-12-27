using System.Text.Json.Serialization;

namespace Tpcly.Canvas.Abstractions.GraphQl;

public record LegacyNode(
    [property: JsonPropertyName("enrollments")] IEnumerable<Enrollment>? Enrollments
    );