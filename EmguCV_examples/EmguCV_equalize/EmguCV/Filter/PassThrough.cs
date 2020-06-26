using EmguCV_equalize.EmguCV.Image;

namespace EmguCV_equalize.EmguCV.Filter
{
    public class PassThrough
        : IFilter
    {
        static public IFilter New() => new PassThrough();

        public IImage transform(IImage image) => image;
    }
}
