using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBDialogTests : BunitContext
{
    [Fact]
    public void Not_Rendered_When_Not_Visible()
    {
        var cut = Render<NBDialog>(p => p
            .Add(d => d.IsVisible, false)
            .AddChildContent("Body"));

        Assert.Empty(cut.FindAll("[role='dialog']"));
    }

    [Fact]
    public void Rendered_When_Visible()
    {
        var cut = Render<NBDialog>(p => p
            .Add(d => d.IsVisible, true)
            .AddChildContent("Body"));

        Assert.NotEmpty(cut.FindAll("[role='dialog']"));
    }

    [Fact]
    public void Renders_Title_And_Description()
    {
        var cut = Render<NBDialog>(p => p
            .Add(d => d.IsVisible, true)
            .Add(d => d.Title, "Edit Profile")
            .Add(d => d.Description, "Change your settings")
            .AddChildContent("Body"));

        Assert.Contains("Edit Profile", cut.Find(".nb-dialog__title").TextContent);
        Assert.Contains("Change your settings", cut.Find(".nb-dialog__description").TextContent);
    }

    [Fact]
    public void Close_Button_Shown_When_OnClose_Set()
    {
        var cut = Render<NBDialog>(p => p
            .Add(d => d.IsVisible, true)
            .Add(d => d.OnClose, () => { })
            .AddChildContent("Body"));

        Assert.NotEmpty(cut.FindAll(".nb-dialog__close"));
    }

    [Fact]
    public void No_Close_Button_Without_OnClose()
    {
        var cut = Render<NBDialog>(p => p
            .Add(d => d.IsVisible, true)
            .AddChildContent("Body"));

        Assert.Empty(cut.FindAll(".nb-dialog__close"));
    }

    [Fact]
    public void Renders_Footer()
    {
        var cut = Render<NBDialog>(p => p
            .Add(d => d.IsVisible, true)
            .Add(d => d.Footer, b => b.AddMarkupContent(0, "<button>Save</button>"))
            .AddChildContent("Body"));

        Assert.NotEmpty(cut.FindAll(".nb-dialog__footer"));
    }

    [Fact]
    public void Renders_ChildContent()
    {
        var cut = Render<NBDialog>(p => p
            .Add(d => d.IsVisible, true)
            .AddChildContent("Dialog body here"));

        Assert.Contains("Dialog body here", cut.Find(".nb-dialog__body").TextContent);
    }

    [Fact]
    public void No_Header_When_No_Title_Or_Description()
    {
        var cut = Render<NBDialog>(p => p
            .Add(d => d.IsVisible, true)
            .AddChildContent("Body"));

        Assert.Empty(cut.FindAll(".nb-dialog__header"));
    }

    [Fact]
    public void Has_Aria_Modal_True()
    {
        var cut = Render<NBDialog>(p => p
            .Add(d => d.IsVisible, true)
            .AddChildContent("Body"));

        Assert.Equal("true", cut.Find("[role='dialog']").GetAttribute("aria-modal"));
    }

    [Fact]
    public void Backdrop_Click_Fires_OnClose_When_CloseOnBackdrop()
    {
        var closed = false;
        var cut = Render<NBDialog>(p => p
            .Add(d => d.IsVisible, true)
            .Add(d => d.CloseOnBackdrop, true)
            .Add(d => d.OnClose, () => closed = true)
            .AddChildContent("Body"));

        cut.Find(".nb-dialog-backdrop").Click();

        Assert.True(closed);
    }

    [Fact]
    public void Backdrop_Click_Does_Not_Fire_When_Not_CloseOnBackdrop()
    {
        var closed = false;
        var cut = Render<NBDialog>(p => p
            .Add(d => d.IsVisible, true)
            .Add(d => d.CloseOnBackdrop, false)
            .Add(d => d.OnClose, () => closed = true)
            .AddChildContent("Body"));

        cut.Find(".nb-dialog-backdrop").Click();

        Assert.False(closed);
    }

    [Fact]
    public void No_Footer_When_Not_Provided()
    {
        var cut = Render<NBDialog>(p => p
            .Add(d => d.IsVisible, true)
            .AddChildContent("Body"));

        Assert.Empty(cut.FindAll(".nb-dialog__footer"));
    }
}
