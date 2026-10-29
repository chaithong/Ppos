namespace Ppos
{
    partial class Form_Calendar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Calendar));
            tableLayoutPanel_back = new TableLayoutPanel();
            label_set_days = new Label();
            button_confirm = new Button();
            label_title = new Label();
            panel_top = new Panel();
            label_month_year = new Label();
            button_next = new Button();
            button_back = new Button();
            tableLayoutPanel_calendar = new TableLayoutPanel();
            label_sun = new Label();
            label_mon = new Label();
            label_tue = new Label();
            label_wed = new Label();
            label_thu = new Label();
            label_fri = new Label();
            label_sat = new Label();
            label_1 = new Label();
            label_2 = new Label();
            label_3 = new Label();
            label_4 = new Label();
            label_5 = new Label();
            label_6 = new Label();
            label_7 = new Label();
            label_14 = new Label();
            label_13 = new Label();
            label_12 = new Label();
            label_11 = new Label();
            label_10 = new Label();
            label_9 = new Label();
            label_8 = new Label();
            label_15 = new Label();
            label_16 = new Label();
            label_17 = new Label();
            label_18 = new Label();
            label_19 = new Label();
            label_20 = new Label();
            label_21 = new Label();
            label_28 = new Label();
            label_27 = new Label();
            label_26 = new Label();
            label_25 = new Label();
            label_24 = new Label();
            label_23 = new Label();
            label_22 = new Label();
            label_29 = new Label();
            label_30 = new Label();
            label_31 = new Label();
            label_32 = new Label();
            label_33 = new Label();
            label_34 = new Label();
            label_35 = new Label();
            label_42 = new Label();
            label_41 = new Label();
            label_40 = new Label();
            label_39 = new Label();
            label_38 = new Label();
            label_37 = new Label();
            label_36 = new Label();
            tableLayoutPanel_back.SuspendLayout();
            panel_top.SuspendLayout();
            tableLayoutPanel_calendar.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.White;
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(label_set_days, 0, 3);
            tableLayoutPanel_back.Controls.Add(button_confirm, 0, 4);
            tableLayoutPanel_back.Controls.Add(label_title, 0, 0);
            tableLayoutPanel_back.Controls.Add(panel_top, 0, 1);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_calendar, 0, 2);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 5;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.Size = new Size(682, 653);
            tableLayoutPanel_back.TabIndex = 0;
            // 
            // label_set_days
            // 
            label_set_days.BackColor = Color.Transparent;
            label_set_days.Dock = DockStyle.Fill;
            label_set_days.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label_set_days.Location = new Point(0, 493);
            label_set_days.Margin = new Padding(0);
            label_set_days.Name = "label_set_days";
            label_set_days.Size = new Size(682, 60);
            label_set_days.TabIndex = 4;
            label_set_days.Text = "--";
            label_set_days.TextAlign = ContentAlignment.MiddleCenter;
            label_set_days.MouseEnter += label_MouseEnter;
            label_set_days.MouseLeave += label_MouseLeave;
            // 
            // button_confirm
            // 
            button_confirm.BackColor = Color.White;
            button_confirm.BackgroundImageLayout = ImageLayout.Zoom;
            button_confirm.Dock = DockStyle.Fill;
            button_confirm.FlatAppearance.BorderSize = 0;
            button_confirm.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_confirm.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_confirm.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_confirm.Location = new Point(3, 556);
            button_confirm.Name = "button_confirm";
            button_confirm.Size = new Size(676, 94);
            button_confirm.TabIndex = 0;
            button_confirm.Text = "ตกลง";
            button_confirm.TextAlign = ContentAlignment.MiddleRight;
            button_confirm.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_confirm.UseVisualStyleBackColor = false;
            button_confirm.Click += button_confirm_Click;
            button_confirm.MouseEnter += button_MouseEnter;
            button_confirm.MouseLeave += button_MouseLeave;
            // 
            // label_title
            // 
            label_title.BackColor = Color.Transparent;
            label_title.Dock = DockStyle.Fill;
            label_title.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Underline);
            label_title.ForeColor = Color.Black;
            label_title.Location = new Point(0, 0);
            label_title.Margin = new Padding(0);
            label_title.Name = "label_title";
            label_title.Size = new Size(682, 50);
            label_title.TabIndex = 1;
            label_title.Text = "หัวข้อ";
            label_title.TextAlign = ContentAlignment.MiddleCenter;
            label_title.MouseEnter += label_MouseEnter;
            label_title.MouseLeave += label_MouseLeave;
            // 
            // panel_top
            // 
            panel_top.Controls.Add(label_month_year);
            panel_top.Controls.Add(button_next);
            panel_top.Controls.Add(button_back);
            panel_top.Dock = DockStyle.Fill;
            panel_top.Location = new Point(0, 50);
            panel_top.Margin = new Padding(0);
            panel_top.Name = "panel_top";
            panel_top.Size = new Size(682, 60);
            panel_top.TabIndex = 2;
            // 
            // label_month_year
            // 
            label_month_year.BackColor = Color.White;
            label_month_year.Dock = DockStyle.Fill;
            label_month_year.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_month_year.Location = new Point(70, 0);
            label_month_year.Margin = new Padding(0, 0, 0, 3);
            label_month_year.Name = "label_month_year";
            label_month_year.Size = new Size(542, 60);
            label_month_year.TabIndex = 2;
            label_month_year.Text = "--";
            label_month_year.TextAlign = ContentAlignment.MiddleCenter;
            label_month_year.DoubleClick += label_month_year_DoubleClick;
            label_month_year.MouseEnter += label_MouseEnter;
            label_month_year.MouseLeave += label_MouseLeave;
            // 
            // button_next
            // 
            button_next.BackColor = Color.Transparent;
            button_next.BackgroundImageLayout = ImageLayout.Zoom;
            button_next.Dock = DockStyle.Right;
            button_next.FlatAppearance.BorderSize = 0;
            button_next.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_next.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_next.FlatStyle = FlatStyle.Flat;
            button_next.Location = new Point(612, 0);
            button_next.Name = "button_next";
            button_next.Size = new Size(70, 60);
            button_next.TabIndex = 1;
            button_next.UseVisualStyleBackColor = false;
            button_next.Click += button_next_Click;
            button_next.MouseEnter += button_MouseEnter;
            button_next.MouseLeave += button_MouseLeave;
            // 
            // button_back
            // 
            button_back.BackColor = Color.Transparent;
            button_back.BackgroundImageLayout = ImageLayout.Zoom;
            button_back.Dock = DockStyle.Left;
            button_back.FlatAppearance.BorderSize = 0;
            button_back.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_back.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_back.FlatStyle = FlatStyle.Flat;
            button_back.Location = new Point(0, 0);
            button_back.Name = "button_back";
            button_back.Size = new Size(70, 60);
            button_back.TabIndex = 0;
            button_back.UseVisualStyleBackColor = false;
            button_back.Click += button_back_Click;
            button_back.MouseEnter += button_MouseEnter;
            button_back.MouseLeave += button_MouseLeave;
            // 
            // tableLayoutPanel_calendar
            // 
            tableLayoutPanel_calendar.BackColor = Color.White;
            tableLayoutPanel_calendar.ColumnCount = 7;
            tableLayoutPanel_calendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857113F));
            tableLayoutPanel_calendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel_calendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel_calendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel_calendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel_calendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel_calendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel_calendar.Controls.Add(label_sun, 0, 0);
            tableLayoutPanel_calendar.Controls.Add(label_mon, 1, 0);
            tableLayoutPanel_calendar.Controls.Add(label_tue, 2, 0);
            tableLayoutPanel_calendar.Controls.Add(label_wed, 3, 0);
            tableLayoutPanel_calendar.Controls.Add(label_thu, 4, 0);
            tableLayoutPanel_calendar.Controls.Add(label_fri, 5, 0);
            tableLayoutPanel_calendar.Controls.Add(label_sat, 6, 0);
            tableLayoutPanel_calendar.Controls.Add(label_1, 0, 1);
            tableLayoutPanel_calendar.Controls.Add(label_2, 1, 1);
            tableLayoutPanel_calendar.Controls.Add(label_3, 2, 1);
            tableLayoutPanel_calendar.Controls.Add(label_4, 3, 1);
            tableLayoutPanel_calendar.Controls.Add(label_5, 4, 1);
            tableLayoutPanel_calendar.Controls.Add(label_6, 5, 1);
            tableLayoutPanel_calendar.Controls.Add(label_7, 6, 1);
            tableLayoutPanel_calendar.Controls.Add(label_14, 6, 2);
            tableLayoutPanel_calendar.Controls.Add(label_13, 5, 2);
            tableLayoutPanel_calendar.Controls.Add(label_12, 4, 2);
            tableLayoutPanel_calendar.Controls.Add(label_11, 3, 2);
            tableLayoutPanel_calendar.Controls.Add(label_10, 2, 2);
            tableLayoutPanel_calendar.Controls.Add(label_9, 1, 2);
            tableLayoutPanel_calendar.Controls.Add(label_8, 0, 2);
            tableLayoutPanel_calendar.Controls.Add(label_15, 0, 3);
            tableLayoutPanel_calendar.Controls.Add(label_16, 1, 3);
            tableLayoutPanel_calendar.Controls.Add(label_17, 2, 3);
            tableLayoutPanel_calendar.Controls.Add(label_18, 3, 3);
            tableLayoutPanel_calendar.Controls.Add(label_19, 4, 3);
            tableLayoutPanel_calendar.Controls.Add(label_20, 5, 3);
            tableLayoutPanel_calendar.Controls.Add(label_21, 6, 3);
            tableLayoutPanel_calendar.Controls.Add(label_28, 6, 4);
            tableLayoutPanel_calendar.Controls.Add(label_27, 5, 4);
            tableLayoutPanel_calendar.Controls.Add(label_26, 4, 4);
            tableLayoutPanel_calendar.Controls.Add(label_25, 3, 4);
            tableLayoutPanel_calendar.Controls.Add(label_24, 2, 4);
            tableLayoutPanel_calendar.Controls.Add(label_23, 1, 4);
            tableLayoutPanel_calendar.Controls.Add(label_22, 0, 4);
            tableLayoutPanel_calendar.Controls.Add(label_29, 0, 5);
            tableLayoutPanel_calendar.Controls.Add(label_30, 1, 5);
            tableLayoutPanel_calendar.Controls.Add(label_31, 2, 5);
            tableLayoutPanel_calendar.Controls.Add(label_32, 3, 5);
            tableLayoutPanel_calendar.Controls.Add(label_33, 4, 5);
            tableLayoutPanel_calendar.Controls.Add(label_34, 5, 5);
            tableLayoutPanel_calendar.Controls.Add(label_35, 6, 5);
            tableLayoutPanel_calendar.Controls.Add(label_42, 6, 6);
            tableLayoutPanel_calendar.Controls.Add(label_41, 5, 6);
            tableLayoutPanel_calendar.Controls.Add(label_40, 4, 6);
            tableLayoutPanel_calendar.Controls.Add(label_39, 3, 6);
            tableLayoutPanel_calendar.Controls.Add(label_38, 2, 6);
            tableLayoutPanel_calendar.Controls.Add(label_37, 1, 6);
            tableLayoutPanel_calendar.Controls.Add(label_36, 0, 6);
            tableLayoutPanel_calendar.Dock = DockStyle.Fill;
            tableLayoutPanel_calendar.Location = new Point(0, 110);
            tableLayoutPanel_calendar.Margin = new Padding(0);
            tableLayoutPanel_calendar.Name = "tableLayoutPanel_calendar";
            tableLayoutPanel_calendar.RowCount = 7;
            tableLayoutPanel_calendar.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel_calendar.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel_calendar.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel_calendar.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel_calendar.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel_calendar.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel_calendar.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel_calendar.Size = new Size(682, 383);
            tableLayoutPanel_calendar.TabIndex = 3;
            // 
            // label_sun
            // 
            label_sun.BackColor = Color.FromArgb(255, 192, 192);
            label_sun.Dock = DockStyle.Fill;
            label_sun.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_sun.Location = new Point(0, 0);
            label_sun.Margin = new Padding(0);
            label_sun.Name = "label_sun";
            label_sun.Size = new Size(97, 54);
            label_sun.TabIndex = 0;
            label_sun.Text = "อาทิตย์";
            label_sun.TextAlign = ContentAlignment.MiddleCenter;
            label_sun.MouseEnter += label_MouseEnter;
            label_sun.MouseLeave += label_MouseLeave;
            // 
            // label_mon
            // 
            label_mon.BackColor = Color.FromArgb(192, 255, 192);
            label_mon.Dock = DockStyle.Fill;
            label_mon.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_mon.Location = new Point(97, 0);
            label_mon.Margin = new Padding(0);
            label_mon.Name = "label_mon";
            label_mon.Size = new Size(97, 54);
            label_mon.TabIndex = 0;
            label_mon.Text = "จันทร์";
            label_mon.TextAlign = ContentAlignment.MiddleCenter;
            label_mon.MouseEnter += label_MouseEnter;
            label_mon.MouseLeave += label_MouseLeave;
            // 
            // label_tue
            // 
            label_tue.BackColor = Color.FromArgb(192, 255, 192);
            label_tue.Dock = DockStyle.Fill;
            label_tue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_tue.Location = new Point(194, 0);
            label_tue.Margin = new Padding(0);
            label_tue.Name = "label_tue";
            label_tue.Size = new Size(97, 54);
            label_tue.TabIndex = 0;
            label_tue.Text = "อังคาร";
            label_tue.TextAlign = ContentAlignment.MiddleCenter;
            label_tue.MouseEnter += label_MouseEnter;
            label_tue.MouseLeave += label_MouseLeave;
            // 
            // label_wed
            // 
            label_wed.BackColor = Color.FromArgb(192, 255, 192);
            label_wed.Dock = DockStyle.Fill;
            label_wed.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_wed.Location = new Point(291, 0);
            label_wed.Margin = new Padding(0);
            label_wed.Name = "label_wed";
            label_wed.Size = new Size(97, 54);
            label_wed.TabIndex = 0;
            label_wed.Text = "พุธ";
            label_wed.TextAlign = ContentAlignment.MiddleCenter;
            label_wed.MouseEnter += label_MouseEnter;
            label_wed.MouseLeave += label_MouseLeave;
            // 
            // label_thu
            // 
            label_thu.BackColor = Color.FromArgb(192, 255, 192);
            label_thu.Dock = DockStyle.Fill;
            label_thu.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_thu.Location = new Point(388, 0);
            label_thu.Margin = new Padding(0);
            label_thu.Name = "label_thu";
            label_thu.Size = new Size(97, 54);
            label_thu.TabIndex = 0;
            label_thu.Text = "พฤหัส";
            label_thu.TextAlign = ContentAlignment.MiddleCenter;
            label_thu.MouseEnter += label_MouseEnter;
            label_thu.MouseLeave += label_MouseLeave;
            // 
            // label_fri
            // 
            label_fri.BackColor = Color.FromArgb(192, 255, 192);
            label_fri.Dock = DockStyle.Fill;
            label_fri.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_fri.Location = new Point(485, 0);
            label_fri.Margin = new Padding(0);
            label_fri.Name = "label_fri";
            label_fri.Size = new Size(97, 54);
            label_fri.TabIndex = 0;
            label_fri.Text = "ศุกร์";
            label_fri.TextAlign = ContentAlignment.MiddleCenter;
            label_fri.MouseEnter += label_MouseEnter;
            label_fri.MouseLeave += label_MouseLeave;
            // 
            // label_sat
            // 
            label_sat.BackColor = Color.FromArgb(255, 192, 192);
            label_sat.Dock = DockStyle.Fill;
            label_sat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_sat.Location = new Point(582, 0);
            label_sat.Margin = new Padding(0);
            label_sat.Name = "label_sat";
            label_sat.Size = new Size(100, 54);
            label_sat.TabIndex = 0;
            label_sat.Text = "เสาร์";
            label_sat.TextAlign = ContentAlignment.MiddleCenter;
            label_sat.MouseEnter += label_MouseEnter;
            label_sat.MouseLeave += label_MouseLeave;
            // 
            // label_1
            // 
            label_1.Dock = DockStyle.Fill;
            label_1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_1.Location = new Point(3, 57);
            label_1.Margin = new Padding(3);
            label_1.Name = "label_1";
            label_1.Size = new Size(91, 48);
            label_1.TabIndex = 1;
            label_1.TextAlign = ContentAlignment.MiddleCenter;
            label_1.Click += label_click;
            label_1.DoubleClick += label_doubleclick;
            label_1.MouseEnter += label_MouseEnter;
            label_1.MouseLeave += label_MouseLeave;
            // 
            // label_2
            // 
            label_2.Dock = DockStyle.Fill;
            label_2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_2.Location = new Point(100, 57);
            label_2.Margin = new Padding(3);
            label_2.Name = "label_2";
            label_2.Size = new Size(91, 48);
            label_2.TabIndex = 1;
            label_2.TextAlign = ContentAlignment.MiddleCenter;
            label_2.Click += label_click;
            label_2.DoubleClick += label_doubleclick;
            label_2.MouseEnter += label_MouseEnter;
            label_2.MouseLeave += label_MouseLeave;
            // 
            // label_3
            // 
            label_3.Dock = DockStyle.Fill;
            label_3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_3.Location = new Point(197, 57);
            label_3.Margin = new Padding(3);
            label_3.Name = "label_3";
            label_3.Size = new Size(91, 48);
            label_3.TabIndex = 1;
            label_3.TextAlign = ContentAlignment.MiddleCenter;
            label_3.Click += label_click;
            label_3.DoubleClick += label_doubleclick;
            label_3.MouseEnter += label_MouseEnter;
            label_3.MouseLeave += label_MouseLeave;
            // 
            // label_4
            // 
            label_4.Dock = DockStyle.Fill;
            label_4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_4.Location = new Point(294, 57);
            label_4.Margin = new Padding(3);
            label_4.Name = "label_4";
            label_4.Size = new Size(91, 48);
            label_4.TabIndex = 1;
            label_4.TextAlign = ContentAlignment.MiddleCenter;
            label_4.Click += label_click;
            label_4.DoubleClick += label_doubleclick;
            label_4.MouseEnter += label_MouseEnter;
            label_4.MouseLeave += label_MouseLeave;
            // 
            // label_5
            // 
            label_5.Dock = DockStyle.Fill;
            label_5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_5.Location = new Point(391, 57);
            label_5.Margin = new Padding(3);
            label_5.Name = "label_5";
            label_5.Size = new Size(91, 48);
            label_5.TabIndex = 1;
            label_5.TextAlign = ContentAlignment.MiddleCenter;
            label_5.Click += label_click;
            label_5.DoubleClick += label_doubleclick;
            label_5.MouseEnter += label_MouseEnter;
            label_5.MouseLeave += label_MouseLeave;
            // 
            // label_6
            // 
            label_6.Dock = DockStyle.Fill;
            label_6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_6.Location = new Point(488, 57);
            label_6.Margin = new Padding(3);
            label_6.Name = "label_6";
            label_6.Size = new Size(91, 48);
            label_6.TabIndex = 1;
            label_6.TextAlign = ContentAlignment.MiddleCenter;
            label_6.Click += label_click;
            label_6.DoubleClick += label_doubleclick;
            label_6.MouseEnter += label_MouseEnter;
            label_6.MouseLeave += label_MouseLeave;
            // 
            // label_7
            // 
            label_7.Dock = DockStyle.Fill;
            label_7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_7.Location = new Point(585, 57);
            label_7.Margin = new Padding(3);
            label_7.Name = "label_7";
            label_7.Size = new Size(94, 48);
            label_7.TabIndex = 1;
            label_7.TextAlign = ContentAlignment.MiddleCenter;
            label_7.Click += label_click;
            label_7.DoubleClick += label_doubleclick;
            label_7.MouseEnter += label_MouseEnter;
            label_7.MouseLeave += label_MouseLeave;
            // 
            // label_14
            // 
            label_14.Dock = DockStyle.Fill;
            label_14.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_14.Location = new Point(585, 111);
            label_14.Margin = new Padding(3);
            label_14.Name = "label_14";
            label_14.Size = new Size(94, 48);
            label_14.TabIndex = 1;
            label_14.TextAlign = ContentAlignment.MiddleCenter;
            label_14.Click += label_click;
            label_14.DoubleClick += label_doubleclick;
            label_14.MouseEnter += label_MouseEnter;
            label_14.MouseLeave += label_MouseLeave;
            // 
            // label_13
            // 
            label_13.Dock = DockStyle.Fill;
            label_13.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_13.Location = new Point(488, 111);
            label_13.Margin = new Padding(3);
            label_13.Name = "label_13";
            label_13.Size = new Size(91, 48);
            label_13.TabIndex = 1;
            label_13.TextAlign = ContentAlignment.MiddleCenter;
            label_13.Click += label_click;
            label_13.DoubleClick += label_doubleclick;
            label_13.MouseEnter += label_MouseEnter;
            label_13.MouseLeave += label_MouseLeave;
            // 
            // label_12
            // 
            label_12.Dock = DockStyle.Fill;
            label_12.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_12.Location = new Point(391, 111);
            label_12.Margin = new Padding(3);
            label_12.Name = "label_12";
            label_12.Size = new Size(91, 48);
            label_12.TabIndex = 1;
            label_12.TextAlign = ContentAlignment.MiddleCenter;
            label_12.Click += label_click;
            label_12.DoubleClick += label_doubleclick;
            label_12.MouseEnter += label_MouseEnter;
            label_12.MouseLeave += label_MouseLeave;
            // 
            // label_11
            // 
            label_11.Dock = DockStyle.Fill;
            label_11.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_11.Location = new Point(294, 111);
            label_11.Margin = new Padding(3);
            label_11.Name = "label_11";
            label_11.Size = new Size(91, 48);
            label_11.TabIndex = 1;
            label_11.TextAlign = ContentAlignment.MiddleCenter;
            label_11.Click += label_click;
            label_11.DoubleClick += label_doubleclick;
            label_11.MouseEnter += label_MouseEnter;
            label_11.MouseLeave += label_MouseLeave;
            // 
            // label_10
            // 
            label_10.Dock = DockStyle.Fill;
            label_10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_10.Location = new Point(197, 111);
            label_10.Margin = new Padding(3);
            label_10.Name = "label_10";
            label_10.Size = new Size(91, 48);
            label_10.TabIndex = 1;
            label_10.TextAlign = ContentAlignment.MiddleCenter;
            label_10.Click += label_click;
            label_10.DoubleClick += label_doubleclick;
            label_10.MouseEnter += label_MouseEnter;
            label_10.MouseLeave += label_MouseLeave;
            // 
            // label_9
            // 
            label_9.Dock = DockStyle.Fill;
            label_9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_9.Location = new Point(100, 111);
            label_9.Margin = new Padding(3);
            label_9.Name = "label_9";
            label_9.Size = new Size(91, 48);
            label_9.TabIndex = 1;
            label_9.TextAlign = ContentAlignment.MiddleCenter;
            label_9.Click += label_click;
            label_9.DoubleClick += label_doubleclick;
            label_9.MouseEnter += label_MouseEnter;
            label_9.MouseLeave += label_MouseLeave;
            // 
            // label_8
            // 
            label_8.Dock = DockStyle.Fill;
            label_8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_8.Location = new Point(3, 111);
            label_8.Margin = new Padding(3);
            label_8.Name = "label_8";
            label_8.Size = new Size(91, 48);
            label_8.TabIndex = 1;
            label_8.TextAlign = ContentAlignment.MiddleCenter;
            label_8.Click += label_click;
            label_8.DoubleClick += label_doubleclick;
            label_8.MouseEnter += label_MouseEnter;
            label_8.MouseLeave += label_MouseLeave;
            // 
            // label_15
            // 
            label_15.Dock = DockStyle.Fill;
            label_15.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_15.Location = new Point(3, 165);
            label_15.Margin = new Padding(3);
            label_15.Name = "label_15";
            label_15.Size = new Size(91, 48);
            label_15.TabIndex = 1;
            label_15.TextAlign = ContentAlignment.MiddleCenter;
            label_15.Click += label_click;
            label_15.DoubleClick += label_doubleclick;
            label_15.MouseEnter += label_MouseEnter;
            label_15.MouseLeave += label_MouseLeave;
            // 
            // label_16
            // 
            label_16.Dock = DockStyle.Fill;
            label_16.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_16.Location = new Point(100, 165);
            label_16.Margin = new Padding(3);
            label_16.Name = "label_16";
            label_16.Size = new Size(91, 48);
            label_16.TabIndex = 1;
            label_16.TextAlign = ContentAlignment.MiddleCenter;
            label_16.Click += label_click;
            label_16.DoubleClick += label_doubleclick;
            label_16.MouseEnter += label_MouseEnter;
            label_16.MouseLeave += label_MouseLeave;
            // 
            // label_17
            // 
            label_17.Dock = DockStyle.Fill;
            label_17.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_17.Location = new Point(197, 165);
            label_17.Margin = new Padding(3);
            label_17.Name = "label_17";
            label_17.Size = new Size(91, 48);
            label_17.TabIndex = 1;
            label_17.TextAlign = ContentAlignment.MiddleCenter;
            label_17.Click += label_click;
            label_17.DoubleClick += label_doubleclick;
            label_17.MouseEnter += label_MouseEnter;
            label_17.MouseLeave += label_MouseLeave;
            // 
            // label_18
            // 
            label_18.Dock = DockStyle.Fill;
            label_18.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_18.Location = new Point(294, 165);
            label_18.Margin = new Padding(3);
            label_18.Name = "label_18";
            label_18.Size = new Size(91, 48);
            label_18.TabIndex = 1;
            label_18.TextAlign = ContentAlignment.MiddleCenter;
            label_18.Click += label_click;
            label_18.DoubleClick += label_doubleclick;
            label_18.MouseEnter += label_MouseEnter;
            label_18.MouseLeave += label_MouseLeave;
            // 
            // label_19
            // 
            label_19.Dock = DockStyle.Fill;
            label_19.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_19.Location = new Point(391, 165);
            label_19.Margin = new Padding(3);
            label_19.Name = "label_19";
            label_19.Size = new Size(91, 48);
            label_19.TabIndex = 1;
            label_19.TextAlign = ContentAlignment.MiddleCenter;
            label_19.Click += label_click;
            label_19.DoubleClick += label_doubleclick;
            label_19.MouseEnter += label_MouseEnter;
            label_19.MouseLeave += label_MouseLeave;
            // 
            // label_20
            // 
            label_20.Dock = DockStyle.Fill;
            label_20.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_20.Location = new Point(488, 165);
            label_20.Margin = new Padding(3);
            label_20.Name = "label_20";
            label_20.Size = new Size(91, 48);
            label_20.TabIndex = 1;
            label_20.TextAlign = ContentAlignment.MiddleCenter;
            label_20.Click += label_click;
            label_20.DoubleClick += label_doubleclick;
            label_20.MouseEnter += label_MouseEnter;
            label_20.MouseLeave += label_MouseLeave;
            // 
            // label_21
            // 
            label_21.Dock = DockStyle.Fill;
            label_21.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_21.Location = new Point(585, 165);
            label_21.Margin = new Padding(3);
            label_21.Name = "label_21";
            label_21.Size = new Size(94, 48);
            label_21.TabIndex = 1;
            label_21.TextAlign = ContentAlignment.MiddleCenter;
            label_21.Click += label_click;
            label_21.DoubleClick += label_doubleclick;
            label_21.MouseEnter += label_MouseEnter;
            label_21.MouseLeave += label_MouseLeave;
            // 
            // label_28
            // 
            label_28.Dock = DockStyle.Fill;
            label_28.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_28.Location = new Point(585, 219);
            label_28.Margin = new Padding(3);
            label_28.Name = "label_28";
            label_28.Size = new Size(94, 48);
            label_28.TabIndex = 1;
            label_28.TextAlign = ContentAlignment.MiddleCenter;
            label_28.Click += label_click;
            label_28.DoubleClick += label_doubleclick;
            label_28.MouseEnter += label_MouseEnter;
            label_28.MouseLeave += label_MouseLeave;
            // 
            // label_27
            // 
            label_27.Dock = DockStyle.Fill;
            label_27.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_27.Location = new Point(488, 219);
            label_27.Margin = new Padding(3);
            label_27.Name = "label_27";
            label_27.Size = new Size(91, 48);
            label_27.TabIndex = 1;
            label_27.TextAlign = ContentAlignment.MiddleCenter;
            label_27.Click += label_click;
            label_27.DoubleClick += label_doubleclick;
            label_27.MouseEnter += label_MouseEnter;
            label_27.MouseLeave += label_MouseLeave;
            // 
            // label_26
            // 
            label_26.Dock = DockStyle.Fill;
            label_26.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_26.Location = new Point(391, 219);
            label_26.Margin = new Padding(3);
            label_26.Name = "label_26";
            label_26.Size = new Size(91, 48);
            label_26.TabIndex = 1;
            label_26.TextAlign = ContentAlignment.MiddleCenter;
            label_26.Click += label_click;
            label_26.DoubleClick += label_doubleclick;
            label_26.MouseEnter += label_MouseEnter;
            label_26.MouseLeave += label_MouseLeave;
            // 
            // label_25
            // 
            label_25.Dock = DockStyle.Fill;
            label_25.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_25.Location = new Point(294, 219);
            label_25.Margin = new Padding(3);
            label_25.Name = "label_25";
            label_25.Size = new Size(91, 48);
            label_25.TabIndex = 1;
            label_25.TextAlign = ContentAlignment.MiddleCenter;
            label_25.Click += label_click;
            label_25.DoubleClick += label_doubleclick;
            label_25.MouseEnter += label_MouseEnter;
            label_25.MouseLeave += label_MouseLeave;
            // 
            // label_24
            // 
            label_24.Dock = DockStyle.Fill;
            label_24.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_24.Location = new Point(197, 219);
            label_24.Margin = new Padding(3);
            label_24.Name = "label_24";
            label_24.Size = new Size(91, 48);
            label_24.TabIndex = 1;
            label_24.TextAlign = ContentAlignment.MiddleCenter;
            label_24.Click += label_click;
            label_24.DoubleClick += label_doubleclick;
            label_24.MouseEnter += label_MouseEnter;
            label_24.MouseLeave += label_MouseLeave;
            // 
            // label_23
            // 
            label_23.Dock = DockStyle.Fill;
            label_23.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_23.Location = new Point(100, 219);
            label_23.Margin = new Padding(3);
            label_23.Name = "label_23";
            label_23.Size = new Size(91, 48);
            label_23.TabIndex = 1;
            label_23.TextAlign = ContentAlignment.MiddleCenter;
            label_23.Click += label_click;
            label_23.DoubleClick += label_doubleclick;
            label_23.MouseEnter += label_MouseEnter;
            label_23.MouseLeave += label_MouseLeave;
            // 
            // label_22
            // 
            label_22.Dock = DockStyle.Fill;
            label_22.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_22.Location = new Point(3, 219);
            label_22.Margin = new Padding(3);
            label_22.Name = "label_22";
            label_22.Size = new Size(91, 48);
            label_22.TabIndex = 1;
            label_22.TextAlign = ContentAlignment.MiddleCenter;
            label_22.Click += label_click;
            label_22.DoubleClick += label_doubleclick;
            label_22.MouseEnter += label_MouseEnter;
            label_22.MouseLeave += label_MouseLeave;
            // 
            // label_29
            // 
            label_29.Dock = DockStyle.Fill;
            label_29.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_29.Location = new Point(3, 273);
            label_29.Margin = new Padding(3);
            label_29.Name = "label_29";
            label_29.Size = new Size(91, 48);
            label_29.TabIndex = 1;
            label_29.TextAlign = ContentAlignment.MiddleCenter;
            label_29.Click += label_click;
            label_29.DoubleClick += label_doubleclick;
            label_29.MouseEnter += label_MouseEnter;
            label_29.MouseLeave += label_MouseLeave;
            // 
            // label_30
            // 
            label_30.Dock = DockStyle.Fill;
            label_30.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_30.Location = new Point(100, 273);
            label_30.Margin = new Padding(3);
            label_30.Name = "label_30";
            label_30.Size = new Size(91, 48);
            label_30.TabIndex = 1;
            label_30.TextAlign = ContentAlignment.MiddleCenter;
            label_30.Click += label_click;
            label_30.DoubleClick += label_doubleclick;
            label_30.MouseEnter += label_MouseEnter;
            label_30.MouseLeave += label_MouseLeave;
            // 
            // label_31
            // 
            label_31.Dock = DockStyle.Fill;
            label_31.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_31.Location = new Point(197, 273);
            label_31.Margin = new Padding(3);
            label_31.Name = "label_31";
            label_31.Size = new Size(91, 48);
            label_31.TabIndex = 1;
            label_31.TextAlign = ContentAlignment.MiddleCenter;
            label_31.Click += label_click;
            label_31.DoubleClick += label_doubleclick;
            label_31.MouseEnter += label_MouseEnter;
            label_31.MouseLeave += label_MouseLeave;
            // 
            // label_32
            // 
            label_32.Dock = DockStyle.Fill;
            label_32.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_32.Location = new Point(294, 273);
            label_32.Margin = new Padding(3);
            label_32.Name = "label_32";
            label_32.Size = new Size(91, 48);
            label_32.TabIndex = 1;
            label_32.TextAlign = ContentAlignment.MiddleCenter;
            label_32.Click += label_click;
            label_32.DoubleClick += label_doubleclick;
            label_32.MouseEnter += label_MouseEnter;
            label_32.MouseLeave += label_MouseLeave;
            // 
            // label_33
            // 
            label_33.Dock = DockStyle.Fill;
            label_33.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_33.Location = new Point(391, 273);
            label_33.Margin = new Padding(3);
            label_33.Name = "label_33";
            label_33.Size = new Size(91, 48);
            label_33.TabIndex = 1;
            label_33.TextAlign = ContentAlignment.MiddleCenter;
            label_33.Click += label_click;
            label_33.DoubleClick += label_doubleclick;
            label_33.MouseEnter += label_MouseEnter;
            label_33.MouseLeave += label_MouseLeave;
            // 
            // label_34
            // 
            label_34.Dock = DockStyle.Fill;
            label_34.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_34.Location = new Point(488, 273);
            label_34.Margin = new Padding(3);
            label_34.Name = "label_34";
            label_34.Size = new Size(91, 48);
            label_34.TabIndex = 1;
            label_34.TextAlign = ContentAlignment.MiddleCenter;
            label_34.Click += label_click;
            label_34.DoubleClick += label_doubleclick;
            label_34.MouseEnter += label_MouseEnter;
            label_34.MouseLeave += label_MouseLeave;
            // 
            // label_35
            // 
            label_35.Dock = DockStyle.Fill;
            label_35.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_35.Location = new Point(585, 273);
            label_35.Margin = new Padding(3);
            label_35.Name = "label_35";
            label_35.Size = new Size(94, 48);
            label_35.TabIndex = 1;
            label_35.TextAlign = ContentAlignment.MiddleCenter;
            label_35.Click += label_click;
            label_35.DoubleClick += label_doubleclick;
            label_35.MouseEnter += label_MouseEnter;
            label_35.MouseLeave += label_MouseLeave;
            // 
            // label_42
            // 
            label_42.Dock = DockStyle.Fill;
            label_42.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_42.Location = new Point(585, 327);
            label_42.Margin = new Padding(3);
            label_42.Name = "label_42";
            label_42.Size = new Size(94, 53);
            label_42.TabIndex = 1;
            label_42.TextAlign = ContentAlignment.MiddleCenter;
            label_42.Click += label_click;
            label_42.DoubleClick += label_doubleclick;
            label_42.MouseEnter += label_MouseEnter;
            label_42.MouseLeave += label_MouseLeave;
            // 
            // label_41
            // 
            label_41.Dock = DockStyle.Fill;
            label_41.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_41.Location = new Point(488, 327);
            label_41.Margin = new Padding(3);
            label_41.Name = "label_41";
            label_41.Size = new Size(91, 53);
            label_41.TabIndex = 1;
            label_41.TextAlign = ContentAlignment.MiddleCenter;
            label_41.Click += label_click;
            label_41.DoubleClick += label_doubleclick;
            label_41.MouseEnter += label_MouseEnter;
            label_41.MouseLeave += label_MouseLeave;
            // 
            // label_40
            // 
            label_40.Dock = DockStyle.Fill;
            label_40.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_40.Location = new Point(391, 327);
            label_40.Margin = new Padding(3);
            label_40.Name = "label_40";
            label_40.Size = new Size(91, 53);
            label_40.TabIndex = 1;
            label_40.TextAlign = ContentAlignment.MiddleCenter;
            label_40.Click += label_click;
            label_40.DoubleClick += label_doubleclick;
            label_40.MouseEnter += label_MouseEnter;
            label_40.MouseLeave += label_MouseLeave;
            // 
            // label_39
            // 
            label_39.Dock = DockStyle.Fill;
            label_39.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_39.Location = new Point(294, 327);
            label_39.Margin = new Padding(3);
            label_39.Name = "label_39";
            label_39.Size = new Size(91, 53);
            label_39.TabIndex = 1;
            label_39.TextAlign = ContentAlignment.MiddleCenter;
            label_39.Click += label_click;
            label_39.DoubleClick += label_doubleclick;
            label_39.MouseEnter += label_MouseEnter;
            label_39.MouseLeave += label_MouseLeave;
            // 
            // label_38
            // 
            label_38.Dock = DockStyle.Fill;
            label_38.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_38.Location = new Point(197, 327);
            label_38.Margin = new Padding(3);
            label_38.Name = "label_38";
            label_38.Size = new Size(91, 53);
            label_38.TabIndex = 1;
            label_38.TextAlign = ContentAlignment.MiddleCenter;
            label_38.Click += label_click;
            label_38.DoubleClick += label_doubleclick;
            label_38.MouseEnter += label_MouseEnter;
            label_38.MouseLeave += label_MouseLeave;
            // 
            // label_37
            // 
            label_37.Dock = DockStyle.Fill;
            label_37.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_37.Location = new Point(100, 327);
            label_37.Margin = new Padding(3);
            label_37.Name = "label_37";
            label_37.Size = new Size(91, 53);
            label_37.TabIndex = 1;
            label_37.TextAlign = ContentAlignment.MiddleCenter;
            label_37.Click += label_click;
            label_37.DoubleClick += label_doubleclick;
            label_37.MouseEnter += label_MouseEnter;
            label_37.MouseLeave += label_MouseLeave;
            // 
            // label_36
            // 
            label_36.Dock = DockStyle.Fill;
            label_36.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_36.Location = new Point(3, 327);
            label_36.Margin = new Padding(3);
            label_36.Name = "label_36";
            label_36.Size = new Size(91, 53);
            label_36.TabIndex = 1;
            label_36.TextAlign = ContentAlignment.MiddleCenter;
            label_36.Click += label_click;
            label_36.DoubleClick += label_doubleclick;
            label_36.MouseEnter += label_MouseEnter;
            label_36.MouseLeave += label_MouseLeave;
            // 
            // Form_Calendar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(682, 653);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_Calendar";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ปฏิทิน";
            tableLayoutPanel_back.ResumeLayout(false);
            panel_top.ResumeLayout(false);
            tableLayoutPanel_calendar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_back;
        private Button button_confirm;
        private Label label_title;
        private Panel panel_top;
        private Label label_month_year;
        private Button button_next;
        private Button button_back;
        private TableLayoutPanel tableLayoutPanel_calendar;
        private Label label_sun;
        private Label label_mon;
        private Label label_tue;
        private Label label_wed;
        private Label label_thu;
        private Label label_fri;
        private Label label_sat;
        private Label label_1;
        private Label label_2;
        private Label label_3;
        private Label label_4;
        private Label label_5;
        private Label label_6;
        private Label label_7;
        private Label label_14;
        private Label label_13;
        private Label label_12;
        private Label label_11;
        private Label label_10;
        private Label label_9;
        private Label label_8;
        private Label label_15;
        private Label label_16;
        private Label label_17;
        private Label label_18;
        private Label label_19;
        private Label label_20;
        private Label label_21;
        private Label label_28;
        private Label label_27;
        private Label label_26;
        private Label label_25;
        private Label label_24;
        private Label label_23;
        private Label label_22;
        private Label label_29;
        private Label label_30;
        private Label label_31;
        private Label label_32;
        private Label label_33;
        private Label label_34;
        private Label label_35;
        private Label label_42;
        private Label label_41;
        private Label label_40;
        private Label label_39;
        private Label label_38;
        private Label label_37;
        private Label label_36;
        public Label label_set_days;
    }
}