using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBThemeProviderTests : BunitContext
{
    [Fact]
    public void Renders_ChildContent()
    {
        var cut = Render<NBThemeProvider>(p => p
            .Add(t => t.Theme, new NBTheme())
            .AddChildContent("<p>Themed</p>"));

        Assert.Contains("Themed", cut.Markup);
    }

    [Fact]
    public void Applies_Css_Variables_From_Theme()
    {
        var theme = new NBTheme
        {
            Primary = "#ff0000",
            Background = "#eee"
        };

        var cut = Render<NBThemeProvider>(p => p
            .Add(t => t.Theme, theme)
            .AddChildContent("Content"));

        var style = cut.Find("div").GetAttribute("style");
        Assert.Contains("--nb-primary: #ff0000", style);
        Assert.Contains("--nb-bg: #eee", style);
    }

    [Fact]
    public void Only_Non_Null_Tokens_Emitted()
    {
        var theme = new NBTheme
        {
            Primary = "#123456"
        };

        var cut = Render<NBThemeProvider>(p => p
            .Add(t => t.Theme, theme)
            .AddChildContent("Content"));

        var style = cut.Find("div").GetAttribute("style")!;
        Assert.Contains("--nb-primary", style);
        Assert.DoesNotContain("--nb-bg", style);
        Assert.DoesNotContain("--nb-danger", style);
    }

    [Fact]
    public void All_Tokens_Emitted_When_Set()
    {
        var theme = new NBTheme
        {
            Black = "#000",
            White = "#fff",
            Background = "#faf5e8",
            BackgroundDark = "#e8e0d0",
            Primary = "#ff6b2b",
            PrimaryHover = "#e55a1f",
            Danger = "#ff4444",
            DangerHover = "#cc3333",
            Success = "#22c55e",
            Muted = "#6b7280",
            Border = "2px solid #000",
            Shadow = "4px 4px 0 #000",
            ShadowSm = "2px 2px 0 #000",
            Radius = "0",
            Font = "Inter"
        };

        var cut = Render<NBThemeProvider>(p => p
            .Add(t => t.Theme, theme)
            .AddChildContent("Content"));

        var style = cut.Find("div").GetAttribute("style")!;
        Assert.Contains("--nb-black", style);
        Assert.Contains("--nb-white", style);
        Assert.Contains("--nb-shadow-sm", style);
        Assert.Contains("--nb-font", style);
    }
}

public class NBThemeTests
{
    [Fact]
    public void Theme_Properties_Can_Be_Set()
    {
        var theme = new NBTheme
        {
            Primary = "#abc",
            Danger = "#def"
        };

        Assert.Equal("#abc", theme.Primary);
        Assert.Equal("#def", theme.Danger);
    }

    [Fact]
    public void Theme_Defaults_Are_Null()
    {
        var theme = new NBTheme();

        Assert.Null(theme.Primary);
        Assert.Null(theme.Danger);
        Assert.Null(theme.Background);
    }
}
