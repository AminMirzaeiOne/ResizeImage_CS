using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ResizeImage
{
    public class Resize
    {
        public enum StandardSizes : int
        {
            Custom, Default = 50, VerySmall = 15, Small = 20, Medium = 40, Large = 60, VeryLarge = 80
        }

        private ResizeImage.Resize.StandardSizes standardSize = ResizeImage.Resize.StandardSizes.Custom;

        public System.Drawing.Image Image { get; set; } = null;
        public System.Int32 Wdith { get; set; } = 50;
        public System.Int32 Height { get; set; } = 50;
        public ResizeImage.Resize.StandardSizes StandardSize
        {
            get { return this.standardSize; }
            set
            {
                this.standardSize = value;
                if (value != StandardSizes.Custom) 
                {
                    this.Wdith = (System.Int32)value;
                    this.Height = (System.Int32)value;
                }
            }
        }

        public Resize()
        {

        }

        public Resize(System.Drawing.Image image,System.Int32 width, System.Int32 height)
        {
            this.Image = image;
            this.Wdith = width;
            this.Height = height;
        }

        public Resize(System.Drawing.Image image,ResizeImage.Resize.StandardSizes standard)
        {
            this.StandardSize = standard;
        }

        public System.Drawing.Bitmap ActionSize()
        {
            var destRect = new Rectangle(0, 0, this.Wdith, this.Height);
            var destImage = new Bitmap(this.Wdith, this.Height);
            destImage.SetResolution(this.Image.HorizontalResolution, this.Image.VerticalResolution);
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(this.Image, destRect, 0, 0, this.Image.Width, this.Image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

    }
}
