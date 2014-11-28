using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;

namespace Cartoonish
{
    class EdgeUtils
    {
        public static Image<Bgr, byte> run(Image<Bgr, byte> img, double areaThreshold, int numDilations)
        {
            Image<Bgr, byte> originalImage = img.Copy();
            img = img.SmoothGaussian(5);
            img = img.SmoothMedian(7);

            Image<Gray, byte> canny = img.Convert<Gray, byte>().Canny(40, 100);

            img = canny.Convert<Bgr, byte>();
            
            int i = 0;
            while (i <= numDilations) { 
                img = dilate(img);
                i++;
            }
            double area = img.Width * img.Height;
            int threshold = (int)(area * areaThreshold);

            img = removeSmallCurves(img, threshold);

            return img;
        }

        private static Image<Bgr, byte> dilate(Image<Bgr, byte> img)
        {
            int[,] tempStructure = { { 1, 1 }, { 1, 1 } };
            StructuringElementEx element = new StructuringElementEx(tempStructure, 0, 0);
            CvInvoke.cvDilate(img, img, element, 1);
            return img;
        }

        private static Image<Bgr, byte> erode(Image<Bgr, byte> img)
        {
            int[,] tempStructure = { { 1, 1 }, { 1, 1 } };
            StructuringElementEx element = new StructuringElementEx(tempStructure, 0, 0);
            CvInvoke.cvErode(img, img, element, 1);
            return img;
        }

        private static Image<Bgr, byte> removeSmallCurves(Image<Bgr, byte> img, int threshold)
        {
            Image<Gray, byte> grayFrame = img.Convert<Gray, byte>();
            Contour<Point> contours = grayFrame.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST);

            Contour<Point> currentContour;
            using (MemStorage storage = new MemStorage()) {
                for (int i = 0; contours != null; contours = contours.HNext, i++) {
                    currentContour = contours.ApproxPoly(contours.Perimeter * 0.005, storage);
                    if (currentContour.Area < threshold) {
                        Rectangle currentrect = currentContour.BoundingRectangle;
                        img.Draw(currentrect, new Bgr(0, 0, 0), -1);
                    }
                }
            }
            return img;
        }
    }
}
