using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBTooltipTests : BunitContext
{
    [Fact]
    public void Renders_Tooltip_Text()
    {
        var cut = Render<NBTooltip>(p => p
            .Add(t => t.Text, "Hint")
            .AddChildContent("Hover me"));

        Assert.Equal("Hint", cut.Find(".nb-tooltip").TextContent);
    }

    [Fact]
    public void Renders_Trigger_Content()
    {
        var cut = Render<NBTooltip>(p => p
            .Add(t => t.Text, "Hint")
            .AddChildContent("Button"));

        Assert.Equal("Button", cut.Find(".nb-tooltip-trigger").TextContent);
    }

    [Theory]
    [InlineData(NBTooltipSide.Top, "nb-tooltip--top")]
    [InlineData(NBTooltipSide.Bottom, "nb-tooltip--bottom")]
    [InlineData(NBTooltipSide.Left, "nb-tooltip--left")]
    [InlineData(NBTooltipSide.Right, "nb-tooltip--right")]
    public void Applies_Side_Class(NBTooltipSide side, string expectedClass)
    {
        var cut = Render<NBTooltip>(p => p
            .Add(t => t.Text, "Hint")
            .Add(t => t.Side, side)
            .AddChildContent("Trigger"));

        Assert.Contains(expectedClass, cut.Find(".nb-tooltip").GetAttribute("class"));
    }
}
