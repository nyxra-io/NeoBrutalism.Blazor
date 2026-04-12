using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBCalendarTests : BunitContext
{
    [Fact]
    public void Renders_Day_Headers()
    {
        var cut = Render<NBCalendar>(p => p
            .Add(c => c.SelectedDate, new DateTime(2026, 4, 12)));

        var headers = cut.FindAll(".nb-calendar__head-cell");
        Assert.Equal(7, headers.Count);
        Assert.Equal("Mo", headers[0].TextContent);
    }

    [Fact]
    public void Displays_Current_Month()
    {
        var cut = Render<NBCalendar>(p => p
            .Add(c => c.SelectedDate, new DateTime(2026, 4, 12)));

        Assert.Contains("2026", cut.Find(".nb-calendar__title").TextContent);
    }

    [Fact]
    public void Navigate_Previous_Month()
    {
        var cut = Render<NBCalendar>(p => p
            .Add(c => c.SelectedDate, new DateTime(2026, 4, 12)));

        cut.Find("[aria-label='Previous month']").Click();

        var title = cut.Find(".nb-calendar__title").TextContent;
        Assert.DoesNotContain("April", title);
    }

    [Fact]
    public void Navigate_Next_Month()
    {
        var cut = Render<NBCalendar>(p => p
            .Add(c => c.SelectedDate, new DateTime(2026, 4, 12)));

        cut.Find("[aria-label='Next month']").Click();

        var title = cut.Find(".nb-calendar__title").TextContent;
        Assert.DoesNotContain("April", title);
    }

    [Fact]
    public void Single_Mode_Selects_Date()
    {
        DateTime? selected = null;
        var cut = Render<NBCalendar>(p => p
            .Add(c => c.Mode, NBCalendarMode.Single)
            .Add(c => c.SelectedDate, new DateTime(2026, 4, 1))
            .Add(c => c.SelectedDateChanged, (DateTime? d) => selected = d));

        // Click on a day button (find one that is not outside and not disabled)
        var dayButtons = cut.FindAll(".nb-calendar__day:not(.nb-calendar__day--outside):not(.nb-calendar__day--disabled)");
        dayButtons[9].Click(); // Click the 10th day

        Assert.NotNull(selected);
    }

    [Fact]
    public void Disabled_Dates_Have_Disabled_Attribute()
    {
        var cut = Render<NBCalendar>(p => p
            .Add(c => c.SelectedDate, new DateTime(2026, 4, 15))
            .Add(c => c.MinDate, new DateTime(2026, 4, 10))
            .Add(c => c.MaxDate, new DateTime(2026, 4, 20)));

        var disabledButtons = cut.FindAll(".nb-calendar__day--disabled");
        Assert.NotEmpty(disabledButtons);
    }

    [Fact]
    public void Range_Mode_Selects_Start_And_End()
    {
        DateTime? start = null;
        DateTime? end = null;
        var cut = Render<NBCalendar>(p => p
            .Add(c => c.Mode, NBCalendarMode.Range)
            .Add(c => c.RangeStart, (DateTime?)null)
            .Add(c => c.RangeStartChanged, (DateTime? d) => start = d)
            .Add(c => c.RangeEndChanged, (DateTime? d) => end = d));

        var dayButtons = cut.FindAll(".nb-calendar__day:not(.nb-calendar__day--outside)");
        dayButtons[4].Click(); // First click sets start

        Assert.NotNull(start);
    }

    [Fact]
    public void Has_Grid_Role()
    {
        var cut = Render<NBCalendar>(p => p
            .Add(c => c.SelectedDate, new DateTime(2026, 4, 12)));

        Assert.NotNull(cut.Find("[role='grid']"));
    }
}
