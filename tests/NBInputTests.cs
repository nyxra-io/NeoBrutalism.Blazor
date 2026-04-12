using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBInputTests : BunitContext
{
    [Fact]
    public void Renders_Label_And_Input()
    {
        var cut = Render<NBInput>(p => p
            .Add(i => i.Id, "email")
            .Add(i => i.Label, "Email"));

        var input = cut.Find("input");
        Assert.Equal("email", input.GetAttribute("id"));
        Assert.Equal("text", input.GetAttribute("type"));
    }

    [Theory]
    [InlineData(NBInputType.Email, "email")]
    [InlineData(NBInputType.Password, "password")]
    [InlineData(NBInputType.Number, "number")]
    [InlineData(NBInputType.Tel, "tel")]
    [InlineData(NBInputType.Url, "url")]
    [InlineData(NBInputType.Search, "search")]
    public void Applies_Input_Type(NBInputType type, string expectedHtmlType)
    {
        var cut = Render<NBInput>(p => p
            .Add(i => i.Id, "field")
            .Add(i => i.Label, "Field")
            .Add(i => i.Type, type));

        Assert.Equal(expectedHtmlType, cut.Find("input").GetAttribute("type"));
    }

    [Fact]
    public void Shows_Error_Message()
    {
        var cut = Render<NBInput>(p => p
            .Add(i => i.Id, "field")
            .Add(i => i.Label, "Field")
            .Add(i => i.ErrorMessage, "Required"));

        var error = cut.Find(".nb-field-error");
        Assert.Equal("Required", error.TextContent);
        Assert.Contains("nb-input--error", cut.Find("input").GetAttribute("class"));
    }

    [Fact]
    public void Shows_Subtitle_When_No_Error()
    {
        var cut = Render<NBInput>(p => p
            .Add(i => i.Id, "field")
            .Add(i => i.Label, "Field")
            .Add(i => i.Subtitle, "Helper text"));

        Assert.NotEmpty(cut.FindAll(".nb-field-subtitle"));
        Assert.Empty(cut.FindAll(".nb-field-error"));
    }

    [Fact]
    public void Error_Takes_Priority_Over_Subtitle()
    {
        var cut = Render<NBInput>(p => p
            .Add(i => i.Id, "field")
            .Add(i => i.Label, "Field")
            .Add(i => i.Subtitle, "Helper")
            .Add(i => i.ErrorMessage, "Oops"));

        Assert.NotEmpty(cut.FindAll(".nb-field-error"));
        Assert.Empty(cut.FindAll(".nb-field-subtitle"));
    }

    [Fact]
    public void ValueChanged_Fires_On_Input()
    {
        string? received = null;
        var cut = Render<NBInput>(p => p
            .Add(i => i.Id, "field")
            .Add(i => i.Label, "Field")
            .Add(i => i.ValueChanged, (string? v) => received = v));

        cut.Find("input").Input("hello");

        Assert.Equal("hello", received);
    }

    [Fact]
    public void Placeholder_Is_Rendered()
    {
        var cut = Render<NBInput>(p => p
            .Add(i => i.Id, "field")
            .Add(i => i.Label, "Field")
            .Add(i => i.Placeholder, "Type here..."));

        Assert.Equal("Type here...", cut.Find("input").GetAttribute("placeholder"));
    }

    [Fact]
    public void Disabled_Attribute_Rendered()
    {
        var cut = Render<NBInput>(p => p
            .Add(i => i.Id, "field")
            .Add(i => i.Label, "Field")
            .Add(i => i.Disabled, true));

        Assert.NotNull(cut.Find("input").GetAttribute("disabled"));
    }
}
