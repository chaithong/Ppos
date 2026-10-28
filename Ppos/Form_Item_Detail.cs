using Ppos.Class;
using System.Data;
using System.Data.SQLite;
using System.Drawing.Imaging;
using System.Reflection;
using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Ppos
{
    public partial class Form_Item_Detail : Form
    {
        DataTable dt;
        bool edit_save = true, add_save = true;
        bool set_sale_vat, set_sale_negative, set_item_weight, set_effective_promotion, set_effective_member, set_effective_hotkey;
        string set_item_total;
        int Corners = 30; // มุม
        int Limit = 20; // จำนวนแสดงผล
        int set_search = 5, count_set_search = 0;
        int shows = 0;

        // string cameraName; // ระบุชื่อกล้องที่คุณทราบ
        bool start_video = false;

        // 1. สร้าง Object ของ ToolTip ขึ้นมา
        System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        public Form_Item_Detail()
        {
            InitializeComponent();

            try
            {
                this.DoubleBuffered = true;
                tableLayoutPanel_back_detail_item.Location = new Point(
                   (panel_detail.Width / 2) - (tableLayoutPanel_back_detail_item.Width / 2),
                   0);

                dataGridView_item.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_item, true, null);

                foreach (DataGridViewColumn column in dataGridView_item.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_item);

                dataGridView_item.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128,255,128);
                dataGridView_item.EnableHeadersVisualStyles = false;

                // เพิ่ม Code นี้ใน Constructor หรือ Form_Load เพื่อผูก Event
                dataGridView_item.MouseWheel += new MouseEventHandler(dataGridView_item_MouseWheel);

                // เรียกใช้ Class ส่วนกลาง แล้วส่ง Panel ของ Form นี้เข้าไป
                Class_Scroll_Panel.EnableDragScroll(panel_detail);

                button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));

                button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.add_item, new Size(50, 50));

                button_cancel.Image = Class_Image.resizeImage(Ppos.Properties.Resources.exits, new Size(40, 40));

                button_edit_picture.Image = Class_Image.resizeImage(Ppos.Properties.Resources.file, new Size(35, 35));

                button_camera.Image = Class_Image.resizeImage(Ppos.Properties.Resources.camera, new Size(35, 35));

                button_delete_picture.Image = Class_Image.resizeImage(Ppos.Properties.Resources.exits, new Size(30, 30));


                pictureBox_item.Image = Ppos.Properties.Resources.picture_dark;

                dataGridView_item.Columns["name"].HeaderText = "";

                // ตั้งต้นสถานะ
                button_sale_vat.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));
                set_sale_vat = false;

                button_sale_negative.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                set_sale_negative = true;

                button_item_weight.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));
                set_item_weight = false;

                button_effective_promotion.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                set_effective_promotion = true;

                button_effective_member.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                set_effective_member = true;

                button_effective_hotkey.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                set_effective_hotkey = true;

                // ลบ master
                // ถ้ามีภาพ master
                if (System.IO.File.Exists(Form_Login.item_path + @"\master.Png"))
                {

                    System.IO.File.Delete(Form_Login.item_path + @"\master.Png");

                }

                // 2. ตั้งค่าหน่วงเวลาและการแสดงผล (เลือกใส่หรือไม่ใส่ก็ได้)
                toolTip.AutoPopDelay = 5000;   // ให้แสดงค้างไว้นาน 5 วินาที
                toolTip.InitialDelay = 500;    // เอาเมาส์ชี้ทิ้งไว้ 0.5 วินาที แล้วค่อยแสดง
                toolTip.ReshowDelay = 0;     // เวลาขยับเมาส์ไปจุดอื่นให้หน่วงเท่าไหร่
                toolTip.ShowAlways = true;     // แสดงผลตลอดเวลาแม้หน้าต่างจะไม่ถูก Active


                toolTip.SetToolTip(label_small_price, "ราคาขายต่อหน่วยเล็ก");
                toolTip.SetToolTip(label_medium_price, "ราคาขายต่อหน่วยกลาง");
                toolTip.SetToolTip(label_large_price, "ราคาขายต่อหน่วยใหญ่");

                toolTip.SetToolTip(label_small_cost_last, "ต้นทุนหน่วยเล็กที่รับเข้าล่าสุด");
                toolTip.SetToolTip(label_medium_cost_last, "ต้นทุนหน่วยกลางที่รับเข้าล่าสุด");
                toolTip.SetToolTip(label_large_cost_last, "ต้นทุนหน่วยใหญ่ที่รับเข้าล่าสุด");

                toolTip.SetToolTip(label_small_cost_avg, "ต้นทุนเฉลี่ยต่อหน่วยเล็ก");
                toolTip.SetToolTip(label_medium_cost_avg, "ต้นทุนเฉลี่ยต่อหน่วยกลาง");
                toolTip.SetToolTip(label_large_cost_avg, "ต้นทุนเฉลี่ยต่อหน่วยใหญ่");

                toolTip.SetToolTip(label_medium_qty_small, "จำนวนหน่วยเล็ก" + Environment.NewLine + "ใน 1 หน่วยกลาง");
                toolTip.SetToolTip(label_large_qty_small, "จำนวนหน่วยเล็ก" + Environment.NewLine + "ใน 1 หน่วยใหญ่");

                toolTip_Add(false);
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // group main
                        cmd_sqlite.CommandText = "select group_main from Item_Group where status = 1 group by group_main order by group_main";
                        var source = new AutoCompleteStringCollection();
                        using (var reader = cmd_sqlite.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                // อ่านค่าจากคอลัมน์แรก (ดัชนี 0) มาใส่ใน Source
                                source.Add(reader["group_main"].ToString()!);
                            }

                        }
                        textBox_group_main.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        textBox_group_main.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        textBox_group_main.AutoCompleteCustomSource = source;

                        // group sub
                        cmd_sqlite.CommandText = "select group_sub from Item_Group where status = 1 group by group_sub order by group_sub";
                        source = new AutoCompleteStringCollection();
                        using (var reader = cmd_sqlite.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                // อ่านค่าจากคอลัมน์แรก (ดัชนี 0) มาใส่ใน Source
                                source.Add(reader["group_sub"].ToString()!);
                            }

                        }
                        textBox_group_sub.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        textBox_group_sub.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        textBox_group_sub.AutoCompleteCustomSource = source;
                        // กล้อง                      
                        if (Class_Parameter.device_name == "") // ถ้าไม่มีกล้อง
                        {
                            button_camera.Visible = false;
                            tableLayoutPanel_button_picture.ColumnStyles[1].SizeType = SizeType.Absolute;
                            tableLayoutPanel_button_picture.ColumnStyles[1].Width = 0;
                        }

                        // count item
                        cmd_sqlite.CommandText = "select count(code) from Item where status = 1";
                        using (var reader = cmd_sqlite.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // อ่านค่าจากคอลัมน์แรก (ดัชนี 0) มาใส่ใน Source
                                label_search.Text = Convert.ToInt32(reader[0].ToString()).ToString("#,##0");
                            }
                            set_item_total = label_search.Text;
                        }

                    }
                    con_sqlite.Close();
                }


            }
            catch
            {
                this.Close();
            }
        }
        private void Form_Item_Detail_Load(object sender, EventArgs e)
        {
            try
            {

                AutoComplete();
                search();
                textBox_search.Focus();
                timer_show.Start();

            }
            catch
            {

            }

        }
       
        private void timer_show_Tick(object sender, EventArgs e)
        {
            try
            {
                shows++;
                if (shows == 1)
                {
                    customGroupBox_picture.Visible = true;
                }
                else if (shows == 2)
                {
                    customGroupBox_small.Visible = true;
                }
                else if (shows == 3)
                {
                    customGroupBox_item.Visible = true;
                }
                else if (shows == 4)
                {
                    customGroupBox_medium.Visible = true;
                }
                else if (shows == 5)
                {
                    customGroupBox_other.Visible = true;
                }
                else
                {
                    customGroupBox_large.Visible = true;
                    timer_show.Stop();
                }
            }
            catch
            {
                timer_show.Stop();
            }
        }
        private void toolTip_Add(bool add)
        {
            try
            {

                if (add)
                {
                    toolTip.SetToolTip(label_small_qty, "จำนวนหน่วยเล็กทั้งหมด");
                    toolTip.SetToolTip(label_medium_qty, "จำนวนหน่วยกลางทั้งหมด");
                    toolTip.SetToolTip(label_large_qty, "จำนวนหน่วยใหญ่ทั้งหมด");

                }
                else
                {
                    toolTip.SetToolTip(label_small_qty, "จำนวนหน่วยเล็กทั้งหมด" + Environment.NewLine + "รวมหน่วยเล็กในหน่วยกลาง" + Environment.NewLine + "และหน่วยเล็กในหน่วยใหญ่");
                    toolTip.SetToolTip(label_medium_qty, "จำนวนหน่วยกลางทั้งหมด" + Environment.NewLine + "ของจำนวนหน่วยเล็ก");
                    toolTip.SetToolTip(label_large_qty, "จำนวนหน่วยใหญ่ทั้งหมด" + Environment.NewLine + "ของจำนวนหน่วยเล็ก");

                }
            }
            catch
            { }
        }

        // ฟังก์ชันควบคุมการเลื่อนเมื่อหมุน Mouse Wheel
        private void dataGridView_item_MouseWheel(object sender, MouseEventArgs e)
        {
            // ตรวจสอบว่ามีข้อมูลใน DataGridView หรือไม่
            if (dataGridView_item.RowCount == 0) return;

            // ดึงค่าดัชนีแถวปัจจุบันที่แสดงอยู่บนสุด
            int currentIndex = dataGridView_item.FirstDisplayedScrollingRowIndex;
            if (currentIndex < 0) currentIndex = 0;

            // e.Delta > 0 คือหมุนขึ้น (เลื่อนบรรทัดขึ้น), e.Delta < 0 คือหมุนลง (เลื่อนบรรทัดลง)
            int scrollLines = 1; // จำนวนแถวที่ต้องการให้เลื่อนต่อการหมุน 1 กริ๊ก
            int newIndex = currentIndex + (e.Delta > 0 ? -scrollLines : scrollLines);

            // ตรวจสอบไม่ให้ดัชนีหลุดขอบบนและขอบล่างของตาราง
            if (newIndex < 0)
            {
                newIndex = 0;
            }
            else if (newIndex >= dataGridView_item.RowCount)
            {
                newIndex = dataGridView_item.RowCount - 1;
            }

            // สั่งให้ตารางเลื่อนไปยังแถวที่คำนวณได้
            dataGridView_item.FirstDisplayedScrollingRowIndex = newIndex;
        }

        private void AutoComplete()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        /* // ชื่อ
                         cmd_sqlite.CommandText = "SELECT i.name from Item i where i.status = '1' group by i.name";
                         source = new AutoCompleteStringCollection();
                         using (var reader = cmd_sqlite.ExecuteReader())
                         {

                             while (reader.Read())
                             {
                                 // อ่านค่าจากคอลัมน์แรก (ดัชนี 0) มาใส่ใน Source
                                 source.Add(reader["name"].ToString());
                             }

                         }
                         textBox_name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                         textBox_name.AutoCompleteSource = AutoCompleteSource.CustomSource;
                         textBox_name.AutoCompleteCustomSource = source;*/
                        // หน่วย
                        cmd_sqlite.CommandText = "SELECT i.small_unit  from Item i WHERE i.status = '1' UNION " +
                                                 "SELECT i.medium_unit  from Item i WHERE i.status = '1' and i.medium_unit != '' UNION " +
                                                 "SELECT i.large_unit  from Item i WHERE i.status = '1' and i.large_unit != '' " +
                                                 "group by i.small_unit,i.medium_unit,i.large_unit ";
                        var source = new AutoCompleteStringCollection();
                        using (var reader = cmd_sqlite.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                // อ่านค่าจากคอลัมน์แรก (ดัชนี 0) มาใส่ใน Source
                                source.Add(reader["small_unit"].ToString()!);
                            }

                        }
                        textBox_small_unit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        textBox_small_unit.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        textBox_small_unit.AutoCompleteCustomSource = source;
                        textBox_medium_unit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        textBox_medium_unit.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        textBox_medium_unit.AutoCompleteCustomSource = source;
                        textBox_large_unit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        textBox_large_unit.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        textBox_large_unit.AutoCompleteCustomSource = source;
                    }
                }
            }
            catch
            {

            }
        }
        private void dataGridView_item_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {


                if (e.RowIndex != -1)
                {
                    dataGridView_item.Rows[e.RowIndex].Selected = true;
                    dataGridView_item.CurrentCell = dataGridView_item.Rows[e.RowIndex].Cells["name"];
                    // ค้นหาภาพ
                    if (System.IO.File.Exists(Form_Login.item_path + @"\" + dataGridView_item.Rows[e.RowIndex].Cells["small_barcode"].Value!.ToString() + ".Png"))
                    {
                        using (FileStream bitmapFile = new FileStream(Form_Login.item_path + @"\" + dataGridView_item.Rows[e.RowIndex].Cells["small_barcode"].Value!.ToString() + ".Png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            pictureBox_item.Image = new Bitmap(bitmapFile);

                        }
                    }
                    else
                    {
                        pictureBox_item.Image = Ppos.Properties.Resources.picture_dark;
                    }

                    textBox_group_main.Text = dataGridView_item.Rows[e.RowIndex].Cells["group_main"].Value!.ToString();
                    textBox_group_sub.Text = dataGridView_item.Rows[e.RowIndex].Cells["group_sub"].Value!.ToString();
                    textBox_name.Text = dataGridView_item.Rows[e.RowIndex].Cells["name"].Value!.ToString();

                    textBox_small_barcode.Text = dataGridView_item.Rows[e.RowIndex].Cells["small_barcode"].Value!.ToString();
                    textBox_small_unit.Text = dataGridView_item.Rows[e.RowIndex].Cells["small_unit"].Value!.ToString();
                    textBox_small_price.Text = Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["small_price"].Value!.ToString()).ToString("#,##0.##");
                    textBox_small_qty.Text = Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["small_qty"].Value!.ToString()).ToString("#,##0.###");
                    textBox_small_cost_last.Text = Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["small_cost_last"].Value!.ToString()).ToString("#,##0.##");
                    textBox_small_cost_avg.Text = Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["small_cost_avg"].Value!.ToString()).ToString("#,##0.##");

                    textBox_medium_barcode.Text = dataGridView_item.Rows[e.RowIndex].Cells["medium_barcode"].Value!.ToString();
                    textBox_medium_unit.Text = dataGridView_item.Rows[e.RowIndex].Cells["medium_unit"].Value!.ToString();
                    textBox_medium_price.Text = Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["medium_price"].Value!.ToString()).ToString("#,##0.##");
                    textBox_medium_qty.Text = Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["medium_qty"].Value!.ToString()).ToString("#,##0.###");
                    textBox_medium_qty_small.Text = Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["medium_qty_small"].Value!.ToString()).ToString("#,##0.##");
                    textBox_medium_cost_last.Text = Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["medium_cost_last"].Value!.ToString()).ToString("#,##0.##");
                    textBox_medium_cost_avg.Text = Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["medium_cost_avg"].Value!.ToString()).ToString("#,##0.##");

                    textBox_large_barcode.Text = dataGridView_item.Rows[e.RowIndex].Cells["large_barcode"].Value!.ToString();
                    textBox_large_unit.Text = dataGridView_item.Rows[e.RowIndex].Cells["large_unit"].Value!.ToString();
                    textBox_large_price.Text = Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["large_price"].Value!.ToString()).ToString("#,##0.##");
                    textBox_large_qty.Text = Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["large_qty"].Value!.ToString()).ToString("#,##0.###");
                    textBox_large_qty_small.Text = Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["large_qty_small"].Value!.ToString()).ToString("#,##0.##");
                    textBox_large_cost_last.Text = Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["large_cost_last"].Value!.ToString()).ToString("#,##0.##");
                    textBox_large_cost_avg.Text = Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["large_cost_avg"].Value!.ToString()).ToString("#,##0.##");

                    if (Convert.ToBoolean(dataGridView_item.Rows[e.RowIndex].Cells["sale_vat"].Value))
                    {
                        button_sale_vat.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                        set_sale_vat = true;
                    }
                    else
                    {
                        button_sale_vat.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));
                        set_sale_vat = false;
                    }
                    if (Convert.ToBoolean(dataGridView_item.Rows[e.RowIndex].Cells["sale_negative"].Value))
                    {
                        button_sale_negative.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                        set_sale_negative = true;
                    }
                    else
                    {
                        button_sale_negative.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));
                        set_sale_negative = false;
                    }
                    if (Convert.ToBoolean(dataGridView_item.Rows[e.RowIndex].Cells["item_weight"].Value))
                    {
                        button_item_weight.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                        set_item_weight = true;
                    }
                    else
                    {
                        button_item_weight.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));
                        set_item_weight = false;
                    }
                    if (Convert.ToBoolean(dataGridView_item.Rows[e.RowIndex].Cells["effective_promotion"].Value))
                    {
                        button_effective_promotion.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                        set_effective_promotion = true;
                    }
                    else
                    {
                        button_effective_promotion.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));
                        set_effective_promotion = false;
                    }

                    if (Convert.ToBoolean(dataGridView_item.Rows[e.RowIndex].Cells["effective_member"].Value))
                    {
                        button_effective_member.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                        set_effective_member = true;
                    }
                    else
                    {
                        button_effective_member.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));
                        set_effective_member = false;
                    }
                    if (Convert.ToBoolean(dataGridView_item.Rows[e.RowIndex].Cells["effective_hotkey"].Value))
                    {
                        button_effective_hotkey.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                        set_effective_hotkey = true;
                    }
                    else
                    {
                        button_effective_hotkey.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));
                        set_effective_hotkey = false;
                    }

                    // ปุ่มแก้ไข
                    edit_save = true;
                    button_edit_save.Enabled = true;
                    button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                    button_edit_save.Text = "แก้ไข";
                    button_edit_save.FlatStyle = FlatStyle.Standard;
                    button_edit_save.BackColor = Color.FromArgb(128,255,128);

                    // กดลบ
                    if (e.ColumnIndex == dataGridView_item.Columns["delete"]!.Index)
                    {

                        if (check_delete_item_hotkey())
                        {
                            if (check_item_pro())
                            {
                                if(check_item_hole())
                                {
                                    if (MessageBox.Show("ต้องการลบ " + dataGridView_item.Rows[e.RowIndex].Cells["name"].Value!.ToString() + " ใช่หรือไม่ ?", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        // ปุ่มแก้ไข
                                        edit_save = true;
                                        button_edit_save.Enabled = false;
                                        button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                                        button_edit_save.Text = "แก้ไข";
                                        button_edit_save.FlatStyle = FlatStyle.Flat;
                                        button_edit_save.BackColor = Color.FromArgb(128,255,128);

                                        // ลบภาพที่เพิ่มไว้
                                        if (System.IO.File.Exists(Form_Login.item_path + @"\" + textBox_small_barcode.Text + ".Png"))
                                        {
                                            System.IO.File.Delete(Form_Login.item_path + @"\" + textBox_small_barcode.Text + ".Png");
                                        }

                                        // ใส่ภาพเริ่มต้น
                                        pictureBox_item.Image = Ppos.Properties.Resources.picture_dark;


                                        // เริ่ม delete                                                              
                                        Class_Item_Detail.Delete(dataGridView_item.Rows[dataGridView_item.CurrentRow!.Index].Cells["code"].Value!.ToString()!,
                                        textBox_group_main.Text.Trim(),
                                        textBox_group_sub.Text.Trim(),
                                        textBox_name.Text.Trim(),

                                        textBox_small_barcode.Text.Trim(),
                                        textBox_small_unit.Text.Trim(),
                                        textBox_small_price.Text,
                                        textBox_small_cost_last.Text,
                                        textBox_small_cost_avg.Text,
                                        textBox_small_qty.Text,

                                        textBox_medium_barcode.Text.Trim(),
                                        textBox_medium_unit.Text.Trim(),
                                        textBox_medium_price.Text,
                                        textBox_medium_cost_last.Text,
                                        textBox_medium_cost_avg.Text,
                                        textBox_medium_qty.Text,
                                        textBox_medium_qty_small.Text,

                                        textBox_large_barcode.Text.Trim(),
                                        textBox_large_unit.Text.Trim(),
                                        textBox_large_price.Text,
                                        textBox_large_cost_last.Text,
                                        textBox_large_cost_avg.Text,
                                        textBox_large_qty.Text,
                                        textBox_large_qty_small.Text,

                                         set_sale_vat,
                                            set_sale_negative,
                                            set_item_weight,
                                            set_effective_promotion,
                                            set_effective_member,
                                            set_effective_hotkey
                                        );

                                        // ลบสินค้าทั้งหมดอีก 1 รายการ
                                        set_item_total = (Convert.ToInt32(set_item_total.Replace(",", "")) - 1).ToString("#,##0");

                                        stringempty();

                                        search();
                                    }

                                }

                            }
                        }

                    }

                }

                textBox_search.Focus();
            }
            catch
            {

            }
        }
        private void timer_search_Tick(object sender, EventArgs e)
        {
            try
            {
                count_set_search++;
                if (count_set_search >= set_search)
                {
                    timer_search.Stop();
                    count_set_search = 0;
                    search();
                }
            }
            catch
            {

            }
        }
        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!timer_search.Enabled)
                {
                    timer_search.Start();
                }
                count_set_search = 0;
            }
            catch
            {

            }
        }
        private void search()
        {
            try
            {
                dataGridView_item.Rows.Clear();

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT code,group_main,group_sub,name," +
                                                 "small_barcode,small_unit,small_price,small_cost_last,small_cost_avg,small_qty," +
                                                 "medium_barcode,medium_unit,medium_price,medium_cost_last,medium_cost_avg,medium_qty,medium_qty_small," +
                                                 "large_barcode,large_unit,large_price,large_cost_last,large_cost_avg,large_qty,large_qty_small," +
                                                 "sale_vat,sale_negative,item_weight,effective_promotion,effective_member,effective_hotkey,status " +
                                                 "from Item " +
                                                 "WHERE status = 1 ";
                        if (textBox_search.Text != "")
                        {
                            cmd_sqlite.CommandText += "and " +
                                                    "(name like '%" + textBox_search.Text + "%' or " +
                                                    "small_barcode like '%" + textBox_search.Text + "%' or " +
                                                    "medium_barcode like '%" + textBox_search.Text + "%' or " +
                                                    "large_barcode like '%" + textBox_search.Text + "%') "
                                                    ;
                        }
                        cmd_sqlite.CommandText += "order by code desc ";
                        if (Limit > 0)
                        {
                            cmd_sqlite.CommandText += "limit " + Limit;
                        }


                        var er = cmd_sqlite.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(er);

                        if (dt.Rows.Count > 0)
                        {
                            bool selected = false;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dataGridView_item.Rows.Add(
                                    dt.Rows[i]["code"].ToString()!,
                                    dt.Rows[i]["group_main"].ToString()!,
                                    dt.Rows[i]["group_sub"].ToString()!,
                                    dt.Rows[i]["name"].ToString()!,
                                    dt.Rows[i]["small_barcode"].ToString()!,
                                    dt.Rows[i]["small_unit"].ToString()!,
                                   dt.Rows[i]["small_price"].ToString()!,
                                   dt.Rows[i]["small_cost_last"].ToString()!,
                                   dt.Rows[i]["small_cost_avg"].ToString()!,
                                   dt.Rows[i]["small_qty"].ToString()!,
                                   dt.Rows[i]["medium_barcode"].ToString()!,
                                   dt.Rows[i]["medium_unit"].ToString()!,
                                   dt.Rows[i]["medium_price"].ToString()!,
                                   dt.Rows[i]["medium_cost_last"].ToString()!,
                                   dt.Rows[i]["medium_cost_avg"].ToString()!,
                                   dt.Rows[i]["medium_qty"].ToString()!,
                                   dt.Rows[i]["medium_qty_small"].ToString()!,
                                   dt.Rows[i]["large_barcode"].ToString()!,
                                   dt.Rows[i]["large_unit"].ToString()!,
                                   dt.Rows[i]["large_price"].ToString()!,
                                   dt.Rows[i]["large_cost_last"].ToString()!,
                                   dt.Rows[i]["large_cost_avg"].ToString()!,
                                   dt.Rows[i]["large_qty"].ToString()!,
                                   dt.Rows[i]["large_qty_small"].ToString()!,
                                   dt.Rows[i]["sale_vat"].ToString()!,
                                   dt.Rows[i]["sale_negative"].ToString()!,
                                   dt.Rows[i]["item_weight"].ToString()!,
                                    dt.Rows[i]["effective_promotion"].ToString()!,
                                    dt.Rows[i]["effective_member"].ToString()!,
                                    dt.Rows[i]["effective_hotkey"].ToString()!,
                                    Class_Image.resizeImage(Ppos.Properties.Resources.exits, new Size(20, 20))
                                    );
                                // ถ้าเป็นข้อมูลที่เลือกไว้ จะ select ให้
                                if (dt.Rows[i]["small_barcode"].ToString() == textBox_small_barcode.Text)
                                {
                                    selected = true;
                                    dataGridView_item.Rows[i].Selected = true;
                                    dataGridView_item.CurrentCell = dataGridView_item.Rows[i].Cells["name"];
                                    dataGridView_item_CellMouseDown(dataGridView_item, new DataGridViewCellMouseEventArgs(3, i, 0, 0, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0)));

                                }
                            }
                            // ถ้าไม่มีข้อมูลเดิมจะไม่เลือก
                            if (!selected)
                            {
                                dataGridView_item.ClearSelection();

                                /* if (dt.Rows.Count == 1) // มีรายการเดียว ทำการ กด
                                 {
                                     dataGridView_item_CellMouseDown(dataGridView_item, new DataGridViewCellMouseEventArgs(3, 0, 0, 0, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0)));

                                 }*/
                            }

                        }
                    }
                    con_sqlite.Close();
                }


                // นับจำนวนค้นหา
                label_search.Text = set_item_total;
                if (dataGridView_item.RowCount > 0)
                {
                    label_search.Text = dt.Rows.Count.ToString("#,##0") + " / " + set_item_total;
                }

            }
            catch
            {

            }
        }
        private void button_edit_save_Click(object sender, EventArgs e)
        {
            try
            {
                button_edit_save.Enabled = false;

                if (edit_save) // กดแก้ไข
                {
                    if (check_item_pro())
                    {
                        if(check_item_hole())
                        {
                            if (textBox_small_barcode.Text != "")
                            {
                                // ปุ่มแก้ไข
                                edit_save = false;
                                button_edit_save.Enabled = true;
                                button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.save, new Size(45, 45));
                                button_edit_save.Text = "บันทึก";
                                button_edit_save.FlatStyle = FlatStyle.Standard;
                                button_edit_save.BackColor = Color.FromArgb(192, 255, 192);

                                // ปุ่มเพิ่ม
                                add_save = true;
                                button_add_save.Enabled = false;
                                button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.add_item, new Size(50, 50));
                                button_add_save.Text = "เพิ่ม";
                                button_add_save.FlatStyle = FlatStyle.Flat;
                                button_add_save.BackColor = Color.FromArgb(128,255,128);

                                // เปิดปุ่มยกเลิก
                                button_cancel.Enabled = true;
                                button_cancel.FlatStyle = FlatStyle.Standard;
                                button_cancel.BackColor = Color.FromArgb(192, 255, 192);

                                Enabled(true);

                                // ปิดจุดที่แก้ไขไม่ได้
                                if (Convert.ToDouble(textBox_small_qty.Text) <= 0)
                                {
                                    textBox_small_cost_avg.Enabled = false;
                                    textBox_small_cost_avg.BackColor = Color.FromArgb(192, 255, 192);
                                }
                                textBox_small_cost_last.Enabled = false;
                                textBox_small_cost_last.BackColor = Color.FromArgb(192, 255, 192);

                                textBox_medium_qty.Enabled = false;
                                textBox_medium_qty.BackColor = Color.FromArgb(192, 255, 192);
                                textBox_medium_cost_avg.Enabled = false;
                                textBox_medium_cost_avg.BackColor = Color.FromArgb(192, 255, 192);
                                textBox_medium_cost_last.Enabled = false;
                                textBox_medium_cost_last.BackColor = Color.FromArgb(192, 255, 192);

                                textBox_large_qty.Enabled = false;
                                textBox_large_qty.BackColor = Color.FromArgb(192, 255, 192);
                                textBox_large_cost_avg.Enabled = false;
                                textBox_large_cost_avg.BackColor = Color.FromArgb(192, 255, 192);
                                textBox_large_cost_last.Enabled = false;
                                textBox_large_cost_last.BackColor = Color.FromArgb(192, 255, 192);

                            }
                        }
                       
                    }
                }
                else // กดบันทึก
                {
                    // ต้องไม่มีค่าว่าง
                    if (checkSave())
                    {
                        // ตรวจสอบบาร์ เล็ก กลาง ใหญ่ ต้องไม่ซ้ำกัน
                        if (checkBarDuplicate())
                        {
                            // ตรวจสอบบาร์ต้องไม่ซ้ำกับสินค้าอื่น
                            if (compareBar(dataGridView_item.Rows[dataGridView_item.CurrentRow!.Index].Cells["code"].Value!.ToString()!))
                            {
                                // ตรวจสอบ กลุ่มสินค้าต้องเหมือนกับที่สร้างไว้
                                if (compareGroup())
                                {
                                    // ตรวจสอบพร้อมแจ้งเตือน
                                    if (checkAlert())
                                    {
                                        // เริ่มบันทึก
                                        // ปิดการแก้ไข
                                        Enabled(false);

                                        // ถ้ามีภาพ master
                                        if (System.IO.File.Exists(Form_Login.item_path + @"\master.Png"))
                                        {
                                            // ถ้ามีภาพเดิม ชื่อเดิมจะทำการลบก่อน
                                            if (System.IO.File.Exists(Form_Login.item_path + @"\" + textBox_small_barcode.Text + ".Png"))
                                            {

                                                System.IO.File.Delete(Form_Login.item_path + @"\" + textBox_small_barcode.Text + ".Png");
                                            }
                                            // เปลี่ยนชื่อ master เป็น barcode
                                            System.IO.File.Move(Form_Login.item_path + @"\master.Png", Form_Login.item_path + @"\" + textBox_small_barcode.Text + ".Png");
                                        }

                                        // ปุ่มแก้ไข
                                        edit_save = true;
                                        button_edit_save.Enabled = true;
                                        button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                                        button_edit_save.Text = "แก้ไข";
                                        button_edit_save.FlatStyle = FlatStyle.Standard;
                                        button_edit_save.BackColor = Color.FromArgb(128,255,128);

                                        // ปุ่มเพิ่ม
                                        add_save = true;
                                        button_add_save.Enabled = true;
                                        button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.add_item, new Size(50, 50));
                                        button_add_save.Text = "เพิ่ม";
                                        button_add_save.FlatStyle = FlatStyle.Standard;
                                        button_add_save.BackColor = Color.FromArgb(128,255,128);

                                        // ปุ่มยกเลิก
                                        button_cancel.Enabled = false;
                                        button_cancel.FlatStyle = FlatStyle.Flat;
                                        button_cancel.BackColor = Color.FromArgb(128,255,128);

                                        // updaete
                                        if (textBox_medium_barcode.Text.Trim() == "")
                                        {
                                            textBox_medium_unit.Text = "";
                                            textBox_medium_price.Text = "";
                                            textBox_medium_qty.Text = "";
                                            textBox_medium_qty_small.Text = "";
                                            textBox_medium_cost_last.Text = "";
                                            textBox_medium_cost_avg.Text = "";
                                        }
                                        if (textBox_large_barcode.Text.Trim() == "")
                                        {
                                            textBox_large_unit.Text = "";
                                            textBox_large_price.Text = "";
                                            textBox_large_qty.Text = "";
                                            textBox_large_qty_small.Text = "";
                                            textBox_large_cost_last.Text = "";
                                            textBox_large_cost_avg.Text = "";
                                        }
                                        // เริ่ม update                                                              
                                        Class_Item_Detail.Edit(dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["code"].Value!.ToString()!,
                                        textBox_group_main.Text.Trim(),
                                        textBox_group_sub.Text.Trim(),
                                        textBox_name.Text.Trim(),

                                        textBox_small_barcode.Text.Trim(),
                                        textBox_small_unit.Text.Trim(),
                                        textBox_small_price.Text,
                                        textBox_small_cost_last.Text,
                                        textBox_small_cost_avg.Text,
                                        textBox_small_qty.Text,

                                        textBox_medium_barcode.Text.Trim(),
                                        textBox_medium_unit.Text.Trim(),
                                        textBox_medium_price.Text,
                                        textBox_medium_cost_last.Text,
                                        textBox_medium_cost_avg.Text,
                                        textBox_medium_qty.Text,
                                        textBox_medium_qty_small.Text,

                                        textBox_large_barcode.Text.Trim(),
                                        textBox_large_unit.Text.Trim(),
                                        textBox_large_price.Text,
                                        textBox_large_cost_last.Text,
                                        textBox_large_cost_avg.Text,
                                        textBox_large_qty.Text,
                                        textBox_large_qty_small.Text,

                                        set_sale_vat,
                                        set_sale_negative,
                                        set_item_weight,
                                        set_effective_promotion,
                                        set_effective_member,
                                        set_effective_hotkey,

                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["group_main"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["group_sub"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["name"].Value!.ToString()!,

                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["small_barcode"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["small_unit"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["small_price"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["small_cost_avg"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["small_qty"].Value!.ToString()!,

                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["medium_barcode"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["medium_unit"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["medium_price"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["medium_cost_avg"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["medium_qty"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["medium_qty_small"].Value!.ToString()!,

                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["large_barcode"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["large_unit"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["large_price"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["large_cost_avg"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["large_qty"].Value!.ToString()!,
                                        dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["large_qty_small"].Value!.ToString()!,

                                        Convert.ToBoolean(dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["sale_vat"].Value),
                                        Convert.ToBoolean(dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["sale_negative"].Value),
                                        Convert.ToBoolean(dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["item_weight"].Value),
                                        Convert.ToBoolean(dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["effective_promotion"].Value),
                                        Convert.ToBoolean(dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["effective_member"].Value),
                                        Convert.ToBoolean(dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["effective_hotkey"].Value)
                                        );

                                        // จบการ update
                                        AutoComplete();
                                        // ค้นหาอีกครั้ง
                                        search();
                                        /* // กดเลือกอีกครั้ง
                                         if(dataGridView_item.RowCount !=1 )
                                         {
                                             dataGridView_item_CellMouseDown(dataGridView_item, new DataGridViewCellMouseEventArgs(3, dataGridView_item.CurrentRow.Index, 0, 0, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)));

                                         }*/

                                    }
                                }
                            }
                        }
                    }
                }

                textBox_search.Focus();
                button_edit_save.Enabled = true;
            }
            catch
            {
                button_edit_save.Enabled = true;
            }
        }


        private void button_add_item_Click(object sender, EventArgs e)
        {
            try
            {
                button_add_save.Enabled = false;
                if (add_save) // กดเพิ่ม
                {
                    pictureBox_item.Image = Ppos.Properties.Resources.picture;
                    dataGridView_item.ClearSelection();

                    // ปุ่มแก้ไข
                    edit_save = true;
                    button_edit_save.Enabled = false;
                    button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                    button_edit_save.Text = "แก้ไข";
                    button_edit_save.FlatStyle = FlatStyle.Flat;
                    button_edit_save.BackColor = Color.FromArgb(128,255,128);

                    // ปุ่มเพิ่ม
                    add_save = false;
                    button_add_save.Enabled = true;
                    button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.save, new Size(45, 45));
                    button_add_save.Text = "บันทึก";
                    button_add_save.FlatStyle = FlatStyle.Standard;
                    button_add_save.BackColor = Color.FromArgb(192, 255, 192);

                    // เปิดปุ่มยกเลิก
                    button_cancel.Enabled = true;
                    button_cancel.FlatStyle = FlatStyle.Standard;
                    button_cancel.BackColor = Color.FromArgb(192, 255, 192);

                    toolTip_Add(true);

                    stringempty();

                    Enabled(true);

                    // ถ้ากลุ่มเป็นค่าว่าง จะเลือกกลุ่มแรก
                    if (textBox_group_main.Text == string.Empty && textBox_group_sub.Text == string.Empty)
                    {
                        textBox_group_main.Text = Class_Parameter.Group_Main;
                        textBox_group_sub.Text = Class_Parameter.Group_Sub;
                    }

                    // ตัวเลขตั้งต้น
                    textBox_small_qty.Text = "0";
                    textBox_small_cost_avg.Text = "0";
                    textBox_small_cost_avg.Enabled = false;
                    textBox_small_cost_avg.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_small_cost_last.Text = "0";

                    textBox_medium_qty.Text = "0";
                    textBox_medium_cost_avg.Text = "0";
                    textBox_medium_cost_avg.Enabled = false;
                    textBox_medium_cost_avg.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_medium_cost_last.Text = "0";

                    textBox_large_qty.Text = "0";
                    textBox_large_cost_avg.Text = "0";
                    textBox_large_cost_avg.Enabled = false;
                    textBox_large_cost_avg.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_large_cost_last.Text = "0";

                    // set_display_edit_add(true);

                    if (textBox_group_main.Text != "")
                    {
                        if (textBox_group_sub.Text != "")
                        {
                            textBox_name.Focus();
                        }
                        else
                        {
                            textBox_group_sub.Focus();
                        }
                    }
                    else
                    {
                        textBox_group_main.Focus();
                    }

                }
                else // กดบันทึก
                {
                    // ต้องไม่มีค่าว่าง
                    if (checkSave())
                    {
                        // ตรวจสอบบาร์ เล็ก กลาง ใหญ่ ต้องไม่ซ้ำกัน
                        if (checkBarDuplicate())
                        {
                            // ตรวจสอบบาร์ต้องไม่ซ้ำกับสินค้าอื่น
                            if (compareBar(""))
                            {
                                // ตรวจสอบ กลุ่มสินค้าต้องเหมือนกับที่สร้างไว้
                                if (compareGroup())
                                {
                                    // ตรวจสอบพร้อมแจ้งเตือน
                                    if (checkAlert())
                                    {
                                        // เริ่มบันทึก
                                        // ปิดการแก้ไข
                                        Enabled(false);

                                        toolTip_Add(false);

                                        // ถ้ามีภาพ master
                                        if (System.IO.File.Exists(Form_Login.item_path + @"\master.Png"))
                                        {
                                            // ถ้ามีภาพเดิม ชื่อเดิมจะทำการลบก่อน
                                            if (System.IO.File.Exists(Form_Login.item_path + @"\" + textBox_small_barcode.Text + ".Png"))
                                            {

                                                System.IO.File.Delete(Form_Login.item_path + @"\" + textBox_small_barcode.Text + ".Png");
                                            }
                                            // เปลี่ยนชื่อ master เป็น barcode
                                            System.IO.File.Move(Form_Login.item_path + @"\master.Png", Form_Login.item_path + @"\" + textBox_small_barcode.Text + ".Png");
                                        }

                                        // ปุ่มแก้ไข
                                        edit_save = true;
                                        button_edit_save.Enabled = true;
                                        button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                                        button_edit_save.Text = "แก้ไข";
                                        button_edit_save.FlatStyle = FlatStyle.Standard;
                                        button_edit_save.BackColor = Color.FromArgb(128,255,128);

                                        // ปุ่มเพิ่ม
                                        add_save = true;
                                        button_add_save.Enabled = true;
                                        button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.add_item, new Size(50, 50));
                                        button_add_save.Text = "เพิ่ม";
                                        button_add_save.FlatStyle = FlatStyle.Standard;
                                        button_add_save.BackColor = Color.FromArgb(128,255,128);

                                        // ปิดปุ่มยกเลิก
                                        button_cancel.Enabled = false;
                                        button_cancel.FlatStyle = FlatStyle.Flat;
                                        button_cancel.BackColor = Color.FromArgb(128,255,128);




                                        // transaction
                                        Class_Item_Detail.Created(textBox_group_main.Text,
                                                                       textBox_group_sub.Text,
                                                                       textBox_name.Text,

                                                                       textBox_small_barcode.Text,
                                                                       textBox_small_unit.Text,
                                                                       textBox_small_price.Text,
                                                                       textBox_small_cost_last.Text,
                                                                       textBox_small_cost_avg.Text,
                                                                       textBox_small_qty.Text,

                                                                       textBox_medium_barcode.Text,
                                                                       textBox_medium_unit.Text,
                                                                       textBox_medium_price.Text,
                                                                       textBox_medium_cost_last.Text,
                                                                       textBox_medium_cost_avg.Text,
                                                                       textBox_medium_qty.Text,
                                                                       textBox_medium_qty_small.Text,

                                                                       textBox_large_barcode.Text,
                                                                       textBox_large_unit.Text,
                                                                       textBox_large_price.Text,
                                                                       textBox_large_cost_last.Text,
                                                                       textBox_large_cost_avg.Text,
                                                                       textBox_large_qty.Text,
                                                                       textBox_large_qty_small.Text,

                                                                       set_sale_vat,
                                                                       set_sale_negative,
                                                                       set_item_weight,
                                                                       set_effective_promotion,
                                                                       set_effective_member,
                                                                       set_effective_hotkey
                                                                       );

                                        AutoComplete();
                                        // ทำการค้นหาที่สร้าง
                                        textBox_search.Text = textBox_small_barcode.Text;
                                        // เพิ่มสินค้าทั้งหมดอีก 1 รายการ
                                        set_item_total = (Convert.ToInt32(set_item_total.Replace(",", "")) + 1).ToString("#,##0");

                                        search();

                                        /* // ทำการเลือก
                                         if (dataGridView_item.RowCount != 1)
                                         {
                                             for (int i = 0; i < dataGridView_item.RowCount; i++)
                                             {
                                                 if (dataGridView_item.Rows[i].Cells["small_barcode"].Value.ToString() == textBox_small_barcode.Text)
                                                 {
                                                     dataGridView_item_CellMouseDown(dataGridView_item, new DataGridViewCellMouseEventArgs(3, i, 0, 0, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0)));
                                                     dataGridView_item.Rows[i].Selected = true;
                                                     dataGridView_item.CurrentCell = dataGridView_item.Rows[i].Cells[3];
                                                     break;
                                                 }
                                             }
                                         }*/

                                    }
                                }
                            }
                        }

                    }
                }
                textBox_search.Focus();
                button_add_save.Enabled = true;
            }
            catch
            {
                button_add_save.Enabled = true;
            }
        }
        private void button_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                // ปุ่มยกเลิก
                button_cancel.Enabled = false;
                button_cancel.FlatStyle = FlatStyle.Flat;
                button_cancel.BackColor = Color.FromArgb(128,255,128);

                Enabled(false);

                toolTip_Add(false);

                // ลบภาพที่เพิ่มไว้
                if (System.IO.File.Exists(Form_Login.item_path + @"\master.Png"))
                {
                    System.IO.File.Delete(Form_Login.item_path + @"\master.Png");
                }
                // ปิดกล้อง
                if (Form_Main.videoSource != null && Form_Main.videoSource.IsRunning)
                {
                    Form_Main.videoSource.SignalToStop(); // ส่งสัญญาณหยุดทำงาน
                    Form_Main.videoSource.WaitForStop();   // รอจนกระทั่งระบบหยุดเคลียร์ Thread ทั้งหมด

                }

                if (!edit_save) // ยกเลิกของแก้ไข
                {
                    // ปุ่มแก้ไข
                    edit_save = true;
                    button_edit_save.Enabled = true;
                    button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                    button_edit_save.Text = "แก้ไข";
                    button_edit_save.FlatStyle = FlatStyle.Standard;
                    button_edit_save.BackColor = Color.FromArgb(128,255,128);

                    // ปุ่มเพิ่ม
                    add_save = true;
                    button_add_save.Enabled = true;
                    button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.add_item, new Size(50, 50));
                    button_add_save.Text = "เพิ่ม";
                    button_add_save.FlatStyle = FlatStyle.Standard;
                    button_add_save.BackColor = Color.FromArgb(128,255,128);

                    // กดเลือกสินค้าเพื่อคืนค่า
                    dataGridView_item_CellMouseDown(dataGridView_item,
                    new DataGridViewCellMouseEventArgs(3, dataGridView_item.CurrentRow!.Index, 0, 0, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0)));

                }
                if (!add_save) // ยกเลิกของเพิ่ม
                {

                    // ปุ่มแก้ไข
                    edit_save = true;
                    button_edit_save.Enabled = false;
                    button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                    button_edit_save.Text = "แก้ไข";
                    button_edit_save.FlatStyle = FlatStyle.Flat;
                    button_edit_save.BackColor = Color.FromArgb(128,255,128);

                    // ปุ่มเพิ่ม
                    add_save = true;
                    button_add_save.Enabled = true;
                    button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.add_item, new Size(50, 50));
                    button_add_save.Text = "เพิ่ม";
                    button_add_save.FlatStyle = FlatStyle.Standard;
                    button_add_save.BackColor = Color.FromArgb(128,255,128);

                    // เปลี่ยนภาพให้เป็นตั้งต้น
                    pictureBox_item.Image = Ppos.Properties.Resources.picture_dark;

                    // ใส่ค่าว่าง
                    stringempty();
                }



                textBox_search.Focus();

            }
            catch
            {

            }
        }
        private bool checkSave()
        {
            try
            {
                if (textBox_group_main.Text.Replace(" ", "") != string.Empty &&
                    textBox_group_sub.Text.Replace(" ", "") != string.Empty &&
                    textBox_name.Text.Replace(" ", "") != string.Empty &&

                    textBox_small_barcode.Text.Replace(" ", "").Replace(".", "").Replace("-", "") != string.Empty &&
                    textBox_small_unit.Text.Replace(" ", "").Replace(".", "").Replace("-", "") != string.Empty &&
                    textBox_small_price.Text.Replace(" ", "").Replace(".", "").Replace("-", "") != string.Empty
                    )
                {
                    // ถ้าว่างให้เป็นค่า 0
                    if (textBox_small_qty.Text.Replace(" ", "").Replace(".", "").Replace("-", "") == string.Empty)
                    {
                        textBox_small_qty.Text = "0";
                    }
                    if (textBox_small_cost_last.Text.Replace(" ", "").Replace(".", "").Replace("-", "") == string.Empty)
                    {
                        textBox_small_cost_last.Text = "0";
                    }
                    if (textBox_small_cost_avg.Text.Replace(" ", "").Replace(".", "").Replace("-", "") == string.Empty)
                    {
                        textBox_small_cost_avg.Text = "0";
                    }
                    // มีบาร์กลาง 
                    if (textBox_medium_barcode.Text.Replace(" ", "").Replace(".", "").Replace("-", "") != string.Empty)
                    {
                        if (textBox_medium_unit.Text.Replace(" ", "") != string.Empty &&
                            textBox_medium_price.Text.Replace(" ", "").Replace(".", "").Replace("-", "") != string.Empty &&
                            textBox_medium_qty_small.Text.Replace(" ", "").Replace(".", "").Replace("-", "") != string.Empty &&
                            Convert.ToDouble(textBox_medium_qty_small.Text) > 1 // จำนวนต้องมากกว่า 1
                           )
                        {
                            // ถ้าว่างให้เป็นค่า 0
                            if (textBox_medium_qty.Text.Replace(" ", "").Replace(".", "").Replace("-", "") == string.Empty)
                            {
                                textBox_medium_qty.Text = "0";
                            }
                            if (textBox_medium_cost_last.Text.Replace(" ", "").Replace(".", "").Replace("-", "") == string.Empty)
                            {
                                textBox_medium_cost_last.Text = "0";
                            }
                            if (textBox_medium_cost_avg.Text.Replace(" ", "").Replace(".", "").Replace("-", "") == string.Empty)
                            {
                                textBox_medium_cost_avg.Text = "0";
                            }
                            // มีบาร์ใหญ่
                            if (textBox_large_barcode.Text.Replace(" ", "").Replace(".", "").Replace("-", "") != string.Empty)
                            {
                                if (textBox_large_unit.Text.Replace(" ", "") != string.Empty &&
                                    textBox_large_price.Text.Replace(" ", "").Replace(".", "").Replace("-", "") != string.Empty &&
                                    textBox_large_qty_small.Text.Replace(" ", "").Replace(".", "").Replace("-", "") != string.Empty &&
                                   Convert.ToDouble(textBox_large_qty_small.Text) > Convert.ToDouble(textBox_medium_qty_small.Text)
                                  )
                                {
                                    // ถ้าว่างให้เป็นค่า 0
                                    if (textBox_large_qty.Text.Replace(" ", "").Replace(".", "").Replace("-", "") == string.Empty)
                                    {
                                        textBox_large_qty.Text = "0";
                                    }
                                    if (textBox_large_cost_last.Text.Replace(" ", "").Replace(".", "").Replace("-", "") == string.Empty)
                                    {
                                        textBox_large_cost_last.Text = "0";
                                    }
                                    if (textBox_large_cost_avg.Text.Replace(" ", "").Replace(".", "").Replace("-", "") == string.Empty)
                                    {
                                        textBox_large_cost_avg.Text = "0";
                                    }
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("กรุณากรองหน่วยใหญ่ให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            // ไม่มีบาร์ใหญ่
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("กรุณากรองหน่วยกลางให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    }
                    // ไม่มีบาร์กลาง มีบาร์ใหญ่
                    else if (textBox_large_barcode.Text.Replace(" ", "").Replace(".", "").Replace("-", "") != string.Empty)
                    {
                        MessageBox.Show("กรุณากรองหน่วยกลางให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    // มีแต่บาร์เล็ก
                    else
                    {
                        return true;
                    }

                }
                else
                {
                    MessageBox.Show("กรุณากรองข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }
        private bool checkBarDuplicate()
        {
            try
            {
                // มีบาร์กลาง
                if (textBox_medium_barcode.Text != "")
                {
                    if (textBox_small_barcode.Text != textBox_medium_barcode.Text)
                    {
                        if (textBox_large_barcode.Text != "")
                        {
                            if (textBox_small_barcode.Text != textBox_large_barcode.Text &&
                                textBox_medium_barcode.Text != textBox_large_barcode.Text)
                            {
                                return true;
                            }
                            else // เมื่อมีเท่ากัน หาอะไรเท่ากัน เพื่อแจ้งเตือน
                            {
                                if (textBox_small_barcode.Text == textBox_large_barcode.Text) // เล็ก เท่ากับ ใหญ่
                                {
                                    MessageBox.Show("บาร์โค้ดหน่วยใหญ่ ต้องไม่เหมือนกับ บาร์โค้ดหน่วยเล็ก", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                }
                                if (textBox_medium_barcode.Text == textBox_large_barcode.Text) // กลาง เท่ากับ ใหญ่
                                {
                                    MessageBox.Show("บาร์โค้ดหน่วยกลาง ต้องไม่เหมือนกับ บาร์โค้ดหน่วยใหญ่", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                }
                                return false;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("บาร์โค้ดหน่วยกลาง ต้องไม่เหมือนกับ บาร์โค้ดหน่วยเล็ก", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                // ไม่มีบาร์กลาง มีบาร์ใหญ่
                else if (textBox_large_barcode.Text != "")
                {
                    MessageBox.Show("กรุณากรองหน่วยกลางให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        private bool compareBar(string edit)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        cmd_sqlite.CommandText = scriptCompare(textBox_small_barcode.Text, edit);
                        var er = cmd_sqlite.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(er);
                        // บาร์เล็ก ต้องไม่เหมือนกับ บาร์อื่นๆ
                        if (dt.Rows.Count == 0)
                        {
                            if (textBox_medium_barcode.Text != "")
                            {
                                cmd_sqlite.CommandText = scriptCompare(textBox_medium_barcode.Text, edit);
                                er = cmd_sqlite.ExecuteReader();
                                dt = new DataTable();
                                dt.Load(er);
                                // บาร์กลาง ต้องไม่เหมือนกับ บาร์อื่นๆ
                                if (dt.Rows.Count == 0)
                                {
                                    if (textBox_large_barcode.Text != "")
                                    {
                                        cmd_sqlite.CommandText = scriptCompare(textBox_large_barcode.Text, edit);
                                        er = cmd_sqlite.ExecuteReader();
                                        dt = new DataTable();
                                        dt.Load(er);
                                        // บาร์ใหญ่ ต้องไม่เหมือนกับ บาร์อื่นๆ
                                        if (dt.Rows.Count == 0)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            MessageBox.Show("บาร์โค้ดหน่วยใหญ่ซ้ำกับสินค้า " + dt.Rows[0]["name"].ToString(), "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("บาร์โค้ดหน่วยกลางซ้ำกับสินค้า " + dt.Rows[0]["name"].ToString(), "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return false;
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("บาร์โค้ดหน่วยเล็กซ้ำกับสินค้า " + dt.Rows[0]["name"].ToString(), "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }

                    }
                }
            }
            catch
            {
                return false;
            }
        }
        private string scriptCompare(string bar, string edit)
        {
            try
            {
                string script;
                if (edit != "")
                {
                    script = "SELECT name from Item i where status = 1 and small_barcode <> '' and small_barcode = '" + bar + "' and code != " + edit + " " +
                       "UNION SELECT name from Item i where status = 1 and medium_barcode  <> '' and medium_barcode = '" + bar + "' and code != " + edit + " " +
                       "UNION SELECT name from Item i where status = 1 and large_barcode <> '' and large_barcode = '" + bar + "' and code != " + edit;
                }
                else
                {
                    script = "SELECT name from Item i where status = 1 and small_barcode <> '' and small_barcode = '" + bar + "' " +
                       "UNION SELECT name from Item i where status = 1 and medium_barcode  <> '' and medium_barcode = '" + bar + "' " +
                       "UNION SELECT name from Item i where status = 1 and large_barcode <> '' and large_barcode = '" + bar + "' ";
                }
                return script;
            }
            catch
            {
                return "";
            }
        }
        private bool compareGroup()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT 1 from Item_Group where status = 1 and " +
                                                      "group_main = '" + textBox_group_main.Text + "' and " +
                                                      "group_sub = '" + textBox_group_sub.Text + "'";
                        var er = cmd_sqlite.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(er);

                        // ตรวจสอบ กลุ่มสินค้าต้องเหมือนกับที่สร้างไว้
                        if (dt.Rows.Count == 0)
                        {
                            // ไม่มี group
                            MessageBox.Show("กลุ่มสินค้าไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool checkAlert()
        {
            try
            {
                // หน่วยเล็ก ราคาขายน้อยกว่าต้นทุนล่าสุด
                if (Convert.ToDouble(textBox_small_cost_last.Text) > Convert.ToDouble(textBox_small_price.Text) &&
                   Convert.ToDouble(textBox_small_cost_last.Text) > 0 && Convert.ToDouble(textBox_small_qty.Text) > 0)
                {
                    if (MessageBox.Show("ราคาขายน้อยกว่าต้นทุนล่าสุด ต้องการบันทึกใช่หรือไม่ ?", "แจ้งเตือน หน่วยเล็ก", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        return false;
                    }
                }
                // หน่วยเล็ก มีทุนล่าสุดแต่ไม่มีจำนวน // เฉพาะการเพิ่มสินค้า
                if (Convert.ToDouble(textBox_small_cost_last.Text) > 0 &&
                   Convert.ToDouble(textBox_small_qty.Text) == 0 &&
                   !add_save)
                {
                    if (MessageBox.Show("มีต้นทุนล่าสุด แต่ไม่มีจำนวน" + Environment.NewLine + "ต้นทุนล่าสุดจะเปลี่ยนเป็น 0" + Environment.NewLine + "ต้องการบันทึกใช่หรือไม่ ?", "แจ้งเตือน หน่วยเล็ก", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        return false;
                    }
                }
                // หน่วยกลาง มีทุนล่าสุดแต่ไม่มีจำนวน // เฉพาะการเพิ่มสินค้า
                if (textBox_medium_barcode.Text != string.Empty &&
                   Convert.ToDouble(textBox_medium_cost_last.Text) > 0 &&
                   Convert.ToDouble(textBox_medium_qty.Text) == 0 &&
                   !add_save)
                {
                    if (MessageBox.Show("มีต้นทุนล่าสุด แต่ไม่มีจำนวน" + Environment.NewLine + "ต้นทุนล่าสุดจะเปลี่ยนเป็น 0" + Environment.NewLine + "ต้องการบันทึกใช่หรือไม่ ?", "แจ้งเตือน หน่วยกลาง", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        return false;
                    }
                }
                // หน่วยใหญ่ มีทุนล่าสุดแต่ไม่มีจำนวน // เฉพาะการเพิ่มสินค้า
                if (textBox_large_barcode.Text != string.Empty &&
                   Convert.ToDouble(textBox_large_cost_last.Text) > 0 &&
                   Convert.ToDouble(textBox_large_qty.Text) == 0 &&
                   !add_save)
                {
                    if (MessageBox.Show("มีต้นทุนล่าสุด แต่ไม่มีจำนวน" + Environment.NewLine + "ต้นทุนล่าสุดจะเปลี่ยนเป็น 0" + Environment.NewLine + "ต้องการบันทึกใช่หรือไม่ ?", "แจ้งเตือน หน่วยใหญ่", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        return false;
                    }
                }
                // มีบาร์กลาง
                if (textBox_medium_barcode.Text != string.Empty &&
                       Convert.ToDouble(textBox_medium_cost_last.Text) > Convert.ToDouble(textBox_medium_price.Text) &&
                       Convert.ToDouble(textBox_medium_cost_last.Text) > 0 &&
                       Convert.ToDouble(textBox_medium_qty.Text) > 0)
                {

                    if (MessageBox.Show("ราคาขายน้อยกว่าต้นทุนล่าสุด ต้องการบันทึกใช่หรือไม่ ?", "แจ้งเตือน หน่วยกลาง", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        return false;
                    }

                }
                // มีบาร์ใหญ่
                if (textBox_large_barcode.Text != string.Empty &&
                        Convert.ToDouble(textBox_large_cost_last.Text) > Convert.ToDouble(textBox_large_price.Text) &&
                       Convert.ToDouble(textBox_large_cost_last.Text) > 0 &&
                       Convert.ToDouble(textBox_large_qty.Text) > 0)
                {

                    if (MessageBox.Show("ราคาขายน้อยกว่าต้นทุนล่าสุด ต้องการบันทึกใช่หรือไม่ ?", "แจ้งเตือน หน่วยใหญ่", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        return false;
                    }

                }
                // ราคาหน่วยเล็ก = 0
                if (Convert.ToDouble(textBox_small_price.Text) == 0)
                {
                    if (MessageBox.Show("ราคาขาย 0 ต้องการบันทึกใช่หรือไม่ ?", "แจ้งเตือน หน่วยเล็ก", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return false;
                    }
                }
                // มีบาร์กลาง
                if (textBox_medium_barcode.Text != string.Empty &&
                   textBox_medium_price.Text != string.Empty)
                {
                    // ราคาหน่วยกลาง = 0
                    if (Convert.ToDouble(textBox_medium_price.Text) == 0)
                    {
                        if (MessageBox.Show("ราคาขาย 0 ต้องการบันทึกใช่หรือไม่ ?", "แจ้งเตือน หน่วยกลาง", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                    // ราคาขายหน่วยเล็กมากกว่าหน่วยกลาง
                    if (Convert.ToDouble(textBox_small_price.Text) > Convert.ToDouble(textBox_medium_price.Text))
                    {
                        if (MessageBox.Show("ราคาขาย หน่วยเล็ก มากกว่า หน่วยกลาง" + Environment.NewLine + "ต้องการบันทึกใช่หรือไม่ ?", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                    // หน่วยกลางเหมือนกับหน่วยเล็ก
                    if (textBox_small_unit.Text.Trim() == textBox_medium_unit.Text.Trim())
                    {
                        MessageBox.Show("หน่วยกลาง เหมือนกับ หน่วยเล็ก !!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                // มีบาร์ใหญ่
                if (textBox_large_barcode.Text != string.Empty &&
                   textBox_large_price.Text != string.Empty)
                {
                    // ราคาหน่วยใหญ่ = 0
                    if (Convert.ToDouble(textBox_large_price.Text) == 0)
                    {
                        if (MessageBox.Show("ราคาขาย 0 ต้องการบันทึกใช่หรือไม่ ?", "แจ้งเตือน หน่วยใหญ่", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                    // ราคาหน่วยเล็กมากกว่าหน่วยใหญ่
                    if (Convert.ToDouble(textBox_small_price.Text) > Convert.ToDouble(textBox_large_price.Text))
                    {
                        if (MessageBox.Show("ราคาขาย หน่วยเล็ก มากกว่า หน่วยใหญ่" + Environment.NewLine + "ต้องการบันทึกใช่หรือไม่ ?", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                    // ราคาหน่วยกลางมากกว่าหน่วยใหญ่
                    if (Convert.ToDouble(textBox_medium_price.Text) > Convert.ToDouble(textBox_large_price.Text))
                    {
                        if (MessageBox.Show("ราคาขาย หน่วยกลาง มากกว่า หน่วยใหญ่" + Environment.NewLine + "ต้องการบันทึกใช่หรือไม่ ?", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                    // หน่วยใหญ่เหมือนกับหน่วยเล็ก
                    if (textBox_small_unit.Text.Trim() == textBox_large_unit.Text.Trim())
                    {
                        MessageBox.Show("หน่วยใหญ่ เหมือนกับ หน่วยเล็ก !!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    // หน่วยใหญ่เหมือนกับหน่วยกลาง
                    if (textBox_medium_unit.Text.Trim() == textBox_large_unit.Text.Trim())
                    {
                        MessageBox.Show("หน่วยใหญ่ เหมือนกับ หน่วยกลาง !!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // เหลือการเทียบทุน เล็ก กลาง ใหญ่
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void button_status_Click(object sender, EventArgs e)
        {
            try
            {

                if (!edit_save || !add_save) // ถ้าแก้ไข หรือ เพิ่ม
                {
                    System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
                    if (b.Name == "button_item_weight")
                    {
                        if (set_item_weight)
                        {
                            button_item_weight.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));
                            set_item_weight = false;
                        }
                        else
                        {
                            button_item_weight.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                            set_item_weight = true;
                        }
                    }
                    else if (b.Name == "button_effective_promotion")
                    {
                        if (set_effective_promotion)
                        {
                            button_effective_promotion.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));
                            set_effective_promotion = false;
                        }
                        else
                        {
                            button_effective_promotion.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                            set_effective_promotion = true;
                        }
                    }
                    else if (b.Name == "button_sale_vat")
                    {
                        if (set_sale_vat)
                        {
                            button_sale_vat.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));
                            set_sale_vat = false;
                        }
                        else
                        {
                            button_sale_vat.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                            set_sale_vat = true;
                        }
                    }
                    else if (b.Name == "button_effective_member")
                    {
                        if (set_effective_member)
                        {
                            button_effective_member.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));
                            set_effective_member = false;
                        }
                        else
                        {
                            button_effective_member.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                            set_effective_member = true;
                        }
                    }
                    else if (b.Name == "button_sale_negative")
                    {
                        if (set_sale_negative)
                        {
                            button_sale_negative.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));
                            set_sale_negative = false;
                        }
                        else
                        {
                            button_sale_negative.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                            set_sale_negative = true;
                        }
                    }
                    else if (b.Name == "button_effective_hotkey")
                    {
                        if (set_effective_hotkey)
                        {
                            button_effective_hotkey.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));
                            set_effective_hotkey = false;
                        }
                        else
                        {
                            button_effective_hotkey.Image = Class_Image.resizeImage(Ppos.Properties.Resources.check, new Size(40, 40));
                            set_effective_hotkey = true;
                        }
                    }
                }
            }
            catch
            {

            }
        }
        public static Bitmap resizeBitmap(Bitmap bitmaps)
        {
            try
            {
                if (bitmaps.Height > 200)
                {
                    bitmaps = new Bitmap(bitmaps, new Size((bitmaps.Width * 200) / bitmaps.Height, 200));
                }
                return bitmaps;
            }
            catch
            {
                return null!;
            }
        }



        private void stringempty()
        {
            try
            {
                if (add_save)
                {
                    textBox_group_main.Text = "";
                    textBox_group_sub.Text = "";
                }


                textBox_name.Text = "";

                textBox_small_barcode.Text = "";
                textBox_small_unit.Text = "";
                textBox_small_price.Text = "";
                textBox_small_qty.Text = "";
                textBox_small_cost_last.Text = "";
                textBox_small_cost_avg.Text = "";

                textBox_medium_barcode.Text = "";
                textBox_medium_unit.Text = "";
                textBox_medium_price.Text = "";
                textBox_medium_qty.Text = "";
                textBox_medium_cost_last.Text = "";
                textBox_medium_cost_avg.Text = "";
                textBox_medium_qty_small.Text = "";

                textBox_large_barcode.Text = "";
                textBox_large_unit.Text = "";
                textBox_large_price.Text = "";
                textBox_large_qty.Text = "";
                textBox_large_cost_last.Text = "";
                textBox_large_cost_avg.Text = "";
                textBox_large_qty_small.Text = "";

            }
            catch
            {

            }
        }

        private void Enabled(bool e)
        {
            try
            {
                if (e) // ทำการเปิดการแก้ไข
                {
                    textBox_search.Enabled = false;
                    dataGridView_item.Enabled = false;

                    pictureBox_item.Enabled = true;
                    button_edit_picture.Enabled = true;
                    button_camera.Enabled = true;
                    button_delete_picture.Enabled = true;
                    /////////////
                    textBox_group_main.Enabled = true;
                    textBox_group_sub.Enabled = true;
                    textBox_name.Enabled = true;

                    textBox_small_barcode.Enabled = true;
                    textBox_small_unit.Enabled = true;
                    textBox_small_price.Enabled = true;
                    textBox_small_qty.Enabled = true;
                    textBox_small_cost_last.Enabled = true;
                    textBox_small_cost_avg.Enabled = true;

                    textBox_medium_barcode.Enabled = true;
                    textBox_medium_unit.Enabled = true;
                    textBox_medium_price.Enabled = true;
                    textBox_medium_qty.Enabled = true;
                    textBox_medium_cost_last.Enabled = true;
                    textBox_medium_cost_avg.Enabled = true;
                    textBox_medium_qty_small.Enabled = true;

                    textBox_large_barcode.Enabled = true;
                    textBox_large_unit.Enabled = true;
                    textBox_large_price.Enabled = true;
                    textBox_large_qty.Enabled = true;
                    textBox_large_cost_last.Enabled = true;
                    textBox_large_cost_avg.Enabled = true;
                    textBox_large_qty_small.Enabled = true;
                    ///////
                    textBox_group_main.BackColor = Color.White;
                    textBox_group_sub.BackColor = Color.White;
                    textBox_name.BackColor = Color.White;

                    textBox_small_barcode.BackColor = Color.White;
                    textBox_small_unit.BackColor = Color.White;
                    textBox_small_price.BackColor = Color.White;
                    textBox_small_qty.BackColor = Color.White;
                    textBox_small_cost_last.BackColor = Color.White;
                    textBox_small_cost_avg.BackColor = Color.White;

                    textBox_medium_barcode.BackColor = Color.White;
                    textBox_medium_unit.BackColor = Color.White;
                    textBox_medium_price.BackColor = Color.White;
                    textBox_medium_qty.BackColor = Color.White;
                    textBox_medium_cost_last.BackColor = Color.White;
                    textBox_medium_cost_avg.BackColor = Color.White;
                    textBox_medium_qty_small.BackColor = Color.White;

                    textBox_large_barcode.BackColor = Color.White;
                    textBox_large_unit.BackColor = Color.White;
                    textBox_large_price.BackColor = Color.White;
                    textBox_large_qty.BackColor = Color.White;
                    textBox_large_cost_last.BackColor = Color.White;
                    textBox_large_cost_avg.BackColor = Color.White;
                    textBox_large_qty_small.BackColor = Color.White;
                }
                else // ปิดการแก้ไข
                {
                    textBox_search.Enabled = true;
                    dataGridView_item.Enabled = true;

                    // ปิดกล้อง
                    if (start_video)
                    {
                        button_camera_Click(null!, null!);
                    }

                    pictureBox_item.Enabled = false;
                    button_edit_picture.Enabled = false;
                    button_camera.Enabled = false;
                    button_delete_picture.Enabled = false;

                    ////////
                    textBox_group_main.Enabled = false;
                    textBox_group_sub.Enabled = false;
                    textBox_name.Enabled = false;

                    textBox_small_barcode.Enabled = false;
                    textBox_small_unit.Enabled = false;
                    textBox_small_price.Enabled = false;
                    textBox_small_qty.Enabled = false;
                    textBox_small_cost_last.Enabled = false;
                    textBox_small_cost_avg.Enabled = false;

                    textBox_medium_barcode.Enabled = false;
                    textBox_medium_unit.Enabled = false;
                    textBox_medium_price.Enabled = false;
                    textBox_medium_qty.Enabled = false;
                    textBox_medium_cost_last.Enabled = false;
                    textBox_medium_cost_avg.Enabled = false;
                    textBox_medium_qty_small.Enabled = false;

                    textBox_large_barcode.Enabled = false;
                    textBox_large_unit.Enabled = false;
                    textBox_large_price.Enabled = false;
                    textBox_large_qty.Enabled = false;
                    textBox_large_cost_last.Enabled = false;
                    textBox_large_cost_avg.Enabled = false;
                    textBox_large_qty_small.Enabled = false;
                    /////
                    textBox_group_main.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_group_sub.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_name.BackColor = Color.FromArgb(192, 255, 192);

                    textBox_small_barcode.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_small_unit.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_small_price.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_small_qty.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_small_cost_last.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_small_cost_avg.BackColor = Color.FromArgb(192, 255, 192);

                    textBox_medium_barcode.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_medium_unit.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_medium_price.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_medium_qty.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_medium_cost_last.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_medium_cost_avg.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_medium_qty_small.BackColor = Color.FromArgb(192, 255, 192);

                    textBox_large_barcode.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_large_unit.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_large_price.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_large_qty.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_large_cost_last.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_large_cost_avg.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_large_qty_small.BackColor = Color.FromArgb(192, 255, 192);
                }
            }
            catch
            {

            }
        }
        private void button_edit_picture_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "เลือกรูปภาพ : " + textBox_name.Text;
                openFileDialog.Filter = "Image Files|*.png|Image Files|*.jpg";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var bitmaps = new Bitmap(openFileDialog.FileName);
                    var bitmap = resizeBitmap(bitmaps);
                    if (bitmap is not null)
                    {
                        if (System.IO.File.Exists(Form_Login.item_path + @"\master.Png"))
                        {
                            System.IO.File.Delete(Form_Login.item_path + @"\master.Png");
                        }
                        Class_RoundedCorners.CreateRoundedCorners(bitmap, Corners).Save(Form_Login.item_path + @"\master.Png", ImageFormat.Png);

                        pictureBox_item.Image = Class_RoundedCorners.CreateRoundedCorners(bitmap, Corners);
                    }
                    else
                    {
                        pictureBox_item.Image = Ppos.Properties.Resources.picture;
                    }
                }
            }
            catch
            {

            }
        }

        private void button_camera_Click(object sender, EventArgs e)
        {
            try
            {
                button_camera.Enabled = false;
                if (start_video) // เปิดกล้องอยู่ จะปิดกล้อง
                {
                    start_video = false;
                    button_camera.Text = "ถ่ายภาพ";

                    // เปิดปุ่มเลือกภาพ
                    button_edit_picture.Enabled = true;

                    button_delete_picture.Text = "ลบภาพ";
                    button_delete_picture.Image = Class_Image.resizeImage(Ppos.Properties.Resources.exits, new Size(30, 30));

                    // ปิดกล้อง
                    if (Form_Main.videoSource != null && Form_Main.videoSource.IsRunning)
                    {
                        Form_Main.videoSource.SignalToStop(); // ส่งสัญญาณหยุดทำงาน
                        Form_Main.videoSource.WaitForStop();   // รอจนกระทั่งระบบหยุดเคลียร์ Thread ทั้งหมด

                    }
                    // บันทึกภาพเป็น master
                    if (System.IO.File.Exists(Form_Login.item_path + @"\master.Png"))
                    {
                        System.IO.File.Delete(Form_Login.item_path + @"\master.Png");
                    }
                    pictureBox_item.Image!.Save(Form_Login.item_path + @"\master.Png", ImageFormat.Png);




                }
                else // จะเปิดกล้อง
                {
                    start_video = true;
                    button_camera.Text = "บันทึก";

                    button_delete_picture.Text = "หยุด";
                    button_delete_picture.Image = Class_Image.resizeImage(Ppos.Properties.Resources.stop, new Size(35, 35));

                    // ตรวจสอบและปิดการทำงานของกล้องเดิมก่อนถ้ามีการเปิดค้างไว้
                    if (Form_Main.videoSource != null && Form_Main.videoSource.IsRunning)
                    {
                        Form_Main.videoSource.SignalToStop();
                        Form_Main.videoSource.WaitForStop();
                    }

                    // ดึงค่า MonikerString ของกล้องที่เลือกมาใช้งาน

                    if (!string.IsNullOrEmpty(GetMonikerStringByDeviceName(Class_Parameter.device_name)))
                    {
                        Form_Main.videoSource = new VideoCaptureDevice(GetMonikerStringByDeviceName(Class_Parameter.device_name));

                        // ผูก Event ข้อมูลภาพใหม่เข้ากับฟังก์ชันวาดรูป
                        Form_Main.videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                        Form_Main.videoSource.Start(); // เริ่มส่งสัญญาณวิดีโอ
                    }
                    /// ปิดปุ่มเลือกภาพกับลบภาพ
                    button_edit_picture.Enabled = false;
                    // button_delete_picture.Enabled = false;
                }
                button_camera.Enabled = true;
            }
            catch
            {

            }
        }
        private void button_delete_picture_Click(object sender, EventArgs e)
        {
            try
            {

                button_delete_picture.Enabled = false;
                if (start_video)
                {

                    start_video = false;
                    button_camera.Text = "ถ่ายภาพ";

                    // เปิดปุ่มเลือกภาพ
                    button_edit_picture.Enabled = true;

                    button_delete_picture.Text = "ลบภาพ";
                    button_delete_picture.Image = Class_Image.resizeImage(Ppos.Properties.Resources.exits, new Size(30, 30));

                    // ปิดกล้อง
                    if (Form_Main.videoSource != null && Form_Main.videoSource.IsRunning)
                    {
                        Form_Main.videoSource.SignalToStop(); // ส่งสัญญาณหยุดทำงาน
                        Form_Main.videoSource.WaitForStop();   // รอจนกระทั่งระบบหยุดเคลียร์ Thread ทั้งหมด

                    }
                    // ค้นหาภาพ
                    if (System.IO.File.Exists(Form_Login.item_path + @"\" + textBox_small_barcode.Text + ".Png"))
                    {
                        using (FileStream bitmapFile = new FileStream(Form_Login.item_path + @"\" + textBox_small_barcode.Text + ".Png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            pictureBox_item.Image = new Bitmap(bitmapFile);
                        }
                    }
                    else
                    {
                        pictureBox_item.Image = Ppos.Properties.Resources.picture;
                    }
                }
                else
                {
                    // ลบภาพ master
                    if (System.IO.File.Exists(Form_Login.item_path + @"\master.Png"))
                    {
                        System.IO.File.Delete(Form_Login.item_path + @"\master.Png");

                    }
                    else
                    {
                        if (System.IO.File.Exists(Form_Login.item_path + @"\" + dataGridView_item.Rows[dataGridView_item.CurrentRow!.Index].Cells["small_barcode"].Value!.ToString() + ".Png"))
                        {
                            if (MessageBox.Show("ต้องการลบรูปภาพ ใช่หรือไม่ ?", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                System.IO.File.Delete(Form_Login.item_path + @"\" + dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["small_barcode"].Value!.ToString() + ".Png");
                            }
                        }

                    }
                    // ค้นหาภาพ
                    if (System.IO.File.Exists(Form_Login.item_path + @"\" + textBox_small_barcode.Text + ".Png"))
                    {
                        using (FileStream bitmapFile = new FileStream(Form_Login.item_path + @"\" + textBox_small_barcode.Text + ".Png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            pictureBox_item.Image = new Bitmap(bitmapFile);

                        }
                    }
                    else
                    {
                        pictureBox_item.Image = Ppos.Properties.Resources.picture;
                    }
                }
                button_delete_picture.Enabled = true;
            }
            catch
            {

            }
        }

        // ฟังก์ชันทำงานทุกครั้งที่มีเฟรมภาพใหม่ส่งมาจากกล้อง
        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                // โคลนภาพเฟรมปัจจุบันมาแปลงเป็นรูปแบบ Bitmap เพื่อแสดงผล
                Bitmap videoFrame = (Bitmap)eventArgs.Frame.Clone();

                // ภาพซ้าย - ขวาสลับกัน(เหมือนกระจกเงา / Mirror Effect) - เจอบ่อยที่สุดในเว็บแคม
                videoFrame.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // ส่งภาพไปตัดมุมโค้ง (ตัวเลข 30 คือความโค้ง ยิ่งมากยิ่งโค้ง)
                Bitmap roundedFrame = Class_RoundedCorners.CreateRoundedCorners(videoFrame, Corners);

                // คืนหน่วยความจำภาพต้นฉบับทันทีเพื่อประหยัดแรม
                videoFrame.Dispose();

                // แสดงภาพบน PictureBox (จัดการ Thread ปลอดภัยด้วยการเปลี่ยนค่า Image โดยตรง)
                pictureBox_item.Image = roundedFrame;


            }
            catch
            {

            }

        }
        // ฟังก์ชันค้นหา MonikerString ด้วยชื่อกล้อง
        private string GetMonikerStringByDeviceName(string targetDeviceName)
        {
            try
            {
                // ดึงรายการอุปกรณ์วิดีโอทั้งหมดที่เชื่อมต่อกับคอมพิวเตอร์
                FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                // วนลูปค้นหากล้องที่มีชื่อตรงกับที่ระบุ
                foreach (FilterInfo device in videoDevices)
                {
                    if (device.Name.Equals(targetDeviceName, StringComparison.OrdinalIgnoreCase))
                    {
                        return device.MonikerString; // คืนค่า MonikerString เมื่อเจอชื่อที่ตรงกัน
                    }
                }

                return null!; // คืนค่า null หากไม่พบกล้องชื่อนี้
            }
            catch
            {
                return null!; // คืนค่า null หากไม่พบกล้องชื่อนี้
            }

        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
                    if (textBox.Name == "textBox_group_main" && textBox.Text != "")
                    {
                        textBox_group_sub.Focus();
                    }
                    else if (textBox.Name == "textBox_group_sub" && textBox.Text != "")
                    {
                        textBox_name.Focus();
                    }
                    else if (textBox.Name == "textBox_name" && textBox.Text != "")
                    {
                        textBox_small_barcode.Focus();
                    }
                    else if (textBox.Name == "textBox_small_barcode" && textBox.Text != "")
                    {
                        textBox_small_unit.Focus();
                    }
                    else if (textBox.Name == "textBox_small_unit" && textBox.Text != "")
                    {
                        textBox_small_price.Focus();
                    }
                    else if (textBox.Name == "textBox_small_price" && textBox.Text != "")
                    {
                        if (textBox_small_cost_last.Enabled)
                        {
                            textBox_small_cost_last.Focus();
                        }
                        else
                        {
                            textBox_small_qty.Focus();
                        }
                    }
                    else if (textBox.Name == "textBox_small_cost_last" && textBox.Text != "")
                    {
                        textBox_small_qty.Focus();
                    }
                    else if (textBox.Name == "textBox_small_qty" && textBox.Text != "")
                    {
                        if (textBox_small_cost_avg.Enabled)
                        {
                            textBox_small_cost_avg.Focus();
                        }
                        else
                        {
                            textBox_medium_barcode.Focus();
                        }
                    }
                    else if (textBox.Name == "textBox_small_cost_avg" && textBox.Text != "")
                    {
                        textBox_medium_barcode.Focus();
                    }
                    else if (textBox.Name == "textBox_medium_barcode" && textBox.Text != "")
                    {
                        textBox_medium_unit.Focus();
                    }
                    else if (textBox.Name == "textBox_medium_unit" && textBox.Text != "")
                    {
                        textBox_medium_price.Focus();
                    }
                    else if (textBox.Name == "textBox_medium_price" && textBox.Text != "")
                    {
                        if (textBox_medium_cost_last.Enabled)
                        {
                            textBox_medium_cost_last.Focus();
                        }
                        else if (textBox_medium_qty.Enabled)
                        {
                            textBox_medium_qty.Focus();
                        }
                        else if (textBox_medium_cost_avg.Enabled)
                        {
                            textBox_medium_cost_avg.Focus();
                        }
                        else
                        {
                            textBox_medium_qty_small.Focus();
                        }
                    }
                    else if (textBox.Name == "textBox_medium_cost_last" && textBox.Text != "")
                    {
                        textBox_medium_qty.Focus();
                    }
                    else if (textBox.Name == "textBox_medium_qty" && textBox.Text != "")
                    {
                        if (textBox_medium_cost_avg.Enabled)
                        {
                            textBox_medium_cost_avg.Focus();
                        }
                        else
                        {
                            textBox_medium_qty_small.Focus();
                        }
                    }
                    else if (textBox.Name == "textBox_medium_qty_small" && textBox.Text != "")
                    {
                        textBox_large_barcode.Focus();
                    }
                    else if (textBox.Name == "textBox_large_barcode" && textBox.Text != "")
                    {
                        textBox_large_unit.Focus();
                    }
                    else if (textBox.Name == "textBox_large_unit" && textBox.Text != "")
                    {
                        textBox_large_price.Focus();
                    }
                    else if (textBox.Name == "textBox_large_price" && textBox.Text != "")
                    {
                        if (textBox_large_cost_last.Enabled)
                        {
                            textBox_large_cost_last.Focus();
                        }
                        else if (textBox_large_qty.Enabled)
                        {
                            textBox_large_qty.Focus();
                        }
                        else if (textBox_large_cost_avg.Enabled)
                        {
                            textBox_large_cost_avg.Focus();
                        }
                        else
                        {
                            textBox_large_qty_small.Focus();
                        }
                    }
                    else if (textBox.Name == "textBox_large_cost_last" && textBox.Text != "")
                    {
                        textBox_large_qty.Focus();
                    }
                    else if (textBox.Name == "textBox_large_qty" && textBox.Text != "")
                    {
                        if (textBox_large_cost_avg.Enabled)
                        {
                            textBox_large_cost_avg.Focus();
                        }
                        else
                        {
                            textBox_large_qty_small.Focus();
                        }
                    }
                }
            }
            catch
            {

            }
        }
        // ทุนล่าสุดกับทุนเฉลี่ย
        private void textBox_Cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)sender;

                // 1. อนุญาตให้กดตัวเลข, backspace, จุดทศนิยม (.), 
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // 2. อนุญาตให้มีจุดทศนิยม (.) ได้เพียงจุดเดียวเท่านั้น
                if ((e.KeyChar == '.'))
                {
                    if (txt.Text.IndexOf('.') > -1 || txt.SelectionStart == 0)
                    {
                        e.Handled = true;
                    }

                }
                // 4. จำกัดตัวเลขหลังจุดทศนิยมไม่เกิน 2 ตำแหน่ง
                if (char.IsDigit(e.KeyChar))
                {
                    int dotIndex = txt.Text.IndexOf('.');

                    // ตรวจสอบว่ามีจุดทศนิยมแล้ว และเคอร์เซอร์อยู่หลังจุดทศนิยมหรือไม่
                    if (dotIndex > -1 && txt.SelectionStart > dotIndex)
                    {
                        // แยกข้อความหลังจุดทศนิยมมานับจำนวนหลัก โดยตัดข้อความที่ถูกคลุมดำเลือก (Selection) ออกก่อน
                        string postDotText = txt.Text.Substring(dotIndex + 1);

                        // ลบจำนวนตัวอักษรที่กำลังถูกไฮไลท์เลือกอยู่ เพราะผู้ใช้สามารถพิมพ์ทับได้
                        int selectedLengthAfterDot = Math.Max(0, txt.SelectionStart + txt.SelectionLength - (dotIndex + 1))
                                                     - Math.Max(0, txt.SelectionStart - (dotIndex + 1));

                        if ((postDotText.Length - selectedLengthAfterDot) >= 2)
                        {
                            e.Handled = true;
                        }
                    }
                }

            }
            catch
            {

            }
        }
        // ราคาขาย
        private void textBox_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)sender;

                // 1. อนุญาตให้กดตัวเลข, backspace, จุดทศนิยม (.), 
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // 2. อนุญาตให้มีจุดทศนิยม (.) ได้เพียงจุดเดียวเท่านั้น
                if ((e.KeyChar == '.'))
                {
                    if (txt.Text.IndexOf('.') > -1 || txt.SelectionStart == 0)
                    {
                        e.Handled = true;
                    }

                }
                // 4. จำกัดตัวเลขหลังจุดทศนิยมไม่เกิน 2 ตำแหน่ง
                if (char.IsDigit(e.KeyChar))
                {
                    int dotIndex = txt.Text.IndexOf('.');

                    // ตรวจสอบว่ามีจุดทศนิยมแล้ว และเคอร์เซอร์อยู่หลังจุดทศนิยมหรือไม่
                    if (dotIndex > -1 && txt.SelectionStart > dotIndex)
                    {
                        // แยกข้อความหลังจุดทศนิยมมานับจำนวนหลัก โดยตัดข้อความที่ถูกคลุมดำเลือก (Selection) ออกก่อน
                        string postDotText = txt.Text.Substring(dotIndex + 1);

                        // ลบจำนวนตัวอักษรที่กำลังถูกไฮไลท์เลือกอยู่ เพราะผู้ใช้สามารถพิมพ์ทับได้
                        int selectedLengthAfterDot = Math.Max(0, txt.SelectionStart + txt.SelectionLength - (dotIndex + 1))
                                                     - Math.Max(0, txt.SelectionStart - (dotIndex + 1));

                        if ((postDotText.Length - selectedLengthAfterDot) >= 2)
                        {
                            e.Handled = true;
                        }
                    }
                }

            }
            catch
            {

            }
        }
        // จำนวน
        private void textBox_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)sender;

                // 1. อนุญาตให้กดตัวเลข, backspace, จุดทศนิยม (.), และเครื่องหมายลบ (-)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
                {
                    e.Handled = true;
                }

                // 2. อนุญาตให้มีจุดทศนิยม (.) ได้เพียงจุดเดียวเท่านั้น
                if ((e.KeyChar == '.'))
                {
                    if (txt.Text.IndexOf('.') > -1 || txt.SelectionStart == 0 || (txt.Text.Contains("-") && txt.SelectionStart == 1))
                    {
                        e.Handled = true;
                    }

                }

                // 3. อนุญาตให้มีเครื่องหมายลบ (-) ได้ตัวเดียว และต้องอยู่หน้าสุดเท่านั้น
                if (e.KeyChar == '-')
                {
                    // ถ้ามีเครื่องหมายลบอยู่แล้ว หรือเคอร์เซอร์ไม่ได้อยู่ตำแหน่งแรกสุด (index 0) จะกดไม่ได้
                    if (txt.Text.IndexOf('-') > -1 || txt.SelectionStart != 0)
                    {
                        e.Handled = true;
                    }
                }

                // 4. จำกัดตัวเลขหลังจุดทศนิยมไม่เกิน 3 ตำแหน่ง
                if (char.IsDigit(e.KeyChar))
                {
                    int dotIndex = txt.Text.IndexOf('.');

                    // ตรวจสอบว่ามีจุดทศนิยมแล้ว และเคอร์เซอร์อยู่หลังจุดทศนิยมหรือไม่
                    if (dotIndex > -1 && txt.SelectionStart > dotIndex)
                    {
                        // แยกข้อความหลังจุดทศนิยมมานับจำนวนหลัก โดยตัดข้อความที่ถูกคลุมดำเลือก (Selection) ออกก่อน
                        string postDotText = txt.Text.Substring(dotIndex + 1);

                        // ลบจำนวนตัวอักษรที่กำลังถูกไฮไลท์เลือกอยู่ เพราะผู้ใช้สามารถพิมพ์ทับได้
                        int selectedLengthAfterDot = Math.Max(0, txt.SelectionStart + txt.SelectionLength - (dotIndex + 1))
                                                     - Math.Max(0, txt.SelectionStart - (dotIndex + 1));

                        if ((postDotText.Length - selectedLengthAfterDot) >= 3)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void KeyPress_Barcode(object sender, KeyPressEventArgs e)
        {
            try
            {
                // ตรวจสอบว่าคีย์ที่กดเป็น ตัวอักษร, ตัวเลข หรือ ปุ่มลบ (Backspace) หรือไม่
                if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    // ถ้าไม่ใช่ทั้งหมดด้านบน ให้บล็อกคีย์นั้น (ไม่ยอมให้พิมพ์ลงพิมพ์ใน TextBox)
                    e.Handled = true;
                }
            }
            catch
            {

            }
        }
        // บาร์โค้ดกับจำนวนตัวเล็ก
        private void KeyPress_Number(object sender, KeyPressEventArgs e)
        {
            try
            {
                // อนุญาตเฉพาะตัวเลข (0-9) และปุ่ม Control (เช่น Backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // ปฏิเสธปุ่มอื่นๆ ทั้งหมด
                }
            }
            catch
            {

            }
        }
        private void dataGridView_item_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // ตรวจสอบว่าเมาส์ชี้อยู่ในแถวที่มีข้อมูล (ไม่ใช่แถวหัวคอลัมน์ Index -1)
                if (e.RowIndex >= 0)
                {
                    //  dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230); // สีที่ต้องการตอนชี้
                    dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold); // สีที่ต้องการตอนชี้

                }
            }
            catch
            { }
        }

        private void dataGridView_item_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; // สีที่ต้องการตอนไม่ชี้
                    dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular); // สีที่ต้องการตอนชี้

                }
            }
            catch
            { }
        }

        private bool check_delete_item_hotkey()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT i.code " +
                                                   "from item i " +
                                                   "join item_hotkey ih on ih.item_code = i.code " +
                                                   "where i.code = " + dataGridView_item.Rows[dataGridView_item.CurrentRow!.Index].Cells["code"].Value!.ToString();
                        var e = cmd_sqlite.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(e);
                        if (dt.Rows.Count > 0)
                        {

                            MessageBox.Show(
                                   "ไม่สามารถลบสินค้าได้ !!" + Environment.NewLine +
                                   "เป็นสินค้าที่อยู่ในคีย์ลัด",
                                   "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool check_item_pro()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT p.pro_desc " +
                                                   "from Promotion p " +
                                                   "join Promotion_Items pi on pi.pro_id = p.pro_id " +
                                                   "where p.status = 1 and pi.item_code = " + dataGridView_item.Rows[dataGridView_item.CurrentRow!.Index].Cells["code"].Value!.ToString() + " " +
                                                   "UNION " +
                                                   "SELECT p.pro_desc " +
                                                   "from Promotion p " +
                                                   "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                   "where p.status = 1 and pip.item_code = " + dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["code"].Value!.ToString();
                        var e = cmd_sqlite.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(e);
                        if (dt.Rows.Count > 0)
                        {

                            MessageBox.Show(
                                   "ไม่สามารถแก้ไขสินค้าได้ !!" + Environment.NewLine +
                                   "เป็นสินค้าที่อยู่ในโปรโมชั่น" + Environment.NewLine +
                                   "สินค้า : " + dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["name"].Value!.ToString() + Environment.NewLine +
                                   "ชื่อโปร : " + dt.Rows[0]["pro_desc"].ToString(),
                                   "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool check_item_hole()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText =  "SELECT 1 from Invoice_Body_Temp " +
                                                   "where void = false and item_code = " + dataGridView_item.Rows[dataGridView_item.CurrentRow!.Index].Cells["code"].Value!.ToString();
                        var e = cmd_sqlite.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(e);
                        if (dt.Rows.Count > 0)
                        {

                            MessageBox.Show(
                                   "ไม่สามารถแก้ไขสินค้าได้ !!" + Environment.NewLine +
                                   "เป็นสินค้าที่มีการพักบิล" ,
                                   "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void button_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                button.Font = new System.Drawing.Font("Segoe UI", button.Font.Size + 1, button.Font.Style);
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
                button.Font = new System.Drawing.Font("Segoe UI", button.Font.Size - 1, button.Font.Style);
            }
            catch
            {

            }
        }

       
    }
}
