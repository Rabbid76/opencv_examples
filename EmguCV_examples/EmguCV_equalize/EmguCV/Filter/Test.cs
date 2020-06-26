using Emgu.CV;
using Emgu.CV.CvEnum;
using EmguCV_equalize.EmguCV.Image;
using System.Drawing;

namespace EmguCV_equalize.EmguCV.Filter
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

        public IImage transform(IImage image)
        {
            var image_mat = new Mat(image.image.Rows, image.image.Cols, DepthType.Cv8U, image.image.NumberOfChannels);
            var dest_image = new Image.Image(image_mat);
            CvInvoke.Filter2D(image.image, dest_image.image, this.kernel, new Point(0, 0));
            return dest_image;
        }
    }
}
