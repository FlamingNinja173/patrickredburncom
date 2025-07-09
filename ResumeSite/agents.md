# Project Overview

This repository contains several .NET projects that powers the personal website at PatrickRedburn.com. The following summaries give a quick idea of what each major project is used for. All projects are built using .NET 9 and follow a modular architecture to separate concerns and facilitate development.

## Deployment Projects
- ResumeSite.Web
  - A Blazor WebAssembly application (client-side) that constitutes the entire website. This project contains the interactive web UI, pages, and shared components. It uses MudBlazor for styling.

## Support Projects
- ResumeSite.Model
  - Data models used by the ResumeSite.Web project. This includes classes that define the structure of the resume content, such as skills, certifications, and work history.

- ResumeSite.Export
  - A utility console project that migrates data from a sqlite database to JSON files. This is used to export resume data into a format that can be consumed by the ResumeSite.Web project.

# Coding Style
- Use PascalCase for public members, methods, and classes.
- Use camelCase for private members and parameters.
- Constants should be in UPPER_CASE_WITH_UNDERSCORES.
- Use meaningful names for variables, methods, and classes.
- For async methods, omit the Async suffix.
- Interface names are prefixed with I (e.g., IAuthenticationService).
- For methods with a return object, name the object `retVal` inside the method.
- Do not use _discards in method variables, always use meaningful names.

# Blazor Components
- Razor components should alwaays have a separate code-behind file. This file shoule be named `ComponentName.razor.cs`. The class name should be `ComponentNameCode`.
- Do not use @code blocks in Razor files. Instead, use the code-behind file for any C# logic.
- Avoid using `@using` directives for namespaces that are already globally imported in `_Imports.razor`.

# Documentation
- All public methods and classes should have XML documentation comments.
- SQL scripts should have comments at the top explaining their purpose and any important details.
- Methods or Stored Procedures longer than 3 lines should have inline comments explaining the purpose of each logical block of code.

# Testing Instructions
- Use xUnit for unit tests.
- Ensure all tests pass before committing changes.
- Add new tests for any new features or bug fixes.
- When changing existing functionality, ensure that existing tests still pass and add new tests as needed to cover the changes. Do not change exisitng tests unless absolutely necessary.
- Add or update tests for the code you change, even if nobody asked.
- Tests should be placed in the `ResumeSite.Tests` project. The top level folder should match the project e.g. Api, Data, Blazor.Shared, etc.