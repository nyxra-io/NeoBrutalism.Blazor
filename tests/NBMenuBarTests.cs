using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBMenuBarTests : BunitContext
{
    [Fact]
    public void Renders_With_Menubar_Role()
    {
        var cut = Render<NBMenuBar>(p => p
            .AddChildContent("<div>Menu</div>"));

        Assert.NotNull(cut.Find("[role='menubar']"));
    }

    [Fact]
    public void MenuBarItem_Renders()
    {
        var cut = Render<NBMenuBarItem>(p => p
            .AddChildContent("Cut"));

        Assert.Contains("Cut", cut.Find("[role='menuitem']").TextContent);
    }

    [Fact]
    public void MenuBarItem_Shows_Shortcut()
    {
        var cut = Render<NBMenuBarItem>(p => p
            .AddChildContent("Copy")
            .Add(i => i.Shortcut, "⌘C"));

        Assert.Equal("⌘C", cut.Find(".nb-menubar__shortcut").TextContent);
    }

    [Fact]
    public void MenuBarItem_Disabled_Has_Class()
    {
        var cut = Render<NBMenuBarItem>(p => p
            .AddChildContent("Paste")
            .Add(i => i.Disabled, true));

        Assert.Contains("nb-menubar__item--disabled", cut.Find(".nb-menubar__item").GetAttribute("class"));
    }

    [Fact]
    public void MenuBarMenu_Toggle_Opens_Content()
    {
        var cut = Render<NBMenuBarMenu>(p => p
            .Add(m => m.Label, "File")
            .AddChildContent("<div class='item'>Open</div>"));

        cut.Find(".nb-menubar__trigger").Click();

        Assert.NotEmpty(cut.FindAll(".nb-menubar__content"));
    }

    [Fact]
    public void MenuBarLabel_Renders()
    {
        var cut = Render<NBMenuBarLabel>(p => p
            .AddChildContent("Section"));

        Assert.Equal("Section", cut.Find(".nb-menubar__label").TextContent);
    }

    [Fact]
    public void MenuBarSeparator_Renders()
    {
        var cut = Render<NBMenuBarSeparator>();

        Assert.NotNull(cut.Find("[role='separator']"));
    }

    [Fact]
    public void MenuBarShortcut_Renders()
    {
        var cut = Render<NBMenuBarShortcut>(p => p
            .AddChildContent("⌘K"));

        Assert.Equal("⌘K", cut.Find(".nb-menubar__shortcut").TextContent);
    }

    [Fact]
    public void MenuBarMenu_Toggle_Closes()
    {
        var cut = Render<NBMenuBarMenu>(p => p
            .Add(m => m.Label, "File")
            .AddChildContent("<div class='item'>Open</div>"));

        cut.Find(".nb-menubar__trigger").Click(); // open
        cut.Find(".nb-menubar__trigger").Click(); // close

        Assert.Empty(cut.FindAll(".nb-menubar__content"));
    }

    [Fact]
    public void MenuBarMenu_Has_Aria_Expanded()
    {
        var cut = Render<NBMenuBarMenu>(p => p
            .Add(m => m.Label, "File")
            .AddChildContent("<div>Open</div>"));

        Assert.NotNull(cut.Find("[aria-haspopup='true']"));
    }

    [Fact]
    public void MenuBarMenu_Content_Click_Closes()
    {
        var cut = Render<NBMenuBarMenu>(p => p
            .Add(m => m.Label, "File")
            .AddChildContent("<div class='item'>Open</div>"));

        cut.Find(".nb-menubar__trigger").Click();
        cut.Find(".nb-menubar__content").Click();

        Assert.Empty(cut.FindAll(".nb-menubar__content"));
    }

    [Fact]
    public void MenuBarItem_Click_Fires_OnClick()
    {
        var clicked = false;
        var cut = Render<NBMenuBarItem>(p => p
            .AddChildContent("Cut")
            .Add(i => i.OnClick, () => clicked = true));

        cut.Find(".nb-menubar__item").Click();

        Assert.True(clicked);
    }

    [Fact]
    public void MenuBarItem_Disabled_Does_Not_Fire()
    {
        var clicked = false;
        var cut = Render<NBMenuBarItem>(p => p
            .AddChildContent("Cut")
            .Add(i => i.Disabled, true)
            .Add(i => i.OnClick, () => clicked = true));

        cut.Find(".nb-menubar__item").Click();

        Assert.False(clicked);
    }

    [Fact]
    public void MenuBarItem_No_Shortcut_When_Not_Provided()
    {
        var cut = Render<NBMenuBarItem>(p => p
            .AddChildContent("Cut"));

        Assert.Empty(cut.FindAll(".nb-menubar__shortcut"));
    }
}
