using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBCarouselTests : BunitContext
{
    [Fact]
    public void Renders_With_Carousel_Role()
    {
        var cut = Render<NBCarousel>(p => p
            .Add(c => c.SlideCount, 3)
            .AddChildContent("<div>Slide</div>"));

        Assert.NotNull(cut.Find("[aria-roledescription='carousel']"));
    }

    [Fact]
    public void Prev_Disabled_On_First_Slide()
    {
        var cut = Render<NBCarousel>(p => p
            .Add(c => c.SlideCount, 3)
            .AddChildContent("<div>Slide</div>"));

        Assert.NotNull(cut.Find(".nb-carousel__btn-prev[disabled]"));
    }

    [Fact]
    public void Next_Enabled_When_More_Slides()
    {
        var cut = Render<NBCarousel>(p => p
            .Add(c => c.SlideCount, 3)
            .AddChildContent("<div>Slide</div>"));

        Assert.Null(cut.Find(".nb-carousel__btn-next").GetAttribute("disabled"));
    }

    [Theory]
    [InlineData(NBCarouselOrientation.Horizontal, "nb-carousel--horizontal")]
    [InlineData(NBCarouselOrientation.Vertical, "nb-carousel--vertical")]
    public void Applies_Orientation_Class(NBCarouselOrientation orientation, string expectedClass)
    {
        var cut = Render<NBCarousel>(p => p
            .Add(c => c.Orientation, orientation)
            .Add(c => c.SlideCount, 1)
            .AddChildContent("<div>Slide</div>"));

        Assert.Contains(expectedClass, cut.Find("[aria-roledescription='carousel']").GetAttribute("class"));
    }

    [Fact]
    public void CarouselItem_Renders()
    {
        var cut = Render<NBCarouselItem>(p => p
            .AddChildContent("Slide 1"));

        Assert.Equal("slide", cut.Find(".nb-carousel__item").GetAttribute("aria-roledescription"));
        Assert.Contains("Slide 1", cut.Find(".nb-carousel__item").TextContent);
    }

    [Fact]
    public void Next_Navigates_Forward()
    {
        var cut = Render<NBCarousel>(p => p
            .Add(c => c.SlideCount, 3)
            .AddChildContent("<div>Slide</div>"));

        cut.Find(".nb-carousel__btn-next").Click();

        // Prev should now be enabled
        Assert.Null(cut.Find(".nb-carousel__btn-prev").GetAttribute("disabled"));
    }

    [Fact]
    public void Previous_After_Next()
    {
        var cut = Render<NBCarousel>(p => p
            .Add(c => c.SlideCount, 3)
            .AddChildContent("<div>Slide</div>"));

        cut.Find(".nb-carousel__btn-next").Click();
        cut.Find(".nb-carousel__btn-prev").Click();

        // Back to first slide, prev disabled
        Assert.NotNull(cut.Find(".nb-carousel__btn-prev[disabled]"));
    }

    [Fact]
    public void Next_Disabled_On_Last_Slide()
    {
        var cut = Render<NBCarousel>(p => p
            .Add(c => c.SlideCount, 2)
            .AddChildContent("<div>Slide</div>"));

        cut.Find(".nb-carousel__btn-next").Click();

        Assert.NotNull(cut.Find(".nb-carousel__btn-next[disabled]"));
    }

    [Fact]
    public void Keyboard_ArrowRight_Navigates()
    {
        var cut = Render<NBCarousel>(p => p
            .Add(c => c.SlideCount, 3)
            .Add(c => c.Orientation, NBCarouselOrientation.Horizontal)
            .AddChildContent("<div>Slide</div>"));

        cut.Find("[aria-roledescription='carousel']")
            .KeyDown(key: "ArrowRight");

        Assert.Null(cut.Find(".nb-carousel__btn-prev").GetAttribute("disabled"));
    }

    [Fact]
    public void Keyboard_ArrowLeft_Navigates_Back()
    {
        var cut = Render<NBCarousel>(p => p
            .Add(c => c.SlideCount, 3)
            .Add(c => c.Orientation, NBCarouselOrientation.Horizontal)
            .AddChildContent("<div>Slide</div>"));

        cut.Find("[aria-roledescription='carousel']").KeyDown(key: "ArrowRight");
        cut.Find("[aria-roledescription='carousel']").KeyDown(key: "ArrowLeft");

        Assert.NotNull(cut.Find(".nb-carousel__btn-prev[disabled]"));
    }

    [Fact]
    public void Keyboard_ArrowDown_Vertical_Navigates()
    {
        var cut = Render<NBCarousel>(p => p
            .Add(c => c.SlideCount, 3)
            .Add(c => c.Orientation, NBCarouselOrientation.Vertical)
            .AddChildContent("<div>Slide</div>"));

        cut.Find("[aria-roledescription='carousel']")
            .KeyDown(key: "ArrowDown");

        Assert.Null(cut.Find(".nb-carousel__btn-prev").GetAttribute("disabled"));
    }

    [Fact]
    public void Transform_Reflects_Current_Slide()
    {
        var cut = Render<NBCarousel>(p => p
            .Add(c => c.SlideCount, 3)
            .AddChildContent("<div>Slide</div>"));

        Assert.Contains("translateX(0%)", cut.Find(".nb-carousel__container").GetAttribute("style"));

        cut.Find(".nb-carousel__btn-next").Click();

        Assert.Contains("translateX(-100%)", cut.Find(".nb-carousel__container").GetAttribute("style"));
    }

    [Fact]
    public void Single_Slide_Both_Buttons_Disabled()
    {
        var cut = Render<NBCarousel>(p => p
            .Add(c => c.SlideCount, 1)
            .AddChildContent("<div>Slide</div>"));

        Assert.NotNull(cut.Find(".nb-carousel__btn-prev[disabled]"));
        Assert.NotNull(cut.Find(".nb-carousel__btn-next[disabled]"));
    }

    [Fact]
    public void HideArrows_Hides_Buttons()
    {
        var cut = Render<NBCarousel>(p => p
            .Add(c => c.SlideCount, 3)
            .Add(c => c.HideArrows, true)
            .AddChildContent("<div>Slide</div>"));

        Assert.Empty(cut.FindAll(".nb-carousel__btn-prev"));
        Assert.Empty(cut.FindAll(".nb-carousel__btn-next"));
    }

    [Fact]
    public void HideArrows_False_Shows_Buttons()
    {
        var cut = Render<NBCarousel>(p => p
            .Add(c => c.SlideCount, 3)
            .Add(c => c.HideArrows, false)
            .AddChildContent("<div>Slide</div>"));

        Assert.NotEmpty(cut.FindAll(".nb-carousel__btn-prev"));
        Assert.NotEmpty(cut.FindAll(".nb-carousel__btn-next"));
    }
}
