using System.Runtime.InteropServices;

public class PathManager
{
    public string? anyFolder;

    public PathManager()
    {

    }

    public string GetAnyFolder(string sFolder)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // On Windows, locate Databases in the same folder as the exe file
            string? exeFolder = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule!.FileName);
            anyFolder = Path.Combine(exeFolder!, sFolder);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            // On macOS, use the Application Support folder in the user's Library
            string userLibrary = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Library", "Application Support");
            anyFolder = Path.Combine(userLibrary, "AiNetProfit", sFolder);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            // On Linux, use the /var directory
            anyFolder = Path.Combine("/var", "AiNetProfit", sFolder);
        }
        else
        {
            // Default to the current directory if OS is unrecognized
            anyFolder = Path.Combine(Directory.GetCurrentDirectory(), sFolder);
        }

        // Ensure directory exists
        if (!Directory.Exists(anyFolder))
        {
            Directory.CreateDirectory(anyFolder);
        }
        return anyFolder!;
    }

    public string GetProgramFiles32()
    {
        // Get Program Files (x86) (for 32-bit apps on 64-bit Windows)
        string programFiles32 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        return programFiles32;
    }

    public string GetProgramFiles64()
    {
        // Get Program Files (64-bit)
        string programFiles64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        return programFiles64;
    }

    //public static byte[] GuidToByteArray(Guid guid)
    //{
    //    return guid.ToByteArray();
    //}

} //public class DatabaseManager







