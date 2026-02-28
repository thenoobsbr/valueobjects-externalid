# Contributing to TheNoobs.ValueObjects.ExternalId

Thank you for your interest in contributing to this project!
Whether you're fixing a bug, adding a feature, improving documentation, or reporting an issue — your help is
appreciated.

---

## Table of Contents

- [How to contribute](#-how-to-contribute)
- [Issue reporting](#-issue-reporting)
- [Pull request guidelines](#-pull-request-guidelines)
- [Development setup](#-development-setup)
- [Code style and conventions](#-code-style-and-conventions)
- [License](#-license)

---

## How to contribute

There are several ways to contribute:

- 🐛 Report a bug
- ✨ Propose or implement a feature
- 📝 Improve documentation
- 🔧 Refactor or optimize existing code
- ✅ Add tests or improve coverage

---

## Issue reporting

If you've encountered a bug or unexpected behavior:

1. Search [existing issues](https://github.com/thenoobsbr/valueobjects-externalid/issues) to avoid duplicates.
2. If none exists, open a **new issue** with:
    - Steps to reproduce
    - Expected behavior
    - Environment (.NET version, OS, etc.)
    - Error logs or test case (if available)

Clear, reproducible issues help us fix things faster.

---

## Pull request guidelines

To contribute code:

1. Fork the repository
2. Create a new branch:
    ```bash
       git checkout -b feature/my-feature
    ````
3. Write your code and tests
4. Run tests locally:
    ```bash
      dotnet test
    ```
5. Commit using clear messages
6. Push to your fork and open a PR against `main`

### PR checklist:

* [ ] Your code builds and tests pass
* [ ] Follows the coding style (see below)
* [ ] If you add functionality, include corresponding tests
* [ ] Reference related issues in the PR (e.g., `Fixes #12`)

---

## Development setup

You need:

* [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
* (Optionally) [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
* Git, an IDE (like Visual Studio or VS Code), and NuGet

Clone the repository:
```bash
git clone https://github.com/thenoobsbr/valueobjects-externalid.git
cd valueobjects-externalid
```

Run tests:
```bash
dotnet test
```

---

## Code style and conventions

*
Use [C# standard conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
* Prefer `async/await` over `Task.Result` or `.Wait()`
* Use explicit access modifiers (`public`, `private`, etc.)
* Tests follow the `Given_When_Then` pattern where appropriate

We recommend enabling automatic formatting with:

```bash
dotnet format
```

---

## License

By contributing, you agree that your code will be licensed under the [MIT License](LICENSE).
