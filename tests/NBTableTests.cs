using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBTableTests : BunitContext
{
    [Fact]
    public void Table_Renders_With_Wrapper()
    {
        var cut = Render<NBTable>(p => p
            .AddChildContent("<tr><td>Cell</td></tr>"));

        Assert.NotNull(cut.Find(".nb-table-wrapper"));
        Assert.NotNull(cut.Find(".nb-table"));
    }

    [Fact]
    public void TableHeader_Renders()
    {
        var cut = Render<NBTableHeader>(p => p
            .AddChildContent("<tr><th>Col</th></tr>"));

        Assert.Equal("THEAD", cut.Find(".nb-table-header").TagName);
    }

    [Fact]
    public void TableBody_Renders()
    {
        var cut = Render<NBTableBody>(p => p
            .AddChildContent("<tr><td>Cell</td></tr>"));

        Assert.Equal("TBODY", cut.Find(".nb-table-body").TagName);
    }

    [Fact]
    public void TableFooter_Renders()
    {
        var cut = Render<NBTableFooter>(p => p
            .AddChildContent("<tr><td>Total</td></tr>"));

        Assert.Equal("TFOOT", cut.Find(".nb-table-footer").TagName);
    }

    [Fact]
    public void TableRow_Renders()
    {
        var cut = Render<NBTableRow>(p => p
            .AddChildContent("<td>Cell</td>"));

        Assert.Equal("TR", cut.Find(".nb-table-row").TagName);
    }

    [Fact]
    public void TableHead_Renders()
    {
        var cut = Render<NBTableHead>(p => p
            .AddChildContent("Column"));

        var th = cut.Find(".nb-table-head");
        Assert.Equal("TH", th.TagName);
        Assert.Equal("col", th.GetAttribute("scope"));
    }

    [Fact]
    public void TableCell_Renders()
    {
        var cut = Render<NBTableCell>(p => p
            .AddChildContent("Value"));

        Assert.Equal("TD", cut.Find(".nb-table-cell").TagName);
        Assert.Equal("Value", cut.Find(".nb-table-cell").TextContent);
    }

    [Fact]
    public void TableCaption_Renders()
    {
        var cut = Render<NBTableCaption>(p => p
            .AddChildContent("Table caption"));

        Assert.Equal("CAPTION", cut.Find(".nb-table-caption").TagName);
    }
}
