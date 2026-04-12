namespace NeoBrutalism.Blazor;

/// <summary>Represents a single item in an <see cref="NBBreadcrumb"/>.</summary>
/// <param name="Label">Display text for the breadcrumb link.</param>
/// <param name="Href">Optional navigation URL. When <c>null</c> the item is rendered as plain text.</param>
public record NBBreadcrumbItem(string Label, string? Href = null);
