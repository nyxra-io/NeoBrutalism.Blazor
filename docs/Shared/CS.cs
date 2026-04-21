namespace NeoBrutalism.Blazor.Docs.Shared;

/// <summary>Code samples for documentation pages.</summary>
public static class CS
{
    // Button
    public const string ButtonVariants = """
        <NBButton Variant="@NBButtonVariant.Default">Default</NBButton>
        <NBButton Variant="@NBButtonVariant.Neutral">Neutral</NBButton>
        <NBButton Variant="@NBButtonVariant.Reverse">Reverse</NBButton>
        <NBButton Variant="@NBButtonVariant.NoShadow">No Shadow</NBButton>
        <NBButton Variant="@NBButtonVariant.Danger">Danger</NBButton>
        <NBButton Variant="@NBButtonVariant.Success">Success</NBButton>
        """;

    public const string ButtonSizes = """
        <NBButton Size="@NBButtonSize.Small">Small</NBButton>
        <NBButton Size="@NBButtonSize.Normal">Normal</NBButton>
        <NBButton Size="@NBButtonSize.Large">Large</NBButton>
        <NBButton Size="@NBButtonSize.Icon">✕</NBButton>
        """;

    public const string ButtonDisabled = """
        <NBButton Disabled="true">Cannot click</NBButton>
        <NBButton Variant="@NBButtonVariant.Neutral" Disabled="true">Neutral disabled</NBButton>
        """;

    public const string ButtonOnClick = """
        <NBButton OnClick="@HandleClick">Click me</NBButton>
        <p>Clicked: @_count times</p>

        @code {
            private int _count;
            private void HandleClick() => _count++;
        }
        """;

    public const string ButtonEnums = """
        public enum NBButtonVariant { Default, Neutral, Reverse, NoShadow, Danger, Success }
        public enum NBButtonSize { Normal, Small, Large, Icon }
        """;

    // Badge
    public const string BadgeVariants = """
        <NBBadge Variant="@NBBadgeVariant.Default">Default</NBBadge>
        <NBBadge Variant="@NBBadgeVariant.Neutral">Neutral</NBBadge>
        """;

    public const string BadgeInButton = """
        <NBButton>
            Notifications <NBBadge>3</NBBadge>
        </NBButton>
        """;

    public const string BadgeEnum = """
        public enum NBBadgeVariant { Default, Neutral }
        """;

    // Alert
    public const string AlertVariants = """
        <NBAlert Variant="@NBAlertVariant.Default" Body="Your changes have been saved." />
        <NBAlert Variant="@NBAlertVariant.Info" Body="The system will restart tonight at 2 AM." />
        <NBAlert Variant="@NBAlertVariant.Success" Body="Payment received successfully." />
        <NBAlert Variant="@NBAlertVariant.Warning" Body="Your subscription expires in 3 days." />
        <NBAlert Variant="@NBAlertVariant.Destructive" Body="This document will be permanently deleted." />
        <NBAlert Variant="@NBAlertVariant.Error" Body="Failed to connect to the server." />
        """;

    public const string AlertWithTitle = """
        <NBAlert Variant="@NBAlertVariant.Warning"
                 Title="Low disk space"
                 Body="You have less than 1 GB remaining. Consider deleting unused files." />
        """;

    public const string AlertWithIcon = """
        <NBAlert Variant="@NBAlertVariant.Success" Title="Deployed!" Body="Your app is live at example.com.">
            <Icon>
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24"
                     fill="none" stroke="currentColor" stroke-width="2.5">
                    <polyline points="20 6 9 17 4 12" />
                </svg>
            </Icon>
        </NBAlert>
        """;

    public const string AlertEnum = """
        public enum NBAlertVariant { Default, Destructive, Info, Success, Warning, Error }
        """;

    // Accordion
    public const string AccordionDefault = """
        <NBAccordion>
            <NBAccordionItem Header="What is NeoBrutalism Blazor?" @bind-IsOpen="_open1">
                NeoBrutalism Blazor is a Neo Brutalism component library for Blazor.
            </NBAccordionItem>
            <NBAccordionItem Header="How do I install it?" @bind-IsOpen="_open2">
                Run dotnet add package NeoBrutalism.Blazor and link the stylesheet.
            </NBAccordionItem>
            <NBAccordionItem Header="Does it support theming?" @bind-IsOpen="_open3">
                Yes — override CSS variables or use NBThemeProvider.
            </NBAccordionItem>
        </NBAccordion>

        @code {
            private bool _open1 = true;
            private bool _open2;
            private bool _open3;
        }
        """;

    // Tabs
    public const string TabsDefault = """
        <NBTabs Items="_tabs" @bind-ActiveKey="_activeTab" />

        @code {
            private string _activeTab = "overview";

            private readonly List<NBTabItem> _tabs =
            [
                new("overview", "Overview", @<p>Overview content.</p>),
                new("specs",    "Specs",    @<p>Technical specs.</p>),
                new("reviews",  "Reviews",  @<p>User reviews.</p>)
            ];
        }
        """;

    public const string TabsRecord = """
        // record NBTabItem(string Key, string Label, RenderFragment? Content);
        var tabs = new List<NBTabItem>
        {
            new("a", "Tab A", @<p>Content A</p>),
            new("b", "Tab B", @<p>Content B</p>)
        };
        """;

    // Progress
    public const string ProgressDefault = """
        <NBProgress Value="40" />
        """;

    public const string ProgressValues = """
        <NBProgress Value="10" />
        <NBProgress Value="50" />
        <NBProgress Value="80" />
        <NBProgress Value="100" />
        """;

