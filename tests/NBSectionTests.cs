using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBSectionTests : BunitContext
{
    [Fact]
    public void Renders_ChildContent()
    {
        var cut = Render<NBSection>(p => p
            .AddChildContent("<p>Body text</p>"));

        Assert.Contains("Body text", cut.Find(".nb-section__body").InnerHtml);
    }

    [Fact]
    public void Renders_Title_When_Provided()
    {
        var cut = Render<NBSection>(p => p
            .Add(s => s.Title, "Features")
            .AddChildContent("content"));

        Assert.Equal("Features", cut.Find(".nb-section__title").TextContent);
    }

    [Fact]
    public void Title_Not_Rendered_When_Null()
    {
        var cut = Render<NBSection>(p => p
            .AddChildContent("content"));

        Assert.Empty(cut.FindAll(".nb-section__title"));
    }

    [Fact]
    public void Renders_Subtitle_When_Provided()
    {
        var cut = Render<NBSection>(p => p
            .Add(s => s.Title, "Title")
            .Add(s => s.Subtitle, "A brief description")
            .AddChildContent("content"));

        Assert.Equal("A brief description", cut.Find(".nb-section__subtitle").TextContent);
    }

    [Fact]
    public void Subtitle_Not_Rendered_When_Null()
    {
        var cut = Render<NBSection>(p => p
            .AddChildContent("content"));

        Assert.Empty(cut.FindAll(".nb-section__subtitle"));
    }

    [Theory]
    [InlineData(NBSectionBackground.Default, "nb-section--default")]
    [InlineData(NBSectionBackground.Secondary, "nb-section--secondary")]
    public void Applies_Background_CssClass(NBSectionBackground bg, string expectedClass)
    {
        var cut = Render<NBSection>(p => p
            .Add(s => s.Background, bg)
            .AddChildContent("content"));

        Assert.Contains(expectedClass, cut.Find("section").GetAttribute("class"));
    }

    [Fact]
    public void Default_Background_Is_Default()
    {
        var cut = Render<NBSection>(p => p
            .AddChildContent("content"));

        Assert.Contains("nb-section--default", cut.Find("section").GetAttribute("class"));
    }

    [Fact]
    public void Renders_As_Section_Element()
    {
        var cut = Render<NBSection>(p => p
            .AddChildContent("content"));

        Assert.Equal("SECTION", cut.Find(".nb-section").TagName);
    }

    [Theory]
    [InlineData(NBSectionAlign.Center, "nb-section--align-center")]
    [InlineData(NBSectionAlign.Left, "nb-section--align-left")]
    [InlineData(NBSectionAlign.Right, "nb-section--align-right")]
    public void Applies_Align_CssClass(NBSectionAlign align, string expectedClass)
    {
        var cut = Render<NBSection>(p => p
            .Add(s => s.Align, align)
            .AddChildContent("content"));

        Assert.Contains(expectedClass, cut.Find("section").GetAttribute("class"));
    }

    [Fact]
    public void Default_Align_Is_Center()
    {
        var cut = Render<NBSection>(p => p
            .AddChildContent("content"));

        Assert.Contains("nb-section--align-center", cut.Find("section").GetAttribute("class"));
    }
}
