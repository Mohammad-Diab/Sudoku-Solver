# Sudoku Solver

A Sudoku solver for Windows: type a puzzle into the 9 by 9 grid and the app fills in the empty cells. Written in C# with WPF on .NET Framework 4.5.2.

## Features

- Enter the given digits (1 to 9) in the grid and leave `?` in the empty cells. Any other character is rejected.
- **Check** tells you if the grid breaks a row, column or 3 by 3 box rule, or if it is already solved.
- **Solve** fills the empty cells with a backtracking search, or tells you the puzzle has no solution. Hard puzzles can take a while: the search runs in the background and the button turns into **Cancel** until it finishes.
- **Copy** puts the grid on the clipboard as 9 tab-separated rows (`?` for empty cells), ready to paste into Excel or a text file. **Paste** reads 81 digits back from the clipboard (`0` or `?` for an empty cell).
- Clear one row or column with the buttons at the edge of the grid, or the whole grid with **Clear all**.
- **Home** and **End** jump to the first and last cell; **Up**, **Down**, **Page Up** and **Page Down** move between rows; **Left** and **Right** move to the previous and next cell, and **Enter** moves to the next one.

## Requirements

Windows with .NET Framework 4.5.2 or later. Windows 10 and 11 already include it.

## Usage

Download the `.7z` file of the latest version from [Releases](https://github.com/Mohammad-Diab/Sudoku-Solver/releases), extract it, and run `Sudoku Solver.exe`. There is no installer. Earlier versions are on the same page.

The exe is not signed, so Windows SmartScreen may warn the first time you run it: click **More info**, then **Run anyway**.

## Building

```
git clone https://github.com/Mohammad-Diab/Sudoku-Solver.git
```

Open `Sudoku Solver.sln` in Visual Studio and build, or run:

```
MSBuild "Sudoku Solver.sln" /p:Configuration=Release
```

The exe is written to `Sudoku Solver\bin\Release`.

The project targets .NET Framework 4.5.2. Recent Visual Studio versions don't ship its reference assemblies; if the build stops with `MSB3644`, extract the [Microsoft.NETFramework.ReferenceAssemblies.net452](https://www.nuget.org/packages/Microsoft.NETFramework.ReferenceAssemblies.net452) NuGet package and point MSBuild at its `build` folder:

```
MSBuild "Sudoku Solver.sln" /p:Configuration=Release /p:TargetFrameworkRootPath=<package>\build
```

## Author

Mohammad Diab

## License

[Apache 2.0](LICENSE)
