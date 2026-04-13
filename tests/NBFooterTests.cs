using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBFooterTests : BunitContext
{
    [Fact]
    public void Renders_Copyright()
    {
        var cut = Render<NBFooter>(p => p
            .Add(f => f.Copyright, "© 2026 Acme Inc."));

        Assert.Equal("© 2026 Acme Inc.", cut.Find(".nb-footer__copyright").TextContent);
    }

    [Fact]
    public void Copyright_Not_Rendered_When_Null()
    {
        var cut = Render<NBFooter>();

        Assert.Empty(cut.FindAll(".nb-footer__copyright"));
    }

    [Fact]
    public void Renders_Columns_Slot()
    {
        var cut = Render<NBFooter>(p => p
            .Add(f => f.Columns, b => b.AddMarkupContent(0, "<div class=\"col\">Links</div>")));

        Assert.NotNull(cut.Find(".nb-footer__columns .col"));
    }

    [Fact]
    public void Columns_Not_Rendered_When_Null()
    {
        var cut = Render<NBFooter>(p => p
            .Add(f => f.Copyright, "©"));

        Assert.Empty(cut.FindAll(".nb-footer__columns"));
    }

    [Fact]
    public void Renders_Social_Slot()
    {
        var cut = Render<NBFooter>(p => p
            .Add(f => f.Social, b => b.AddMarkupContent(0, "<a href=\"#\">GitHub</a>")));

        Assert.NotNull(cut.Find(".nb-footer__social a"));
    }

    [Fact]
    public void Social_Not_Rendered_When_Null()
    {
        var cut = Render<NBFooter>(p => p
            .Add(f => f.Copyright, "©"));

        Assert.Empty(cut.FindAll(".nb-footer__social"));
    }

    [Fact]
    public void Renders_As_Footer_Element()
    {
        var cut = Render<NBFooter>(p => p
            .Add(f => f.Copyright, "©"));

        Assert.Equal("FOOTER", cut.Find(".nb-footer").TagName);
    }

    [Fact]
    public void FooterColumn_Renders_Title()
    {
        var cut = Render<NBFooterColumn>(p => p
            .Add(c => c.Title, "Product")
            .AddChildContent("<a href=\"#\">Features</a>"));

        Assert.Equal("Product", cut.Find(".nb-footer__column-title").TextContent);
    }

    [Fact]
    public void FooterColumn_Renders_ChildContent()
    {
        var cut = Render<NBFooterColumn>(p => p
            .AddChildContent("<a href=\"#\">About</a>"));

        Assert.Contains("About", cut.Find(".nb-footer__column").InnerHtml);
    }

    [Fact]
    public void FooterColumn_Title_Not_Rendered_When_Null()
    {
        var cut = Render<NBFooterColumn>(p => p
            .AddChildContent("links"));

        Assert.Empty(cut.FindAll(".nb-footer__column-title"));
    }
}
