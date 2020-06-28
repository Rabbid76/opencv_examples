using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Drawing;

namespace EmguCVUtility.Image
{
    public class Image
        : IImage
    {
        public Mat matrix { get; set; }

        public Image(Mat matrix) 
        {
            this.matrix = matrix;
        }

        static public Image New(Mat matrix) => new Image(matrix);
        static public Image New(string file_name) => New(CvInvoke.Imread(file_name, ImreadModes.AnyColor));
        static public Image New8U(Size size, int channels) => New(new Mat(size, DepthType.Cv8U, channels));

        public IImage clone() => New(this.matrix.Clone());
    }
}
