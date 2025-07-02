# Expenditure Tracker

A simple cross-platform expenditure tracking app made using AvaloniaUI, Entity Framework and SQLite.

## Getting Started

To build and run the project, make sure to install the dotnet ef tool. This will install the tool globally:

```bash
dotnet tool install --global dotnet-ef
```

You may need to add the dotnet tools directory to PATH.

Then generate the database model by running:

```bash
dotnet ef migrations add <migration_name>
```
