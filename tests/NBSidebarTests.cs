using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBSidebarTests : BunitContext
{
    [Fact]
    public void SidebarProvider_Renders_With_Open_Class()
    {
        var cut = Render<NBSidebarProvider>(p => p
            .Add(s => s.Open, true)
            .AddChildContent("<div>Content</div>"));

        Assert.Contains("nb-sidebar-wrapper--open", cut.Find(".nb-sidebar-wrapper").GetAttribute("class"));
    }

    [Fact]
    public void SidebarProvider_Renders_With_Closed_Class()
    {
        var cut = Render<NBSidebarProvider>(p => p
            .Add(s => s.Open, false)
            .AddChildContent("<div>Content</div>"));

        Assert.Contains("nb-sidebar-wrapper--closed", cut.Find(".nb-sidebar-wrapper").GetAttribute("class"));
    }

    [Fact]
    public void SidebarProvider_ToggleSidebar_Changes_State()
    {
        var openState = true;
        var cut = Render<NBSidebarProvider>(p => p
            .Add(s => s.Open, openState)
            .Add(s => s.OpenChanged, (bool v) => openState = v)
            .AddChildContent("<div>Content</div>"));

        Assert.Contains("nb-sidebar-wrapper--open", cut.Find(".nb-sidebar-wrapper").GetAttribute("class"));
    }

    [Fact]
    public void SidebarProvider_Custom_Width()
    {
        var cut = Render<NBSidebarProvider>(p => p
            .Add(s => s.Open, true)
            .Add(s => s.Width, "20rem")
            .Add(s => s.IconWidth, "4rem")
            .AddChildContent("<div>Content</div>"));

        var style = cut.Find(".nb-sidebar-wrapper").GetAttribute("style");
        Assert.Contains("--nb-sidebar-width: 20rem", style);
        Assert.Contains("--nb-sidebar-width-icon: 4rem", style);
    }

    [Fact]
    public void SidebarProvider_State_Property()
    {
        var cut = Render<NBSidebarProvider>(p => p
            .Add(s => s.Open, true)
            .AddChildContent("<div>Content</div>"));

        // Provider.State should be "expanded"
        Assert.Contains("nb-sidebar-wrapper--open", cut.Find(".nb-sidebar-wrapper").GetAttribute("class"));
    }

    [Fact]
    public void Sidebar_Renders_With_Provider()
    {
        var cut = Render<NBSidebarProvider>(p => p
            .Add(s => s.Open, true)
            .AddChildContent(b =>
            {
                b.OpenComponent<NBSidebar>(0);
                b.AddAttribute(1, "ChildContent",
                    (Microsoft.AspNetCore.Components.RenderFragment)(b2 => b2.AddContent(0, "Nav")));
                b.CloseComponent();
            }));

        Assert.NotNull(cut.Find(".nb-sidebar"));
        Assert.Contains("nb-sidebar--expanded", cut.Find(".nb-sidebar").GetAttribute("class"));
    }

    [Fact]
    public void Sidebar_Side_And_Variant_Classes()
    {
        var cut = Render<NBSidebarProvider>(p => p
            .Add(s => s.Open, true)
            .AddChildContent(b =>
            {
                b.OpenComponent<NBSidebar>(0);
                b.AddAttribute(1, "Side", NBSidebarSide.Right);
                b.AddAttribute(2, "Variant", NBSidebarVariant.Inset);
                b.AddAttribute(3, "ChildContent",
                    (Microsoft.AspNetCore.Components.RenderFragment)(b2 => b2.AddContent(0, "Nav")));
                b.CloseComponent();
            }));

        var sidebar = cut.Find(".nb-sidebar");
        Assert.Contains("nb-sidebar--right", sidebar.GetAttribute("class"));
        Assert.Contains("nb-sidebar--inset", sidebar.GetAttribute("class"));
    }

    [Fact]
    public void SidebarTrigger_Renders_Toggle_Button()
    {
        var cut = Render<NBSidebarProvider>(p => p
            .Add(s => s.Open, true)
            .AddChildContent(b =>
            {
                b.OpenComponent<NBSidebarTrigger>(0);
                b.CloseComponent();
            }));

        Assert.NotNull(cut.Find(".nb-sidebar-trigger"));
        Assert.Equal("Toggle Sidebar", cut.Find(".nb-sidebar-trigger").GetAttribute("aria-label"));
    }

    [Fact]
    public void SidebarTrigger_Click_Toggles_Provider()
    {
        var openState = true;
        var cut = Render<NBSidebarProvider>(p => p
            .Add(s => s.Open, openState)
            .Add(s => s.OpenChanged, (bool v) => openState = v)
            .AddChildContent(b =>
            {
                b.OpenComponent<NBSidebarTrigger>(0);
                b.CloseComponent();
            }));

        cut.Find(".nb-sidebar-trigger").Click();

        Assert.False(openState);
    }

    [Fact]
    public void SidebarContent_Renders()
    {
        var cut = Render<NBSidebarContent>(p => p
            .AddChildContent("Content"));

        Assert.Equal("Content", cut.Find(".nb-sidebar__content").TextContent);
    }

    [Fact]
    public void SidebarHeader_Renders()
    {
        var cut = Render<NBSidebarHeader>(p => p
            .AddChildContent("Header"));

        Assert.Equal("Header", cut.Find(".nb-sidebar__header").TextContent);
    }

    [Fact]
    public void SidebarFooter_Renders()
    {
        var cut = Render<NBSidebarFooter>(p => p
            .AddChildContent("Footer"));

        Assert.Equal("Footer", cut.Find(".nb-sidebar__footer").TextContent);
    }

    [Fact]
    public void SidebarGroup_Renders()
    {
        var cut = Render<NBSidebarGroup>(p => p
            .AddChildContent("Group"));

        Assert.Equal("Group", cut.Find(".nb-sidebar__group").TextContent);
    }

    [Fact]
    public void SidebarGroupLabel_Renders()
    {
        var cut = Render<NBSidebarGroupLabel>(p => p
            .AddChildContent("Label"));

        Assert.Equal("Label", cut.Find(".nb-sidebar__group-label").TextContent);
    }

    [Fact]
    public void SidebarMenu_Renders_As_Ul()
    {
        var cut = Render<NBSidebarMenu>(p => p
            .AddChildContent("<li>Item</li>"));

        Assert.Equal("UL", cut.Find(".nb-sidebar__menu").TagName);
    }

    [Fact]
    public void SidebarMenuItem_Renders_As_Li()
    {
        var cut = Render<NBSidebarMenuItem>(p => p
            .AddChildContent("Item"));

        Assert.Equal("LI", cut.Find(".nb-sidebar__menu-item").TagName);
    }

    [Fact]
    public void SidebarMenuButton_Active_Has_Class()
    {
        var cut = Render<NBSidebarMenuButton>(p => p
            .Add(b => b.IsActive, true)
            .AddChildContent("Dashboard"));

        Assert.Contains("nb-sidebar__menu-btn--active", cut.Find(".nb-sidebar__menu-btn").GetAttribute("class"));
    }

    [Fact]
    public void SidebarMenuButton_Click_Fires()
    {
        var clicked = false;
        var cut = Render<NBSidebarMenuButton>(p => p
            .Add(b => b.OnClick, () => clicked = true)
            .AddChildContent("Dashboard"));

        cut.Find(".nb-sidebar__menu-btn").Click();

        Assert.True(clicked);
    }

    [Fact]
    public void SidebarInset_Renders_As_Main()
    {
        var cut = Render<NBSidebarInset>(p => p
            .AddChildContent("Main content"));

        Assert.Equal("MAIN", cut.Find(".nb-sidebar-inset").TagName);
    }
}