    public const string ProgressAnimated = """
        <NBProgress Value="@_progress" />
        <NBButton Size="@NBButtonSize.Small" @onclick="Increment">+10</NBButton>

        @code {
            private int _progress = 20;
            private void Increment() => _progress = Math.Min(100, _progress + 10);
        }
        """;

    // Skeleton
    public const string SkeletonLines = """
        <NBSkeleton Width="60%" Height="20px" />
        <NBSkeleton Width="90%" Height="16px" />
        <NBSkeleton Width="75%" Height="16px" />
        """;

    public const string SkeletonCard = """
        <NBCard>
            <NBCardHeader>
                <NBSkeleton Width="40%" Height="22px" />
                <NBSkeleton Width="60%" Height="16px" />
            </NBCardHeader>
            <NBCardContent>
                <NBSkeleton Width="100%" Height="16px" />
                <NBSkeleton Width="85%" Height="16px" />
            </NBCardContent>
        </NBCard>
        """;

    public const string SkeletonAvatar = """
        <NBSkeleton Width="40px" Height="40px" />
        """;

    // Avatar
    public const string AvatarImage = """
        <NBAvatar Src="https://i.pravatar.cc/80?img=5" Alt="Alice" />
        <NBAvatar Src="https://i.pravatar.cc/80?img=8" Alt="Bob" Size="@NBAvatarSize.Lg" />
        """;

    public const string AvatarInitials = """
        <NBAvatar Initials="AB" Size="@NBAvatarSize.Sm" />
        <NBAvatar Initials="CD" />
        <NBAvatar Initials="EF" Size="@NBAvatarSize.Lg" />
        """;

    public const string AvatarFallback = """
        <NBAvatar Size="@NBAvatarSize.Sm" />
        <NBAvatar />
        <NBAvatar Size="@NBAvatarSize.Lg" />
        """;

    public const string AvatarEnum = """
        public enum NBAvatarSize { Sm, Default, Lg }
        """;

    // Breadcrumb
    public const string BreadcrumbDefault = """
        <NBBreadcrumb Items="_items" />

        @code {
            private readonly List<NBBreadcrumbItem> _items =
            [
                new("Home", "/"),
                new("Products", "/products"),
                new("Widget Pro", null)
            ];
        }
        """;

    public const string BreadcrumbTwoLevels = """
        <NBBreadcrumb Items="@(new List<NBBreadcrumbItem> { new("Home", "/"), new("About", null) })" />
        """;

    public const string BreadcrumbRecord = """
        // record NBBreadcrumbItem(string Label, string? Href);
        // Last item should have Href = null (renders as current page without link)
        var crumbs = new List<NBBreadcrumbItem>
        {
            new("Home", "/"),
            new("Docs", "/docs"),
            new("Breadcrumb", null)
        };
        """;

    // Pagination
    public const string PaginationDefault = """
        <NBPagination TotalPages="10" @bind-CurrentPage="_page" />
        <p>Current page: @_page</p>

        @code {
            private int _page = 1;
        }
        """;

    public const string PaginationFew = """
        <NBPagination TotalPages="5" @bind-CurrentPage="_page2" />
        """;

    public const string PaginationMany = """
        <NBPagination TotalPages="50" @bind-CurrentPage="_page3" />
        """;

    // Tooltip
    public const string TooltipSides = """
        <NBTooltip Text="Top tooltip" Side="@NBTooltipSide.Top">
            <NBButton Variant="@NBButtonVariant.Neutral">Top</NBButton>
        </NBTooltip>

        <NBTooltip Text="Bottom" Side="@NBTooltipSide.Bottom">
            <NBButton Variant="@NBButtonVariant.Neutral">Bottom</NBButton>
        </NBTooltip>

        <NBTooltip Text="Left" Side="@NBTooltipSide.Left">
            <NBButton Variant="@NBButtonVariant.Neutral">Left</NBButton>
        </NBTooltip>

        <NBTooltip Text="Right" Side="@NBTooltipSide.Right">
            <NBButton Variant="@NBButtonVariant.Neutral">Right</NBButton>
        </NBTooltip>
        """;

    public const string TooltipAny = """
        <NBTooltip Text="Copy to clipboard">
            <button style="background:none;border:none;cursor:pointer;font-size:20px">📋</button>
        </NBTooltip>
        """;

    public const string TooltipEnum = """
        public enum NBTooltipSide { Top, Bottom, Left, Right }
        """;

    // Loading
    public const string LoadingDefault = """
        <NBLoading />
        """;

    public const string LoadingText = """
        <NBLoading Text="Loading data…" />
        """;

    public const string LoadingConditional = """
        @if (_loading)
        {
            <NBLoading Text="Saving…" />
        }
        else
        {
            <NBButton @onclick="Simulate">Save</NBButton>
        }

        @code {
            private bool _loading;

            private async Task Simulate()
            {
                _loading = true;
                await Task.Delay(2000);
                _loading = false;
            }
        }
        """;

    // Table
    public const string TableDefault = """
        <NBTable>
            <NBTableCaption>Q1 2025 Orders</NBTableCaption>
            <NBTableHeader>
                <NBTableRow>
                    <NBTableHead>Order</NBTableHead>
                    <NBTableHead>Customer</NBTableHead>
                    <NBTableHead>Status</NBTableHead>
                    <NBTableHead>Amount</NBTableHead>
                </NBTableRow>
            </NBTableHeader>
            <NBTableBody>
                <NBTableRow>
                    <NBTableCell>#1001</NBTableCell>
                    <NBTableCell>Alice Martin</NBTableCell>
                    <NBTableCell><NBBadge>Paid</NBBadge></NBTableCell>
                    <NBTableCell>$240.00</NBTableCell>
                </NBTableRow>
            </NBTableBody>
        </NBTable>
        """;

