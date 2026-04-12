using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBNavigationMenuTests : BunitContext
{
    [Fact]
    public void Renders_Nav_With_Role()
    {
        var cut = Render<NBNavigationMenu>(p => p
            .AddChildContent("<div>Items</div>"));

        Assert.NotNull(cut.Find("[role='navigation']"));
    }

    [Fact]
    public void NavigationMenuLink_Renders()
    {
        var cut = Render<NBNavigationMenuLink>(p => p
            .Add(l => l.Href, "/docs")
            .AddChildContent("Docs"));

        var link = cut.Find(".nb-nav-menu__link-item");
        Assert.Equal("/docs", link.GetAttribute("href"));
        Assert.Equal("Docs", link.TextContent);
    }

    [Fact]
    public void NavigationMenuItem_Renders_As_Link_When_No_Content()
    {
        var cut = Render<NBNavigationMenuItem>(p => p
            .Add(i => i.Label, "Home")
            .Add(i => i.Href, "/"));

        Assert.NotNull(cut.Find(".nb-nav-menu__link"));
        Assert.Equal("/", cut.Find(".nb-nav-menu__link").GetAttribute("href"));
    }

    [Fact]
    public void NavigationMenuItem_Renders_As_Button_When_Content()
    {
        var cut = Render<NBNavigationMenuItem>(p => p
            .Add(i => i.Label, "Resources")
            .Add(i => i.Content, b => b.AddMarkupContent(0, "<div>Sub items</div>")));

        Assert.NotNull(cut.Find(".nb-nav-menu__trigger"));
        Assert.Equal("menuitem", cut.Find(".nb-nav-menu__trigger").GetAttribute("role"));
    }

    [Fact]
    public void NavigationMenuItem_Toggle_Opens_Content()
    {
        var cut = Render<NBNavigationMenuItem>(p => p
            .Add(i => i.Label, "Resources")
            .Add(i => i.Content, b => b.AddMarkupContent(0, "<div class='sub'>Sub items</div>")));

        cut.Find(".nb-nav-menu__trigger").Click();

        Assert.NotEmpty(cut.FindAll(".nb-nav-menu__content"));
        Assert.Contains("nb-nav-menu__trigger--open", cut.Find(".nb-nav-menu__trigger").GetAttribute("class"));
    }

    [Fact]
    public void NavigationMenuItem_Toggle_Closes_Content()
    {
        var cut = Render<NBNavigationMenuItem>(p => p
            .Add(i => i.Label, "Resources")
            .Add(i => i.Content, b => b.AddMarkupContent(0, "<div>Sub</div>")));

        cut.Find(".nb-nav-menu__trigger").Click();
        cut.Find(".nb-nav-menu__trigger").Click();

        Assert.Empty(cut.FindAll(".nb-nav-menu__content"));
    }

    [Fact]
    public void NavigationMenuItem_Has_Aria_Expanded()
    {
        var cut = Render<NBNavigationMenuItem>(p => p
            .Add(i => i.Label, "Resources")
            .Add(i => i.Content, b => b.AddMarkupContent(0, "<div>Sub</div>")));

        Assert.NotNull(cut.Find("[aria-haspopup='true']"));
    }
}
