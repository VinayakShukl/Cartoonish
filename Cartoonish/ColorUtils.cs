using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Drawing;

namespace Cartoonish
{
    class ColorUtils
    {
        public static Image<Bgr, byte> run(Image<Bgr, byte> img){

            Image<Bgr, byte> res = img.Copy();
            Image<Bgr, byte> temp = img.Copy();

            // down scale
            double scale = 4;
            Size smallSize = new Size(img.Size.Width, img.Size.Height);


            int numReps = 7;
            int kernelSize = 9;
            int colorSigma = 15;
            int spaceSigma = 7;

            for (int i = 0; i < numReps; i++)
            {
                temp = res.SmoothBilatral(kernelSize, colorSigma, spaceSigma);
                res = temp.SmoothBilatral(kernelSize, colorSigma, spaceSigma);
            }

            CvInvoke.cvShowImage("bilatral", res);
            return res;
        } 
    }
}
