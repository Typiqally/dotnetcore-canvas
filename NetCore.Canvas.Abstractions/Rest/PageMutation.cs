using System.Text.Json.Serialization;

namespace NetCore.Canvas.Abstractions.Rest;

public record PageMutation(
    [property: JsonPropertyName("wiki_page")] Page? Page
);