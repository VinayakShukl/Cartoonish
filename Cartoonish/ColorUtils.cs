using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Drawing;
using System;

namespace Cartoonish
{
    class ColorUtils
    {
        public static Image<Bgr, byte> run(Image<Bgr, byte> img, int scaleFactor, int kernelSize, int iterations){
            
            Image<Bgr, byte> small = img.Copy();
            Image<Bgr, byte> temp = img.Copy();

            // downscale
            int scale = 4;
            Size smallSize = new Size(img.Size.Width/scale, img.Size.Height/scale);
            small.Resize(smallSize.Width, smallSize.Height, INTER.CV_INTER_AREA);

            int colorSigma = 15;
            int spaceSigma = 7;

            // bilatral filtering
            for (int i = 0; i < iterations; i++) {
                temp = small.SmoothBilatral(kernelSize, colorSigma, spaceSigma);
                small = temp.SmoothBilatral(kernelSize, colorSigma, spaceSigma);
            }

            // upscale
            small.Resize(img.Width, img.Height, INTER.CV_INTER_AREA);
            small = small.SmoothMedian(7);


            // quantize colors
            Size size = small.Size;
            double colorScaleFactor = (double)scaleFactor;
            byte[, ,] data = small.Data;

            for (int row = 0; row < size.Height; row++) {
                for (int col = 0; col < size.Width; col++) {
                    for (int i = 0; i < 3; i++)
                    {
                        int pix = (int)data[row, col, i];
                        pix = (int)(Math.Floor((pix) / colorScaleFactor) * colorScaleFactor);
                        data[row, col, i] = (byte)pix;
                    }
                }
            }

            small.SmoothMedian(11);
            return small;
        } 
    }
}
