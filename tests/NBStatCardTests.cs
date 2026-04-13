using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBStatCardTests : BunitContext
{
    [Fact]
    public void Renders_Value()
    {
        var cut = Render<NBStatCard>(p => p
            .Add(c => c.Value, "1,234"));

        Assert.Equal("1,234", cut.Find(".nb-stat-card__value").TextContent);
    }

    [Fact]
    public void Renders_Label_When_Provided()
    {
        var cut = Render<NBStatCard>(p => p
            .Add(c => c.Value, "42")
            .Add(c => c.Label, "Active users"));

        Assert.Equal("Active users", cut.Find(".nb-stat-card__label").TextContent);
    }

    [Fact]
    public void Label_Not_Rendered_When_Null()
    {
        var cut = Render<NBStatCard>(p => p
            .Add(c => c.Value, "42"));

        Assert.Empty(cut.FindAll(".nb-stat-card__label"));
    }

    [Fact]
    public void Renders_Trend_Up()
    {
        var cut = Render<NBStatCard>(p => p
            .Add(c => c.Value, "99")
            .Add(c => c.Trend, NBStatCardTrend.Up));

        var trend = cut.Find(".nb-stat-card__trend");
        Assert.Contains("nb-stat-card__trend--up", trend.GetAttribute("class"));
        Assert.Contains("↑", trend.TextContent);
    }

    [Fact]
    public void Renders_Trend_Down()
    {
        var cut = Render<NBStatCard>(p => p
            .Add(c => c.Value, "12")
            .Add(c => c.Trend, NBStatCardTrend.Down));

        var trend = cut.Find(".nb-stat-card__trend");
        Assert.Contains("nb-stat-card__trend--down", trend.GetAttribute("class"));
        Assert.Contains("↓", trend.TextContent);
    }

    [Fact]
    public void Trend_Not_Rendered_When_None()
    {
        var cut = Render<NBStatCard>(p => p
            .Add(c => c.Value, "50"));

        Assert.Empty(cut.FindAll(".nb-stat-card__trend"));
    }

    [Fact]
    public void Default_Trend_Is_None()
    {
        var cut = Render<NBStatCard>(p => p
            .Add(c => c.Value, "50"));

        Assert.Empty(cut.FindAll(".nb-stat-card__trend"));
    }

    [Fact]
    public void Renders_As_Div()
    {
        var cut = Render<NBStatCard>(p => p
            .Add(c => c.Value, "10"));

        Assert.Equal("DIV", cut.Find(".nb-stat-card").TagName);
    }
}
