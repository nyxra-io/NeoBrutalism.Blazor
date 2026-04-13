using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBTimelineTests : BunitContext
{
    [Fact]
    public void Renders_ChildContent()
    {
        var cut = Render<NBTimeline>(p => p
            .AddChildContent("<div class=\"child\">step</div>"));

        Assert.Contains("step", cut.Find(".nb-timeline").InnerHtml);
    }

    [Fact]
    public void Step_Renders_Title()
    {
        var cut = Render<NBTimelineStep>(p => p
            .Add(s => s.Title, "Step 1"));

        Assert.Equal("Step 1", cut.Find(".nb-timeline__title").TextContent);
    }

    [Fact]
    public void Step_Renders_Description()
    {
        var cut = Render<NBTimelineStep>(p => p
            .Add(s => s.Title, "Step")
            .Add(s => s.Description, "Details here"));

        Assert.Equal("Details here", cut.Find(".nb-timeline__description").TextContent);
    }

    [Fact]
    public void Step_Title_Not_Rendered_When_Null()
    {
        var cut = Render<NBTimelineStep>(p => p
            .Add(s => s.Description, "desc"));

        Assert.Empty(cut.FindAll(".nb-timeline__title"));
    }

    [Fact]
    public void Step_Description_Not_Rendered_When_Null()
    {
        var cut = Render<NBTimelineStep>(p => p
            .Add(s => s.Title, "title"));

        Assert.Empty(cut.FindAll(".nb-timeline__description"));
    }

    [Theory]
    [InlineData(NBTimelineStepState.Completed, "nb-timeline__step--completed")]
    [InlineData(NBTimelineStepState.Active, "nb-timeline__step--active")]
    [InlineData(NBTimelineStepState.Upcoming, "nb-timeline__step--upcoming")]
    public void Step_Applies_State_CssClass(NBTimelineStepState state, string expectedClass)
    {
        var cut = Render<NBTimelineStep>(p => p
            .Add(s => s.Title, "Step")
            .Add(s => s.State, state));

        Assert.Contains(expectedClass, cut.Find(".nb-timeline__step").GetAttribute("class"));
    }

    [Fact]
    public void Step_Default_State_Is_Upcoming()
    {
        var cut = Render<NBTimelineStep>(p => p
            .Add(s => s.Title, "Step"));

        Assert.Contains("nb-timeline__step--upcoming", cut.Find(".nb-timeline__step").GetAttribute("class"));
    }

    [Fact]
    public void Step_Renders_Icon_When_Provided()
    {
        var cut = Render<NBTimelineStep>(p => p
            .Add(s => s.Title, "Step")
            .Add(s => s.Icon, b => b.AddMarkupContent(0, "<svg id=\"ico\"></svg>")));

        Assert.NotNull(cut.Find(".nb-timeline__indicator #ico"));
    }

    [Fact]
    public void Step_Has_Indicator()
    {
        var cut = Render<NBTimelineStep>(p => p
            .Add(s => s.Title, "Step"));

        Assert.NotNull(cut.Find(".nb-timeline__indicator"));
    }

    [Theory]
    [InlineData(NBTimelineOrientation.Vertical, "nb-timeline--vertical")]
    [InlineData(NBTimelineOrientation.Horizontal, "nb-timeline--horizontal")]
    public void Applies_Orientation_CssClass(NBTimelineOrientation orientation, string expectedClass)
    {
        var cut = Render<NBTimeline>(p => p
            .Add(t => t.Orientation, orientation)
            .AddChildContent("<div>step</div>"));

        Assert.Contains(expectedClass, cut.Find(".nb-timeline").GetAttribute("class"));
    }

    [Fact]
    public void Default_Orientation_Is_Vertical()
    {
        var cut = Render<NBTimeline>(p => p
            .AddChildContent("<div>step</div>"));

        Assert.Contains("nb-timeline--vertical", cut.Find(".nb-timeline").GetAttribute("class"));
    }
}
