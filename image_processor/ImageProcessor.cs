﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Collections.Generic;

class ImageProcessor
{
    /// <summary>
    /// Inverts a list of image(s).
    /// </summary>
    /// <param name="filenames">A list of images to invert.</param>
    public static void Inverse(string[] filenames)
    {

        // Iterate through all .jpg files in images directory
        Parallel.ForEach(filenames, (imagePath) =>
        {
            {
                // For each image file create a new Bitmap object
                Bitmap image = new Bitmap(imagePath);

                // Lock the bitmaps bits
                BitmapData bmpData = image.LockBits(
                    new Rectangle(0, 0, image.Width, image.Height),
                    ImageLockMode.ReadWrite, image.PixelFormat);

                // Determine size of image in bytes
                int bytes = bmpData.Stride * bmpData.Height;

                // Allocate buffer size of image bytes
                byte[] rgbBuffer = new byte[bytes];

                // Safely copy bitmap data to buffer
                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, rgbBuffer, 0, bytes);

                // Iterate through RGB buffer, inverting each color value
                for (var i = 0; i < bytes; i++)
                    rgbBuffer[i] = (byte)(255 - rgbBuffer[i]);

                // Copy values back from buffer
                System.Runtime.InteropServices.Marshal.Copy(rgbBuffer, 0, bmpData.Scan0, bytes);

                // Unlock bits
                image.UnlockBits(bmpData);

                // Extract filename from path and edit for new save
                string[] nameSplit = imagePath.Split(new Char[] { '/', '.' });
                String newFilename = nameSplit[nameSplit.Length - 2] + "_inverse." +
                                        nameSplit[nameSplit.Length - 1];

                // Save inverted image to new file
                image.Save(newFilename);
            }
        });
    }
}
