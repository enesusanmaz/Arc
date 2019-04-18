using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MYARCH.UTILITIES.ImageOperations
{
    public class ImageManager
    {
        public static byte[] imageToByteArray(System.Drawing.Image imageIn, string contentType)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, contentTypetoImageFormat(contentType));
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        static string[] imgFormatsString = { "bmp", "emf", "exif", "gif", "icon", "jpeg", "memorybmp", "png", "tiff", "wmf" };
        static ImageFormat[] imgFormats = { ImageFormat.Bmp, ImageFormat.Emf, ImageFormat.Exif, ImageFormat.Gif, ImageFormat.Icon, ImageFormat.Jpeg, ImageFormat.MemoryBmp, ImageFormat.Png, ImageFormat.Tiff, ImageFormat.Wmf };

        public static ImageFormat contentTypetoImageFormat(string contentType)
        {
            for (int i = 0; i < imgFormatsString.Length; i++)
            {
                if (imgFormatsString[i] == contentType.Split("/".ToCharArray())[1].ToString())
                    return imgFormats.ToList()[i];
            }
            return null;
        }
        public static byte[] ConvertToSize(byte[] image, int? w, int? h)
        {

            bool noCrop = false;
            w = w == 0 ? null : w;
            h = h == 0 ? null : h;
            if ((w != null || h != null))
            {
                System.Drawing.Image orjImg = byteArrayToImage(image);
                if (h == null)
                {
                    h = Convert.ToInt32(((float)w / (float)orjImg.Width) * orjImg.Height);
                    noCrop = true;
                }
                if (w == null)
                {
                    w = Convert.ToInt32(((float)h / (float)orjImg.Height) * orjImg.Width);
                    noCrop = true;
                }
                if (noCrop)
                {
                    Bitmap bmPhoto = new Bitmap(orjImg, w.Value, h.Value);
                    image = imageToByteArray((System.Drawing.Image)bmPhoto, "image/png");
                }
                else
                {
                    float oran = (float)w.Value / (float)h.Value;
                    float orjOran = (float)orjImg.Width / (float)orjImg.Height;
                    int x = 0, y = 0;
                    Rectangle cropArea = new Rectangle();

                    if (oran < orjOran)
                    {
                        cropArea.X = (int)((orjImg.Width - oran * orjImg.Height) / 2);
                        cropArea.Y = 0;
                        cropArea.Height = orjImg.Height;
                        cropArea.Width = (int)(oran * orjImg.Height);
                    }
                    else
                    {
                        cropArea.X = 0;
                        cropArea.Y = (int)((orjImg.Height - orjImg.Width / oran) / 2);
                        cropArea.Height = (int)(orjImg.Width / oran);
                        cropArea.Width = orjImg.Width;
                    }
                    var bmpImage = new Bitmap(orjImg);
                    var cbmpImage = new Bitmap(orjImg, w.Value, h.Value);
                    //System.Drawing.Image croppedImage = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
                    //Bitmap bmCropped = new Bitmap(croppedImage, w.Value, h.Value);
                    //image = imageToByteArray((System.Drawing.Image)bmCropped, "image/png"); 
                    Graphics grp = Graphics.FromImage(cbmpImage);
                    grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    //draw the image into the target bitmap
                    grp.Clear(Color.Transparent);
                    grp.DrawImage(bmpImage, new Rectangle(0, 0, w.Value, h.Value), new Rectangle(cropArea.X, cropArea.Y, cropArea.Width, cropArea.Height), GraphicsUnit.Pixel);
                    grp.Dispose();
                    //grp.DrawImage(bmpImage,w.Value,)
                    //Bitmap bmCropped = new Bitmap(bmpImage, w.Value, h.Value);
                    image = imageToByteArray((System.Drawing.Image)cbmpImage, "image/png");
                }
            }

            return image;
        }
    }

}
