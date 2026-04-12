using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBProgressTests : BunitContext
{
    [Fact]
    public void Renders_With_Progressbar_Role()
    {
        var cut = Render<NBProgress>(p => p
            .Add(pr => pr.Value, 50));

        var bar = cut.Find("[role='progressbar']");
        Assert.Equal("50", bar.GetAttribute("aria-valuenow"));
    }

    [Fact]
    public void Bar_Width_Matches_Value()
    {
        var cut = Render<NBProgress>(p => p
            .Add(pr => pr.Value, 75));

        var bar = cut.Find(".nb-progress__bar");
        Assert.Contains("width: 75%", bar.GetAttribute("style"));
    }

    [Fact]
    public void Clamps_Value_To_100()
    {
        var cut = Render<NBProgress>(p => p
            .Add(pr => pr.Value, 150));

        var bar = cut.Find(".nb-progress__bar");
        Assert.Contains("width: 100%", bar.GetAttribute("style"));
    }

    [Fact]
    public void Clamps_Value_To_0()
    {
        var cut = Render<NBProgress>(p => p
            .Add(pr => pr.Value, -10));

        var bar = cut.Find(".nb-progress__bar");
        Assert.Contains("width: 0%", bar.GetAttribute("style"));
    }
}
