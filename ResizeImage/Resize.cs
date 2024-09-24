using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ResizeImage
{
    public class Resize
    {
        public enum StandardSizes : int
        {
            Custom, Default = 50, VerySmall = 15, Small = 20, Medium = 40, Large = 60, VeryLarge = 80
        }

        private ResizeImage.Resize.StandardSizes standardSize = ResizeImage.Resize.StandardSizes.Custom;

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

        public Resize(System.Int32 width, System.Int32 height)
        {
            this.Wdith = width;
            this.Height = height;
        }

        public Resize(ResizeImage.Resize.StandardSizes standard)
        {
            this.standardSize = standard;
        }

    }
}
