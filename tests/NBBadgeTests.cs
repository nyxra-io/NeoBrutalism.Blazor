using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBBadgeTests : BunitContext
{
    [Fact]
    public void Renders_ChildContent()
    {
        var cut = Render<NBBadge>(p => p
            .AddChildContent("New"));

        Assert.Equal("New", cut.Find(".nb-badge").TextContent);
    }

    [Theory]
    [InlineData(NBBadgeVariant.Default, "nb-badge--default")]
    [InlineData(NBBadgeVariant.Neutral, "nb-badge--neutral")]
    public void Applies_Variant_CssClass(NBBadgeVariant variant, string expectedClass)
    {
        var cut = Render<NBBadge>(p => p
            .Add(b => b.Variant, variant)
            .AddChildContent("tag"));

        Assert.Contains(expectedClass, cut.Find("span").GetAttribute("class"));
    }

    [Fact]
    public void Renders_As_Span()
    {
        var cut = Render<NBBadge>(p => p
            .AddChildContent("tag"));

        Assert.Equal("SPAN", cut.Find(".nb-badge").TagName);
    }
}
