//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseRouting();

//app.UseAuthorization();

//app.MapStaticAssets();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}")
//    .WithStaticAssets();

//using DocumentFormat.OpenXml.Spreadsheet;
//using DocumentFormat.OpenXml.Vml;
//using DocumentFormat.OpenXml.Wordprocessing;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Security.Cryptography;

namespace AiNetProfit
{
    public class Program
    {
        public static IConfiguration? Configuration { get; private set; }

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConsole();
                })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    // Add appsettings.json configuration file
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    Configuration = config.Build();
                })
                .UseElectron(args)
                .ConfigureServices((context, services) =>
                {
                    // Remove all CORS and security settings for testing purposes
                    services.AddCors(options =>
                    {
                        options.AddPolicy("AllowCorsPolicy", builder =>
                        {
                            builder.SetIsOriginAllowed(_ => true)
                                   .AllowAnyHeader()
                                   .AllowAnyMethod()
                                   .AllowCredentials();
                        });
                    });

                    services.AddHttpContextAccessor(); // <-- Required for IHttpContextAccessor injection

                    // Add services to the container (includes MVC)
                    services.AddControllersWithViews()
                        .AddJsonOptions(options =>
                        {
                            options.JsonSerializerOptions.PropertyNamingPolicy = null;
                        });
                })
                .Configure(app =>
                {
                    var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
                    var configuration = app.ApplicationServices.GetRequiredService<IConfiguration>();

                    // Access configuration and environment
                    var _Env = configuration["Environment"];
                    var _AppName = configuration["AppName"];

                    // Define custom MIME type mappings
                    var defaultFileProvider = new FileExtensionContentTypeProvider();
                    // Add custom MIME type mappings
                    defaultFileProvider.Mappings[".apk"] = "application/vnd.android.package-archive";
                    defaultFileProvider.Mappings[".ipa"] = "application/octet-stream";
                    defaultFileProvider.Mappings[".plist"] = "text/xml";
                    defaultFileProvider.Mappings[".mp4"] = "video/mp4";
                    defaultFileProvider.Mappings[".avi"] = "video/x-msvideo";
                    defaultFileProvider.Mappings[".mov"] = "video/quicktime";
                    defaultFileProvider.Mappings[".wmv"] = "video/x-ms-wmv";
                    defaultFileProvider.Mappings[".flv"] = "video/x-flv";
                    defaultFileProvider.Mappings[".mkv"] = "video/x-matroska";
                    defaultFileProvider.Mappings[".webm"] = "video/webm";
                    defaultFileProvider.Mappings[".mp3"] = "audio/mpeg";
                    defaultFileProvider.Mappings[".wav"] = "audio/wav";
                    defaultFileProvider.Mappings[".ogg"] = "audio/ogg";
                    defaultFileProvider.Mappings[".flac"] = "audio/flac";
                    defaultFileProvider.Mappings[".pdf"] = "application/pdf";
                    defaultFileProvider.Mappings[".doc"] = "application/msword";
                    defaultFileProvider.Mappings[".docx"] = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    defaultFileProvider.Mappings[".xls"] = "application/vnd.ms-excel";
                    defaultFileProvider.Mappings[".xlsx"] = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    defaultFileProvider.Mappings[".ppt"] = "application/vnd.ms-powerpoint";
                    defaultFileProvider.Mappings[".pptx"] = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                    defaultFileProvider.Mappings[".jpg"] = "image/jpeg";
                    defaultFileProvider.Mappings[".jpeg"] = "image/jpeg";
                    defaultFileProvider.Mappings[".png"] = "image/png";
                    defaultFileProvider.Mappings[".gif"] = "image/gif";
                    defaultFileProvider.Mappings[".bmp"] = "image/bmp";
                    defaultFileProvider.Mappings[".svg"] = "image/svg+xml";
                    defaultFileProvider.Mappings[".zip"] = "application/zip";
                    defaultFileProvider.Mappings[".rar"] = "application/x-rar-compressed";
                    defaultFileProvider.Mappings[".7z"] = "application/x-7z-compressed";
                    defaultFileProvider.Mappings[".tar"] = "application/x-tar";
                    defaultFileProvider.Mappings[".gz"] = "application/gzip";
                    defaultFileProvider.Mappings[".json"] = "application/json";
                    defaultFileProvider.Mappings[".xml"] = "application/xml";
                    defaultFileProvider.Mappings[".csv"] = "text/csv";
                    defaultFileProvider.Mappings[".txt"] = "text/plain";

                    if (env.IsDevelopment())
                    {
                        app.UseDeveloperExceptionPage();
                    }

                    app.UseStaticFiles(new StaticFileOptions
                    {
                        ContentTypeProvider = defaultFileProvider
                    });

                    app.UseRouting();

                    app.Use(async (context, next) =>
                    {
                        string scriptNonce;
                        using (var rng = RandomNumberGenerator.Create())
                        {
                            var nonceBytes = new byte[32];
                            rng.GetBytes(nonceBytes);
                            scriptNonce = Convert.ToBase64String(nonceBytes);
                        }

                        context.Items["ScriptNonce"] = scriptNonce;

                        string[] domains = new string[]
                        {
                            "https://www.googletagmanager.com",
                            "https://www.google-analytics.com",
                            "https://fonts.googleapis.com",
                            "https://fonts.gstatic.com",
                            "https://cdn.datatables.net",
                            "https://cdnjs.cloudflare.com",
                            "https://cdn.jsdelivr.net",
                            "https://stackpath.bootstrapcdn.com",
                            "https://code.jquery.com",
                            "https://ajax.aspnetcdn.com",
                            "https://www.adobe.com",
                            "https://adobe.com",
                            "https://ainetprofit.com",
                            "https://ainetprofits.com",
                            "https://sergioapps.com",
                            "https://maxlifespan.com",
                            "https://mdhealthbuzz.com",
                            "https://software-rus.com",
                            "https://stationbreaktv.com",
                            "https://localhost:*",
                            "wss://localhost:*"
                        };

                        string scriptSrcDomains = string.Join(" ", domains);

                        string csp = $"default-src 'self'; " +
                                     $"script-src 'self' 'nonce-{scriptSrcDomains}' 'strict-dynamic' {scriptSrcDomains}; " +
                                     $"font-src 'self' https://fonts.gstatic.com {scriptSrcDomains}; " +
                                     $"img-src 'self' data: blob: {scriptSrcDomains}; " +
                                     $"object-src 'none'; " +
                                     $"media-src 'self' blob: {scriptSrcDomains}; " +
                                     $"connect-src {scriptSrcDomains} ws://localhost:* https://localhost:* http://localhost:*; " +
                                     $"style-src 'self' 'unsafe-inline' {scriptSrcDomains}; " +
                                     $"frame-ancestors 'self'; " +
                                     $"form-action 'self' {scriptSrcDomains} https://localhost:5001;";

                        context.Response.Headers["Content-Security-Policy"] = "";

                        await next();
                    });

                    app.UseCors("AllowCorsPolicy");  // Apply CORS policy

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    });

                    if (HybridSupport.IsElectronActive)
                    {
                        Electron.App.Ready += async () =>
                        {
                            var preloadPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "js", "preload.js");

                            var browserWindow = await Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions
                            {
                                Width = 1152,
                                Height = 940,
                                MinWidth = 800,
                                MinHeight = 500,
                                HasShadow = false,
                                Center = true,
                                AutoHideMenuBar = false,
                                Frame = true,
                                Transparent = false,
                                Icon = "wwwroot/img/check.ico",
                                WebPreferences = new WebPreferences
                                {
                                    NodeIntegration = false,
                                    ContextIsolation = true,
                                    Preload = preloadPath
                                }
                            });

                            browserWindow.SetTitle(configuration["DemoTitleInSettings"] ?? "Electron.NET App");

                            // 🔒 Why _ = ...?
                            // It tells the compiler and Visual Studio you intentionally ignore
                            // the returned Task, preventing the green squiggle about “not awaited”.
                            // It does not cause multiple registrations like wrapping in async
                            // again or placing it inside another async method.
                            _ = Electron.IpcMain.On("open-image-dialog", async (args) =>
                            {
                                var mainWindow = Electron.WindowManager.BrowserWindows.First();
                                var result = await Electron.Dialog.ShowOpenDialogAsync(mainWindow, new OpenDialogOptions
                                {
                                    Title = "Select Image",
                                    Properties = new[] { OpenDialogProperty.openFile },
                                    Filters = new[]
                                    {
                                        new FileFilter
                                        {
                                            Name = "Images",
                                            Extensions = new[] { "png", "jpg", "jpeg", "gif", "bmp", "webp" }
                                        }
                                    }
                                });

                                var filePath = result?.FirstOrDefault();
                                Electron.IpcMain.Send(browserWindow, "open-image-dialog-response", filePath);
                            });

                        };
                    }
                });
        }
    }
}



