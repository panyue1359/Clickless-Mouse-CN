# AGENTS.md

## Project Overview

Clickless Mouse is a Windows WPF application targeting `.NET Framework 4.5.2`. The current source version is `2.2`.

## Repository Layout

- `Clickless Mouse/Clickless Mouse.sln` is the solution entry point.
- `Clickless Mouse/Clickless Mouse/` contains the application source.
- `MainWindow.xaml` and `MainWindow.xaml.cs` implement the main UI and most runtime behavior.
- `Language.cs` contains the English and Polish UI/manual text.
- `WindowChangelog.xaml.cs` contains the in-app changelog text.
- `other/latest_version.txt` is the version file checked by the update prompt.
- `other/images/` stores screenshots and contact assets used by the README.

## Runtime Notes

- The app stores settings beside the executable in `settings.txt`.
- Enabling startup writes a `Run` registry entry and generates a sibling `.vbs` launcher.
- Version `2.2` includes update checks and documents administrator-rights requirement in the changelog.
- The manual text in `Language.cs` states that exclusive fullscreen is unsupported; windowed or borderless mode is expected.

## Documentation Rules

- Keep `readme.md` aligned with code-visible behavior, requirements, and build entry points.
- If supported languages, runtime prerequisites, or update behavior change, update both `readme.md` and this file.
- Do not add session history here; keep only durable project facts and editing rules.
