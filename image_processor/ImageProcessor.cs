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
        foreach (string imagePath in filenames)
        {
            using (Bitmap image = new Bitmap(imagePath))
            {
                int width = image.Width;
                int height = image.Height;

                BitmapData bmpData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                int stride = bmpData.Stride;
                byte[] pixelBuffer = new byte[stride * height];

                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

                for (int i = 0; i < pixelBuffer.Length / 4; i++)
                {
                    int x = i * 4;
                    pixelBuffer[x] ^= 0xFF;
                    pixelBuffer[x + 1] ^= 0xFF;
                    pixelBuffer[x + 2] ^= 0xFF;
                }

                System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, 0, bmpData.Scan0, pixelBuffer.Length);

                image.UnlockBits(bmpData);

                string[] nameSplit = imagePath.Split(new char[] { '/', '.' });
                string newFilename = $"{nameSplit[nameSplit.Length - 2]}_inverse.{nameSplit[nameSplit.Length - 1]}";

                image.Save(newFilename);
            }
        }
    }

    /// <summary>
    /// Converts a list of image(s) to grayscale.
    /// </summary>
    /// <param name="filenames">A list of images to convert to grayscale.</param>
    public static void Grayscale(string[] filenames)
    {
        foreach (string imagePath in filenames)
        {
            using (Bitmap image = new Bitmap(imagePath))
            {
                int width = image.Width;
                int height = image.Height;

                BitmapData bmpData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                int stride = bmpData.Stride;
                byte[] pixelBuffer = new byte[stride * height];

                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

                for (int i = 0; i < pixelBuffer.Length / 4; i++)
                {
                    int x = i * 4;
                    byte b = pixelBuffer[x];
                    byte g = pixelBuffer[x + 1];
                    byte r = pixelBuffer[x + 2];

                    byte gray = (byte)(0.3 * r + 0.59 * g + 0.11 * b);

                    pixelBuffer[x] = gray;
                    pixelBuffer[x + 1] = gray;
                    pixelBuffer[x + 2] = gray;
                }

                System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, 0, bmpData.Scan0, pixelBuffer.Length);

                image.UnlockBits(bmpData);

                string[] nameSplit = imagePath.Split(new char[] { '/', '.' });
                string newFilename = $"{nameSplit[nameSplit.Length - 2]}_grayscale.{nameSplit[nameSplit.Length - 1]}";

                image.Save(newFilename);
            }
        }
    }
}
