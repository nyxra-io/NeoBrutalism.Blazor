namespace NeoBrutalism.Blazor;

/// <summary>Represents a group of selectable items in an <see cref="NBCommand"/> component.</summary>
/// <param name="Heading">Group heading displayed above the items.</param>
/// <param name="Items">The items in this group.</param>
public record NBCommandGroup(string Heading, IReadOnlyList<NBCommandItem> Items);

/// <summary>Represents a single item in an <see cref="NBCommand"/> component.</summary>
/// <param name="Label">Display text for the item.</param>
/// <param name="Value">Unique value used for selection and filtering.</param>
/// <param name="Shortcut">Optional keyboard shortcut hint.</param>
/// <param name="Disabled">Whether the item is disabled.</param>
public record NBCommandItem(string Label, string Value, string? Shortcut = null, bool Disabled = false);
