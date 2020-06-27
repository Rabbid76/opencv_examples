using Emgu.CV;
using EmguCVUtility.Image;

namespace EmguCVUtility.Filter
{
    /// <summary>
    /// See Histogram Equalization
    /// https://docs.opencv.org/master/d5/daf/tutorial_py_histogram_equalization.html
    /// </summary>
    public class Equalizer
        : IFilter
    {
        static public IFilter New() => new Equalizer();

        public IImage transform(IImage image)
        {
            var dest_image = image.matrix.NumberOfChannels == 1 ? 
                transfrormU8(image.matrix) : transformU(image.matrix);
            return dest_image;
        }

        private IImage transfrormU8(Mat source_matrix)
        {
            var dest_image = Image.Image.New8U(source_matrix.Size, 1);
            CvInvoke.EqualizeHist(source_matrix, dest_image.matrix);
            return dest_image;
        }

        private IImage transformU(Mat source_matrix)
        {
            var dest_image = transfrormU8(source_matrix.Reshape(1));
            dest_image.matrix = dest_image.matrix.Reshape(source_matrix.NumberOfChannels);
            return dest_image;
        }
    }
}
