# Desktop_Project

C# WinForms desktop application for managing an IELTS class center.

## Build

- Open `DesktopApp_Project/DesktopApp_Project.sln` in Visual Studio, or run:

```powershell
dotnet build DesktopApp_Project\DesktopApp_Project.sln
```

- The project targets .NET Framework 4.7.2.
- `FontAwesome.Sharp` is restored through `PackageReference`; a committed `packages` folder is not required.
- Recommended for demo: open and build with Visual Studio. If VS Code or `dotnet build` reports a `FontAwesome.Sharp` restore/reference error, restore NuGet packages again or build once in Visual Studio, then retry.

## Database Setup

SQL scripts are in `DesktopApp_Project/DesktopApp_Project.DAL/Sql`.

- `Schema.sql` is the normal setup script. It creates the `QuanLyLopIELTS` database and seed data only when the schema is missing. Running it again should not drop existing data.
- `ResetDatabase.sql` is dev-only and destructive. It drops the `QuanLyLopIELTS` database, then includes `Schema.sql`; run it with SQLCMD mode enabled.

`App.config` controls the SQL Server connection string at:

`DesktopApp_Project/DesktopApp_Project.GUI/App.config`

Current connection string:

```xml
Data Source=KANNAR;Initial Catalog=QuanLyLopIELTS;Integrated Security=True;
```

On another machine, change only `Data Source` to the local SQL Server name before running the app, for example:

- `Data Source=.;Initial Catalog=QuanLyLopIELTS;Integrated Security=True;`
- `Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyLopIELTS;Integrated Security=True;`

Database setup steps:

1. Open SQL Server Management Studio.
2. Connect to the SQL Server instance that matches `Data Source`.
3. Open `DesktopApp_Project/DesktopApp_Project.DAL/Sql/Schema.sql`.
4. Execute the script.
5. Confirm database `QuanLyLopIELTS` exists and contains seed data.

Sample accounts after running `Schema.sql`:

- `admin` / `admin`
- `giaovien` / `123456`

## Runtime Notes

- Login opens the main dashboard first.
- Sidebar buttons open the student, class, material, assignment, grading, attendance, score, exam, report, vocabulary, notification, and tuition modules.
- Reports export as HTML.
- Selected material and assignment files are copied to `%APPDATA%\QuanLyLopIELTS\Uploads`, and the database stores relative paths such as `Uploads/TaiLieu/<file>`.

## Architecture

- `DTO`: transfer objects.
- `DAL`: LINQ to SQL entities, data context, repository, and SQL scripts.
- `BUS`: service layer and validation.
- `GUI`: WinForms screens that call BUS services.
