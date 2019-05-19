using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpotlightImageSaver.CoreFunctions
{
    public class FileSystem
    {
        public static string GetSpotLightPath() => Environment.ExpandEnvironmentVariables(Constants.path);

        public static DirectoryInfo CreateSavedimageDirectory(string DirectoryPath = "Images") => Directory.CreateDirectory(DirectoryPath);

        public static string[] GetAllImages() => Directory.GetFiles(GetSpotLightPath());

        public static void SaveImages(string directory, List<string> images)
        {
            try
            {
                foreach (var image in images)
                {
                    File.Copy(image, $"{directory}/{image.Split('\\').Last()}.jpg", true);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
