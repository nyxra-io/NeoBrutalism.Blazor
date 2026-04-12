namespace NeoBrutalism.Blazor;

/// <summary>Represents a selectable option inside an <see cref="NBSelect"/> component.</summary>
public class NBSelectOption
{
    /// <summary>Initializes a new <see cref="NBSelectOption"/>.</summary>
    public NBSelectOption() { }

    /// <summary>Initializes a new <see cref="NBSelectOption"/> with the given value and label.</summary>
    /// <param name="value">Option value.</param>
    /// <param name="label">Display text.</param>
    public NBSelectOption(string value, string label)
    {
        Value = value;
        Label = label;
    }

    /// <summary>The value submitted when this option is selected.</summary>
    public string Value { get; set; } = string.Empty;
    /// <summary>The display text shown in the dropdown.</summary>
    public string Label { get; set; } = string.Empty;
}
