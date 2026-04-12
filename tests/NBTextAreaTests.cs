using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBTextAreaTests : BunitContext
{
    [Fact]
    public void Renders_Label_And_Textarea()
    {
        var cut = Render<NBTextArea>(p => p
            .Add(t => t.Label, "Message")
            .Add(t => t.Id, "msg"));

        Assert.NotNull(cut.Find("#msg"));
        Assert.Equal("TEXTAREA", cut.Find("#msg").TagName);
    }

    [Fact]
    public void Default_Rows_Is_4()
    {
        var cut = Render<NBTextArea>(p => p
            .Add(t => t.Label, "Message")
            .Add(t => t.Id, "msg"));

        Assert.Equal("4", cut.Find("textarea").GetAttribute("rows"));
    }

    [Fact]
    public void Custom_Rows_Applied()
    {
        var cut = Render<NBTextArea>(p => p
            .Add(t => t.Label, "Message")
            .Add(t => t.Id, "msg")
            .Add(t => t.Rows, 8));

        Assert.Equal("8", cut.Find("textarea").GetAttribute("rows"));
    }

    [Fact]
    public void Placeholder_Rendered()
    {
        var cut = Render<NBTextArea>(p => p
            .Add(t => t.Label, "Message")
            .Add(t => t.Id, "msg")
            .Add(t => t.Placeholder, "Type here..."));

        Assert.Equal("Type here...", cut.Find("textarea").GetAttribute("placeholder"));
    }

    [Fact]
    public void Disabled_Attribute_Rendered()
    {
        var cut = Render<NBTextArea>(p => p
            .Add(t => t.Label, "Message")
            .Add(t => t.Id, "msg")
            .Add(t => t.Disabled, true));

        Assert.NotNull(cut.Find("textarea").GetAttribute("disabled"));
    }

    [Fact]
    public void Actions_Slot_Rendered()
    {
        var cut = Render<NBTextArea>(p => p
            .Add(t => t.Label, "Message")
            .Add(t => t.Id, "msg")
            .Add(t => t.Actions, b => b.AddMarkupContent(0, "<button>Send</button>")));

        Assert.NotEmpty(cut.FindAll(".nb-textarea__actions"));
    }

    [Fact]
    public void No_Actions_When_Not_Provided()
    {
        var cut = Render<NBTextArea>(p => p
            .Add(t => t.Label, "Message")
            .Add(t => t.Id, "msg"));

        Assert.Empty(cut.FindAll(".nb-textarea__actions"));
    }

    [Fact]
    public void Input_Fires_ValueChanged()
    {
        string? value = null;
        var cut = Render<NBTextArea>(p => p
            .Add(t => t.Label, "Message")
            .Add(t => t.Id, "msg")
            .Add(t => t.ValueChanged, (string? v) => value = v));

        cut.Find("textarea").Input("Hello world");

        Assert.Equal("Hello world", value);
    }

    [Fact]
    public void Renders_Label()
    {
        var cut = Render<NBTextArea>(p => p
            .Add(t => t.Label, "Notes")
            .Add(t => t.Id, "notes"));

        Assert.Contains("Notes", cut.Markup);
    }
}
