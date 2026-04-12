using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBDataTableTests : BunitContext
{
    private record Person(string Name, int Age);

    private static readonly IReadOnlyList<Person> _people =
    [
        new("Alice", 30),
        new("Bob", 25),
        new("Charlie", 35)
    ];

    private static readonly IReadOnlyList<NBDataTableColumn<Person>> _columns =
    [
        new() { Title = "Name", Field = p => p.Name, Sortable = true },
        new() { Title = "Age", Field = p => p.Age }
    ];

    [Fact]
    public void Renders_Headers()
    {
        var cut = Render<NBDataTable<Person>>(p => p
            .Add(t => t.Items, _people)
            .Add(t => t.Columns, _columns));

        var headers = cut.FindAll(".nb-table-head");
        Assert.Equal(2, headers.Count);
    }

    [Fact]
    public void Renders_All_Rows()
    {
        var cut = Render<NBDataTable<Person>>(p => p
            .Add(t => t.Items, _people)
            .Add(t => t.Columns, _columns)
            .Add(t => t.PageSize, 0));

        var rows = cut.FindAll(".nb-table-row");
        Assert.Equal(3, rows.Count);
    }

    [Fact]
    public void Sortable_Column_Has_Button()
    {
        var cut = Render<NBDataTable<Person>>(p => p
            .Add(t => t.Items, _people)
            .Add(t => t.Columns, _columns));

        Assert.NotEmpty(cut.FindAll(".nb-data-table__sort-btn"));
    }

    [Fact]
    public void Search_Filter_Shows_When_Searchable()
    {
        var cut = Render<NBDataTable<Person>>(p => p
            .Add(t => t.Items, _people)
            .Add(t => t.Columns, _columns)
            .Add(t => t.Searchable, true)
            .Add(t => t.SearchField, p => p.Name));

        Assert.NotEmpty(cut.FindAll(".nb-data-table__filter"));
    }

    [Fact]
    public void Pagination_Shows_When_Items_Exceed_PageSize()
    {
        var cut = Render<NBDataTable<Person>>(p => p
            .Add(t => t.Items, _people)
            .Add(t => t.Columns, _columns)
            .Add(t => t.PageSize, 2));

        Assert.NotEmpty(cut.FindAll(".nb-data-table__pagination"));
    }

    [Fact]
    public void No_Pagination_When_Items_Fit()
    {
        var cut = Render<NBDataTable<Person>>(p => p
            .Add(t => t.Items, _people)
            .Add(t => t.Columns, _columns)
            .Add(t => t.PageSize, 10));

        Assert.Empty(cut.FindAll(".nb-data-table__pagination"));
    }

    [Fact]
    public void Sort_Button_Click_Sorts()
    {
        var cut = Render<NBDataTable<Person>>(p => p
            .Add(t => t.Items, _people)
            .Add(t => t.Columns, _columns)
            .Add(t => t.PageSize, 0));

        var sortBtn = cut.Find(".nb-data-table__sort-btn");
        sortBtn.Click(); // Sort ascending

        var firstCell = cut.FindAll(".nb-table-cell")[0];
        Assert.Equal("Alice", firstCell.TextContent);
    }

    [Fact]
    public void Sort_Button_Double_Click_Reverses()
    {
        var cut = Render<NBDataTable<Person>>(p => p
            .Add(t => t.Items, _people)
            .Add(t => t.Columns, _columns)
            .Add(t => t.PageSize, 0));

        var sortBtn = cut.Find(".nb-data-table__sort-btn");
        sortBtn.Click(); // asc
        sortBtn.Click(); // desc

        var firstCell = cut.FindAll(".nb-table-cell")[0];
        Assert.Equal("Charlie", firstCell.TextContent);
    }

    [Fact]
    public void Pagination_Next_Shows_Next_Page()
    {
        var cut = Render<NBDataTable<Person>>(p => p
            .Add(t => t.Items, _people)
            .Add(t => t.Columns, _columns)
            .Add(t => t.PageSize, 1));

        cut.Find("[aria-label='Next page']").Click();

        var cell = cut.FindAll(".nb-table-cell")[0];
        Assert.Equal("Bob", cell.TextContent);
    }

    [Fact]
    public void Non_Sortable_Column_Has_No_Button()
    {
        var cut = Render<NBDataTable<Person>>(p => p
            .Add(t => t.Items, _people)
            .Add(t => t.Columns, _columns));

        // The "Age" column (index 1) is not sortable
        var headers = cut.FindAll(".nb-table-head");
        Assert.Single(cut.FindAll(".nb-data-table__sort-btn"));
    }
}
