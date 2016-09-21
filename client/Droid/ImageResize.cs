using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using formsapp2.Code.api;
using Android.Graphics;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(formsapp2.Droid.ImageResize))]
namespace formsapp2.Droid
{
    class ImageResize : IResizeImage
    {
        public byte[] ResizeImage(byte[] imageByte, float width, float height)
        {
            Bitmap image = BitmapFactory.DecodeByteArray(imageByte, 0, imageByte.Length);
            Bitmap imageResized = Bitmap.CreateScaledBitmap(image, (int)width, (int)height, false);

            using (MemoryStream memory = new MemoryStream())
            {
                imageResized.Compress(Bitmap.CompressFormat.Jpeg, 100, memory);
                return memory.ToArray();
            }
        }
    }
    
}