using System.IO.Compression;

namespace StratenProjectUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string zipPath = @"C:\pad\naar\bestand.zip";
            string extractPath = @"C:\bestemming\map";

            // Unzip het bestand
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
