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

        public IImage transform(IImage image)
        {
            var dest_image = image;
            foreach (var filter in this.FilterSequence)
            {
                dest_image = filter.transform(dest_image);
            }
            return dest_image;
        }
    }
}
