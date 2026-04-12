namespace NeoBrutalism.Blazor;

/// <summary>Represents a single option inside an <see cref="NBRadioGroup"/>.</summary>
/// <param name="Value">The value submitted when this option is selected.</param>
/// <param name="Label">Display text shown next to the radio button.</param>
/// <param name="Disabled">Whether this option is disabled.</param>
public record NBRadioOption(string Value, string Label, bool Disabled = false);
