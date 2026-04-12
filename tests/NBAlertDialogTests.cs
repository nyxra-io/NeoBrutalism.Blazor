using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBAlertDialogTests : BunitContext
{
    [Fact]
    public void Not_Rendered_When_Not_Visible()
    {
        var cut = Render<NBAlertDialog>(p => p
            .Add(a => a.Title, "Confirm")
            .Add(a => a.IsVisible, false));

        Assert.Empty(cut.FindAll(".nb-alert-dialog"));
    }

    [Fact]
    public void Rendered_When_Visible()
    {
        var cut = Render<NBAlertDialog>(p => p
            .Add(a => a.Title, "Confirm")
            .Add(a => a.IsVisible, true));

        Assert.NotEmpty(cut.FindAll("[role='alertdialog']"));
    }

    [Fact]
    public void Renders_Title_And_Description()
    {
        var cut = Render<NBAlertDialog>(p => p
            .Add(a => a.Title, "Delete?")
            .Add(a => a.Description, "This cannot be undone.")
            .Add(a => a.IsVisible, true));

        Assert.Contains("Delete?", cut.Find(".nb-dialog__title").TextContent);
        Assert.Contains("This cannot be undone.", cut.Find(".nb-dialog__description").TextContent);
    }

    [Fact]
    public void Custom_Button_Text()
    {
        var cut = Render<NBAlertDialog>(p => p
            .Add(a => a.Title, "Confirm")
            .Add(a => a.IsVisible, true)
            .Add(a => a.ConfirmText, "Yes")
            .Add(a => a.CancelText, "No"));

        var buttons = cut.FindAll(".nb-alert-dialog__footer button");
        Assert.Contains(buttons, b => b.TextContent.Contains("No"));
        Assert.Contains(buttons, b => b.TextContent.Contains("Yes"));
    }

    [Fact]
    public void Confirm_Fires_OnConfirm()
    {
        var confirmed = false;
        var cut = Render<NBAlertDialog>(p => p
            .Add(a => a.Title, "Confirm")
            .Add(a => a.IsVisible, true)
            .Add(a => a.OnConfirm, () => confirmed = true));

        var buttons = cut.FindAll(".nb-alert-dialog__footer button");
        buttons[1].Click(); // Confirm is second button

        Assert.True(confirmed);
    }

    [Fact]
    public void Cancel_Fires_OnCancel()
    {
        var cancelled = false;
        var cut = Render<NBAlertDialog>(p => p
            .Add(a => a.Title, "Confirm")
            .Add(a => a.IsVisible, true)
            .Add(a => a.OnCancel, () => cancelled = true));

        var buttons = cut.FindAll(".nb-alert-dialog__footer button");
        buttons[0].Click(); // Cancel is first button

        Assert.True(cancelled);
    }

    [Fact]
    public void Renders_ChildContent()
    {
        var cut = Render<NBAlertDialog>(p => p
            .Add(a => a.Title, "Confirm")
            .Add(a => a.IsVisible, true)
            .Add(a => a.ChildContent, b => b.AddContent(0, "Extra body")));

        Assert.Contains("Extra body", cut.Find(".nb-dialog__body").TextContent);
    }

    [Fact]
    public void No_Body_When_No_ChildContent()
    {
        var cut = Render<NBAlertDialog>(p => p
            .Add(a => a.Title, "Confirm")
            .Add(a => a.IsVisible, true));

        Assert.Empty(cut.FindAll(".nb-dialog__body"));
    }

    [Fact]
    public void Has_AlertDialog_Role()
    {
        var cut = Render<NBAlertDialog>(p => p
            .Add(a => a.Title, "Confirm")
            .Add(a => a.IsVisible, true));

        Assert.NotNull(cut.Find("[role='alertdialog']"));
    }

    [Fact]
    public void Has_Aria_Modal()
    {
        var cut = Render<NBAlertDialog>(p => p
            .Add(a => a.Title, "Confirm")
            .Add(a => a.IsVisible, true));

        Assert.Equal("true", cut.Find("[role='alertdialog']").GetAttribute("aria-modal"));
    }

    [Fact]
    public void No_Description_When_Not_Provided()
    {
        var cut = Render<NBAlertDialog>(p => p
            .Add(a => a.Title, "Confirm")
            .Add(a => a.IsVisible, true));

        Assert.Empty(cut.FindAll(".nb-dialog__description"));
    }
}
