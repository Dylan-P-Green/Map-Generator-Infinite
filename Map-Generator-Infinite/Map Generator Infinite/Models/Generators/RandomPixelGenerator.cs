using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixelEditorLib;

namespace Map_Generator_Infinite.Models.Generators
{
    class RandomPixelGenerator : Generator
    {
        Random r; //For genetating pixels
        public RandomPixelGenerator()
        {
            title = "Random Pixel Generator";
            author = "Dylan Green";
            description = "A test Generator for Map Generator Infinite";
            IsEnabled = false;
        }




        public override PixelRGBA[,] Apply(PixelRGBA[,] pixels, int seed, int xOffset, int yOffset)
        {
            r = new Random(seed); //Use seed from main form

            //Generate random color for every value of every pixel
            for(int y = 0; y < pixels.GetLength(0); y++)
            {
                for (int x = 0; x < pixels.GetLength(0); x++)
                {
                    pixels[x,y].R = (byte)r.Next(0, 255);
                    pixels[x,y].G = (byte)r.Next(0, 255);
                    pixels[x,y].B = (byte)r.Next(0, 255);
                    pixels[x,y].A = 255; //Leave the image solid with no transparency
                }
            }

            return pixels;
        }

        public override void ShowSettings()
        {
            //TODO: Create settings page and implement controls here
        }

        public override void Submit()
        {
            //TODO: Submit form from settings to alter class variabales
        }
    }
}
