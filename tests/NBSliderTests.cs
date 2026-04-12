using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBSliderTests : BunitContext
{
    [Fact]
    public void Renders_Range_Input()
    {
        var cut = Render<NBSlider>(p => p
            .Add(s => s.Value, 50));

        Assert.NotNull(cut.Find("input[type='range']"));
    }

    [Fact]
    public void Renders_Label_When_Provided()
    {
        var cut = Render<NBSlider>(p => p
            .Add(s => s.Value, 50)
            .Add(s => s.Label, "Volume"));

        Assert.Contains("Volume", cut.Markup);
    }

    [Theory]
    [InlineData(NBSliderOrientation.Horizontal, "nb-slider--horizontal")]
    [InlineData(NBSliderOrientation.Vertical, "nb-slider--vertical")]
    public void Applies_Orientation_Class(NBSliderOrientation orientation, string expectedClass)
    {
        var cut = Render<NBSlider>(p => p
            .Add(s => s.Value, 50)
            .Add(s => s.Orientation, orientation));

        Assert.Contains(expectedClass, cut.Markup);
    }

    [Fact]
    public void Disabled_Has_Class()
    {
        var cut = Render<NBSlider>(p => p
            .Add(s => s.Value, 50)
            .Add(s => s.Disabled, true));

        Assert.Contains("nb-slider--disabled", cut.Markup);
    }

    [Fact]
    public void Multi_Thumb_Renders_Two_Inputs()
    {
        var cut = Render<NBSlider>(p => p
            .Add(s => s.Values, new double[] { 20, 80 }));

        Assert.Equal(2, cut.FindAll("input[type='range']").Count);
    }

    [Fact]
    public void Single_Input_Fires_ValueChanged()
    {
        double? changed = null;
        var cut = Render<NBSlider>(p => p
            .Add(s => s.Value, 50)
            .Add(s => s.ValueChanged, (double v) => changed = v));

        cut.Find("input[type='range']").Input("75");

        Assert.Equal(75, changed);
    }

    [Fact]
    public void Range_Style_Set_For_Single_Horizontal()
    {
        var cut = Render<NBSlider>(p => p
            .Add(s => s.Value, 50)
            .Add(s => s.Orientation, NBSliderOrientation.Horizontal));

        var style = cut.Find(".nb-slider__range").GetAttribute("style");
        Assert.Contains("left:0", style);
    }

    [Fact]
    public void Range_Style_Set_For_Single_Vertical()
    {
        var cut = Render<NBSlider>(p => p
            .Add(s => s.Value, 50)
            .Add(s => s.Orientation, NBSliderOrientation.Vertical));

        var style = cut.Find(".nb-slider__range").GetAttribute("style");
        Assert.Contains("bottom:0", style);
    }

    [Fact]
    public void Multi_Thumb_Range_Style()
    {
        var cut = Render<NBSlider>(p => p
            .Add(s => s.Values, new double[] { 25, 75 }));

        var style = cut.Find(".nb-slider__range").GetAttribute("style");
        Assert.Contains("left:", style);
        Assert.Contains("right:", style);
    }

    [Fact]
    public void No_Label_When_Not_Provided()
    {
        var cut = Render<NBSlider>(p => p
            .Add(s => s.Value, 50));

        // Should not contain any label element
        Assert.Empty(cut.FindAll(".nb-label"));
    }

    [Fact]
    public void Min_Max_Step_Applied()
    {
        var cut = Render<NBSlider>(p => p
            .Add(s => s.Value, 5)
            .Add(s => s.Min, 0)
            .Add(s => s.Max, 10)
            .Add(s => s.Step, 2));

        var input = cut.Find("input[type='range']");
        Assert.Equal("0", input.GetAttribute("min"));
        Assert.Equal("10", input.GetAttribute("max"));
        Assert.Equal("2", input.GetAttribute("step"));
    }
}
