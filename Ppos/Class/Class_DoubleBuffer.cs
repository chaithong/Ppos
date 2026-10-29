using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Ppos.Class
{
    internal class Class_DoubleBuffer
    {
        public static void EnableDoubleBuffering(Control control)
        {
            try
            {
                PropertyInfo property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)!;
                property?.SetValue(control, true, null);

                foreach (Control ctrl1 in control.Controls)
                {
                    property?.SetValue(ctrl1, true, null);

                    foreach (Control ctrl2 in ctrl1.Controls)
                    {
                        property?.SetValue(ctrl2, true, null);
                        foreach (Control ctrl3 in ctrl2.Controls)
                        {
                            property?.SetValue(ctrl3, true, null);
                            foreach (Control ctrl4 in ctrl3.Controls)
                            {
                                property?.SetValue(ctrl4, true, null);

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
