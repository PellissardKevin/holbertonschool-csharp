using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

public class ImageProcessor
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
                // Lock the bitmaps bits
                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
                BitmapData bmpData = image.LockBits(rect, ImageLockMode.ReadWrite, image.PixelFormat);

                // Get the address of the first line
                IntPtr ptr = bmpData.Scan0;

                // Declare an array to hold the bytes of the bitmap
                int bytes = Math.Abs(bmpData.Stride) * image.Height;
                byte[] rgbValues = new byte[bytes];

                // Copy the RGB values into the array
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                // Invert each pixel
                for (int i = 0; i < rgbValues.Length; i++)
                {
                    rgbValues[i] = (byte)(255 - rgbValues[i]);
                }

                // Copy the RGB values back to the bitmap
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

                // Unlock the bits
                image.UnlockBits(bmpData);

                // Extract filename from path and edit for new save
                string fileName = Path.GetFileNameWithoutExtension(imagePath);
                string extension = Path.GetExtension(imagePath);
                string directory = Path.GetDirectoryName(imagePath);
                string newFilename = Path.Combine(directory, fileName + "_inverse" + extension);

                // Save inverted image to new file
                image.Save(newFilename);
            }
        });
    }
}
