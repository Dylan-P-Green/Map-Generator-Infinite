using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Windows.Graphics.Imaging;
using Windows.Foundation;

namespace PixelEditorLib
{


    [ComImport]
    [Guid("5B0D3235-4DBA-4D44-865E-8F1D0E4FD04D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    unsafe interface IMemoryBufferByteAccess
    {
        void GetBuffer(out byte* buffer, out uint capacity);
    }


    public static class PixelManager
    {
        public static unsafe SoftwareBitmap SavePixelArray(PixelRGBA[,] array)
        {
            int length = array.GetLength(0);
            int width = array.GetLength(1); //Assuming the number of elements is consistant

            //Create base image
            SoftwareBitmap image = new SoftwareBitmap(BitmapPixelFormat.Bgra8, length, width, BitmapAlphaMode.Premultiplied);


            //Access raw image and write data from the 2D processed pixel array
            using (BitmapBuffer buffer = image.LockBuffer(BitmapBufferAccessMode.Write))
            {
                using (IMemoryBufferReference reference = buffer.CreateReference())
                {
                    byte* dataInBytes;
                    uint capacity;
                    ((IMemoryBufferByteAccess)reference).GetBuffer(out dataInBytes, out capacity);

                    BitmapPlaneDescription bufferLayout = buffer.GetPlaneDescription(0);

                    for (int y = 0; y < bufferLayout.Height; y++)
                    {
                        for (int x = 0; x < bufferLayout.Width; x++)
                        {
                            dataInBytes[bufferLayout.StartIndex + bufferLayout.Stride * y + 4 * x + 0] = array[x,y].B;
                            dataInBytes[bufferLayout.StartIndex + bufferLayout.Stride * y + 4 * x + 1] = array[x,y].G;
                            dataInBytes[bufferLayout.StartIndex + bufferLayout.Stride * y + 4 * x + 2] = array[x,y].R;
                            dataInBytes[bufferLayout.StartIndex + bufferLayout.Stride * y + 4 * x + 3] = array[x,y].A;
                        }
                    }
                }
            }


            return image;
        }

        //Create initial pixel structures in the format of a 2D image
        public static PixelRGBA[,] GeneratePixelCanvas(int width, int height)
        {
            PixelRGBA[,] canvas = new PixelRGBA[width,height];

            for(int y = 0; y < height; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    canvas[x, y] = new PixelRGBA(255, 255, 255, 255);
                }
            }
            return canvas;
        }
    }
}
