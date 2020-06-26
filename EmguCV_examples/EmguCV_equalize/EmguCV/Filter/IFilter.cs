using EmguCV_equalize.EmguCV.Image;

namespace EmguCV_equalize.EmguCV.Filter
{
    public interface IFilter
    {
        public IImage transform(IImage image);
    }
}
