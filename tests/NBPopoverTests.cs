using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBPopoverTests : BunitContext
{
    [Fact]
    public void Content_Hidden_By_Default()
    {
        var cut = Render<NBPopover>(p => p
            .AddChildContent("Trigger")
            .Add(po => po.Content, b => b.AddMarkupContent(0, "<div>Popover</div>")));

        Assert.Empty(cut.FindAll(".nb-popover"));
    }

    [Fact]
    public void Content_Visible_After_Click()
    {
        var cut = Render<NBPopover>(p => p
            .AddChildContent("Trigger")
            .Add(po => po.Content, b => b.AddMarkupContent(0, "<div>Popover</div>")));

        cut.Find(".nb-popover-trigger").Click();

        Assert.NotEmpty(cut.FindAll(".nb-popover"));
    }

    [Theory]
    [InlineData(NBPopoverSide.Top, "nb-popover--top")]
    [InlineData(NBPopoverSide.Bottom, "nb-popover--bottom")]
    [InlineData(NBPopoverSide.Left, "nb-popover--left")]
    [InlineData(NBPopoverSide.Right, "nb-popover--right")]
    public void Applies_Side_Class(NBPopoverSide side, string expectedClass)
    {
        var cut = Render<NBPopover>(p => p
            .AddChildContent("Trigger")
            .Add(po => po.Content, b => b.AddMarkupContent(0, "<div>Pop</div>"))
            .Add(po => po.Side, side)
            .Add(po => po.IsOpen, true));

        Assert.Contains(expectedClass, cut.Find(".nb-popover").GetAttribute("class"));
    }

    [Fact]
    public void Toggle_Off_Hides_Content()
    {
        var cut = Render<NBPopover>(p => p
            .AddChildContent("Trigger")
            .Add(po => po.Content, b => b.AddMarkupContent(0, "<div>Pop</div>")));

        cut.Find(".nb-popover-trigger").Click(); // open
        cut.Find(".nb-popover-trigger").Click(); // close

        Assert.Empty(cut.FindAll(".nb-popover"));
    }

    [Fact]
    public void IsOpenChanged_Fires()
    {
        bool? isOpen = null;
        var cut = Render<NBPopover>(p => p
            .AddChildContent("Trigger")
            .Add(po => po.Content, b => b.AddMarkupContent(0, "<div>Pop</div>"))
            .Add(po => po.IsOpenChanged, (bool v) => isOpen = v));

        cut.Find(".nb-popover-trigger").Click();

        Assert.True(isOpen);
    }

    [Fact]
    public void Initial_IsOpen_True_Shows_Content()
    {
        var cut = Render<NBPopover>(p => p
            .AddChildContent("Trigger")
            .Add(po => po.Content, b => b.AddMarkupContent(0, "<div>Pop</div>"))
            .Add(po => po.IsOpen, true));

        Assert.NotEmpty(cut.FindAll(".nb-popover"));
    }
}
