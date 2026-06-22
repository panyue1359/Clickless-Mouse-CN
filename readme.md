# Clickless Mouse

[中文说明 / Chinese README](./readme_CN.md)

## Download
[Download latest version](https://github.com/ProperCode/Clickless-Mouse/releases)

Version in this repository: `2.2`

**Languages:** English, Polish, Chinese

## Differences From The Original Project

This repository is not a plain mirror of the upstream `ProperCode/Clickless-Mouse` release. Compared with the original project, the current version in this repository emphasizes:
- Added Chinese UI and Chinese user-guide text.
- Added a Chinese README for local users.
- Added configurable auto-release behavior for left and right mouse-button hold actions after a short stop.
- Added a small red hold-state overlay indicator.
- Cleaned tracked Visual Studio and build-output artifacts from the repository and added ignore rules for future builds.

## Description

Clickless Mouse is a Windows desktop application for using a mouse without physical clicking. It is intended for people with repetitive strain injury, carpal tunnel syndrome, some motor disabilities, or temporary mouse-button failure.

The app watches mouse movement and shows action squares after the cursor stays idle. Moving the cursor into a square triggers one of these actions:
- Top center square = double left click
- Top left square = left click
- Top right square = right click
- Left square = left button hold on/off
- Right square = right button hold on/off

![Action squares](https://raw.githubusercontent.com/ProperCode/Clickless-Mouse/master/other/images/1en.jpg)

When the cursor stays inside a square long enough, the app returns the pointer to the previous position and performs the selected action.

Additional behavior in the current codebase:
- If the cursor is near the top edge, the top action squares are shown below the pointer.
- If the cursor is near the left or right edge, square size is reduced so part of each square remains visible.
- Unneeded squares can be disabled.
- Screen panning can map screen edges to arrow-key presses.
- Left and right button hold actions can be configured to release automatically after the cursor stops for a short time.
- A small red overlay dot indicates when the app is currently holding a mouse button down.
- Automatic update checks are available in version `2.2`.
- The app works only in windowed or borderless applications. Exclusive fullscreen is not supported.

## First Use

1. Enter the diagonal screen size and use `Set recommended square size`.
2. Enable only the mouse actions you need.
3. If the user has motor impairments, consider increasing idle time, movement start time, and square size.

Lowest accepted values enforced by the program:
- Cursor idle time before squares appear [ms]: `100`
- Hold release delay after stop [ms]: `10`
- Time to start mouse movement after squares appear [ms]: `300`
- Cursor time in square to register click [ms]: `10`
- Size [px]: `10`
- Border width [px]: `1`
- Minimum size [%]: `10`

## Requirements

- Windows
- .NET Framework `4.5.2`
- Administrator rights when running version `2.2`

Settings are stored next to the executable in `settings.txt`. Enabling startup also generates a sibling `.vbs` launcher used by the app's autorun entry.

The settings file is backward-compatible with older installs. Newer builds append hold-release options and the selected UI language after the existing values.

## Build

Open `Clickless Mouse/Clickless Mouse.sln` in Visual Studio and build the `Clickless Mouse` project for `Debug` or `Release`.

Project layout:
- `Clickless Mouse/Clickless Mouse.sln` - Visual Studio solution
- `Clickless Mouse/Clickless Mouse/` - WPF application source
- `Clickless Mouse/Clickless Mouse/HoldIndicator.cs` - WinForms overlay used to show active hold state
- `other/latest_version.txt` - remote version marker used by update checks
- `other/images/` - README and in-app documentation assets

## Screenshot

English UI:

![English UI screenshot](./other/images/2en.jpg)

Chinese UI:

![Chinese UI screenshot](./other/images/2zh.jpg)

## Awards
[![Softpedia Clean Award](https://raw.githubusercontent.com/ProperCode/Clickless-Mouse/master/other/awards/softpedia_100_free.png)](https://www.softpedia.com/get/Desktop-Enhancements/Other-Desktop-Enhancements/Clickless-Mouse.shtml#status)
[![Uptodown Clean Award](https://raw.githubusercontent.com/ProperCode/Clickless-Mouse/master/other/awards/certified-free.png)](https://clickless-mouse.en.uptodown.com/windows)
[![Updatestar Clean Award](https://raw.githubusercontent.com/ProperCode/Clickless-Mouse/master/other/awards/updatestar.com.jpg)](https://www.updatestar.com/virus-report/clickless-mouse/4021684)
[![Majorgeeks Award](https://raw.githubusercontent.com/ProperCode/Clickless-Mouse/master/other/awards/majorgeektested.gif)](https://www.majorgeeks.com/files/details/clickless_mouse.html)
[![File Transit 5/5 Award](https://raw.githubusercontent.com/ProperCode/Clickless-Mouse/master/other/awards/filetransit_5of5.gif)](http://www.filetransit.com/view.php?id=454284)

## Bug Reports and Feedback

To report a bug or send feedback, use the email address shown in the image below and include reproduction details plus screenshots when relevant.

![Contact email](https://raw.githubusercontent.com/ProperCode/Clickless-Mouse/master/other/images/email.jpg)

## Related Projects

[Aspiring Keyboard](https://github.com/ProperCode/Aspiring-Keyboard)

[Work by Speech](https://github.com/ProperCode/Work-by-Speech)
