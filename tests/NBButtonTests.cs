using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBButtonTests : BunitContext
{
    [Fact]
    public void Renders_Default_ChildContent()
    {
        var cut = Render<NBButton>(p => p
            .AddChildContent("Click me"));

        cut.Find("button").MarkupMatches(
            @"<button class=""nb-btn nb-btn--default"">Click me</button>");
    }

    [Theory]
    [InlineData(NBButtonVariant.Default, "nb-btn--default")]
    [InlineData(NBButtonVariant.Neutral, "nb-btn--neutral")]
    [InlineData(NBButtonVariant.Reverse, "nb-btn--reverse")]
    [InlineData(NBButtonVariant.NoShadow, "nb-btn--noshadow")]
    [InlineData(NBButtonVariant.Danger, "nb-btn--danger")]
    [InlineData(NBButtonVariant.Success, "nb-btn--success")]
    public void Applies_Variant_CssClass(NBButtonVariant variant, string expectedClass)
    {
        var cut = Render<NBButton>(p => p
            .Add(b => b.Variant, variant)
            .AddChildContent("btn"));

        Assert.Contains(expectedClass, cut.Find("button").GetAttribute("class"));
    }

    [Theory]
    [InlineData(NBButtonSize.Small, "nb-btn--sm")]
    [InlineData(NBButtonSize.Large, "nb-btn--lg")]
    [InlineData(NBButtonSize.Icon, "nb-btn--icon")]
    public void Applies_Size_CssClass(NBButtonSize size, string expectedClass)
    {
        var cut = Render<NBButton>(p => p
            .Add(b => b.Size, size)
            .AddChildContent("btn"));

        Assert.Contains(expectedClass, cut.Find("button").GetAttribute("class"));
    }

    [Fact]
    public void Normal_Size_Has_No_Extra_Class()
    {
        var cut = Render<NBButton>(p => p
            .Add(b => b.Size, NBButtonSize.Normal)
            .AddChildContent("btn"));

        var classes = cut.Find("button").GetAttribute("class")!;
        Assert.DoesNotContain("nb-btn--sm", classes);
        Assert.DoesNotContain("nb-btn--lg", classes);
        Assert.DoesNotContain("nb-btn--icon", classes);
    }

    [Fact]
    public void Disabled_Attribute_Rendered()
    {
        var cut = Render<NBButton>(p => p
            .Add(b => b.Disabled, true)
            .AddChildContent("btn"));

        Assert.NotNull(cut.Find("button").GetAttribute("disabled"));
    }

    [Fact]
    public void Click_Invokes_OnClick()
    {
        var clicked = false;
        var cut = Render<NBButton>(p => p
            .Add(b => b.OnClick, () => clicked = true)
            .AddChildContent("btn"));

        cut.Find("button").Click();

        Assert.True(clicked);
    }

    [Fact]
    public void Splatted_Attributes_Rendered()
    {
        var cut = Render<NBButton>(p => p
            .AddUnmatched("data-testid", "my-btn")
            .AddChildContent("btn"));

        Assert.Equal("my-btn", cut.Find("button").GetAttribute("data-testid"));
    }
}
