using System.Text.Json.Serialization;

namespace NetCore.Canvas.Abstractions.GraphQl;

public record GraphQlConnection<TNode>(
    [property: JsonPropertyName("nodes")] IReadOnlyList<TNode> Nodes
);