using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

class ImageProcessor
{
    /// <summary>
    /// Inverts a list of image(s).
    /// </summary>
    /// <param name="filenames">A list of images to invert.</param>
    public static void Inverse(string[] filenames)
    {
        Parallel.ForEach(filenames, (imagePath) =>
        {
            using (Bitmap image = new Bitmap(imagePath))
            {
                int width = image.Width;
                int height = image.Height;

                BitmapData bmpData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                int stride = bmpData.Stride;
                int bytes = stride * height;
                byte[] pixelBuffer = new byte[bytes];

                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixelBuffer, 0, bytes);

                // Iterate through the pixels sequentially
                for (int i = 0; i < pixelBuffer.Length; i += 4)
                {
                    pixelBuffer[i] ^= 0xFF;        // Blue
                    pixelBuffer[i + 1] ^= 0xFF;    // Green
                    pixelBuffer[i + 2] ^= 0xFF;    // Red
                }

                System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, 0, bmpData.Scan0, bytes);

                image.UnlockBits(bmpData);

                // Generate new filename
                string directory = AppDomain.CurrentDomain.BaseDirectory;
                string filenameWithoutExtension = Path.GetFileNameWithoutExtension(imagePath);
                string extension = Path.GetExtension(imagePath);
                string newFilename = Path.Combine(directory, $"{filenameWithoutExtension}_inverse{extension}");

                image.Save(newFilename, image.RawFormat);
            }
        });
    }
}
