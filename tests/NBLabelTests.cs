using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBLabelTests : BunitContext
{
    [Fact]
    public void Renders_Label_With_For()
    {
        var cut = Render<NBLabel>(p => p
            .Add(l => l.For, "email")
            .AddChildContent("Email"));

        var label = cut.Find(".nb-label");
        Assert.Equal("email", label.GetAttribute("for"));
        Assert.Equal("Email", label.TextContent);
    }

    [Fact]
    public void Renders_As_Label_Element()
    {
        var cut = Render<NBLabel>(p => p
            .AddChildContent("Text"));

        Assert.Equal("LABEL", cut.Find(".nb-label").TagName);
    }
}
