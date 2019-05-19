using SpotlightImageSaver.CoreFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpotlightImageSaver.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating saved image directory...");

            var arguments = ParseArguments(args);

            var directory = CreateSaveDirectory(arguments);

            Console.WriteLine("Finding images...");

            var potentialImages = FileSystem.GetAllImages();

            Console.WriteLine("Saving images...");

            FileSystem.SaveImages(directory, potentialImages.Where(i => new FileInfo(i).Length > (200 * 1024)).ToList());

            Console.WriteLine("Finished saving images...");

        }

        private static string CreateSaveDirectory(Dictionary<string, string> arguments)
        {
            if (arguments.ContainsKey("D"))
            {
                return FileSystem.CreateSavedimageDirectory(arguments["D"]).FullName;
            }

            return FileSystem.CreateSavedimageDirectory().FullName;

        }

        private static Dictionary<string, string> ParseArguments(string[] args)
        {
            var parsed = new Dictionary<string, string>();

            foreach (var argument in args)
            {
                string[] split = argument.Split('-');
                parsed.Add(split[0], split[1]);
            }

            return parsed;
        }

    }
}
