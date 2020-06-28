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

        public IImage transform_in_place(IImage image)
        {
            image.matrix = image.matrix.NumberOfChannels == 1 ? 
                transfrormU8(image.matrix) : transformU(image.matrix);
            return image;
        }

        private Mat transfrormU8(Mat matrix)
        {
            CvInvoke.EqualizeHist(matrix, matrix);
            return matrix;
        }

        private Mat transformU(Mat source_matrix)
        {
            var matrix = transfrormU8(source_matrix.Reshape(1));
            return matrix.Reshape(source_matrix.NumberOfChannels);
        }
    }
}
