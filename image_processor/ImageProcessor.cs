using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Threading.Tasks;

public class ImageProcessor
{
    public static void Inverse(string[] filenames)
    {
        // Check if filenames are provided or get files from the "images" directory
        if (filenames.Length == 0)
        {
            string directory = "images/";
            if (!Directory.Exists(directory))
            {
                Console.WriteLine($"Directory '{directory}' not found.");
                return;
            }

            filenames = Directory.GetFiles(directory, "*.jpg");
            if (filenames.Length == 0)
            {
                Console.WriteLine("No images found in the directory.");
                return;
            }
        }

        // Get the current directory
        string currentDirectory = Directory.GetCurrentDirectory();

        // Process each file in parallel
        Parallel.ForEach(filenames, filename =>
        {
            try
            {
                using (Image<Rgba32> image = Image.Load<Rgba32>(filename))
                {
                    image.Mutate(ctx => ctx.Invert());

                    string filenameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                    string extension = Path.GetExtension(filename);
                    string newFilename = Path.Combine(currentDirectory, $"{filenameWithoutExtension}_inverse{extension}");

                    image.Save(newFilename);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file {filename}: {ex.Message}");
            }
        });

        Console.WriteLine("Image processing completed.");
    }
}