    // Panel
    public const string PanelDefault = """
        <NBPanel Title="Statistics">
            <p>Revenue: $12,400</p>
            <p>Orders: 342</p>
        </NBPanel>
        """;

    public const string PanelNoTitle = """
        <NBPanel>
            <p>Content without a title bar.</p>
        </NBPanel>
        """;

    // Card
    public const string CardDefault = """
        <NBCard>
            <NBCardHeader>
                <NBCardTitle>Invoice #1042</NBCardTitle>
                <NBCardDescription>Due May 31 2025</NBCardDescription>
            </NBCardHeader>
            <NBCardContent>
                <p>Total amount: <strong>$2,400.00</strong></p>
            </NBCardContent>
            <NBCardFooter>
                <NBButton>Pay now</NBButton>
            </NBCardFooter>
        </NBCard>
        """;

    public const string CardClickable = """
        <NBCard OnClick="@HandleClick">
            <NBCardContent>
                <p>Click me!</p>
            </NBCardContent>
        </NBCard>

        @code {
            private void HandleClick() { /* ... */ }
        }
        """;

    public const string CardWithAction = """
        <NBCard>
            <NBCardHeader>
                <NBCardTitle>Team members</NBCardTitle>
                <NBCardAction>
                    <NBButton Variant="@NBButtonVariant.NoShadow" Size="@NBButtonSize.Small">Invite</NBButton>
                </NBCardAction>
            </NBCardHeader>
            <NBCardContent>
                <p>Alice, Bob, Charlie</p>
            </NBCardContent>
        </NBCard>
        """;

    // PageHeader
    public const string PageHeaderDefault = """
        <NBPageHeader>
            <div style="display:flex;justify-content:space-between;align-items:center;">
                <NBHeading Variant="@NBHeadingVariant.H1">Dashboard</NBHeading>
                <NBButton>New report</NBButton>
            </div>
        </NBPageHeader>
        """;

    public const string PageHeaderBreadcrumb = """
        <NBPageHeader>
            <NBBreadcrumb Items="_crumbs" />
            <NBHeading Variant="@NBHeadingVariant.H2" style="margin-top:8px">Settings</NBHeading>
        </NBPageHeader>

        @code {
            private List<NBBreadcrumbItem> _crumbs = new()
            {
                new("Home", "/"),
                new("Admin", "/admin"),
                new("Settings", null)
            };
        }
        """;

    // Drawer
    public const string DrawerDefault = """
        <NBButton @onclick="() => _open = true">Open drawer</NBButton>

        <NBDrawer IsVisible="_open" Title="Cart" OnClose="@(() => _open = false)">
            <p>Item 1 — $12.00</p>
            <p>Item 2 — $8.50</p>
            <NBButton style="margin-top:16px">Checkout</NBButton>
        </NBDrawer>

        @code {
            private bool _open;
        }
        """;

    public const string DrawerHeaderExtra = """
        <NBDrawer IsVisible="_open2" Title="Filters" OnClose="@(() => _open2 = false)">
            <HeaderExtra>
                <NBBadge>3 active</NBBadge>
            </HeaderExtra>
            <p>Filter controls here…</p>
        </NBDrawer>
        """;

    // Dialog
    public const string DialogDefault = """
        <NBButton @onclick="() => _open = true">Open dialog</NBButton>

        <NBDialog IsVisible="_open" Title="Delete item?" OnClose="@(() => _open = false)">
            <p>This action is permanent and cannot be undone.</p>
            <NBFormActions>
                <NBButton Variant="@NBButtonVariant.Neutral" @onclick="() => _open = false">Cancel</NBButton>
                <NBButton Variant="@NBButtonVariant.Danger">Delete</NBButton>
            </NBFormActions>
        </NBDialog>

        @code {
            private bool _open;
        }
        """;

    public const string DialogBackdrop = """
        <NBDialog IsVisible="_open2" Title="Light dismiss" CloseOnBackdrop="true" OnClose="@(() => _open2 = false)">
            <p>Click outside to close.</p>
        </NBDialog>
        """;

    // Input
    public const string InputDefault = """
        <NBInput Id="name" Label="Full name" @bind-Value="_val" Placeholder="John Doe" />

        @code {
            private string? _val;
        }
        """;

    public const string InputSubtitle = """
        <NBInput Id="email" Label="Email" @bind-Value="_email"
                 Subtitle="We will never share your email."
                 Placeholder="you@example.com" />
        """;

    public const string InputError = """
        <NBInput Id="err" Label="Username" @bind-Value="_user" ErrorMessage="Username is already taken." />
        """;

    public const string InputDisabled = """
        <NBInput Id="dis" Label="Account ID" Value="ACC-0042" Disabled="true" />
        """;

    public const string InputTypes = """
        <NBInput Id="pwd" Label="Password" Type="@NBInputType.Password" @bind-Value="_pwd" />
        <NBInput Id="num" Label="Amount" Type="@NBInputType.Number" @bind-Value="_num" />
        """;

    // TextArea
    public const string TextAreaDefault = """
        <NBTextArea Id="bio" Label="Bio" @bind-Value="_bio" Placeholder="Tell us about yourself…" />

        @code {
            private string? _bio;
        }
        """;

    public const string TextAreaActions = """
        <NBTextArea Id="msg" Label="Message" @bind-Value="_msg" Rows="5">
            <Actions>
                <NBButton Size="@NBButtonSize.Small">Send</NBButton>
            </Actions>
        </NBTextArea>
        """;

    public const string TextAreaDisabled = """
        <NBTextArea Id="dis" Label="Notes" Value="Read-only content." Disabled="true" />
        """;

