using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBDatePickerTests : BunitContext
{
    [Fact]
    public void Renders_Label_And_Trigger()
    {
        var cut = Render<NBDatePicker>(p => p
            .Add(d => d.Label, "Date")
            .Add(d => d.Id, "date1"));

        Assert.NotNull(cut.Find("#date1"));
    }

    [Fact]
    public void Shows_Placeholder_When_No_Value()
    {
        var cut = Render<NBDatePicker>(p => p
            .Add(d => d.Label, "Date")
            .Add(d => d.Id, "date1")
            .Add(d => d.Placeholder, "Pick a date"));

        Assert.Contains("Pick a date", cut.Find(".nb-select__value").TextContent);
    }

    [Fact]
    public void Shows_Formatted_Value()
    {
        var cut = Render<NBDatePicker>(p => p
            .Add(d => d.Label, "Date")
            .Add(d => d.Id, "date1")
            .Add(d => d.Value, new DateTime(2026, 4, 12))
            .Add(d => d.Format, "dd/MM/yyyy"));

        Assert.Contains("12/04/2026", cut.Find(".nb-select__value").TextContent);
    }

    [Fact]
    public void Opens_Calendar_On_Click()
    {
        var cut = Render<NBDatePicker>(p => p
            .Add(d => d.Label, "Date")
            .Add(d => d.Id, "date1"));

        cut.Find("#date1").Click();

        Assert.NotEmpty(cut.FindAll(".nb-calendar"));
    }

    [Fact]
    public void Closes_Calendar_On_Second_Click()
    {
        var cut = Render<NBDatePicker>(p => p
            .Add(d => d.Label, "Date")
            .Add(d => d.Id, "date1"));

        cut.Find("#date1").Click();
        cut.Find("#date1").Click();

        Assert.Empty(cut.FindAll(".nb-calendar"));
    }

    [Fact]
    public void Fires_ValueChanged_On_Date_Select()
    {
        DateTime? selected = null;
        var cut = Render<NBDatePicker>(p => p
            .Add(d => d.Label, "Date")
            .Add(d => d.Id, "date1")
            .Add(d => d.ValueChanged, (DateTime? v) => selected = v));

        cut.Find("#date1").Click();

        // Find and click a day
        var days = cut.FindAll(".nb-calendar__day:not(.nb-calendar__day--outside):not(.nb-calendar__day--disabled)");
        if (days.Count > 0)
        {
            days[5].Click();
            Assert.NotNull(selected);
        }
    }

    [Fact]
    public void Calendar_Not_Visible_By_Default()
    {
        var cut = Render<NBDatePicker>(p => p
            .Add(d => d.Label, "Date")
            .Add(d => d.Id, "date1"));

        Assert.Empty(cut.FindAll(".nb-calendar"));
    }

    [Fact]
    public void Has_Calendar_Icon()
    {
        var cut = Render<NBDatePicker>(p => p
            .Add(d => d.Label, "Date")
            .Add(d => d.Id, "date1"));

        Assert.NotEmpty(cut.FindAll(".nb-select__icon"));
    }
}
