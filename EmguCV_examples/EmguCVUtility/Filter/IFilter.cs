using EmguCVUtility.Image;

namespace EmguCVUtility.Filter
{
    public interface IFilter
    {
        IImage transform_in_place(IImage image);
    }
}
