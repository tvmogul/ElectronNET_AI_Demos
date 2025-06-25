## ElectronNET_AI_Demos is an AI Electron.NET ASP.NET 9 CORE 9 Web App (Model-View-Controller)

## Show You How to Use ML.NET, AI and Neural Networks in Electron.NET 

Using Node.js in a C# .NET 9 Core Razor MVC web app with Electron.NET 
is like putting a square peg in a round hole—unnecessary,
bloated, and
fundamentally at odds with the streamlined, high-performance architecture 
of modern .NET. Electron.NET was built to give .NET developers native access 
to desktop-level power without dragging in Node.js and its fragile web of 
dependencies, security holes, and endless package churn. By avoiding Node, 
you keep your app faster, leaner, and entirely in the C# ecosystem you 
control—no npm hacks, no version hell, no nonsense. Just clean, efficient 
.NET code from top to bottom.

## EXPLANATION OF CORE NAMING

In November 2020, Microsoft released .NET 5.0, dropping the "Core” branding so all 
versions of .NET after 5.0 are "Core" apps. Commonly you will see .NET 8 applications 
refrred to as a "Core 8" applications because .NET 8 is a Core application.

- ### Install These Packages
- Microsoft.AspNetCore.Mvc.NewtonsoftJson (Version="9.0.5")
- xMicrosoft.DotNet.UpgradeAssistant.Extensions.Default.Analyzers (Version="0.4.421302")
- Microsoft.Extensions.Hosting (Version="9.0.5") 
- xMicrosoft.Extensions.Logging (Version="8.0.0")
- xMicrosoft.VisualStudio.Web.CodeGeneration.Design (Version="8.0.5")
- Newtonsoft.Json (Version="13.0.3")
- Microsoft.Data.Sqlite.Core (Version="9.0.5")

- ### Install ML.NET Packages
- Microsoft.ML (Version="4.0.2")

- ### Install SQLite Packages
- SQLitePCLRaw.bundle_e_sqlite3 (Version="2.1.11")  
- SQLitePCLRaw.bundle_green (Version="2.1.11")
- SQLitePCLRaw.core (Version="2.1.11")
- SQLitePCLRaw.provider.dynamic_cdecl (Version="2.1.11")

- ### Install Electron.NET
- ElectronNET.API (Version="23.6.2")

- ### Other Packages You Can Add
- xExcelDataReader (Version="3.7.0")
- xMarkdig (Version="0.37.0")


## PDF & WORD EXPORTS
var r_header_title: 'Header Title Here';
var r_main_title = 'Sample Report';
var r_messageTop = 'Sample Number: 12345 | Type: Example Type';
var r_footer_text = 'Footer text here';
title: 'Sample Report',  // Set the title of the exported PDF
messageTop: '";"


## IMAGES & EMOJIS SYMBOLS: ™, ®, ©, 

Here are some emojis you can use directly in html:
https://unicode.org/emoji/charts/full-emoji-list.html
https://emojipedia.org/travel-places/
https://emojihub.org/
https://emoji-copy-paste.com/

## Fonts - Use calc

Use the `calc()` function to dynamically calculate the font size based on the width of the viewport (`vw`). This technique is often used to create fluid typography on web pages, making the font size responsive to the screen size without the need for media queries. Here's a breakdown of how it works:

```css
font-size: calc(13px + (15 - 13) * ((100vw - 300px) / (1600 - 300)));
```

1. **Base Font Size**: The calculation starts with a base font size of `13px`. This is the minimum font size that will be applied.
2. **Font Size Range**: The next part, `(15 - 13)`, calculates the range within which the font size can grow. In this case, the font size can increase by up to `2px` (from `13px` to `15px`).
3. **Viewport Width Adjustment**: `100vw` represents 100% of the viewport width. The expression `(100vw - 300px)` calculates the difference between the current viewport width and `300px`. This difference will be used to adjust the font size based on the screen width.
4. **Scaling Range**: `(1600 - 300)` calculates the total scaling range for the viewport width, which in this case is `1300px` (from `300px` to `1600px`). This defines the range over which the font size will adjust.
5. **Final Calculation**: The entire `calc()` function calculates the font size by starting with the base size (`13px`), then adds an increment that scales based on the viewport width. The increment is proportionally scaled within the range defined by `(15 - 13) * ((100vw - 300px) / (1600 - 300))`. This means as the viewport width increases from `300px` to `1600px`, the font size will linearly increase from `13px` to `15px`.

In summary, this CSS rule makes the font size start at `13px` when the viewport width is `300px` or less. As the viewport width grows, the font size increases linearly, reaching `15px` when the viewport width hits `1600px`. For viewport widths between `300px` and `1600px`, the font size will be somewhere between `13px` and `15px`, calculated based on the formula provided. This approach provides a smooth transition of font sizes across different screen widths, enhancing readability and user experience on a variety of devices.





tp1.Text = "Welcome";
WelcomeControl welcomeControl = new WelcomeControl(this);

tp2.Text = "Accounts";
AccountControl accountControl = new AccountControl(this);

tp3.Text = "Banks";
BankControl bankControl = new BankControl(this);

tp4.Text = "Import";
ImportControl importControl = new ImportControl(this);

tp5.Text = "Transactions";
TransactionControl transControl = new TransactionControl(this);

tp6.Text = "Reports";
ReportControl reportsControl = new ReportControl(this);

tp7.Text = "Categories";
CategoryControl categoryControl = new CategoryControl(this);

tp8.Text = "Export";
ExportControl exportControl = new ExportControl(this);

tp9.Text = "Settings";
SettingsControl settingsControl = new SettingsControl(this);


ELECTRON.NET ML.NET /
├── Controllers/
├── Models/
├── Data/                         ← ✅ Only company/user DBs go here
│   └── acme_corp.aidb
│   └── my_test_company.aidb
│   └── ...
├── Internal/                     ← 🔒 Internal-use only database goes here
│   └── pandata.aidb              ← Example: shared master categories, rules, etc.
├── Program.cs
└── Views/Shared/_SplashModel.cshtml_


## ✅ Theme Colors

| Color Class   | CSS Variable       | Description            |
|---------------|--------------------|-------------------------|
| `primary`     | `--bs-primary`     | 🔵 Blue (default primary brand color) |
| `secondary`   | `--bs-secondary`   | ⚪ Gray (neutral)       |
| `success`     | `--bs-success`     | 🟢 Green (for success states) |
| `danger`      | `--bs-danger`      | 🔴 Red (for errors)     |
| `warning`     | `--bs-warning`     | 🟡 Yellow (for cautions) |
| `info`        | `--bs-info`        | 🔵 Light blue / Cyan    |
| `light`       | `--bs-light`       | ⚪ Very light gray       |
| `dark`        | `--bs-dark`        | ⚫ Very dark gray        |

---

