using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Numerics;

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
                int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
                int byteCount = stride * height;
                byte[] pixelBuffer = new byte[byteCount];

                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

                int vectorSize = Vector<byte>.Count;
                byte[] maxValues = new byte[vectorSize];
                for (int j = 0; j < vectorSize; j++)
                    maxValues[j] = 255;
                Vector<byte> maxVector = new Vector<byte>(maxValues);

                Parallel.For(0, pixelBuffer.Length / vectorSize, i =>
                {
                    int offset = i * vectorSize;
                    if (offset + vectorSize > pixelBuffer.Length) return;

                    Vector<byte> pixelVector = new Vector<byte>(pixelBuffer, offset);
                    Vector<byte> resultVector = maxVector - pixelVector;
                    resultVector.CopyTo(pixelBuffer, offset);
                });

                System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, 0, bmpData.Scan0, pixelBuffer.Length);

                image.UnlockBits(bmpData);

                string[] nameSplit = imagePath.Split(new char[] { '/', '.' });
                string newFilename = $"{nameSplit[nameSplit.Length - 2]}_inverse.{nameSplit[nameSplit.Length - 1]}";

                image.Save(newFilename);
            }
        });
    }
}
