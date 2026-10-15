
using Microsoft.Office.Interop.Excel;
using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Ppos
{
    public partial class Form_Load_Add : Form
    {
        string path_load;
        bool status_upload,status_file;
        System.Data.DataTable dt;
        SQLiteDataReader dr;

        public Form_Load_Add()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            button_download_all_item.Location = new System.Drawing.Point((panel_back.Width / 2) - (button_download_all_item.Width / 2), 10);

            pictureBox_load_all_item.Location = button_download_all_item.Location;

            customPanel_all_item.Location = new System.Drawing.Point(pictureBox_load_all_item.Location.X, pictureBox_load_all_item.Location.Y + pictureBox_load_all_item.Height + 10);

            customGroupBox_add_item.Location = new System.Drawing.Point(pictureBox_load_all_item.Location.X, customPanel_all_item.Location.Y + customPanel_all_item.Height + 10);


            button_download_all_item.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Excel, new Size(60, 60));



            button_upload.Image = Class_Image.resizeImage(Ppos.Properties.Resources.additem, new Size(60, 60));

            button_load_template.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Excel, new Size(30, 30));

            button_load_error.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Excel, new Size(30, 30));



            using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
            {
                con_sqlite.Open();
                using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                {
                    // count item
                    cmd_sqlite.CommandText = "select count(code) from Item where status = 1";
                    using (var reader = cmd_sqlite.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // อ่านค่าจากคอลัมน์แรก (ดัชนี 0) มาใส่ใน Source
                            label_item_all.Text = Convert.ToInt32(reader[0].ToString()).ToString("#,##0");
                        }
                    }
                }
            }

        }
        // สรรหาฟังก์ชันจากภายนอกมาช่วยดึง Process ID ของหน้าต่าง Excel
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        private void button_download_all_item_Click(object sender, EventArgs e)
        {

            try
            {
                panel_load.Focus();
                if (Convert.ToUInt32(label_item_all.Text.Replace(",", "")) > 0)
                {
                    using (SaveFileDialog saveFileDialoge = new SaveFileDialog())
                    {
                        saveFileDialoge.FileName = "สินค้าทั้งหมด_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
                        saveFileDialoge.DefaultExt = ".Xlsx";
                        saveFileDialoge.Filter = "Xlsx|*.Xlsx";
                        saveFileDialoge.Title = "บันทึกไฟล์สินค้า";


                        if (saveFileDialoge.ShowDialog(this) == DialogResult.OK)
                        {
                            path_load = saveFileDialoge.FileName;
                            panel_load.Focus();

                            button_download_all_item.Visible = false;

                            button_upload.Enabled = false;

                            button_load_template.Enabled = false;

                            button_load_error.Enabled = false;

                            Class_Parameter.runbackground = true;

                            backgroundWorker_export_all_item.RunWorkerAsync();
                        }
                    }
                }


            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        private void backgroundWorker_export_all_item_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {


                // 2. ประกาศตัวแปร COM Objects
                Excel.Application App = new Excel.Application();
                Excel.Workbooks workbooks = App.Workbooks;
                Excel.Workbook workbook = workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                uint excelProcessId = 0;
                GetWindowThreadProcessId((IntPtr)App.Hwnd, out excelProcessId);
                try
                {

                    worksheet.Name = "สินค้า";



                    worksheet.Columns[1].ColumnWidth = 30;

                    worksheet.Rows[1].Font.Size = 14;
                    worksheet.Rows[1].Font.Bold = true;

                    worksheet.Cells[1, 1] = " กลุ่มหลัก ";
                    worksheet.Cells[1, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[1].NumberFormat = "@";

                    worksheet.Cells[1, 2] = " กลุ่มย่อย ";
                    worksheet.Cells[1, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[2].NumberFormat = "@";

                    worksheet.Cells[1, 3] = " บาร์โค้ด ";
                    worksheet.Cells[1, 3].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[3].NumberFormat = "@";

                    worksheet.Cells[1, 4] = " ชื่อสินค้า ";
                    worksheet.Cells[1, 4].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[4].NumberFormat = "@";

                    worksheet.Cells[1, 5] = " จำนวน ";
                    worksheet.Cells[1, 5].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[5].NumberFormat = "General";

                    worksheet.Cells[1, 6] = " หน่วย ";
                    worksheet.Cells[1, 6].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[6].NumberFormat = "@";

                    worksheet.Cells[1, 7] = " ราคาต่อหน่วย ";
                    worksheet.Cells[1, 7].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[7].NumberFormat = "General";

                    worksheet.Cells[1, 8] = " ต้นทุนต่อหน่วย ";
                    worksheet.Cells[1, 8].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[8].NumberFormat = "General";

                    worksheet.Activate();
                    worksheet.Application.ActiveWindow.SplitRow = 1;
                    worksheet.Application.ActiveWindow.FreezePanes = true;

                    // สร้างเส้น                
                    Excel.Range rangeAllBorders = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 8]];
                    rangeAllBorders.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    rangeAllBorders.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    rangeAllBorders.Borders.Color = ColorTranslator.ToOle(Color.Black);

                    // เริ่มใส่ข้อมูล
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {

                            cmd_sqlite.CommandText = "SELECT group_main,group_sub,name," +
                                     "small_barcode as barcode,small_unit,small_price," +
                                     "small_cost_last,small_cost_avg,small_qty " +
                                     "from Item " +
                                     "where status = 1 ";

                            cmd_sqlite.CommandText += "union all " +
                                      "SELECT group_main,group_sub,name," +
                                      "medium_barcode,medium_unit,medium_price,medium_cost_last,medium_cost_avg,medium_qty " +
                                      "from Item " +
                                      "where status = 1 " +
                                      "and medium_barcode <> '' ";

                            cmd_sqlite.CommandText += "union all " +
                                      "SELECT group_main,group_sub,name," +
                                      "large_barcode,large_unit,large_price,large_cost_last,large_cost_avg,large_qty " +
                                      "from Item " +
                                      "where status = 1 " +
                                      "and large_barcode <> ''";

                            cmd_sqlite.CommandText += "order by group_main,group_sub,name ";

                            dr = cmd_sqlite.ExecuteReader();
                            dt = new System.Data.DataTable();
                            dt.Load(dr);
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    worksheet.Cells[i + 2, 1] = dt.Rows[i]["group_main"].ToString();
                                    worksheet.Cells[i + 2, 2] = dt.Rows[i]["group_sub"].ToString();
                                    worksheet.Cells[i + 2, 3] = dt.Rows[i]["barcode"].ToString();
                                    worksheet.Cells[i + 2, 4] = dt.Rows[i]["name"].ToString();
                                    worksheet.Cells[i + 2, 5] = dt.Rows[i]["small_qty"].ToString();
                                    worksheet.Cells[i + 2, 6] = dt.Rows[i]["small_unit"].ToString();
                                    worksheet.Cells[i + 2, 7] = dt.Rows[i]["small_price"].ToString();
                                    worksheet.Cells[i + 2, 8] = dt.Rows[i]["small_cost_avg"].ToString();

                                    panel_load.Width = (i + 1) * panel_back.Width / dt.Rows.Count;
                                }
                            }
                        }
                    }

                    worksheet.Columns.AutoFit();

                    // 4. บันทึกไฟล์ไปยัง Path ที่ผู้ใช้เลือกจาก Dialog
                    // ลบไฟล์เก่าทิ้งก่อน (ถ้ามีชื่อซ้ำและต้องการเซฟทับโดยไม่ให้ Excel ถามแจ้งเตือน)
                    App.DisplayAlerts = false;
                    App.Visible = false; // ซ่อนหน้าต่าง Excel ไว้เบื้องหลังขณะทำงาน

                    workbook.SaveAs(path_load);

                }
                finally
                {

                    // ปิดแบบนุ่มนวลก่อน
                    try { App.Quit(); } catch { }

                    // สั่งจัดการขั้นเด็ดขาดดึง Process เจาะจงตัวนี้มาสั่งปิดทันที [2]
                    if (excelProcessId != 0)
                    {
                        try
                        {
                            Process excelProcess = Process.GetProcessById((int)excelProcessId);
                            if (excelProcess != null && !excelProcess.HasExited)
                            {
                                excelProcess.Kill(); // ตัดจบกระบวนการทันที ไม่เหลือค้างแน่นอน [2]
                            }
                        }
                        catch { /* หากกระบวนการปิดไปแล้ว จะข้ามส่วนนี้อัตโนมัติ */}
                    }
                }
            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        private void backgroundWorker_export_all_item_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Class_Parameter.runbackground = false;

                MessageBox.Show(path_load, "ดาวน์โหลดไฟล์ เรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Information);

                button_download_all_item.Visible = true;

                button_upload.Enabled = true;

                button_load_template.Enabled = true;

                button_load_error.Enabled = true;

                panel_load.Width = 0;
            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }
        private void button_upload_Click(object sender, EventArgs e)
        {
            try
            {
                panel_load.Focus();
                OpenFileDialog Pexcel = new OpenFileDialog();
                Pexcel.Filter = "Excel File|*.xls;*.xlsx;*.xlsm";

                if (Pexcel.ShowDialog() == DialogResult.OK)
                {
                    status_upload = true;
                    status_file = true;

                    path_load = Pexcel.FileName;


                    pictureBox_load_error.Visible = false;
                    button_load_error.Visible = false;

                    button_upload.Text = "กำลังอัพโหลด      ";

                    button_download_all_item.Enabled = false;

                    button_upload.Enabled = false;

                    button_load_template.Enabled = false;

                    button_load_error.Enabled = false;

                    label_item_load.Text = "0";
                    label_item_load_complete.Text = "0";
                    label_item_data_error.Text = "0";

                    Class_Parameter.runbackground = true;
                    backgroundWorker_import_excel.RunWorkerAsync();
                }
            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        private void backgroundWorker_import_excel_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbook workbook = app.Workbooks.Open(path_load);
                Excel.Worksheet worksheet = workbook.Worksheets[1];
                Excel.Range xlRange = worksheet.UsedRange;

                uint excelProcessId = 0;
                GetWindowThreadProcessId((IntPtr)app.Hwnd, out excelProcessId);

                try
                {
                    int rows = xlRange.Rows.Count;
                    int noofrow = 3;

                    if (rows >= 3) // ถ้ามีข้อมูลรายการสินค้า ไม่รวมหัวข้อ
                    {
                        if (worksheet.Name == "สินค้า" &&
                           worksheet.Cells[1, 3].Text.Trim() == "บาร์โค้ด" && // บาร์โค้ด
                           worksheet.Cells[1, 4].Text.Trim() == "ชื่อสินค้า" && // ชื่อ
                           worksheet.Cells[1, 5].Text.Trim() == "หน่วย" && // หน่วย
                           worksheet.Cells[1, 6].Text.Trim() == "ราคาต่อหน่วย" // ราคา
                            )
                        {
                            using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                            {
                                con_sqlite.Open();
                                using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                {
                                    // ลบข้อมูลสินค้า
                                    cmd_sqlite.CommandText = "DELETE from Item_Temp_Excel";
                                    cmd_sqlite.ExecuteNonQuery();

                                    string status = "";
                                    // เพิ่มข้อมูลสินค้า

                                    for (int r = noofrow; r <= rows; r++)
                                    {

                                        status = "";

                                        if (worksheet.Cells[r, 3].Text.Replace("'", "").Trim() != "" && // บาร์โค้ด
                                            worksheet.Cells[r, 4].Text.Replace("'", "").Trim() != "" && // ชื่อ
                                            worksheet.Cells[r, 5].Text.Replace("'", "").Trim() != "" && // หน่วย
                                            worksheet.Cells[r, 6].Text.Replace("'", "").Trim() != "" // ราคา
                                            )
                                        {
                                            // ราคาต้องเป็นตัวเลข
                                            if (double.TryParse(worksheet.Cells[r, 6].Text.Replace("'", "").Trim(), out double price))
                                            {
                                                // ราคาขายต้องมากกว่า 0
                                                if (Convert.ToDouble(worksheet.Cells[r, 6].Text.Replace("'", "").Trim()) > 0)
                                                {
                                                    // ตรวจสอบจำนวน
                                                    if (worksheet.Cells[r, 8].Text.Replace("'", "").Trim() != "")
                                                    {
                                                        if (double.TryParse(worksheet.Cells[r, 8].Text.Replace("'", "").Trim(), out double qty))
                                                        {
                                                            // ตรวจสอบต้นทุน
                                                            if (worksheet.Cells[r, 7].Text.Replace("'", "").Trim() != "")
                                                            {
                                                                if (!double.TryParse(worksheet.Cells[r, 7].Text.Replace("'", "").Trim(), out double cost))
                                                                {
                                                                    label_item_data_error.Text = (Convert.ToInt32(label_item_data_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                                    status = "ต้นทุนต้องเป็นตัวเลข";
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            label_item_data_error.Text = (Convert.ToInt32(label_item_data_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                            status = "จำนวนต้องเป็นตัวเลข";
                                                        }
                                                    }
                                                    // ถ้า จำนวนไม่มี แต่มีต้นทุน
                                                    else if (worksheet.Cells[r, 7].Text.Replace("'", "").Trim() != "")
                                                    {
                                                        label_item_data_error.Text = (Convert.ToInt32(label_item_data_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                        status = "มีต้นทุนจะต้องมีจำนวน";
                                                    }
                                                }
                                                else
                                                {
                                                    label_item_data_error.Text = (Convert.ToInt32(label_item_data_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                    status = "ราคาขายต้องมากกว่า 0";
                                                }
                                            }
                                            else
                                            {
                                                label_item_data_error.Text = (Convert.ToInt32(label_item_data_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                status = "ราคาขายต้องเป็นตัวเลข";
                                            }

                                        }
                                        else
                                        {
                                            label_item_data_error.Text = (Convert.ToInt32(label_item_data_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                            status = "ข้อมูลไม่ครบถ้วน";
                                        }

                                        // ตรวจสอบ กลุ่ม
                                        if ((worksheet.Cells[r, 1].Text.Replace("'", "").Trim() != "" && worksheet.Cells[r, 2].Text.Replace("'", "").Trim() == "") ||
                                           (worksheet.Cells[r, 1].Text.Replace("'", "").Trim() == "" && worksheet.Cells[r, 2].Text.Replace("'", "").Trim() != ""))
                                        {
                                            if (status == "")
                                            {
                                                status = "กลุ่มสินค้าไม่ครบถ้วน";
                                            }
                                            else
                                            {
                                                status += " และ กลุ่มสินค้าไม่ครบถ้วน";
                                            }
                                            label_item_data_error.Text = (Convert.ToInt32(label_item_data_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                        }
                                        // มีทั้งคู แต่เหมือนกัน
                                        else if (worksheet.Cells[r, 1].Text.Replace("'", "").Trim() != "" && worksheet.Cells[r, 2].Text.Replace("'", "").Trim() != "" &&
                                               worksheet.Cells[r, 1].Text.Replace("'", "").Trim() == worksheet.Cells[r, 2].Text.Replace("'", "").Trim())
                                        {
                                            if (status == "")
                                            {
                                                status = "กลุ่มสินค้าต้องไม่เหมือนกัน";
                                            }
                                            else
                                            {
                                                status += " และ กลุ่มสินค้าต้องไม่เหมือนกัน";
                                            }
                                            label_item_data_error.Text = (Convert.ToInt32(label_item_data_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                        }
                                        cmd_sqlite.CommandText = "INSERT INTO Item_Temp_Excel(group_main,group_sub,small_barcode,name,small_unit,small_price,small_cost_last,small_qty,status) VALUES";

                                        cmd_sqlite.CommandText += "('" + worksheet.Cells[r, 1].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                         worksheet.Cells[r, 2].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                         worksheet.Cells[r, 3].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                         worksheet.Cells[r, 4].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                         worksheet.Cells[r, 5].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                         worksheet.Cells[r, 6].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                         worksheet.Cells[r, 7].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                         worksheet.Cells[r, 8].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                         status + "')";
                                        panel_load.Width = r * panel_back.Width / 2 / rows;
                                        label_item_load.Text = (Convert.ToInt32(label_item_load.Text.Replace(",", "")) + 1).ToString("#,##0");

                                        cmd_sqlite.ExecuteNonQuery();
                                        loading(r);
                                    }
                                    // cmd_sqlite.CommandText = cmd_sqlite.CommandText.Substring(0, cmd_sqlite.CommandText.Length - 1);
                                    // cmd_sqlite.ExecuteNonQuery();

                                    // กลุ่มย่อยซ้ำใน temp
                                    cmd_sqlite.CommandText = "UPDATE Item_Temp_Excel set status = 'กลุ่มย่อยซ้ำกันแต่ละกลุ่มหลัก' " +
                                                            "WHERE group_sub in( " +
                                                            "SELECT g.group_sub from ( " +
                                                            "SELECT ite.group_main , ite.group_sub " +
                                                            "from Item_Temp_Excel ite " +
                                                            "group by ite.group_main , ite.group_sub ) g " +
                                                            "group by g.group_sub " +
                                                            "HAVING count(g.group_sub) >1) " +
                                                            "and status = ''";
                                    cmd_sqlite.ExecuteNonQuery();

                                    // กลุ่มย่อยซ้ำในระบบ
                                    cmd_sqlite.CommandText = "UPDATE Item_Temp_Excel set status = 'กลุ่มย่อยซ้ำกับในระบบแต่ละกลุ่มหลัก' " +
                                                             "WHERE group_sub in( " +
                                                             "SELECT g.group_sub from( " +
                                                             "SELECT ite.group_main , ite.group_sub  " +
                                                             "from Item_Temp_Excel ite  " +
                                                             "where ite.status = '' " +
                                                             "group by ite.group_main , ite.group_sub " +
                                                             "union " +
                                                             "SELECT ig.group_main , ig.group_sub  " +
                                                             "from Item_Group ig  " +
                                                             "group by ig.group_main , ig.group_sub) g " +
                                                             "group by g.group_sub " +
                                                             "HAVING count(g.group_sub) >1) " +
                                                             "and status = ''";
                                    cmd_sqlite.ExecuteNonQuery();

                                    // หาบาร์ซ้ำ ใน temp
                                    cmd_sqlite.CommandText = "UPDATE Item_Temp_Excel set status = 'บาร์โค้ดซ้ำกัน' where small_barcode in( " +
                                                             "SELECT small_barcode from Item_Temp_Excel where status = '' group by small_barcode HAVING count(small_barcode)>1) " +
                                                             "and status = ''";
                                    cmd_sqlite.ExecuteNonQuery();

                                    // หาบาร์ซ้ำ ใน Item
                                    cmd_sqlite.CommandText = "UPDATE Item_Temp_Excel  set status = 'บาร์โค้ดซ้ำกับสินค้าในระบบ' " +
                                                             "where small_barcode in ( SELECT ite.small_barcode from item i " +
                                                             "join Item_Temp_Excel ite on ite.small_barcode = i.small_barcode where i.status = '1') " +
                                                             "and status = ''";
                                    cmd_sqlite.ExecuteNonQuery();

                                    // เปลี่ยนค่าตัวเลข
                                    cmd_sqlite.CommandText = "SELECT count(id) from Item_Temp_Excel where status in('บาร์โค้ดซ้ำกัน','บาร์โค้ดซ้ำกับสินค้าในระบบ','กลุ่มย่อยซ้ำกันแต่ละกลุ่มหลัก','กลุ่มย่อยซ้ำกับในระบบแต่ละกลุ่มหลัก')";
                                    using (var reader = cmd_sqlite.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            // อ่านค่าจากคอลัมน์แรก (ดัชนี 0) มาใส่ใน Source
                                            label_item_data_error.Text = (Convert.ToInt32(label_item_data_error.Text.Replace(",", "")) + Convert.ToInt32(reader[0].ToString())).ToString("#,##0");
                                        }
                                    }

                                    // เริ่มเพิ่มสินค้า
                                    cmd_sqlite.CommandText = "SELECT  group_main, group_sub,  small_barcode,name, small_unit, small_price, small_cost_last,small_qty FROM Item_Temp_Excel WHERE status = '';";
                                    dr = cmd_sqlite.ExecuteReader();
                                    System.Data.DataTable dt = new System.Data.DataTable();
                                    dt.Load(dr);

                                    if (dt.Rows.Count > 0)
                                    {

                                        System.Data.DataTable dt_group;
                                        SQLiteDataReader group;

                                        // panel_load.Width = 0;
                                        string group_main, group_sub, small_cost_last, small_qty;

                                        List<string> list_group_main = new List<string>();
                                        List<string> list_group_sub = new List<string>();

                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {

                                            if (dt.Rows[i]["group_main"].ToString() == "" && dt.Rows[i]["group_sub"].ToString() == "")
                                            {
                                                group_main = Class_Parameter.Group_Main;
                                                group_sub = Class_Parameter.Group_Sub;
                                            }
                                            else
                                            {
                                                group_main = dt.Rows[i]["group_main"].ToString()!;
                                                group_sub = dt.Rows[i]["group_sub"].ToString()!;
                                                // ถ้ามีแต่ กลุ่มหลัก ไม่ใช่ชื่อ กลุ่มหลัก หรือ กลุ่มย่อยไม่ใช่ชื่อ กลุ่มย่อย
                                                if (group_main != Class_Parameter.Group_Main ||
                                                   group_sub != Class_Parameter.Group_Sub)
                                                {

                                                    // ถ้าไม่ใช่กลุ่มใหม่ที่เพิ่มไปแล้ว
                                                    if (!list_group_main.Contains(group_main) || !list_group_sub.Contains(group_sub))
                                                    {
                                                        // ตรวจสอบกลุ่ม 

                                                        cmd_sqlite.CommandText = "SELECT 1 from Item_Group ig where ig.status = '1' " +
                                                                                 "and ig.group_main = '" + group_main + "' " +
                                                                                 "and ig.group_sub = '" + group_sub + "'";
                                                        group = cmd_sqlite.ExecuteReader();
                                                        dt_group = new System.Data.DataTable();
                                                        dt_group.Load(group);
                                                        // ถ้าไม่มีกลุ่ม จะต้องสร้างกลุ่ม
                                                        if (dt_group.Rows.Count == 0)
                                                        {
                                                            list_group_main.Add(group_main);
                                                            list_group_main.Add(group_sub);

                                                            cmd_sqlite.CommandText = "INSERT INTO Item_Group(created_by,created_date,updated_by,updated_date,group_main,group_sub,status) " +
                                                                      "VALUES('" + Class_Parameter.User_Login + "',datetime('now', 'localtime'),'',''," +
                                                                      "'" + group_main + "','" + group_sub + "',1)";
                                                            cmd_sqlite.ExecuteNonQuery();
                                                        }
                                                    }

                                                }



                                            }


                                            if (dt.Rows[i]["small_cost_last"].ToString() != "")
                                            {
                                                small_cost_last = Convert.ToDouble(dt.Rows[i]["small_cost_last"]).ToString("0.##");
                                            }
                                            else
                                            {
                                                small_cost_last = "0";
                                            }
                                            if (dt.Rows[i]["small_qty"].ToString() != "")
                                            {
                                                small_qty = Convert.ToDouble(dt.Rows[i]["small_qty"]).ToString("0.##");
                                            }
                                            else
                                            {
                                                small_qty = "0";
                                            }



                                            Class_Item_Detail.Created(group_main,
                                                                      group_sub,
                                                                      dt.Rows[i]["name"].ToString()!,

                                                                      dt.Rows[i]["small_barcode"].ToString()!,
                                                                      dt.Rows[i]["small_unit"].ToString()!,
                                                                      Convert.ToDouble(dt.Rows[i]["small_price"]).ToString("0.##"),
                                                                      small_cost_last,
                                                                      small_cost_last,
                                                                      small_qty,

                                                                      "",
                                                                      "",
                                                                      "0",
                                                                      "0",
                                                                      "0",
                                                                      "0",
                                                                      "0",

                                                                      "",
                                                                      "",
                                                                      "0",
                                                                      "0",
                                                                      "0",
                                                                      "0",
                                                                      "0",

                                                                      false,
                                                                      true,
                                                                      false,
                                                                      true,
                                                                      true,
                                                                      true
                                                                      );

                                            // เพิ่มค่าจำนวนโหลด
                                            label_item_load_complete.Text = (i + 1).ToString("#,##0");
                                            label_item_all.Text = (Convert.ToInt32(label_item_all.Text.Replace(",", "")) + 1).ToString("#,##0");

                                            panel_load.Width = ((i + 1) * panel_back.Width / 2 / dt.Rows.Count) + (panel_back.Width / 2);

                                            loading(i);
                                        }
                                    }

                                    // ถ้ามี error จะให้โหลด
                                    if (label_item_data_error.Text != "0")
                                    {
                                        status_upload = false;
                                    }


                                }
                            }
                        }
                        else
                        {
                            status_upload =false;
                            status_file = false;
                        }
                    }
                }
                finally
                {
                    // ปิดแบบนุ่มนวลก่อน
                    try { app.Quit(); } catch { }

                    // สั่งจัดการขั้นเด็ดขาดดึง Process เจาะจงตัวนี้มาสั่งปิดทันที [2]
                    if (excelProcessId != 0)
                    {
                        try
                        {
                            Process excelProcess = Process.GetProcessById((int)excelProcessId);
                            if (excelProcess != null && !excelProcess.HasExited)
                            {
                                excelProcess.Kill(); // ตัดจบกระบวนการทันที ไม่เหลือค้างแน่นอน [2]
                            }
                        }
                        catch { /* หากกระบวนการปิดไปแล้ว จะข้ามส่วนนี้อัตโนมัติ */ }
                    }
                }
            }
            catch (Exception ex)
            {
                Class_Parameter.runbackground = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loading(int r)
        {
            try
            {
                if (r % 5 == 0)
                {
                    if (button_upload.Text == "กำลังอัพโหลด      ")
                    {
                        button_upload.Text = "กำลังอัพโหลด .    ";
                    }
                    else if (button_upload.Text == "กำลังอัพโหลด .    ")
                    {
                        button_upload.Text = "กำลังอัพโหลด ..   ";
                    }
                    else if (button_upload.Text == "กำลังอัพโหลด ..   ")
                    {
                        button_upload.Text = "กำลังอัพโหลด ...  ";
                    }
                    else if (button_upload.Text == "กำลังอัพโหลด ...  ")
                    {
                        button_upload.Text = "กำลังอัพโหลด .... ";
                    }
                    else if (button_upload.Text == "กำลังอัพโหลด .... ")
                    {
                        button_upload.Text = "กำลังอัพโหลด .....";
                    }
                    else
                    {
                        button_upload.Text = "กำลังอัพโหลด      ";
                    }
                }

            }
            catch
            {

            }
        }
        private void backgroundWorker_import_excel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Class_Parameter.runbackground = false;

                panel_load.Width = 0;

                button_upload.Text = "อัพโหลดเพิ่มสินค้า";

                button_download_all_item.Enabled = true;

                button_upload.Enabled = true;

                button_load_template.Enabled = true;

                button_load_error.Enabled = true;

                if (status_upload)
                {
                    MessageBox.Show("อัพโหลดเพิ่มสินค้าเรียบร้อย " + label_item_load_complete.Text + " รายการ", "เรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if(status_file)
                    {
                        // แสดงปุ่มกด โหลด error
                        pictureBox_load_error.Visible = true;
                        button_load_error.Visible = true;

                        MessageBox.Show("ข้อมูลสินค้าทั้งหมด " + label_item_load.Text + " รายการ" + Environment.NewLine +
                            "อัพโหลดเพิ่มสินค้าเรียบร้อย " + label_item_load_complete.Text + " รายการ" + Environment.NewLine +
                            "ข้อมูลเพิ่มสินค้าไม่ถูกต้อง " + label_item_data_error.Text + " รายการ" + Environment.NewLine
                            + "ตรวจสอบข้อมูลได้ที่ปุ่ม ข้อมูลไม่ถูกต้อง", "เรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("ไฟล์ข้อมูลไม่ถูกต้อง !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }


            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        private void button_load_template_Click(object sender, EventArgs e)
        {
            try
            {
                panel_load.Focus();
                using (SaveFileDialog saveFileDialoge = new SaveFileDialog())
                {
                    saveFileDialoge.FileName = "รูปแบบไฟล์เพิ่มสินค้า_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
                    saveFileDialoge.DefaultExt = ".Xlsx";
                    saveFileDialoge.Filter = "Xlsx|*.Xlsx";
                    saveFileDialoge.Title = "บันทึกรูปแบบไฟล์เพิ่มสินค้า";


                    if (saveFileDialoge.ShowDialog(this) == DialogResult.OK)
                    {

                        path_load = saveFileDialoge.FileName;

                        button_download_all_item.Enabled = false;

                        button_upload.Enabled = false;

                        button_load_template.Visible = false;

                        button_load_error.Enabled = false;

                        Class_Parameter.runbackground = true;

                        backgroundWorker_export_excel.RunWorkerAsync();


                    }
                }
            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        private void backgroundWorker_export_excel_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                try
                {

                    // 2. ประกาศตัวแปร COM Objects
                    Excel.Application App = new Excel.Application();
                    Excel.Workbooks workbooks = App.Workbooks;
                    Excel.Workbook workbook = workbooks.Add(Type.Missing);
                    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                    uint excelProcessId = 0;
                    GetWindowThreadProcessId((IntPtr)App.Hwnd, out excelProcessId);

                    try
                    {
                        App.Visible = false; // ซ่อนหน้าต่าง Excel ไว้เบื้องหลังขณะทำงาน
                        worksheet.Name = "สินค้า";

                        worksheet.Columns.NumberFormat = "@";

                        worksheet.Columns.ColumnWidth = 20;
                        worksheet.Columns[1].ColumnWidth = 30;
                        worksheet.Columns[2].ColumnWidth = 30;

                        worksheet.Rows[1].Font.Size = 14;
                        worksheet.Rows[1].Font.Bold = true;
                        worksheet.Rows[2].Font.Size = 14;
                        worksheet.Rows[2].Font.Bold = true;

                        worksheet.Rows[1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        worksheet.Rows[1].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        worksheet.Rows[2].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        worksheet.Rows[2].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        Excel.Range rangeToMerge1 = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 2]];
                        rangeToMerge1.Merge(Type.Missing);
                        worksheet.Cells[1, 1] = "ถ้าไม่ใส่ข้อมูล ระบบจะใช้ กลุ่มหลัก กลุ่มย่อย";
                        worksheet.Cells[1, 1].Interior.Color = ColorTranslator.ToOle(Color.Lime);

                        worksheet.Cells[2, 1] = " กลุ่มหลัก ";
                        worksheet.Cells[2, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);

                        worksheet.Cells[2, 2] = " กลุ่มย่อย ";
                        worksheet.Cells[2, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);

                        Excel.Range rangeToMerge2 = worksheet.Range[worksheet.Cells[1, 3], worksheet.Cells[2, 3]];
                        rangeToMerge2.Merge(Type.Missing);
                        worksheet.Cells[1, 3] = " บาร์โค้ด ";
                        worksheet.Cells[1, 3].Interior.Color = ColorTranslator.ToOle(Color.Red);

                        Excel.Range rangeToMerge3 = worksheet.Range[worksheet.Cells[1, 4], worksheet.Cells[2, 4]];
                        rangeToMerge3.Merge(Type.Missing);
                        worksheet.Cells[1, 4] = " ชื่อสินค้า ";
                        worksheet.Cells[1, 4].Interior.Color = ColorTranslator.ToOle(Color.Red);

                        Excel.Range rangeToMerge4 = worksheet.Range[worksheet.Cells[1, 5], worksheet.Cells[2, 5]];
                        rangeToMerge4.Merge(Type.Missing);
                        worksheet.Cells[1, 5] = " หน่วย ";
                        worksheet.Cells[1, 5].Interior.Color = ColorTranslator.ToOle(Color.Red);

                        Excel.Range rangeToMerge5 = worksheet.Range[worksheet.Cells[1, 6], worksheet.Cells[2, 6]];
                        rangeToMerge5.Merge(Type.Missing);
                        worksheet.Cells[1, 6] = " ราคาต่อหน่วย ";
                        worksheet.Cells[1, 6].Interior.Color = ColorTranslator.ToOle(Color.Red);
                        worksheet.Columns[6].NumberFormat = "General";

                        Excel.Range rangeToMerge6 = worksheet.Range[worksheet.Cells[1, 7], worksheet.Cells[1, 8]];
                        rangeToMerge6.Merge(Type.Missing);
                        worksheet.Cells[1, 7] = "ถ้าไม่ใส่ข้อมูล ระบบจะใช้ค่า 0";
                        worksheet.Cells[1, 7].Interior.Color = ColorTranslator.ToOle(Color.Lime);

                        worksheet.Cells[2, 7] = " ต้นทุนต่อหน่วย ";
                        worksheet.Cells[2, 7].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        worksheet.Columns[7].NumberFormat = "General";

                        worksheet.Cells[2, 8] = " จำนวน ";
                        worksheet.Cells[2, 8].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                        worksheet.Columns[8].NumberFormat = "General";



                        worksheet.Activate();
                        worksheet.Application.ActiveWindow.SplitRow = 2;
                        worksheet.Application.ActiveWindow.FreezePanes = true;

                        // สร้างเส้น                
                        Excel.Range rangeAllBorders = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[2, 8]];
                        rangeAllBorders.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        rangeAllBorders.Borders.Weight = Excel.XlBorderWeight.xlThin;
                        rangeAllBorders.Borders.Color = ColorTranslator.ToOle(Color.Black);


                        // 4. บันทึกไฟล์ไปยัง Path ที่ผู้ใช้เลือกจาก Dialog
                        // ลบไฟล์เก่าทิ้งก่อน (ถ้ามีชื่อซ้ำและต้องการเซฟทับโดยไม่ให้ Excel ถามแจ้งเตือน)
                        App.DisplayAlerts = false;

                        workbook.SaveAs(path_load);


                    }
                    finally
                    {
                        // ปิดแบบนุ่มนวลก่อน
                        try { App.Quit(); } catch { }

                        // สั่งจัดการขั้นเด็ดขาดดึง Process เจาะจงตัวนี้มาสั่งปิดทันที [2]
                        if (excelProcessId != 0)
                        {
                            try
                            {
                                Process excelProcess = Process.GetProcessById((int)excelProcessId);
                                if (excelProcess != null && !excelProcess.HasExited)
                                {
                                    excelProcess.Kill(); // ตัดจบกระบวนการทันที ไม่เหลือค้างแน่นอน [2]
                                }
                            }
                            catch { /* หากกระบวนการปิดไปแล้ว จะข้ามส่วนนี้อัตโนมัติ */ }
                        }
                    }

                }
                catch { }
            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        private void backgroundWorker_export_excel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Class_Parameter.runbackground = false;

                button_download_all_item.Enabled = true;

                button_upload.Enabled = true;

                button_load_template.Visible = true;

                button_load_error.Enabled = true;

                MessageBox.Show(path_load, "ดาวน์โหลดรูปแบบไฟล์ เรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }


        private void button_load_error_Click(object sender, EventArgs e)
        {
            try
            {
                panel_load.Focus();
                using (SaveFileDialog saveFileDialoge = new SaveFileDialog())
                {
                    saveFileDialoge.FileName = "ข้อมูลสินค้าไม่ถูกต้อง_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + "_สามารถแก้ไขและอัพโหลดสินค้าได้อีกครั้ง";
                    saveFileDialoge.DefaultExt = ".Xlsx";
                    saveFileDialoge.Filter = "Xlsx|*.Xlsx";
                    saveFileDialoge.Title = "บันทึกไฟล์";


                    if (saveFileDialoge.ShowDialog(this) == DialogResult.OK)
                    {
                        path_load = saveFileDialoge.FileName;


                        button_download_all_item.Enabled = false;

                        button_upload.Enabled = false;

                        button_load_template.Enabled = false;

                        button_load_error.Visible = false;

                        Class_Parameter.runbackground = true;

                        backgroundWorker_export_excel_error.RunWorkerAsync();
                    }
                }
            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        private void backgroundWorker_export_excel_error_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {


                // 2. ประกาศตัวแปร COM Objects
                Excel.Application App = new Excel.Application();
                Excel.Workbooks workbooks = App.Workbooks;
                Excel.Workbook workbook = workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                uint excelProcessId = 0;
                GetWindowThreadProcessId((IntPtr)App.Hwnd, out excelProcessId);
                try
                {

                    worksheet.Name = "สินค้า";



                    worksheet.Columns.ColumnWidth = 20;
                    worksheet.Columns[1].ColumnWidth = 30;
                    worksheet.Columns[2].ColumnWidth = 30;

                    worksheet.Rows[1].Font.Size = 14;
                    worksheet.Rows[1].Font.Bold = true;
                    worksheet.Rows[2].Font.Size = 14;
                    worksheet.Rows[2].Font.Bold = true;

                    worksheet.Rows[1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Rows[1].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Rows[2].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Rows[2].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    Excel.Range rangeToMerge1 = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 2]];
                    rangeToMerge1.Merge(Type.Missing);
                    worksheet.Cells[1, 1] = "ถ้าไม่ใส่ข้อมูล ระบบจะใช้ กลุ่มหลัก กลุ่มย่อย";
                    worksheet.Cells[1, 1].Interior.Color = ColorTranslator.ToOle(Color.Lime);

                    worksheet.Cells[2, 1] = " กลุ่มหลัก ";
                    worksheet.Cells[2, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[1].NumberFormat = "@";

                    worksheet.Cells[2, 2] = " กลุ่มย่อย ";
                    worksheet.Cells[2, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[2].NumberFormat = "@";

                    Excel.Range rangeToMerge2 = worksheet.Range[worksheet.Cells[1, 3], worksheet.Cells[2, 3]];
                    rangeToMerge2.Merge(Type.Missing);
                    worksheet.Cells[1, 3] = " บาร์โค้ด ";
                    worksheet.Cells[1, 3].Interior.Color = ColorTranslator.ToOle(Color.Red);
                    worksheet.Columns[3].NumberFormat = "@";

                    Excel.Range rangeToMerge3 = worksheet.Range[worksheet.Cells[1, 4], worksheet.Cells[2, 4]];
                    rangeToMerge3.Merge(Type.Missing);
                    worksheet.Cells[1, 4] = " ชื่อสินค้า ";
                    worksheet.Cells[1, 4].Interior.Color = ColorTranslator.ToOle(Color.Red);
                    worksheet.Columns[4].NumberFormat = "@";

                    Excel.Range rangeToMerge4 = worksheet.Range[worksheet.Cells[1, 5], worksheet.Cells[2, 5]];
                    rangeToMerge4.Merge(Type.Missing);
                    worksheet.Cells[1, 5] = " หน่วย ";
                    worksheet.Cells[1, 5].Interior.Color = ColorTranslator.ToOle(Color.Red);
                    worksheet.Columns[5].NumberFormat = "@";

                    Excel.Range rangeToMerge5 = worksheet.Range[worksheet.Cells[1, 6], worksheet.Cells[2, 6]];
                    rangeToMerge5.Merge(Type.Missing);
                    worksheet.Cells[1, 6] = " ราคาต่อหน่วย ";
                    worksheet.Cells[1, 6].Interior.Color = ColorTranslator.ToOle(Color.Red);
                    worksheet.Columns[6].NumberFormat = "General";

                    Excel.Range rangeToMerge6 = worksheet.Range[worksheet.Cells[1, 7], worksheet.Cells[1, 8]];
                    rangeToMerge6.Merge(Type.Missing);
                    worksheet.Cells[1, 7] = "ถ้าไม่ใส่ข้อมูล ระบบจะใช้ค่า 0";
                    worksheet.Cells[1, 7].Interior.Color = ColorTranslator.ToOle(Color.Lime);

                    worksheet.Cells[2, 7] = " ต้นทุนต่อหน่วย ";
                    worksheet.Cells[2, 7].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[7].NumberFormat = "General";

                    worksheet.Cells[2, 8] = " จำนวน ";
                    worksheet.Cells[2, 8].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[8].NumberFormat = "General";

                    worksheet.Activate();
                    worksheet.Application.ActiveWindow.SplitRow = 2;
                    worksheet.Application.ActiveWindow.FreezePanes = true;

                    // สร้างเส้น                
                    Excel.Range rangeAllBorders = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[2, 8]];
                    rangeAllBorders.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    rangeAllBorders.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    rangeAllBorders.Borders.Color = ColorTranslator.ToOle(Color.Black);

                    // เริ่มใส่ข้อมูลผิดพลาด
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            cmd_sqlite.CommandText = "SELECT id,group_main,group_sub,small_barcode,name,small_unit,small_price,small_cost_last,small_qty,status " +
                                                     "FROM Item_Temp_Excel WHERE status <> ''";
                            dr = cmd_sqlite.ExecuteReader();
                            dt = new System.Data.DataTable();
                            dt.Load(dr);
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    worksheet.Cells[i + 3, 1] = dt.Rows[i]["group_main"].ToString();
                                    worksheet.Cells[i + 3, 2] = dt.Rows[i]["group_sub"].ToString();
                                    worksheet.Cells[i + 3, 3] = dt.Rows[i]["small_barcode"].ToString();
                                    worksheet.Cells[i + 3, 4] = dt.Rows[i]["name"].ToString();
                                    worksheet.Cells[i + 3, 5] = dt.Rows[i]["small_unit"].ToString();
                                    worksheet.Cells[i + 3, 6] = dt.Rows[i]["small_price"].ToString();
                                    worksheet.Cells[i + 3, 7] = dt.Rows[i]["small_cost_last"].ToString();
                                    worksheet.Cells[i + 3, 8] = dt.Rows[i]["small_qty"].ToString();
                                    worksheet.Cells[i + 3, 9] = dt.Rows[i]["status"].ToString();

                                    panel_load.Width = ((i + 1) * panel_back.Width / dt.Rows.Count);

                                }
                            }
                        }
                    }

                    // 4. บันทึกไฟล์ไปยัง Path ที่ผู้ใช้เลือกจาก Dialog
                    // ลบไฟล์เก่าทิ้งก่อน (ถ้ามีชื่อซ้ำและต้องการเซฟทับโดยไม่ให้ Excel ถามแจ้งเตือน)
                    App.DisplayAlerts = false;
                    App.Visible = false; // ซ่อนหน้าต่าง Excel ไว้เบื้องหลังขณะทำงาน

                    workbook.SaveAs(path_load);

                }
                finally
                {

                    // ปิดแบบนุ่มนวลก่อน
                    try { App.Quit(); } catch { }

                    // สั่งจัดการขั้นเด็ดขาดดึง Process เจาะจงตัวนี้มาสั่งปิดทันที [2]
                    if (excelProcessId != 0)
                    {
                        try
                        {
                            Process excelProcess = Process.GetProcessById((int)excelProcessId);
                            if (excelProcess != null && !excelProcess.HasExited)
                            {
                                excelProcess.Kill(); // ตัดจบกระบวนการทันที ไม่เหลือค้างแน่นอน [2]
                            }
                        }
                        catch { /* หากกระบวนการปิดไปแล้ว จะข้ามส่วนนี้อัตโนมัติ */}
                    }
                }



            }
            catch
            {
                Class_Parameter.runbackground = false;
            }

        }

        private void backgroundWorker_export_excel_error_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Class_Parameter.runbackground = false;

                MessageBox.Show(path_load, "ดาวน์โหลดไฟล์ เรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Information);

                panel_load.Width = 0;

                button_download_all_item.Enabled = true;

                button_upload.Enabled = true;

                button_load_template.Enabled = true;

                button_load_error.Visible = true;

            }
            catch
            {
                Class_Parameter.runbackground = false;
            }

        }



        private void button_upload_all_item_MouseEnter(object sender, EventArgs e)
        {
            button_download_all_item.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Excel, new Size(80, 80));
        }

        private void button_upload_all_item_MouseLeave(object sender, EventArgs e)
        {
            button_download_all_item.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Excel, new Size(60, 60));
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                button.Font = new System.Drawing.Font("Segoe UI", button.Font.Size+2,button.Font.Style);
            }
            catch
            {

            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                button.Font = new System.Drawing.Font("Segoe UI", button.Font.Size - 2, button.Font.Style);
            }
            catch
            {

            }
        }
    }
}
