using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBPaginationTests : BunitContext
{
    [Fact]
    public void Renders_Page_Buttons()
    {
        var cut = Render<NBPagination>(p => p
            .Add(pg => pg.TotalPages, 5)
            .Add(pg => pg.CurrentPage, 1));

        var buttons = cut.FindAll(".nb-pagination__btn");
        Assert.True(buttons.Count >= 2); // At least prev + next
    }

    [Fact]
    public void Prev_Disabled_On_First_Page()
    {
        var cut = Render<NBPagination>(p => p
            .Add(pg => pg.TotalPages, 5)
            .Add(pg => pg.CurrentPage, 1));

        var prev = cut.Find("[aria-label='Previous page']");
        Assert.NotNull(prev.GetAttribute("disabled"));
    }

    [Fact]
    public void Next_Disabled_On_Last_Page()
    {
        var cut = Render<NBPagination>(p => p
            .Add(pg => pg.TotalPages, 5)
            .Add(pg => pg.CurrentPage, 5));

        var next = cut.Find("[aria-label='Next page']");
        Assert.NotNull(next.GetAttribute("disabled"));
    }

    [Fact]
    public void Active_Page_Has_Aria_Current()
    {
        var cut = Render<NBPagination>(p => p
            .Add(pg => pg.TotalPages, 5)
            .Add(pg => pg.CurrentPage, 3));

        Assert.NotEmpty(cut.FindAll("[aria-current='page']"));
    }

    [Fact]
    public void CurrentPageChanged_Fires_On_Click()
    {
        var page = 0;
        var cut = Render<NBPagination>(p => p
            .Add(pg => pg.TotalPages, 5)
            .Add(pg => pg.CurrentPage, 1)
            .Add(pg => pg.CurrentPageChanged, (int p) => page = p));

        cut.Find("[aria-label='Next page']").Click();

        Assert.Equal(2, page);
    }

    [Fact]
    public void Ellipsis_Shown_For_Many_Pages()
    {
        var cut = Render<NBPagination>(p => p
            .Add(pg => pg.TotalPages, 20)
            .Add(pg => pg.CurrentPage, 10));

        Assert.NotEmpty(cut.FindAll(".nb-pagination__ellipsis"));
    }
}
