using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMAUI.Helper
{
    public class FileAccessHelper
    {
        public static string GetPathFile(string fileName)
        {
            // Asegura que el directorio exista
            var appDataDir = FileSystem.AppDataDirectory;
            Directory.CreateDirectory(appDataDir);
            return Path.Combine(appDataDir, fileName);
        }

        public static string GetAppDirectory()
            => FileSystem.AppDataDirectory;
    }
}
