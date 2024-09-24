﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ResizeImage
{
    public class Resize
    {
        public enum StandardSizes
        {
            Custom, Default, VerySmall, Small, Medium, Large, VeryLarge
        }

        private ResizeImage.Resize.StandardSizes standardSize = ResizeImage.Resize.StandardSizes.Custom;

        public System.Int32 Wdith { get; set; } = 50;
        public System.Int32 Height { get; set; } = 50;

        public Resize() 
        { 

        }

        public Resize(System.Int32 width,System.Int32 height)
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
