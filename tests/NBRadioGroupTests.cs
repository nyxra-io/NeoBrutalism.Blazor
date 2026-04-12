using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBRadioGroupTests : BunitContext
{
    private static readonly NBRadioOption[] _options =
    [
        new("a", "Option A"),
        new("b", "Option B"),
        new("c", "Option C", Disabled: true)
    ];

    [Fact]
    public void Renders_All_Options()
    {
        var cut = Render<NBRadioGroup>(p => p
            .Add(r => r.Options, _options));

        Assert.Equal(3, cut.FindAll(".nb-radio-item").Count);
    }

    [Fact]
    public void Selected_Option_Has_Checked_Class()
    {
        var cut = Render<NBRadioGroup>(p => p
            .Add(r => r.Options, _options)
            .Add(r => r.Value, "a"));

        Assert.NotEmpty(cut.FindAll(".nb-radio-button--checked"));
    }

    [Fact]
    public void Disabled_Option_Has_Class()
    {
        var cut = Render<NBRadioGroup>(p => p
            .Add(r => r.Options, _options));

        Assert.NotEmpty(cut.FindAll(".nb-radio-item--disabled"));
    }

    [Fact]
    public void ValueChanged_Fires_On_Change()
    {
        string? selected = null;
        var cut = Render<NBRadioGroup>(p => p
            .Add(r => r.Options, _options)
            .Add(r => r.ValueChanged, (string? v) => selected = v));

        cut.FindAll("input[type='radio']")[1].Change("b");

        Assert.Equal("b", selected);
    }

    [Fact]
    public void Has_Radiogroup_Role()
    {
        var cut = Render<NBRadioGroup>(p => p
            .Add(r => r.Options, _options));

        Assert.NotNull(cut.Find("[role='radiogroup']"));
    }
}
