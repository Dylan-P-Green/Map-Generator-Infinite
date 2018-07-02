using PixelEditorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map_Generator_Infinite.Models.Generators
{
    public abstract class Generator
    {
        public bool IsEnabled = false;
        public string author;
        public string description;

        public abstract PixelRGBA[,] Apply(PixelRGBA[,] pixels, int seed);

        public abstract void ShowSettings();
        public abstract void Submit();
    }
}
