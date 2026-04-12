using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBCheckboxTests : BunitContext
{
    [Fact]
    public void Renders_Label_And_Input()
    {
        var cut = Render<NBCheckbox>(p => p
            .Add(c => c.Id, "chk1")
            .Add(c => c.Label, "Accept terms"));

        var input = cut.Find("input[type='checkbox']");
        var label = cut.Find("label");

        Assert.Equal("chk1", input.GetAttribute("id"));
        Assert.Equal("chk1", label.GetAttribute("for"));
        Assert.Equal("Accept terms", label.TextContent);
    }

    [Fact]
    public void Disabled_Attribute_Rendered()
    {
        var cut = Render<NBCheckbox>(p => p
            .Add(c => c.Id, "chk1")
            .Add(c => c.Label, "lbl")
            .Add(c => c.Disabled, true));

        Assert.NotNull(cut.Find("input").GetAttribute("disabled"));
    }

    [Fact]
    public void CheckedChanged_Fires_On_Change()
    {
        var newValue = false;
        var cut = Render<NBCheckbox>(p => p
            .Add(c => c.Id, "chk1")
            .Add(c => c.Label, "lbl")
            .Add(c => c.CheckedChanged, (bool v) => newValue = v));

        cut.Find("input").Change(true);

        Assert.True(newValue);
    }
}
