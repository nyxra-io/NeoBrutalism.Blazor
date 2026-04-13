using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBHeroTests : BunitContext
{
    [Fact]
    public void Renders_Title()
    {
        var cut = Render<NBHero>(p => p
            .Add(h => h.Title, "Welcome"));

        Assert.Equal("Welcome", cut.Find(".nb-hero__title").TextContent);
    }

    [Fact]
    public void Renders_Subtitle()
    {
        var cut = Render<NBHero>(p => p
            .Add(h => h.Title, "Hi")
            .Add(h => h.Subtitle, "A subtitle"));

        Assert.Equal("A subtitle", cut.Find(".nb-hero__subtitle").TextContent);
    }

    [Fact]
    public void Title_Not_Rendered_When_Null()
    {
        var cut = Render<NBHero>();

        Assert.Empty(cut.FindAll(".nb-hero__title"));
    }

    [Fact]
    public void Subtitle_Not_Rendered_When_Null()
    {
        var cut = Render<NBHero>(p => p
            .Add(h => h.Title, "Hi"));

        Assert.Empty(cut.FindAll(".nb-hero__subtitle"));
    }

    [Theory]
    [InlineData(NBHeroVariant.Centered, "nb-hero--centered")]
    [InlineData(NBHeroVariant.Split, "nb-hero--split")]
    public void Applies_Variant_CssClass(NBHeroVariant variant, string expectedClass)
    {
        var cut = Render<NBHero>(p => p
            .Add(h => h.Title, "Test")
            .Add(h => h.Variant, variant));

        Assert.Contains(expectedClass, cut.Find("section").GetAttribute("class"));
    }

    [Fact]
    public void Default_Variant_Is_Centered()
    {
        var cut = Render<NBHero>(p => p
            .Add(h => h.Title, "Test"));

        Assert.Contains("nb-hero--centered", cut.Find("section").GetAttribute("class"));
    }

    [Fact]
    public void Renders_Cta_Slot()
    {
        var cut = Render<NBHero>(p => p
            .Add(h => h.Title, "Test")
            .Add(h => h.Cta, b => b.AddMarkupContent(0, "<button>Get Started</button>")));

        Assert.NotNull(cut.Find(".nb-hero__cta button"));
    }

    [Fact]
    public void Cta_Not_Rendered_When_Null()
    {
        var cut = Render<NBHero>(p => p
            .Add(h => h.Title, "Test"));

        Assert.Empty(cut.FindAll(".nb-hero__cta"));
    }

    [Fact]
    public void Renders_Visual_Slot()
    {
        var cut = Render<NBHero>(p => p
            .Add(h => h.Title, "Test")
            .Add(h => h.Visual, b => b.AddMarkupContent(0, "<img src=\"hero.png\" />")));

        Assert.NotNull(cut.Find(".nb-hero__visual img"));
    }

    [Fact]
    public void Visual_Not_Rendered_When_Null()
    {
        var cut = Render<NBHero>(p => p
            .Add(h => h.Title, "Test"));

        Assert.Empty(cut.FindAll(".nb-hero__visual"));
    }

    [Fact]
    public void Renders_As_Section_Element()
    {
        var cut = Render<NBHero>(p => p
            .Add(h => h.Title, "Test"));

        Assert.Equal("SECTION", cut.Find(".nb-hero").TagName);
    }

    [Fact]
    public void Applies_BackgroundImage_Style()
    {
        var cut = Render<NBHero>(p => p
            .Add(h => h.Title, "Test")
            .Add(h => h.BackgroundImage, "https://example.com/bg.jpg"));

        var style = cut.Find("section").GetAttribute("style");
        Assert.Contains("background-image:url('https://example.com/bg.jpg')", style);
        Assert.Contains("background-size:cover", style);
    }

    [Fact]
    public void No_BackgroundImage_Style_When_Null()
    {
        var cut = Render<NBHero>(p => p
            .Add(h => h.Title, "Test"));

        Assert.Null(cut.Find("section").GetAttribute("style"));
    }
}
