using Ppos.Class;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Printing;
using YourProjectNamespace;


namespace Ppos
{
    public partial class Form_Setting_Invoice : Form
    {
        int count_search, set_search = 2;
        private Class_PdfImageViewer _pdfViewer;
        string text_bold = "ตัวหนา", text_regular = "ตัวบาง", text_show = "แสดง", text_notshow = "ไม่แสดง";
        public Form_Setting_Invoice()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;
                // ผูก Panel และ PictureBox เข้ากับคลาสจัดการ
                _pdfViewer = new Class_PdfImageViewer(panel_invoice, pictureBox_invoice);
                // ปรับขนาด tablelayoutpanel_back
                new TableLayoutResizer(tableLayoutPanel_back, this);
                // ต้องใช้เฉพาะ ใช้ร่วมกดไม่ได้
                EnableDragScroll(panel_set);

                // ตั้งค่า License (จำเป็น)
                QuestPDF.Settings.License = LicenseType.Community;

                string fontRegularPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Font", "Sarabun-Regular.ttf");
                string fontBoldPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Font", "Sarabun-Bold.ttf");

                if (File.Exists(fontRegularPath)) FontManager.RegisterFontFromFile(fontRegularPath);
                if (File.Exists(fontBoldPath)) FontManager.RegisterFontFromFile(fontBoldPath);

                comboBox_print_name.MouseWheel += ComboBox_MouseWheel;

                comboBox_width.Text = Class_Parameter.inv_width.ToString();
                comboBox_margin.Text = Class_Parameter.inv_margin.ToString();
                comboBox_logo_width.Text = Class_Parameter.inv_logo_width.ToString();
                comboBox_width.MouseWheel += ComboBox_MouseWheel;
                comboBox_margin.MouseWheel += ComboBox_MouseWheel;
                comboBox_logo_width.MouseWheel += ComboBox_MouseWheel;

                comboBox_name_fontsize.Text = Class_Parameter.inv_name_fontsize.ToString();
                comboBox_name_bold.Text = (Class_Parameter.inv_name_bold) ? text_bold : text_regular;
                comboBox_name_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_name_bold.MouseWheel += ComboBox_MouseWheel;

                comboBox_address.Text = (Class_Parameter.inv_address) ? text_show : text_notshow;
                comboBox_address_fontsize.Text = Class_Parameter.inv_address_fontsize.ToString();
                comboBox_address_bold.Text = (Class_Parameter.inv_address_bold) ? text_bold : text_regular;
                comboBox_address.MouseWheel += ComboBox_MouseWheel;
                comboBox_address_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_address_bold.MouseWheel += ComboBox_MouseWheel;

                comboBox_tax_id.Text = (Class_Parameter.inv_tax_id) ? text_show : text_notshow;
                comboBox_tax_id_fontsize.Text = Class_Parameter.inv_tax_id_fontsize.ToString();
                comboBox_tax_id_bold.Text = (Class_Parameter.inv_tax_id_bold) ? text_bold : text_regular;
                comboBox_tax_id.MouseWheel += ComboBox_MouseWheel;
                comboBox_tax_id_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_tax_id_bold.MouseWheel += ComboBox_MouseWheel;

                comboBox_phone.Text = (Class_Parameter.inv_phone) ? text_show : text_notshow;
                comboBox_phone_fontsize.Text = Class_Parameter.inv_phone_fontsize.ToString();
                comboBox_phone_bold.Text = (Class_Parameter.inv_phone_bold) ? text_bold : text_regular;
                comboBox_phone.MouseWheel += ComboBox_MouseWheel;
                comboBox_phone_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_phone_bold.MouseWheel += ComboBox_MouseWheel;

                comboBox_type_fontsize.Text = Class_Parameter.inv_type_fontsize.ToString();
                comboBox_type_bold.Text = (Class_Parameter.inv_type_bold) ? text_bold : text_regular;
                comboBox_type_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_type_bold.MouseWheel += ComboBox_MouseWheel;

