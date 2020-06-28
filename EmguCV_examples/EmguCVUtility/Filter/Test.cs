using Emgu.CV;
using Emgu.CV.CvEnum;
using EmguCVUtility.Image;
using System.Drawing;

namespace EmguCVUtility.Filter
{
    public class Test
        : IFilter
    {
        IInputArray kernel { get; set; }

        Test(IInputArray kernel)
        {
            this.kernel = kernel;
        }

        static public IFilter New()
        {
            float[,] kernal_array = { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
            var convol_colution  = new ConvolutionKernelF(kernal_array);
            return new Test(convol_colution);
        }

        public IImage transform_in_place(IImage image)
        {
            CvInvoke.Filter2D(image.matrix, image.matrix, this.kernel, new Point(0, 0));
            return image;
        }
    }
}
