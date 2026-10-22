namespace Ppos
{
    partial class Form_Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            button_exit = new Button();
            panel_main = new Panel();
            button_sale = new Button();
            button_item = new Button();
            button_member = new Button();
            button_report = new Button();
            button_promotion = new Button();
            panel_top_main = new Panel();
            label_title = new Label();
            tableLayoutPanel_datetime = new TableLayoutPanel();
            label_date = new Label();
            label_time = new Label();
            pictureBox_time = new PictureBox();
            pictureBox_date = new PictureBox();
            pictureBox_logo = new PictureBox();
            button_setting = new Button();
            panel_menu = new Panel();
            panel_setting = new Panel();
            button_setting_config_pro = new Button();
            button_setting_camera = new Button();
            button_setting_user = new Button();
            button_setting_store = new Button();
            panel_report = new Panel();
            button_report_trans = new Button();
            panel_member = new Panel();
            button_member_detail = new Button();
            panel_promotion = new Panel();
            button_set_item = new Button();
            button_mix_item = new Button();
            button_pro_item = new Button();
            panel_load_excel = new Panel();
            button_load_price = new Button();
            button_load_qty = new Button();
            button_load_add = new Button();
            button_load_excel = new Button();
            panel_item = new Panel();
            button_item_adjust = new Button();
            button_item_hotkey = new Button();
            button_item_detail = new Button();
            button_item_group = new Button();
            timer = new System.Windows.Forms.Timer(components);
            button_menu = new Button();
            timer_menu_1 = new System.Windows.Forms.Timer(components);
            timer_menu_2 = new System.Windows.Forms.Timer(components);
            panel_menu_back = new Panel();
            timer_tab_menu = new System.Windows.Forms.Timer(components);
            panel_back = new Panel();
            tableLayoutPanel_back = new TableLayoutPanel();
            timer_check_tab = new System.Windows.Forms.Timer(components);
            panel_top_main.SuspendLayout();
            tableLayoutPanel_datetime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_time).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_date).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).BeginInit();
            panel_menu.SuspendLayout();
            panel_setting.SuspendLayout();
            panel_report.SuspendLayout();
            panel_member.SuspendLayout();
            panel_promotion.SuspendLayout();
            panel_load_excel.SuspendLayout();
            panel_item.SuspendLayout();
            panel_menu_back.SuspendLayout();
            panel_back.SuspendLayout();
            tableLayoutPanel_back.SuspendLayout();
            SuspendLayout();
            // 
            // button_exit
            // 
            button_exit.BackColor = Color.Cyan;
            button_exit.BackgroundImageLayout = ImageLayout.Zoom;
            button_exit.Dock = DockStyle.Bottom;
            button_exit.FlatAppearance.BorderSize = 0;
            button_exit.FlatAppearance.MouseDownBackColor = Color.Red;
            button_exit.FlatAppearance.MouseOverBackColor = Color.Red;
            button_exit.FlatStyle = FlatStyle.Flat;
            button_exit.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_exit.ForeColor = Color.Black;
            button_exit.ImageAlign = ContentAlignment.MiddleLeft;
            button_exit.Location = new Point(0, 1460);
            button_exit.Margin = new Padding(4, 4, 4, 4);
            button_exit.Name = "button_exit";
            button_exit.Size = new Size(500, 88);
            button_exit.TabIndex = 0;
            button_exit.TabStop = false;
            button_exit.Text = "ออกจากโปรแกรม";
            button_exit.TextAlign = ContentAlignment.MiddleLeft;
            button_exit.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_exit.UseVisualStyleBackColor = false;
            button_exit.Click += button_exit_Click;
            button_exit.MouseEnter += button_MouseEnter;
            button_exit.MouseLeave += button_MouseLeave;
            // 
            // panel_main
            // 
            panel_main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_main.BackColor = Color.White;
            panel_main.Location = new Point(31, 0);
            panel_main.Margin = new Padding(0);
            panel_main.Name = "panel_main";
            panel_main.Size = new Size(1249, 1502);
            panel_main.TabIndex = 1;
            // 
            // button_sale
            // 
            button_sale.BackColor = Color.FromArgb(128, 255, 255);
            button_sale.BackgroundImageLayout = ImageLayout.Zoom;
            button_sale.Dock = DockStyle.Top;
            button_sale.FlatAppearance.BorderColor = Color.Lime;
            button_sale.FlatAppearance.BorderSize = 0;
            button_sale.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 255);
            button_sale.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 255);
            button_sale.FlatStyle = FlatStyle.Flat;
            button_sale.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold);
            button_sale.ForeColor = Color.Black;
            button_sale.ImageAlign = ContentAlignment.MiddleLeft;
            button_sale.Location = new Point(0, 0);
            button_sale.Margin = new Padding(0);
            button_sale.Name = "button_sale";
            button_sale.Size = new Size(500, 88);
            button_sale.TabIndex = 0;
            button_sale.TabStop = false;
            button_sale.Text = "ขายสินค้า";
            button_sale.TextAlign = ContentAlignment.MiddleLeft;
            button_sale.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_sale.UseVisualStyleBackColor = false;
            button_sale.Click += button_sale_Click;
            button_sale.MouseEnter += button_MouseEnter;
            button_sale.MouseLeave += button_MouseLeave;
            // 
            // button_item
            // 
            button_item.BackColor = Color.FromArgb(192, 255, 255);
            button_item.BackgroundImageLayout = ImageLayout.Zoom;
            button_item.Dock = DockStyle.Top;
            button_item.FlatAppearance.BorderSize = 0;
            button_item.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            button_item.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            button_item.FlatStyle = FlatStyle.Flat;
            button_item.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_item.ForeColor = Color.DimGray;
            button_item.ImageAlign = ContentAlignment.MiddleLeft;
            button_item.Location = new Point(0, 88);
            button_item.Margin = new Padding(0);
            button_item.Name = "button_item";
            button_item.Size = new Size(500, 62);
            button_item.TabIndex = 0;
            button_item.TabStop = false;
            button_item.Text = "สินค้า";
            button_item.TextAlign = ContentAlignment.MiddleLeft;
            button_item.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_item.UseVisualStyleBackColor = false;
            button_item.Click += button_item_Click;
            button_item.MouseEnter += button_MouseEnter;
            button_item.MouseLeave += button_MouseLeave;
            // 
            // button_member
            // 
            button_member.BackColor = Color.FromArgb(192, 255, 255);
            button_member.BackgroundImageLayout = ImageLayout.Zoom;
            button_member.Dock = DockStyle.Top;
            button_member.FlatAppearance.BorderSize = 0;
            button_member.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            button_member.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            button_member.FlatStyle = FlatStyle.Flat;
            button_member.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_member.ForeColor = Color.DimGray;
            button_member.ImageAlign = ContentAlignment.MiddleLeft;
            button_member.Location = new Point(0, 900);
            button_member.Margin = new Padding(0);
            button_member.Name = "button_member";
            button_member.Size = new Size(500, 62);
            button_member.TabIndex = 0;
            button_member.TabStop = false;
            button_member.Text = "สมาชิก";
            button_member.TextAlign = ContentAlignment.MiddleLeft;
            button_member.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_member.UseVisualStyleBackColor = false;
            button_member.Click += button_member_Click;
            button_member.MouseEnter += button_MouseEnter;
            button_member.MouseLeave += button_MouseLeave;
            // 
            // button_report
            // 
            button_report.BackColor = Color.FromArgb(192, 255, 255);
            button_report.BackgroundImageLayout = ImageLayout.Zoom;
            button_report.Dock = DockStyle.Top;
            button_report.FlatAppearance.BorderSize = 0;
            button_report.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            button_report.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            button_report.FlatStyle = FlatStyle.Flat;
            button_report.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_report.ForeColor = Color.DimGray;
            button_report.ImageAlign = ContentAlignment.MiddleLeft;
            button_report.Location = new Point(0, 1024);
            button_report.Margin = new Padding(0);
            button_report.Name = "button_report";
            button_report.Size = new Size(500, 62);
            button_report.TabIndex = 0;
            button_report.TabStop = false;
            button_report.Text = "รายงาน";
            button_report.TextAlign = ContentAlignment.MiddleLeft;
            button_report.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_report.UseVisualStyleBackColor = false;
            button_report.Click += button_report_Click;
            button_report.MouseEnter += button_MouseEnter;
            button_report.MouseLeave += button_MouseLeave;
            // 
            // button_promotion
            // 
            button_promotion.BackColor = Color.FromArgb(192, 255, 255);
            button_promotion.BackgroundImageLayout = ImageLayout.Zoom;
            button_promotion.Dock = DockStyle.Top;
            button_promotion.FlatAppearance.BorderSize = 0;
            button_promotion.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            button_promotion.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            button_promotion.FlatStyle = FlatStyle.Flat;
            button_promotion.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_promotion.ForeColor = Color.DimGray;
            button_promotion.ImageAlign = ContentAlignment.MiddleLeft;
            button_promotion.Location = new Point(0, 650);
            button_promotion.Margin = new Padding(0);
            button_promotion.Name = "button_promotion";
            button_promotion.Size = new Size(500, 62);
            button_promotion.TabIndex = 0;
            button_promotion.TabStop = false;
            button_promotion.Text = "โปรโมชั่น";
            button_promotion.TextAlign = ContentAlignment.MiddleLeft;
            button_promotion.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_promotion.UseVisualStyleBackColor = false;
            button_promotion.Click += button_promotion_Click;
            button_promotion.MouseEnter += button_MouseEnter;
            button_promotion.MouseLeave += button_MouseLeave;
            // 
            // panel_top_main
            // 
            panel_top_main.BackColor = Color.Cyan;
            panel_top_main.Controls.Add(label_title);
            panel_top_main.Controls.Add(tableLayoutPanel_datetime);
            panel_top_main.Controls.Add(pictureBox_logo);
            panel_top_main.Dock = DockStyle.Fill;
            panel_top_main.Location = new Point(0, 0);
            panel_top_main.Margin = new Padding(0);
            panel_top_main.Name = "panel_top_main";
            panel_top_main.Size = new Size(1280, 88);
            panel_top_main.TabIndex = 2;
            // 
            // label_title
            // 
            label_title.Dock = DockStyle.Fill;
            label_title.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold);
            label_title.Location = new Point(500, 0);
            label_title.Margin = new Padding(4, 0, 4, 0);
            label_title.Name = "label_title";
            label_title.Size = new Size(280, 88);
            label_title.TabIndex = 1;
            label_title.Text = "ร้านทดสอบ";
            label_title.TextAlign = ContentAlignment.MiddleCenter;
            label_title.DoubleClick += label_title_DoubleClick;
            label_title.MouseEnter += label_enter;
            label_title.MouseLeave += label_leave;
            // 
            // tableLayoutPanel_datetime
            // 
            tableLayoutPanel_datetime.ColumnCount = 3;
            tableLayoutPanel_datetime.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_datetime.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_datetime.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_datetime.Controls.Add(label_date, 2, 0);
            tableLayoutPanel_datetime.Controls.Add(label_time, 2, 1);
            tableLayoutPanel_datetime.Controls.Add(pictureBox_time, 1, 1);
            tableLayoutPanel_datetime.Controls.Add(pictureBox_date, 1, 0);
            tableLayoutPanel_datetime.Dock = DockStyle.Right;
            tableLayoutPanel_datetime.Location = new Point(780, 0);
            tableLayoutPanel_datetime.Margin = new Padding(0);
            tableLayoutPanel_datetime.Name = "tableLayoutPanel_datetime";
            tableLayoutPanel_datetime.RowCount = 2;
            tableLayoutPanel_datetime.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_datetime.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_datetime.Size = new Size(500, 88);
            tableLayoutPanel_datetime.TabIndex = 2;
            // 
            // label_date
            // 
            label_date.Dock = DockStyle.Fill;
            label_date.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_date.Location = new Point(275, 0);
            label_date.Margin = new Padding(0);
            label_date.Name = "label_date";
            label_date.Size = new Size(225, 44);
            label_date.TabIndex = 2;
            label_date.Text = "00/00/0000";
            label_date.TextAlign = ContentAlignment.MiddleLeft;
            label_date.MouseEnter += label_enter;
            label_date.MouseLeave += label_leave;
            // 
            // label_time
            // 
            label_time.Dock = DockStyle.Fill;
            label_time.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_time.Location = new Point(275, 44);
            label_time.Margin = new Padding(0);
            label_time.Name = "label_time";
            label_time.Size = new Size(225, 44);
            label_time.TabIndex = 3;
            label_time.Text = "00:00:00";
            label_time.TextAlign = ContentAlignment.MiddleLeft;
            label_time.MouseEnter += label_enter;
            label_time.MouseLeave += label_leave;
            // 
            // pictureBox_time
            // 
            pictureBox_time.Dock = DockStyle.Fill;
            pictureBox_time.Image = (Image)resources.GetObject("pictureBox_time.Image");
            pictureBox_time.Location = new Point(225, 48);
            pictureBox_time.Margin = new Padding(0, 4, 0, 4);
            pictureBox_time.Name = "pictureBox_time";
            pictureBox_time.Size = new Size(50, 36);
            pictureBox_time.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_time.TabIndex = 1;
            pictureBox_time.TabStop = false;
            // 
            // pictureBox_date
            // 
            pictureBox_date.Dock = DockStyle.Fill;
            pictureBox_date.Image = (Image)resources.GetObject("pictureBox_date.Image");
            pictureBox_date.Location = new Point(225, 4);
            pictureBox_date.Margin = new Padding(0, 4, 0, 4);
            pictureBox_date.Name = "pictureBox_date";
            pictureBox_date.Size = new Size(50, 36);
            pictureBox_date.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_date.TabIndex = 0;
            pictureBox_date.TabStop = false;
            // 
            // pictureBox_logo
            // 
            pictureBox_logo.BackColor = Color.Transparent;
            pictureBox_logo.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox_logo.Dock = DockStyle.Left;
            pictureBox_logo.Location = new Point(0, 0);
            pictureBox_logo.Margin = new Padding(0);
            pictureBox_logo.Name = "pictureBox_logo";
            pictureBox_logo.Size = new Size(500, 88);
            pictureBox_logo.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_logo.TabIndex = 0;
            pictureBox_logo.TabStop = false;
            pictureBox_logo.Click += pictureBox_logo_Click;
            pictureBox_logo.MouseEnter += pictureBox_logo_MouseEnter;
            pictureBox_logo.MouseLeave += pictureBox_logo_MouseLeave;
            // 
            // button_setting
            // 
            button_setting.BackColor = Color.FromArgb(192, 255, 255);
            button_setting.BackgroundImageLayout = ImageLayout.Zoom;
            button_setting.Dock = DockStyle.Top;
            button_setting.FlatAppearance.BorderSize = 0;
            button_setting.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            button_setting.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            button_setting.FlatStyle = FlatStyle.Flat;
            button_setting.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_setting.ForeColor = Color.DimGray;
            button_setting.ImageAlign = ContentAlignment.MiddleLeft;
            button_setting.Location = new Point(0, 1148);
            button_setting.Margin = new Padding(0);
            button_setting.Name = "button_setting";
            button_setting.Size = new Size(500, 62);
            button_setting.TabIndex = 0;
            button_setting.TabStop = false;
            button_setting.Text = "ตั้งค่า";
            button_setting.TextAlign = ContentAlignment.MiddleLeft;
            button_setting.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_setting.UseVisualStyleBackColor = false;
            button_setting.Click += button_setting_Click;
            button_setting.MouseEnter += button_MouseEnter;
            button_setting.MouseLeave += button_MouseLeave;
            // 
            // panel_menu
            // 
            panel_menu.AutoScroll = true;
            panel_menu.BackColor = Color.White;
            panel_menu.Controls.Add(panel_setting);
            panel_menu.Controls.Add(button_setting);
            panel_menu.Controls.Add(panel_report);
            panel_menu.Controls.Add(button_report);
            panel_menu.Controls.Add(panel_member);
            panel_menu.Controls.Add(button_member);
            panel_menu.Controls.Add(panel_promotion);
            panel_menu.Controls.Add(button_promotion);
            panel_menu.Controls.Add(panel_load_excel);
            panel_menu.Controls.Add(button_load_excel);
            panel_menu.Controls.Add(panel_item);
            panel_menu.Controls.Add(button_item);
            panel_menu.Controls.Add(button_sale);
            panel_menu.Controls.Add(button_exit);
            panel_menu.Dock = DockStyle.Left;
            panel_menu.Location = new Point(0, 0);
            panel_menu.Margin = new Padding(0);
            panel_menu.Name = "panel_menu";
            panel_menu.Size = new Size(526, 1502);
            panel_menu.TabIndex = 3;
            // 
            // panel_setting
            // 
            panel_setting.BackColor = Color.FromArgb(192, 255, 255);
            panel_setting.Controls.Add(button_setting_config_pro);
            panel_setting.Controls.Add(button_setting_camera);
            panel_setting.Controls.Add(button_setting_user);
            panel_setting.Controls.Add(button_setting_store);
            panel_setting.Dock = DockStyle.Top;
            panel_setting.Location = new Point(0, 1210);
            panel_setting.Margin = new Padding(4, 4, 4, 4);
            panel_setting.Name = "panel_setting";
            panel_setting.Size = new Size(500, 250);
            panel_setting.TabIndex = 1;
            // 
            // button_setting_config_pro
            // 
            button_setting_config_pro.BackColor = Color.White;
            button_setting_config_pro.Dock = DockStyle.Top;
            button_setting_config_pro.FlatAppearance.BorderSize = 0;
            button_setting_config_pro.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_setting_config_pro.FlatAppearance.MouseOverBackColor = Color.White;
            button_setting_config_pro.FlatStyle = FlatStyle.Flat;
            button_setting_config_pro.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_setting_config_pro.ForeColor = Color.DimGray;
            button_setting_config_pro.Location = new Point(0, 186);
            button_setting_config_pro.Margin = new Padding(4, 4, 4, 4);
            button_setting_config_pro.Name = "button_setting_config_pro";
            button_setting_config_pro.Padding = new Padding(50, 0, 0, 0);
            button_setting_config_pro.Size = new Size(500, 62);
            button_setting_config_pro.TabIndex = 7;
            button_setting_config_pro.Text = "- ตั้งค่าการใช้งานระบบ";
            button_setting_config_pro.TextAlign = ContentAlignment.MiddleLeft;
            button_setting_config_pro.UseVisualStyleBackColor = false;
            button_setting_config_pro.Click += button_setting_config_pro_Click;
            button_setting_config_pro.MouseEnter += button_MouseEnter;
            button_setting_config_pro.MouseLeave += button_MouseLeave;
            // 
            // button_setting_camera
            // 
            button_setting_camera.BackColor = Color.White;
            button_setting_camera.Dock = DockStyle.Top;
            button_setting_camera.FlatAppearance.BorderSize = 0;
            button_setting_camera.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_setting_camera.FlatAppearance.MouseOverBackColor = Color.White;
            button_setting_camera.FlatStyle = FlatStyle.Flat;
            button_setting_camera.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_setting_camera.ForeColor = Color.DimGray;
            button_setting_camera.Location = new Point(0, 124);
            button_setting_camera.Margin = new Padding(4, 4, 4, 4);
            button_setting_camera.Name = "button_setting_camera";
            button_setting_camera.Padding = new Padding(50, 0, 0, 0);
            button_setting_camera.Size = new Size(500, 62);
            button_setting_camera.TabIndex = 6;
            button_setting_camera.Text = "- ตั้งค่ากล้องถ่ายภาพ";
            button_setting_camera.TextAlign = ContentAlignment.MiddleLeft;
            button_setting_camera.UseVisualStyleBackColor = false;
            button_setting_camera.Click += button_setting_camera_Click;
            button_setting_camera.MouseEnter += button_MouseEnter;
            button_setting_camera.MouseLeave += button_MouseLeave;
            // 
            // button_setting_user
            // 
            button_setting_user.BackColor = Color.White;
            button_setting_user.Dock = DockStyle.Top;
            button_setting_user.FlatAppearance.BorderSize = 0;
            button_setting_user.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_setting_user.FlatAppearance.MouseOverBackColor = Color.White;
            button_setting_user.FlatStyle = FlatStyle.Flat;
            button_setting_user.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_setting_user.ForeColor = Color.DimGray;
            button_setting_user.Location = new Point(0, 62);
            button_setting_user.Margin = new Padding(4, 4, 4, 4);
            button_setting_user.Name = "button_setting_user";
            button_setting_user.Padding = new Padding(50, 0, 0, 0);
            button_setting_user.Size = new Size(500, 62);
            button_setting_user.TabIndex = 0;
            button_setting_user.TabStop = false;
            button_setting_user.Text = "- ข้อมูลพนักงานใช้ระบบ";
            button_setting_user.TextAlign = ContentAlignment.MiddleLeft;
            button_setting_user.UseVisualStyleBackColor = false;
            button_setting_user.Click += button_setting_user_Click;
            button_setting_user.MouseEnter += button_MouseEnter;
            button_setting_user.MouseLeave += button_MouseLeave;
            // 
            // button_setting_store
            // 
            button_setting_store.BackColor = Color.White;
            button_setting_store.Dock = DockStyle.Top;
            button_setting_store.FlatAppearance.BorderSize = 0;
            button_setting_store.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_setting_store.FlatAppearance.MouseOverBackColor = Color.White;
            button_setting_store.FlatStyle = FlatStyle.Flat;
            button_setting_store.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_setting_store.ForeColor = Color.DimGray;
            button_setting_store.Location = new Point(0, 0);
            button_setting_store.Margin = new Padding(4, 4, 4, 4);
            button_setting_store.Name = "button_setting_store";
            button_setting_store.Padding = new Padding(50, 0, 0, 0);
            button_setting_store.Size = new Size(500, 62);
            button_setting_store.TabIndex = 8;
            button_setting_store.Text = "- ข้อมูลร้านค้า";
            button_setting_store.TextAlign = ContentAlignment.MiddleLeft;
            button_setting_store.UseVisualStyleBackColor = false;
            button_setting_store.Click += button_setting_store_Click;
            button_setting_store.MouseEnter += button_MouseEnter;
            button_setting_store.MouseLeave += button_MouseLeave;
            // 
            // panel_report
            // 
            panel_report.BackColor = Color.FromArgb(192, 255, 255);
            panel_report.Controls.Add(button_report_trans);
            panel_report.Dock = DockStyle.Top;
            panel_report.Location = new Point(0, 1086);
            panel_report.Margin = new Padding(4, 4, 4, 4);
            panel_report.Name = "panel_report";
            panel_report.Size = new Size(500, 62);
            panel_report.TabIndex = 5;
            // 
            // button_report_trans
            // 
            button_report_trans.BackColor = Color.White;
            button_report_trans.Dock = DockStyle.Top;
            button_report_trans.FlatAppearance.BorderSize = 0;
            button_report_trans.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_report_trans.FlatAppearance.MouseOverBackColor = Color.White;
            button_report_trans.FlatStyle = FlatStyle.Flat;
            button_report_trans.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_report_trans.ForeColor = Color.DimGray;
            button_report_trans.Location = new Point(0, 0);
            button_report_trans.Margin = new Padding(4, 4, 4, 4);
            button_report_trans.Name = "button_report_trans";
            button_report_trans.Padding = new Padding(50, 0, 0, 0);
            button_report_trans.Size = new Size(500, 62);
            button_report_trans.TabIndex = 0;
            button_report_trans.Text = "- รายงานเคลื่อนไหวต้นทุน";
            button_report_trans.TextAlign = ContentAlignment.MiddleLeft;
            button_report_trans.UseVisualStyleBackColor = false;
            button_report_trans.Click += button_report_trans_Click;
            button_report_trans.MouseEnter += button_MouseEnter;
            button_report_trans.MouseLeave += button_MouseLeave;
            // 
            // panel_member
            // 
            panel_member.BackColor = Color.FromArgb(192, 255, 255);
            panel_member.Controls.Add(button_member_detail);
            panel_member.Dock = DockStyle.Top;
            panel_member.Location = new Point(0, 962);
            panel_member.Margin = new Padding(4, 4, 4, 4);
            panel_member.Name = "panel_member";
            panel_member.Size = new Size(500, 62);
            panel_member.TabIndex = 4;
            // 
            // button_member_detail
            // 
            button_member_detail.BackColor = Color.White;
            button_member_detail.Dock = DockStyle.Top;
            button_member_detail.FlatAppearance.BorderSize = 0;
            button_member_detail.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_member_detail.FlatAppearance.MouseOverBackColor = Color.White;
            button_member_detail.FlatStyle = FlatStyle.Flat;
            button_member_detail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_member_detail.ForeColor = Color.DimGray;
            button_member_detail.Location = new Point(0, 0);
            button_member_detail.Margin = new Padding(4, 4, 4, 4);
            button_member_detail.Name = "button_member_detail";
            button_member_detail.Padding = new Padding(50, 0, 0, 0);
            button_member_detail.Size = new Size(500, 62);
            button_member_detail.TabIndex = 1;
            button_member_detail.Text = "- ข้อมูลสมาชิก";
            button_member_detail.TextAlign = ContentAlignment.MiddleLeft;
            button_member_detail.UseVisualStyleBackColor = false;
            button_member_detail.Click += button_member_detail_Click;
            button_member_detail.MouseEnter += button_MouseEnter;
            button_member_detail.MouseLeave += button_MouseLeave;
            // 
            // panel_promotion
            // 
            panel_promotion.BackColor = Color.FromArgb(192, 255, 255);
            panel_promotion.Controls.Add(button_set_item);
            panel_promotion.Controls.Add(button_mix_item);
            panel_promotion.Controls.Add(button_pro_item);
            panel_promotion.Dock = DockStyle.Top;
            panel_promotion.Location = new Point(0, 712);
            panel_promotion.Margin = new Padding(4, 4, 4, 4);
            panel_promotion.Name = "panel_promotion";
            panel_promotion.Size = new Size(500, 188);
            panel_promotion.TabIndex = 3;
            // 
            // button_set_item
            // 
            button_set_item.BackColor = Color.White;
            button_set_item.Dock = DockStyle.Top;
            button_set_item.FlatAppearance.BorderSize = 0;
            button_set_item.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_set_item.FlatAppearance.MouseOverBackColor = Color.White;
            button_set_item.FlatStyle = FlatStyle.Flat;
            button_set_item.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_set_item.ForeColor = Color.DimGray;
            button_set_item.Location = new Point(0, 124);
            button_set_item.Margin = new Padding(4, 4, 4, 4);
            button_set_item.Name = "button_set_item";
            button_set_item.Padding = new Padding(50, 0, 0, 0);
            button_set_item.Size = new Size(500, 62);
            button_set_item.TabIndex = 0;
            button_set_item.Text = "- โปรโมชั่นชุดสินค้า";
            button_set_item.TextAlign = ContentAlignment.MiddleLeft;
            button_set_item.UseVisualStyleBackColor = false;
            button_set_item.Click += button_set_item_Click;
            button_set_item.MouseEnter += button_MouseEnter;
            button_set_item.MouseLeave += button_MouseLeave;
            // 
            // button_mix_item
            // 
            button_mix_item.BackColor = Color.White;
            button_mix_item.Dock = DockStyle.Top;
            button_mix_item.FlatAppearance.BorderSize = 0;
            button_mix_item.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_mix_item.FlatAppearance.MouseOverBackColor = Color.White;
            button_mix_item.FlatStyle = FlatStyle.Flat;
            button_mix_item.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_mix_item.ForeColor = Color.DimGray;
            button_mix_item.Location = new Point(0, 62);
            button_mix_item.Margin = new Padding(4, 4, 4, 4);
            button_mix_item.Name = "button_mix_item";
            button_mix_item.Padding = new Padding(50, 0, 0, 0);
            button_mix_item.Size = new Size(500, 62);
            button_mix_item.TabIndex = 0;
            button_mix_item.Text = "- โปรโมชั่นคละรายการสินค้า";
            button_mix_item.TextAlign = ContentAlignment.MiddleLeft;
            button_mix_item.UseVisualStyleBackColor = false;
            button_mix_item.Click += button_mix_item_Click;
            button_mix_item.MouseEnter += button_MouseEnter;
            button_mix_item.MouseLeave += button_MouseLeave;
            // 
            // button_pro_item
            // 
            button_pro_item.BackColor = Color.White;
            button_pro_item.Dock = DockStyle.Top;
            button_pro_item.FlatAppearance.BorderSize = 0;
            button_pro_item.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_pro_item.FlatAppearance.MouseOverBackColor = Color.White;
            button_pro_item.FlatStyle = FlatStyle.Flat;
            button_pro_item.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_pro_item.ForeColor = Color.DimGray;
            button_pro_item.Location = new Point(0, 0);
            button_pro_item.Margin = new Padding(4, 4, 4, 4);
            button_pro_item.Name = "button_pro_item";
            button_pro_item.Padding = new Padding(50, 0, 0, 0);
            button_pro_item.Size = new Size(500, 62);
            button_pro_item.TabIndex = 0;
            button_pro_item.Text = "- โปรโมชั่นต่อรายการสินค้า";
            button_pro_item.TextAlign = ContentAlignment.MiddleLeft;
            button_pro_item.UseVisualStyleBackColor = false;
            button_pro_item.Click += button_pro_item_Click;
            button_pro_item.MouseEnter += button_MouseEnter;
            button_pro_item.MouseLeave += button_MouseLeave;
            // 
            // panel_load_excel
            // 
            panel_load_excel.BackColor = Color.FromArgb(192, 255, 255);
            panel_load_excel.Controls.Add(button_load_price);
            panel_load_excel.Controls.Add(button_load_qty);
            panel_load_excel.Controls.Add(button_load_add);
            panel_load_excel.Dock = DockStyle.Top;
            panel_load_excel.Location = new Point(0, 462);
            panel_load_excel.Margin = new Padding(4, 4, 4, 4);
            panel_load_excel.Name = "panel_load_excel";
            panel_load_excel.Size = new Size(500, 188);
            panel_load_excel.TabIndex = 7;
            // 
            // button_load_price
            // 
            button_load_price.BackColor = Color.White;
            button_load_price.Dock = DockStyle.Top;
            button_load_price.FlatAppearance.BorderSize = 0;
            button_load_price.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_load_price.FlatAppearance.MouseOverBackColor = Color.White;
            button_load_price.FlatStyle = FlatStyle.Flat;
            button_load_price.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_load_price.ForeColor = Color.DimGray;
            button_load_price.Location = new Point(0, 124);
            button_load_price.Margin = new Padding(4, 4, 4, 4);
            button_load_price.Name = "button_load_price";
            button_load_price.Padding = new Padding(50, 0, 0, 0);
            button_load_price.Size = new Size(500, 62);
            button_load_price.TabIndex = 5;
            button_load_price.TabStop = false;
            button_load_price.Text = "- โหลดปรับราคา";
            button_load_price.TextAlign = ContentAlignment.MiddleLeft;
            button_load_price.UseVisualStyleBackColor = false;
            button_load_price.Click += button_load_price_Click;
            button_load_price.MouseEnter += button_MouseEnter;
            button_load_price.MouseLeave += button_MouseLeave;
            // 
            // button_load_qty
            // 
            button_load_qty.BackColor = Color.White;
            button_load_qty.Dock = DockStyle.Top;
            button_load_qty.FlatAppearance.BorderSize = 0;
            button_load_qty.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_load_qty.FlatAppearance.MouseOverBackColor = Color.White;
            button_load_qty.FlatStyle = FlatStyle.Flat;
            button_load_qty.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_load_qty.ForeColor = Color.DimGray;
            button_load_qty.Location = new Point(0, 62);
            button_load_qty.Margin = new Padding(4, 4, 4, 4);
            button_load_qty.Name = "button_load_qty";
            button_load_qty.Padding = new Padding(50, 0, 0, 0);
            button_load_qty.Size = new Size(500, 62);
            button_load_qty.TabIndex = 4;
            button_load_qty.TabStop = false;
            button_load_qty.Text = "- โหลดปรับจำนวน";
            button_load_qty.TextAlign = ContentAlignment.MiddleLeft;
            button_load_qty.UseVisualStyleBackColor = false;
            button_load_qty.Click += button_load_qty_Click;
            button_load_qty.MouseEnter += button_MouseEnter;
            button_load_qty.MouseLeave += button_MouseLeave;
            // 
            // button_load_add
            // 
            button_load_add.BackColor = Color.White;
            button_load_add.Dock = DockStyle.Top;
            button_load_add.FlatAppearance.BorderSize = 0;
            button_load_add.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_load_add.FlatAppearance.MouseOverBackColor = Color.White;
            button_load_add.FlatStyle = FlatStyle.Flat;
            button_load_add.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_load_add.ForeColor = Color.DimGray;
            button_load_add.Location = new Point(0, 0);
            button_load_add.Margin = new Padding(4, 4, 4, 4);
            button_load_add.Name = "button_load_add";
            button_load_add.Padding = new Padding(50, 0, 0, 0);
            button_load_add.Size = new Size(500, 62);
            button_load_add.TabIndex = 3;
            button_load_add.TabStop = false;
            button_load_add.Text = "- โหลดเพิ่มสินค้า";
            button_load_add.TextAlign = ContentAlignment.MiddleLeft;
            button_load_add.UseVisualStyleBackColor = false;
            button_load_add.Click += button_load_add_Click;
            button_load_add.MouseEnter += button_MouseEnter;
            button_load_add.MouseLeave += button_MouseLeave;
            // 
            // button_load_excel
            // 
            button_load_excel.BackColor = Color.FromArgb(192, 255, 255);
            button_load_excel.BackgroundImageLayout = ImageLayout.Zoom;
            button_load_excel.Dock = DockStyle.Top;
            button_load_excel.FlatAppearance.BorderSize = 0;
            button_load_excel.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 255);
            button_load_excel.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 255);
            button_load_excel.FlatStyle = FlatStyle.Flat;
            button_load_excel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_load_excel.ForeColor = Color.DimGray;
            button_load_excel.ImageAlign = ContentAlignment.MiddleLeft;
            button_load_excel.Location = new Point(0, 400);
            button_load_excel.Margin = new Padding(0);
            button_load_excel.Name = "button_load_excel";
            button_load_excel.Size = new Size(500, 62);
            button_load_excel.TabIndex = 6;
            button_load_excel.TabStop = false;
            button_load_excel.Text = "โหลดสินค้า";
            button_load_excel.TextAlign = ContentAlignment.MiddleLeft;
            button_load_excel.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_load_excel.UseVisualStyleBackColor = false;
            button_load_excel.Click += button_load_excel_Click;
            button_load_excel.MouseEnter += button_MouseEnter;
            button_load_excel.MouseLeave += button_MouseLeave;
            // 
            // panel_item
            // 
            panel_item.BackColor = Color.FromArgb(192, 255, 255);
            panel_item.Controls.Add(button_item_adjust);
            panel_item.Controls.Add(button_item_hotkey);
            panel_item.Controls.Add(button_item_detail);
            panel_item.Controls.Add(button_item_group);
            panel_item.Dock = DockStyle.Top;
            panel_item.Location = new Point(0, 150);
            panel_item.Margin = new Padding(4, 4, 4, 4);
            panel_item.Name = "panel_item";
            panel_item.Size = new Size(500, 250);
            panel_item.TabIndex = 2;
            // 
            // button_item_adjust
            // 
            button_item_adjust.BackColor = Color.White;
            button_item_adjust.Dock = DockStyle.Top;
            button_item_adjust.FlatAppearance.BorderSize = 0;
            button_item_adjust.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_item_adjust.FlatAppearance.MouseOverBackColor = Color.White;
            button_item_adjust.FlatStyle = FlatStyle.Flat;
            button_item_adjust.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_item_adjust.ForeColor = Color.DimGray;
            button_item_adjust.Location = new Point(0, 186);
            button_item_adjust.Margin = new Padding(4, 4, 4, 4);
            button_item_adjust.Name = "button_item_adjust";
            button_item_adjust.Padding = new Padding(50, 0, 0, 0);
            button_item_adjust.Size = new Size(500, 62);
            button_item_adjust.TabIndex = 1;
            button_item_adjust.TabStop = false;
            button_item_adjust.Text = "- ปรับจำนวนสินค้า";
            button_item_adjust.TextAlign = ContentAlignment.MiddleLeft;
            button_item_adjust.UseVisualStyleBackColor = false;
            button_item_adjust.Click += button_item_adjust_Click;
            button_item_adjust.MouseEnter += button_MouseEnter;
            button_item_adjust.MouseLeave += button_MouseLeave;
            // 
            // button_item_hotkey
            // 
            button_item_hotkey.BackColor = Color.White;
            button_item_hotkey.Dock = DockStyle.Top;
            button_item_hotkey.FlatAppearance.BorderSize = 0;
            button_item_hotkey.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_item_hotkey.FlatAppearance.MouseOverBackColor = Color.White;
            button_item_hotkey.FlatStyle = FlatStyle.Flat;
            button_item_hotkey.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_item_hotkey.ForeColor = Color.DimGray;
            button_item_hotkey.Location = new Point(0, 124);
            button_item_hotkey.Margin = new Padding(4, 4, 4, 4);
            button_item_hotkey.Name = "button_item_hotkey";
            button_item_hotkey.Padding = new Padding(50, 0, 0, 0);
            button_item_hotkey.Size = new Size(500, 62);
            button_item_hotkey.TabIndex = 4;
            button_item_hotkey.TabStop = false;
            button_item_hotkey.Text = "- คีย์ลัดหน้าขายสินค้า";
            button_item_hotkey.TextAlign = ContentAlignment.MiddleLeft;
            button_item_hotkey.UseVisualStyleBackColor = false;
            button_item_hotkey.Click += button_item_hotkey_Click;
            button_item_hotkey.MouseEnter += button_MouseEnter;
            button_item_hotkey.MouseLeave += button_MouseLeave;
            // 
            // button_item_detail
            // 
            button_item_detail.BackColor = Color.White;
            button_item_detail.Dock = DockStyle.Top;
            button_item_detail.FlatAppearance.BorderSize = 0;
            button_item_detail.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_item_detail.FlatAppearance.MouseOverBackColor = Color.White;
            button_item_detail.FlatStyle = FlatStyle.Flat;
            button_item_detail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_item_detail.ForeColor = Color.DimGray;
            button_item_detail.Location = new Point(0, 62);
            button_item_detail.Margin = new Padding(4, 4, 4, 4);
            button_item_detail.Name = "button_item_detail";
            button_item_detail.Padding = new Padding(50, 0, 0, 0);
            button_item_detail.Size = new Size(500, 62);
            button_item_detail.TabIndex = 0;
            button_item_detail.TabStop = false;
            button_item_detail.Text = "- ข้อมูลสินค้า";
            button_item_detail.TextAlign = ContentAlignment.MiddleLeft;
            button_item_detail.UseVisualStyleBackColor = false;
            button_item_detail.Click += button_item_detail_Click;
            button_item_detail.MouseEnter += button_MouseEnter;
            button_item_detail.MouseLeave += button_MouseLeave;
            // 
            // button_item_group
            // 
            button_item_group.BackColor = Color.White;
            button_item_group.Dock = DockStyle.Top;
            button_item_group.FlatAppearance.BorderSize = 0;
            button_item_group.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_item_group.FlatAppearance.MouseOverBackColor = Color.White;
            button_item_group.FlatStyle = FlatStyle.Flat;
            button_item_group.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_item_group.ForeColor = Color.DimGray;
            button_item_group.Location = new Point(0, 0);
            button_item_group.Margin = new Padding(4, 4, 4, 4);
            button_item_group.Name = "button_item_group";
            button_item_group.Padding = new Padding(50, 0, 0, 0);
            button_item_group.Size = new Size(500, 62);
            button_item_group.TabIndex = 2;
            button_item_group.TabStop = false;
            button_item_group.Text = "- กลุ่มสินค้า";
            button_item_group.TextAlign = ContentAlignment.MiddleLeft;
            button_item_group.UseVisualStyleBackColor = false;
            button_item_group.Click += button_item_group_Click;
            button_item_group.MouseEnter += button_MouseEnter;
            button_item_group.MouseLeave += button_MouseLeave;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // button_menu
            // 
            button_menu.BackColor = Color.Cyan;
            button_menu.Dock = DockStyle.Left;
            button_menu.FlatAppearance.BorderSize = 0;
            button_menu.FlatAppearance.MouseDownBackColor = Color.Cyan;
            button_menu.FlatAppearance.MouseOverBackColor = Color.Cyan;
            button_menu.FlatStyle = FlatStyle.Flat;
            button_menu.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_menu.ForeColor = Color.Cyan;
            button_menu.Location = new Point(500, 0);
            button_menu.Margin = new Padding(4, 4, 4, 4);
            button_menu.Name = "button_menu";
            button_menu.Size = new Size(31, 1502);
            button_menu.TabIndex = 6;
            button_menu.TabStop = false;
            button_menu.Text = ">";
            button_menu.UseVisualStyleBackColor = false;
            button_menu.Click += button_menu_Click;
            button_menu.MouseEnter += button_menu_MouseEnter;
            button_menu.MouseLeave += button_menu_MouseLeave;
            // 
            // timer_menu_1
            // 
            timer_menu_1.Interval = 15;
            timer_menu_1.Tick += timer_menu_1_Tick;
            // 
            // timer_menu_2
            // 
            timer_menu_2.Interval = 15;
            timer_menu_2.Tick += timer_menu_2_Tick;
            // 
            // panel_menu_back
            // 
            panel_menu_back.BackColor = Color.Cyan;
            panel_menu_back.Controls.Add(panel_menu);
            panel_menu_back.Dock = DockStyle.Left;
            panel_menu_back.Location = new Point(0, 0);
            panel_menu_back.Margin = new Padding(4, 4, 4, 4);
            panel_menu_back.Name = "panel_menu_back";
            panel_menu_back.Size = new Size(500, 1502);
            panel_menu_back.TabIndex = 8;
            // 
            // timer_tab_menu
            // 
            timer_tab_menu.Interval = 15;
            timer_tab_menu.Tick += timer_tab_menu_Tick;
            // 
            // panel_back
            // 
            panel_back.Controls.Add(button_menu);
            panel_back.Controls.Add(panel_menu_back);
            panel_back.Controls.Add(panel_main);
            panel_back.Dock = DockStyle.Fill;
            panel_back.Location = new Point(0, 88);
            panel_back.Margin = new Padding(0);
            panel_back.Name = "panel_back";
            panel_back.Size = new Size(1280, 1502);
            panel_back.TabIndex = 10;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(panel_back, 0, 1);
            tableLayoutPanel_back.Controls.Add(panel_top_main, 0, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(4, 4, 4, 4);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(1280, 1590);
            tableLayoutPanel_back.TabIndex = 11;
            // 
            // timer_check_tab
            // 
            timer_check_tab.Tick += timer_check_tab_Tick;
            // 
            // Form_Main
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1280, 1590);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form_Main";
            StartPosition = FormStartPosition.CenterScreen;
            TransparencyKey = Color.White;
            FormClosing += Form_Main_FormClosing;
            Load += Form_Main_Load;
            panel_top_main.ResumeLayout(false);
            tableLayoutPanel_datetime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_time).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_date).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).EndInit();
            panel_menu.ResumeLayout(false);
            panel_setting.ResumeLayout(false);
            panel_report.ResumeLayout(false);
            panel_member.ResumeLayout(false);
            panel_promotion.ResumeLayout(false);
            panel_load_excel.ResumeLayout(false);
            panel_item.ResumeLayout(false);
            panel_menu_back.ResumeLayout(false);
            panel_back.ResumeLayout(false);
            tableLayoutPanel_back.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button_exit;
        private Panel panel_top_main;
        private Button button_sale;
        private Button button_item;
        private Button button_report;
        private Button button_member;
        private PictureBox pictureBox_logo;
        private Button button_promotion;
        private Button button_setting;
        private Panel panel_menu;
        private Panel panel_setting;
        private Button button_setting_user;
        private Label label_title;
        private System.Windows.Forms.Timer timer;
        private Panel panel_item;
        private Panel panel_promotion;
        private Panel panel_report;
        private Panel panel_member;
        private Button button_item_detail;
        private Button button_item_adjust;
        private Button button_menu;
        private TableLayoutPanel tableLayoutPanel_datetime;
        private PictureBox pictureBox_date;
        private PictureBox pictureBox_time;
        private Label label_date;
        private Label label_time;
        private Button button_setting_camera;
        private Button button_report_trans;
        private Button button_set_item;
        private Button button_mix_item;
        private Button button_pro_item;
        public Panel panel_main;
        private Button button_member_detail;
        private Button button_setting_config_pro;
        public Button button_item_group;
        private Button button_load_add;
        private Button button_setting_store;
        private Button button_item_hotkey;
        private Button button_load_excel;
        private Panel panel_load_excel;
        private Button button_load_price;
        private Button button_load_qty;
        private System.Windows.Forms.Timer timer_menu_1;
        private System.Windows.Forms.Timer timer_menu_2;
        private Panel panel_menu_back;
        private System.Windows.Forms.Timer timer_tab_menu;
        private Panel panel_back;
        private TableLayoutPanel tableLayoutPanel_back;
        private System.Windows.Forms.Timer timer_check_tab;
    }
}