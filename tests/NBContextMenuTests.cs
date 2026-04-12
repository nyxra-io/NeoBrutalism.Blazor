using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBContextMenuTests : BunitContext
{
    [Fact]
    public void Menu_Not_Visible_By_Default()
    {
        var cut = Render<NBContextMenu>(p => p
            .AddChildContent("<span>Right click me</span>")
            .Add(c => c.MenuContent, b => b.AddMarkupContent(0, "<div>Menu</div>")));

        Assert.Empty(cut.FindAll(".nb-context-menu"));
    }

    [Fact]
    public void ContextMenuItem_Renders_Content()
    {
        var cut = Render<NBContextMenuItem>(p => p
            .AddChildContent("Copy"));

        Assert.Contains("Copy", cut.Find(".nb-context-menu__item").TextContent);
    }

    [Fact]
    public void ContextMenuItem_Shows_Shortcut()
    {
        var cut = Render<NBContextMenuItem>(p => p
            .AddChildContent("Copy")
            .Add(c => c.Shortcut, "⌘C"));

        Assert.Equal("⌘C", cut.Find(".nb-context-menu__shortcut").TextContent);
    }

    [Fact]
    public void ContextMenuItem_Disabled_Has_Class()
    {
        var cut = Render<NBContextMenuItem>(p => p
            .AddChildContent("Paste")
            .Add(c => c.Disabled, true));

        Assert.Contains("nb-context-menu__item--disabled", cut.Find(".nb-context-menu__item").GetAttribute("class"));
    }

    [Fact]
    public void ContextMenuLabel_Renders()
    {
        var cut = Render<NBContextMenuLabel>(p => p
            .AddChildContent("Actions"));

        Assert.Equal("Actions", cut.Find(".nb-context-menu__label").TextContent);
    }

    [Fact]
    public void ContextMenuSeparator_Renders()
    {
        var cut = Render<NBContextMenuSeparator>();

        Assert.NotNull(cut.Find("[role='separator']"));
    }

    [Fact]
    public void Menu_Opens_On_ContextMenu_Event()
    {
        var cut = Render<NBContextMenu>(p => p
            .AddChildContent("<span>Right click me</span>")
            .Add(c => c.MenuContent, b => b.AddMarkupContent(0, "<div class='menu-inner'>Menu</div>")));

        cut.Find(".nb-context-menu-wrap").TriggerEvent("oncontextmenu",
            new Microsoft.AspNetCore.Components.Web.MouseEventArgs { ClientX = 100, ClientY = 200 });

        Assert.NotEmpty(cut.FindAll(".nb-context-menu"));
    }

    [Fact]
    public void Menu_Closes_On_Backdrop_Click()
    {
        var cut = Render<NBContextMenu>(p => p
            .AddChildContent("<span>Right click me</span>")
            .Add(c => c.MenuContent, b => b.AddMarkupContent(0, "<div>Menu</div>")));

        cut.Find(".nb-context-menu-wrap").TriggerEvent("oncontextmenu",
            new Microsoft.AspNetCore.Components.Web.MouseEventArgs { ClientX = 100, ClientY = 200 });

        cut.Find(".nb-context-menu-backdrop").Click();

        Assert.Empty(cut.FindAll(".nb-context-menu"));
    }

    [Fact]
    public void ContextMenuItem_Click_Fires_OnClick()
    {
        var clicked = false;
        var cut = Render<NBContextMenuItem>(p => p
            .AddChildContent("Copy")
            .Add(c => c.OnClick, () => clicked = true));

        cut.Find(".nb-context-menu__item").Click();

        Assert.True(clicked);
    }

    [Fact]
    public void ContextMenuItem_Click_Does_Not_Fire_When_Disabled()
    {
        var clicked = false;
        var cut = Render<NBContextMenuItem>(p => p
            .AddChildContent("Copy")
            .Add(c => c.Disabled, true)
            .Add(c => c.OnClick, () => clicked = true));

        cut.Find(".nb-context-menu__item").Click();

        Assert.False(clicked);
    }

    [Fact]
    public void ContextMenuItem_Has_MenuItemRole()
    {
        var cut = Render<NBContextMenuItem>(p => p
            .AddChildContent("Copy"));

        Assert.NotNull(cut.Find("[role='menuitem']"));
    }

    [Fact]
    public void ContextMenuItem_No_Shortcut_When_Not_Provided()
    {
        var cut = Render<NBContextMenuItem>(p => p
            .AddChildContent("Copy"));

        Assert.Empty(cut.FindAll(".nb-context-menu__shortcut"));
    }
}
