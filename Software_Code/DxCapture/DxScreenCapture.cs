using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Direct2D;
using SlimDX.Direct3D9;

namespace KMPP
{
    public class DxScreenCapture
    {
        Device d,d2;

        public DxScreenCapture()
        {
            PresentParameters present_params = new PresentParameters();
            present_params.Windowed = true;
            present_params.SwapEffect = SwapEffect.Discard;
            //present_params.BackBufferCount = 1;
            //present_params.FullScreenRefreshRateInHertz = 0;
            d = new Device(new Direct3D(), 0, DeviceType.Hardware, IntPtr.Zero, CreateFlags.SoftwareVertexProcessing, present_params);
            //d2 = new Device(new Direct3D(), 1, DeviceType.Hardware, IntPtr.Zero, CreateFlags.SoftwareVertexProcessing, present_params);
        }

  

        public Surface CaptureScreen()
        {
            
            
            
            Surface s = Surface.CreateOffscreenPlain(d, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, Format.A8R8G8B8, Pool.Scratch);
            //d.GetFrontBufferData(0, s);

            //Surface s = Surface.CreateOffscreenPlain(d, SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height, Format.A8R8G8B8, Pool.Scratch);
            d.GetFrontBufferData(0, s);

 
           
            return s;
        }

        public Surface CaptureScreen2()
        {



            Surface s2 = Surface.CreateOffscreenPlain(d2, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, Format.A8R8G8B8, Pool.Scratch);
            //d.GetFrontBufferData(0, s);

            //Surface s = Surface.CreateOffscreenPlain(d, SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height, Format.A8R8G8B8, Pool.Scratch);
            d2.GetFrontBufferData(0, s2);



            return s2;
        }

    }
}




