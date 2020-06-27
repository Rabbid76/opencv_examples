using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmguCVUtility.Filter;
using System.Drawing;
using System.Linq;

namespace UnitTest.EmguCV.Filter
{
    [TestClass]
    public class Equalizer
    {
        static readonly IFilter filter = EmguCVUtility.Filter.Equalizer.New();
            
        [TestMethod]
        public void EquilizerTest()
        {
            var test_image = EmguCVUtility.Image.Image.New8U(new Size(4, 4), 1);
            byte[] image_array = Enumerable.Range(100, 16).Select(x => (byte)x).ToArray();
            test_image.matrix.SetTo(image_array);

            var filtered_image = filter.transform(test_image);
            byte[] filter_data = new byte[image_array.Length];
            filtered_image.matrix.CopyTo(filter_data);

            Assert.AreEqual(0, filter_data[0]);
            Assert.AreEqual(255, filter_data[15]);
        }
    }
}
