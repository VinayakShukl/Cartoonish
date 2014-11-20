using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;

namespace Cartoonish
{
    class EdgeUtils
    {

        static Contour<Point> contours;
        static Contour<Point> ptr;
        public static Image<Bgr, byte> run2(Image<Bgr, byte> img)
        {
            //This is the right image
            //This has been selected.
            Image<Bgr, byte> originalImage = img.Copy();
            img = img.SmoothGaussian(5);
            //CvInvoke.cvShowImage("Gaussian", img);

            img = img.SmoothMedian(7);

            Image<Gray, byte> canny = img.Convert<Gray, byte>().Canny(40, 100);

            img = canny.Convert<Bgr, byte>();

            img = dilate(img);


            double area = img.Width * img.Height;
            int threshold = (int)(area * 0.00005);

            img = removeSmallCurves(img, threshold);


            CvInvoke.cvDrawContours(originalImage.Ptr, ptr, new MCvScalar(0,0,255), new MCvScalar(0,0,255), 0, 2, Emgu.CV.CvEnum.LINE_TYPE.EIGHT_CONNECTED, new Point(0, 0));
            Console.WriteLine(ptr);

            return originalImage;
        }

        public static Image<Bgr, byte> run(Image<Bgr, byte> img)
        {
            img = img.SmoothGaussian(5);

            img = img.SmoothMedian(7);

            Image<Gray, byte> canny = img.Convert<Gray,byte>().Canny(40,75);

            img = canny.Convert<Bgr, byte>();

            img = dilate(img);

            double area = img.Width * img.Height;
            int threshold = (int)(area * 0.00005);

            img = removeSmallCurves(img, threshold);
            return img;

        }

        private static Image<Bgr,byte> dilate(Image<Bgr, byte> img)
        {
            int[,] tempStructure = { { 1, 1}, {1, 1} };
            StructuringElementEx element = new StructuringElementEx(tempStructure, 0, 0);
            CvInvoke.cvDilate(img, img, element, 1);
            return img;
        }


        private static Image<Bgr,byte> removeSmallCurves(Image<Bgr,byte> img, int threshold)
        {

            Image<Gray, byte> grayFrame = img.Convert<Gray, byte>();
            //grayFrame._EqualizeHist();
            
            contours = grayFrame.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST);
            ptr = contours;
            int i = 0;
            for (; contours != null; contours = contours.HNext, i++)
            {
                Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.005);

                if (currentContour.Area < threshold)
                {
                    Rectangle currentrect = currentContour.BoundingRectangle;
                    img.Draw(currentrect, new Bgr(0, 0, 0), -1);
                }
                else
                {
                    //Remove the contour from the list
                    //contours.RemoveAt(i);
                }
                
            }
            return img;

        }
    }
}
