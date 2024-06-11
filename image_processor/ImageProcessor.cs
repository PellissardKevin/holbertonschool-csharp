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

                BitmapData bmpData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                int stride = bmpData.Stride;
                byte[] pixelBuffer = new byte[stride * height];

                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

                for (int x = 0; x < pixelBuffer.Length; x += 4)
                {
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
        });
    }
}
