using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmguCVUtility.Filter;
using System.Drawing;
using System.Linq;

namespace UnitTest.EmguCV.Filter
{
    [TestClass]
    public class Sequence
    {
        static readonly IFilter filter_sequance = 
            EmguCVUtility.Filter.Sequence.New(new IFilter[]
                {
                    EmguCVUtility.Filter.Flip.New(FlipAxis.XAxis),
                    EmguCVUtility.Filter.Flip.New(FlipAxis.YAxis),
                    EmguCVUtility.Filter.Flip.New(FlipAxis.XAxis),
                    EmguCVUtility.Filter.Flip.New(FlipAxis.YAxis)
                });

        [TestMethod]
        public void SequenceTest()
        {
            var test_image = EmguCVUtility.Image.Image.New8U(new Size(4, 4), 1);
            byte[] image_array = Enumerable.Range(0, 16).Select(x => (byte)x).ToArray();
            test_image.matrix.SetTo(image_array);

            var filtered_image = filter_sequance.transform(test_image);
            byte[] filter_data = new byte[image_array.Length];
            filtered_image.matrix.CopyTo(filter_data);

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    Assert.AreEqual(y * 4 + x, filter_data[y * 4 + x]);
                }
            }
        }
    }
}
