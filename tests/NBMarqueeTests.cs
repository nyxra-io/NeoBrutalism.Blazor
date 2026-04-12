using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBMarqueeTests : BunitContext
{
    [Fact]
    public void Renders_Items()
    {
        var cut = Render<NBMarquee>(p => p
            .Add(m => m.Items, new[] { "One", "Two", "Three" }));

        var items = cut.FindAll(".nb-marquee__item");
        Assert.True(items.Count >= 3); // Duplicate track renders items twice
    }

    [Fact]
    public void Has_Two_Tracks()
    {
        var cut = Render<NBMarquee>(p => p
            .Add(m => m.Items, new[] { "A" }));

        Assert.Equal(2, cut.FindAll(".nb-marquee__track").Count);
    }

    [Fact]
    public void PauseOnHover_Adds_Class()
    {
        var cut = Render<NBMarquee>(p => p
            .Add(m => m.Items, new[] { "A" })
            .Add(m => m.PauseOnHover, true));

        Assert.Contains("nb-marquee--pause-hover", cut.Find(".nb-marquee").GetAttribute("class"));
    }

    [Fact]
    public void Custom_Speed_Applied()
    {
        var cut = Render<NBMarquee>(p => p
            .Add(m => m.Items, new[] { "A" })
            .Add(m => m.Speed, "10s"));

        Assert.Contains("--nb-marquee-speed: 10s", cut.Find(".nb-marquee").GetAttribute("style"));
    }
}
