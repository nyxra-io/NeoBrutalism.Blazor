using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBAccordionTests : BunitContext
{
    [Fact]
    public void Accordion_Renders_ChildContent()
    {
        var cut = Render<NBAccordion>(p => p
            .AddChildContent("<p>inner</p>"));

        Assert.Contains("inner", cut.Find(".nb-accordion").InnerHtml);
    }

    [Fact]
    public void AccordionItem_Renders_Header()
    {
        var cut = Render<NBAccordionItem>(p => p
            .Add(i => i.Header, "Section 1")
            .AddChildContent("Content"));

        Assert.Equal("Section 1", cut.Find(".nb-accordion-trigger span").TextContent);
    }

    [Fact]
    public void AccordionItem_Content_Hidden_When_Closed()
    {
        var cut = Render<NBAccordionItem>(p => p
            .Add(i => i.Header, "Section")
            .Add(i => i.IsOpen, false)
            .AddChildContent("Hidden content"));

        Assert.Empty(cut.FindAll(".nb-accordion-content"));
    }

    [Fact]
    public void AccordionItem_Content_Visible_When_Open()
    {
        var cut = Render<NBAccordionItem>(p => p
            .Add(i => i.Header, "Section")
            .Add(i => i.IsOpen, true)
            .AddChildContent("Visible content"));

        Assert.Contains("Visible content", cut.Find(".nb-accordion-content").TextContent);
    }

    [Fact]
    public void AccordionItem_Toggle_Changes_State()
    {
        var isOpen = false;
        var cut = Render<NBAccordionItem>(p => p
            .Add(i => i.Header, "Section")
            .Add(i => i.IsOpen, isOpen)
            .Add(i => i.IsOpenChanged, (bool v) => isOpen = v)
            .AddChildContent("Content"));

        cut.Find(".nb-accordion-trigger").Click();

        Assert.True(isOpen);
    }

    [Fact]
    public void AccordionItem_Has_Aria_Attributes()
    {
        var cut = Render<NBAccordionItem>(p => p
            .Add(i => i.Header, "Section")
            .Add(i => i.IsOpen, true)
            .AddChildContent("Content"));

        var button = cut.Find(".nb-accordion-trigger");
        Assert.NotNull(button.GetAttribute("aria-expanded"));
        Assert.NotNull(button.GetAttribute("aria-controls"));

        var panel = cut.Find(".nb-accordion-content");
        Assert.Equal("region", panel.GetAttribute("role"));
    }

    [Fact]
    public void AccordionItem_Open_Adds_CssClass()
    {
        var cut = Render<NBAccordionItem>(p => p
            .Add(i => i.Header, "Section")
            .Add(i => i.IsOpen, true)
            .AddChildContent("Content"));

        Assert.Contains("nb-accordion-item--open", cut.Find(".nb-accordion-item").GetAttribute("class"));
    }
}