    // Select
    public const string SelectDefault = """
        <NBSelect Id="role" Label="Role" @bind-Value="_role"
                  Placeholder="Choose a role"
                  Options="_roles" />

        @code {
            private string? _role;

            private readonly List<NBSelectOption> _roles =
            [
                new("admin", "Administrator"),
                new("editor", "Editor"),
                new("viewer", "Viewer")
            ];
        }
        """;

    public const string SelectSubtitle = """
        <NBSelect Id="country" Label="Country" @bind-Value="_country"
                  Subtitle="Your billing country."
                  Options="_countries" />
        """;

    public const string SelectDisabled = """
        <NBSelect Id="dis" Label="Plan" Value="pro" Disabled="true" Options="_plans" />
        """;

    public const string SelectRecord = """
        // record NBSelectOption(string Value, string Label);
        var options = new List<NBSelectOption>
        {
            new("en", "English"),
            new("it", "Italian"),
            new("fr", "French")
        };
        """;

    // Checkbox
    public const string CheckboxDefault = """
        <NBCheckbox Id="terms" Label="I agree to the terms and conditions" @bind-Checked="_terms" />

        @code {
            private bool _terms;
        }
        """;

    public const string CheckboxChecked = """
        <NBCheckbox Id="news" Label="Send me newsletters" @bind-Checked="_news" />

        @code {
            private bool _news = true;
        }
        """;

    public const string CheckboxDisabled = """
        <NBCheckbox Id="dis1" Label="Disabled unchecked" Disabled="true" />
        <NBCheckbox Id="dis2" Label="Disabled checked" Checked="true" Disabled="true" />
        """;

    // Switch
    public const string SwitchDefault = """
        <NBSwitch @bind-Checked="_on" Label="Enable notifications" />

        @code {
            private bool _on;
        }
        """;

    public const string SwitchOn = """
        <NBSwitch @bind-Checked="_on2" Label="Dark mode" />

        @code {
            private bool _on2 = true;
        }
        """;

    public const string SwitchNoLabel = """
        <NBSwitch @bind-Checked="_on3" />
        """;

    public const string SwitchDisabled = """
        <NBSwitch Label="Disabled off" Disabled="true" />
        <NBSwitch Label="Disabled on" Checked="true" Disabled="true" />
        """;

    // RadioGroup
    public const string RadioGroupDefault = """
        <NBRadioGroup Options="_sizes" @bind-Value="_size" />

        @code {
            private string? _size = "md";

            private readonly List<NBRadioOption> _sizes =
            [
                new("sm", "Small"),
                new("md", "Medium"),
                new("lg", "Large")
            ];
        }
        """;

    public const string RadioGroupDisabledOption = """
        <NBRadioGroup Options="_plans" @bind-Value="_plan" />

        @code {
            private string? _plan = "pro";

            private readonly List<NBRadioOption> _plans =
            [
                new("free", "Free"),
                new("pro", "Pro"),
                new("enterprise", "Enterprise (Coming soon)", Disabled: true)
            ];
        }
        """;

    public const string RadioGroupAllDisabled = """
        <NBRadioGroup Options="_sizes" Value="sm" Disabled="true" />
        """;

    public const string RadioRecord = """
        // record NBRadioOption(string Value, string Label, bool Disabled = false);
        var options = new List<NBRadioOption>
        {
            new("a", "Option A"),
            new("b", "Option B"),
            new("c", "Option C (locked)", Disabled: true)
        };
        """;

    // Slider
    public const string SliderDefault = """
        <NBSlider Label="Volume" @bind-Value="_vol" Min="0" Max="100" />
        <p>Value: @_vol</p>

        @code {
            private double _vol = 40;
        }
        """;

    public const string SliderTwoThumbs = """
        <NBSlider Label="Price range" @bind-Values="_range" Min="0" Max="100" />
        <p>@_range[0] – @_range[1]</p>

        @code {
            private double[] _range = [25, 75];
        }
        """;

    public const string SliderVertical = """
        <NBSlider @bind-Value="_vert" Min="0" Max="100"
                  Orientation="NBSliderOrientation.Vertical" />

        @code {
            private double _vert = 50;
        }
        """;

    public const string SliderControlled = """
        <NBSlider Label="Temperature" @bind-Values="_temp"
                  Min="0" Max="1" Step="0.1" />
        <p>@string.Join(", ", _temp)</p>

        @code {
            private double[] _temp = [0.3, 0.7];
        }
        """;

    public const string SliderDisabled = """
        <NBSlider Label="Disabled" Value="60" Disabled="true" />
        """;

    // ImageUpload
    public const string ImageUploadDefault = """
        <NBImageUpload Label="Product photos"
                       ExistingImages="_existing"
                       PendingFiles="_pending"
                       OnFileAdded="AddFile"
                       OnExistingRemoved="RemoveExisting"
                       OnPendingRemoved="RemovePending" />

        @code {
            private List<NBExistingImage> _existing = [];
            private List<NBImageUploadFile> _pending = [];

            private void AddFile(NBImageUploadFile f) => _pending.Add(f);
            private void RemoveExisting(NBExistingImage img) => _existing.Remove(img);
            private void RemovePending(NBImageUploadFile f) => _pending.Remove(f);
        }
        """;

    public const string ImageUploadModels = """
        // NBExistingImage — already-saved image
        public class NBExistingImage
        {
            public string Src { get; set; } = "";  // URL to the saved image
            public string? Id { get; set; }        // Optional server ID for deletion
        }

        // NBImageUploadFile — unsaved selected file
        public class NBImageUploadFile
        {
            public Guid Id { get; init; } = Guid.NewGuid();
            public IBrowserFile BrowserFile { get; init; } = default!;
        }
        """;

