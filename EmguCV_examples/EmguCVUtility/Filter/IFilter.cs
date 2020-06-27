using EmguCVUtility.Image;

namespace EmguCVUtility.Filter
{
    public interface IFilter
    {
        IImage transform(IImage image);
    }
}
