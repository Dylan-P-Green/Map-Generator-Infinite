using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace PixelEditorLib
{
    public struct PixelRGBA
    {
        //Standard RGBA format

        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public Color PixelColor
        {
            get
            {
                return Color.FromArgb(A, R, G, B);
            }
            set
            {
                R = value.R;
                G = value.G;
                B = value.B;
                A = value.A;
            }
        }

        public PixelRGBA(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
        public PixelRGBA(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
            A = (byte)255;
        }

        public static PixelRGBA operator +(PixelRGBA a, PixelRGBA b)
        {
            return new PixelRGBA(
                (byte)((a.R / 2 + b.R / 2) * 255),
                (byte)((a.B / 2 + b.B / 2) * 255),
                (byte)((a.G / 2 + b.G / 2) * 255),
                (byte)((a.A / 2 + b.A / 2) * 255)
                );
        }
        public static PixelRGBA operator *(PixelRGBA a, PixelRGBA b)
        {
            return new PixelRGBA(
                (byte)((a.R * b.R) * 255),
                (byte)((a.B * b.B) * 255),
                (byte)((a.G * b.G) * 255),
                (byte)((a.A * b.A) * 255)
                );
        }
        public static PixelRGBA operator -(PixelRGBA a, PixelRGBA b)
        {
            return new PixelRGBA(
                (byte)(Math.Abs(a.R / 2 - b.R / 2) * 255),
                (byte)(Math.Abs(a.G / 2 - b.G / 2) * 255),
                (byte)(Math.Abs(a.B / 2 - b.B / 2) * 255),
                (byte)(Math.Abs(a.A / 2 - b.A / 2) * 255)
                );
        }
    }
}