    // FormGroup
    public const string FormGroupStacked = """
        <NBFormGroup>
            <NBInput Id="fg-name" Label="Full name" @bind-Value="_name" />
            <NBInput Id="fg-email" Label="Email" @bind-Value="_email" Type="@NBInputType.Email" />
            <NBSelect Id="fg-role" Label="Role" @bind-Value="_role" Options="_roles" />
        </NBFormGroup>
        """;

    public const string FormGroupInlineActions = """
        <NBFormGroup>
            <NBInput Id="promo" Label="Promo code" @bind-Value="_code" Placeholder="SUMMER25" />
            <Actions>
                <NBButton Size="@NBButtonSize.Small">Apply</NBButton>
            </Actions>
        </NBFormGroup>
        """;

    public const string FormActionsDefault = """
        <NBFormActions>
            <NBButton Variant="@NBButtonVariant.Neutral">Cancel</NBButton>
            <NBButton>Save changes</NBButton>
        </NBFormActions>
        """;

    // Heading
    public const string HeadingAll = """
        <NBHeading Variant="@NBHeadingVariant.H1">H1 — Page title</NBHeading>
        <NBHeading Variant="@NBHeadingVariant.H2">H2 — Section title</NBHeading>
        <NBHeading Variant="@NBHeadingVariant.H3">H3 — Sub-section</NBHeading>
        <NBHeading Variant="@NBHeadingVariant.H4">H4 — Card title</NBHeading>
        <NBHeading Variant="@NBHeadingVariant.H5">H5 — Sidebar group</NBHeading>
        <NBHeading Variant="@NBHeadingVariant.H6">H6 — Caption heading</NBHeading>
        """;

    public const string HeadingEnum = """
        public enum NBHeadingVariant { H1, H2, H3, H4, H5, H6 }
        """;

    // Title
    public const string TitleAll = """
        <NBTitle Variant="@NBTitleVariant.Title">Page title</NBTitle>
        <NBTitle Variant="@NBTitleVariant.Subtitle">A short description of the page content.</NBTitle>
        <NBTitle Variant="@NBTitleVariant.Section">Section heading</NBTitle>
        <NBTitle Variant="@NBTitleVariant.SubSection">Sub-section heading</NBTitle>
        """;

    public const string TitleEnum = """
        public enum NBTitleVariant { Title, Subtitle, Section, SubSection }
        """;

    // Label
    public const string LabelStandalone = """
        <NBLabel For="my-input">First name</NBLabel>
        <input id="my-input" class="nb-input" placeholder="John" />
        """;

    public const string LabelNoFor = """
        <NBLabel>Section title (no bound input)</NBLabel>
        """;

    // Theming
    public const string GettingStartedUsing = "@using NeoBrutalism.Blazor";

    public const string GettingStartedLink = """<link rel="stylesheet" href="_content/NeoBrutalism.Blazor/nb-design-system.css" />""";

    public const string GettingStartedFont = """
        <link rel="preconnect" href="https://fonts.googleapis.com" />
        <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;700;800;900&display=swap" rel="stylesheet" />
        """;

    // Theming
    public const string ThemingProvider = """
        <NBThemeProvider Theme="@_theme">
            <Routes />
        </NBThemeProvider>

        @code {
            private NBTheme _theme = new()
            {
                Primary = "#6366f1",
                PrimaryHover = "#4f46e5",
                Background = "#faf5ff"
            };
        }
        """;

    public const string ThemingCssOverride = """
        :root {
            --nb-primary: #6366f1;
            --nb-primary-hover: #4f46e5;
            --nb-shadow: 6px 6px 0 #000;
            --nb-border-width: 3px;
        }
        """;

    // ImageCard
    public const string ImageCardDefault = """
        <NBImageCard ImageUrl="https://picsum.photos/seed/nb1/400/300" Caption="A beautiful landscape" />
        """;

    public const string ImageCardCustom = """
        <NBImageCard ImageUrl="https://picsum.photos/seed/nb2/400/300"
                     Caption="Custom alt text"
                     Alt="Mountain view at sunset" />
        """;

    // Marquee
    public const string MarqueeDefault = """
        <NBMarquee Items="@(new[] { "Neobrutalism", "Blazor", "Components", "Open Source", "Tailwind" })" />
        """;

    public const string MarqueePauseHover = """
        <NBMarquee Items="@(new[] { "Hover me!", "I will pause", "Then continue" })"
                   PauseOnHover="true" Speed="15s" />
        """;

    // Popover
    public const string PopoverDefault = """
        <NBPopover Side="NBPopoverSide.Bottom">
            <NBButton Variant="@NBButtonVariant.Neutral">Open Popover</NBButton>
            <Content>
                <p style="margin:0">This is a popover content area.</p>
            </Content>
        </NBPopover>
        """;

    public const string PopoverSides = """
        <NBPopover Side="NBPopoverSide.Top">
            <NBButton Variant="@NBButtonVariant.Neutral">Top</NBButton>
            <Content><p style="margin:0">Top popover</p></Content>
        </NBPopover>

        <NBPopover Side="NBPopoverSide.Right">
            <NBButton Variant="@NBButtonVariant.Neutral">Right</NBButton>
            <Content><p style="margin:0">Right popover</p></Content>
        </NBPopover>
        """;

    // AlertDialog
    public const string AlertDialogDefault = """
        <NBButton Variant="@NBButtonVariant.Danger" OnClick="() => _alertOpen = true">Delete account</NBButton>

        <NBAlertDialog IsVisible="_alertOpen"
                       Title="Are you absolutely sure?"
                       Description="This action cannot be undone. This will permanently delete your account."
                       OnConfirm="() => _alertOpen = false"
                       OnCancel="() => _alertOpen = false" />

        @code {
            private bool _alertOpen;
        }
        """;

