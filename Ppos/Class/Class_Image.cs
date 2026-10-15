using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppos.Class
{
    internal class Class_Image
    {
        public static Image resizeImage(Image imgToResize, Size size)
        {
            try
            {
                return (Image)(new Bitmap(imgToResize, size));
            }
            catch
            {
                //  Class_Event_Log.AddLog("Error", "resizeImage", ex.Message);
                return null!;
            }

        }
    }
}
