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

        public IImage transform_in_place(IImage image)
        {
            CvInvoke.Flip(image.matrix, image.matrix, this.Direction == FlipAxis.YAxis ? FlipType.Horizontal : FlipType.Vertical);
            return image;
        }
    }
}
