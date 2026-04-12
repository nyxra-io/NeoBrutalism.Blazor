using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBComboBoxTests : BunitContext
{
    private static readonly NBSelectOption[] _options =
    [
        new("apple", "Apple"),
        new("banana", "Banana"),
        new("cherry", "Cherry")
    ];

    [Fact]
    public void Renders_Label_And_Trigger()
    {
        var cut = Render<NBComboBox>(p => p
            .Add(c => c.Label, "Fruit")
            .Add(c => c.Id, "fruit")
            .Add(c => c.Options, _options));

        Assert.NotNull(cut.Find("[role='combobox']"));
    }

    [Fact]
    public void Shows_Placeholder_When_No_Value()
    {
        var cut = Render<NBComboBox>(p => p
            .Add(c => c.Label, "Fruit")
            .Add(c => c.Id, "fruit")
            .Add(c => c.Options, _options)
            .Add(c => c.Placeholder, "Pick one"));

        Assert.Contains("Pick one", cut.Find(".nb-select__value").TextContent);
    }

    [Fact]
    public void Dropdown_Opens_On_Click()
    {
        var cut = Render<NBComboBox>(p => p
            .Add(c => c.Label, "Fruit")
            .Add(c => c.Id, "fruit")
            .Add(c => c.Options, _options));

        cut.Find("[role='combobox']").Click();

        Assert.NotEmpty(cut.FindAll(".nb-combobox__dropdown"));
    }

    [Fact]
    public void Shows_Selected_Label()
    {
        var cut = Render<NBComboBox>(p => p
            .Add(c => c.Label, "Fruit")
            .Add(c => c.Id, "fruit")
            .Add(c => c.Options, _options)
            .Add(c => c.Value, "banana"));

        Assert.Contains("Banana", cut.Find(".nb-select__value").TextContent);
    }

    [Fact]
    public void Selecting_Option_Fires_ValueChanged()
    {
        string? selected = null;
        var cut = Render<NBComboBox>(p => p
            .Add(c => c.Label, "Fruit")
            .Add(c => c.Id, "fruit")
            .Add(c => c.Options, _options)
            .Add(c => c.ValueChanged, (string? v) => selected = v));

        cut.Find("[role='combobox']").Click();
        cut.FindAll(".nb-select__item")[1].Click();

        Assert.NotNull(selected);
    }

    [Fact]
    public void Search_Filters_Options()
    {
        var cut = Render<NBComboBox>(p => p
            .Add(c => c.Label, "Fruit")
            .Add(c => c.Id, "fruit")
            .Add(c => c.Options, _options));

        cut.Find("[role='combobox']").Click();
        cut.Find(".nb-combobox__search").Input("ban");

        var items = cut.FindAll(".nb-select__item");
        Assert.Single(items);
    }

    [Fact]
    public void Empty_Text_When_No_Match()
    {
        var cut = Render<NBComboBox>(p => p
            .Add(c => c.Label, "Fruit")
            .Add(c => c.Id, "fruit")
            .Add(c => c.Options, _options)
            .Add(c => c.EmptyText, "Nothing"));

        cut.Find("[role='combobox']").Click();
        cut.Find(".nb-combobox__search").Input("zzz");

        Assert.Contains("Nothing", cut.Find(".nb-command__empty").TextContent);
    }

    [Fact]
    public void Toggle_Clears_Query_On_Close()
    {
        var cut = Render<NBComboBox>(p => p
            .Add(c => c.Label, "Fruit")
            .Add(c => c.Id, "fruit")
            .Add(c => c.Options, _options));

        cut.Find("[role='combobox']").Click();
        cut.Find(".nb-combobox__search").Input("app");
        cut.Find("[role='combobox']").Click(); // close

        Assert.Empty(cut.FindAll(".nb-combobox__dropdown"));
    }

    [Fact]
    public void Deselect_When_Same_Value_Clicked()
    {
        string? selected = "apple";
        var cut = Render<NBComboBox>(p => p
            .Add(c => c.Label, "Fruit")
            .Add(c => c.Id, "fruit")
            .Add(c => c.Options, _options)
            .Add(c => c.Value, "apple")
            .Add(c => c.ValueChanged, (string? v) => selected = v));

        cut.Find("[role='combobox']").Click();
        cut.FindAll(".nb-select__item")[0].Click(); // Click already selected

        Assert.Null(selected);
    }

    [Fact]
    public void Selected_Item_Has_Check()
    {
        var cut = Render<NBComboBox>(p => p
            .Add(c => c.Label, "Fruit")
            .Add(c => c.Id, "fruit")
            .Add(c => c.Options, _options)
            .Add(c => c.Value, "apple"));

        cut.Find("[role='combobox']").Click();

        Assert.NotEmpty(cut.FindAll(".nb-select__item--selected"));
    }
}
