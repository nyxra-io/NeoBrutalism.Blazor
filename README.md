# NeoBrutalism.Blazor

A Blazor Razor Class Library providing a complete set of **Neo Brutalism** UI components — bold borders, hard shadows, uppercase typography, and vibrant colors.



Inspired by [neobrutalism.dev](https://www.neobrutalism.dev), built natively for Blazor (.NET 10+).

---

## Installation



```bash
dotnet add package NeoBrutalism.Blazor
```

The package is published on [nuget.org](https://www.nuget.org/packages/NeoBrutalism.Blazor). No additional feed configuration is needed.



---

## Setup

### 1. Add the stylesheet

In `App.razor` (Blazor Web App) or `_Host.cshtml`, add the design system CSS **before** your own styles:

```html
<link rel="stylesheet" href="_content/NeoBrutalism.Blazor/nb-design-system.css" />
```

### 2. Add the global using

In your `_Imports.razor`:

```razor
@using NeoBrutalism.Blazor
```

That's it. All components, enums, and models are now available everywhere.

---

## Theming

All visual tokens are CSS custom properties (`--nb-*`). Override them in two ways.

### Option A — `NBThemeProvider` (scoped override)

```razor
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
```

### Option B — CSS override

```css
:root {
    --nb-primary: #6366f1;
    --nb-primary-hover: #4f46e5;
    --nb-shadow: 6px 6px 0 #000;
}
```

### Available tokens

| CSS variable | `NBTheme` property | Default | Description |
|---|---|---|---|
| `--nb-black` | `Black` | `#000000` | Borders and text |
| `--nb-white` | `White` | `#ffffff` | Component backgrounds |
| `--nb-bg` | `Background` | `#f5f0e8` | Page background |
| `--nb-bg-secondary` | `BackgroundDark` | `#e8dfd0` | Secondary background |
| `--nb-primary` | `Primary` | `#ff6b2b` | Primary accent |
| `--nb-primary-hover` | `PrimaryHover` | `#e55a1f` | Primary hover state |
| `--nb-danger` | `Danger` | `#ff4444` | Destructive color |
| `--nb-danger-hover` | `DangerHover` | `#cc3333` | Destructive hover |
| `--nb-success` | `Success` | `#22c55e` | Success color |
| `--nb-muted` | `Muted` | `#6b7280` | Muted/helper text |
| `--nb-shadow` | `Shadow` | `4px 4px 0 #000` | Hard shadow |
| `--nb-radius` | `Radius` | `0` | Border radius |
| `--nb-font` | `Font` | `'Inter', sans-serif` | Font family |

---

## Components

For the full component reference — usage examples, parameters, and live demos — see the **[documentation site](docs/)**.

---

## Running the docs locally

The docs are a Blazor WebAssembly app located in `docs/`.

```bash
cd docs
dotnet run
```

Then open the URL shown in the terminal (default: `http://localhost:5000`).

### Hot reload

```bash
dotnet watch
```

### Prerequisites

- .NET 10 SDK
- The library project in `src/` (already referenced via `ProjectReference`)

---

## Running the tests

The test project uses [bUnit](https://bunit.dev/) and xUnit. To run all tests:

```bash
dotnet test tests/NeoBrutalism.Blazor.Tests.csproj
```

---

## Contributing

Contributions are welcome! Please read [CONTRIBUTING.md](CONTRIBUTING.md) before submitting a PR.

---

## License

[MIT](LICENSE)
