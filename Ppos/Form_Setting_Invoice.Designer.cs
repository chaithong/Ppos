namespace Ppos
{
    partial class Form_Setting_Invoice
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
            panel_invoice = new Panel();
            pictureBox_invoice = new PictureBox();
            customGroupBox_invoice = new CustomGroupBox();
            tableLayoutPanel_invoice = new TableLayoutPanel();
            textBox_trx_no = new TextBox();
            tableLayoutPanel_back = new TableLayoutPanel();
            customGroupBox_set = new CustomGroupBox();
            panel_set = new Panel();
            button_print = new Button();
            textBox_thank_desc = new TextBox();
            label23 = new Label();
            label6 = new Label();
            label5 = new Label();
            label22 = new Label();
            label11 = new Label();
            label8 = new Label();
            label19 = new Label();
            label16 = new Label();
            label15 = new Label();
            label20 = new Label();
            label21 = new Label();
            label18 = new Label();
            label17 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label10 = new Label();
            label9 = new Label();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label24 = new Label();
            label1 = new Label();
            comboBox_tax_id_bold = new ComboBox();
            comboBox_phone_bold = new ComboBox();
            comboBox_bar_bold = new ComboBox();
            comboBox_member_head_bold = new ComboBox();
            comboBox_pro_head_bold = new ComboBox();
            comboBox_sum_vat_bold = new ComboBox();
            comboBox_thank_bold = new ComboBox();
            comboBox_member_bold = new ComboBox();
            comboBox_pro_bold = new ComboBox();
            comboBox_net_bold = new ComboBox();
            comboBox_sum_bold = new ComboBox();
            comboBox_item_bold = new ComboBox();
            comboBox_head_bold = new ComboBox();
            comboBox_trx_no_bold = new ComboBox();
            comboBox_address_bold = new ComboBox();
            comboBox_type_bold = new ComboBox();
            comboBox_name_bold = new ComboBox();
            comboBox_tax_id_fontsize = new ComboBox();
            comboBox_phone_fontsize = new ComboBox();
            comboBox_address_fontsize = new ComboBox();
            comboBox_tax_id = new ComboBox();
            comboBox_phone = new ComboBox();
            comboBox_bar_fontsize = new ComboBox();
            comboBox_member_head_fontsize = new ComboBox();
            comboBox_pro_head_fontsize = new ComboBox();
            comboBox_sum_vat_fontsize = new ComboBox();
            comboBox_thank_fontsize = new ComboBox();
            comboBox_member_fontsize = new ComboBox();
            comboBox_pro_fontsize = new ComboBox();
            comboBox_net_fontsize = new ComboBox();
            comboBox_sum_fontsize = new ComboBox();
            comboBox_bar = new ComboBox();
            comboBox_member = new ComboBox();
            comboBox_pro = new ComboBox();
            comboBox_sum_vat = new ComboBox();
            comboBox_address = new ComboBox();
            comboBox_item_fontsize = new ComboBox();
            comboBox_head_fontsize = new ComboBox();
            comboBox_trx_no_fontsize = new ComboBox();
            comboBox_point_0 = new ComboBox();
            comboBox_column_size = new ComboBox();
            comboBox_line = new ComboBox();
            comboBox_type_fontsize = new ComboBox();
            comboBox_name_fontsize = new ComboBox();
            comboBox_logo_width = new ComboBox();
            comboBox_print_name = new ComboBox();
            comboBox_width = new ComboBox();
            comboBox_margin = new ComboBox();
            timer_search = new System.Windows.Forms.Timer(components);
            backgroundWorker_print = new System.ComponentModel.BackgroundWorker();
            panel_invoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_invoice).BeginInit();
            customGroupBox_invoice.SuspendLayout();
            tableLayoutPanel_invoice.SuspendLayout();
            tableLayoutPanel_back.SuspendLayout();
            customGroupBox_set.SuspendLayout();
            panel_set.SuspendLayout();
            SuspendLayout();
            // 
            // panel_invoice
            // 
            panel_invoice.BackColor = Color.Transparent;
            panel_invoice.Controls.Add(pictureBox_invoice);
            panel_invoice.Dock = DockStyle.Fill;
            panel_invoice.Location = new Point(3, 73);
            panel_invoice.Name = "panel_invoice";
            panel_invoice.Size = new Size(365, 957);
            panel_invoice.TabIndex = 0;
            panel_invoice.Resize += panel_invoice_Resize;
            // 
            // pictureBox_invoice
            // 
            pictureBox_invoice.BackColor = Color.Transparent;
            pictureBox_invoice.Location = new Point(0, 0);
            pictureBox_invoice.Margin = new Padding(0);
            pictureBox_invoice.Name = "pictureBox_invoice";
            pictureBox_invoice.Size = new Size(168, 619);
            pictureBox_invoice.TabIndex = 0;
            pictureBox_invoice.TabStop = false;
            pictureBox_invoice.DoubleClick += pictureBox_invoice_DoubleClick;
            // 
            // customGroupBox_invoice
            // 
            customGroupBox_invoice.BorderColor = Color.White;
            customGroupBox_invoice.BorderRadius = 30;
            customGroupBox_invoice.BorderThickness = 20;
            customGroupBox_invoice.Controls.Add(tableLayoutPanel_invoice);
            customGroupBox_invoice.Dock = DockStyle.Fill;
            customGroupBox_invoice.Font = new Font("Segoe UI", 1F);
            customGroupBox_invoice.Location = new Point(3, 3);
            customGroupBox_invoice.Name = "customGroupBox_invoice";
            customGroupBox_invoice.Padding = new Padding(30);
            customGroupBox_invoice.Size = new Size(431, 1096);
            customGroupBox_invoice.TabIndex = 1;
            customGroupBox_invoice.TabStop = false;
            // 
            // tableLayoutPanel_invoice
            // 
            tableLayoutPanel_invoice.BackColor = Color.Transparent;
            tableLayoutPanel_invoice.ColumnCount = 1;
            tableLayoutPanel_invoice.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_invoice.Controls.Add(textBox_trx_no, 0, 0);
            tableLayoutPanel_invoice.Controls.Add(panel_invoice, 0, 1);
            tableLayoutPanel_invoice.Dock = DockStyle.Fill;
            tableLayoutPanel_invoice.Location = new Point(30, 33);
            tableLayoutPanel_invoice.Name = "tableLayoutPanel_invoice";
            tableLayoutPanel_invoice.RowCount = 2;
            tableLayoutPanel_invoice.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel_invoice.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_invoice.Size = new Size(371, 1033);
            tableLayoutPanel_invoice.TabIndex = 0;
            // 
            // textBox_trx_no
            // 
            textBox_trx_no.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_trx_no.BorderStyle = BorderStyle.None;
            textBox_trx_no.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_trx_no.Location = new Point(0, 13);
            textBox_trx_no.Margin = new Padding(0);
            textBox_trx_no.Name = "textBox_trx_no";
            textBox_trx_no.Size = new Size(371, 44);
            textBox_trx_no.TabIndex = 1;
            textBox_trx_no.TextAlign = HorizontalAlignment.Center;
            textBox_trx_no.TextChanged += textBox_trx_no_TextChanged;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.ColumnCount = 2;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel_back.Controls.Add(customGroupBox_invoice, 0, 0);
            tableLayoutPanel_back.Controls.Add(customGroupBox_set, 1, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 1;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(1094, 1102);
            tableLayoutPanel_back.TabIndex = 2;
            // 
            // customGroupBox_set
            // 
            customGroupBox_set.BackColor = Color.Transparent;
            customGroupBox_set.BorderColor = Color.White;
            customGroupBox_set.BorderRadius = 30;
            customGroupBox_set.BorderThickness = 20;
            customGroupBox_set.Controls.Add(panel_set);
            customGroupBox_set.Dock = DockStyle.Fill;
            customGroupBox_set.Font = new Font("Segoe UI", 1F);
            customGroupBox_set.Location = new Point(440, 3);
            customGroupBox_set.Name = "customGroupBox_set";
            customGroupBox_set.Padding = new Padding(10);
            customGroupBox_set.Size = new Size(651, 1096);
            customGroupBox_set.TabIndex = 2;
            customGroupBox_set.TabStop = false;
            // 
            // panel_set
            // 
            panel_set.AutoScroll = true;
            panel_set.BackColor = Color.White;
            panel_set.Controls.Add(button_print);
            panel_set.Controls.Add(textBox_thank_desc);
            panel_set.Controls.Add(label23);
            panel_set.Controls.Add(label6);
            panel_set.Controls.Add(label5);
            panel_set.Controls.Add(label22);
            panel_set.Controls.Add(label11);
            panel_set.Controls.Add(label8);
            panel_set.Controls.Add(label19);
            panel_set.Controls.Add(label16);
            panel_set.Controls.Add(label15);
            panel_set.Controls.Add(label20);
            panel_set.Controls.Add(label21);
            panel_set.Controls.Add(label18);
            panel_set.Controls.Add(label17);
            panel_set.Controls.Add(label14);
            panel_set.Controls.Add(label13);
            panel_set.Controls.Add(label12);
            panel_set.Controls.Add(label10);
            panel_set.Controls.Add(label9);
            panel_set.Controls.Add(label7);
            panel_set.Controls.Add(label4);
            panel_set.Controls.Add(label3);
            panel_set.Controls.Add(label2);
            panel_set.Controls.Add(label24);
            panel_set.Controls.Add(label1);
            panel_set.Controls.Add(comboBox_tax_id_bold);
            panel_set.Controls.Add(comboBox_phone_bold);
            panel_set.Controls.Add(comboBox_bar_bold);
            panel_set.Controls.Add(comboBox_member_head_bold);
            panel_set.Controls.Add(comboBox_pro_head_bold);
            panel_set.Controls.Add(comboBox_sum_vat_bold);
            panel_set.Controls.Add(comboBox_thank_bold);
            panel_set.Controls.Add(comboBox_member_bold);
            panel_set.Controls.Add(comboBox_pro_bold);
            panel_set.Controls.Add(comboBox_net_bold);
            panel_set.Controls.Add(comboBox_sum_bold);
            panel_set.Controls.Add(comboBox_item_bold);
            panel_set.Controls.Add(comboBox_head_bold);
            panel_set.Controls.Add(comboBox_trx_no_bold);
            panel_set.Controls.Add(comboBox_address_bold);
            panel_set.Controls.Add(comboBox_type_bold);
            panel_set.Controls.Add(comboBox_name_bold);
            panel_set.Controls.Add(comboBox_tax_id_fontsize);
            panel_set.Controls.Add(comboBox_phone_fontsize);
            panel_set.Controls.Add(comboBox_address_fontsize);
            panel_set.Controls.Add(comboBox_tax_id);
            panel_set.Controls.Add(comboBox_phone);
            panel_set.Controls.Add(comboBox_bar_fontsize);
            panel_set.Controls.Add(comboBox_member_head_fontsize);
            panel_set.Controls.Add(comboBox_pro_head_fontsize);
            panel_set.Controls.Add(comboBox_sum_vat_fontsize);
            panel_set.Controls.Add(comboBox_thank_fontsize);
            panel_set.Controls.Add(comboBox_member_fontsize);
            panel_set.Controls.Add(comboBox_pro_fontsize);
            panel_set.Controls.Add(comboBox_net_fontsize);
            panel_set.Controls.Add(comboBox_sum_fontsize);
            panel_set.Controls.Add(comboBox_bar);
            panel_set.Controls.Add(comboBox_member);
            panel_set.Controls.Add(comboBox_pro);
            panel_set.Controls.Add(comboBox_sum_vat);
            panel_set.Controls.Add(comboBox_address);
            panel_set.Controls.Add(comboBox_item_fontsize);
            panel_set.Controls.Add(comboBox_head_fontsize);
            panel_set.Controls.Add(comboBox_trx_no_fontsize);
            panel_set.Controls.Add(comboBox_point_0);
            panel_set.Controls.Add(comboBox_column_size);
            panel_set.Controls.Add(comboBox_line);
            panel_set.Controls.Add(comboBox_type_fontsize);
            panel_set.Controls.Add(comboBox_name_fontsize);
            panel_set.Controls.Add(comboBox_logo_width);
            panel_set.Controls.Add(comboBox_print_name);
            panel_set.Controls.Add(comboBox_width);
            panel_set.Controls.Add(comboBox_margin);
            panel_set.Dock = DockStyle.Fill;
            panel_set.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel_set.Location = new Point(10, 13);
            panel_set.Name = "panel_set";
            panel_set.Size = new Size(631, 1073);
            panel_set.TabIndex = 0;
            // 
            // button_print
            // 
            button_print.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_print.Location = new Point(503, 52);
            button_print.Name = "button_print";
            button_print.Size = new Size(94, 36);
            button_print.TabIndex = 4;
            button_print.Text = "ปริ้น";
            button_print.UseVisualStyleBackColor = true;
            button_print.Click += button_print_Click;
            // 
            // textBox_thank_desc
            // 
            textBox_thank_desc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_thank_desc.Location = new Point(178, 1063);
            textBox_thank_desc.Multiline = true;
            textBox_thank_desc.Name = "textBox_thank_desc";
            textBox_thank_desc.Size = new Size(319, 63);
            textBox_thank_desc.TabIndex = 3;
            textBox_thank_desc.TextChanged += textBox_thank_TextChanged;
            // 
            // label23
            // 
            label23.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.Location = new Point(60, 307);
            label23.Name = "label23";
            label23.Size = new Size(112, 28);
            label23.TabIndex = 2;
            label23.Text = "เลขภาษี";
            label23.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(60, 349);
            label6.Name = "label6";
            label6.Size = new Size(112, 28);
            label6.TabIndex = 2;
            label6.Text = "เบอร์โทร";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(60, 265);
            label5.Name = "label5";
            label5.Size = new Size(112, 28);
            label5.TabIndex = 2;
            label5.Text = "ที่อยู่";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            label22.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.Location = new Point(69, 556);
            label22.Name = "label22";
            label22.Size = new Size(103, 28);
            label22.TabIndex = 2;
            label22.Text = "ทศนิยม";
            label22.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(69, 514);
            label11.Name = "label11";
            label11.Size = new Size(103, 28);
            label11.TabIndex = 2;
            label11.Text = "ตาราง";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(60, 433);
            label8.Name = "label8";
            label8.Size = new Size(112, 28);
            label8.TabIndex = 2;
            label8.Text = "เส้นขั้น";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            label19.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.Location = new Point(48, 895);
            label19.Name = "label19";
            label19.Size = new Size(124, 28);
            label19.TabIndex = 2;
            label19.Text = "สมาชิก";
            label19.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(48, 811);
            label16.Name = "label16";
            label16.Size = new Size(124, 28);
            label16.TabIndex = 2;
            label16.Text = "หัวข้อโปร";
            label16.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(48, 769);
            label15.Name = "label15";
            label15.Size = new Size(124, 28);
            label15.TabIndex = 2;
            label15.Text = "ภาษี";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            label20.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.Location = new Point(48, 982);
            label20.Name = "label20";
            label20.Size = new Size(124, 28);
            label20.TabIndex = 2;
            label20.Text = "บาร์โค้ด";
            label20.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            label21.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.Location = new Point(48, 1024);
            label21.Name = "label21";
            label21.Size = new Size(124, 28);
            label21.TabIndex = 2;
            label21.Text = "ท้ายบิล";
            label21.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.Location = new Point(48, 940);
            label18.Name = "label18";
            label18.Size = new Size(124, 28);
            label18.TabIndex = 2;
            label18.Text = "แต้มสมาชิก";
            label18.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(48, 856);
            label17.Name = "label17";
            label17.Size = new Size(124, 28);
            label17.TabIndex = 2;
            label17.Text = "ข้อมูลโปร";
            label17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(48, 727);
            label14.Name = "label14";
            label14.Size = new Size(124, 28);
            label14.TabIndex = 2;
            label14.Text = "สุทธิ";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(48, 685);
            label13.Name = "label13";
            label13.Size = new Size(124, 28);
            label13.TabIndex = 2;
            label13.Text = "ผลรวม";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(48, 643);
            label12.Name = "label12";
            label12.Size = new Size(124, 28);
            label12.TabIndex = 2;
            label12.Text = "สินค้า";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(48, 601);
            label10.Name = "label10";
            label10.Size = new Size(124, 28);
            label10.TabIndex = 2;
            label10.Text = "หัวข้อสินค้า";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(48, 475);
            label9.Name = "label9";
            label9.Size = new Size(124, 28);
            label9.TabIndex = 2;
            label9.Text = "เลขใบเสร็จ";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(60, 391);
            label7.Name = "label7";
            label7.Size = new Size(112, 28);
            label7.TabIndex = 2;
            label7.Text = "ปรเภท";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(60, 223);
            label4.Name = "label4";
            label4.Size = new Size(112, 28);
            label4.TabIndex = 2;
            label4.Text = "ชื่อร้าน";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(60, 181);
            label3.Name = "label3";
            label3.Size = new Size(112, 28);
            label3.TabIndex = 2;
            label3.Text = "ขนาดภาพ";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(60, 139);
            label2.Name = "label2";
            label2.Size = new Size(112, 28);
            label2.TabIndex = 2;
            label2.Text = "ระยะขอบ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            label24.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.Location = new Point(48, 52);
            label24.Name = "label24";
            label24.Size = new Size(124, 36);
            label24.TabIndex = 2;
            label24.Text = "เครื่องปริ้น";
            label24.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(48, 93);
            label1.Name = "label1";
            label1.Size = new Size(124, 36);
            label1.TabIndex = 2;
            label1.Text = "ความกว้าง";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // comboBox_tax_id_bold
            // 
            comboBox_tax_id_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_tax_id_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_tax_id_bold.FormattingEnabled = true;
            comboBox_tax_id_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_tax_id_bold.Location = new Point(514, 304);
            comboBox_tax_id_bold.Name = "comboBox_tax_id_bold";
            comboBox_tax_id_bold.Size = new Size(151, 36);
            comboBox_tax_id_bold.TabIndex = 1;
            comboBox_tax_id_bold.SelectedIndexChanged += comboBox_tax_id_bold_SelectedIndexChanged;
            // 
            // comboBox_phone_bold
            // 
            comboBox_phone_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_phone_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_phone_bold.FormattingEnabled = true;
            comboBox_phone_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_phone_bold.Location = new Point(514, 346);
            comboBox_phone_bold.Name = "comboBox_phone_bold";
            comboBox_phone_bold.Size = new Size(151, 36);
            comboBox_phone_bold.TabIndex = 1;
            comboBox_phone_bold.SelectedIndexChanged += comboBox_phone_bold_SelectedIndexChanged;
            // 
            // comboBox_bar_bold
            // 
            comboBox_bar_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_bar_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_bar_bold.FormattingEnabled = true;
            comboBox_bar_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_bar_bold.Location = new Point(514, 979);
            comboBox_bar_bold.Name = "comboBox_bar_bold";
            comboBox_bar_bold.Size = new Size(151, 36);
            comboBox_bar_bold.TabIndex = 1;
            comboBox_bar_bold.SelectedIndexChanged += comboBox_bar_bold_SelectedIndexChanged;
            // 
            // comboBox_member_head_bold
            // 
            comboBox_member_head_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_member_head_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_member_head_bold.FormattingEnabled = true;
            comboBox_member_head_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_member_head_bold.Location = new Point(514, 895);
            comboBox_member_head_bold.Name = "comboBox_member_head_bold";
            comboBox_member_head_bold.Size = new Size(151, 36);
            comboBox_member_head_bold.TabIndex = 1;
            comboBox_member_head_bold.SelectedIndexChanged += comboBox_member_head_bold_SelectedIndexChanged;
            // 
            // comboBox_pro_head_bold
            // 
            comboBox_pro_head_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_pro_head_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_pro_head_bold.FormattingEnabled = true;
            comboBox_pro_head_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_pro_head_bold.Location = new Point(514, 811);
            comboBox_pro_head_bold.Name = "comboBox_pro_head_bold";
            comboBox_pro_head_bold.Size = new Size(151, 36);
            comboBox_pro_head_bold.TabIndex = 1;
            comboBox_pro_head_bold.SelectedIndexChanged += comboBox_pro_head_bold_SelectedIndexChanged;
            // 
            // comboBox_sum_vat_bold
            // 
            comboBox_sum_vat_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sum_vat_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_sum_vat_bold.FormattingEnabled = true;
            comboBox_sum_vat_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_sum_vat_bold.Location = new Point(514, 769);
            comboBox_sum_vat_bold.Name = "comboBox_sum_vat_bold";
            comboBox_sum_vat_bold.Size = new Size(151, 36);
            comboBox_sum_vat_bold.TabIndex = 1;
            comboBox_sum_vat_bold.SelectedIndexChanged += comboBox_sum_vat_bold_SelectedIndexChanged;
            // 
            // comboBox_thank_bold
            // 
            comboBox_thank_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_thank_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_thank_bold.FormattingEnabled = true;
            comboBox_thank_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_thank_bold.Location = new Point(346, 1021);
            comboBox_thank_bold.Name = "comboBox_thank_bold";
            comboBox_thank_bold.Size = new Size(151, 36);
            comboBox_thank_bold.TabIndex = 1;
            comboBox_thank_bold.SelectedIndexChanged += comboBox_thank_bold_SelectedIndexChanged;
            // 
            // comboBox_member_bold
            // 
            comboBox_member_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_member_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_member_bold.FormattingEnabled = true;
            comboBox_member_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_member_bold.Location = new Point(346, 937);
            comboBox_member_bold.Name = "comboBox_member_bold";
            comboBox_member_bold.Size = new Size(151, 36);
            comboBox_member_bold.TabIndex = 1;
            comboBox_member_bold.SelectedIndexChanged += comboBox_member_bold_SelectedIndexChanged;
            // 
            // comboBox_pro_bold
            // 
            comboBox_pro_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_pro_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_pro_bold.FormattingEnabled = true;
            comboBox_pro_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_pro_bold.Location = new Point(346, 853);
            comboBox_pro_bold.Name = "comboBox_pro_bold";
            comboBox_pro_bold.Size = new Size(151, 36);
            comboBox_pro_bold.TabIndex = 1;
            comboBox_pro_bold.SelectedIndexChanged += comboBox_pro_bold_SelectedIndexChanged;
            // 
            // comboBox_net_bold
            // 
            comboBox_net_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_net_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_net_bold.FormattingEnabled = true;
            comboBox_net_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_net_bold.Location = new Point(346, 724);
            comboBox_net_bold.Name = "comboBox_net_bold";
            comboBox_net_bold.Size = new Size(151, 36);
            comboBox_net_bold.TabIndex = 1;
            comboBox_net_bold.SelectedIndexChanged += comboBox_net_bold_SelectedIndexChanged;
            // 
            // comboBox_sum_bold
            // 
            comboBox_sum_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sum_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_sum_bold.FormattingEnabled = true;
            comboBox_sum_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_sum_bold.Location = new Point(346, 682);
            comboBox_sum_bold.Name = "comboBox_sum_bold";
            comboBox_sum_bold.Size = new Size(151, 36);
            comboBox_sum_bold.TabIndex = 1;
            comboBox_sum_bold.SelectedIndexChanged += comboBox_sum_bold_SelectedIndexChanged;
            // 
            // comboBox_item_bold
            // 
            comboBox_item_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_item_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_item_bold.FormattingEnabled = true;
            comboBox_item_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_item_bold.Location = new Point(346, 640);
            comboBox_item_bold.Name = "comboBox_item_bold";
            comboBox_item_bold.Size = new Size(151, 36);
            comboBox_item_bold.TabIndex = 1;
            comboBox_item_bold.SelectedIndexChanged += comboBox_item_bold_SelectedIndexChanged;
            // 
            // comboBox_head_bold
            // 
            comboBox_head_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_head_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_head_bold.FormattingEnabled = true;
            comboBox_head_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_head_bold.Location = new Point(346, 598);
            comboBox_head_bold.Name = "comboBox_head_bold";
            comboBox_head_bold.Size = new Size(151, 36);
            comboBox_head_bold.TabIndex = 1;
            comboBox_head_bold.SelectedIndexChanged += comboBox_head_bold_SelectedIndexChanged;
            // 
            // comboBox_trx_no_bold
            // 
            comboBox_trx_no_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_trx_no_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_trx_no_bold.FormattingEnabled = true;
            comboBox_trx_no_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_trx_no_bold.Location = new Point(346, 472);
            comboBox_trx_no_bold.Name = "comboBox_trx_no_bold";
            comboBox_trx_no_bold.Size = new Size(151, 36);
            comboBox_trx_no_bold.TabIndex = 1;
            comboBox_trx_no_bold.SelectedIndexChanged += comboBox_trx_no_bold_SelectedIndexChanged;
            // 
            // comboBox_address_bold
            // 
            comboBox_address_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_address_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_address_bold.FormattingEnabled = true;
            comboBox_address_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_address_bold.Location = new Point(514, 262);
            comboBox_address_bold.Name = "comboBox_address_bold";
            comboBox_address_bold.Size = new Size(151, 36);
            comboBox_address_bold.TabIndex = 1;
            comboBox_address_bold.SelectedIndexChanged += comboBox_address_bold_SelectedIndexChanged;
            // 
            // comboBox_type_bold
            // 
            comboBox_type_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_type_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_type_bold.FormattingEnabled = true;
            comboBox_type_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_type_bold.Location = new Point(346, 388);
            comboBox_type_bold.Name = "comboBox_type_bold";
            comboBox_type_bold.Size = new Size(151, 36);
            comboBox_type_bold.TabIndex = 1;
            comboBox_type_bold.SelectedIndexChanged += comboBox_type_bold_SelectedIndexChanged;
            // 
            // comboBox_name_bold
            // 
            comboBox_name_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_name_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_name_bold.FormattingEnabled = true;
            comboBox_name_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_name_bold.Location = new Point(346, 220);
            comboBox_name_bold.Name = "comboBox_name_bold";
            comboBox_name_bold.Size = new Size(151, 36);
            comboBox_name_bold.TabIndex = 1;
            comboBox_name_bold.SelectedIndexChanged += comboBox_name_bold_SelectedIndexChanged;
            // 
            // comboBox_tax_id_fontsize
            // 
            comboBox_tax_id_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_tax_id_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_tax_id_fontsize.FormattingEnabled = true;
            comboBox_tax_id_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_tax_id_fontsize.Location = new Point(346, 304);
            comboBox_tax_id_fontsize.Name = "comboBox_tax_id_fontsize";
            comboBox_tax_id_fontsize.Size = new Size(151, 36);
            comboBox_tax_id_fontsize.TabIndex = 1;
            comboBox_tax_id_fontsize.SelectedIndexChanged += comboBox_tax_id_fontsize_SelectedIndexChanged;
            // 
            // comboBox_phone_fontsize
            // 
            comboBox_phone_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_phone_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_phone_fontsize.FormattingEnabled = true;
            comboBox_phone_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_phone_fontsize.Location = new Point(346, 346);
            comboBox_phone_fontsize.Name = "comboBox_phone_fontsize";
            comboBox_phone_fontsize.Size = new Size(151, 36);
            comboBox_phone_fontsize.TabIndex = 1;
            comboBox_phone_fontsize.SelectedIndexChanged += comboBox_phone_fontsize_SelectedIndexChanged;
            // 
            // comboBox_address_fontsize
            // 
            comboBox_address_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_address_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_address_fontsize.FormattingEnabled = true;
            comboBox_address_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_address_fontsize.Location = new Point(346, 262);
            comboBox_address_fontsize.Name = "comboBox_address_fontsize";
            comboBox_address_fontsize.Size = new Size(151, 36);
            comboBox_address_fontsize.TabIndex = 1;
            comboBox_address_fontsize.SelectedIndexChanged += comboBox_address_fontsize_SelectedIndexChanged;
            // 
            // comboBox_tax_id
            // 
            comboBox_tax_id.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_tax_id.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_tax_id.FormattingEnabled = true;
            comboBox_tax_id.Items.AddRange(new object[] { "แสดง", "ไม่แสดง" });
            comboBox_tax_id.Location = new Point(178, 304);
            comboBox_tax_id.Name = "comboBox_tax_id";
            comboBox_tax_id.Size = new Size(151, 36);
            comboBox_tax_id.TabIndex = 1;
            comboBox_tax_id.SelectedIndexChanged += comboBox_tax_id_SelectedIndexChanged;
            // 
            // comboBox_phone
            // 
            comboBox_phone.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_phone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_phone.FormattingEnabled = true;
            comboBox_phone.Items.AddRange(new object[] { "แสดง", "ไม่แสดง" });
            comboBox_phone.Location = new Point(178, 346);
            comboBox_phone.Name = "comboBox_phone";
            comboBox_phone.Size = new Size(151, 36);
            comboBox_phone.TabIndex = 1;
            comboBox_phone.SelectedIndexChanged += comboBox_phone_SelectedIndexChanged;
            // 
            // comboBox_bar_fontsize
            // 
            comboBox_bar_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_bar_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_bar_fontsize.FormattingEnabled = true;
            comboBox_bar_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_bar_fontsize.Location = new Point(346, 979);
            comboBox_bar_fontsize.Name = "comboBox_bar_fontsize";
            comboBox_bar_fontsize.Size = new Size(151, 36);
            comboBox_bar_fontsize.TabIndex = 1;
            comboBox_bar_fontsize.SelectedIndexChanged += comboBox_bar_fontsize_SelectedIndexChanged;
            // 
            // comboBox_member_head_fontsize
            // 
            comboBox_member_head_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_member_head_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_member_head_fontsize.FormattingEnabled = true;
            comboBox_member_head_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_member_head_fontsize.Location = new Point(346, 895);
            comboBox_member_head_fontsize.Name = "comboBox_member_head_fontsize";
            comboBox_member_head_fontsize.Size = new Size(151, 36);
            comboBox_member_head_fontsize.TabIndex = 1;
            comboBox_member_head_fontsize.SelectedIndexChanged += comboBox_member_head_fontsize_SelectedIndexChanged;
            // 
            // comboBox_pro_head_fontsize
            // 
            comboBox_pro_head_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_pro_head_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_pro_head_fontsize.FormattingEnabled = true;
            comboBox_pro_head_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_pro_head_fontsize.Location = new Point(346, 811);
            comboBox_pro_head_fontsize.Name = "comboBox_pro_head_fontsize";
            comboBox_pro_head_fontsize.Size = new Size(151, 36);
            comboBox_pro_head_fontsize.TabIndex = 1;
            comboBox_pro_head_fontsize.SelectedIndexChanged += comboBox_pro_head_fontsize_SelectedIndexChanged;
            // 
            // comboBox_sum_vat_fontsize
            // 
            comboBox_sum_vat_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sum_vat_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_sum_vat_fontsize.FormattingEnabled = true;
            comboBox_sum_vat_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_sum_vat_fontsize.Location = new Point(346, 769);
            comboBox_sum_vat_fontsize.Name = "comboBox_sum_vat_fontsize";
            comboBox_sum_vat_fontsize.Size = new Size(151, 36);
            comboBox_sum_vat_fontsize.TabIndex = 1;
            comboBox_sum_vat_fontsize.SelectedIndexChanged += comboBox_sum_vat_fontsize_SelectedIndexChanged;
            // 
            // comboBox_thank_fontsize
            // 
            comboBox_thank_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_thank_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_thank_fontsize.FormattingEnabled = true;
            comboBox_thank_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_thank_fontsize.Location = new Point(178, 1021);
            comboBox_thank_fontsize.Name = "comboBox_thank_fontsize";
            comboBox_thank_fontsize.Size = new Size(151, 36);
            comboBox_thank_fontsize.TabIndex = 1;
            comboBox_thank_fontsize.SelectedIndexChanged += comboBox_thank_fontsize_SelectedIndexChanged;
            // 
            // comboBox_member_fontsize
            // 
            comboBox_member_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_member_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_member_fontsize.FormattingEnabled = true;
            comboBox_member_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_member_fontsize.Location = new Point(178, 937);
            comboBox_member_fontsize.Name = "comboBox_member_fontsize";
            comboBox_member_fontsize.Size = new Size(151, 36);
            comboBox_member_fontsize.TabIndex = 1;
            comboBox_member_fontsize.SelectedIndexChanged += comboBox_member_fontsize_SelectedIndexChanged;
            // 
            // comboBox_pro_fontsize
            // 
            comboBox_pro_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_pro_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_pro_fontsize.FormattingEnabled = true;
            comboBox_pro_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_pro_fontsize.Location = new Point(178, 853);
            comboBox_pro_fontsize.Name = "comboBox_pro_fontsize";
            comboBox_pro_fontsize.Size = new Size(151, 36);
            comboBox_pro_fontsize.TabIndex = 1;
            comboBox_pro_fontsize.SelectedIndexChanged += comboBox_pro_fontsize_SelectedIndexChanged;
            // 
            // comboBox_net_fontsize
            // 
            comboBox_net_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_net_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_net_fontsize.FormattingEnabled = true;
            comboBox_net_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_net_fontsize.Location = new Point(178, 724);
            comboBox_net_fontsize.Name = "comboBox_net_fontsize";
            comboBox_net_fontsize.Size = new Size(151, 36);
            comboBox_net_fontsize.TabIndex = 1;
            comboBox_net_fontsize.SelectedIndexChanged += comboBox_net_fontsize_SelectedIndexChanged;
            // 
            // comboBox_sum_fontsize
            // 
            comboBox_sum_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sum_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_sum_fontsize.FormattingEnabled = true;
            comboBox_sum_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_sum_fontsize.Location = new Point(178, 682);
            comboBox_sum_fontsize.Name = "comboBox_sum_fontsize";
            comboBox_sum_fontsize.Size = new Size(151, 36);
            comboBox_sum_fontsize.TabIndex = 1;
            comboBox_sum_fontsize.SelectedIndexChanged += comboBox_sum_fontsize_SelectedIndexChanged;
            // 
            // comboBox_bar
            // 
            comboBox_bar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_bar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_bar.FormattingEnabled = true;
            comboBox_bar.Items.AddRange(new object[] { "ไม่แสดง", "Barcode", "QR Code" });
            comboBox_bar.Location = new Point(178, 979);
            comboBox_bar.Name = "comboBox_bar";
            comboBox_bar.Size = new Size(151, 36);
            comboBox_bar.TabIndex = 1;
            comboBox_bar.SelectedIndexChanged += comboBox_bar_SelectedIndexChanged;
            // 
            // comboBox_member
            // 
            comboBox_member.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_member.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_member.FormattingEnabled = true;
            comboBox_member.Items.AddRange(new object[] { "แสดง", "ไม่แสดง" });
            comboBox_member.Location = new Point(178, 895);
            comboBox_member.Name = "comboBox_member";
            comboBox_member.Size = new Size(151, 36);
            comboBox_member.TabIndex = 1;
            comboBox_member.SelectedIndexChanged += comboBox_member_SelectedIndexChanged;
            // 
            // comboBox_pro
            // 
            comboBox_pro.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_pro.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_pro.FormattingEnabled = true;
            comboBox_pro.Items.AddRange(new object[] { "แสดง", "ไม่แสดง" });
            comboBox_pro.Location = new Point(178, 811);
            comboBox_pro.Name = "comboBox_pro";
            comboBox_pro.Size = new Size(151, 36);
            comboBox_pro.TabIndex = 1;
            comboBox_pro.SelectedIndexChanged += comboBox_pro_SelectedIndexChanged;
            // 
            // comboBox_sum_vat
            // 
            comboBox_sum_vat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_sum_vat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_sum_vat.FormattingEnabled = true;
            comboBox_sum_vat.Items.AddRange(new object[] { "แสดง", "ไม่แสดง" });
            comboBox_sum_vat.Location = new Point(178, 769);
            comboBox_sum_vat.Name = "comboBox_sum_vat";
            comboBox_sum_vat.Size = new Size(151, 36);
            comboBox_sum_vat.TabIndex = 1;
            comboBox_sum_vat.SelectedIndexChanged += comboBox_sum_vat_SelectedIndexChanged;
            // 
            // comboBox_address
            // 
            comboBox_address.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_address.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_address.FormattingEnabled = true;
            comboBox_address.Items.AddRange(new object[] { "แสดง", "ไม่แสดง" });
            comboBox_address.Location = new Point(178, 262);
            comboBox_address.Name = "comboBox_address";
            comboBox_address.Size = new Size(151, 36);
            comboBox_address.TabIndex = 1;
            comboBox_address.SelectedIndexChanged += comboBox_address_SelectedIndexChanged;
            // 
            // comboBox_item_fontsize
            // 
            comboBox_item_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_item_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_item_fontsize.FormattingEnabled = true;
            comboBox_item_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_item_fontsize.Location = new Point(178, 640);
            comboBox_item_fontsize.Name = "comboBox_item_fontsize";
            comboBox_item_fontsize.Size = new Size(151, 36);
            comboBox_item_fontsize.TabIndex = 1;
            comboBox_item_fontsize.SelectedIndexChanged += comboBox_item_fontsize_SelectedIndexChanged;
            // 
            // comboBox_head_fontsize
            // 
            comboBox_head_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_head_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_head_fontsize.FormattingEnabled = true;
            comboBox_head_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_head_fontsize.Location = new Point(178, 598);
            comboBox_head_fontsize.Name = "comboBox_head_fontsize";
            comboBox_head_fontsize.Size = new Size(151, 36);
            comboBox_head_fontsize.TabIndex = 1;
            comboBox_head_fontsize.SelectedIndexChanged += comboBox_head_fontsize_SelectedIndexChanged;
            // 
            // comboBox_trx_no_fontsize
            // 
            comboBox_trx_no_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_trx_no_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_trx_no_fontsize.FormattingEnabled = true;
            comboBox_trx_no_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_trx_no_fontsize.Location = new Point(178, 472);
            comboBox_trx_no_fontsize.Name = "comboBox_trx_no_fontsize";
            comboBox_trx_no_fontsize.Size = new Size(151, 36);
            comboBox_trx_no_fontsize.TabIndex = 1;
            comboBox_trx_no_fontsize.SelectedIndexChanged += comboBox_trx_no_fontsize_SelectedIndexChanged;
            // 
            // comboBox_point_0
            // 
            comboBox_point_0.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_point_0.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_point_0.FormattingEnabled = true;
            comboBox_point_0.Items.AddRange(new object[] { "มี .00", "ไม่มี .00" });
            comboBox_point_0.Location = new Point(178, 556);
            comboBox_point_0.Name = "comboBox_point_0";
            comboBox_point_0.Size = new Size(151, 36);
            comboBox_point_0.TabIndex = 1;
            comboBox_point_0.SelectedIndexChanged += comboBox_point_0_SelectedIndexChanged;
            // 
            // comboBox_column_size
            // 
            comboBox_column_size.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_column_size.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_column_size.FormattingEnabled = true;
            comboBox_column_size.Items.AddRange(new object[] { "60|20|20", "50|20|30", "50|25|25", "40|20|40", "40|30|30" });
            comboBox_column_size.Location = new Point(178, 514);
            comboBox_column_size.Name = "comboBox_column_size";
            comboBox_column_size.Size = new Size(151, 36);
            comboBox_column_size.TabIndex = 1;
            comboBox_column_size.SelectedIndexChanged += comboBox_column_size_SelectedIndexChanged;
            // 
            // comboBox_line
            // 
            comboBox_line.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_line.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_line.FormattingEnabled = true;
            comboBox_line.Items.AddRange(new object[] { "เส้นตรง", "เส้นจุด" });
            comboBox_line.Location = new Point(178, 430);
            comboBox_line.Name = "comboBox_line";
            comboBox_line.Size = new Size(151, 36);
            comboBox_line.TabIndex = 1;
            comboBox_line.SelectedIndexChanged += comboBox_line_SelectedIndexChanged;
            // 
            // comboBox_type_fontsize
            // 
            comboBox_type_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_type_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_type_fontsize.FormattingEnabled = true;
            comboBox_type_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_type_fontsize.Location = new Point(178, 388);
            comboBox_type_fontsize.Name = "comboBox_type_fontsize";
            comboBox_type_fontsize.Size = new Size(151, 36);
            comboBox_type_fontsize.TabIndex = 1;
            comboBox_type_fontsize.SelectedIndexChanged += comboBox_type_fontsize_SelectedIndexChanged;
            // 
            // comboBox_name_fontsize
            // 
            comboBox_name_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_name_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_name_fontsize.FormattingEnabled = true;
            comboBox_name_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_name_fontsize.Location = new Point(178, 220);
            comboBox_name_fontsize.Name = "comboBox_name_fontsize";
            comboBox_name_fontsize.Size = new Size(151, 36);
            comboBox_name_fontsize.TabIndex = 1;
            comboBox_name_fontsize.SelectedIndexChanged += comboBox_name_fontsize_SelectedIndexChanged;
            // 
            // comboBox_logo_width
            // 
            comboBox_logo_width.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_logo_width.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_logo_width.FormattingEnabled = true;
            comboBox_logo_width.Items.AddRange(new object[] { "10", "20", "30", "40", "50", "60", "70", "80", "90" });
            comboBox_logo_width.Location = new Point(178, 178);
            comboBox_logo_width.Name = "comboBox_logo_width";
            comboBox_logo_width.Size = new Size(151, 36);
            comboBox_logo_width.TabIndex = 1;
            comboBox_logo_width.SelectedIndexChanged += comboBox_logo_width_SelectedIndexChanged;
            // 
            // comboBox_print_name
            // 
            comboBox_print_name.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_print_name.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_print_name.FormattingEnabled = true;
            comboBox_print_name.Items.AddRange(new object[] { "57", "58", "80" });
            comboBox_print_name.Location = new Point(178, 52);
            comboBox_print_name.Name = "comboBox_print_name";
            comboBox_print_name.Size = new Size(319, 36);
            comboBox_print_name.TabIndex = 1;
            comboBox_print_name.SelectedIndexChanged += comboBox_print_name_SelectedIndexChanged;
            // 
            // comboBox_width
            // 
            comboBox_width.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_width.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_width.FormattingEnabled = true;
            comboBox_width.Items.AddRange(new object[] { "57", "58", "80" });
            comboBox_width.Location = new Point(178, 94);
            comboBox_width.Name = "comboBox_width";
            comboBox_width.Size = new Size(151, 36);
            comboBox_width.TabIndex = 1;
            comboBox_width.SelectedIndexChanged += comboBox_width_SelectedIndexChanged;
            // 
            // comboBox_margin
            // 
            comboBox_margin.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_margin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_margin.FormattingEnabled = true;
            comboBox_margin.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            comboBox_margin.Location = new Point(178, 136);
            comboBox_margin.Name = "comboBox_margin";
            comboBox_margin.Size = new Size(151, 36);
            comboBox_margin.TabIndex = 1;
            comboBox_margin.SelectedIndexChanged += comboBox_margin_SelectedIndexChanged;
            // 
            // timer_search
            // 
            timer_search.Tick += timer_search_Tick;
            // 
            // backgroundWorker_print
            // 
            backgroundWorker_print.DoWork += backgroundWorker_print_DoWork;
            backgroundWorker_print.RunWorkerCompleted += backgroundWorker_print_RunWorkerCompleted;
            // 
            // Form_Setting_Invoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cyan;
            ClientSize = new Size(1094, 1102);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Setting_Invoice";
            Text = "Form_Setting_Invoice";
            FormClosed += Form_Setting_Invoice_FormClosed;
            Load += Form_Setting_Invoice_Load;
            Shown += Form_Setting_Invoice_Shown;
            panel_invoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_invoice).EndInit();
            customGroupBox_invoice.ResumeLayout(false);
            tableLayoutPanel_invoice.ResumeLayout(false);
            tableLayoutPanel_invoice.PerformLayout();
            tableLayoutPanel_back.ResumeLayout(false);
            customGroupBox_set.ResumeLayout(false);
            panel_set.ResumeLayout(false);
            panel_set.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_invoice;
        private PictureBox pictureBox_invoice;
        private CustomGroupBox customGroupBox_invoice;
        private TableLayoutPanel tableLayoutPanel_invoice;
        private TextBox textBox_trx_no;
        private TableLayoutPanel tableLayoutPanel_back;
        private CustomGroupBox customGroupBox_set;
        private Panel panel_set;
        private System.Windows.Forms.Timer timer_search;
        private CustomGroupBox customGroupBox_search;
        private ComboBox comboBox_margin;
        private ComboBox comboBox_logo_width;
        private ComboBox comboBox_width;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private ComboBox comboBox_name_bold;
        private ComboBox comboBox_name_fontsize;
        private Label label5;
        private ComboBox comboBox_address_bold;
        private ComboBox comboBox_address_fontsize;
        private ComboBox comboBox_address;
        private Label label6;
        private ComboBox comboBox_phone_bold;
        private ComboBox comboBox_phone_fontsize;
        private ComboBox comboBox_phone;
        private Label label7;
        private ComboBox comboBox_type_bold;
        private ComboBox comboBox_type_fontsize;
        private Label label8;
        private ComboBox comboBox_line;
        private Label label9;
        private ComboBox comboBox_trx_no_bold;
        private ComboBox comboBox_trx_no_fontsize;
        private Label label10;
        private ComboBox comboBox_head_bold;
        private ComboBox comboBox_head_fontsize;
        private Label label11;
        private ComboBox comboBox_column_size;
        private Label label12;
        private ComboBox comboBox_item_bold;
        private ComboBox comboBox_item_fontsize;
        private Label label13;
        private ComboBox comboBox_sum_bold;
        private ComboBox comboBox_sum_fontsize;
        private Label label15;
        private Label label14;
        private ComboBox comboBox_net_bold;
        private ComboBox comboBox_net_fontsize;
        private ComboBox comboBox_sum_vat;
        private ComboBox comboBox_sum_vat_bold;
        private ComboBox comboBox_sum_vat_fontsize;
        private Label label16;
        private Label label17;
        private ComboBox comboBox_pro_head_bold;
        private ComboBox comboBox_pro_bold;
        private ComboBox comboBox_pro_head_fontsize;
        private ComboBox comboBox_pro_fontsize;
        private ComboBox comboBox_pro;
        private Label label19;
        private Label label18;
        private ComboBox comboBox_member_head_bold;
        private ComboBox comboBox_member_bold;
        private ComboBox comboBox_member_head_fontsize;
        private ComboBox comboBox_member_fontsize;
        private ComboBox comboBox_member;
        private Label label20;
        private Label label21;
        private ComboBox comboBox_bar_bold;
        private ComboBox comboBox_thank_bold;
        private ComboBox comboBox_bar_fontsize;
        private ComboBox comboBox_thank_fontsize;
        private ComboBox comboBox_bar;
        private TextBox textBox_thank_desc;
        private Label label22;
        private ComboBox comboBox_point_0;
        private Label label23;
        private ComboBox comboBox_tax_id_bold;
        private ComboBox comboBox_tax_id_fontsize;
        private ComboBox comboBox_tax_id;
        private ComboBox comboBox_print_name;
        private Button button_print;
        private Label label24;
        private System.ComponentModel.BackgroundWorker backgroundWorker_print;
    }
}