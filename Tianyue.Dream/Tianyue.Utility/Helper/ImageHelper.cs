using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tianyue.Utility.Common;

namespace Tianyue.Utility.Helper
{
    /// <summary>
    /// 图像帮助类
    /// </summary>
    public class ImageHelper
    {
        /// <summary>
        /// 横向合并图片
        /// </summary>
        /// <param name="maps"></param>
        /// <returns></returns>
        public static Bitmap MergerImg(params Image[] maps)
        {
            int i = maps.Length;
            if (i == 0)
            {
                //ExceptUtil.ThrowIfNull(() => maps);
            }

            var map = maps.FirstOrDefault();
            if (map != null)
            {
                //创建要显示的图片对象,根据参数的个数设置宽度
                Bitmap backgroudImg = new Bitmap((map.Width + 5) * i, map.Height);

                using (Graphics g = Graphics.FromImage(backgroudImg))
                {
                    //清除画布,背景设置为白色
                    g.Clear(System.Drawing.Color.Transparent);

                    for (int j = 0; j < i; j++)
                    {
                        g.DrawImage(maps[j], (maps[j].Width + 5) * j, 0, maps[j].Width, maps[j].Height);
                    }
                }

                return backgroudImg;
            }
            else
            {
                return null;
            }
        }

        public static Image CreateThumbnail(Stream fileStream, int width, int height, System.Drawing.Color penColor)
        {
            Bitmap bitmap;
            try
            {
                bitmap = new Bitmap(fileStream);
            }
            catch
            {
                bitmap = new Bitmap(width, height);
            }
            return CreateThumbnail(bitmap, width, height, penColor);
        }

        public static Image CreateThumbnail(string fileName, int width, int height, System.Drawing.Color penColor)
        {
            Bitmap bitmap;
            try
            {
                bitmap = new Bitmap(fileName);
            }
            catch
            {
                bitmap = new Bitmap(width, height);
            }
            return CreateThumbnail(bitmap, width, height, penColor);
        }

        public static Image CreateThumbnail(Image image, int width, int height, System.Drawing.Color penColor)
        {
            Bitmap bitmap;
            try
            {
                bitmap = new Bitmap(image);
            }
            catch
            {
                bitmap = new Bitmap(width, height);
            }
            return CreateThumbnail(bitmap, width, height, penColor);
        }

        public static Image CreateThumbnail(Bitmap bitmap, int width, int height, System.Drawing.Color penColor)
        {
            width = bitmap.Width > width ? width : bitmap.Width;
            height = bitmap.Height > height ? height : bitmap.Height;
            Bitmap bitmap1 = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format64bppPArgb);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap1))
            {
                int width1 = width;
                int height1 = height;
                if (bitmap.Width > bitmap.Height)
                    height1 = (int)((double)bitmap.Height / (double)bitmap.Width * (double)width1);
                else if (bitmap.Width < bitmap.Height)
                    width1 = (int)((double)bitmap.Width / (double)bitmap.Height * (double)height1);
                int x = width / 2 - width1 / 2;
                int y = height / 2 - height1 / 2;
                graphics.PixelOffsetMode = PixelOffsetMode.None;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage((Image)bitmap, x, y, width1, height1);
                using (System.Drawing.Pen pen = new System.Drawing.Pen(penColor, 1f))
                    graphics.DrawRectangle(pen, 0, 0, bitmap1.Width - 1, bitmap1.Height - 1);
                return (Image)bitmap1;
            }
        }

        //public static void DrawImage(Graphics g, Rectangle rect, Image img, float opacity)
        //{
        //    if ((double)opacity <= 0.0)
        //        return;
        //    using (ImageAttributes imageAttributes = new ImageAttributes())
        //    {
        //        SetImageOpacity(imageAttributes, (double)opacity >= 1.0 ? 1f : opacity);
        //        Rectangle rectangle;
        //        ref Rectangle local = ref rectangle;
        //        int x = rect.X;
        //        int y = rect.Y + rect.Height / 2 - img.Size.Height / 2;
        //        System.Drawing.Size size = img.Size;
        //        int width = size.Width;
        //        size = img.Size;
        //        int height = size.Height;
        //        local = new Rectangle(x, y, width, height);
        //        g.DrawImage(img, rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAttributes);
        //    }
        //}

        public static void SetImageOpacity(ImageAttributes imgAttributes, float opacity)
        {
            ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
            {
        new float[5]{ 1f, 0.0f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 1f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 1f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, opacity, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
            });
            imgAttributes.SetColorMatrix(newColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        }

        public static ImageSource CreateImageSourceThumbnia(string fileName, double width, double height)
        {
            Image original = Image.FromFile(fileName);
            float num = (float)Math.Min(width / (double)original.Width, height / (double)original.Height);
            int width1 = original.Width;
            int height1 = original.Height;
            if ((double)num < 1.0)
            {
                width1 = (int)Math.Round((double)original.Width * (double)num);
                height1 = (int)Math.Round((double)original.Height * (double)num);
            }
            Bitmap bitmap = new Bitmap(original, width1, height1);
            IntPtr hbitmap = bitmap.GetHbitmap();
            BitmapSource sourceFromHbitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            sourceFromHbitmap.Freeze();
            Win32.DeleteObject(hbitmap);
            original.Dispose();
            bitmap.Dispose();
            return (ImageSource)sourceFromHbitmap;
        }

        public static ImageSource CreateImageSourceThumbnia(Image sourceImage, double width, double height)
        {
            if (sourceImage == null)
                return (ImageSource)null;
            float num = (float)Math.Min(width / (double)sourceImage.Width, height / (double)sourceImage.Height);
            int width1 = sourceImage.Width;
            int height1 = sourceImage.Height;
            if ((double)num < 1.0)
            {
                width1 = (int)Math.Round((double)sourceImage.Width * (double)num);
                height1 = (int)Math.Round((double)sourceImage.Height * (double)num);
            }
            Bitmap bitmap = new Bitmap(sourceImage, width1, height1);
            IntPtr hbitmap = bitmap.GetHbitmap();
            BitmapSource sourceFromHbitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            sourceFromHbitmap.Freeze();
            Win32.DeleteObject(hbitmap);
            sourceImage.Dispose();
            bitmap.Dispose();
            return (ImageSource)sourceFromHbitmap;
        }

        public static ImageSource CreateImageSourceThumbnia(byte[] data, double width, double height)
        {
            using (Stream stream = (Stream)new MemoryStream(data, true))
            {
                using (Image sourceImage = Image.FromStream(stream))
                    return CreateImageSourceThumbnia(sourceImage, width, height);
            }
        }

        public static ImageSource CreateImageSourceFromImage(Bitmap image)
        {
            if (image == null)
                return (ImageSource)null;
            try
            {
                IntPtr hbitmap = image.GetHbitmap();
                BitmapSource sourceFromHbitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                sourceFromHbitmap.Freeze();
                image.Dispose();
                Win32.DeleteObject(hbitmap);
                return (ImageSource)sourceFromHbitmap;
            }
            catch (Exception ex)
            {
                return (ImageSource)null;
            }
        }

    }
}
