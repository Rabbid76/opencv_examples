using Emgu.CV;
using Emgu.CV.CvEnum;
using EmguCVUtility.Image;

namespace EmguCVUtility.Filter
{
    public enum FlipAxis { XAxis, YAxis }

    public class Flip
        : IFilter
    {
        FlipAxis Direction { get; set; }

        public Flip(FlipAxis direction)
        {
            this.Direction = direction;
        }

        public static Flip New(FlipAxis direction) => new Flip(direction);

        public IImage transform(IImage image)
        {
            var dest_image = Image.Image.New8U(image.matrix.Size, image.matrix.NumberOfChannels);
            CvInvoke.Flip(image.matrix, dest_image.matrix, this.Direction == FlipAxis.YAxis ? FlipType.Horizontal : FlipType.Vertical);
            return dest_image;
        }
    }
}
