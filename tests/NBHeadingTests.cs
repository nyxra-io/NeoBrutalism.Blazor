using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBHeadingTests : BunitContext
{
    [Theory]
    [InlineData(NBHeadingVariant.H1, "h1")]
    [InlineData(NBHeadingVariant.H2, "h2")]
    [InlineData(NBHeadingVariant.H3, "h3")]
    [InlineData(NBHeadingVariant.H4, "h4")]
    [InlineData(NBHeadingVariant.H5, "h5")]
    [InlineData(NBHeadingVariant.H6, "h6")]
    public void Renders_Correct_Tag(NBHeadingVariant variant, string expectedTag)
    {
        var cut = Render<NBHeading>(p => p
            .Add(h => h.Variant, variant)
            .AddChildContent("Title"));

        var element = cut.Find($".nb-heading");
        Assert.Equal(expectedTag.ToUpperInvariant(), element.TagName);
    }

    [Fact]
    public void Applies_Variant_CssClass()
    {
        var cut = Render<NBHeading>(p => p
            .Add(h => h.Variant, NBHeadingVariant.H3)
            .AddChildContent("Title"));

        Assert.Contains("nb-heading--h3", cut.Find(".nb-heading").GetAttribute("class"));
    }

    [Fact]
    public void Renders_ChildContent()
    {
        var cut = Render<NBHeading>(p => p
            .AddChildContent("My Heading"));

        Assert.Equal("My Heading", cut.Find(".nb-heading").TextContent);
    }

    [Fact]
    public void Splatted_Attributes_Rendered()
    {
        var cut = Render<NBHeading>(p => p
            .AddUnmatched("data-testid", "heading")
            .AddChildContent("Title"));

        Assert.Equal("heading", cut.Find(".nb-heading").GetAttribute("data-testid"));
    }
}