                comboBox_line.Text = (Class_Parameter.inv_line_point) ? "เส้นจุด" : "เส้นตรง";
                comboBox_line.MouseWheel += ComboBox_MouseWheel;

                comboBox_trx_no_fontsize.Text = Class_Parameter.inv_trx_no_fontsize.ToString();
                comboBox_trx_no_bold.Text = (Class_Parameter.inv_trx_no_bold) ? text_bold : text_regular;
                comboBox_trx_no_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_trx_no_bold.MouseWheel += ComboBox_MouseWheel;

                comboBox_column_size.Text = Class_Parameter.inv_column_size;
                comboBox_column_size.MouseWheel += ComboBox_MouseWheel;

                comboBox_point_0.Text = (Class_Parameter.inv_point_0) ? "มี .00" : "ไม่มี .00";
                comboBox_point_0.MouseWheel += ComboBox_MouseWheel;

                comboBox_head_fontsize.Text = Class_Parameter.inv_head_fontsize.ToString();
                comboBox_head_bold.Text = (Class_Parameter.inv_head_bold) ? text_bold : text_regular;
                comboBox_head_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_head_bold.MouseWheel += ComboBox_MouseWheel;

                comboBox_item_fontsize.Text = Class_Parameter.inv_item_fontsize.ToString();
                comboBox_item_bold.Text = (Class_Parameter.inv_item_bold) ? text_bold : text_regular;
                comboBox_item_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_item_bold.MouseWheel += ComboBox_MouseWheel;

                comboBox_sum_fontsize.Text = Class_Parameter.inv_sum_fontsize.ToString();
                comboBox_sum_bold.Text = (Class_Parameter.inv_sum_bold) ? text_bold : text_regular;
                comboBox_sum_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_sum_bold.MouseWheel += ComboBox_MouseWheel;

                comboBox_net_fontsize.Text = Class_Parameter.inv_net_fontsize.ToString();
                comboBox_net_bold.Text = (Class_Parameter.inv_net_bold) ? text_bold : text_regular;
                comboBox_net_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_net_bold.MouseWheel += ComboBox_MouseWheel;

                comboBox_sum_vat.Text = (Class_Parameter.inv_sum_vat) ? text_show : text_notshow;
                comboBox_sum_vat_fontsize.Text = Class_Parameter.inv_sum_vat_fontsize.ToString();
                comboBox_sum_vat_bold.Text = (Class_Parameter.inv_sum_vat_bold) ? text_bold : text_regular;
                comboBox_sum_vat_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_sum_vat_bold.MouseWheel += ComboBox_MouseWheel;
                comboBox_sum_vat.MouseWheel += ComboBox_MouseWheel;

                comboBox_pro.Text = (Class_Parameter.inv_pro) ? text_show : text_notshow;
                comboBox_pro_head_fontsize.Text = Class_Parameter.inv_pro_head_fontsize.ToString();
                comboBox_pro_head_bold.Text = (Class_Parameter.inv_pro_head_bold) ? text_bold : text_regular;
                comboBox_pro_fontsize.Text = Class_Parameter.inv_pro_fontsize.ToString();
                comboBox_pro_bold.Text = (Class_Parameter.inv_pro_bold) ? text_bold : text_regular;
                comboBox_pro.MouseWheel += ComboBox_MouseWheel;
                comboBox_pro_head_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_pro_head_bold.MouseWheel += ComboBox_MouseWheel;
                comboBox_pro_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_pro_bold.MouseWheel += ComboBox_MouseWheel;

