using System;
using System.IO;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

public class ImageProcessor
{
    /// <summary>
    /// Inverts a list of image(s).
    /// </summary>
    /// <param name="filenames">A list of images to invert.</param>
    public static void Inverse(string[] filenames)
    {
        // Iterate through all image files
        Parallel.ForEach(filenames, (imagePath) =>
        {
            // Load the image
            using (Image<Rgba32> image = Image.Load<Rgba32>(imagePath))
            {
                // Invert the image colors
                image.Mutate(x => x.Invert());

                // Extract filename from path and edit for new save
                string currentDirectory = Directory.GetCurrentDirectory();
                string filename = Path.GetFileNameWithoutExtension(imagePath);
                string extension = Path.GetExtension(imagePath);
                string newFilename = Path.Combine(currentDirectory, filename + "_inverse" + extension);

                // Save inverted image to new file
                image.Save(newFilename);
            }
        });
    }
}
