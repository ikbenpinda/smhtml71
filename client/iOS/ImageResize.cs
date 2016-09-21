using CoreGraphics;
using formsapp2.Code.api;
using System;
using System.Drawing;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(formsapp2.iOS.ImageResize))]
namespace formsapp2.iOS
{
    public class ImageResize : IResizeImage
    {

        public byte[] ResizeImage(byte[] imageByte, float width, float height)
        {
            UIImage originalImage = ImageFromByteArray(imageByte);
            UIImageOrientation orientation = originalImage.Orientation;

            //create a 24bit RGB image
            int intWidth = (int)width;
            int intHeihgt = (int)height;
            using (CGBitmapContext context = new CGBitmapContext(IntPtr.Zero,
                intWidth, intHeihgt, 8,
                4 * intWidth, CGColorSpace.CreateDeviceRGB(),
                CGImageAlphaInfo.PremultipliedFirst))
            
                {

                RectangleF imageRect = new RectangleF(0, 0, width, height);

                // draw the image
                context.DrawImage(imageRect, originalImage.CGImage);

                UIImage resizedImage = UIImage.FromImage(context.ToImage(), 0, orientation);

                // save the image as a jpeg
                return resizedImage.AsJPEG().ToArray();
            }
        }

        public static UIImage ImageFromByteArray(byte[] data)
        {
            if (data == null)
            {
                return null;
            }

            UIImage image;
            try
            {
                image = new UIImage(Foundation.NSData.FromArray(data));
            }
            catch (Exception e)
            {
                Console.WriteLine("Image load failed: " + e.Message);
                return null;
            }
            return image;
        }

    }
}