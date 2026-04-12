using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBSkeletonTests : BunitContext
{
    [Fact]
    public void Renders_Div()
    {
        var cut = Render<NBSkeleton>();

        Assert.NotNull(cut.Find(".nb-skeleton"));
    }

    [Fact]
    public void Applies_Width_And_Height()
    {
        var cut = Render<NBSkeleton>(p => p
            .Add(s => s.Width, "200px")
            .Add(s => s.Height, "40px"));

        var style = cut.Find(".nb-skeleton").GetAttribute("style");
        Assert.Contains("width:200px", style);
        Assert.Contains("height:40px", style);
    }

    [Fact]
    public void No_Style_When_No_Dimensions()
    {
        var cut = Render<NBSkeleton>();

        var style = cut.Find(".nb-skeleton").GetAttribute("style") ?? "";
        Assert.DoesNotContain("width", style);
        Assert.DoesNotContain("height", style);
    }
}
