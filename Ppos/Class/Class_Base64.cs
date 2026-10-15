using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppos.Class
{
    internal class Class_Base64
    {

        public static string RC_Base64ToString(string bs)
        {
            try
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String( /// แปลงออก base64 1
                       Encoding.UTF8.GetString(Convert.FromBase64String( /// แปลงออก base64 2
                       bs))));
            }
            catch 
            {
                return "";
            }
        }
        public static string RC_StringToBase64(string sb)
        {
            try
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(  /// แปลง base64 1
                       Convert.ToBase64String(Encoding.UTF8.GetBytes(  /// แปลง base64 2
                       sb))));
            }
            catch
            {
                return "";
            }
        }
        public static string ST_String()
        {
            try
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(
                   Encoding.UTF8.GetString(Convert.FromBase64String(
                   Encoding.UTF8.GetString(Convert.FromBase64String(
                   Encoding.UTF8.GetString(Convert.FromBase64String(
                   File.ReadLines(Class_Parameter.STtxt).First()))))))));
            }
            catch
            {
                return "";
            }
        }
        public static string ST_Base64()
        {
            try
            {
                // วันที่เริ่ม วันปัจจุบัน
                CultureInfo cultures = new CultureInfo("en-US");
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(  // แปลง base64 1
                           Convert.ToBase64String(Encoding.UTF8.GetBytes(  // แปลง base64 2
                           Convert.ToBase64String(Encoding.UTF8.GetBytes(  // แปลง base64 3
                           Convert.ToBase64String(Encoding.UTF8.GetBytes(  // แปลง base64 4
                           DateTime.Now.ToString("yyyy-MM-dd", cultures).Replace("-", "")))))))));
            }
            catch
            {
                return "";
            }
        }
    }
}
