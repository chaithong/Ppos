using Ppos;
using Ppos.Class;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

public class TableLayoutResizer
{
    private readonly TableLayoutPanel _tableLayoutPanel;
    private bool _isResizingColumn = false;
    private int _lastX = -1;

    public TableLayoutResizer(TableLayoutPanel tableLayoutPanel)
    {
        try
        {
            _tableLayoutPanel = tableLayoutPanel ?? throw new ArgumentNullException(nameof(tableLayoutPanel));

            // เปิด DoubleBuffered ลดอาการกระพริบ
            EnableDoubleBuffering(_tableLayoutPanel);

            InitializeEvents();                  
        }
        catch
        {

        }     
    }

    private void EnableDoubleBuffering(Control control)
    {
        PropertyInfo property = typeof(Control).GetProperty("DoubleBuffered",BindingFlags.NonPublic | BindingFlags.Instance)!;
        property?.SetValue(control, true, null);
    }

    private void InitializeEvents()
    {
        if((_tableLayoutPanel.Name == "tableLayoutPanel_back" ) ||
            _tableLayoutPanel.Name == "tableLayoutPanel_back_pay" && Class_Parameter.pay_show_keypad)
        {
            _tableLayoutPanel.MouseDown += TableLayoutPanel_MouseDown!;
            _tableLayoutPanel.MouseMove += TableLayoutPanel_MouseMove!;
            _tableLayoutPanel.MouseUp += TableLayoutPanel_MouseUp!;
        }
       
        BindMouseEventsToAllControls(_tableLayoutPanel);
    }

    private void BindMouseEventsToAllControls(Control parent)
    {
        foreach (Control ctrl in parent.Controls)
        {
            if (ctrl != _tableLayoutPanel)
            {
                if ((_tableLayoutPanel.Name == "tableLayoutPanel_back" ) ||
                 _tableLayoutPanel.Name == "tableLayoutPanel_back_pay" && Class_Parameter.pay_show_keypad)
                {
                    ctrl.MouseMove += InnerControl_MouseMove!;
                    ctrl.MouseDown += InnerControl_MouseDown!;
                    ctrl.MouseUp += InnerControl_MouseUp!;
                }
               
                EnableDoubleBuffering(ctrl);
            }

            if (ctrl.Controls.Count > 0)
            {
                BindMouseEventsToAllControls(ctrl);
            }
        }
    }

