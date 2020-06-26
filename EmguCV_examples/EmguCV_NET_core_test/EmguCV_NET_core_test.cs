using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace EmguCV_NET_core_test
{
    class EmguCV_NET_core_test
    {
        static void Main(string[] args)
        {
            var window_name = "EmguCV .NET framework Test Window";
            CvInvoke.NamedWindow(window_name);

            var test_image = new Mat(200, 400, DepthType.Cv8U, 3);
            test_image.SetTo(new Bgr(255, 0, 0).MCvScalar);

            CvInvoke.PutText(
               test_image,
               "Hello, world",
               new System.Drawing.Point(10, 80),
               FontFace.HersheyComplex,
               1.0,
               new Bgr(0, 255, 0).MCvScalar);


            CvInvoke.Imshow(window_name, test_image);
            CvInvoke.WaitKey(0);
            //CvInvoke.DestroyWindow(window_name);
            CvInvoke.DestroyAllWindows();
        }
    }
}
