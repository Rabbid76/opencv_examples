using Emgu.CV;
using Emgu.CV.CvEnum;

namespace EmguCV_equalize.EmguCV.Image
{
    public class Image
        : IImage
    {
        public Mat image { get; set; }

        public Image(Mat image)
        {
            this.image = image;
        }

        static public Image New(string file_name) => new Image(CvInvoke.Imread(file_name, ImreadModes.AnyColor));
    }
}
