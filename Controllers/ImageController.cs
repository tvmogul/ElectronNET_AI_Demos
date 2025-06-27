using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class ImageController : Controller
{
    public async Task<IActionResult> SelectImage()
    {
        var window = Electron.WindowManager.BrowserWindows.FirstOrDefault();
        if (window == null)
        {
            Console.WriteLine("Electron BrowserWindow not found.");
            return Json(new { success = false, error = "No Electron window available." });
        }

        var options = new OpenDialogOptions
        {
            Title = "Select an Image",
            Properties = new[] { OpenDialogProperty.openFile },
            Filters = new[]
            {
            new FileFilter { Name = "Images", Extensions = new[] { "jpg", "jpeg", "png" } }
        }
        };

        string[] files = await Electron.Dialog.ShowOpenDialogAsync(window, options);

        if (files != null && files.Length > 0)
        {
            string selectedFile = files[0];
            string fileName = Path.GetFileName(selectedFile);

            PathManager path = new PathManager();
            string rootFolder = path.GetAnyFolder("");  // make sure this resolves!

            string logosFolder = Path.Combine(rootFolder, "wwwroot", "logos");

            if (!Directory.Exists(logosFolder))
            {
                Directory.CreateDirectory(logosFolder);
                Console.WriteLine("Created logos folder.");
            }

            string destPath = Path.Combine(logosFolder, fileName);
            try
            {
                System.IO.File.Copy(selectedFile, destPath, overwrite: true);
                Console.WriteLine($"Copied to {destPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            return Json(new { success = true, path = fileName });
        }

        return Json(new { success = false });
    }

}
