using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBFeatureCardTests : BunitContext
{
    [Fact]
    public void Renders_Title()
    {
        var cut = Render<NBFeatureCard>(p => p
            .Add(c => c.Title, "Fast"));

        Assert.Equal("Fast", cut.Find(".nb-feature-card__title").TextContent);
    }

    [Fact]
    public void Renders_Description()
    {
        var cut = Render<NBFeatureCard>(p => p
            .Add(c => c.Title, "Fast")
            .Add(c => c.Description, "Blazing fast performance."));

        Assert.Equal("Blazing fast performance.", cut.Find(".nb-feature-card__description").TextContent);
    }

    [Fact]
    public void Title_Not_Rendered_When_Null()
    {
        var cut = Render<NBFeatureCard>(p => p
            .Add(c => c.Description, "desc"));

        Assert.Empty(cut.FindAll(".nb-feature-card__title"));
    }

    [Fact]
    public void Description_Not_Rendered_When_Null()
    {
        var cut = Render<NBFeatureCard>(p => p
            .Add(c => c.Title, "title"));

        Assert.Empty(cut.FindAll(".nb-feature-card__description"));
    }

    [Fact]
    public void Renders_Icon_When_Provided()
    {
        var cut = Render<NBFeatureCard>(p => p
            .Add(c => c.Title, "Feature")
            .Add(c => c.Icon, b => b.AddMarkupContent(0, "<svg id=\"ico\"></svg>")));

        Assert.NotNull(cut.Find(".nb-feature-card__icon #ico"));
    }

    [Fact]
    public void Icon_Not_Rendered_When_Null()
    {
        var cut = Render<NBFeatureCard>(p => p
            .Add(c => c.Title, "Feature"));

        Assert.Empty(cut.FindAll(".nb-feature-card__icon"));
    }

    [Fact]
    public void Renders_As_Div()
    {
        var cut = Render<NBFeatureCard>(p => p
            .Add(c => c.Title, "Feature"));

        Assert.Equal("DIV", cut.Find(".nb-feature-card").TagName);
    }

    [Fact]
    public void Renders_Image_When_ImageSrc_Set()
    {
        var cut = Render<NBFeatureCard>(p => p
            .Add(c => c.Title, "Feature")
            .Add(c => c.ImageSrc, "https://example.com/img.png"));

        var img = cut.Find(".nb-feature-card__image");
        Assert.Equal("https://example.com/img.png", img.GetAttribute("src"));
    }

    [Fact]
    public void Image_Uses_ImageAlt_When_Provided()
    {
        var cut = Render<NBFeatureCard>(p => p
            .Add(c => c.Title, "Feature")
            .Add(c => c.ImageSrc, "img.png")
            .Add(c => c.ImageAlt, "Custom alt"));

        Assert.Equal("Custom alt", cut.Find(".nb-feature-card__image").GetAttribute("alt"));
    }

    [Fact]
    public void Image_Falls_Back_To_Title_For_Alt()
    {
        var cut = Render<NBFeatureCard>(p => p
            .Add(c => c.Title, "Feature")
            .Add(c => c.ImageSrc, "img.png"));

        Assert.Equal("Feature", cut.Find(".nb-feature-card__image").GetAttribute("alt"));
    }

    [Fact]
    public void ImageSrc_Takes_Priority_Over_Icon()
    {
        var cut = Render<NBFeatureCard>(p => p
            .Add(c => c.Title, "Feature")
            .Add(c => c.ImageSrc, "img.png")
            .Add(c => c.Icon, b => b.AddMarkupContent(0, "<svg></svg>")));

        Assert.NotEmpty(cut.FindAll(".nb-feature-card__image"));
        Assert.Empty(cut.FindAll(".nb-feature-card__icon"));
    }

    [Fact]
    public void Image_Not_Rendered_When_No_ImageSrc()
    {
        var cut = Render<NBFeatureCard>(p => p
            .Add(c => c.Title, "Feature"));

        Assert.Empty(cut.FindAll(".nb-feature-card__image"));
    }
}