    private void InnerControl_MouseMove(object sender, MouseEventArgs e)
    {
        Control currentCtrl = (Control)sender;

        if (!_isResizingColumn)
        {
            Point tablePoint = _tableLayoutPanel.PointToClient(currentCtrl.PointToScreen(e.Location));
            int col0Width = _tableLayoutPanel.GetColumnWidths()[0]; // ดึงความกว้างคอลัมน์แรก

            if (Math.Abs(tablePoint.X - col0Width) <= 5)
            {
                _tableLayoutPanel.Cursor = Cursors.SizeWE;
                currentCtrl.Cursor = Cursors.SizeWE;
            }
            else
            {
                _tableLayoutPanel.Cursor = Cursors.Default;
                currentCtrl.Cursor = Cursors.Default;
            }
        }
        else
        {
            Point tablePoint = _tableLayoutPanel.PointToClient(currentCtrl.PointToScreen(e.Location));
            MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks, tablePoint.X, tablePoint.Y, e.Delta);
            TableLayoutPanel_MouseMove(_tableLayoutPanel, args);
        }
    }

    private void InnerControl_MouseDown(object sender, MouseEventArgs e)
    {
        Point tablePoint = _tableLayoutPanel.PointToClient(((Control)sender).PointToScreen(e.Location));
        MouseEventArgs args = new MouseEventArgs(e.Button, e.Clicks, tablePoint.X, tablePoint.Y, e.Delta);
        TableLayoutPanel_MouseDown(_tableLayoutPanel, args);
    }

    private void InnerControl_MouseUp(object sender, MouseEventArgs e)
    {
        TableLayoutPanel_MouseUp(_tableLayoutPanel, e);
    }

    private void TableLayoutPanel_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            int col0Width = _tableLayoutPanel.GetColumnWidths()[0];
            if (Math.Abs(e.X - col0Width) <= 5)
            {
                _isResizingColumn = true;
                _tableLayoutPanel.Cursor = Cursors.SizeWE;
                _lastX = e.X;
            }
        }
    }

    private void TableLayoutPanel_MouseMove(object sender, MouseEventArgs e)
    {
        if (!_isResizingColumn)
        {
            int col0Width = _tableLayoutPanel.GetColumnWidths()[0];
            if (Math.Abs(e.X - col0Width) <= 5)
                _tableLayoutPanel.Cursor = Cursors.SizeWE;
            else
                _tableLayoutPanel.Cursor = Cursors.Default;
            return;
        }

        // เมื่อลากเมาส์และตำแหน่งเปลี่ยน
        if (_isResizingColumn && e.X != _lastX && e.X > 20 && e.X < _tableLayoutPanel.Width - 20)
        {
            _lastX = e.X;

            if (_tableLayoutPanel.ColumnStyles.Count >= 2)
            {
                // 1. คำนวณเปอร์เซ็นต์ของ Column แรกตามตำแหน่งเมาส์ (เทียบกับความกว้างรวมของตาราง)
                float pct1 = ((float)e.X / _tableLayoutPanel.Width) * 100 / 1;

                // 2. Column ที่สองจะได้เปอร์เซ็นต์ที่เหลือ เพื่อให้รวมกันได้ 100% พอดี
                float pct2 = 100F - pct1;

                // 3. สั่งหยุดอัปเดตหน้าจอชั่วคราวเพื่อทำการเปลี่ยนประเภทและค่าเปอร์เซ็นต์
                _tableLayoutPanel.SuspendLayout();

                _tableLayoutPanel.ColumnStyles[0].SizeType = SizeType.Percent;
                _tableLayoutPanel.ColumnStyles[0].Width = pct1;

                _tableLayoutPanel.ColumnStyles[1].SizeType = SizeType.Percent;
                _tableLayoutPanel.ColumnStyles[1].Width = pct2;

                // 4. สั่งประมวลผล Layout และสั่งวาดใหม่ทันที (ช่วยให้การลากเป็นเปอร์เซ็นต์ลื่นไหลไม่กระตุก)
                _tableLayoutPanel.ResumeLayout(true);
                _tableLayoutPanel.Refresh();
            }
        }
    }

    private void TableLayoutPanel_MouseUp(object sender, MouseEventArgs e)
    {
        if (_isResizingColumn)
        {
            _isResizingColumn = false;
            _tableLayoutPanel.Cursor = Cursors.Default;
          
            update_sale_left_width();
        }
    }
    private void update_sale_left_width()
    {
        try
        {
            using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
            {
                con_sqlite.Open();
                using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                {
                   // MessageBox.Show(_tableLayoutPanel.Name+" "+ _tableLayoutPanel.ColumnStyles[0].Width);
                    if(_tableLayoutPanel.Name == "tableLayoutPanel_back")
                    {
                        Class_Parameter.sale_left_width = _tableLayoutPanel.ColumnStyles[0].Width;
                        // update 
                        cmd_sqlite.CommandText = "UPDATE Sale_Display_Set SET " +
                                                 "updated_date = datetime('now', 'localtime'), " +
                                                 "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                 "value = '" + Class_Parameter.sale_left_width + "' " +
                                                 "where title = 'sale_left_width'";
                       
                    }
                    else
                    {
                        Class_Parameter.pay_left_width = _tableLayoutPanel.ColumnStyles[0].Width;
                        // update 
                        cmd_sqlite.CommandText = "UPDATE Sale_Display_Set SET " +
                                                 "updated_date = datetime('now', 'localtime'), " +
                                                 "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                 "value = '" + Class_Parameter.pay_left_width + "' " +
                                                 "where title = 'pay_left_width'";
                       
                    }                   
                    cmd_sqlite.ExecuteNonQuery();
                }
            }
        }
        catch
        {

        }
    }
}
