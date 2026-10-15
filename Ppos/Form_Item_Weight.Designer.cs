namespace Ppos
{
    partial class Form_Item_Weight
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Item_Weight));
            button_confirm = new Button();
            textBox_weight = new TextBox();
            tableLayoutPanel_back_detail = new TableLayoutPanel();
            customPanel_item_bar = new CustomPanel();
            textBox_barcode = new TextBox();
            label_bar = new Label();
            customPanel_item_name = new CustomPanel();
            textBox_item_name = new TextBox();
            label_name = new Label();
            customPanel_item_unit = new CustomPanel();
            textBox_item_unit = new TextBox();
            label_unit = new Label();
            customPanel_item_price = new CustomPanel();
            textBox_item_price = new TextBox();
            label_price = new Label();
            customPanel_weight = new CustomPanel();
            label_weight = new Label();
            pictureBox_item = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            customGroupBox_back = new CustomGroupBox();
            customGroupBox_keypad = new CustomGroupBox();
            tableLayoutPanel_keypad = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button_point = new Button();
            button0 = new Button();
            button_delete = new Button();
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_left = new TableLayoutPanel();
            customGroupBox_confirm = new CustomGroupBox();
            tableLayoutPanel_back_detail.SuspendLayout();
            customPanel_item_bar.SuspendLayout();
            customPanel_item_name.SuspendLayout();
            customPanel_item_unit.SuspendLayout();
            customPanel_item_price.SuspendLayout();
            customPanel_weight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_item).BeginInit();
            customGroupBox_back.SuspendLayout();
            customGroupBox_keypad.SuspendLayout();
            tableLayoutPanel_keypad.SuspendLayout();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_left.SuspendLayout();
            customGroupBox_confirm.SuspendLayout();
            SuspendLayout();
            // 
            // button_confirm
            // 
            button_confirm.BackColor = Color.Lime;
            button_confirm.BackgroundImageLayout = ImageLayout.Zoom;
            button_confirm.Dock = DockStyle.Fill;
            button_confirm.FlatAppearance.BorderSize = 0;
            button_confirm.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_confirm.FlatAppearance.MouseOverBackColor = Color.Lime;
            button_confirm.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold);
            button_confirm.Location = new Point(10, 13);
            button_confirm.Margin = new Padding(10);
            button_confirm.Name = "button_confirm";
            button_confirm.Size = new Size(481, 77);
            button_confirm.TabIndex = 0;
            button_confirm.Text = "ตกลง";
            button_confirm.TextAlign = ContentAlignment.MiddleRight;
            button_confirm.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_confirm.UseVisualStyleBackColor = false;
            button_confirm.Click += button_confirm_Click;
            button_confirm.MouseEnter += button_confirm_MouseEnter;
            button_confirm.MouseLeave += button_confirm_MouseLeave;
            // 
            // textBox_weight
            // 
            textBox_weight.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_weight.BackColor = Color.FromArgb(128, 255, 128);
            textBox_weight.BorderStyle = BorderStyle.None;
            textBox_weight.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_weight.Location = new Point(171, 17);
            textBox_weight.Margin = new Padding(0);
            textBox_weight.Name = "textBox_weight";
            textBox_weight.Size = new Size(298, 63);
            textBox_weight.TabIndex = 1;
            textBox_weight.KeyDown += textBox_weight_KeyDown;
            textBox_weight.KeyPress += textBox_weight_KeyPress;
            textBox_weight.Leave += textBox_weight_Leave;
            // 
            // tableLayoutPanel_back_detail
            // 
            tableLayoutPanel_back_detail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel_back_detail.BackColor = Color.Transparent;
            tableLayoutPanel_back_detail.ColumnCount = 1;
            tableLayoutPanel_back_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back_detail.Controls.Add(customPanel_item_bar, 0, 1);
            tableLayoutPanel_back_detail.Controls.Add(customPanel_item_name, 0, 2);
            tableLayoutPanel_back_detail.Controls.Add(customPanel_item_unit, 0, 3);
            tableLayoutPanel_back_detail.Controls.Add(customPanel_item_price, 0, 4);
            tableLayoutPanel_back_detail.Controls.Add(customPanel_weight, 0, 5);
            tableLayoutPanel_back_detail.Controls.Add(pictureBox_item, 0, 0);
            tableLayoutPanel_back_detail.Location = new Point(15, 15);
            tableLayoutPanel_back_detail.Margin = new Padding(10);
            tableLayoutPanel_back_detail.Name = "tableLayoutPanel_back_detail";
            tableLayoutPanel_back_detail.RowCount = 6;
            tableLayoutPanel_back_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tableLayoutPanel_back_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel_back_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel_back_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel_back_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel_back_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_back_detail.Size = new Size(471, 442);
            tableLayoutPanel_back_detail.TabIndex = 2;
            // 
            // customPanel_item_bar
            // 
            customPanel_item_bar.BackColor = Color.FromArgb(192, 255, 192);
            customPanel_item_bar.BorderRadius = 10;
            customPanel_item_bar.Controls.Add(textBox_barcode);
            customPanel_item_bar.Controls.Add(label_bar);
            customPanel_item_bar.Dock = DockStyle.Fill;
            customPanel_item_bar.Location = new Point(10, 155);
            customPanel_item_bar.Margin = new Padding(10, 5, 10, 5);
            customPanel_item_bar.Name = "customPanel_item_bar";
            customPanel_item_bar.Size = new Size(451, 38);
            customPanel_item_bar.TabIndex = 0;
            customPanel_item_bar.Visible = false;
            // 
            // textBox_barcode
            // 
            textBox_barcode.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_barcode.BackColor = Color.FromArgb(192, 255, 192);
            textBox_barcode.BorderStyle = BorderStyle.None;
            textBox_barcode.Enabled = false;
            textBox_barcode.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            textBox_barcode.ForeColor = Color.Gray;
            textBox_barcode.Location = new Point(143, 4);
            textBox_barcode.Margin = new Padding(0);
            textBox_barcode.Name = "textBox_barcode";
            textBox_barcode.Size = new Size(308, 31);
            textBox_barcode.TabIndex = 1;
            // 
            // label_bar
            // 
            label_bar.Dock = DockStyle.Left;
            label_bar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_bar.ForeColor = Color.Gray;
            label_bar.Location = new Point(0, 0);
            label_bar.Name = "label_bar";
            label_bar.Size = new Size(140, 38);
            label_bar.TabIndex = 0;
            label_bar.Text = "บาร์โค้ด :";
            label_bar.TextAlign = ContentAlignment.MiddleRight;
            label_bar.MouseEnter += bar_enter;
            label_bar.MouseLeave += bar_leave;
            // 
            // customPanel_item_name
            // 
            customPanel_item_name.BackColor = Color.FromArgb(192, 255, 192);
            customPanel_item_name.BorderRadius = 10;
            customPanel_item_name.Controls.Add(textBox_item_name);
            customPanel_item_name.Controls.Add(label_name);
            customPanel_item_name.Dock = DockStyle.Fill;
            customPanel_item_name.Location = new Point(10, 203);
            customPanel_item_name.Margin = new Padding(10, 5, 10, 5);
            customPanel_item_name.Name = "customPanel_item_name";
            customPanel_item_name.Size = new Size(451, 38);
            customPanel_item_name.TabIndex = 0;
            customPanel_item_name.Visible = false;
            // 
            // textBox_item_name
            // 
            textBox_item_name.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_item_name.BackColor = Color.FromArgb(192, 255, 192);
            textBox_item_name.BorderStyle = BorderStyle.None;
            textBox_item_name.Enabled = false;
            textBox_item_name.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            textBox_item_name.ForeColor = Color.Gray;
            textBox_item_name.Location = new Point(140, 4);
            textBox_item_name.Margin = new Padding(0);
            textBox_item_name.Name = "textBox_item_name";
            textBox_item_name.Size = new Size(311, 31);
            textBox_item_name.TabIndex = 1;
            // 
            // label_name
            // 
            label_name.Dock = DockStyle.Left;
            label_name.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_name.ForeColor = Color.Gray;
            label_name.Location = new Point(0, 0);
            label_name.Name = "label_name";
            label_name.Size = new Size(140, 38);
            label_name.TabIndex = 0;
            label_name.Text = "ชื่อสินค้า :";
            label_name.TextAlign = ContentAlignment.MiddleRight;
            label_name.MouseEnter += bar_enter;
            label_name.MouseLeave += bar_leave;
            // 
            // customPanel_item_unit
            // 
            customPanel_item_unit.BackColor = Color.FromArgb(192, 255, 192);
            customPanel_item_unit.BorderRadius = 10;
            customPanel_item_unit.Controls.Add(textBox_item_unit);
            customPanel_item_unit.Controls.Add(label_unit);
            customPanel_item_unit.Dock = DockStyle.Fill;
            customPanel_item_unit.Location = new Point(10, 251);
            customPanel_item_unit.Margin = new Padding(10, 5, 10, 5);
            customPanel_item_unit.Name = "customPanel_item_unit";
            customPanel_item_unit.Size = new Size(451, 38);
            customPanel_item_unit.TabIndex = 0;
            customPanel_item_unit.Visible = false;
            // 
            // textBox_item_unit
            // 
            textBox_item_unit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_item_unit.BackColor = Color.FromArgb(192, 255, 192);
            textBox_item_unit.BorderStyle = BorderStyle.None;
            textBox_item_unit.Enabled = false;
            textBox_item_unit.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            textBox_item_unit.ForeColor = Color.Gray;
            textBox_item_unit.Location = new Point(143, 4);
            textBox_item_unit.Margin = new Padding(0);
            textBox_item_unit.Name = "textBox_item_unit";
            textBox_item_unit.Size = new Size(308, 31);
            textBox_item_unit.TabIndex = 1;
            // 
            // label_unit
            // 
            label_unit.Dock = DockStyle.Left;
            label_unit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_unit.ForeColor = Color.Gray;
            label_unit.Location = new Point(0, 0);
            label_unit.Name = "label_unit";
            label_unit.Size = new Size(140, 38);
            label_unit.TabIndex = 0;
            label_unit.Text = "หน่วย :";
            label_unit.TextAlign = ContentAlignment.MiddleRight;
            label_unit.MouseEnter += bar_enter;
            label_unit.MouseLeave += bar_leave;
            // 
            // customPanel_item_price
            // 
            customPanel_item_price.BackColor = Color.FromArgb(192, 255, 192);
            customPanel_item_price.BorderRadius = 10;
            customPanel_item_price.Controls.Add(textBox_item_price);
            customPanel_item_price.Controls.Add(label_price);
            customPanel_item_price.Dock = DockStyle.Fill;
            customPanel_item_price.Location = new Point(10, 299);
            customPanel_item_price.Margin = new Padding(10, 5, 10, 5);
            customPanel_item_price.Name = "customPanel_item_price";
            customPanel_item_price.Size = new Size(451, 38);
            customPanel_item_price.TabIndex = 0;
            customPanel_item_price.Visible = false;
            // 
            // textBox_item_price
            // 
            textBox_item_price.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_item_price.BackColor = Color.FromArgb(192, 255, 192);
            textBox_item_price.BorderStyle = BorderStyle.None;
            textBox_item_price.Enabled = false;
            textBox_item_price.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            textBox_item_price.ForeColor = Color.Gray;
            textBox_item_price.Location = new Point(143, 4);
            textBox_item_price.Margin = new Padding(0);
            textBox_item_price.Name = "textBox_item_price";
            textBox_item_price.Size = new Size(308, 31);
            textBox_item_price.TabIndex = 1;
            // 
            // label_price
            // 
            label_price.Dock = DockStyle.Left;
            label_price.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_price.ForeColor = Color.Gray;
            label_price.Location = new Point(0, 0);
            label_price.Name = "label_price";
            label_price.Size = new Size(140, 38);
            label_price.TabIndex = 0;
            label_price.Text = "ราคาขาย :";
            label_price.TextAlign = ContentAlignment.MiddleRight;
            label_price.MouseEnter += bar_enter;
            label_price.MouseLeave += bar_leave;
            // 
            // customPanel_weight
            // 
            customPanel_weight.BackColor = Color.FromArgb(128, 255, 128);
            customPanel_weight.BorderRadius = 0;
            customPanel_weight.Controls.Add(label_weight);
            customPanel_weight.Controls.Add(textBox_weight);
            customPanel_weight.Dock = DockStyle.Fill;
            customPanel_weight.Location = new Point(0, 347);
            customPanel_weight.Margin = new Padding(0, 5, 0, 0);
            customPanel_weight.Name = "customPanel_weight";
            customPanel_weight.Size = new Size(471, 95);
            customPanel_weight.TabIndex = 1;
            customPanel_weight.Visible = false;
            // 
            // label_weight
            // 
            label_weight.BackColor = Color.FromArgb(128, 255, 128);
            label_weight.Dock = DockStyle.Left;
            label_weight.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_weight.Location = new Point(0, 0);
            label_weight.Name = "label_weight";
            label_weight.Size = new Size(168, 95);
            label_weight.TabIndex = 0;
            label_weight.Text = "จำนวน :";
            label_weight.TextAlign = ContentAlignment.MiddleRight;
            label_weight.MouseEnter += weight_enter;
            label_weight.MouseLeave += weight_leave;
            // 
            // pictureBox_item
            // 
            pictureBox_item.Dock = DockStyle.Fill;
            pictureBox_item.Location = new Point(0, 0);
            pictureBox_item.Margin = new Padding(0);
            pictureBox_item.Name = "pictureBox_item";
            pictureBox_item.Size = new Size(471, 150);
            pictureBox_item.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_item.TabIndex = 1;
            pictureBox_item.TabStop = false;
            pictureBox_item.Visible = false;
            pictureBox_item.WaitOnLoad = true;
            pictureBox_item.MouseEnter += pictureBox_item_MouseEnter;
            pictureBox_item.MouseLeave += pictureBox_item_MouseLeave;
            // 
            // timer
            // 
            timer.Interval = 50;
            timer.Tick += timer_Tick;
            // 
            // customGroupBox_back
            // 
            customGroupBox_back.BackColor = Color.White;
            customGroupBox_back.BorderColor = Color.FromArgb(128, 255, 128);
            customGroupBox_back.BorderRadius = 10;
            customGroupBox_back.BorderThickness = 20;
            customGroupBox_back.Controls.Add(tableLayoutPanel_back_detail);
            customGroupBox_back.Dock = DockStyle.Fill;
            customGroupBox_back.Location = new Point(0, 0);
            customGroupBox_back.Margin = new Padding(0, 0, 0, 10);
            customGroupBox_back.Name = "customGroupBox_back";
            customGroupBox_back.Padding = new Padding(10);
            customGroupBox_back.Size = new Size(501, 472);
            customGroupBox_back.TabIndex = 6;
            customGroupBox_back.TabStop = false;
            // 
            // customGroupBox_keypad
            // 
            customGroupBox_keypad.BorderColor = Color.Silver;
            customGroupBox_keypad.BorderRadius = 10;
            customGroupBox_keypad.BorderThickness = 20;
            customGroupBox_keypad.Controls.Add(tableLayoutPanel_keypad);
            customGroupBox_keypad.Dock = DockStyle.Fill;
            customGroupBox_keypad.Font = new Font("Segoe UI", 1F);
            customGroupBox_keypad.Location = new Point(504, 0);
            customGroupBox_keypad.Margin = new Padding(3, 0, 0, 0);
            customGroupBox_keypad.Name = "customGroupBox_keypad";
            customGroupBox_keypad.Padding = new Padding(10);
            customGroupBox_keypad.Size = new Size(332, 582);
            customGroupBox_keypad.TabIndex = 8;
            customGroupBox_keypad.TabStop = false;
            // 
            // tableLayoutPanel_keypad
            // 
            tableLayoutPanel_keypad.BackColor = Color.Silver;
            tableLayoutPanel_keypad.ColumnCount = 3;
            tableLayoutPanel_keypad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_keypad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_keypad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_keypad.Controls.Add(button1, 0, 0);
            tableLayoutPanel_keypad.Controls.Add(button2, 1, 0);
            tableLayoutPanel_keypad.Controls.Add(button3, 2, 0);
            tableLayoutPanel_keypad.Controls.Add(button4, 0, 1);
            tableLayoutPanel_keypad.Controls.Add(button5, 1, 1);
            tableLayoutPanel_keypad.Controls.Add(button6, 2, 1);
            tableLayoutPanel_keypad.Controls.Add(button7, 0, 2);
            tableLayoutPanel_keypad.Controls.Add(button8, 1, 2);
            tableLayoutPanel_keypad.Controls.Add(button9, 2, 2);
            tableLayoutPanel_keypad.Controls.Add(button_point, 0, 3);
            tableLayoutPanel_keypad.Controls.Add(button0, 1, 3);
            tableLayoutPanel_keypad.Controls.Add(button_delete, 2, 3);
            tableLayoutPanel_keypad.Dock = DockStyle.Fill;
            tableLayoutPanel_keypad.Location = new Point(10, 13);
            tableLayoutPanel_keypad.Margin = new Padding(5);
            tableLayoutPanel_keypad.Name = "tableLayoutPanel_keypad";
            tableLayoutPanel_keypad.RowCount = 4;
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.Size = new Size(312, 559);
            tableLayoutPanel_keypad.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            button1.ForeColor = Color.Gray;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(98, 133);
            button1.TabIndex = 0;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += keypad_click;
            button1.MouseEnter += button_enter;
            button1.MouseLeave += button_leave;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Dock = DockStyle.Fill;
            button2.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            button2.ForeColor = Color.Gray;
            button2.Location = new Point(107, 3);
            button2.Name = "button2";
            button2.Size = new Size(98, 133);
            button2.TabIndex = 0;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = false;
            button2.Click += keypad_click;
            button2.MouseEnter += button_enter;
            button2.MouseLeave += button_leave;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.Dock = DockStyle.Fill;
            button3.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            button3.ForeColor = Color.Gray;
            button3.Location = new Point(211, 3);
            button3.Name = "button3";
            button3.Size = new Size(98, 133);
            button3.TabIndex = 0;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = false;
            button3.Click += keypad_click;
            button3.MouseEnter += button_enter;
            button3.MouseLeave += button_leave;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.Dock = DockStyle.Fill;
            button4.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            button4.ForeColor = Color.Gray;
            button4.Location = new Point(3, 142);
            button4.Name = "button4";
            button4.Size = new Size(98, 133);
            button4.TabIndex = 0;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = false;
            button4.Click += keypad_click;
            button4.MouseEnter += button_enter;
            button4.MouseLeave += button_leave;
            // 
            // button5
            // 
            button5.BackColor = Color.White;
            button5.Dock = DockStyle.Fill;
            button5.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            button5.ForeColor = Color.Gray;
            button5.Location = new Point(107, 142);
            button5.Name = "button5";
            button5.Size = new Size(98, 133);
            button5.TabIndex = 0;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = false;
            button5.Click += keypad_click;
            button5.MouseEnter += button_enter;
            button5.MouseLeave += button_leave;
            // 
            // button6
            // 
            button6.BackColor = Color.White;
            button6.Dock = DockStyle.Fill;
            button6.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            button6.ForeColor = Color.Gray;
            button6.Location = new Point(211, 142);
            button6.Name = "button6";
            button6.Size = new Size(98, 133);
            button6.TabIndex = 0;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = false;
            button6.Click += keypad_click;
            button6.MouseEnter += button_enter;
            button6.MouseLeave += button_leave;
            // 
            // button7
            // 
            button7.BackColor = Color.White;
            button7.Dock = DockStyle.Fill;
            button7.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            button7.ForeColor = Color.Gray;
            button7.Location = new Point(3, 281);
            button7.Name = "button7";
            button7.Size = new Size(98, 133);
            button7.TabIndex = 0;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = false;
            button7.Click += keypad_click;
            button7.MouseEnter += button_enter;
            button7.MouseLeave += button_leave;
            // 
            // button8
            // 
            button8.BackColor = Color.White;
            button8.Dock = DockStyle.Fill;
            button8.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            button8.ForeColor = Color.Gray;
            button8.Location = new Point(107, 281);
            button8.Name = "button8";
            button8.Size = new Size(98, 133);
            button8.TabIndex = 0;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = false;
            button8.Click += keypad_click;
            button8.MouseEnter += button_enter;
            button8.MouseLeave += button_leave;
            // 
            // button9
            // 
            button9.BackColor = Color.White;
            button9.Dock = DockStyle.Fill;
            button9.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            button9.ForeColor = Color.Gray;
            button9.Location = new Point(211, 281);
            button9.Name = "button9";
            button9.Size = new Size(98, 133);
            button9.TabIndex = 0;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = false;
            button9.Click += keypad_click;
            button9.MouseEnter += button_enter;
            button9.MouseLeave += button_leave;
            // 
            // button_point
            // 
            button_point.BackColor = Color.White;
            button_point.Dock = DockStyle.Fill;
            button_point.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            button_point.ForeColor = Color.Gray;
            button_point.Location = new Point(3, 420);
            button_point.Name = "button_point";
            button_point.Size = new Size(98, 136);
            button_point.TabIndex = 0;
            button_point.Text = ".";
            button_point.UseVisualStyleBackColor = false;
            button_point.Click += keypad_click;
            button_point.MouseEnter += button_enter;
            button_point.MouseLeave += button_leave;
            // 
            // button0
            // 
            button0.BackColor = Color.White;
            button0.Dock = DockStyle.Fill;
            button0.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            button0.ForeColor = Color.Gray;
            button0.Location = new Point(107, 420);
            button0.Name = "button0";
            button0.Size = new Size(98, 136);
            button0.TabIndex = 0;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = false;
            button0.Click += keypad_click;
            button0.MouseEnter += button_enter;
            button0.MouseLeave += button_leave;
            // 
            // button_delete
            // 
            button_delete.BackColor = Color.White;
            button_delete.Dock = DockStyle.Fill;
            button_delete.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_delete.ForeColor = Color.Gray;
            button_delete.Location = new Point(211, 420);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(98, 136);
            button_delete.TabIndex = 0;
            button_delete.Text = "ลบ";
            button_delete.UseVisualStyleBackColor = false;
            button_delete.Click += keypad_click;
            button_delete.MouseEnter += button_enter;
            button_delete.MouseLeave += button_leave;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.ColumnCount = 2;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel_back.Controls.Add(customGroupBox_keypad, 1, 0);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_left, 0, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 1;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(836, 582);
            tableLayoutPanel_back.TabIndex = 9;
            // 
            // tableLayoutPanel_left
            // 
            tableLayoutPanel_left.ColumnCount = 1;
            tableLayoutPanel_left.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_left.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_left.Controls.Add(customGroupBox_back, 0, 0);
            tableLayoutPanel_left.Controls.Add(customGroupBox_confirm, 0, 1);
            tableLayoutPanel_left.Dock = DockStyle.Fill;
            tableLayoutPanel_left.Location = new Point(0, 0);
            tableLayoutPanel_left.Margin = new Padding(0);
            tableLayoutPanel_left.Name = "tableLayoutPanel_left";
            tableLayoutPanel_left.RowCount = 2;
            tableLayoutPanel_left.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_left.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_left.Size = new Size(501, 582);
            tableLayoutPanel_left.TabIndex = 9;
            // 
            // customGroupBox_confirm
            // 
            customGroupBox_confirm.BorderColor = Color.Lime;
            customGroupBox_confirm.BorderRadius = 10;
            customGroupBox_confirm.BorderThickness = 20;
            customGroupBox_confirm.Controls.Add(button_confirm);
            customGroupBox_confirm.Dock = DockStyle.Fill;
            customGroupBox_confirm.Font = new Font("Segoe UI", 1F);
            customGroupBox_confirm.Location = new Point(0, 482);
            customGroupBox_confirm.Margin = new Padding(0);
            customGroupBox_confirm.Name = "customGroupBox_confirm";
            customGroupBox_confirm.Padding = new Padding(10);
            customGroupBox_confirm.Size = new Size(501, 100);
            customGroupBox_confirm.TabIndex = 7;
            customGroupBox_confirm.TabStop = false;
            customGroupBox_confirm.Text = " ";
            // 
            // Form_Item_Weight
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(836, 582);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_Item_Weight";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "แก้ไขจำนวน";
            Shown += Form_Item_Weight_Shown;
            tableLayoutPanel_back_detail.ResumeLayout(false);
            customPanel_item_bar.ResumeLayout(false);
            customPanel_item_bar.PerformLayout();
            customPanel_item_name.ResumeLayout(false);
            customPanel_item_name.PerformLayout();
            customPanel_item_unit.ResumeLayout(false);
            customPanel_item_unit.PerformLayout();
            customPanel_item_price.ResumeLayout(false);
            customPanel_item_price.PerformLayout();
            customPanel_weight.ResumeLayout(false);
            customPanel_weight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_item).EndInit();
            customGroupBox_back.ResumeLayout(false);
            customGroupBox_keypad.ResumeLayout(false);
            tableLayoutPanel_keypad.ResumeLayout(false);
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_left.ResumeLayout(false);
            customGroupBox_confirm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button button_confirm;
        private TextBox textBox_weight;
        private TableLayoutPanel tableLayoutPanel_back_detail;
        private Label label_bar;
        private Label label_name;
        private Label label_unit;
        private Label label_price;
        private Label label_weight;
        private PictureBox pictureBox_item;
        private TextBox textBox_barcode;
        private TextBox textBox_item_name;
        private TextBox textBox_item_unit;
        private TextBox textBox_item_price;
        private CustomPanel customPanel_item_bar;
        private CustomPanel customPanel_item_name;
        private CustomPanel customPanel_item_unit;
        private CustomPanel customPanel_item_price;
        private CustomPanel customPanel_weight;
        private System.Windows.Forms.Timer timer;
        private CustomGroupBox customGroupBox_back;
        private CustomGroupBox customGroupBox_keypad;
        private TableLayoutPanel tableLayoutPanel_keypad;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button_point;
        private Button button0;
        private Button button_delete;
        private TableLayoutPanel tableLayoutPanel_back;
        private TableLayoutPanel tableLayoutPanel_left;
        private CustomGroupBox customGroupBox_confirm;
    }
}