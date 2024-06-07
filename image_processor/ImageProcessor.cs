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
        var tasks = new Task[filenames.Length];

        for (int i = 0; i < filenames.Length; i++)
        {
            string filename = filenames[i];
            tasks[i] = Task.Run(() => InverseImage(filename));
        }

        Task.WaitAll(tasks);
    }

    private static void InverseImage(string filename)
    {
        try
        {
            using (Image<Rgba32> image = Image.Load<Rgba32>(filename))
            {
                image.Mutate(ctx => ctx.Invert());

                string newFilename = GetNewFilename(filename);
                image.Save(newFilename);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing file {filename}: {ex.Message}");
        }
    }

    private static string GetNewFilename(string originalFilename)
    {
        string directory = Path.GetDirectoryName(originalFilename);
        string filenameWithoutExtension = Path.GetFileNameWithoutExtension(originalFilename);
        string extension = Path.GetExtension(originalFilename);

        return Path.Combine(directory, $"{filenameWithoutExtension}_inverse{extension}");
    }
}
