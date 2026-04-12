namespace NeoBrutalism.Blazor;

/// <summary>Side on which the sidebar appears.</summary>
public enum NBSidebarSide
{
    /// <summary>Left side.</summary>
    Left,
    /// <summary>Right side.</summary>
    Right
}

/// <summary>Visual variant for the sidebar.</summary>
public enum NBSidebarVariant
{
    /// <summary>Default sidebar variant.</summary>
    Sidebar,
    /// <summary>Floating sidebar variant.</summary>
    Floating,
    /// <summary>Inset sidebar variant.</summary>
    Inset
}

/// <summary>How the sidebar collapses.</summary>
public enum NBSidebarCollapsible
{
    /// <summary>Offcanvas collapse mode.</summary>
    Offcanvas,
    /// <summary>Icon-only collapse mode.</summary>
    Icon,
    /// <summary>No collapse.</summary>
    None
}
