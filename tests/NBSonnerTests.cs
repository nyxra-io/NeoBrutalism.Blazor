using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBSonnerTests : BunitContext
{
    [Fact]
    public void Service_Show_Triggers_Toast()
    {
        var service = new NBSonnerService();
        Services.AddSingleton(service);

        var cut = Render<NBSonner>();

        service.Show("Hello!");

        Assert.Contains("Hello!", cut.Find(".nb-sonner__message").TextContent);
    }

    [Fact]
    public void Service_Success_Shows_Success_Variant()
    {
        var service = new NBSonnerService();
        Services.AddSingleton(service);

        var cut = Render<NBSonner>();

        service.Success("Done!");

        Assert.NotEmpty(cut.FindAll(".nb-sonner__toast--success"));
    }

    [Fact]
    public void Service_Error_Shows_Error_Variant()
    {
        var service = new NBSonnerService();
        Services.AddSingleton(service);

        var cut = Render<NBSonner>();

        service.Error("Failed!");

        Assert.NotEmpty(cut.FindAll(".nb-sonner__toast--error"));
    }

    [Fact]
    public void Toast_Has_Description()
    {
        var service = new NBSonnerService();
        Services.AddSingleton(service);

        var cut = Render<NBSonner>();

        service.Show("Title", "Description text");

        Assert.Contains("Description text", cut.Find(".nb-sonner__description").TextContent);
    }

    [Fact]
    public void Max_Toasts_Respected()
    {
        var service = new NBSonnerService();
        Services.AddSingleton(service);

        var cut = Render<NBSonner>(p => p
            .Add(s => s.MaxToasts, 2));

        service.Show("One");
        service.Show("Two");
        service.Show("Three");

        Assert.Equal(2, cut.FindAll(".nb-sonner__toast").Count);
    }

    [Fact]
    public void Service_Methods_Exist()
    {
        var service = new NBSonnerService();

        // These should not throw
        service.Warning("warn");
        service.Info("info");
    }
}
