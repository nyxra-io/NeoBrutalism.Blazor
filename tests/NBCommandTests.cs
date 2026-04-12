using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBCommandTests : BunitContext
{
    private static readonly IReadOnlyList<NBCommandGroup> _groups =
    [
        new("Files", [
            new NBCommandItem("Open", "open", "⌘O"),
            new NBCommandItem("Save", "save", "⌘S"),
            new NBCommandItem("Disabled", "disabled", Disabled: true)
        ])
    ];

    [Fact]
    public void Renders_Groups_And_Items()
    {
        var cut = Render<NBCommand>(p => p
            .Add(c => c.Groups, _groups));

        Assert.NotEmpty(cut.FindAll(".nb-command__group"));
        Assert.Equal(3, cut.FindAll(".nb-command__item").Count);
    }

    [Fact]
    public void Shows_Shortcut()
    {
        var cut = Render<NBCommand>(p => p
            .Add(c => c.Groups, _groups));

        Assert.NotEmpty(cut.FindAll(".nb-command__shortcut"));
    }

    [Fact]
    public void Disabled_Item_Has_Class()
    {
        var cut = Render<NBCommand>(p => p
            .Add(c => c.Groups, _groups));

        Assert.NotEmpty(cut.FindAll(".nb-command__item--disabled"));
    }

    [Fact]
    public void OnSelect_Fires_For_Enabled_Item()
    {
        NBCommandItem? selected = null;
        var cut = Render<NBCommand>(p => p
            .Add(c => c.Groups, _groups)
            .Add(c => c.OnSelect, (NBCommandItem i) => selected = i));

        cut.FindAll(".nb-command__item")[0].Click();

        Assert.NotNull(selected);
        Assert.Equal("open", selected!.Value);
    }

    [Fact]
    public void Has_Listbox_Role()
    {
        var cut = Render<NBCommand>(p => p
            .Add(c => c.Groups, _groups));

        Assert.NotNull(cut.Find("[role='listbox']"));
    }

    [Fact]
    public void Shows_Empty_Text_When_No_Results()
    {
        var emptyGroups = new List<NBCommandGroup>
        {
            new("Empty", [])
        };
        var cut = Render<NBCommand>(p => p
            .Add(c => c.Groups, emptyGroups)
            .Add(c => c.EmptyText, "Nothing found"));

        Assert.Contains("Nothing found", cut.Find(".nb-command__empty").TextContent);
    }

    [Fact]
    public void Search_Filters_Items()
    {
        var cut = Render<NBCommand>(p => p
            .Add(c => c.Groups, _groups));

        cut.Find(".nb-command__input").Input("Save");

        var items = cut.FindAll(".nb-command__item");
        Assert.Single(items);
        Assert.Contains("Save", items[0].TextContent);
    }

    [Fact]
    public void Search_Shows_Empty_When_No_Match()
    {
        var cut = Render<NBCommand>(p => p
            .Add(c => c.Groups, _groups)
            .Add(c => c.EmptyText, "No match"));

        cut.Find(".nb-command__input").Input("zzzzz");

        Assert.NotEmpty(cut.FindAll(".nb-command__empty"));
    }

    [Fact]
    public void Keyboard_ArrowDown_Activates_Item()
    {
        var cut = Render<NBCommand>(p => p
            .Add(c => c.Groups, _groups));

        cut.Find(".nb-command").KeyDown(key: "ArrowDown");

        Assert.NotEmpty(cut.FindAll(".nb-command__item--active"));
    }

    [Fact]
    public void Keyboard_Enter_Selects_Active()
    {
        NBCommandItem? selected = null;
        var cut = Render<NBCommand>(p => p
            .Add(c => c.Groups, _groups)
            .Add(c => c.OnSelect, (NBCommandItem i) => selected = i));

        cut.Find(".nb-command").KeyDown(key: "ArrowDown");
        cut.Find(".nb-command").KeyDown(key: "Enter");

        Assert.NotNull(selected);
    }

    [Fact]
    public void Disabled_Item_Not_Selectable_By_Click()
    {
        NBCommandItem? selected = null;
        var cut = Render<NBCommand>(p => p
            .Add(c => c.Groups, _groups)
            .Add(c => c.OnSelect, (NBCommandItem i) => selected = i));

        cut.FindAll(".nb-command__item")[2].Click(); // Disabled item

        Assert.Null(selected);
    }

    [Fact]
    public void Custom_Placeholder()
    {
        var cut = Render<NBCommand>(p => p
            .Add(c => c.Groups, _groups)
            .Add(c => c.Placeholder, "Search commands..."));

        Assert.Equal("Search commands...", cut.Find(".nb-command__input").GetAttribute("placeholder"));
    }
}
