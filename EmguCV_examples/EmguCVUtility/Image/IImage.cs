using Emgu.CV;

namespace EmguCVUtility.Image
{
    public interface IImage
    {
        Mat matrix { get; set; }
        IImage clone();
    }
}
