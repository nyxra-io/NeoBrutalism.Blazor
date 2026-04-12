namespace NeoBrutalism.Blazor;

/// <summary>Visual variant of an <see cref="NBButton"/>.</summary>
public enum NBButtonVariant
{
    /// <summary>Primary color background with shadow; hover shifts into shadow.</summary>
    Default,
    /// <summary>White background with shadow; hover shifts into shadow.</summary>
    Neutral,
    /// <summary>Primary color, no shadow at rest; shadow appears on hover.</summary>
    Reverse,
    /// <summary>Primary color, no shadow ever.</summary>
    NoShadow,
    /// <summary>Danger (red) variant.</summary>
    Danger,
    /// <summary>Success (green) variant.</summary>
    Success
}

/// <summary>Size of an <see cref="NBButton"/>.</summary>
public enum NBButtonSize
{
    /// <summary>Normal size (default).</summary>
    Normal,
    /// <summary>Small size with reduced padding.</summary>
    Small,
    /// <summary>Large size with increased padding.</summary>
    Large,
    /// <summary>Icon-only square button.</summary>
    Icon
}
