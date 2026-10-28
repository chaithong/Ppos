namespace Ppos
{
    partial class Form_Setting_Store
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
            panel_detail = new Panel();
            customGroupBox = new CustomGroupBox();
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_detail = new TableLayoutPanel();
            label_store_no = new Label();
            label_store_name = new Label();
            label_tax_id = new Label();
            label_address = new Label();
            label_sub_district = new Label();
            label_district = new Label();
            label_province = new Label();
            label_postal_code = new Label();
            label_phone = new Label();
            label_email = new Label();
            store_no = new TextBox();
            store_name = new TextBox();
            tax_id = new TextBox();
            address = new TextBox();
            sub_district = new TextBox();
            district = new TextBox();
            province = new TextBox();
            postal_code = new TextBox();
            phone = new TextBox();
            email = new TextBox();
            pictureBox = new PictureBox();
            tableLayoutPanel_top = new TableLayoutPanel();
            button_edit_save = new Button();
            button_cancel = new Button();
            panel_detail.SuspendLayout();
            customGroupBox.SuspendLayout();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            tableLayoutPanel_top.SuspendLayout();
            SuspendLayout();
            // 
            // panel_detail
            // 
            panel_detail.AutoScroll = true;
            panel_detail.BackColor = Color.White;
            panel_detail.Controls.Add(customGroupBox);
            panel_detail.Dock = DockStyle.Fill;
            panel_detail.Location = new Point(0, 100);
            panel_detail.Margin = new Padding(0);
            panel_detail.Name = "panel_detail";
            panel_detail.Size = new Size(1311, 941);
            panel_detail.TabIndex = 0;
            // 
            // customGroupBox
            // 
            customGroupBox.Anchor = AnchorStyles.Top;
            customGroupBox.AutoSize = true;
            customGroupBox.BorderColor = Color.Cyan;
            customGroupBox.BorderRadius = 30;
            customGroupBox.BorderThickness = 20;
            customGroupBox.Controls.Add(tableLayoutPanel_back);
            customGroupBox.Font = new Font("Segoe UI", 1F);
            customGroupBox.Location = new Point(358, 6);
            customGroupBox.Name = "customGroupBox";
            customGroupBox.Padding = new Padding(25);
            customGroupBox.Size = new Size(614, 750);
            customGroupBox.TabIndex = 0;
            customGroupBox.TabStop = false;
            customGroupBox.Text = "  ";
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.Transparent;
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_detail, 0, 1);
            tableLayoutPanel_back.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(25, 28);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(564, 697);
            tableLayoutPanel_back.TabIndex = 0;
            // 
            // tableLayoutPanel_detail
            // 
            tableLayoutPanel_detail.AutoSize = true;
            tableLayoutPanel_detail.ColumnCount = 2;
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_detail.Controls.Add(label_store_no, 0, 0);
            tableLayoutPanel_detail.Controls.Add(label_store_name, 0, 1);
            tableLayoutPanel_detail.Controls.Add(label_tax_id, 0, 2);
            tableLayoutPanel_detail.Controls.Add(label_address, 0, 3);
            tableLayoutPanel_detail.Controls.Add(label_sub_district, 0, 4);
            tableLayoutPanel_detail.Controls.Add(label_district, 0, 5);
            tableLayoutPanel_detail.Controls.Add(label_province, 0, 6);
            tableLayoutPanel_detail.Controls.Add(label_postal_code, 0, 7);
            tableLayoutPanel_detail.Controls.Add(label_phone, 0, 8);
            tableLayoutPanel_detail.Controls.Add(label_email, 0, 9);
            tableLayoutPanel_detail.Controls.Add(store_no, 1, 0);
            tableLayoutPanel_detail.Controls.Add(store_name, 1, 1);
            tableLayoutPanel_detail.Controls.Add(tax_id, 1, 2);
            tableLayoutPanel_detail.Controls.Add(address, 1, 3);
            tableLayoutPanel_detail.Controls.Add(sub_district, 1, 4);
            tableLayoutPanel_detail.Controls.Add(district, 1, 5);
            tableLayoutPanel_detail.Controls.Add(province, 1, 6);
            tableLayoutPanel_detail.Controls.Add(postal_code, 1, 7);
            tableLayoutPanel_detail.Controls.Add(phone, 1, 8);
            tableLayoutPanel_detail.Controls.Add(email, 1, 9);
            tableLayoutPanel_detail.Dock = DockStyle.Fill;
            tableLayoutPanel_detail.Location = new Point(0, 200);
            tableLayoutPanel_detail.Margin = new Padding(0);
            tableLayoutPanel_detail.Name = "tableLayoutPanel_detail";
            tableLayoutPanel_detail.RowCount = 10;
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.Size = new Size(564, 497);
            tableLayoutPanel_detail.TabIndex = 0;
            // 
            // label_store_no
            // 
            label_store_no.Dock = DockStyle.Fill;
            label_store_no.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_store_no.ForeColor = Color.Black;
            label_store_no.Location = new Point(3, 0);
            label_store_no.Name = "label_store_no";
            label_store_no.Size = new Size(144, 49);
            label_store_no.TabIndex = 0;
            label_store_no.Text = "*รหัสร้าน :";
            label_store_no.TextAlign = ContentAlignment.MiddleRight;
            label_store_no.MouseEnter += label_enter;
            label_store_no.MouseLeave += label_leave;
            // 
            // label_store_name
            // 
            label_store_name.Dock = DockStyle.Fill;
            label_store_name.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_store_name.ForeColor = Color.Black;
            label_store_name.Location = new Point(3, 49);
            label_store_name.Name = "label_store_name";
            label_store_name.Size = new Size(144, 49);
            label_store_name.TabIndex = 0;
            label_store_name.Text = "*ชื่อร้าน :";
            label_store_name.TextAlign = ContentAlignment.MiddleRight;
            label_store_name.MouseEnter += label_enter;
            label_store_name.MouseLeave += label_leave;
            // 
            // label_tax_id
            // 
            label_tax_id.Dock = DockStyle.Fill;
            label_tax_id.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_tax_id.ForeColor = Color.Black;
            label_tax_id.Location = new Point(3, 98);
            label_tax_id.Name = "label_tax_id";
            label_tax_id.Size = new Size(144, 49);
            label_tax_id.TabIndex = 0;
            label_tax_id.Text = "เลขภาษี :";
            label_tax_id.TextAlign = ContentAlignment.MiddleRight;
            label_tax_id.MouseEnter += label_enter;
            label_tax_id.MouseLeave += label_leave;
            // 
            // label_address
            // 
            label_address.Dock = DockStyle.Fill;
            label_address.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_address.ForeColor = Color.Black;
            label_address.Location = new Point(3, 147);
            label_address.Name = "label_address";
            label_address.Size = new Size(144, 49);
            label_address.TabIndex = 0;
            label_address.Text = "ที่อยู่ :";
            label_address.TextAlign = ContentAlignment.MiddleRight;
            label_address.MouseEnter += label_enter;
            label_address.MouseLeave += label_leave;
            // 
            // label_sub_district
            // 
            label_sub_district.Dock = DockStyle.Fill;
            label_sub_district.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_sub_district.ForeColor = Color.Black;
            label_sub_district.Location = new Point(3, 196);
            label_sub_district.Name = "label_sub_district";
            label_sub_district.Size = new Size(144, 49);
            label_sub_district.TabIndex = 0;
            label_sub_district.Text = "ตำบล :";
            label_sub_district.TextAlign = ContentAlignment.MiddleRight;
            label_sub_district.MouseEnter += label_enter;
            label_sub_district.MouseLeave += label_leave;
            // 
            // label_district
            // 
            label_district.Dock = DockStyle.Fill;
            label_district.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_district.ForeColor = Color.Black;
            label_district.Location = new Point(3, 245);
            label_district.Name = "label_district";
            label_district.Size = new Size(144, 49);
            label_district.TabIndex = 0;
            label_district.Text = "อำเภอ :";
            label_district.TextAlign = ContentAlignment.MiddleRight;
            label_district.MouseEnter += label_enter;
            label_district.MouseLeave += label_leave;
            // 
            // label_province
            // 
            label_province.Dock = DockStyle.Fill;
            label_province.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_province.ForeColor = Color.Black;
            label_province.Location = new Point(3, 294);
            label_province.Name = "label_province";
            label_province.Size = new Size(144, 49);
            label_province.TabIndex = 0;
            label_province.Text = "จังหวัด :";
            label_province.TextAlign = ContentAlignment.MiddleRight;
            label_province.MouseEnter += label_enter;
            label_province.MouseLeave += label_leave;
            // 
            // label_postal_code
            // 
            label_postal_code.Dock = DockStyle.Fill;
            label_postal_code.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_postal_code.ForeColor = Color.Black;
            label_postal_code.Location = new Point(3, 343);
            label_postal_code.Name = "label_postal_code";
            label_postal_code.Size = new Size(144, 49);
            label_postal_code.TabIndex = 0;
            label_postal_code.Text = "ไปรษณีย์ :";
            label_postal_code.TextAlign = ContentAlignment.MiddleRight;
            label_postal_code.MouseEnter += label_enter;
            label_postal_code.MouseLeave += label_leave;
            // 
            // label_phone
            // 
            label_phone.Dock = DockStyle.Fill;
            label_phone.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_phone.ForeColor = Color.Black;
            label_phone.Location = new Point(3, 392);
            label_phone.Name = "label_phone";
            label_phone.Size = new Size(144, 49);
            label_phone.TabIndex = 0;
            label_phone.Text = "โทรศัพท์ :";
            label_phone.TextAlign = ContentAlignment.MiddleRight;
            label_phone.MouseEnter += label_enter;
            label_phone.MouseLeave += label_leave;
            // 
            // label_email
            // 
            label_email.Dock = DockStyle.Fill;
            label_email.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_email.ForeColor = Color.Black;
            label_email.Location = new Point(3, 441);
            label_email.Name = "label_email";
            label_email.Size = new Size(144, 56);
            label_email.TabIndex = 0;
            label_email.Text = "อีเมลล์ :";
            label_email.TextAlign = ContentAlignment.MiddleRight;
            label_email.MouseEnter += label_enter;
            label_email.MouseLeave += label_leave;
            // 
            // store_no
            // 
            store_no.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            store_no.Font = new Font("Segoe UI", 13.8F);
            store_no.Location = new Point(153, 5);
            store_no.Name = "store_no";
            store_no.Size = new Size(408, 38);
            store_no.TabIndex = 1;
            store_no.TabStop = false;
            store_no.KeyDown += data_KeyDown;
            // 
            // store_name
            // 
            store_name.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            store_name.Font = new Font("Segoe UI", 13.8F);
            store_name.Location = new Point(153, 54);
            store_name.Name = "store_name";
            store_name.Size = new Size(408, 38);
            store_name.TabIndex = 1;
            store_name.TabStop = false;
            store_name.KeyDown += data_KeyDown;
            // 
            // tax_id
            // 
            tax_id.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tax_id.Font = new Font("Segoe UI", 13.8F);
            tax_id.Location = new Point(153, 103);
            tax_id.Name = "tax_id";
            tax_id.Size = new Size(408, 38);
            tax_id.TabIndex = 1;
            tax_id.TabStop = false;
            tax_id.KeyDown += data_KeyDown;
            // 
            // address
            // 
            address.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            address.Font = new Font("Segoe UI", 13.8F);
            address.Location = new Point(153, 152);
            address.Name = "address";
            address.Size = new Size(408, 38);
            address.TabIndex = 1;
            address.TabStop = false;
            address.KeyDown += data_KeyDown;
            // 
            // sub_district
            // 
            sub_district.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            sub_district.Font = new Font("Segoe UI", 13.8F);
            sub_district.Location = new Point(153, 201);
            sub_district.Name = "sub_district";
            sub_district.Size = new Size(408, 38);
            sub_district.TabIndex = 1;
            sub_district.TabStop = false;
            sub_district.KeyDown += data_KeyDown;
            // 
            // district
            // 
            district.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            district.Font = new Font("Segoe UI", 13.8F);
            district.Location = new Point(153, 250);
            district.Name = "district";
            district.Size = new Size(408, 38);
            district.TabIndex = 1;
            district.TabStop = false;
            district.KeyDown += data_KeyDown;
            // 
            // province
            // 
            province.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            province.Font = new Font("Segoe UI", 13.8F);
            province.Location = new Point(153, 299);
            province.Name = "province";
            province.Size = new Size(408, 38);
            province.TabIndex = 1;
            province.TabStop = false;
            province.KeyDown += data_KeyDown;
            // 
            // postal_code
            // 
            postal_code.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            postal_code.Font = new Font("Segoe UI", 13.8F);
            postal_code.Location = new Point(153, 348);
            postal_code.Name = "postal_code";
            postal_code.Size = new Size(408, 38);
            postal_code.TabIndex = 1;
            postal_code.TabStop = false;
            postal_code.KeyDown += data_KeyDown;
            // 
            // phone
            // 
            phone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            phone.Font = new Font("Segoe UI", 13.8F);
            phone.Location = new Point(153, 397);
            phone.Name = "phone";
            phone.Size = new Size(408, 38);
            phone.TabIndex = 1;
            phone.TabStop = false;
            phone.KeyDown += data_KeyDown;
            // 
            // email
            // 
            email.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            email.Font = new Font("Segoe UI", 13.8F);
            email.Location = new Point(153, 450);
            email.Name = "email";
            email.Size = new Size(408, 38);
            email.TabIndex = 1;
            email.TabStop = false;
            email.KeyDown += data_KeyDown;
            // 
            // pictureBox
            // 
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Margin = new Padding(0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(564, 200);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox_Click;
            // 
            // tableLayoutPanel_top
            // 
            tableLayoutPanel_top.AutoSize = true;
            tableLayoutPanel_top.BackColor = Color.White;
            tableLayoutPanel_top.ColumnCount = 4;
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.Controls.Add(button_edit_save, 1, 0);
            tableLayoutPanel_top.Controls.Add(button_cancel, 2, 0);
            tableLayoutPanel_top.Dock = DockStyle.Top;
            tableLayoutPanel_top.Location = new Point(0, 0);
            tableLayoutPanel_top.Name = "tableLayoutPanel_top";
            tableLayoutPanel_top.RowCount = 1;
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_top.Size = new Size(1311, 100);
            tableLayoutPanel_top.TabIndex = 1;
            // 
            // button_edit_save
            // 
            button_edit_save.BackColor = Color.Transparent;
            button_edit_save.Dock = DockStyle.Fill;
            button_edit_save.FlatAppearance.BorderSize = 0;
            button_edit_save.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_edit_save.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_edit_save.FlatStyle = FlatStyle.Flat;
            button_edit_save.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_edit_save.Location = new Point(355, 0);
            button_edit_save.Margin = new Padding(0);
            button_edit_save.Name = "button_edit_save";
            button_edit_save.Size = new Size(300, 100);
            button_edit_save.TabIndex = 0;
            button_edit_save.Text = "แก้ไข";
            button_edit_save.TextAlign = ContentAlignment.BottomCenter;
            button_edit_save.TextImageRelation = TextImageRelation.ImageAboveText;
            button_edit_save.UseVisualStyleBackColor = false;
            button_edit_save.Click += button_edit_save_Click;
            button_edit_save.MouseEnter += button_MouseEnter;
            button_edit_save.MouseLeave += button_MouseLeave;
            // 
            // button_cancel
            // 
            button_cancel.BackColor = Color.Transparent;
            button_cancel.Dock = DockStyle.Fill;
            button_cancel.Enabled = false;
            button_cancel.FlatAppearance.BorderSize = 0;
            button_cancel.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_cancel.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_cancel.FlatStyle = FlatStyle.Flat;
            button_cancel.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_cancel.Location = new Point(655, 0);
            button_cancel.Margin = new Padding(0);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new Size(300, 100);
            button_cancel.TabIndex = 0;
            button_cancel.Text = "ยกเลิก";
            button_cancel.TextAlign = ContentAlignment.BottomCenter;
            button_cancel.TextImageRelation = TextImageRelation.ImageAboveText;
            button_cancel.UseVisualStyleBackColor = false;
            button_cancel.Click += button_cancel_Click;
            button_cancel.MouseEnter += button_MouseEnter;
            button_cancel.MouseLeave += button_MouseLeave;
            // 
            // Form_Setting_Store
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(1311, 1041);
            Controls.Add(panel_detail);
            Controls.Add(tableLayoutPanel_top);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Setting_Store";
            Text = "Form_Setting_Store";
            panel_detail.ResumeLayout(false);
            panel_detail.PerformLayout();
            customGroupBox.ResumeLayout(false);
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_back.PerformLayout();
            tableLayoutPanel_detail.ResumeLayout(false);
            tableLayoutPanel_detail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            tableLayoutPanel_top.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel_detail;
        private TableLayoutPanel tableLayoutPanel_top;
        private Button button_edit_save;
        private Button button_cancel;
        private CustomGroupBox customGroupBox;
        private TableLayoutPanel tableLayoutPanel_detail;
        private PictureBox pictureBox;
        private Label label_store_no;
        private Label label_store_name;
        private Label label_tax_id;
        private Label label_address;
        private Label label_sub_district;
        private Label label_district;
        private Label label_province;
        private Label label_postal_code;
        private Label label_phone;
        private Label label_email;
        private TextBox store_no;
        private TextBox store_name;
        private TextBox tax_id;
        private TextBox address;
        private TextBox sub_district;
        private TextBox district;
        private TextBox province;
        private TextBox postal_code;
        private TextBox phone;
        private TextBox email;
        private TableLayoutPanel tableLayoutPanel_back;
    }
}