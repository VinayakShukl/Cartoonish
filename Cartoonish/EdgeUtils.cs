using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace Cartoonish
{
    class EdgeUtils
    {
        public static Image<Bgr, byte> run2(Image<Bgr, byte> img)
        {
            img = img.SmoothMedian(7);

            Image<Gray, byte> canny = img.Convert<Gray, byte>().Canny(40, 100);

            img = canny.Convert<Bgr, byte>();

            img = dilate(img);
            return img;
        }

        public static Image<Bgr, byte> run(Image<Bgr, byte> img)
        {
            img = img.SmoothMedian(7);

            Image<Gray, byte> canny = img.Convert<Gray,byte>().Canny(40,100);

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

            var contours = grayFrame.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST);


            for (; contours != null; contours = contours.HNext)
            {
                Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.005);

                if (currentContour.Area < threshold)
                {
                    Rectangle currentrect = currentContour.BoundingRectangle;

                    img.Draw(currentrect, new Bgr(0, 0, 0), -1);
                }
            }
            return img;

        }
    }
}
