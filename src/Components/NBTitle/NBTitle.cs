using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace NeoBrutalism.Blazor;

/// <summary>
/// High-level title component that wraps <see cref="NBHeading"/> with predefined
/// semantic variants: page title, subtitle, section and sub-section.
/// </summary>
public class NBTitle : ComponentBase
{
    /// <summary>Semantic variant that controls the rendered element and style.</summary>
    [Parameter]
    public NBTitleVariant Variant { get; set; } = NBTitleVariant.Title;

    /// <summary>Content displayed inside the title element.</summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>Additional HTML attributes forwarded to the rendered element.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    /// <inheritdoc />
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var (tag, css) = Variant switch
        {
            NBTitleVariant.Title      => ("h1", "nb-title nb-title--title"),
            NBTitleVariant.Subtitle   => ("p",  "nb-title nb-title--subtitle"),
            NBTitleVariant.Section    => ("h2", "nb-title nb-title--section"),
            NBTitleVariant.SubSection => ("h3", "nb-title nb-title--subsection"),
            _ => ("h1", "nb-title nb-title--title")
        };

        builder.OpenElement(0, tag);
        builder.AddAttribute(1, "class", css);
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    }
}
