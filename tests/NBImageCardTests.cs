using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBImageCardTests : BunitContext
{
    [Fact]
    public void Renders_Image_And_Caption()
    {
        var cut = Render<NBImageCard>(p => p
            .Add(c => c.ImageUrl, "https://example.com/img.jpg")
            .Add(c => c.Caption, "A nice photo"));

        Assert.Equal("https://example.com/img.jpg", cut.Find(".nb-image-card__img").GetAttribute("src"));
        Assert.Equal("A nice photo", cut.Find(".nb-image-card__caption").TextContent);
    }

    [Fact]
    public void Uses_Alt_When_Provided()
    {
        var cut = Render<NBImageCard>(p => p
            .Add(c => c.ImageUrl, "img.jpg")
            .Add(c => c.Caption, "Caption")
            .Add(c => c.Alt, "Custom alt"));

        Assert.Equal("Custom alt", cut.Find(".nb-image-card__img").GetAttribute("alt"));
    }

    [Fact]
    public void Falls_Back_To_Caption_As_Alt()
    {
        var cut = Render<NBImageCard>(p => p
            .Add(c => c.ImageUrl, "img.jpg")
            .Add(c => c.Caption, "Fallback alt"));

        Assert.Equal("Fallback alt", cut.Find(".nb-image-card__img").GetAttribute("alt"));
    }

    [Fact]
    public void Renders_As_Figure()
    {
        var cut = Render<NBImageCard>(p => p
            .Add(c => c.ImageUrl, "img.jpg")
            .Add(c => c.Caption, "Cap"));

        Assert.Equal("FIGURE", cut.Find(".nb-image-card").TagName);
    }
}
