using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace NeoBrutalism.Blazor;

/// <summary>
/// Renders a semantic heading element (<c>h1</c>–<c>h6</c>) with Neo Brutalism styling.
/// The level is controlled by <see cref="Variant"/>.
/// </summary>
public class NBHeading : ComponentBase
{
    /// <summary>Heading level to render (H1–H6).</summary>
    [Parameter]
    public NBHeadingVariant Variant { get; set; } = NBHeadingVariant.H2;

    /// <summary>Content displayed inside the heading element.</summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>Additional HTML attributes forwarded to the rendered element.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    /// <inheritdoc />
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var tag = Variant.ToString().ToLowerInvariant();
        var css = $"nb-heading nb-heading--{tag}";

        builder.OpenElement(0, tag);
        builder.AddAttribute(1, "class", css);
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}
