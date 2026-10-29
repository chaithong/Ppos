using Microsoft.Office.Interop.Excel;
using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ppos
{
    public partial class Form_Item_Hotkey : Form
    {
        string set_item_total;
        int set_search = 5, count_set_search = 0;
        System.Data.DataTable dt;
        int Limit = 20; // จำนวนแสดงผล
        int C = 0, R = 0;
        TableLayoutPanel tableLayoutPanel_detail = new TableLayoutPanel();
        System.Windows.Forms.Button button = new System.Windows.Forms.Button();
        bool load = true;

        string set_title;
        PictureBox pictureBox_load_hotkey = new PictureBox();
        private void Form_Item_Hotkey_Resize(object sender, EventArgs e)
        {
            try
            {
              /*  tableLayoutPanel_back_detail.ColumnStyles[1].Width = (this.Width * (100 - Class_Parameter.sale_left_width) / 100) - dataGridView_item.Width;
                tableLayoutPanel_set.ColumnStyles[5].Width = tableLayoutPanel_back_detail.ColumnStyles[1].Width / 2;
                tableLayoutPanel_set.ColumnStyles[6].Width = tableLayoutPanel_back_detail.ColumnStyles[1].Width / 2;

                pictureBox_load_hotkey.Location = new System.Drawing.Point(
                  panel_detail.Location.X + (panel_detail.Width / 2) - (pictureBox_load_hotkey.Width / 2),
                  panel_detail.Location.Y + (panel_detail.Height / 2) - (pictureBox_load_hotkey.Height / 2));*/
            }
            catch
            {

            }
        }
        public Form_Item_Hotkey()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;

                Class_DoubleBuffer.EnableDoubleBuffering(tableLayoutPanel_back);

                panel_detail.Controls.Add(pictureBox_load_hotkey);
                pictureBox_load_hotkey.Size = new Size(200, 200);
                pictureBox_load_hotkey.Image = Ppos.Properties.Resources.load;
                pictureBox_load_hotkey.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox_load_hotkey.BackColor = System.Drawing.Color.Transparent;

              


                button_hotkey_1.Image = Class_Image.resizeImage(Ppos.Properties.Resources.additem, new Size(40, 40));
                button_hotkey_2.Image = Class_Image.resizeImage(Ppos.Properties.Resources.additem, new Size(40, 40));
                button_hotkey_3.Image = Class_Image.resizeImage(Ppos.Properties.Resources.additem, new Size(40, 40));


                dataGridView_item.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_item, true, null);
                foreach (DataGridViewColumn column in dataGridView_item.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_item);
                dataGridView_item.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128, 255, 128);
                dataGridView_item.EnableHeadersVisualStyles = false;

                dataGridView_item.MouseWheel += new MouseEventHandler(dataGridView_item_MouseWheel!);

                button_sort.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Refresh, new Size(40, 40));
                button_delete.Image = Class_Image.resizeImage(Ppos.Properties.Resources.clear, new Size(40, 40));

                // ใส่ข้อความ hotkey
                button_hotkey_1.Text = Class_Parameter.hotkey_title_1;
                button_hotkey_2.Text = Class_Parameter.hotkey_title_2;
                button_hotkey_3.Text = Class_Parameter.hotkey_title_3;

                comboBox_last_back_date.Text = Class_Parameter.hotkey_last_sale_back_date;
                comboBox_last_limit.Text = Class_Parameter.hotkey_last_sale_limit;

                comboBox_hot_back_date.Text = Class_Parameter.hotkey_hot_sale_back_date;
                comboBox_hot_limit.Text = Class_Parameter.hotkey_hot_sale_limit;

                // กำหนดปุ่ม hotkey
                if (Class_Parameter.hotkey_pag == 1)
                {
                    // button_hotkey_1.BackColor = Color.Cyan;
                    button_hotkey_1.FlatStyle = FlatStyle.Standard;
                    button_hotkey_1.ForeColor = Color.Black;

                    set_title = button_hotkey_1.Text;
                    textBox_title.Text = button_hotkey_1.Text;


                }
                else if (Class_Parameter.hotkey_pag == 2)
                {
                    //  button_hotkey_2.BackColor = Color.Cyan;
                    button_hotkey_2.FlatStyle = FlatStyle.Standard;
                    button_hotkey_2.ForeColor = Color.Black;

                    set_title = button_hotkey_2.Text;
                    textBox_title.Text = button_hotkey_2.Text;

                }
                else
                {
                    Class_Parameter.hotkey_pag = 3; // บังคับหน้าสุดท้าย เพราะอาจเป็น 4 5 ขายดี ล่าสุด
                                                    // button_hotkey_3.BackColor = Color.Cyan;
                    button_hotkey_3.FlatStyle = FlatStyle.Standard;
                    button_hotkey_3.ForeColor = Color.Black;

                    set_title = button_hotkey_3.Text;
                    textBox_title.Text = button_hotkey_3.Text;

                }
                // tableLayoutPanel_back_detail.ColumnStyles[1].Width = (this.Width / 2) - dataGridView_item.Width;
                // Class_Scroll_Panel.EnableDragScroll(panel_detail);

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
                                label_search.Text = Convert.ToInt32(reader[0].ToString()).ToString("#,##0");
                            }
                            set_item_total = label_search.Text;
                        }
                    }
                }
                ////////////////////////
                comboBox_column_count.Text = Class_Parameter.column_count.ToString();
                comboBox_row_height.Text = Class_Parameter.row_height.ToString();
                comboBox_font_size.Text = Class_Parameter.font_size.ToString();
                comboBox_image_type.Text = Class_Parameter.image_type.ToString();
                // 🚀 เรียกใช้งานแค่บรรทัดเดียว! ComboBox จะกลายเป็น ComboBox สีทันที
                ColorComboBoxHelper.Initialize(comboBox_button_color);

                ColorComboBoxHelper.SetSelectedColor(comboBox_button_color, Class_Parameter.button_color);

                ColorComboBoxHelper.Initialize(comboBox_font_color);

                ColorComboBoxHelper.SetSelectedColor(comboBox_font_color, Class_Parameter.font_color);

                
                // ต้องใช้เฉพาะ ใช้ร่วมกดไม่ได้
                EnableDragScroll(panel_set);

                Enable(false);
            }
            catch
            {
                this.Close();
            }

        }
        ///  // ตัวแปรสำหรับจำสถานะ (ใช้ร่วมกันในการลาก)
        public static bool isScrolling = false;
        private static System.Drawing.Point startMousePoint = new System.Drawing.Point(0, 0);
        private static System.Drawing.Point startScrollPoint = new System.Drawing.Point(0, 0);
        private static Panel targetPanel;
        public static void EnableDragScroll(Panel panel)
        {
            if (panel == null) return;

            targetPanel = panel;
            targetPanel.AutoScroll = true; // เปิด AutoScroll เสมอ

            // ผูก Event ให้ Panel หลัก
            RegisterEvents(targetPanel);

            // วนลูปผูก Event ให้ทุก Object ย่อยที่อยู่ใน Panel ณ ขณะนั้น
            foreach (Control ctrl in targetPanel.Controls)
            {
                if (ctrl is not DataGridView)
                {
                    RegisterEvents(ctrl);
                    foreach (Control control in ctrl.Controls)
                    {
                        if (control is not DataGridView)
                        {
                            RegisterEvents(control);
                            foreach (Control control2 in control.Controls)
                            {
                                if (control2 is not DataGridView)
                                {
                                    RegisterEvents(control2);
                                    foreach (Control control3 in control2.Controls)
                                    {
                                        if (control3 is not DataGridView)
                                        {
                                            RegisterEvents(control3);
                                        }


                                    }
                                }

                            }
                        }

                    }
                }

            }
        }
        public static void RegisterEvents(Control ctrl)
        {
            if (ctrl == null)
            {
                return;
            }
            // ลบ Event เก่าออกก่อนเพื่อป้องกันการผูกซ้ำ (หากมีการเรียกฟังก์ชันซ้ำ)
            ctrl.MouseDown -= Common_MouseDown!;
            ctrl.MouseMove -= Common_MouseMove!;
            ctrl.MouseUp -= Common_MouseUp!;

            // ผูก Event ใหม่
            ctrl.MouseDown += Common_MouseDown!;
            ctrl.MouseMove += Common_MouseMove!;
            ctrl.MouseUp += Common_MouseUp!;
        }
        private static void Common_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && targetPanel != null)
            {
                isScrolling = true;
                startMousePoint = Cursor.Position;
                startScrollPoint = new System.Drawing.Point(targetPanel.HorizontalScroll.Value, targetPanel.VerticalScroll.Value);
            }
        }
        private static void Common_MouseMove(object sender, MouseEventArgs e)
        {
            if (isScrolling && targetPanel != null)
            {
                int deltaX = Cursor.Position.X - startMousePoint.X;
                int deltaY = Cursor.Position.Y - startMousePoint.Y;

                int newScrollX = startScrollPoint.X - deltaX;
                int newScrollY = startScrollPoint.Y - deltaY;

                if (newScrollX < 0) newScrollX = 0;
                if (newScrollY < 0) newScrollY = 0;

                targetPanel.AutoScrollPosition = new System.Drawing.Point(newScrollX, newScrollY);
            }
        }
        private static void Common_MouseUp(object sender, MouseEventArgs e)
        {
            isScrolling = false;
        }
        private void Enable(bool e)
        {
            try
            {
                dataGridView_item.Enabled = e;
                textBox_search.Enabled = e;
                tableLayoutPanel_set.Enabled = e;
                tableLayoutPanel_set_hotkey.Enabled = e;

                pictureBox_load_hotkey.Visible = !e;
            }
            catch
            {

            }
        }
        private void Form_Item_Hotkey_Shown(object sender, EventArgs e)
        {
            try
            {
                search();

                pictureBox_load_hotkey.Location = new System.Drawing.Point(
                 panel_detail.Location.X + (panel_detail.Width / 2) - (pictureBox_load_hotkey.Width / 2),
                 panel_detail.Location.Y + (panel_detail.Height / 2) - (pictureBox_load_hotkey.Height / 2));

                backgroundWorker_load.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void backgroundWorker_load_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {


                //  tableLayoutPanel_detail.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                for (int i = 0; i < Class_Parameter.column_count; i++)
                {
                    tableLayoutPanel_detail.ColumnCount += 1;
                    tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                }
                tableLayoutPanel_detail.AutoSize = true;
                tableLayoutPanel_detail.Dock = DockStyle.Top;
                tableLayoutPanel_detail.Width = panel_detail.Width;
                tableLayoutPanel_detail.Name = "tableLayoutPanel_detail";
                tableLayoutPanel_detail.RowCount = 1;
                tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, Class_Parameter.row_height));

                // button = new System.Windows.Forms.Button();


                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        /* cmd_sqlite.CommandText = @"SELECT count(id) from Item_Hotkey where pag = " + Class_Parameter.hotkey_pag;
                         var er = cmd_sqlite.ExecuteReader();
                         count_hotkey = new System.Data.DataTable();
                         count_hotkey.Load(er);

                         // มี hotkey
                         if (Convert.ToInt32(count_hotkey.Rows[0][0]) > 0)
                         {
                             // สร้างตาราง
                             cmd_sqlite.CommandText = @"SELECT max(row) from Item_Hotkey where pag = " + Class_Parameter.hotkey_pag;
                             er = cmd_sqlite.ExecuteReader();
                             System.Data.DataTable row = new System.Data.DataTable();
                             row.Load(er);

                             if (Convert.ToInt32(row.Rows[0][0].ToString()) > 0)
                             {
                                 for (int i = 0; i < Convert.ToInt32(row.Rows[0][0].ToString()); i++)
                                 {
                                     tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, Class_Parameter.row_height));
                                 }
                             }
 */

                        // เริ่มสร้างปุ่ม
                        cmd_sqlite.CommandText = @"SELECT  i.small_barcode,i.barcode,i.code,i.group_main,i.group_sub,i.name ,i.unit,i.price ,ih2.column ,ih2.row
                                                    from ( 
                                                    SELECT small_barcode,small_barcode as barcode,code,group_main,group_sub,name,small_unit as unit,small_price as price
                                                    from Item 
                                                    where status = 1                                            
                                                    union all 
                                                    SELECT small_barcode,medium_barcode,code,group_main,group_sub,name,medium_unit,medium_price 
                                                    from Item 
                                                    where status = 1 
                                            
                                                    and medium_barcode <> '' 
                                                    union all 
                                                    SELECT small_barcode,large_barcode,code,group_main,group_sub,name,large_unit,large_price 
                                                    from Item 
                                                    where status = 1                              
                                                    and large_barcode <> '') i 
                                                    join Item_Hotkey ih2 on ih2.item_code = i.code and ih2.barcode = i.barcode ";
                        cmd_sqlite.CommandText += "and pag = " + Class_Parameter.hotkey_pag + " ";
                        cmd_sqlite.CommandText += "order by ih2.row,ih2.column";
                        SQLiteDataReader er = cmd_sqlite.ExecuteReader();
                        dt = new System.Data.DataTable();
                        dt.Load(er);
                        if (dt.Rows.Count > 0)
                        {
                            C = R = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                button = new System.Windows.Forms.Button();
                                tableLayoutPanel_detail.Controls.Add(button, C, R);

                                // button.FlatStyle = FlatStyle.Flat;
                                // button.FlatAppearance.BorderSize = 0;

                                button.Name = dt.Rows[i]["code"].ToString() + "|" + dt.Rows[i]["small_barcode"].ToString() + "|" + dt.Rows[i]["barcode"].ToString();
                                button.Text = dt.Rows[i]["name"].ToString() + " (" + dt.Rows[i]["unit"].ToString() + ")" + Environment.NewLine +
                                    "ราคา : " + dt.Rows[i]["price"].ToString() + " บาท";

                                button_style(button, dt.Rows[i]["small_barcode"].ToString()!);

                                button.MouseUp += Button_MouseUp;
                                button.MouseEnter += Button_MouseEnter;
                                button.MouseLeave += Button_MouseLeave;

                                // เพิ่มจำนวน

                                button_sort.Text = "( " + (Convert.ToInt32(button_sort.Text.Replace("( ", "").Replace(" )", "")) + 1).ToString() + " )";

                                C++;
                                if (C == Class_Parameter.column_count)
                                {
                                    C = 0;
                                    R++;

                                    tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, Class_Parameter.row_height));


                                }


                            }
                        }



                        // }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void backgroundWorker_load_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                tableLayoutPanel_set_hotkey.Visible = true;
                panel_detail.Controls.Add(tableLayoutPanel_detail);
                Class_Scroll_Panel.EnableDragScroll(panel_detail);
                Enable(true);
                load = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void backgroundWorker_sort_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                tableLayoutPanel_detail = new TableLayoutPanel();


                for (int i = 0; i < Class_Parameter.column_count; i++)
                {
                    tableLayoutPanel_detail.ColumnCount += 1;
                    tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                }
                tableLayoutPanel_detail.AutoSize = true;
                tableLayoutPanel_detail.Dock = DockStyle.Top;
                tableLayoutPanel_detail.Width = panel_detail.Width;
                tableLayoutPanel_detail.Name = "tableLayoutPanel_detail";
                tableLayoutPanel_detail.RowCount = 1;
                tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, Class_Parameter.row_height));
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT  i.small_barcode,i.barcode,i.code,i.group_main,i.group_sub,i.name,i.unit,i.price,ih2.column ,ih2.row
                                                    from ( 
                                                    SELECT small_barcode,small_barcode as barcode,code,group_main,group_sub,name,small_unit as unit,small_price as price 
                                                    from Item 
                                                    where status = 1                                                  
                                                    union all 
                                                    SELECT small_barcode,medium_barcode,code,group_main,group_sub,name,medium_unit,medium_price 
                                                    from Item 
                                                    where status = 1                                            
                                                    and medium_barcode <> '' 
                                                    union all 
                                                    SELECT small_barcode,large_barcode,code,group_main,group_sub,name,large_unit,large_price 
                                                    from Item 
                                                    where status = 1                                            
                                                    and large_barcode <> '') i 
                                                    join Item_Hotkey ih2 on ih2.item_code = i.code and ih2.barcode = i.barcode ";
                        cmd_sqlite.CommandText += "and ih2.pag = " + Class_Parameter.hotkey_pag + " ";
                        cmd_sqlite.CommandText += "order by ih2.row,ih2.column";
                        SQLiteDataReader er = cmd_sqlite.ExecuteReader();
                        dt = new System.Data.DataTable();
                        dt.Load(er);
                        if (dt.Rows.Count > 0)
                        {
                            C = R = 0;
                            tableLayoutPanel_detail.Width = panel_detail.Width;
                            button_sort.Text = "( 0 )";
                            // ทำการเรียงใหม่และอัพเดท row column
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                button = new System.Windows.Forms.Button();
                                tableLayoutPanel_detail.Controls.Add(button, C, R);

                                button.Name = dt.Rows[i]["code"].ToString() + "|" + dt.Rows[i]["small_barcode"].ToString() + "|" + dt.Rows[i]["barcode"].ToString();
                                button.Text = dt.Rows[i]["name"].ToString() + " (" + dt.Rows[i]["unit"].ToString() + ")" + Environment.NewLine +
                                    "ราคา : " + dt.Rows[i]["price"].ToString() + " บาท";

                                button_style(button, dt.Rows[i]["small_barcode"].ToString()!);


                                button.MouseUp += Button_MouseUp;
                                button.MouseEnter += Button_MouseEnter;
                                button.MouseLeave += Button_MouseLeave;

                                // update

                                cmd_sqlite.CommandText = "UPDATE Item_HotKey SET " +
                                                    "updated_date = datetime('now', 'localtime'), " +
                                                    "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                    "column = '" + C + "', " +
                                                    "row = '" + R + "' " +
                                                    "WHERE item_code = " + dt.Rows[i]["code"].ToString() + " " +
                                                    "and barcode = '" + dt.Rows[i]["barcode"].ToString() + "' " +
                                                    "and pag = " + Class_Parameter.hotkey_pag;
                                cmd_sqlite.ExecuteNonQuery();

                                C++;
                                if (C == Class_Parameter.column_count)
                                {
                                    C = 0;
                                    R++;

                                    tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, Class_Parameter.row_height));


                                }

                                button_sort.Text = "( " + (Convert.ToInt32(button_sort.Text.Replace("( ", "").Replace(" )", "")) + 1).ToString() + " )";

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

        private void backgroundWorker_sort_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                panel_detail.Controls.Add(tableLayoutPanel_detail);
                tableLayoutPanel_detail.Dock = DockStyle.Top;
                Class_Scroll_Panel.EnableDragScroll(panel_detail);
                textBox_search.Focus();
                Enable(true);
            }
            catch
            {

            }

        }
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
        private void button_style(System.Windows.Forms.Button b, string bar)
        {
            try
            {
                b.Dock = DockStyle.Fill;
                b.UseVisualStyleBackColor = true;
                b.Font = new System.Drawing.Font("Segoe UI", Class_Parameter.font_size, FontStyle.Regular);
                //  b.BackColor = b_backcolor;
                b.BackColor = Color.FromName(Class_Parameter.button_color);
                b.ForeColor = Color.FromName(Class_Parameter.font_color);

                // b.FlatStyle = FlatStyle.Flat;
                // b.FlatAppearance.BorderSize = 0;

                b.Image = null;
                // ค้นหาภาพ
                if (Class_Parameter.image_type != "ไม่มี")
                {
                    if (System.IO.File.Exists(Form_Login.item_path + @"\" + bar + ".Png"))
                    {
                        using (FileStream bitmapFile = new FileStream(Form_Login.item_path + @"\" + bar + ".Png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (Bitmap bitmap = new Bitmap(bitmapFile))
                            {
                                if (Class_Parameter.image_type == "กลาง")
                                {
                                    b.Image = Class_Image.resizeImage(bitmap, new Size((b.Height - 10) * bitmap.Width / bitmap.Height, b.Height - 10));
                                    if (b.Image.Width > b.Width)
                                    {
                                        b.Image = Class_Image.resizeImage(b.Image, new Size(b.Width - 10, (b.Width - 10) * b.Image.Height / b.Image.Width));
                                    }
                                    b.TextImageRelation = TextImageRelation.Overlay;
                                    b.ImageAlign = ContentAlignment.MiddleCenter;
                                    b.TextAlign = ContentAlignment.MiddleCenter;
                                }
                                else if (Class_Parameter.image_type == "บน")
                                {
                                    b.Image = Class_Image.resizeImage(bitmap, new Size(b.Height / 2 * bitmap.Width / bitmap.Height, b.Height / 2));
                                    if (b.Image.Width > b.Width)
                                    {
                                        b.Image = Class_Image.resizeImage(b.Image, new Size(b.Width, b.Width * b.Image.Height / b.Image.Width));
                                    }
                                    b.TextImageRelation = TextImageRelation.ImageAboveText;
                                    b.ImageAlign = ContentAlignment.TopCenter;
                                    b.TextAlign = ContentAlignment.BottomCenter;
                                }
                                else // ด้านซ้าย
                                {
                                    b.Image = Class_Image.resizeImage(bitmap, new Size(b.Width / 2, b.Width / 2 * bitmap.Height / bitmap.Width));
                                    if (b.Image.Height > b.Height)
                                    {
                                        b.Image = Class_Image.resizeImage(b.Image, new Size((b.Height - 10) * (b.Image.Width / b.Image.Height), b.Height - 10));
                                    }
                                    b.TextImageRelation = TextImageRelation.ImageBeforeText;
                                    b.ImageAlign = ContentAlignment.MiddleLeft;
                                    b.TextAlign = ContentAlignment.MiddleLeft;
                                }
                            }
                        }
                    }
                    else
                    {

                        if (Class_Parameter.image_type == "กลาง")
                        {
                            b.Image = Class_Image.resizeImage(Properties.Resources.picture_dark, new Size((b.Height - 10) * Properties.Resources.picture_dark.Width / Properties.Resources.picture_dark.Height, b.Height - 10));
                            if (b.Image.Width > b.Width)
                            {
                                b.Image = Class_Image.resizeImage(Properties.Resources.picture_dark, new Size(b.Width - 10, (b.Width - 10) * b.Image.Height / b.Image.Width));
                            }
                            b.TextImageRelation = TextImageRelation.Overlay;
                            b.ImageAlign = ContentAlignment.MiddleCenter;
                            b.TextAlign = ContentAlignment.MiddleCenter;
                        }
                        else if (Class_Parameter.image_type == "บน")
                        {

                            b.Image = Class_Image.resizeImage(Properties.Resources.picture_dark, new Size(b.Height / 2 * Properties.Resources.picture_dark.Width / Properties.Resources.picture_dark.Height, b.Height / 2));
                            if (b.Image.Width > b.Width)
                            {
                                b.Image = Class_Image.resizeImage(Properties.Resources.picture_dark, new Size(b.Width, b.Width * b.Image.Height / b.Image.Width));

                            }
                            b.TextImageRelation = TextImageRelation.ImageAboveText;
                            b.ImageAlign = ContentAlignment.TopCenter;
                            b.TextAlign = ContentAlignment.BottomCenter;


                        }
                        else // ด้านซ้าย
                        {
                            b.Image = Class_Image.resizeImage(Properties.Resources.picture_dark, new Size(b.Width / 2, b.Width / 2 * Properties.Resources.picture_dark.Height / Properties.Resources.picture_dark.Width));
                            if (b.Image.Height > b.Height)
                            {
                                b.Image = Class_Image.resizeImage(Properties.Resources.picture_dark, new Size((b.Height - 10) * b.Image.Width / b.Image.Height, b.Height - 10));
                            }
                            b.TextImageRelation = TextImageRelation.ImageBeforeText;
                            b.ImageAlign = ContentAlignment.MiddleLeft;
                            b.TextAlign = ContentAlignment.MiddleLeft;
                        }

                    }
                }
                else
                {
                    b.TextImageRelation = TextImageRelation.Overlay;
                    b.ImageAlign = ContentAlignment.MiddleCenter;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void create_new_hotkey(int e)
        {
            try
            {
                button = new System.Windows.Forms.Button();
                C = R = 0;

                while (true)
                {
                    if (tableLayoutPanel_detail.GetControlFromPosition(C, R) is null)
                    {

                        tableLayoutPanel_detail.Controls.Add(button, C, R);

                        button.Name = dataGridView_item.Rows[e].Cells["code"].Value!.ToString() + "|" + dataGridView_item.Rows[e].Cells["small_barcode"].Value!.ToString() + "|" + dataGridView_item.Rows[e].Cells["barcode"].Value!.ToString();
                        button.Text = dataGridView_item.Rows[e].Cells["name"].Value!.ToString() + " (" + dataGridView_item.Rows[e].Cells["unit"].Value!.ToString() + ")" + Environment.NewLine +
                            "ราคา : " + dataGridView_item.Rows[e].Cells["price"].Value!.ToString() + " บาท";

                        button_style(button, dataGridView_item.Rows[e].Cells["small_barcode"].Value!.ToString()!);


                        button.MouseUp += Button_MouseUp;
                        button.MouseEnter += Button_MouseEnter;
                        button.MouseLeave += Button_MouseLeave;

                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                        {
                            con_sqlite.Open();
                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                            {
                                cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey (created_by,created_date,updated_by,updated_date,pag,item_code,small_barcode,barcode,column,row)
                                                   VALUES('" + Class_Parameter.User_Login + "',datetime('now', 'localtime'), '', ''," + Class_Parameter.hotkey_pag + ",'" + button.Name.Split("|")[0] + "','" + button.Name.Split("|")[1] + "','" + button.Name.Split("|")[2] + "'," + C + "," + R + " )";
                                cmd_sqlite.ExecuteNonQuery();
                            }
                        }
                        // เพิ่มจำนวน
                        button_sort.Text = "( " + (Convert.ToInt32(button_sort.Text.Replace("( ", "").Replace(" )", "")) + 1).ToString() + " )";

                        Class_Scroll_Panel.EnableDragScroll(panel_detail);
                        search();
                        break;
                    }

                    C++;
                    if (C == Class_Parameter.column_count)
                    {
                        C = 0;
                        R++;

                        tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, Class_Parameter.row_height));


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button_MouseUp(object? sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender!;
                    button.Dispose();


                    // ลบใน DB
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            cmd_sqlite.CommandText = @"DELETE from Item_Hotkey where item_code = " + button.Name.Split("|")[0] + " and barcode = '" + button.Name.Split("|")[2] + "'";
                            cmd_sqlite.ExecuteNonQuery();
                        }
                    }
                    // ลบจำนวน
                    button_sort.Text = "( " + (Convert.ToInt32(button_sort.Text.Replace("( ", "").Replace(" )", "")) - 1).ToString() + " )";
                    search();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                timer_search.Stop();
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                timer_search.Stop();
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        cmd_sqlite.CommandText = script();
                        var er = cmd_sqlite.ExecuteReader();
                        dt = new System.Data.DataTable();
                        dt.Load(er);

                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dataGridView_item.Rows.Add(
                                     dt.Rows[i]["small_barcode"].ToString()!,
                                   dt.Rows[i]["barcode"].ToString()!,
                                   dt.Rows[i]["code"].ToString()!,
                                   dt.Rows[i]["group_main"].ToString()!,
                                   dt.Rows[i]["group_sub"].ToString()!,
                                   dt.Rows[i]["name"].ToString()!,
                                   dt.Rows[i]["unit"].ToString()!,
                                   dt.Rows[i]["price"].ToString()!
                                    );


                            }

                        }
                    }
                    con_sqlite.Close();
                }
                // นับจำนวนค้นหา
                label_search.Text = set_item_total;
                if (dt.Rows.Count > 0)
                {
                    label_search.Text = dt.Rows.Count.ToString("#,##0") + " / " + set_item_total;
                }
                dataGridView_item.ClearSelection();
                textBox_search.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string script()
        {
            try
            {
                string script;
                script = "SELECT i.small_barcode,i.barcode,i.code,i.group_main,i.group_sub,i.name,i.unit ,i.price " +
                         "from ( " +
                         "SELECT small_barcode,small_barcode as barcode,code,group_main,group_sub,name,small_unit as unit,small_price as price " +
                         "from Item " +
                         "where status = 1 and effective_hotkey = 1 ";
                if (textBox_search.Text != "")
                {
                    script += "and (name like '%" + textBox_search.Text + "%' or small_barcode like '%" + textBox_search.Text + "%' ) ";
                }
                script += "union all " +
                          "SELECT small_barcode, medium_barcode,code,group_main,group_sub,name,medium_unit,medium_price " +
                          "from Item " +
                          "where status = 1 and effective_hotkey = 1 " +
                          "and medium_barcode <> '' ";
                if (textBox_search.Text != "")
                {
                    script += "and (name like '%" + textBox_search.Text + "%' or medium_barcode like '%" + textBox_search.Text + "%' ) ";
                }
                script += "union all " +
                          "SELECT small_barcode, large_barcode,code,group_main,group_sub,name,large_unit,large_price " +
                          "from Item " +
                          "where status = 1 and effective_hotkey = 1 " +
                          "and large_barcode <> ''";
                if (textBox_search.Text != "")
                {
                    script += "and (name like '%" + textBox_search.Text + "%' or large_barcode like '%" + textBox_search.Text + "%' ) ";
                }

                script += ") i where i.barcode not in(select ih.barcode from Item_Hotkey ih) order by code desc ";
                if (Limit > 0)
                {
                    script += "limit " + Limit;
                }
                return script;
            }
            catch
            {
                return null!;
            }
        }
        private void dataGridView_item_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    dataGridView_item.Rows[e.RowIndex].Cells["name"].Style.Font = new System.Drawing.Font("Segoe UI", 13.8F, FontStyle.Bold); // สีที่ต้องการตอนชี้

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView_item_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    dataGridView_item.Rows[e.RowIndex].Cells["name"].Style.Font = new System.Drawing.Font("Segoe UI", 13.8F, FontStyle.Regular); // สีที่ต้องการตอนชี้

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool mouseMove = false, mouseDown = false;
        private void dataGridView_item_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                mouseDown = true;
            }
            catch
            {

            }
        }

        private void dataGridView_item_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (mouseDown)
                {
                    mouseMove = true;
                }


            }
            catch
            {

            }
        }
        private void dataGridView_item_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (!mouseMove)
                {
                    Enable(false);
                    create_new_hotkey(e.RowIndex);
                    Enable(true);
                }
                mouseDown = false;
                mouseMove = false;

            }
            catch
            {

            }
        }
        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender!;
                button.Font = new System.Drawing.Font("Segoe UI", Class_Parameter.font_size, FontStyle.Bold); // สีที่ต้องการตอนชี้
                                                                                                              // button.ForeColor = Color.;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender!;
                button.Font = new System.Drawing.Font("Segoe UI", Class_Parameter.font_size, FontStyle.Regular); // 
                                                                                                                 //  button.ForeColor = Color.FromName(Class_Parameter.font_color);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox_column_count_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (!load)
                {
                    // ถ้าไม่ใช่เลขเดิม
                    if (Convert.ToInt16(comboBox_column_count.Text) != Class_Parameter.column_count)
                    {
                        if (Convert.ToInt16(comboBox_column_count.Text) < Class_Parameter.column_count)
                        {
                            tableLayoutPanel_detail.ColumnCount -= (Class_Parameter.column_count - Convert.ToInt16(comboBox_column_count.Text));


                        }
                        else
                        {

                            tableLayoutPanel_detail.ColumnCount += Convert.ToInt16(comboBox_column_count.Text) - Class_Parameter.column_count;

                            for (int i = 0; i < Class_Parameter.column_count; i++)
                            {
                                tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                            }

                        }
                        // เรียงปุ่มใหม่
                        Class_Parameter.column_count = tableLayoutPanel_detail.ColumnCount;
                        button_sort_Click(sender, e);

                        // update set
                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                        {
                            con_sqlite.Open();
                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                            {
                                cmd_sqlite.CommandText = "UPDATE Item_HotKey_Set SET " +
                                                         "updated_date = datetime('now', 'localtime'), " +
                                                         "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                         "Value = '" + comboBox_column_count.Text + "' " +
                                                         "WHERE title = 'column_count' ";
                                cmd_sqlite.ExecuteNonQuery();
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
        private void comboBox_row_height_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!load)
                {
                    if (float.Parse(comboBox_row_height.Text) != Class_Parameter.row_height)
                    {
                        Class_Parameter.row_height = float.Parse(comboBox_row_height.Text);

                        backgroundWorker_row_height.RunWorkerAsync();

                    }
                }

            }
            catch
            {
                tableLayoutPanel_detail.Visible = true;
            }
        }
        private void backgroundWorker_row_height_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                foreach (RowStyle style in tableLayoutPanel_detail.RowStyles)
                {
                    // style.SizeType = SizeType.Absolute;
                    style.Height = Class_Parameter.row_height; // ปรับความสูง ทุกแถว
                }
                Enable(false);
                tableLayoutPanel_detail.Visible = false;
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        foreach (Control control in tableLayoutPanel_detail.Controls)
                        {
                            if (control is System.Windows.Forms.Button)
                            {
                                System.Windows.Forms.Button btn = (System.Windows.Forms.Button)control;

                                cmd_sqlite.CommandText = "SELECT i.small_barcode  FROM Item i  WHERE i.code = " + btn.Name.Split("|")[0];
                                var er = cmd_sqlite.ExecuteReader();
                                dt = new System.Data.DataTable();
                                dt.Load(er);
                                button_style(btn, dt.Rows[0]["small_barcode"].ToString()!);

                            }
                        }


                        // update set

                        cmd_sqlite.CommandText = "UPDATE Item_HotKey_Set SET " +
                                                 "updated_date = datetime('now', 'localtime'), " +
                                                 "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                 "Value = '" + comboBox_row_height.Text + "' " +
                                                 "WHERE title = 'row_height' ";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void backgroundWorker_row_height_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                label_row_height.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Regular);
                tableLayoutPanel_detail.Visible = true;
                Enable(true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox_font_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Enable(false);
                if (!load)
                {
                    if (float.Parse(comboBox_font_size.Text) != Class_Parameter.font_size)
                    {
                        foreach (Control control in tableLayoutPanel_detail.Controls)
                        {
                            if (control is System.Windows.Forms.Button)
                            {
                                System.Windows.Forms.Button btn = (System.Windows.Forms.Button)control;
                                Class_Parameter.font_size = float.Parse(comboBox_font_size.Text);
                                btn.Font = new System.Drawing.Font("Segoe UI", Class_Parameter.font_size, FontStyle.Regular);




                            }
                        }
                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                        {
                            con_sqlite.Open();
                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                            {
                                // update set

                                cmd_sqlite.CommandText = "UPDATE Item_HotKey_Set SET " +
                                                         "updated_date = datetime('now', 'localtime'), " +
                                                         "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                         "Value = '" + comboBox_font_size.Text + "' " +
                                                         "WHERE title = 'font_size' ";
                                cmd_sqlite.ExecuteNonQuery();
                            }
                        }
                    }
                }
                Enable(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox_image_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!load)
                {
                    if (comboBox_image_type.Text != Class_Parameter.image_type)
                    {
                        Class_Parameter.image_type = comboBox_image_type.Text;
                        button_sort_Click(sender, e);
                        // update set
                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                        {
                            con_sqlite.Open();
                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                            {
                                // update set

                                cmd_sqlite.CommandText = "UPDATE Item_HotKey_Set SET " +
                                                         "updated_date = datetime('now', 'localtime'), " +
                                                         "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                         "Value = '" + comboBox_image_type.Text + "' " +
                                                         "WHERE title = 'image_type' ";
                                cmd_sqlite.ExecuteNonQuery();
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

        private void comboBox_button_color_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (!load)
                {
                    if (Color.FromName(Class_Parameter.button_color).Name != ColorComboBoxHelper.GetSelectedColor(comboBox_button_color).Name)
                    {

                        Class_Parameter.button_color = ColorComboBoxHelper.GetSelectedColor(comboBox_button_color).Name;
                        button_sort_Click(sender, e);

                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                        {
                            con_sqlite.Open();
                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                            {
                                // update set

                                cmd_sqlite.CommandText = "UPDATE Item_HotKey_Set SET " +
                                                         "updated_date = datetime('now', 'localtime'), " +
                                                         "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                         "Value = '" + Class_Parameter.button_color + "' " +
                                                         "WHERE title = 'button_color' ";
                                cmd_sqlite.ExecuteNonQuery();
                            }
                        }

                    }
                }

                // Enable(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox_font_color_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (!load)
                {
                    if (Color.FromName(Class_Parameter.font_color).Name != ColorComboBoxHelper.GetSelectedColor(comboBox_font_color).Name)
                    {
                        Class_Parameter.font_color = ColorComboBoxHelper.GetSelectedColor(comboBox_font_color).Name;
                        button_sort_Click(sender, e);
                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                        {
                            con_sqlite.Open();
                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                            {
                                // update set

                                cmd_sqlite.CommandText = "UPDATE Item_HotKey_Set SET " +
                                                         "updated_date = datetime('now', 'localtime'), " +
                                                         "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                         "Value = '" + Class_Parameter.font_color + "' " +
                                                         "WHERE title = 'font_color' ";
                                cmd_sqlite.ExecuteNonQuery();
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
        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (button_sort.Text != "( 0 )")
                {

                    if (MessageBox.Show("ต้องการลบคีย์ลัดทั้งหมด ใช่หรือไม่ ?", "แจ้งเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        // ลบคอนโทรลทั้งหมดออกจากตาราง และทำลายหน่วยความจำ (Dispose) คอนโทรลเหล่านั้นด้วย
                        while (tableLayoutPanel_detail.Controls.Count > 0)
                        {
                            tableLayoutPanel_detail.Controls[0].Dispose();
                        }
                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                        {
                            con_sqlite.Open();
                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                            {
                                cmd_sqlite.CommandText = "DELETE FROM Item_HotKey where pag = " + Class_Parameter.hotkey_pag;
                                cmd_sqlite.ExecuteNonQuery();
                            }
                        }
                        search();
                        // เครียจำนวน
                        button_sort.Text = "( 0 )";
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_sort_Click(object sender, EventArgs e)
        {
            try
            {
                Enable(false);
                button_sort.Text = "( 0 )";
                sort_hotkey();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void sort_hotkey()
        {
            try
            {

                for (int i = panel_detail.Controls.Count - 1; i >= 0; i--)
                {
                    // นำคอนโทรลออกมาแล้วสั่งทำลายทิ้งจากหน่วยความจำ
                    panel_detail.Controls[i].Dispose();
                }
                panel_detail.Controls.Clear();

                pictureBox_load_hotkey = new PictureBox();
                panel_detail.Controls.Add(pictureBox_load_hotkey);
                pictureBox_load_hotkey.Size = new Size(200, 200);
                pictureBox_load_hotkey.Image = Ppos.Properties.Resources.load;
                pictureBox_load_hotkey.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox_load_hotkey.BackColor = System.Drawing.Color.Transparent;

                pictureBox_load_hotkey.Location = new System.Drawing.Point(
              panel_detail.Location.X + (panel_detail.Width / 2) - (pictureBox_load_hotkey.Width / 2),
              panel_detail.Location.Y + (panel_detail.Height / 2) - (pictureBox_load_hotkey.Height / 2));

                backgroundWorker_sort.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_Delete_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                // button_delete.Image = Class_Image.resizeImage(Ppos.Properties.Resources.trash, new Size(50, 50)); // สีที่ต้องการตอนชี้
                button_delete.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold); // 
            }
            catch
            {

            }
        }

        private void Button_Delete_MouseLeave(object sender, EventArgs e)
        {
            try
            {

                // button_delete.Image = Class_Image.resizeImage(Ppos.Properties.Resources.trash, new Size(40, 40)); //
                button_delete.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Regular); // 

            }
            catch
            {

            }
        }

        private void Button_Sort_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                // button_sort.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Refresh, new Size(60, 60));
                button_sort.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold); // 
            }
            catch
            {

            }
        }

        private void Button_Sort_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                // button_sort.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Refresh, new Size(50, 50));
                button_sort.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Regular); // 
            }
            catch
            {

            }
        }

        private void hotkey_click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
                if (b.Name == "button_hotkey_1" && Class_Parameter.hotkey_pag != 1) // 1
                {
                    Class_Parameter.hotkey_pag = 1;

                    button_hotkey_1.FlatStyle = FlatStyle.Standard;
                    //button_hotkey_1.BackColor = Color.White;
                    button_hotkey_1.ForeColor = Color.Black;

                    button_hotkey_2.FlatStyle = FlatStyle.Flat;
                    // button_hotkey_2.BackColor = Color.White;
                    button_hotkey_2.ForeColor = Color.Gray;

                    button_hotkey_3.FlatStyle = FlatStyle.Flat;
                    // button_hotkey_3.BackColor = Color.White;
                    button_hotkey_3.ForeColor = Color.Gray;

                    set_title = button_hotkey_1.Text;
                    textBox_title.Text = button_hotkey_1.Text;


                    button_sort_Click(sender, e);

                }
                else if (b.Name == "button_hotkey_2" && Class_Parameter.hotkey_pag != 2) // 2
                {
                    Class_Parameter.hotkey_pag = 2;

                    button_hotkey_1.FlatStyle = FlatStyle.Flat;
                    // button_hotkey_1.BackColor = Color.White;
                    button_hotkey_1.ForeColor = Color.Gray;

                    button_hotkey_2.FlatStyle = FlatStyle.Standard;
                    // button_hotkey_2.BackColor = Color.Cyan;
                    button_hotkey_2.ForeColor = Color.Black;

                    button_hotkey_3.FlatStyle = FlatStyle.Flat;
                    // button_hotkey_3.BackColor = Color.White;
                    button_hotkey_3.ForeColor = Color.Gray;

                    set_title = button_hotkey_2.Text;
                    textBox_title.Text = button_hotkey_2.Text;


                    button_sort_Click(sender, e);
                }
                else if (b.Name == "button_hotkey_3" && Class_Parameter.hotkey_pag != 3)// 3
                {
                    Class_Parameter.hotkey_pag = 3;

                    button_hotkey_1.FlatStyle = FlatStyle.Flat;
                    // button_hotkey_1.BackColor = Color.White;
                    button_hotkey_1.ForeColor = Color.Gray;

                    button_hotkey_2.FlatStyle = FlatStyle.Flat;
                    // button_hotkey_2.BackColor = Color.White;
                    button_hotkey_2.ForeColor = Color.Gray;

                    button_hotkey_3.FlatStyle = FlatStyle.Standard;
                    // button_hotkey_3.BackColor = Color.Cyan;
                    button_hotkey_3.ForeColor = Color.Black;

                    set_title = button_hotkey_3.Text;
                    textBox_title.Text = button_hotkey_3.Text;


                    button_sort_Click(sender, e);
                }
            }
            catch
            {

            }
        }

        private void hotkey_enter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
                b.Font = new System.Drawing.Font(b.Font.FontFamily, b.Font.Size + 2, FontStyle.Bold);


            }
            catch
            {

            }
        }

        private void hotkey_leave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
                b.Font = new System.Drawing.Font(b.Font.FontFamily, b.Font.Size - 2, FontStyle.Regular);

            }
            catch
            {

            }
        }
        int count_save_title, set_save_title = 5;
        private void textBox_title_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_title.Text != set_title)
                {

                    timer_title.Start();
                }
                else
                {

                    timer_title.Stop();
                    count_save_title = 0;
                }
            }
            catch
            {
                timer_search.Stop();
            }
        }
        private void timer_title_Tick(object sender, EventArgs e)
        {
            try
            {
                count_save_title++;
                if (count_save_title == set_save_title)
                {
                    timer_title.Stop();
                    count_save_title = 0;
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {

                            if (Class_Parameter.hotkey_pag == 1)
                            {

                                // update
                                cmd_sqlite.CommandText = "UPDATE Item_Hotkey_Set SET " +
                                                         "updated_date = datetime('now', 'localtime'), " +
                                                         "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                         "value = '" + textBox_title.Text.Trim() + "' " +
                                                         "where title = 'hotkey_title_1'";

                                button_hotkey_1.Text = textBox_title.Text.Trim();
                                Class_Parameter.hotkey_title_1 = textBox_title.Text.Trim();
                            }
                            else if (Class_Parameter.hotkey_pag == 2)
                            {

                                // update
                                cmd_sqlite.CommandText = "UPDATE Item_Hotkey_Set SET " +
                                                         "updated_date = datetime('now', 'localtime'), " +
                                                         "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                         "value = '" + textBox_title.Text.Trim() + "' " +
                                                         "where title = 'hotkey_title_2'";
                                button_hotkey_2.Text = textBox_title.Text.Trim();
                                Class_Parameter.hotkey_title_2 = textBox_title.Text.Trim();
                            }
                            else if (Class_Parameter.hotkey_pag == 3)
                            {

                                // update
                                cmd_sqlite.CommandText = "UPDATE Item_Hotkey_Set SET " +
                                                         "updated_date = datetime('now', 'localtime'), " +
                                                         "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                         "value = '" + textBox_title.Text.Trim() + "' " +
                                                         "where title = 'hotkey_title_3'";
                                button_hotkey_3.Text = textBox_title.Text.Trim();
                                Class_Parameter.hotkey_title_3 = textBox_title.Text.Trim();
                            }

                            cmd_sqlite.ExecuteNonQuery();
                            set_title = textBox_title.Text;

                        }
                    }
                }
            }
            catch
            {
                timer_search.Stop();
            }
        }


        private void label_enter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label l = (System.Windows.Forms.Label)sender;
                l.Font = new System.Drawing.Font(l.Font.FontFamily, l.Font.Size, FontStyle.Bold);
            }
            catch
            {

            }
        }

        private void label_leave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label l = (System.Windows.Forms.Label)sender;
                l.Font = new System.Drawing.Font(l.Font.FontFamily, l.Font.Size, FontStyle.Regular);
            }
            catch
            {

            }
        }

        private void textBox_title_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\'')
                {
                    // สั่งให้ระบบมองว่าจัดการปุ่มนี้แล้ว (ทำให้ตัวอักษรไม่แสดงใน TextBox)
                    e.Handled = true;
                }
            }
            catch
            {

            }
        }

        private void comboBox_last_back_date_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // update
                        cmd_sqlite.CommandText = "UPDATE Item_Hotkey_Set SET " +
                                                 "updated_date = datetime('now', 'localtime'), " +
                                                 "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                 "value = '" + comboBox_last_back_date.Text + "' " +
                                                 "where title = 'hotkey_last_sale_back_date'";
                        cmd_sqlite.ExecuteNonQuery();
                        Class_Parameter.hotkey_last_sale_back_date = comboBox_last_back_date.Text;
                    }
                }

            }
            catch
            {

            }
        }

        private void comboBox_last_limit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // update
                        cmd_sqlite.CommandText = "UPDATE Item_Hotkey_Set SET " +
                                                 "updated_date = datetime('now', 'localtime'), " +
                                                 "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                 "value = '" + comboBox_last_limit.Text + "' " +
                                                 "where title = 'hotkey_last_sale_limit'";
                        cmd_sqlite.ExecuteNonQuery();
                        Class_Parameter.hotkey_last_sale_limit = comboBox_last_limit.Text;
                    }
                }
            }
            catch
            {

            }
        }

        private void comboBox_hot_back_date_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // update
                        cmd_sqlite.CommandText = "UPDATE Item_Hotkey_Set SET " +
                                                 "updated_date = datetime('now', 'localtime'), " +
                                                 "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                 "value = '" + comboBox_hot_back_date.Text + "' " +
                                                 "where title = 'hotkey_hot_sale_back_date'";
                        cmd_sqlite.ExecuteNonQuery();
                        Class_Parameter.hotkey_hot_sale_back_date = comboBox_hot_back_date.Text;
                    }
                }
            }
            catch
            {

            }
        }

        private void comboBox_hot_limit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // update
                        cmd_sqlite.CommandText = "UPDATE Item_Hotkey_Set SET " +
                                                 "updated_date = datetime('now', 'localtime'), " +
                                                 "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                 "value = '" + comboBox_hot_limit.Text + "' " +
                                                 "where title = 'hotkey_hot_sale_limit'";
                        cmd_sqlite.ExecuteNonQuery();
                        Class_Parameter.hotkey_hot_sale_limit = comboBox_hot_limit.Text;
                    }
                }
            }
            catch
            {

            }
        }
    }
}
