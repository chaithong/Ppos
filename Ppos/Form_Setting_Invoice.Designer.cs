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
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            comboBox_phone_bold = new ComboBox();
            comboBox_address_bold = new ComboBox();
            comboBox_name_bold = new ComboBox();
            comboBox_phone_fontsize = new ComboBox();
            comboBox_address_fontsize = new ComboBox();
            comboBox_phone = new ComboBox();
            comboBox_address = new ComboBox();
            comboBox_name_fontsize = new ComboBox();
            comboBox_logo_width = new ComboBox();
            comboBox_width = new ComboBox();
            comboBox_margin = new ComboBox();
            timer_search = new System.Windows.Forms.Timer(components);
            comboBox_type_fontsize = new ComboBox();
            comboBox_type_bold = new ComboBox();
            label7 = new Label();
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
            panel_invoice.Size = new Size(256, 559);
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
            customGroupBox_invoice.Size = new Size(322, 698);
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
            tableLayoutPanel_invoice.Size = new Size(262, 635);
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
            textBox_trx_no.Size = new Size(262, 44);
            textBox_trx_no.TabIndex = 1;
            textBox_trx_no.TextAlign = HorizontalAlignment.Center;
            textBox_trx_no.TextChanged += textBox_trx_no_TextChanged;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.ColumnCount = 2;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel_back.Controls.Add(customGroupBox_invoice, 0, 0);
            tableLayoutPanel_back.Controls.Add(customGroupBox_set, 1, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 1;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(1094, 704);
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
            customGroupBox_set.Location = new Point(331, 3);
            customGroupBox_set.Name = "customGroupBox_set";
            customGroupBox_set.Padding = new Padding(10);
            customGroupBox_set.Size = new Size(760, 698);
            customGroupBox_set.TabIndex = 2;
            customGroupBox_set.TabStop = false;
            // 
            // panel_set
            // 
            panel_set.Controls.Add(label6);
            panel_set.Controls.Add(label5);
            panel_set.Controls.Add(label7);
            panel_set.Controls.Add(label4);
            panel_set.Controls.Add(label3);
            panel_set.Controls.Add(label2);
            panel_set.Controls.Add(label1);
            panel_set.Controls.Add(comboBox_phone_bold);
            panel_set.Controls.Add(comboBox_address_bold);
            panel_set.Controls.Add(comboBox_type_bold);
            panel_set.Controls.Add(comboBox_name_bold);
            panel_set.Controls.Add(comboBox_phone_fontsize);
            panel_set.Controls.Add(comboBox_address_fontsize);
            panel_set.Controls.Add(comboBox_phone);
            panel_set.Controls.Add(comboBox_address);
            panel_set.Controls.Add(comboBox_type_fontsize);
            panel_set.Controls.Add(comboBox_name_fontsize);
            panel_set.Controls.Add(comboBox_logo_width);
            panel_set.Controls.Add(comboBox_width);
            panel_set.Controls.Add(comboBox_margin);
            panel_set.Dock = DockStyle.Fill;
            panel_set.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel_set.Location = new Point(10, 13);
            panel_set.Name = "panel_set";
            panel_set.Size = new Size(740, 675);
            panel_set.TabIndex = 0;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(48, 294);
            label6.Name = "label6";
            label6.Size = new Size(103, 28);
            label6.TabIndex = 2;
            label6.Text = "เบอร์โทร";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(48, 252);
            label5.Name = "label5";
            label5.Size = new Size(103, 28);
            label5.TabIndex = 2;
            label5.Text = "ที่อยู่";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(48, 215);
            label4.Name = "label4";
            label4.Size = new Size(103, 28);
            label4.TabIndex = 2;
            label4.Text = "ชื่อร้าน";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(48, 173);
            label3.Name = "label3";
            label3.Size = new Size(103, 28);
            label3.TabIndex = 2;
            label3.Text = "ขนาดภาพ";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(48, 131);
            label2.Name = "label2";
            label2.Size = new Size(103, 28);
            label2.TabIndex = 2;
            label2.Text = "ระยะขอบ";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(48, 81);
            label1.Name = "label1";
            label1.Size = new Size(112, 36);
            label1.TabIndex = 2;
            label1.Text = "ความกว้าง";
            // 
            // comboBox_phone_bold
            // 
            comboBox_phone_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_phone_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_phone_bold.FormattingEnabled = true;
            comboBox_phone_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_phone_bold.Location = new Point(502, 291);
            comboBox_phone_bold.Name = "comboBox_phone_bold";
            comboBox_phone_bold.Size = new Size(151, 36);
            comboBox_phone_bold.TabIndex = 1;
            comboBox_phone_bold.SelectedIndexChanged += comboBox_phone_bold_SelectedIndexChanged;
            // 
            // comboBox_address_bold
            // 
            comboBox_address_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_address_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_address_bold.FormattingEnabled = true;
            comboBox_address_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_address_bold.Location = new Point(502, 249);
            comboBox_address_bold.Name = "comboBox_address_bold";
            comboBox_address_bold.Size = new Size(151, 36);
            comboBox_address_bold.TabIndex = 1;
            comboBox_address_bold.SelectedIndexChanged += comboBox_address_bold_SelectedIndexChanged;
            // 
            // comboBox_name_bold
            // 
            comboBox_name_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_name_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_name_bold.FormattingEnabled = true;
            comboBox_name_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_name_bold.Location = new Point(334, 207);
            comboBox_name_bold.Name = "comboBox_name_bold";
            comboBox_name_bold.Size = new Size(151, 36);
            comboBox_name_bold.TabIndex = 1;
            comboBox_name_bold.SelectedIndexChanged += comboBox_name_bold_SelectedIndexChanged;
            // 
            // comboBox_phone_fontsize
            // 
            comboBox_phone_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_phone_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_phone_fontsize.FormattingEnabled = true;
            comboBox_phone_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_phone_fontsize.Location = new Point(334, 291);
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
            comboBox_address_fontsize.Location = new Point(334, 249);
            comboBox_address_fontsize.Name = "comboBox_address_fontsize";
            comboBox_address_fontsize.Size = new Size(151, 36);
            comboBox_address_fontsize.TabIndex = 1;
            comboBox_address_fontsize.SelectedIndexChanged += comboBox_address_fontsize_SelectedIndexChanged;
            // 
            // comboBox_phone
            // 
            comboBox_phone.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_phone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_phone.FormattingEnabled = true;
            comboBox_phone.Items.AddRange(new object[] { "แสดง", "ไม่แสดง" });
            comboBox_phone.Location = new Point(166, 291);
            comboBox_phone.Name = "comboBox_phone";
            comboBox_phone.Size = new Size(151, 36);
            comboBox_phone.TabIndex = 1;
            comboBox_phone.SelectedIndexChanged += comboBox_phone_SelectedIndexChanged;
            // 
            // comboBox_address
            // 
            comboBox_address.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_address.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_address.FormattingEnabled = true;
            comboBox_address.Items.AddRange(new object[] { "แสดง", "ไม่แสดง" });
            comboBox_address.Location = new Point(166, 249);
            comboBox_address.Name = "comboBox_address";
            comboBox_address.Size = new Size(151, 36);
            comboBox_address.TabIndex = 1;
            comboBox_address.SelectedIndexChanged += comboBox_address_SelectedIndexChanged;
            // 
            // comboBox_name_fontsize
            // 
            comboBox_name_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_name_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_name_fontsize.FormattingEnabled = true;
            comboBox_name_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_name_fontsize.Location = new Point(166, 207);
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
            comboBox_logo_width.Location = new Point(166, 165);
            comboBox_logo_width.Name = "comboBox_logo_width";
            comboBox_logo_width.Size = new Size(151, 36);
            comboBox_logo_width.TabIndex = 1;
            comboBox_logo_width.SelectedIndexChanged += comboBox_logo_width_SelectedIndexChanged;
            // 
            // comboBox_width
            // 
            comboBox_width.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_width.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_width.FormattingEnabled = true;
            comboBox_width.Items.AddRange(new object[] { "57", "58", "80" });
            comboBox_width.Location = new Point(166, 81);
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
            comboBox_margin.Location = new Point(166, 123);
            comboBox_margin.Name = "comboBox_margin";
            comboBox_margin.Size = new Size(151, 36);
            comboBox_margin.TabIndex = 1;
            comboBox_margin.SelectedIndexChanged += comboBox_margin_SelectedIndexChanged;
            // 
            // timer_search
            // 
            timer_search.Tick += timer_search_Tick;
            // 
            // comboBox_type_fontsize
            // 
            comboBox_type_fontsize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_type_fontsize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_type_fontsize.FormattingEnabled = true;
            comboBox_type_fontsize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_type_fontsize.Location = new Point(166, 333);
            comboBox_type_fontsize.Name = "comboBox_type_fontsize";
            comboBox_type_fontsize.Size = new Size(151, 36);
            comboBox_type_fontsize.TabIndex = 1;
            comboBox_type_fontsize.SelectedIndexChanged += comboBox_type_fontsize_SelectedIndexChanged;
            // 
            // comboBox_type_bold
            // 
            comboBox_type_bold.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_type_bold.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_type_bold.FormattingEnabled = true;
            comboBox_type_bold.Items.AddRange(new object[] { "ตัวหนา", "ตัวบาง" });
            comboBox_type_bold.Location = new Point(334, 333);
            comboBox_type_bold.Name = "comboBox_type_bold";
            comboBox_type_bold.Size = new Size(151, 36);
            comboBox_type_bold.TabIndex = 1;
            comboBox_type_bold.SelectedIndexChanged += comboBox_type_bold_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(48, 341);
            label7.Name = "label7";
            label7.Size = new Size(103, 28);
            label7.TabIndex = 2;
            label7.Text = "ใบเสร็จ";
            // 
            // Form_Setting_Invoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cyan;
            ClientSize = new Size(1094, 704);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Setting_Invoice";
            Text = "Form_Setting_Invoice";
            FormClosed += Form_Setting_Invoice_FormClosed;
            Load += Form_Setting_Invoice_Load;
            panel_invoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_invoice).EndInit();
            customGroupBox_invoice.ResumeLayout(false);
            tableLayoutPanel_invoice.ResumeLayout(false);
            tableLayoutPanel_invoice.PerformLayout();
            tableLayoutPanel_back.ResumeLayout(false);
            customGroupBox_set.ResumeLayout(false);
            panel_set.ResumeLayout(false);
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
    }
}