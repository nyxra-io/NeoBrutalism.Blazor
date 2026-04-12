using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBDrawerTests : BunitContext
{
    [Fact]
    public void Not_Rendered_When_Not_Visible()
    {
        var cut = Render<NBDrawer>(p => p
            .Add(d => d.IsVisible, false)
            .AddChildContent("Body"));

        Assert.Empty(cut.FindAll("[role='dialog']"));
    }

    [Fact]
    public void Rendered_When_Visible()
    {
        var cut = Render<NBDrawer>(p => p
            .Add(d => d.IsVisible, true)
            .Add(d => d.OnClose, () => { })
            .AddChildContent("Body"));

        Assert.NotEmpty(cut.FindAll("[role='dialog']"));
    }

    [Theory]
    [InlineData(NBDrawerSide.Right, "nb-drawer--right")]
    [InlineData(NBDrawerSide.Left, "nb-drawer--left")]
    [InlineData(NBDrawerSide.Top, "nb-drawer--top")]
    [InlineData(NBDrawerSide.Bottom, "nb-drawer--bottom")]
    public void Applies_Side_Class(NBDrawerSide side, string expectedClass)
    {
        var cut = Render<NBDrawer>(p => p
            .Add(d => d.IsVisible, true)
            .Add(d => d.Side, side)
            .Add(d => d.OnClose, () => { })
            .AddChildContent("Body"));

        Assert.Contains(expectedClass, cut.Find(".nb-drawer").GetAttribute("class"));
    }

    [Fact]
    public void Renders_Title_And_Description()
    {
        var cut = Render<NBDrawer>(p => p
            .Add(d => d.IsVisible, true)
            .Add(d => d.Title, "Settings")
            .Add(d => d.Description, "Adjust preferences")
            .Add(d => d.OnClose, () => { })
            .AddChildContent("Body"));

        Assert.Contains("Settings", cut.Find(".nb-drawer__title").TextContent);
        Assert.Contains("Adjust preferences", cut.Find(".nb-drawer__description").TextContent);
    }

    [Fact]
    public void Close_Button_Fires_OnClose()
    {
        var closed = false;
        var cut = Render<NBDrawer>(p => p
            .Add(d => d.IsVisible, true)
            .Add(d => d.OnClose, () => closed = true)
            .AddChildContent("Body"));

        cut.Find(".nb-drawer__close").Click();

        Assert.True(closed);
    }

    [Fact]
    public void Renders_ChildContent()
    {
        var cut = Render<NBDrawer>(p => p
            .Add(d => d.IsVisible, true)
            .Add(d => d.OnClose, () => { })
            .AddChildContent("Drawer body"));

        Assert.Contains("Drawer body", cut.Find(".nb-drawer__body").TextContent);
    }

    [Fact]
    public void Renders_Footer()
    {
        var cut = Render<NBDrawer>(p => p
            .Add(d => d.IsVisible, true)
            .Add(d => d.OnClose, () => { })
            .Add(d => d.Footer, b => b.AddMarkupContent(0, "<button>Submit</button>"))
            .AddChildContent("Body"));

        Assert.NotEmpty(cut.FindAll(".nb-drawer__footer"));
    }

    [Fact]
    public void Has_Aria_Modal()
    {
        var cut = Render<NBDrawer>(p => p
            .Add(d => d.IsVisible, true)
            .Add(d => d.OnClose, () => { })
            .AddChildContent("Body"));

        Assert.Equal("true", cut.Find("[role='dialog']").GetAttribute("aria-modal"));
    }

    [Fact]
    public void Backdrop_Click_Fires_OnClose_When_CloseOnBackdrop()
    {
        var closed = false;
        var cut = Render<NBDrawer>(p => p
            .Add(d => d.IsVisible, true)
            .Add(d => d.CloseOnBackdrop, true)
            .Add(d => d.OnClose, () => closed = true)
            .AddChildContent("Body"));

        cut.Find(".nb-drawer-backdrop").Click();

        Assert.True(closed);
    }

    [Fact]
    public void No_Header_When_No_Title()
    {
        var cut = Render<NBDrawer>(p => p
            .Add(d => d.IsVisible, true)
            .Add(d => d.OnClose, () => { })
            .AddChildContent("Body"));

        Assert.Empty(cut.FindAll(".nb-drawer__header"));
    }
}
