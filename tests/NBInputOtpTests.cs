using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBInputOtpTests : BunitContext
{
    [Fact]
    public void Renders_Correct_Number_Of_Slots()
    {
        var cut = Render<NBInputOtp>(p => p
            .Add(o => o.Length, 4));

        Assert.Equal(4, cut.FindAll(".nb-input-otp__slot").Count);
    }

    [Fact]
    public void Default_Length_Is_6()
    {
        var cut = Render<NBInputOtp>();

        Assert.Equal(6, cut.FindAll(".nb-input-otp__slot").Count);
    }

    [Fact]
    public void Disabled_Has_Class()
    {
        var cut = Render<NBInputOtp>(p => p
            .Add(o => o.Disabled, true));

        Assert.Contains("nb-input-otp--disabled", cut.Find(".nb-input-otp").GetAttribute("class"));
    }

    [Fact]
    public void Renders_Hidden_Inputs()
    {
        var cut = Render<NBInputOtp>(p => p
            .Add(o => o.Length, 4));

        Assert.Equal(4, cut.FindAll(".nb-input-otp__hidden-input").Count);
    }
}
