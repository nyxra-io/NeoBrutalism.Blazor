using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBTitleTests : BunitContext
{
    [Theory]
    [InlineData(NBTitleVariant.Title, "H1", "nb-title--title")]
    [InlineData(NBTitleVariant.Subtitle, "P", "nb-title--subtitle")]
    [InlineData(NBTitleVariant.Section, "H2", "nb-title--section")]
    [InlineData(NBTitleVariant.SubSection, "H3", "nb-title--subsection")]
    public void Renders_Correct_Tag_And_Class(NBTitleVariant variant, string expectedTag, string expectedClass)
    {
        var cut = Render<NBTitle>(p => p
            .Add(t => t.Variant, variant)
            .AddChildContent("Title"));

        var el = cut.Find(".nb-title");
        Assert.Equal(expectedTag, el.TagName);
        Assert.Contains(expectedClass, el.GetAttribute("class"));
    }

    [Fact]
    public void Renders_ChildContent()
    {
        var cut = Render<NBTitle>(p => p
            .AddChildContent("Page Title"));

        Assert.Equal("Page Title", cut.Find(".nb-title").TextContent);
    }

    [Fact]
    public void Splatted_Attributes_Rendered()
    {
        var cut = Render<NBTitle>(p => p
            .AddUnmatched("id", "main-title")
            .AddChildContent("Title"));

        Assert.Equal("main-title", cut.Find(".nb-title").GetAttribute("id"));
    }
}
