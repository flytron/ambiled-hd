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
            //byte[] frame_pixels = new byte[15000 * 3]; //more than 4K resolution


            using (Bitmap bitmap = new Bitmap(ScreenRectangle.Width, ScreenRectangle.Height))
            {

                using (Graphics g = Graphics.FromImage(bitmap))
                {
                     g.CopyFromScreen(Point.Empty, Point.Empty, ScreenRectangle.Size);
                }


                //long pixel_counter = 0;
               Byte[] a = new Byte[stripPos.Length*3];
                
               for (int i = 0; i < stripPos.Length; i++)
                {
                    a[(i*3)+0] = bitmap.GetPixel(stripPos[i].X, stripPos[i].Y).R;
                    a[(i*3)+1] = bitmap.GetPixel(stripPos[i].X, stripPos[i].Y).G;
                    a[(i*3)+2] = bitmap.GetPixel(stripPos[i].X, stripPos[i].Y).B;
                }
               /*

                Color c;
                long ortalama = 0;

                for (int i = 0; i < 1000; i++)
                {
                    c = bitmap.GetPixel(i, 1000);
                    ortalama += c.R;
                }
                ortalama = ortalama / 1000;
                */
                //label1.Text = ortalama.ToString();


                //Image img = (Image)bitmap;
                //Clipboard.SetImage(img);
                //Color c = bitmap.GetPixel(1000, 1000);

                return a;


            }

        }
    }
}