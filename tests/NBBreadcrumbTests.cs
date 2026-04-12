using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBBreadcrumbTests : BunitContext
{
    [Fact]
    public void Renders_All_Items()
    {
        var items = new List<NBBreadcrumbItem>
        {
            new("Home", "/"),
            new("Products", "/products"),
            new("Widget")
        };

        var cut = Render<NBBreadcrumb>(p => p
            .Add(b => b.Items, items));

        var listItems = cut.FindAll(".nb-breadcrumb__item");
        Assert.Equal(3, listItems.Count);
    }

    [Fact]
    public void Last_Item_Has_Aria_Current()
    {
        var items = new List<NBBreadcrumbItem>
        {
            new("Home", "/"),
            new("Current")
        };

        var cut = Render<NBBreadcrumb>(p => p
            .Add(b => b.Items, items));

        var page = cut.Find("[aria-current='page']");
        Assert.Equal("Current", page.TextContent);
    }

    [Fact]
    public void Non_Last_Items_With_Href_Are_Links()
    {
        var items = new List<NBBreadcrumbItem>
        {
            new("Home", "/"),
            new("End")
        };

        var cut = Render<NBBreadcrumb>(p => p
            .Add(b => b.Items, items));

        var link = cut.Find(".nb-breadcrumb__link");
        Assert.Equal("A", link.TagName);
        Assert.Equal("/", link.GetAttribute("href"));
    }

    [Fact]
    public void Has_Nav_With_Aria_Label()
    {
        var cut = Render<NBBreadcrumb>(p => p
            .Add(b => b.Items, new List<NBBreadcrumbItem> { new("X") }));

        Assert.Equal("breadcrumb", cut.Find("nav").GetAttribute("aria-label"));
    }

    [Fact]
    public void Separators_Rendered_Between_Items()
    {
        var items = new List<NBBreadcrumbItem>
        {
            new("A", "/a"),
            new("B", "/b"),
            new("C")
        };

        var cut = Render<NBBreadcrumb>(p => p
            .Add(b => b.Items, items));

        var separators = cut.FindAll(".nb-breadcrumb__separator");
        Assert.Equal(2, separators.Count);
    }
}
