using System.Collections.Generic;
using EmguCVUtility.Image;

namespace EmguCVUtility.Filter
{
    public class Sequence
        : IFilter
    {
        public IEnumerable<IFilter> FilterSequence { get; set; }

        public Sequence(IEnumerable<IFilter> filter_sequence)
        {
            this.FilterSequence = filter_sequence;
        }

        public static Sequence New(IEnumerable<IFilter> filter_sequence) => new Sequence(filter_sequence);

        public IImage transform_in_place(IImage image)
        {
            foreach (var filter in this.FilterSequence)
            {
                image = filter.transform_in_place(image);
            }
            return image;
        }
    }
}