    public const string AlertDialogCustomButtons = """
        <NBAlertDialog IsVisible="_open2"
                       Title="Discard changes?"
                       Description="You have unsaved changes."
                       ConfirmText="Discard"
                       CancelText="Keep editing"
                       ConfirmVariant="@NBButtonVariant.Danger"
                       OnConfirm="() => _open2 = false"
                       OnCancel="() => _open2 = false" />
        """;

    // ContextMenu
    public const string ContextMenuDefault = """
        <NBContextMenu>
            <div style="border: 2px dashed #ccc; padding: 2rem; text-align: center;">
                Right-click here
            </div>
            <MenuContent>
                <NBContextMenuLabel>Actions</NBContextMenuLabel>
                <NBContextMenuSeparator />
                <NBContextMenuItem>Copy</NBContextMenuItem>
                <NBContextMenuItem>Paste</NBContextMenuItem>
                <NBContextMenuSeparator />
                <NBContextMenuItem Shortcut="⌘Z">Undo</NBContextMenuItem>
                <NBContextMenuItem Disabled="true">Delete</NBContextMenuItem>
            </MenuContent>
        </NBContextMenu>
        """;

    // InputOtp
    public const string InputOtpDefault = """
        <NBInputOtp Length="6" @bind-Value="_otp" />
        <p>Value: @_otp</p>

        @code {
            private string? _otp;
        }
        """;

    public const string InputOtpFour = """
        <NBInputOtp Length="4" @bind-Value="_pin" />
        """;

    // Command
    public const string CommandDefault = """
        <NBCommand Groups="_commandGroups" OnSelect="HandleSelect" />

        @code {
            private readonly List<NBCommandGroup> _commandGroups =
            [
                new("Suggestions", new NBCommandItem[]
                {
                    new("Calendar", "calendar"),
                    new("Search", "search"),
                    new("Settings", "settings", "⌘S")
                }),
                new("Actions", new NBCommandItem[]
                {
                    new("Create new file", "new-file"),
                    new("Open recent", "open-recent", "⌘R")
                })
            ];

            private void HandleSelect(NBCommandItem item) { /* ... */ }
        }
        """;

    // ComboBox
    public const string ComboBoxDefault = """
        <NBComboBox Id="framework" Label="Framework"
                    @bind-Value="_framework"
                    Placeholder="Select framework…"
                    SearchPlaceholder="Search frameworks…"
                    Options="_frameworks" />

        @code {
            private string? _framework;

            private readonly List<NBSelectOption> _frameworks =
            [
                new("blazor", "Blazor"),
                new("react", "React"),
                new("vue", "Vue"),
                new("angular", "Angular"),
                new("svelte", "Svelte")
            ];
        }
        """;

    // Calendar
    public const string CalendarSingle = """
        <NBCalendar @bind-SelectedDate="_date" />
        <p>Selected: @_date?.ToString("dd/MM/yyyy")</p>

        @code {
            private DateTime? _date;
        }
        """;

    public const string CalendarRange = """
        <NBCalendar Mode="NBCalendarMode.Range"
                    @bind-RangeStart="_start"
                    @bind-RangeEnd="_end" />
        <p>@_start?.ToString("dd/MM") – @_end?.ToString("dd/MM")</p>

        @code {
            private DateTime? _start;
            private DateTime? _end;
        }
        """;

    // DatePicker
    public const string DatePickerDefault = """
        <NBDatePicker Id="dob" Label="Date of birth" @bind-Value="_dob" />
        <p>@_dob?.ToString("dd/MM/yyyy")</p>

        @code {
            private DateTime? _dob;
        }
        """;

    public const string DatePickerMinMax = """
        <NBDatePicker Id="booking" Label="Booking date"
                      @bind-Value="_booking"
                      MinDate="DateTime.Today"
                      MaxDate="DateTime.Today.AddMonths(3)" />
        """;

    // MenuBar
    public const string MenuBarDefault = """
        <NBMenuBar>
            <NBMenuBarMenu Label="File">
                <NBMenuBarItem>New File</NBMenuBarItem>
                <NBMenuBarItem Shortcut="⌘O">Open</NBMenuBarItem>
                <NBMenuBarSeparator />
                <NBMenuBarItem Shortcut="⌘S">Save</NBMenuBarItem>
            </NBMenuBarMenu>
            <NBMenuBarMenu Label="Edit">
                <NBMenuBarItem Shortcut="⌘Z">Undo</NBMenuBarItem>
                <NBMenuBarItem Shortcut="⌘Y">Redo</NBMenuBarItem>
            </NBMenuBarMenu>
            <NBMenuBarMenu Label="View">
                <NBMenuBarItem>Zoom In</NBMenuBarItem>
                <NBMenuBarItem>Zoom Out</NBMenuBarItem>
            </NBMenuBarMenu>
        </NBMenuBar>
        """;

    // NavigationMenu
    public const string NavigationMenuDefault = """
        <NBNavigationMenu>
            <NBNavigationMenuItem Label="Getting Started">
                <Content>
                    <NBNavigationMenuLink Href="getting-started">Installation</NBNavigationMenuLink>
                    <NBNavigationMenuLink Href="theming">Theming</NBNavigationMenuLink>
                </Content>
            </NBNavigationMenuItem>
            <NBNavigationMenuItem Label="Components">
                <Content>
                    <NBNavigationMenuLink Href="components/button">Button</NBNavigationMenuLink>
                    <NBNavigationMenuLink Href="components/card">Card</NBNavigationMenuLink>
                    <NBNavigationMenuLink Href="components/dialog">Dialog</NBNavigationMenuLink>
                </Content>
            </NBNavigationMenuItem>
            <NBNavigationMenuItem Label="GitHub" Href="https://github.com" />
        </NBNavigationMenu>
        """;

