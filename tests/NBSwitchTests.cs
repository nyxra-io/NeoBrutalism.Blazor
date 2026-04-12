using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBSwitchTests : BunitContext
{
    [Fact]
    public void Renders_Label_When_Provided()
    {
        var cut = Render<NBSwitch>(p => p
            .Add(s => s.Label, "Dark mode"));

        Assert.Equal("Dark mode", cut.Find(".nb-switch__label").TextContent);
    }

    [Fact]
    public void Label_Not_Rendered_When_Empty()
    {
        var cut = Render<NBSwitch>();

        Assert.Empty(cut.FindAll(".nb-switch__label"));
    }

    [Fact]
    public void Disabled_Adds_CssClass()
    {
        var cut = Render<NBSwitch>(p => p
            .Add(s => s.Disabled, true));

        Assert.Contains("nb-switch--disabled", cut.Find("label").GetAttribute("class"));
    }

    [Fact]
    public void CheckedChanged_Fires_On_Toggle()
    {
        var newValue = false;
        var cut = Render<NBSwitch>(p => p
            .Add(s => s.CheckedChanged, (bool v) => newValue = v));

        cut.Find("input").Change(true);

        Assert.True(newValue);
    }
}
