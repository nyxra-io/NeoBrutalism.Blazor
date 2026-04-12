using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBCardTests : BunitContext
{
    [Fact]
    public void Renders_ChildContent()
    {
        var cut = Render<NBCard>(p => p
            .AddChildContent("<p>Card body</p>"));

        Assert.Contains("Card body", cut.Find(".nb-card").InnerHtml);
    }

    [Fact]
    public void Clickable_When_OnClick_Set()
    {
        var cut = Render<NBCard>(p => p
            .Add(c => c.OnClick, () => { })
            .AddChildContent("click"));

        Assert.Contains("nb-card--clickable", cut.Find(".nb-card").GetAttribute("class"));
    }

    [Fact]
    public void Not_Clickable_By_Default()
    {
        var cut = Render<NBCard>(p => p
            .AddChildContent("text"));

        Assert.DoesNotContain("nb-card--clickable", cut.Find(".nb-card").GetAttribute("class")!);
    }

    [Fact]
    public void CardHeader_Renders()
    {
        var cut = Render<NBCardHeader>(p => p
            .AddChildContent("Header"));

        Assert.Equal("Header", cut.Find(".nb-card__header").TextContent);
    }

    [Fact]
    public void CardTitle_Renders()
    {
        var cut = Render<NBCardTitle>(p => p
            .AddChildContent("Title"));

        Assert.Equal("Title", cut.Find(".nb-card__title").TextContent);
    }

    [Fact]
    public void CardDescription_Renders()
    {
        var cut = Render<NBCardDescription>(p => p
            .AddChildContent("Desc"));

        Assert.Equal("Desc", cut.Find(".nb-card__description").TextContent);
    }

    [Fact]
    public void CardContent_Renders()
    {
        var cut = Render<NBCardContent>(p => p
            .AddChildContent("Content"));

        Assert.Equal("Content", cut.Find(".nb-card__content").TextContent);
    }

    [Fact]
    public void CardFooter_Renders()
    {
        var cut = Render<NBCardFooter>(p => p
            .AddChildContent("Footer"));

        Assert.Equal("Footer", cut.Find(".nb-card__footer").TextContent);
    }

    [Fact]
    public void CardAction_Renders()
    {
        var cut = Render<NBCardAction>(p => p
            .AddChildContent("Action"));

        Assert.Equal("Action", cut.Find(".nb-card__action").TextContent);
    }
}
