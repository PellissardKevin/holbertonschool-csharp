using System;
using System.Drawing;
using System.Drawing.Imaging;
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

                Rectangle rect = new Rectangle(0, 0, width, height);
                BitmapData bmpData = image.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                int stride = bmpData.Stride;
                int bytesPerPixel = 4; // 4 bytes per pixel (32 bits)

                byte[] pixelBuffer = new byte[stride * height];

                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

                for (int y = 0; y < height; y++)
                {
                    int currentLine = y * stride;

                    for (int x = 0; x < width; x++)
                    {
                        int currentPixel = currentLine + x * bytesPerPixel;

                        // Invert RGB values
                        pixelBuffer[currentPixel] = (byte)(255 - pixelBuffer[currentPixel]);         // Blue
                        pixelBuffer[currentPixel + 1] = (byte)(255 - pixelBuffer[currentPixel + 1]); // Green
                        pixelBuffer[currentPixel + 2] = (byte)(255 - pixelBuffer[currentPixel + 2]); // Red
                    }
                }

                System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, 0, bmpData.Scan0, pixelBuffer.Length);

                image.UnlockBits(bmpData);

                string[] nameSplit = imagePath.Split(new char[] { '/', '.' });
                string newFilename = $"{nameSplit[nameSplit.Length - 2]}_inverse.{nameSplit[nameSplit.Length - 1]}";

                image.Save(newFilename);
            }
        });
    }
}
