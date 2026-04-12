using Bunit;
using Xunit;

namespace NeoBrutalism.Blazor.Tests;

public class NBAvatarTests : BunitContext
{
    [Fact]
    public void Renders_Image_When_Src_Provided()
    {
        var cut = Render<NBAvatar>(p => p
            .Add(a => a.Src, "https://example.com/photo.jpg")
            .Add(a => a.Alt, "User"));

        var img = cut.Find(".nb-avatar__img");
        Assert.Equal("https://example.com/photo.jpg", img.GetAttribute("src"));
        Assert.Equal("User", img.GetAttribute("alt"));
    }

    [Fact]
    public void Renders_Initials_When_No_Src()
    {
        var cut = Render<NBAvatar>(p => p
            .Add(a => a.Initials, "LF"));

        Assert.Equal("LF", cut.Find(".nb-avatar__initials").TextContent);
    }

    [Fact]
    public void Renders_Fallback_Svg_When_No_Src_Or_Initials()
    {
        var cut = Render<NBAvatar>();

        Assert.NotEmpty(cut.FindAll(".nb-avatar__fallback svg"));
    }

    [Theory]
    [InlineData(NBAvatarSize.Sm, "nb-avatar--sm")]
    [InlineData(NBAvatarSize.Lg, "nb-avatar--lg")]
    public void Applies_Size_Class(NBAvatarSize size, string expectedClass)
    {
        var cut = Render<NBAvatar>(p => p
            .Add(a => a.Size, size));

        Assert.Contains(expectedClass, cut.Find(".nb-avatar").GetAttribute("class"));
    }

    [Fact]
    public void Default_Size_Has_No_Size_Class()
    {
        var cut = Render<NBAvatar>(p => p
            .Add(a => a.Size, NBAvatarSize.Default));

        var classes = cut.Find(".nb-avatar").GetAttribute("class")!;
        Assert.DoesNotContain("nb-avatar--sm", classes);
        Assert.DoesNotContain("nb-avatar--lg", classes);
    }
}