    // Carousel
    public const string CarouselDefault = """
        <NBCarousel SlideCount="3">
            <NBCarouselItem>
                <div style="padding:2rem; text-align:center; background:var(--nb-bg-secondary)">Slide 1</div>
            </NBCarouselItem>
            <NBCarouselItem>
                <div style="padding:2rem; text-align:center; background:var(--nb-primary); color:white">Slide 2</div>
            </NBCarouselItem>
            <NBCarouselItem>
                <div style="padding:2rem; text-align:center; background:var(--nb-bg-secondary)">Slide 3</div>
            </NBCarouselItem>
        </NBCarousel>
        """;

    public const string CarouselAutoPlay = """
        <NBCarousel SlideCount="3" AutoPlay="true" AutoPlayInterval="2000">
            <NBCarouselItem><div style="padding:3rem;text-align:center;background:#fef3c7">Auto 1</div></NBCarouselItem>
            <NBCarouselItem><div style="padding:3rem;text-align:center;background:#dbeafe">Auto 2</div></NBCarouselItem>
            <NBCarouselItem><div style="padding:3rem;text-align:center;background:#dcfce7">Auto 3</div></NBCarouselItem>
        </NBCarousel>
        """;

    public const string CarouselHideArrows = """
        <NBCarousel SlideCount="3" HideArrows="true">
            <NBCarouselItem><div style="padding:2rem; text-align:center; background:var(--nb-bg-secondary)">Slide 1</div></NBCarouselItem>
            <NBCarouselItem><div style="padding:2rem; text-align:center; background:var(--nb-primary); color:white">Slide 2</div></NBCarouselItem>
            <NBCarouselItem><div style="padding:2rem; text-align:center; background:var(--nb-bg-secondary)">Slide 3</div></NBCarouselItem>
        </NBCarousel>
        """;

    // DataTable
    public const string DataTableDefault = """
        <NBDataTable Items="_payments" Columns="_columns" Searchable="true"
                     SearchField="@(p => p.Email)" PageSize="5" />

        @code {
            record Payment(string Id, string Email, string Status, decimal Amount);

            private readonly List<Payment> _payments =
            [
                new("#1001", "alice@example.com", "Paid", 240.00m),
                new("#1002", "bob@example.com", "Pending", 125.50m),
                new("#1003", "charlie@example.com", "Paid", 890.00m)
            ];

            private readonly List<NBDataTableColumn<Payment>> _columns =
            [
                new() { Title = "Order", Field = p => p.Id },
                new() { Title = "Email", Field = p => p.Email, Sortable = true },
                new() { Title = "Status", Field = p => p.Status },
                new() { Title = "Amount", Field = p => p.Amount.ToString("C"), Sortable = true }
            ];
        }
        """;

    // Sidebar
    public const string SidebarDefault = """
        <NBSidebarProvider @bind-Open="_sidebarOpen">
            <NBSidebar>
                <NBSidebarHeader>
                    <span style="font-weight:700">My App</span>
                </NBSidebarHeader>
                <NBSidebarContent>
                    <NBSidebarGroup>
                        <NBSidebarGroupLabel>Navigation</NBSidebarGroupLabel>
                        <NBSidebarMenu>
                            <NBSidebarMenuItem>
                                <NBSidebarMenuButton IsActive="true">Dashboard</NBSidebarMenuButton>
                            </NBSidebarMenuItem>
                            <NBSidebarMenuItem>
                                <NBSidebarMenuButton>Settings</NBSidebarMenuButton>
                            </NBSidebarMenuItem>
                        </NBSidebarMenu>
                    </NBSidebarGroup>
                </NBSidebarContent>
                <NBSidebarFooter>
                    <span style="font-size:0.75rem">v1.0.0</span>
                </NBSidebarFooter>
            </NBSidebar>
            <NBSidebarInset>
                <div style="padding:1rem">
                    <NBSidebarTrigger />
                    <p>Main content area</p>
                </div>
            </NBSidebarInset>
        </NBSidebarProvider>

        @code {
            private bool _sidebarOpen = true;
        }
        """;

    // Sonner
    public const string SonnerSetup = """
        // In Program.cs:
        builder.Services.AddScoped<NBSonnerService>();

        // In your layout or App.razor:
        <NBSonner Position="NBSonnerPosition.BottomRight" />
        """;

    public const string SonnerUsage = """
        @inject NBSonnerService Sonner

        <NBButton OnClick="ShowToast">Show Toast</NBButton>
        <NBButton Variant="@NBButtonVariant.Success" OnClick="ShowSuccess">Success</NBButton>
        <NBButton Variant="@NBButtonVariant.Danger" OnClick="ShowError">Error</NBButton>

        @code {
            private void ShowToast() => Sonner.Show("Event created", "Monday, January 1st at 9:00 AM");
            private void ShowSuccess() => Sonner.Success("Saved successfully!");
            private void ShowError() => Sonner.Error("Something went wrong.");
        }
        """;

    // Hero
    public const string HeroCentered = """
        <NBHero Title="Build faster with NeoBrutalism"
                Subtitle="A bold, expressive component library for Blazor.">
            <Cta>
                <NBButton>Get Started</NBButton>
                <NBButton Variant="@NBButtonVariant.Neutral">Learn More</NBButton>
            </Cta>
        </NBHero>
        """;

    public const string HeroSplit = """
        <NBHero Variant="@NBHeroVariant.Split"
                Title="Ship with confidence"
                Subtitle="Neo Brutalism components that look great out of the box.">
            <Cta>
                <NBButton>Start Free</NBButton>
            </Cta>
            <Visual>
                <img src="hero.png" alt="Hero visual" />
            </Visual>
        </NBHero>
        """;

