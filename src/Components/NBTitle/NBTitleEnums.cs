namespace NeoBrutalism.Blazor;

/// <summary>Semantic variant rendered by an <see cref="NBTitle"/>.</summary>
public enum NBTitleVariant
{
    /// <summary>Primary page title. Renders an <c>&lt;h1&gt;</c>.</summary>
    Title,
    /// <summary>Descriptive subtitle below the title. Renders a <c>&lt;p&gt;</c>.</summary>
    Subtitle,
    /// <summary>Section divider heading. Renders an <c>&lt;h2&gt;</c>.</summary>
    Section,
    /// <summary>Sub-section heading. Renders an <c>&lt;h3&gt;</c>.</summary>
    SubSection
}
