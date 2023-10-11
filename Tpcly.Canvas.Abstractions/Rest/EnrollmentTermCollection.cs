using System.Text.Json.Serialization;

namespace Tpcly.Canvas.Abstractions.Rest;

public record EnrollmentTermCollection(
    [property: JsonPropertyName("enrollment_terms")] IEnumerable<EnrollmentTerm> Terms
);