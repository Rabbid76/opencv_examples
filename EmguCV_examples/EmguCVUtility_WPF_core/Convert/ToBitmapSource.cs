using System;
using Emgu.CV;
using System.Runtime.InteropServices;
using EmguCVUtility.Image;
using System.Windows;
using System.Windows.Media.Imaging;


namespace EmguCV_equalize.Convert
{
    /// <summary>
    /// See Emgu.CV - WPF in CSharp
    /// http://www.emgu.com/wiki/index.php/WPF_in_CSharp
    /// </summary>
    public class ToBitmapSource
    {
        /// <summary>
        /// Delete a GDI object
        /// </summary>
        /// <param name="o">The pointer to the GDI object to be deleted</param>
        /// <returns></returns>
        [DllImport("gdi32")]
        private static extern int DeleteObject(IntPtr o);

        /// <summary>
        /// Convert an IImage to a WPF BitmapSource. The result can be used in the Set Property of Image.Source
        /// </summary>
        /// <param name="image">The Emgu CV Image</param>
        /// <returns>The equivalent BitmapSource</returns>
        public static BitmapSource convert(IImage image)
        {
            
            using (System.Drawing.Bitmap source = image.matrix.ToBitmap())
            {
                IntPtr ptr = source.GetHbitmap(); //obtain the `Hbitmap`

                BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    ptr,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

                DeleteObject(ptr); //release the HBitmap
                return bs;
            }
        }
    }
}

