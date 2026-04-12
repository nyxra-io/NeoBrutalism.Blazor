using Microsoft.AspNetCore.Components;

namespace NeoBrutalism.Blazor;

/// <summary>Represents a single tab inside an <see cref="NBTabs"/> component.</summary>
/// <param name="Key">Unique identifier for the tab.</param>
/// <param name="Label">Display text shown on the tab header.</param>
/// <param name="Content">Content rendered when the tab is active.</param>
public record NBTabItem(string Key, string Label, RenderFragment Content);