    public const string HeroEnum = """
        public enum NBHeroVariant { Centered, Split }
        """;

    public const string HeroBackground = """
        <NBHero Title="Welcome to the jungle"
                Subtitle="Epic hero with a background image and overlay."
                BackgroundImage="https://example.com/bg.jpg">
            <Cta>
                <NBButton>Explore</NBButton>
            </Cta>
        </NBHero>
        """;

    // Section
    public const string SectionDefault = """
        <NBSection Title="Our Features" Subtitle="Everything you need to build great apps.">
            <p>Section body content goes here.</p>
        </NBSection>
        """;

    public const string SectionSecondary = """
        <NBSection Title="Testimonials" Background="@NBSectionBackground.Secondary">
            <p>Customer reviews go here.</p>
        </NBSection>
        """;

    public const string SectionEnum = """
        public enum NBSectionBackground { Default, Secondary }
        public enum NBSectionAlign { Center, Left, Right }
        """;

    public const string SectionLeftAlign = """
        <NBSection Title="About Us" Subtitle="Our story and mission." Align="@NBSectionAlign.Left">
            <p>Left-aligned section content.</p>
        </NBSection>
        """;

    // Timeline
    public const string TimelineDefault = """
        <NBTimeline>
            <NBTimelineStep Title="Order placed" Description="Your order has been confirmed."
                            State="NBTimelineStepState.Completed" />
            <NBTimelineStep Title="Processing" Description="We are preparing your items."
                            State="NBTimelineStepState.Active" />
            <NBTimelineStep Title="Shipped" Description="On the way to your address."
                            State="NBTimelineStepState.Upcoming" />
            <NBTimelineStep Title="Delivered" Description="Package arrives at destination."
                            State="NBTimelineStepState.Upcoming" />
        </NBTimeline>
        """;

    public const string TimelineEnum = """
        public enum NBTimelineStepState { Completed, Active, Upcoming }
        public enum NBTimelineOrientation { Vertical, Horizontal }
        """;

    public const string TimelineHorizontal = """
        <NBTimeline Orientation="@NBTimelineOrientation.Horizontal">
            <NBTimelineStep Title="Step 1" Description="Research"
                            State="NBTimelineStepState.Completed" />
            <NBTimelineStep Title="Step 2" Description="Design"
                            State="NBTimelineStepState.Active" />
            <NBTimelineStep Title="Step 3" Description="Develop"
                            State="NBTimelineStepState.Upcoming" />
            <NBTimelineStep Title="Step 4" Description="Launch"
                            State="NBTimelineStepState.Upcoming" />
        </NBTimeline>
        """;

    // Footer
    public const string FooterDefault = """
        <NBFooter Copyright="© 2026 Acme Inc. All rights reserved.">
            <Columns>
                <NBFooterColumn Title="Product">
                    <a href="#">Features</a>
                    <a href="#">Pricing</a>
                    <a href="#">Changelog</a>
                </NBFooterColumn>
                <NBFooterColumn Title="Company">
                    <a href="#">About</a>
                    <a href="#">Blog</a>
                    <a href="#">Careers</a>
                </NBFooterColumn>
                <NBFooterColumn Title="Legal">
                    <a href="#">Privacy</a>
                    <a href="#">Terms</a>
                </NBFooterColumn>
            </Columns>
        </NBFooter>
        """;

    // Feature Card
    public const string FeatureCardDefault = """
        <div style="display:grid;grid-template-columns:repeat(3,1fr);gap:1rem;">
            <NBFeatureCard Title="Fast" Description="Blazing fast performance out of the box.">
                <Icon><svg>…</svg></Icon>
            </NBFeatureCard>
            <NBFeatureCard Title="Accessible" Description="Built with accessibility in mind.">
                <Icon><svg>…</svg></Icon>
            </NBFeatureCard>
            <NBFeatureCard Title="Themeable" Description="Customize everything via CSS variables.">
                <Icon><svg>…</svg></Icon>
            </NBFeatureCard>
        </div>
        """;

    public const string FeatureCardWithImage = """
        <div style="display:grid;grid-template-columns:repeat(3,1fr);gap:1rem;">
            <NBFeatureCard Title="Dashboard" Description="Monitor your metrics."
                          ImageSrc="dashboard.jpg" ImageAlt="Dashboard screenshot" />
            <NBFeatureCard Title="Analytics" Description="Deep insights."
                          ImageSrc="analytics.jpg" ImageAlt="Analytics screenshot" />
            <NBFeatureCard Title="Reports" Description="Generate PDF reports."
                          ImageSrc="reports.jpg" ImageAlt="Reports screenshot" />
        </div>
        """;

    // Stat Card
    public const string StatCardDefault = """
        <div style="display:grid;grid-template-columns:repeat(3,1fr);gap:1rem;">
            <NBStatCard Value="1,234" Label="Active users" Trend="@NBStatCardTrend.Up" />
            <NBStatCard Value="$48K" Label="Revenue" Trend="@NBStatCardTrend.Up" />
            <NBStatCard Value="3.2%" Label="Bounce rate" Trend="@NBStatCardTrend.Down" />
        </div>
        """;

    public const string StatCardNoTrend = """
        <div style="display:grid;grid-template-columns:repeat(2,1fr);gap:1rem;">
            <NBStatCard Value="99.9%" Label="Uptime" />
            <NBStatCard Value="42" Label="Open issues" />
        </div>
        """;

    public const string StatCardEnum = """
        public enum NBStatCardTrend { None, Up, Down }
        """;
}
