using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Generic;
using AmbiLED;

namespace AmbiLED_HD
{

    class ScreenShot
    {

        public static Byte[] CaptureImage(Rectangle ScreenRectangle, Point[] stripPos)
        {
            using (Bitmap bitmap = new Bitmap(ScreenRectangle.Width, ScreenRectangle.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, ScreenRectangle.Size);


                    Byte[] a = new Byte[stripPos.Length * 3];

                    for (int i = 0; i < stripPos.Length; i++)
                    {
                        a[(i * 3) + 0] = bitmap.GetPixel(stripPos[i].X, stripPos[i].Y).R;
                        a[(i * 3) + 1] = bitmap.GetPixel(stripPos[i].X, stripPos[i].Y).G;
                        a[(i * 3) + 2] = bitmap.GetPixel(stripPos[i].X, stripPos[i].Y).B;
                    }

                    return a;
                }
            }            
        }
    }
}