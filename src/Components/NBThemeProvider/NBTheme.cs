namespace NeoBrutalism.Blazor;

/// <summary>
/// Defines the customizable design tokens for Neo Brutalism components.
/// Only non-null properties will override the defaults from nb-design-system.css.
/// </summary>
public class NBTheme
{
    /// <summary>Black color token (<c>--nb-black</c>).</summary>
    public string? Black { get; set; }
    /// <summary>White color token (<c>--nb-white</c>).</summary>
    public string? White { get; set; }
    /// <summary>Background color token (<c>--nb-bg</c>).</summary>
    public string? Background { get; set; }
    /// <summary>Dark background color token (<c>--nb-bg-dark</c>).</summary>
    public string? BackgroundDark { get; set; }
    /// <summary>Primary color token (<c>--nb-primary</c>).</summary>
    public string? Primary { get; set; }
    /// <summary>Primary hover color token (<c>--nb-primary-hover</c>).</summary>
    public string? PrimaryHover { get; set; }
    /// <summary>Danger color token (<c>--nb-danger</c>).</summary>
    public string? Danger { get; set; }
    /// <summary>Danger hover color token (<c>--nb-danger-hover</c>).</summary>
    public string? DangerHover { get; set; }
    /// <summary>Success color token (<c>--nb-success</c>).</summary>
    public string? Success { get; set; }
    /// <summary>Muted color token (<c>--nb-muted</c>).</summary>
    public string? Muted { get; set; }
    /// <summary>Border style token (<c>--nb-border</c>).</summary>
    public string? Border { get; set; }
    /// <summary>Shadow token (<c>--nb-shadow</c>).</summary>
    public string? Shadow { get; set; }
    /// <summary>Small shadow token (<c>--nb-shadow-sm</c>).</summary>
    public string? ShadowSm { get; set; }
    /// <summary>Border radius token (<c>--nb-radius</c>).</summary>
    public string? Radius { get; set; }
    /// <summary>Font family token (<c>--nb-font</c>).</summary>
    public string? Font { get; set; }

    internal string ToCssVariables()
    {
        var parts = new List<string>();

        if (Black is not null) parts.Add($"--nb-black: {Black}");
        if (White is not null) parts.Add($"--nb-white: {White}");
        if (Background is not null) parts.Add($"--nb-bg: {Background}");
        if (BackgroundDark is not null) parts.Add($"--nb-bg-dark: {BackgroundDark}");
        if (Primary is not null) parts.Add($"--nb-primary: {Primary}");
        if (PrimaryHover is not null) parts.Add($"--nb-primary-hover: {PrimaryHover}");
        if (Danger is not null) parts.Add($"--nb-danger: {Danger}");
        if (DangerHover is not null) parts.Add($"--nb-danger-hover: {DangerHover}");
        if (Success is not null) parts.Add($"--nb-success: {Success}");
        if (Muted is not null) parts.Add($"--nb-muted: {Muted}");
        if (Border is not null) parts.Add($"--nb-border: {Border}");
        if (Shadow is not null) parts.Add($"--nb-shadow: {Shadow}");
        if (ShadowSm is not null) parts.Add($"--nb-shadow-sm: {ShadowSm}");
        if (Radius is not null) parts.Add($"--nb-radius: {Radius}");
        if (Font is not null) parts.Add($"--nb-font: {Font}");

        return string.Join("; ", parts);
    }
}
