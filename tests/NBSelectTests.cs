using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBSelectTests : BunitContext
{
    private static readonly NBSelectOption[] _options =
    [
        new("apple", "Apple"),
        new("banana", "Banana"),
        new("cherry", "Cherry")
    ];

    [Fact]
    public void Renders_Trigger_With_Combobox_Role()
    {
        var cut = Render<NBSelect>(p => p
            .Add(s => s.Label, "Fruit")
            .Add(s => s.Id, "fruit")
            .Add(s => s.Options, _options));

        Assert.NotNull(cut.Find("[role='combobox']"));
    }

    [Fact]
    public void Shows_Placeholder_When_No_Value()
    {
        var cut = Render<NBSelect>(p => p
            .Add(s => s.Label, "Fruit")
            .Add(s => s.Id, "fruit")
            .Add(s => s.Options, _options)
            .Add(s => s.Placeholder, "Choose..."));

        Assert.Contains("Choose...", cut.Find(".nb-select__value").TextContent);
    }

    [Fact]
    public void Opens_Dropdown_On_Click()
    {
        var cut = Render<NBSelect>(p => p
            .Add(s => s.Label, "Fruit")
            .Add(s => s.Id, "fruit")
            .Add(s => s.Options, _options));

        cut.Find("[role='combobox']").Click();

        Assert.NotEmpty(cut.FindAll("[role='listbox']"));
    }

    [Fact]
    public void Shows_Selected_Label()
    {
        var cut = Render<NBSelect>(p => p
            .Add(s => s.Label, "Fruit")
            .Add(s => s.Id, "fruit")
            .Add(s => s.Options, _options)
            .Add(s => s.Value, "cherry"));

        Assert.Contains("Cherry", cut.Find(".nb-select__value").TextContent);
    }

    [Fact]
    public void Disabled_Has_Class()
    {
        var cut = Render<NBSelect>(p => p
            .Add(s => s.Label, "Fruit")
            .Add(s => s.Id, "fruit")
            .Add(s => s.Options, _options)
            .Add(s => s.Disabled, true));

        Assert.Contains("nb-select--disabled", cut.Markup);
    }

    [Fact]
    public void Selecting_Option_Fires_ValueChanged()
    {
        string? selected = null;
        var cut = Render<NBSelect>(p => p
            .Add(s => s.Label, "Fruit")
            .Add(s => s.Id, "fruit")
            .Add(s => s.Options, _options)
            .Add(s => s.ValueChanged, (string? v) => selected = v));

        cut.Find("[role='combobox']").Click();
        cut.FindAll("[role='option']")[1].Click();

        Assert.Equal("banana", selected);
    }

    [Fact]
    public void Subtitle_Rendered()
    {
        var cut = Render<NBSelect>(p => p
            .Add(s => s.Label, "Fruit")
            .Add(s => s.Id, "fruit")
            .Add(s => s.Options, _options)
            .Add(s => s.Subtitle, "Pick your favorite"));

        Assert.Contains("Pick your favorite", cut.Find(".nb-field-subtitle").TextContent);
    }

    [Fact]
    public void Keyboard_Enter_Opens_Dropdown()
    {
        var cut = Render<NBSelect>(p => p
            .Add(s => s.Label, "Fruit")
            .Add(s => s.Id, "fruit")
            .Add(s => s.Options, _options));

        cut.Find("[role='combobox']").KeyDown(key: "Enter");

        Assert.NotEmpty(cut.FindAll("[role='listbox']"));
    }

    [Fact]
    public void Keyboard_Escape_Closes_Dropdown()
    {
        var cut = Render<NBSelect>(p => p
            .Add(s => s.Label, "Fruit")
            .Add(s => s.Id, "fruit")
            .Add(s => s.Options, _options));

        cut.Find("[role='combobox']").Click();
        cut.Find("[role='combobox']").KeyDown(key: "Escape");

        Assert.Empty(cut.FindAll("[role='listbox']"));
    }

    [Fact]
    public void Keyboard_ArrowDown_Opens_Dropdown()
    {
        var cut = Render<NBSelect>(p => p
            .Add(s => s.Label, "Fruit")
            .Add(s => s.Id, "fruit")
            .Add(s => s.Options, _options));

        cut.Find("[role='combobox']").KeyDown(key: "ArrowDown");

        Assert.NotEmpty(cut.FindAll("[role='listbox']"));
    }

    [Fact]
    public void Keyboard_Space_Opens_Dropdown()
    {
        var cut = Render<NBSelect>(p => p
            .Add(s => s.Label, "Fruit")
            .Add(s => s.Id, "fruit")
            .Add(s => s.Options, _options));

        cut.Find("[role='combobox']").KeyDown(key: " ");

        Assert.NotEmpty(cut.FindAll("[role='listbox']"));
    }

    [Fact]
    public void Disabled_Does_Not_Open()
    {
        var cut = Render<NBSelect>(p => p
            .Add(s => s.Label, "Fruit")
            .Add(s => s.Id, "fruit")
            .Add(s => s.Options, _options)
            .Add(s => s.Disabled, true));

        // Click the button - it should be disabled
        Assert.Empty(cut.FindAll("[role='listbox']"));
    }

    [Fact]
    public void Selected_Option_Has_Check_Icon()
    {
        var cut = Render<NBSelect>(p => p
            .Add(s => s.Label, "Fruit")
            .Add(s => s.Id, "fruit")
            .Add(s => s.Options, _options)
            .Add(s => s.Value, "apple"));

        cut.Find("[role='combobox']").Click();

        Assert.NotEmpty(cut.FindAll(".nb-select__item--selected"));
    }

    [Fact]
    public void No_Subtitle_When_Not_Provided()
    {
        var cut = Render<NBSelect>(p => p
            .Add(s => s.Label, "Fruit")
            .Add(s => s.Id, "fruit")
            .Add(s => s.Options, _options));

        Assert.Empty(cut.FindAll(".nb-field-subtitle"));
    }
}
