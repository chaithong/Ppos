using AForge.Video;
using AForge.Video.DirectShow;
using Hardware.Info;
using Ppos.Class;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Main : Form
    {
        CultureInfo cultures = new CultureInfo("en-US");
        bool show_menu = false;
        Button b = new Button();
        Panel P;
        int P_Height;

        // ประกาศตัวแปรสำหรับเก็บรายชื่อกล้องและตัวควบคุมวิดีโอ
        public static FilterInfoCollection videoDevices;
        public static VideoCaptureDevice videoSource;

        // 1. ประกาศตัวแปรคลาสไว้ที่ระดับระดับฟอร์ม (Form Level)
        private SystemMonitor _monitor;

        // ตรวจสอบ พื้นที่ drive
        string mainDriveLetter = Path.GetPathRoot(Environment.SystemDirectory)!;

        // ดึงข้อมูลของไดรฟ์หลัก
        DriveInfo drive;
        double totalSizeGb, freeSpaceGb, usedSpaceGb, usedPercentage;

        public Form_Main()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;
                // 2. สั่งสร้าง Object ตอนเปิดโปรแกรมขึ้นมา
                _monitor = new SystemMonitor();

                panel_back.Location = new Point(button_menu.Width, 0);
                panel_menu_back.Width = pictureBox_logo.Width;

                // this.Size = new Size(1024, 768);

                this.StartPosition = FormStartPosition.Manual;
                this.Location = Screen.PrimaryScreen!.WorkingArea.Location;
                this.WindowState = FormWindowState.Maximized;

                //  button_sale.BackColor = Color.FromArgb(64, 255, 255);

                panel_menu_back.Width = 0;
                // button_menu.BackColor = Color.Cyan;

                // ใส่รูปภาพ
                pictureBox_logo.Image = Class_Image.resizeImage(Ppos.Properties.Resources.logo_Ppos,
                new Size((pictureBox_logo.Height - 10) * Ppos.Properties.Resources.logo_Ppos.Width / Ppos.Properties.Resources.logo_Ppos.Height, pictureBox_logo.Height - 10));


                button_sale.Image = Class_Image.resizeImage(Ppos.Properties.Resources.sales, new Size(50, 50));
                button_item.Image = Class_Image.resizeImage(Ppos.Properties.Resources.product, new Size(40, 40));
                button_load_excel.Image = Class_Image.resizeImage(Ppos.Properties.Resources.add_item, new Size(40, 40));
                button_promotion.Image = Class_Image.resizeImage(Ppos.Properties.Resources.promotions, new Size(40, 40));
                button_member.Image = Class_Image.resizeImage(Ppos.Properties.Resources.member, new Size(40, 40));
                button_report.Image = Class_Image.resizeImage(Ppos.Properties.Resources.reports, new Size(40, 40));
                button_setting.Image = Class_Image.resizeImage(Ppos.Properties.Resources.setting, new Size(40, 40));

                button_exit.Image = Class_Image.resizeImage(Ppos.Properties.Resources.exits, new Size(40, 40));

                // button_menu.Image = Class_Image.resizeImage(Ppos.Properties.Resources.next, new Size(23, 23));

                this.Text = Class_Parameter.Version;

                Class_Setting.Get();
                label_title.Text = Class_Parameter.store_name;


                // ต้องใช้เฉพาะ ใช้ร่วมกดไม่ได้
                EnableDragScroll(panel_menu);

                // ปิดเมนู
                foreach (Control c in panel_menu.Controls)
                {
                    if (c is Panel)
                    {
                        c.Height = 0;
                    }
                }


                // ดึงข้อมูลของไดรฟ์หลัก
                drive = new DriveInfo(mainDriveLetter);

                if (drive.IsReady)
                {
                    // แปลงหน่วยจาก Bytes เป็น Gigabytes (GB)
                    double freeSpaceGB = drive.AvailableFreeSpace / (1024.0 * 1024.0 * 1024.0);

                    // Console.WriteLine($"ชื่อไดรฟ์: {drive.Name}");
                    // Console.WriteLine($"พื้นที่ว่าง: {freeSpaceGB:F2} GB");
                    // Console.WriteLine($"พื้นที่ทั้งหมด: {totalSizeGB:F2} GB");

                    //  MessageBox.Show(freeSpaceGB.ToString());
                    if (freeSpaceGB < 1)
                    {
                        MessageBox.Show("พื้นที่ " + drive.Name + " คงเหลือน้อยกว่า 1 GB !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
            catch
            {
                Application.Exit();
            }


        }
        // สร้างฟังก์ชันเปิด/ปิดปุ่มแบบ Public
        private void Form_Main_Load(object sender, EventArgs e)
        {
            try
            {
                /////////////////////////////// ใช้ทดสอบ


                Class_Parameter.Active = true;
                Form_Sale form_Sale = new Form_Sale();
                form_Sale.TopLevel = false;
                panel_main.Controls.Add(form_Sale);
                form_Sale.BringToFront();
                form_Sale.Dock = DockStyle.Fill;
                form_Sale.Show();
                //////////////////////////////////////////////////////////////////

                /* if (Class_Expiry_Date.Check_EXP()) // ใช้งานได้
                 {
                     Class_Parameter.Active = true;
                     Form_Sale form_Sale = new Form_Sale();
                     form_Sale.TopLevel = false;
                     panel_main.Controls.Add(form_Sale);
                     form_Sale.BringToFront();
                     form_Sale.Dock = DockStyle.Fill;
                     form_Sale.Show();
                 }
                 else // หมดอายุหรือเปิดครั้งแรก
                 {
                     Class_Parameter.Active = false;
                     Form_Extend form_Extend = new Form_Extend();
                     form_Extend.TopLevel = false;
                     panel_main.Controls.Add(form_Extend);
                     form_Extend.BringToFront();
                     form_Extend.Dock = DockStyle.Fill;
                     form_Extend.Show();

                     // ปิดเมนู
                     if (show_menu)
                     {
                         button_menu.BackColor = Color.Cyan;
                         button_menu.Text = ">";
                         panel_menu.Width = 0;
                         show_menu = false;
                     }
                 }*/
            }
            catch
            {

            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                label_date.Text = DateTime.Now.ToString("dd/MM/yyyy", cultures);
                label_time.Text = DateTime.Now.ToString("HH:mm:ss", cultures);
                 /* drive = new DriveInfo(mainDriveLetter);

                  if (drive.IsReady)
                  {
                      // แปลงหน่วยจาก Bytes เป็น Gigabytes (GB)
                      totalSizeGb = drive.TotalSize / (1024.0 * 1024.0 * 1024.0);
                      freeSpaceGb = drive.AvailableFreeSpace / (1024.0 * 1024.0 * 1024.0);
                      usedSpaceGb = totalSizeGb - freeSpaceGb;
                      usedPercentage = (usedSpaceGb / totalSizeGb) * 100;
                      // เรียกดึงค่าเป็น % มาแสดงผลได้ทันที
                      this.Text = Class_Parameter.Version +
                  " ( CPU : " + _monitor.GetCpuUsage().ToString("00.00") + "% , " +
                  " RAM : " + _monitor.GetRamUsagePercentage().ToString("00.00") + "% , " +
                  " DISK : " + _monitor.GetDiskUsagePercentage().ToString("00.00") + "% , " +
                  " DRIVE : " + usedPercentage.ToString("00.00") + "% )";

                  }*/
  
            }
            catch
            {

            }
        }
        private void button_exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {

            }
        }
        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    if (MessageBox.Show("ต้องการออกจากโปรแกรมใช่หรือไม่ ?", "แจ้งเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        e.Cancel = true; // ยกเลิกการปิด
                    }
                    else // ปิด form
                    {
                        // ปิดกล้อง
                        if (videoSource != null && videoSource.IsRunning)
                        {
                            videoSource.SignalToStop();
                            videoSource.WaitForStop();
                        }
                        // คืนทรัพยากรเมื่อปิดฟอร์ม
                        _monitor?.Dispose();

                        // ปิด form ก่อนปิดหลัก
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form is Form f && f.Name != "Form_Main" && f.Name != "Form_Login")
                            {

                                form.Close();
                                form.Dispose();
                            }
                        }

                        // ถ้าตั้งค่าไม่ใช้ login จะปิดโปรแกรมทันที
                        if (!Class_Parameter.login_program)
                        {
                            Application.Exit();
                        }

                    }

                }
            }
            catch
            {

            }
        }
       
        private void label_title_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState != FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                    // ย้ายหน้าต่างมาไว้กลางหน้าจอ
                    this.StartPosition = FormStartPosition.CenterScreen;
                    this.CenterToScreen();
                }

            }
            catch
            {

            }
        }
        private void button_menu_Click(object sender, EventArgs e)
        {
            try
            {
                timer_tab_menu.Start();
               
            }
            catch
            {
            }
        }
        private void timer_tab_menu_Tick(object sender, EventArgs e)
        {
            try
            {
                this.DoubleBuffered = true;
                this.SuspendLayout();
                if (show_menu)
                {
                    
                    

                    timer_check_tab.Stop();
                    panel_menu_back.Width -= 25;
                    if (panel_menu_back.Width <= 0)
                    {
                        show_menu = false;
                        timer_tab_menu.Stop();

                        button_menu.Text = ">";
                        panel_menu_back.Width = 0;
                       
                    }

                }
                else
                {
                    panel_menu_back.Width += 25;
                    if (panel_menu_back.Width >= pictureBox_logo.Width)
                    {
                        show_menu = true;
                        timer_tab_menu.Stop();

                        button_menu.Text = "<";

                        panel_menu_back.Width = pictureBox_logo.Width;

                        timer_check_tab.Start();
                    }

                }
                this.ResumeLayout(true);
            }
            catch
            {
                timer_tab_menu.Stop();
            }
        }
        private void pictureBox_logo_Click(object sender, EventArgs e)
        {
            try
            {
                return;

                // pictureBox_logo.Enabled = false;
                if (panel_main.Controls.Find("Form_Extend", true).FirstOrDefault() == null)
                {
                    Form_Extend form_Extend = new Form_Extend();
                    form_Extend.TopLevel = false;
                    panel_main.Controls.Add(form_Extend);
                    form_Extend.BringToFront();
                    form_Extend.Dock = DockStyle.Fill;
                    form_Extend.Show();
                    // ปิดเมนู
                    if (show_menu)
                    {
                        // button_menu.BackColor = Color.Cyan;
                        button_menu.Text = ">";
                        // button_menu.Image = Class_Image.resizeImage(Ppos.Properties.Resources.next, new Size(23, 23));
                        panel_menu_back.Width = 0;
                        show_menu = false;
                    }
                }
                else
                {
                    if (Class_Parameter.Active && !Class_Parameter.runbackground)
                    {
                        string formNameToRemove = "Form_Extend"; // ชื่อ Form ที่ต้องการลบ

                        foreach (Control ctrl in panel_main.Controls)
                        {
                            if (ctrl is Form f && f.Name == formNameToRemove)
                            {
                                panel_main.Controls.Remove(f);
                                f.Dispose(); // สำคัญมาก: ต้อง Dispose เพื่อคืน RAM
                                break; // ถ้ามีอันเดียวให้หยุด Loop ทันที
                            }
                        }
                    }

                }
                pictureBox_logo.Enabled = true;
            }
            catch
            {
                pictureBox_logo.Enabled = true;
            }
        }
        private void menu_click(Panel panel)
        {
            try
            {
                // ปิดเมนูอื่นๆ
                /*   foreach (Control ctrl in panel_menu.Controls)
                   {
                       if (ctrl is Panel p && p.Name != panel.Name)
                       {
                           p.Visible = false;
                       }
                   }*/
                // เปิดเมนูที่คลิก
                P = panel;
                /* if (!panel.Visible)
                 {

                     P.Visible = true;

                 }
                 else
                 {

                     P.Visible = false;
                 }*/
                if (P.Height > 0)
                {

                    timer_menu_1.Start();
                }
                else
                {
                    P_Height = 0;
                    foreach (Control ctrl in panel.Controls)
                    {
                        if (ctrl is Button)
                        {
                            P_Height += ctrl.Height;
                        }
                    }
                    timer_menu_2.Start();
                }
            }
            catch
            {

            }
        }
        private void timer_menu_1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();
                P.Height -= 25;
                if (P.Height <= 0)
                {
                    timer_menu_1.Stop();
                }
                this.ResumeLayout(true);
            }
            catch
            {
                timer_menu_1.Stop();
            }
        }
        private void timer_menu_2_Tick(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();
                P.Height += 25;
                if (P.Height >= P_Height)
                {
                    timer_menu_2.Stop();
                }
                this.ResumeLayout(true);
            }
            catch
            {
                timer_menu_2.Stop();
            }
        }
        private void submenu_click(Form form, Button button)
        {
            try
            {
           

                foreach (Control ctrl in panel_main.Controls)
                 {

                     if (ctrl is Form f && ctrl.Name != form.Name)
                     {
                       
                         f.Close();
                         ctrl.Dispose(); // สำคัญมาก: ต้อง Dispose เพื่อคืน RAM
                     }
                 }
                if (panel_main.Controls.Find(form.Name, true).FirstOrDefault() == null)
                {
                    // ใส่ชื่อเมนู
                    if (button.Name == "button_sale")
                    {
                        label_title.Text = Class_Parameter.store_name;
                    }
                    else
                    {
                        label_title.Text = button.Text.Replace("-", "");
                    }
                    // ปิดกล้อง
                    if (videoSource != null && videoSource.IsRunning)
                    {
                        videoSource.SignalToStop();
                        videoSource.WaitForStop();
                    }

                    //ปิดเมนูทันทีหลังเปิดเมนูใหม่
                   /* if (Class_Parameter.hide_menu)
                    {
                        form_click = form;
                        button_click = button;
                        button_menu_Click(this, EventArgs.Empty);

                    }
                    else
                    {*/
                        form.TopLevel = false;
                        panel_main.Controls.Add(form);
                        form.BringToFront();
                        form.Dock = DockStyle.Fill;
                        form.Show();

                        if (b.Name != "button_sale")
                        {
                            b.BackColor = Color.White;

                        }
                        else
                        {
                            b.BackColor = Color.FromArgb(128, 255, 255);

                        }

                        b = button;
                        b.BackColor = Color.Cyan;
                   // }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_sale_Click(object sender, EventArgs e)
        {

            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    /*if (b != (Button)sender)
                    {
                        foreach (Control ctrl in panel_menu.Controls)
                        {
                            if (ctrl is Panel p)
                            {
                                p.Visible = false;
                            }
                        }
                    }*/

                   // button_menu_Click(sender, e);

                    Form_Sale form_Sale = new Form_Sale();
                    submenu_click(form_Sale, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_item_Click(object sender, EventArgs e)
        {
            try
            {
                menu_click(panel_item);
            }
            catch
            {

            }
        }
        private void button_item_group_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Item_Group form_item_group = new Form_Item_Group();
                    submenu_click(form_item_group, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_item_detail_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    if (Class_Parameter.use_item_medium_large)
                    {
                        Form_Item_Detail form_item_detail = new Form_Item_Detail();
                        submenu_click(form_item_detail, (Button)sender);
                    }
                    else
                    {

                        Form_Item_Detail_Small form_Item_Detail_Small = new Form_Item_Detail_Small();
                        submenu_click(form_Item_Detail_Small, (Button)sender);
                    }

                }
            }
            catch
            {

            }
        }
        private void button_item_hotkey_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Item_Hotkey form_Item_Hotkey = new Form_Item_Hotkey();
                    submenu_click(form_Item_Hotkey, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_item_adjust_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Item_Adjust form_item_adjust = new Form_Item_Adjust();
                    submenu_click(form_item_adjust, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_load_excel_Click(object sender, EventArgs e)
        {
            try
            {
                menu_click(panel_load_excel);
            }
            catch
            {

            }
        }
        private void button_load_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Load_Add form_item_add = new Form_Load_Add();
                    submenu_click(form_item_add, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_load_qty_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Load_QTY form_Load_QTY = new Form_Load_QTY();
                    submenu_click(form_Load_QTY, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_load_price_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Load_Price form_Load_Price = new Form_Load_Price();
                    submenu_click(form_Load_Price, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_promotion_Click(object sender, EventArgs e)
        {
            try
            {
                menu_click(panel_promotion);
            }
            catch
            {

            }
        }
        private void button_pro_item_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Pro_Base_Item form_Pro_Item = new Form_Pro_Base_Item();
                    submenu_click(form_Pro_Item, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_mix_item_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Pro_Mix_Item form_Pro_Mix_Item = new Form_Pro_Mix_Item();
                    submenu_click(form_Pro_Mix_Item, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_set_item_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Pro_Set_Item form_Pro_Set_Item = new Form_Pro_Set_Item();
                    submenu_click(form_Pro_Set_Item, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_member_Click(object sender, EventArgs e)
        {
            try
            {

                menu_click(panel_member);
            }
            catch
            {

            }
        }
        private void button_member_detail_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Member_Detail form_Member_Detail = new Form_Member_Detail();
                    submenu_click(form_Member_Detail, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_report_Click(object sender, EventArgs e)
        {
            try
            {

                menu_click(panel_report);
            }
            catch
            {

            }
        }
        private void button_report_trans_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Report_Trans form_Report_Trans = new Form_Report_Trans();
                    submenu_click(form_Report_Trans, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_setting_Click(object sender, EventArgs e)
        {
            try
            {

                menu_click(panel_setting);
            }
            catch
            {

            }
        }
        private void button_setting_store_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Setting_Store form_Setting_Store = new Form_Setting_Store();
                    submenu_click(form_Setting_Store, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_setting_user_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Setting_User form_setting_user = new Form_Setting_User();
                    submenu_click(form_setting_user, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_setting_camera_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Setting_Camera form_Setting_Camera = new Form_Setting_Camera();
                    submenu_click(form_Setting_Camera, (Button)sender);
                }
            }
            catch
            {

            }
        }
        private void button_setting_config_pro_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.Active && !Class_Parameter.runbackground)
                {
                    Form_Setting_Configure form_Setting_Config_Pro = new Form_Setting_Configure(this);
                    submenu_click(form_Setting_Config_Pro, (Button)sender);
                }
            }
            catch
            {

            }
        }

        ///////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///  // ตัวแปรสำหรับจำสถานะ (ใช้ร่วมกันในการลาก)
        public static bool isScrolling = false;
        private static Point startMousePoint = new Point(0, 0);
        private static Point startScrollPoint = new Point(0, 0);
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
                startScrollPoint = new Point(targetPanel.HorizontalScroll.Value, targetPanel.VerticalScroll.Value);
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

                targetPanel.AutoScrollPosition = new Point(newScrollX, newScrollY);
            }
        }
        private static void Common_MouseUp(object sender, MouseEventArgs e)
        {
            isScrolling = false;
        }
        private void button_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                button.ForeColor = Color.Black;
                button.Font = new Font("Segoe UI", button.Font.Size + 1, FontStyle.Bold);
                // button.FlatStyle = FlatStyle.Standard;
            }
            catch
            {

            }
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                if (button.Name != "button_sale" && button.Name != "button_exit")
                {
                    button.ForeColor = Color.DimGray;
                }
                button.Font = new Font("Segoe UI", button.Font.Size - 1, FontStyle.Bold);
                //  button.FlatStyle = FlatStyle.Flat;
            }
            catch
            {

            }
        }
        private void pictureBox_logo_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                pictureBox_logo.Image = Class_Image.resizeImage(Ppos.Properties.Resources.logo_Ppos,
new Size(pictureBox_logo.Height * Ppos.Properties.Resources.logo_Ppos.Width / Ppos.Properties.Resources.logo_Ppos.Height, pictureBox_logo.Height));

            }
            catch
            {

            }
        }
        private void pictureBox_logo_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                pictureBox_logo.Image = Class_Image.resizeImage(Ppos.Properties.Resources.logo_Ppos,
   new Size((pictureBox_logo.Height - 10) * Ppos.Properties.Resources.logo_Ppos.Width / Ppos.Properties.Resources.logo_Ppos.Height, pictureBox_logo.Height - 10));


            }
            catch
            {

            }
        }
        private void button_menu_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                button_menu.ForeColor = Color.Black;
                //  button_menu.Font = new Font(button_menu.Font.FontFamily, button_menu.Font.Size + 6, button_menu.Font.Style);
              /*  if(!show_menu)
                {
                    button_menu_Click(sender, EventArgs.Empty);
                }*/

            }
            catch
            {

            }
        }
        private void button_menu_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                button_menu.ForeColor = Color.Cyan;
                // button_menu.Font = new Font(button_menu.Font.FontFamily, button_menu.Font.Size - 6, button_menu.Font.Style);


            }
            catch
            {

            }
        }
        private void label_enter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
                label.Font = new Font(label.Font.FontFamily, label.Font.Size + 2, label.Font.Style);
            }
            catch
            {

            }
        }
        private void label_leave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
                label.Font = new Font(label.Font.FontFamily, label.Font.Size - 2, label.Font.Style);
            }
            catch
            {

            }
        }
        private void timer_check_tab_Tick(object sender, EventArgs e)
        {
            try
            {
                // 1. ดึงตำแหน่งเมาส์จริงบนหน้าจอคอมพิวเตอร์ (Global Position)
                Point mouseScreenPoint = Cursor.Position;

                // 2. แปลงตำแหน่งจุดกึ่งกลางของปุ่ม (บนฟอร์ม) ให้กลายเป็นพิกัดบนหน้าจอคอมพิวเตอร์
                // หาจุดกึ่งกลางของปุ่มในแนวแกน X ก่อน
                int buttonCenterX = button_menu.Width;
                // สร้างจุดกึ่งกลางของปุ่ม (X = กึ่งกลาง, Y = 0) เทียบกับตัวปุ่มเอง
                Point buttonCenterPoint = new Point(buttonCenterX, 0);
                // แปลงจุดนี้ให้เป็นพิกัดหน้าจอหลัก (Screen Coordinates)
                Point buttonCenterScreenPoint = button_menu.PointToScreen(buttonCenterPoint);

                // 3. นำพิกด X ของเมาส์ มาเปรียบเทียบกับพิกัด X กึ่งกลางปุ่มบนหน้าจอ
                if (mouseScreenPoint.X > buttonCenterScreenPoint.X)
                {

                    if (show_menu)
                    {
                        button_menu_Click(sender, new EventArgs());
                    }
                }
               
            }
            catch
            {

            }
        }
    }
}