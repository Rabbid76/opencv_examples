﻿using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using EmguCV_equalize.EmguCV.Image;
using EmguCV_equalize.EmguCV.Filter;

namespace EmguCV_equalize
{
    class EmguCV_equalize
    {
        static readonly string _image_name = "fruits.jpg";
        static readonly IFilter _filter = Test.New();
        
        static void Main(string[] args)
        {
            var test_image = Image.New(_image_name);
            var filtered_image = _filter.transform(test_image);

            var window_name_1 = $"{_image_name} - original";
            var window_name_2 = $"{_image_name} - equalization filter";
            CvInvoke.Imshow(window_name_1, test_image.image);
            CvInvoke.Imshow(window_name_2, filtered_image.image);
            
            CvInvoke.WaitKey(0);
            CvInvoke.DestroyAllWindows();
        }
    }
}