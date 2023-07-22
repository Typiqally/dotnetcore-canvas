using System.Text.Json.Serialization;

namespace NetCore.Canvas.Abstractions.GraphQl;

public record GraphQlSchema(
    [property: JsonPropertyName("allCourses")] IEnumerable<Course>? Courses,
    [property: JsonPropertyName("course")] Course? Course
);