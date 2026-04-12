using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBAlertTests : BunitContext
{
    [Fact]
    public void Renders_Body_Text()
    {
        var cut = Render<NBAlert>(p => p
            .Add(a => a.Body, "Something happened"));

        Assert.Contains("Something happened", cut.Markup);
    }

    [Fact]
    public void Renders_Title_When_Provided()
    {
        var cut = Render<NBAlert>(p => p
            .Add(a => a.Body, "body")
            .Add(a => a.Title, "Heads up!"));

        var title = cut.Find(".nb-alert__title");
        Assert.Equal("Heads up!", title.TextContent);
    }

    [Fact]
    public void Title_Not_Rendered_When_Null()
    {
        var cut = Render<NBAlert>(p => p
            .Add(a => a.Body, "body"));

        Assert.Empty(cut.FindAll(".nb-alert__title"));
    }

    [Theory]
    [InlineData(NBAlertVariant.Default, "nb-alert--default")]
    [InlineData(NBAlertVariant.Destructive, "nb-alert--destructive")]
    [InlineData(NBAlertVariant.Info, "nb-alert--info")]
    [InlineData(NBAlertVariant.Success, "nb-alert--success")]
    [InlineData(NBAlertVariant.Warning, "nb-alert--warning")]
    [InlineData(NBAlertVariant.Error, "nb-alert--error")]
    public void Applies_Variant_CssClass(NBAlertVariant variant, string expectedClass)
    {
        var cut = Render<NBAlert>(p => p
            .Add(a => a.Body, "msg")
            .Add(a => a.Variant, variant));

        Assert.Contains(expectedClass, cut.Find(".nb-alert").GetAttribute("class"));
    }

    [Fact]
    public void Has_Role_Alert()
    {
        var cut = Render<NBAlert>(p => p
            .Add(a => a.Body, "msg"));

        Assert.Equal("alert", cut.Find(".nb-alert").GetAttribute("role"));
    }

    [Fact]
    public void Renders_Icon_When_Provided()
    {
        var cut = Render<NBAlert>(p => p
            .Add(a => a.Body, "msg")
            .Add(a => a.Icon, b => b.AddMarkupContent(0, "<svg id=\"ico\"></svg>")));

        Assert.NotNull(cut.Find(".nb-alert__icon #ico"));
    }

    [Fact]
    public void Icon_Not_Rendered_When_Null()
    {
        var cut = Render<NBAlert>(p => p
            .Add(a => a.Body, "msg"));

        Assert.Empty(cut.FindAll(".nb-alert__icon"));
    }
}
