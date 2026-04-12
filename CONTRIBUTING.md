# Contributing to NeoBrutalism.Blazor

Thank you for your interest in contributing! Here's how to get started.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (for Tailwind CSS build)

## Getting started

1. Fork and clone the repository
2. Install Node dependencies:
   ```bash
   cd src && npm ci
   ```
3. Build the library:
   ```bash
   dotnet build src/NeoBrutalism.Blazor.csproj
   ```
4. Run the docs site locally:
   ```bash
   cd docs && dotnet watch
   ```

## Project structure

| Path | Description |
|------|-------------|
| `src/` | Razor Class Library (components, enums, models, CSS) |
| `docs/` | Blazor WASM documentation site |
| `tests/` | bUnit tests |

## Submitting changes

1. Create a feature branch from `main`:
   ```bash
   git checkout -b feature/my-change
   ```
2. Make your changes and ensure the project builds without warnings.
3. Add or update tests if applicable.
4. Open a Pull Request against `main` with a clear description of the change.

## Code style

- Follow the `.editorconfig` conventions already in the repository.
- Use `NB` prefix for all public component names (e.g. `NBButton`, `NBCard`).
- All public APIs must have XML doc comments.

## Reporting issues

Use the GitHub issue templates to report bugs or request features.

## License

By contributing, you agree that your contributions will be licensed under the [MIT License](LICENSE).
