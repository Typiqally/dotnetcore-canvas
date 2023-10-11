using System.Text.Json.Serialization;

namespace Tpcly.Canvas.Abstractions.GraphQl;

public record GraphQlConnection<TNode>(
    [property: JsonPropertyName("nodes")] IReadOnlyList<TNode> Nodes
);