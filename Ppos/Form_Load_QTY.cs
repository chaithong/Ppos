using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Ppos
{
    public partial class Form_Load_QTY : Form
    {
        string path_load;
        bool status_upload , status_file;
        DataTable dt;
        SQLiteDataReader dr;
        public Form_Load_QTY()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;
                button_download_all_item.Location = new System.Drawing.Point((panel_back.Width / 2) - (button_download_all_item.Width / 2), 10);

                pictureBox_load_all_item.Location = button_download_all_item.Location;

                customGroupBox_all_item.Location = new System.Drawing.Point(pictureBox_load_all_item.Location.X, pictureBox_load_all_item.Location.Y + pictureBox_load_all_item.Height + 10);

                customGroupBox_add_item.Location = new System.Drawing.Point(pictureBox_load_all_item.Location.X, customGroupBox_all_item.Location.Y + customGroupBox_all_item.Height + 10);


                button_download_all_item.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Excel, new Size(60, 60));


                button_upload.Image = Class_Image.resizeImage(Ppos.Properties.Resources.qty, new Size(70, 70));

                button_template.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Excel, new Size(30, 30));

                button_error.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Excel, new Size(30, 30));

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
            catch
            {
                this.Close();
            }


        }
        // สรรหาฟังก์ชันจากภายนอกมาช่วยดึง Process ID ของหน้าต่าง Excel
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        /// <summary>
        /// ปุ่มรูปแบบ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_template_Click(object sender, EventArgs e)
        {
            try
            {
                panel_load.Focus();
                if (Convert.ToUInt32(label_item_all.Text.Replace(",", "")) > 0)
                {
                    using (SaveFileDialog saveFileDialoge = new SaveFileDialog())
                    {
                        saveFileDialoge.FileName = "ปรับจำนวน_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
                        saveFileDialoge.DefaultExt = ".Xlsx";
                        saveFileDialoge.Filter = "Xlsx|*.Xlsx";
                        saveFileDialoge.Title = "บันทึกรูปแบบปรับจำนวน";


                        if (saveFileDialoge.ShowDialog(this) == DialogResult.OK)
                        {
                            path_load = saveFileDialoge.FileName;

                            button_download_all_item.Enabled = false;

                            button_upload.Enabled = false;

                            button_template.Enabled = false;

                            button_template.Text = "ดาวน์โหลดรูปแบบ 0%";

                            button_error.Enabled = false;

                            Class_Parameter.runbackground = true;

                            backgroundWorker_template.RunWorkerAsync();
                        }
                    }
                }


            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        private void backgroundWorker_template_DoWork(object sender, DoWorkEventArgs e)
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
                    worksheet.Name = "สินค้าปรับจำนวน";



                    worksheet.Columns.ColumnWidth = 20;
                    worksheet.Columns[1].ColumnWidth = 30;

                    worksheet.Rows[1].Font.Size = 14;
                    worksheet.Rows[1].Font.Bold = true;

                    worksheet.Rows[1].RowHeight = 30;

                    worksheet.Rows[1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Rows[1].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    worksheet.Cells[1, 1] = " กลุ่มหลัก ";
                    worksheet.Cells[1, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[1].NumberFormat = "@";

                    worksheet.Cells[1, 2] = " กลุ่มย่อย ";
                    worksheet.Cells[1, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[2].NumberFormat = "@";

                    worksheet.Cells[1, 3] = " บาร์โค้ด ";
                    worksheet.Cells[1, 3].Interior.Color = ColorTranslator.ToOle(Color.Red);
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

                    worksheet.Cells[1, 7] = " ปรับเพิ่ม ";
                    worksheet.Cells[1, 7].Interior.Color = ColorTranslator.ToOle(Color.Lime);
                    worksheet.Columns[7].NumberFormat = "General";

                    worksheet.Cells[1, 8] = " ปรับลด ";
                    worksheet.Cells[1, 8].Interior.Color = ColorTranslator.ToOle(Color.Lime);
                    worksheet.Columns[8].NumberFormat = "General";

                    worksheet.Cells[1, 9] = " กำหนด ";
                    worksheet.Cells[1, 9].Interior.Color = ColorTranslator.ToOle(Color.Lime);
                    worksheet.Columns[9].NumberFormat = "General";

                    worksheet.Cells[1, 10] = " ต้นทุนต่อหน่วย ";
                    worksheet.Cells[1, 10].Interior.Color = ColorTranslator.ToOle(Color.Lime);
                    worksheet.Columns[10].NumberFormat = "General";

                    worksheet.Activate();
                    worksheet.Application.ActiveWindow.SplitRow = 1;
                    worksheet.Application.ActiveWindow.FreezePanes = true;

                    // สร้างเส้น                
                    Excel.Range rangeAllBorders = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 10]];
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
                                    worksheet.Cells[i + 2, 5] = Convert.ToDouble(dt.Rows[i]["small_qty"]).ToString("0.###");
                                    worksheet.Cells[i + 2, 6] = dt.Rows[i]["small_unit"].ToString();

                                    worksheet.Cells[i + 2, 10] = dt.Rows[i]["small_cost_last"].ToString();

                                    panel_load.Width = (i + 1) * panel_back.Width / dt.Rows.Count;

                                    button_template.Text = "ดาวน์โหลดรูปแบบ " + ((i + 1) * 100 / dt.Rows.Count).ToString("0") + "%";
                                }
                            }
                        }
                    }

                    worksheet.Columns.AutoFit();

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

        private void backgroundWorker_template_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Class_Parameter.runbackground = false;

                MessageBox.Show(path_load, "ดาวน์โหลดรูปแบบปรับจำนวน เรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Information);

                button_download_all_item.Enabled = true;

                button_upload.Enabled = true;

                button_template.Enabled = true;

                button_template.Text = "รูปแบบปรับจำนวน";

                button_error.Enabled = true;

                panel_load.Width = 0;
            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        /// <summary>
        /// // ปุ่มอัพโหลด
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                    button_download_all_item.Enabled = false;

                    button_upload.Text = "กำลังอัพโหลด      ";
                    button_upload.Enabled = false;

                    button_template.Enabled = false;

                    label_item_load.Text = "0";
                    label_item_load_complete.Text = "0";
                    label_item_load_error.Text = "0";

                    Class_Parameter.runbackground = true;
                    backgroundWorker_upload.RunWorkerAsync();
                }
            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        private void backgroundWorker_upload_DoWork(object sender, DoWorkEventArgs e)
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
                    int noofrow = 2;


                    if (rows >= 2) // ถ้ามีข้อมูลรายการสินค้า ไม่รวมหัวข้อ
                    {
                        if (worksheet.Name == "สินค้าปรับจำนวน" &&
                             worksheet.Cells[1, 7].Text.Trim() == "ปรับเพิ่ม" &&
                              worksheet.Cells[1, 8].Text.Trim() == "ปรับลด" &&
                               worksheet.Cells[1, 9].Text.Trim() == "กำหนด"
                             )
                        {
                            using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                            {
                                con_sqlite.Open();
                                using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                {
                                    // ลบข้อมูลสินค้า
                                    cmd_sqlite.CommandText = "DELETE from Item_Temp_Excel_Qty";
                                    cmd_sqlite.ExecuteNonQuery();

                                    string status = "";
                                    // ปรับจำนวนสินค้า
                                    for (int r = noofrow; r <= rows; r++)
                                    {
                                        status = "";
                                        // ถ้ามีจำนวน
                                        if (worksheet.Cells[r, 7].Text.Trim() != "" ||
                                            worksheet.Cells[r, 8].Text.Trim() != "" ||
                                            worksheet.Cells[r, 9].Text.Trim() != "")
                                        {
                                            // ต้องมีต้นทุน
                                            if (worksheet.Cells[r, 10].Text.Trim() != "")
                                            {
                                                // ต้นทุนต้องเป็นตัวเลข
                                                if (double.TryParse(worksheet.Cells[r, 10].Text.Replace(",", "").Trim(), out double cost))
                                                {

                                                    // ต้นทุนต้องไม่ติดลบ
                                                    if (cost >= 0)
                                                    {

                                                        // ต้องมีจำนวนช่องเดียว
                                                        if (
                                                        (worksheet.Cells[r, 7].Text.Replace("'", "").Trim() != "" &&
                                                        worksheet.Cells[r, 8].Text.Replace("'", "").Trim() == "" &&
                                                        worksheet.Cells[r, 9].Text.Replace("'", "").Trim() == "") ||

                                                        (worksheet.Cells[r, 7].Text.Replace("'", "").Trim() == "" &&
                                                        worksheet.Cells[r, 8].Text.Replace("'", "").Trim() != "" &&
                                                        worksheet.Cells[r, 9].Text.Replace("'", "").Trim() == "") ||

                                                        (worksheet.Cells[r, 7].Text.Replace("'", "").Trim() == "" &&
                                                        worksheet.Cells[r, 8].Text.Replace("'", "").Trim() == "" &&
                                                        worksheet.Cells[r, 9].Text.Replace("'", "").Trim() != "")
                                                         )
                                                        {

                                                            // จำนวนต้องเป็นตัวเลข
                                                            if (double.TryParse(worksheet.Cells[r, 7].Text.Replace("'", "").Replace(",", "").Trim() +
                                                                worksheet.Cells[r, 8].Text.Replace("'", "").Replace(",", "").Trim() +
                                                                worksheet.Cells[r, 9].Text.Replace("'", "").Replace(",", "").Trim()
                                                                , out double qty))
                                                            {
                                                                // เพิ่ม 
                                                                if (worksheet.Cells[r, 7].Text.Replace("'", "").Trim() != "")
                                                                {
                                                                    if (qty <= 0)
                                                                    {
                                                                        label_item_load_error.Text = (Convert.ToInt32(label_item_load_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                                        status = "ปรับเพิ่ม ต้องมากกว่า 0";
                                                                    }

                                                                } // ลด
                                                                else if (worksheet.Cells[r, 8].Text.Replace("'", "").Trim() != "")
                                                                {
                                                                    if (qty <= 0)
                                                                    {

                                                                        label_item_load_error.Text = (Convert.ToInt32(label_item_load_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                                        status = "ปรับลด ต้องมากกว่า 0";
                                                                    }
                                                                }
                                                                else // กำหนด
                                                                {
                                                                    if (qty < 0)
                                                                    {
                                                                        label_item_load_error.Text = (Convert.ToInt32(label_item_load_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                                        status = "กำหนดต้องจำนวน 0 ขึ้นไป";
                                                                    }
                                                                }

                                                            }
                                                            else
                                                            {
                                                                label_item_load_error.Text = (Convert.ToInt32(label_item_load_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                                status = "จำนวนต้องเป็นตัวเลข";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            label_item_load_error.Text = (Convert.ToInt32(label_item_load_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                            status = "ปรับจำนวนได้แค่ค่าเดียว";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        label_item_load_error.Text = (Convert.ToInt32(label_item_load_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                        status = "ต้นทุนต่อหน่วยต้องไม่ติดดลบ";
                                                    }
                                                }
                                                else
                                                {
                                                    label_item_load_error.Text = (Convert.ToInt32(label_item_load_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                    status = "ต้นทุนต่อหน่วยต้องเป็นตัวเลข";
                                                }

                                            }
                                            else
                                            {
                                                label_item_load_error.Text = (Convert.ToInt32(label_item_load_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                status = "ต้องมีต้นทุนต่อหน่วย";
                                            }



                                            cmd_sqlite.CommandText = "INSERT INTO Item_Temp_Excel_Qty(group_main,group_sub,barcode,name,qty,unit,inc,dec,cus,cost,status) VALUES";

                                            cmd_sqlite.CommandText += "('" + worksheet.Cells[r, 1].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                             worksheet.Cells[r, 2].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                             worksheet.Cells[r, 3].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                             worksheet.Cells[r, 4].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                             worksheet.Cells[r, 5].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                             worksheet.Cells[r, 6].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                             worksheet.Cells[r, 7].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                             worksheet.Cells[r, 8].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                             worksheet.Cells[r, 9].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                             worksheet.Cells[r, 10].Text.Replace("'", "").Replace(",", "").Trim() + "','" +
                                                                             status + "')";


                                            label_item_load.Text = (Convert.ToInt32(label_item_load.Text.Replace(",", "")) + 1).ToString("#,##0");

                                            cmd_sqlite.ExecuteNonQuery();
                                            loading(r);
                                        }
                                        panel_load.Width = r * panel_back.Width / 2 / rows;
                                    }

                                    // หาบาร์ไม่มีในระบบ
                                    cmd_sqlite.CommandText = "UPDATE Item_Temp_Excel_Qty set status = 'บาร์โค้ดไม่มีในระบบ' " +
                                                             "where barcode not in( " +
                                                             "SELECT " +
                                                             "small_barcode as barcode " +
                                                             "from Item " +
                                                             "where status = 1 " +
                                                             "union all " +
                                                             "SELECT " +
                                                             "medium_barcode " +
                                                             "from Item " +
                                                             "where status = 1 " +
                                                             "and medium_barcode <> '' " +
                                                             "union all " +
                                                             "SELECT " +
                                                             "large_barcode " +
                                                             "from Item " +
                                                             "where status = 1 " +
                                                             "and large_barcode <> ''" +
                                                             ") " +
                                                             "and status = ''";
                                    cmd_sqlite.ExecuteNonQuery();


                                    // หาบาร์ซ้ำ ใน temp
                                    cmd_sqlite.CommandText = "UPDATE Item_Temp_Excel_Qty set status = 'บาร์โค้ดซ้ำกัน' " +
                                                             "where barcode in( " +
                                                             "SELECT barcode from Item_Temp_Excel_Qty where status = '' group by barcode HAVING count(barcode)>1) " +
                                                             "and status = ''";
                                    cmd_sqlite.ExecuteNonQuery();

                                    // ลดมากกว่าคงเหลือ
                                    cmd_sqlite.CommandText = @"UPDATE Item_Temp_Excel_Qty 
                                                               set status = 'ลดจำนวนมากกว่าคงเหลือ'
                                                               where barcode in(SELECT iteq.barcode 
                                                               from Item_Temp_Excel_Qty iteq 
                                                               join item i on i.small_barcode = iteq.barcode 
                                                               and i.medium_barcode = '' and i.status = 1                                                            
                                                               where iteq.dec <> ''
                                                               and cast(iteq.dec as double) > i.small_qty )
                                                               and status = '';";
                                    cmd_sqlite.ExecuteNonQuery();

                                    // สินค้าหน่วยกลางใหญ่ รวมแล้วลดมากกว่าคงเหลือ
                                    cmd_sqlite.CommandText = @"UPDATE Item_Temp_Excel_Qty 
set status = 'ลดจำนวนมากกว่าคงเหลือ หน่วยเล็ก'
where barcode in(SELECT i.small_barcode from item i
join(SELECT i.code ,sum(iteq.dec*i.qty) as sd
from Item_Temp_Excel_Qty iteq 
join (SELECT code,small_barcode as barcode,1 as qty
from item where status = 1 and medium_barcode <> '' union all
SELECT code,medium_barcode,medium_qty_small
from item where status  = 1 and medium_barcode <> '' union all
SELECT code,large_barcode,large_qty_small
from item where status  = 1 and large_barcode <> ''
group by small_barcode,small_qty 
) i on i.barcode = iteq.barcode 
where iteq.dec <> '' group by i.code
) sums on sums.code = i.code
where i.medium_barcode <> '' and sums.sd > i.small_qty and i.status = 1)
and status = '';";
                                    cmd_sqlite.ExecuteNonQuery();
                                    cmd_sqlite.CommandText = @"UPDATE Item_Temp_Excel_Qty 
set status = 'ลดจำนวนมากกว่าคงเหลือ หน่วยเล็ก'
where barcode in(SELECT i.medium_barcode from item i
join(SELECT i.code ,sum(iteq.dec*i.qty) as sd
from Item_Temp_Excel_Qty iteq 
join (SELECT code,small_barcode as barcode,1 as qty
from item where status = 1 and medium_barcode <> '' union all
SELECT code,medium_barcode,medium_qty_small
from item where status  = 1 and medium_barcode <> '' union all
SELECT code,large_barcode,large_qty_small
from item where status  = 1 and large_barcode <> ''
group by small_barcode,small_qty 
) i on i.barcode = iteq.barcode 
where iteq.dec <> '' group by i.code
) sums on sums.code = i.code
where i.medium_barcode <> '' and sums.sd > i.small_qty and i.status = 1)
and status = '';";
                                    cmd_sqlite.ExecuteNonQuery();
                                    cmd_sqlite.CommandText = @"UPDATE Item_Temp_Excel_Qty 
set status = 'ลดจำนวนมากกว่าคงเหลือ หน่วยเล็ก'
where barcode in(SELECT i.large_barcode from item i
join(SELECT i.code ,sum(iteq.dec*i.qty) as sd
from Item_Temp_Excel_Qty iteq 
join (SELECT code,small_barcode as barcode,1 as qty
from item where status = 1 and medium_barcode <> '' union all
SELECT code,medium_barcode,medium_qty_small
from item where status  = 1 and medium_barcode <> '' union all
SELECT code,large_barcode,large_qty_small
from item where status  = 1 and large_barcode <> ''
group by small_barcode,small_qty 
) i on i.barcode = iteq.barcode 
where iteq.dec <> '' group by i.code
) sums on sums.code = i.code
where i.medium_barcode <> '' and sums.sd > i.small_qty and i.status = 1)
and status = '';";
                                    cmd_sqlite.ExecuteNonQuery();

                                    // กำหนดสินค้าหน่วย กลาง ใหญ่ ซ้ำ
                                    cmd_sqlite.CommandText = @"UPDATE Item_Temp_Excel_Qty 
set status = 'กำหนดจำนวนสินค้าเดียวกัน'
where barcode in(
SELECT iteq.barcode 
from Item_Temp_Excel_Qty iteq 
join(SELECT small_barcode as barcode
from item where status = 1 and medium_barcode <> '' union all
SELECT medium_barcode
from item where status  = 1 and medium_barcode <> '' union all
SELECT large_barcode
from item where status  = 1 and large_barcode <> ''
group by small_barcode) i on i.barcode = iteq.barcode 
where iteq.cus <> '') and status = '';";
                                    cmd_sqlite.ExecuteNonQuery();
                                    // เปลี่ยนค่าตัวเลข
                                    cmd_sqlite.CommandText = "SELECT count(id) from Item_Temp_Excel_Qty where status in('บาร์โค้ดไม่มีในระบบ','บาร์โค้ดซ้ำกัน','ลดจำนวนมากกว่าคงเหลือ','ลดจำนวนมากกว่าคงเหลือ หน่วยเล็ก','กำหนดจำนวนสินค้าเดียวกัน')";
                                    using (var reader = cmd_sqlite.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            // อ่านค่าจากคอลัมน์แรก (ดัชนี 0) มาใส่ใน Source
                                            label_item_load_error.Text = (Convert.ToInt32(label_item_load_error.Text.Replace(",", "")) + Convert.ToInt32(reader[0].ToString())).ToString("#,##0");
                                        }
                                    }
                                    // เริ่มปรับจำนวน
                                    cmd_sqlite.CommandText = @"SELECT ite.barcode as barcode,
                                                                ite.inc,ite.dec,ite.cus,
                                                                i.sizes as sizes,i.small_cost_last as cost
                                                                from Item_Temp_Excel_Qty ite 
                                                                join (SELECT small_barcode, 1 as sizes ,small_cost_last
                                                                from item where status = 1 union all
                                                                SELECT medium_barcode ,medium_qty_small,medium_cost_last
                                                                from item where status  = 1 and medium_barcode <> '' union all
                                                                SELECT large_barcode,large_qty_small,large_cost_last
                                                                from item where status  = 1 and large_barcode <> ''
                                                                group by small_barcode ,small_cost_avg
                                                                ) i on i.small_barcode = ite.barcode 
                                                                where ite.status = '';";
                                    var er = cmd_sqlite.ExecuteReader();
                                    System.Data.DataTable dt = new System.Data.DataTable();
                                    dt.Load(er);

                                    if (dt.Rows.Count > 0)
                                    {


                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            // เพิ่ม
                                            if (dt.Rows[i]["inc"].ToString() != "")
                                            {
                                                if (Class_Item_Adjust.Increase(
                                                    dt.Rows[i]["barcode"].ToString()!,
                                                    dt.Rows[i]["sizes"].ToString()!,
                                                    dt.Rows[i]["inc"].ToString()!,
                                                    dt.Rows[i]["cost"].ToString()!,
                                                    Class_Parameter.Adjust_Increase,
                                                    "โหลด Excel"
                                                    ) is null)
                                                {
                                                    cmd_sqlite.CommandText = "UPDATE Item_Temp_Excel_Qty set status = 'ปรับจำนวนผิดพลาด !!' " +
                                                            "where barcode = '" + dt.Rows[i]["barcode"].ToString()! + "'";
                                                    cmd_sqlite.ExecuteNonQuery();
                                                    label_item_load_error.Text = (Convert.ToInt32(label_item_load_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                }
                                                else
                                                {
                                                    // เพิ่มค่าจำนวนโหลด
                                                    label_item_load_complete.Text = (Convert.ToInt32(label_item_load_complete.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                }
                                            }
                                            // ลด
                                            else if (dt.Rows[i]["dec"].ToString() != "")
                                            {
                                                if (Class_Item_Adjust.Decrease(
                                                   dt.Rows[i]["barcode"].ToString()!,
                                                   dt.Rows[i]["sizes"].ToString()!,
                                                   dt.Rows[i]["dec"].ToString()!,
                                                   dt.Rows[i]["cost"].ToString()!,
                                                   Class_Parameter.Adjust_Decrease,
                                                   "โหลด Excel"
                                                   ) is null)
                                                {
                                                    cmd_sqlite.CommandText = "UPDATE Item_Temp_Excel_Qty set status = 'ปรับจำนวนผิดพลาด !!' " +
                                                            "where barcode = '" + dt.Rows[i]["barcode"].ToString()! + "'";
                                                    cmd_sqlite.ExecuteNonQuery();
                                                    label_item_load_error.Text = (Convert.ToInt32(label_item_load_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                }
                                                else
                                                {
                                                    // เพิ่มค่าจำนวนโหลด
                                                    label_item_load_complete.Text = (Convert.ToInt32(label_item_load_complete.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                }
                                            }
                                            // กำหนด
                                            else
                                            {
                                                if (Class_Item_Adjust.Custom(
                                                   dt.Rows[i]["barcode"].ToString()!,
                                                   dt.Rows[i]["sizes"].ToString()!,
                                                   dt.Rows[i]["cus"].ToString()!,
                                                   dt.Rows[i]["cost"].ToString()!
                                                   ) is null)
                                                {
                                                    cmd_sqlite.CommandText = "UPDATE Item_Temp_Excel_Qty set status = 'ปรับจำนวนผิดพลาด !!' " +
                                                            "where barcode = '" + dt.Rows[i]["barcode"].ToString()! + "'";
                                                    cmd_sqlite.ExecuteNonQuery();
                                                    label_item_load_error.Text = (Convert.ToInt32(label_item_load_error.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                }
                                                else
                                                {
                                                    // เพิ่มค่าจำนวนโหลด
                                                    label_item_load_complete.Text = (Convert.ToInt32(label_item_load_complete.Text.Replace(",", "")) + 1).ToString("#,##0");
                                                }
                                            }



                                            panel_load.Width = ((i + 1) * panel_back.Width / 2 / dt.Rows.Count) + (panel_back.Width / 2);

                                            loading(i);
                                        }
                                    }


                                    // ถ้ามี error จะให้โหลด
                                    if (label_item_load_error.Text != "0")
                                    {
                                        status_upload = false;
                                    }


                                }
                            }
                        }
                        else
                        {
                            status_upload = false;
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
        private void backgroundWorker_upload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Class_Parameter.runbackground = false;

                panel_load.Width = 0;

                button_download_all_item.Enabled = true;

                button_upload.Text = "อัพโหลดจำนวนสินค้า";
                button_upload.Enabled = true;

                button_template.Enabled = true;

                if (status_upload)
                {
                    MessageBox.Show("ปรับจำนวนเรียบร้อย " + label_item_load_complete.Text + " รายการ", "เรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if(status_file)
                    {
                        // แสดงปุ่มกด โหลด error
                        pictureBox_load_error.Visible = true;
                        button_error.Visible = true;

                        MessageBox.Show("ข้อมูลสินค้าทั้งหมด " + label_item_load.Text + " รายการ" + Environment.NewLine +
                            "ปรับจำนวนเรียบร้อย " + label_item_load_complete.Text + " รายการ" + Environment.NewLine +
                            "ข้อมูลสินค้าไม่ถูกต้อง " + label_item_load_error.Text + " รายการ" + Environment.NewLine +
                            "ตรวจสอบข้อมูลได้ที่ปุ่ม ข้อมูลไม่ถูกต้อง", "เรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("ไฟล์ข้อมูลไม่ถูกต้อง !!!","แจ้งเตือน",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }

                }


            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        /// <summary>
        /// // ปุ่มข้อมูลไม่ถูกต้อง
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_error_Click(object sender, EventArgs e)
        {
            try
            {
                panel_load.Focus();
                using (SaveFileDialog saveFileDialoge = new SaveFileDialog())
                {
                    saveFileDialoge.FileName = "ปรับจำนวน_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
                    saveFileDialoge.DefaultExt = ".Xlsx";
                    saveFileDialoge.Filter = "Xlsx|*.Xlsx";
                    saveFileDialoge.Title = "บันทึกไฟล์";


                    if (saveFileDialoge.ShowDialog(this) == DialogResult.OK)
                    {
                        path_load = saveFileDialoge.FileName;


                        button_download_all_item.Enabled = false;

                        button_upload.Enabled = false;

                        button_template.Enabled = false;

                        button_error.Visible = false;

                        Class_Parameter.runbackground = true;

                        backgroundWorker_error.RunWorkerAsync();
                    }
                }
            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }


        private void backgroundWorker_error_DoWork(object sender, DoWorkEventArgs e)
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
                    worksheet.Name = "สินค้าปรับจำนวน";



                    worksheet.Columns.ColumnWidth = 20;
                    worksheet.Columns[1].ColumnWidth = 30;

                    worksheet.Rows[1].Font.Size = 14;
                    worksheet.Rows[1].Font.Bold = true;

                    worksheet.Rows[1].RowHeight = 30;

                    worksheet.Rows[1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Rows[1].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    worksheet.Cells[1, 1] = " กลุ่มหลัก ";
                    worksheet.Cells[1, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[1].NumberFormat = "@";

                    worksheet.Cells[1, 2] = " กลุ่มย่อย ";
                    worksheet.Cells[1, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[2].NumberFormat = "@";

                    worksheet.Cells[1, 3] = " บาร์โค้ด ";
                    worksheet.Cells[1, 3].Interior.Color = ColorTranslator.ToOle(Color.Red);
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

                    worksheet.Cells[1, 7] = " ปรับเพิ่ม ";
                    worksheet.Cells[1, 7].Interior.Color = ColorTranslator.ToOle(Color.Lime);
                    worksheet.Columns[7].NumberFormat = "General";

                    worksheet.Cells[1, 8] = " ปรับลด ";
                    worksheet.Cells[1, 8].Interior.Color = ColorTranslator.ToOle(Color.Lime);
                    worksheet.Columns[8].NumberFormat = "General";

                    worksheet.Cells[1, 9] = " กำหนด ";
                    worksheet.Cells[1, 9].Interior.Color = ColorTranslator.ToOle(Color.Lime);
                    worksheet.Columns[9].NumberFormat = "General";

                    worksheet.Cells[1, 10] = " ต้นทุนต่อหน่วย ";
                    worksheet.Cells[1, 10].Interior.Color = ColorTranslator.ToOle(Color.Lime);
                    worksheet.Columns[10].NumberFormat = "General";

                    worksheet.Activate();
                    worksheet.Application.ActiveWindow.SplitRow = 1;
                    worksheet.Application.ActiveWindow.FreezePanes = true;

                    // สร้างเส้น                
                    Excel.Range rangeAllBorders = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 9]];
                    rangeAllBorders.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    rangeAllBorders.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    rangeAllBorders.Borders.Color = ColorTranslator.ToOle(Color.Black);

                    // เริ่มใส่ข้อมูลผิดพลาด
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            cmd_sqlite.CommandText = @"SELECT iteq.id,iteq.group_main,iteq.group_sub,iteq.barcode,iteq.name,i.qty,
iteq.unit,iteq.inc,iteq.dec,iteq.cus,iteq.cost,iteq.status 
FROM Item_Temp_Excel_Qty iteq
join (
SELECT small_barcode as barcode,small_qty as qty
from item where status = 1 union all
SELECT medium_barcode,medium_qty
from item where status  = 1 and medium_barcode <> '' union all
SELECT large_barcode,large_qty 
from item where status  = 1 and large_barcode <> ''
group by small_barcode ,small_qty
) i on i.barcode = iteq.barcode 
WHERE iteq.status <> '';";
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
                                    worksheet.Cells[i + 2, 5] = dt.Rows[i]["qty"].ToString();
                                    worksheet.Cells[i + 2, 6] = dt.Rows[i]["unit"].ToString();
                                    worksheet.Cells[i + 2, 7] = dt.Rows[i]["inc"].ToString();
                                    worksheet.Cells[i + 2, 8] = dt.Rows[i]["dec"].ToString();
                                    worksheet.Cells[i + 2, 9] = dt.Rows[i]["cus"].ToString();
                                    worksheet.Cells[i + 2, 10] = dt.Rows[i]["cost"].ToString();
                                    worksheet.Cells[i + 2, 11] = dt.Rows[i]["status"].ToString();

                                    panel_load.Width = ((i + 1) * panel_back.Width / dt.Rows.Count);
                                }
                            }
                        }
                    }

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
                        catch { /* หากกระบวนการปิดไปแล้ว จะข้ามส่วนนี้อัตโนมัติ */}
                    }
                }



            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        private void backgroundWorker_error_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Class_Parameter.runbackground = false;

                MessageBox.Show(path_load, "ดาวน์โหลดไฟล์ เรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Information);

                panel_load.Width = 0;

                button_download_all_item.Enabled = true;

                button_upload.Enabled = true;

                button_template.Enabled = true;

                button_error.Visible = true;

            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        private void button_download_all_item_MouseEnter(object sender, EventArgs e)
        {
            button_download_all_item.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Excel, new Size(80, 80));

        }

        private void button_download_all_item_MouseLeave(object sender, EventArgs e)
        {
            button_download_all_item.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Excel, new Size(60, 60));

        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                button.Font = new System.Drawing.Font("Segoe UI", button.Font.Size + 2, button.Font.Style);
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
