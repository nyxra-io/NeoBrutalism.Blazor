using Bunit;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBTabsTests : BunitContext
{
    private static IReadOnlyList<NBTabItem> CreateItems() =>
    [
        new("tab1", "Tab 1", (RenderFragment)(b => b.AddContent(0, "Content 1"))),
        new("tab2", "Tab 2", (RenderFragment)(b => b.AddContent(0, "Content 2"))),
        new("tab3", "Tab 3", (RenderFragment)(b => b.AddContent(0, "Content 3")))
    ];

    [Fact]
    public void Renders_Tab_Triggers()
    {
        var cut = Render<NBTabs>(p => p
            .Add(t => t.Items, CreateItems()));

        var triggers = cut.FindAll("[role='tab']");
        Assert.Equal(3, triggers.Count);
    }

    [Fact]
    public void Active_Tab_Has_Active_Class()
    {
        var cut = Render<NBTabs>(p => p
            .Add(t => t.Items, CreateItems())
            .Add(t => t.ActiveKey, "tab2"));

        var active = cut.Find(".nb-tabs-trigger--active");
        Assert.Contains("Tab 2", active.TextContent);
    }

    [Fact]
    public void Shows_Content_Of_Active_Tab()
    {
        var cut = Render<NBTabs>(p => p
            .Add(t => t.Items, CreateItems())
            .Add(t => t.ActiveKey, "tab2"));

        Assert.Contains("Content 2", cut.Find("[role='tabpanel']").TextContent);
    }

    [Fact]
    public void Clicking_Tab_Fires_ActiveKeyChanged()
    {
        var activeKey = "";
        var cut = Render<NBTabs>(p => p
            .Add(t => t.Items, CreateItems())
            .Add(t => t.ActiveKey, "tab1")
            .Add(t => t.ActiveKeyChanged, (string k) => activeKey = k));

        cut.FindAll("[role='tab']")[1].Click();

        Assert.Equal("tab2", activeKey);
    }

    [Fact]
    public void Defaults_To_First_Tab_If_No_ActiveKey()
    {
        var cut = Render<NBTabs>(p => p
            .Add(t => t.Items, CreateItems()));

        Assert.Contains("Content 1", cut.Find("[role='tabpanel']").TextContent);
    }

    [Fact]
    public void Has_Tablist_Role()
    {
        var cut = Render<NBTabs>(p => p
            .Add(t => t.Items, CreateItems()));

        Assert.NotNull(cut.Find("[role='tablist']"));
    }
}
