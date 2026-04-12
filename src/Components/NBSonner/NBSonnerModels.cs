namespace NeoBrutalism.Blazor;

/// <summary>Visual variant for a toast notification.</summary>
public enum NBToastVariant
{
    /// <summary>Default variant.</summary>
    Default,
    /// <summary>Success variant.</summary>
    Success,
    /// <summary>Error variant.</summary>
    Error,
    /// <summary>Warning variant.</summary>
    Warning,
    /// <summary>Info variant.</summary>
    Info
}

/// <summary>Position where toasts are displayed.</summary>
public enum NBSonnerPosition
{
    /// <summary>Top-left corner.</summary>
    TopLeft,
    /// <summary>Top-right corner.</summary>
    TopRight,
    /// <summary>Top-center.</summary>
    TopCenter,
    /// <summary>Bottom-left corner.</summary>
    BottomLeft,
    /// <summary>Bottom-right corner.</summary>
    BottomRight,
    /// <summary>Bottom-center.</summary>
    BottomCenter
}

/// <summary>Represents a single toast notification.</summary>
public class NBToast
{
    /// <summary>Unique toast identifier.</summary>
    public Guid Id { get; init; } = Guid.NewGuid();
    /// <summary>Toast message text.</summary>
    public string Message { get; init; } = string.Empty;
    /// <summary>Optional description text.</summary>
    public string? Description { get; init; }
    /// <summary>Visual variant of the toast.</summary>
    public NBToastVariant Variant { get; init; } = NBToastVariant.Default;
    /// <summary>Duration in milliseconds before the toast auto-dismisses.</summary>
    public int DurationMs { get; init; } = 4000;
    internal bool IsClosing { get; set; }
}