                comboBox_member.Text = (Class_Parameter.inv_member) ? text_show : text_notshow;
                comboBox_member_head_fontsize.Text = Class_Parameter.inv_member_head_fontsize.ToString();
                comboBox_member_head_bold.Text = (Class_Parameter.inv_member_head_bold) ? text_bold : text_regular;
                comboBox_member_fontsize.Text = Class_Parameter.inv_member_fontsize.ToString();
                comboBox_member_bold.Text = (Class_Parameter.inv_member_bold) ? text_bold : text_regular;
                comboBox_member.MouseWheel += ComboBox_MouseWheel;
                comboBox_member_head_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_member_head_bold.MouseWheel += ComboBox_MouseWheel;
                comboBox_member_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_member_bold.MouseWheel += ComboBox_MouseWheel;

                comboBox_bar.Text = Class_Parameter.inv_bar;
                comboBox_bar_fontsize.Text = Class_Parameter.inv_bar_fontsize.ToString();
                comboBox_bar_bold.Text = (Class_Parameter.inv_bar_bold) ? text_bold : text_regular;
                comboBox_bar_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_bar_bold.MouseWheel += ComboBox_MouseWheel;
                comboBox_bar.MouseWheel += ComboBox_MouseWheel;

                comboBox_thank_fontsize.Text = Class_Parameter.inv_thank_fontsize.ToString();
                comboBox_thank_bold.Text = (Class_Parameter.inv_thank_bold) ? text_bold : text_regular;
                comboBox_thank_fontsize.MouseWheel += ComboBox_MouseWheel;
                comboBox_thank_bold.MouseWheel += ComboBox_MouseWheel;
                textBox_thank_desc.Text = Class_Parameter.inv_thank_desc;



            }
            catch
            {
                this.Close();
            }
        }
        /// <summary>
        ///  // ตัวแปรสำหรับจำสถานะ (ใช้ร่วมกันในการลาก)
        public static bool isScrolling = false;
        private static System.Drawing.Point startMousePoint = new System.Drawing.Point(0, 0);
        private static System.Drawing.Point startScrollPoint = new System.Drawing.Point(0, 0);
        private static Panel targetPanel;
        /// </summary>
        /// <param name="panel"></param>
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

        /// <summary>
        /// ผูก Event ให้กับ Control ตัวใหม่ที่เพิ่งเพิ่มเข้ามาทีหลัง
        /// </summary>
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
        private void ComboBox_MouseWheel(object? sender, MouseEventArgs e)
        {
            try
            {
                if (e is HandledMouseEventArgs handledArgs)
                {
                    handledArgs.Handled = true;
                }
            }
            catch
            {

            }
        }
        private void LoadPrintersToComboBox()
        {
            try
            {
                comboBox_print_name.Items.Clear();

                using var printServer = new LocalPrintServer();

                // ดึงเครื่องพิมพ์ทั้งแบบต่อตรง (Local) และผ่านเครือข่าย (Connections)
                var flags = new[] {
                EnumeratedPrintQueueTypes.Local,
                EnumeratedPrintQueueTypes.Connections
            };

                // ดึงชื่อ Default Printer ปัจจุบันของ Windows
                string defaultPrinterName = printServer.DefaultPrintQueue?.Name!;

                comboBox_print_name.Items.Add("ไม่ปริ้น");
                foreach (PrintQueue queue in printServer.GetPrintQueues(flags))
                {
                    comboBox_print_name.Items.Add(queue.Name);
                }
                comboBox_print_name.Text = Class_Parameter.inv_print_name;
                // เลือก Default Printer ให้แสดงบน ComboBox อัตโนมัติ
                /* if (!string.IsNullOrEmpty(defaultPrinterName) && comboBoxPrinters.Items.Contains(defaultPrinterName))
                 {
                     comboBoxPrinters.SelectedItem = defaultPrinterName;
                 }
                 else if (comboBoxPrinters.Items.Count > 0)
                 {
                     comboBoxPrinters.SelectedIndex = 0;
                 }*/
            }
            catch
            {

            }

        }
        private void Form_Setting_Invoice_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPrintersToComboBox();
                // แสดง master

                // textBox_trx_no_TextChanged(sender, e);
                Class_Invoice.gen_trx_no(true, "", "", 0, 0, 0, 0, 0, Class_Parameter.inv_bar).GeneratePdf(Path.Combine(Form_Login.invoice_path, "Master.pdf"));
                _pdfViewer.LoadPdf(Path.Combine(Form_Login.invoice_path, "Master.pdf"), pageIndex: 0, dpi: 200, fitToWindow: true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form_Setting_Invoice_Shown(object sender, EventArgs e)
        {
           
        }
        // ฟังก์ชันแปลง System.Drawing.Image เป็น byte[]
        private void pictureBox_invoice_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                _pdfViewer.FitToWindow();
            }
            catch
            {

            }
        }
        private void panel_invoice_Resize(object sender, EventArgs e)
        {
            try
            {
                _pdfViewer.FitToWindow();
            }
            catch
            {

            }
        }
        private void textBox_trx_no_TextChanged(object sender, EventArgs e)
        {
            try
            {
                count_search = 0;
                timer_search.Start();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form_Setting_Invoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _pdfViewer?.Dispose();
                //  base.OnFormClosed(e);
            }
            catch
            {

            }
        }
        private void timer_search_Tick(object sender, EventArgs e)
        {
            try
            {
                count_search++;
                if (count_search == set_search)
                {
                    count_search = 0;
                    timer_search.Stop();
                    // ลบภาพก่อน
                    if (pictureBox_invoice.Image != null)
                    {
                        pictureBox_invoice.Image.Dispose();
                        pictureBox_invoice.Image = null;
                    }
                    // ลบภาพ master
                    if (System.IO.File.Exists(Form_Login.invoice_path + @"\Master.pdf"))
                    {
                        System.IO.File.Delete(Form_Login.invoice_path + @"\Master.pdf");

                    }
                    // ถ้ามีตัวอักษรใน textbox
                    if (textBox_trx_no.Text != string.Empty)
                    {
                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                        {
                            con_sqlite.Open();
                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                            {


                                cmd_sqlite.CommandText = "SELECT case when ih.status = 'C' then true else false end as status, " +
                                                         "ih.trx_no,ih.id_member ,ih.discount_point,ih.point_increase  ,ih.pay_transfer ,ih.pay_cash ,ih.change " +
                                                         "from Invoice_Head ih where ih.trx_no like '%" + textBox_trx_no.Text.Replace("'", "").Trim() + "%'";
                                SQLiteDataReader er = cmd_sqlite.ExecuteReader();
                                DataTable dt_head = new DataTable();
                                dt_head.Load(er);
                                // ถ้ามีบิลตามที่กรอกใน textbox
                                if (dt_head.Rows.Count > 0)
                                {
                                    int w = pictureBox_invoice.Width, h = pictureBox_invoice.Height;
                                    int x = pictureBox_invoice.Location.X, y = pictureBox_invoice.Location.Y;

                                    Class_Invoice.gen_trx_no(Convert.ToBoolean(dt_head.Rows[0]["status"]),
                                         dt_head.Rows[0]["trx_no"].ToString()!,
                                      dt_head.Rows[0]["id_member"].ToString()!,
                                      Convert.ToInt32(dt_head.Rows[0]["discount_point"]),
                                      Convert.ToInt32(dt_head.Rows[0]["point_increase"]),
                                      Convert.ToDouble(dt_head.Rows[0]["pay_transfer"]),
                                      Convert.ToDouble(dt_head.Rows[0]["pay_cash"]),
                                      Convert.ToDouble(dt_head.Rows[0]["change"]),
                                      Class_Parameter.inv_bar).GeneratePdf(Path.Combine(Form_Login.invoice_path, "Master.pdf"));
                                    _pdfViewer.LoadPdf(Path.Combine(Form_Login.invoice_path, "Master.pdf"), pageIndex: 0, dpi: 200, fitToWindow: true);

                                    pictureBox_invoice.Width = w;
                                    pictureBox_invoice.Height = h;
                                    pictureBox_invoice.Location = new Point(x, y);
                                }
                                // ถ้าไม่มีตามที่กรอก
                                else
                                {
                                    // ให้ไม่มีภาพ
                                }
                            }
                        }
                    }
                    else // ถ้าเป็นค่าว่าง
                    {
                        int w = pictureBox_invoice.Width, h = pictureBox_invoice.Height;
                        int x = pictureBox_invoice.Location.X, y = pictureBox_invoice.Location.Y;
                        // แสดง master
                        Class_Invoice.gen_trx_no(true, "", "", 0, 0, 0, 0, 0, Class_Parameter.inv_bar).GeneratePdf(Path.Combine(Form_Login.invoice_path, "Master.pdf"));
                        _pdfViewer.LoadPdf(Path.Combine(Form_Login.invoice_path, "Master.pdf"), pageIndex: 0, dpi: 200, fitToWindow: true);
                        pictureBox_invoice.Width = w;
                        pictureBox_invoice.Height = h;
                        pictureBox_invoice.Location = new Point(x, y);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox_width_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Class_Parameter.inv_width = float.Parse(comboBox_width.Text);
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_width + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'width'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }

            }
            catch
            {

            }
        }
        private void comboBox_margin_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Class_Parameter.inv_margin = float.Parse(comboBox_margin.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_margin + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'margin'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }


            }
            catch
            {

            }
        }
        private void comboBox_logo_width_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Class_Parameter.inv_logo_width = float.Parse(comboBox_logo_width.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_logo_width + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'logo_width'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }


            }
            catch
            {

            }
        }
        private void comboBox_name_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_name_fontsize = float.Parse(comboBox_name_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_name_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'name_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_name_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_name_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_name_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_name_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'name_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_address_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_address.Text == text_show)
                        {
                            Class_Parameter.inv_address = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_address = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'address'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_address_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_address_fontsize = float.Parse(comboBox_address_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_address_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'address_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_address_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_address_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_address_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_address_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'address_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_tax_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_tax_id.Text == text_show)
                        {
                            Class_Parameter.inv_tax_id = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_tax_id = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'tax_id'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }

        private void comboBox_tax_id_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_tax_id_fontsize = float.Parse(comboBox_tax_id_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_tax_id_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'tax_id_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }

        private void comboBox_tax_id_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_tax_id_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_tax_id_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_tax_id_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'tax_id_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_phone_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_phone.Text == text_show)
                        {
                            Class_Parameter.inv_phone = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_phone = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'phone'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_phone_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_phone_fontsize = float.Parse(comboBox_phone_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_phone_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'phone_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_phone_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_phone_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_phone_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_phone_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'phone_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_type_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_type_fontsize = float.Parse(comboBox_type_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_type_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'type_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_type_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_type_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_type_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_type_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'type_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_line_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_line.Text == "เส้นจุด")
                        {
                            Class_Parameter.inv_line_point = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_line_point = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'line_point'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_trx_no_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_trx_no_fontsize = float.Parse(comboBox_trx_no_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_trx_no_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'trx_no_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_trx_no_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_trx_no_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_trx_no_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_trx_no_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'trx_no_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_head_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_head_fontsize = float.Parse(comboBox_head_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_head_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'head_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_head_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_head_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_head_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_head_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'head_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_column_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        Class_Parameter.inv_column_size = comboBox_column_size.Text;
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_column_size + "', " +
                                             "updated_by = '" + Class_Parameter.User_Login + "', " +
                                            "updated_date = datetime('now', 'localtime') " +
                                            "WHERE title = 'column_size'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_point_0_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        Class_Parameter.inv_point_0 = (comboBox_point_0.Text == "มี .00") ? true : false;
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_point_0 + "', " +
                                             "updated_by = '" + Class_Parameter.User_Login + "', " +
                                            "updated_date = datetime('now', 'localtime') " +
                                            "WHERE title = 'point_0'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_item_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_item_fontsize = float.Parse(comboBox_item_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_item_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'item_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_item_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_item_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_item_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_item_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'item_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_sum_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_sum_fontsize = float.Parse(comboBox_sum_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_sum_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'sum_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_sum_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_sum_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_sum_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_sum_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'sum_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_net_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_net_fontsize = float.Parse(comboBox_net_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_net_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'net_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_net_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_net_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_net_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_net_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'net_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_sum_vat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_sum_vat.Text == text_show)
                        {
                            Class_Parameter.inv_sum_vat = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_sum_vat = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'sum_vat'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_sum_vat_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_sum_vat_fontsize = float.Parse(comboBox_sum_vat_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_sum_vat_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'sum_vat_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_sum_vat_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_sum_vat_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_sum_vat_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_sum_vat_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'sum_vat_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_pro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_pro.Text == text_show)
                        {
                            Class_Parameter.inv_pro = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_pro = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'pro'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_pro_head_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_pro_head_fontsize = float.Parse(comboBox_pro_head_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_pro_head_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'pro_head_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_pro_head_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_pro_head_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_pro_head_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_pro_head_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'pro_head_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_pro_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_pro_fontsize = float.Parse(comboBox_pro_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_pro_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'pro_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_pro_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_pro_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_pro_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_pro_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'pro_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_member_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_member.Text == text_show)
                        {
                            Class_Parameter.inv_member = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_member = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'member'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_member_head_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_member_head_fontsize = float.Parse(comboBox_member_head_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_member_head_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'member_head_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_member_head_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_member_head_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_member_head_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_member_head_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'member_head_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_member_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_member_fontsize = float.Parse(comboBox_member_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_member_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'member_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_member_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_member_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_member_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_member_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'member_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_bar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        Class_Parameter.inv_bar = comboBox_bar.Text;
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_bar + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'bar'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_bar_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_bar_fontsize = float.Parse(comboBox_bar_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_bar_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'bar_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_bar_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_bar_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_bar_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_bar_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'bar_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_thank_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_thank_fontsize = float.Parse(comboBox_thank_fontsize.Text);

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_thank_fontsize + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'thank_fontsize'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void comboBox_thank_bold_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (comboBox_thank_bold.Text == "ตัวหนา")
                        {
                            Class_Parameter.inv_thank_bold = true;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'True', ";
                        }
                        else
                        {
                            Class_Parameter.inv_thank_bold = false;
                            cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = 'False', ";
                        }
                        cmd_sqlite.CommandText += "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'thank_bold'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }
        }
        private void textBox_thank_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Class_Parameter.inv_thank_desc = textBox_thank_desc.Text.Trim().Replace("'", "");
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_thank_desc + "', " +

                                            "updated_by = '" + Class_Parameter.User_Login + "', " +
                                            "updated_date = datetime('now', 'localtime') " +
                                            "WHERE title = 'thank_desc'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                if (pictureBox_invoice.Image != null)
                {
                    count_search = 0;
                    timer_search.Start();
                }
            }
            catch
            {

            }

        }

        private void comboBox_print_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.inv_print_name = comboBox_print_name.Text;

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Set SET desc = '" + Class_Parameter.inv_print_name + "', " +
                                                "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                "updated_date = datetime('now', 'localtime') " +
                                                "WHERE title = 'print_name'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
            }
            catch
            {

            }
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.inv_print_name != string.Empty && Class_Parameter.inv_print_name != "ไม่ปริ้น" && pictureBox_invoice.Image != null)
                {
                    button_print.Enabled = false;
                    backgroundWorker_print.RunWorkerAsync();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button_print.Enabled = true;
            }
        }

        private void backgroundWorker_print_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Class_Invoice.PrintPdfFile(Path.Combine(Form_Login.invoice_path, "Master.pdf"), Class_Parameter.inv_print_name);
            }
            catch
            {

            }
        }

        private void backgroundWorker_print_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                button_print.Enabled = true;
            }
            catch
            {

            }
        }

       
    }
}
