using EmguCVUtility.Image;

namespace EmguCVUtility.Filter
{
    public class PassThrough
        : IFilter
    {
        static public IFilter New() => new PassThrough();

        public IImage transform(IImage image) => image;
    }
}
