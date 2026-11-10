namespace Ppos
{
    partial class Form_Setting_Configure
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
            panel_back = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            login_program = new PictureBox();
            label_login_program = new Label();
            use_item_medium_large = new PictureBox();
            label_use_item_medium_large = new Label();
            custom_cost_adjust = new PictureBox();
            label_custom_cost_adjust = new Label();
            label_sale_show_hotkey = new Label();
            label_pay_show_keypad = new Label();
            sale_show_hotkey = new PictureBox();
            pay_show_keypad = new PictureBox();
            pay_show_change = new PictureBox();
            label_pay_show_change = new Label();
            customGroupBox_back = new CustomGroupBox();
            panel_back.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)login_program).BeginInit();
            ((System.ComponentModel.ISupportInitialize)use_item_medium_large).BeginInit();
            ((System.ComponentModel.ISupportInitialize)custom_cost_adjust).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sale_show_hotkey).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pay_show_keypad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pay_show_change).BeginInit();
            customGroupBox_back.SuspendLayout();
            SuspendLayout();
            // 
            // panel_back
            // 
            panel_back.AutoScroll = true;
            panel_back.BackColor = Color.White;
            panel_back.Controls.Add(tableLayoutPanel1);
            panel_back.Dock = DockStyle.Fill;
            panel_back.Location = new Point(10, 13);
            panel_back.Name = "panel_back";
            panel_back.Size = new Size(1003, 635);
            panel_back.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(login_program, 1, 1);
            tableLayoutPanel1.Controls.Add(label_login_program, 2, 1);
            tableLayoutPanel1.Controls.Add(use_item_medium_large, 1, 2);
            tableLayoutPanel1.Controls.Add(label_use_item_medium_large, 2, 2);
            tableLayoutPanel1.Controls.Add(custom_cost_adjust, 1, 3);
            tableLayoutPanel1.Controls.Add(label_custom_cost_adjust, 2, 3);
            tableLayoutPanel1.Controls.Add(label_sale_show_hotkey, 2, 4);
            tableLayoutPanel1.Controls.Add(label_pay_show_keypad, 2, 5);
            tableLayoutPanel1.Controls.Add(sale_show_hotkey, 1, 4);
            tableLayoutPanel1.Controls.Add(pay_show_keypad, 1, 5);
            tableLayoutPanel1.Controls.Add(pay_show_change, 1, 6);
            tableLayoutPanel1.Controls.Add(label_pay_show_change, 2, 6);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(1003, 350);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // login_program
            // 
            login_program.Dock = DockStyle.Fill;
            login_program.Image = Properties.Resources.check;
            login_program.Location = new Point(329, 53);
            login_program.Name = "login_program";
            login_program.Size = new Size(44, 44);
            login_program.SizeMode = PictureBoxSizeMode.Zoom;
            login_program.TabIndex = 0;
            login_program.TabStop = false;
            login_program.Click += Click_Status;
            // 
            // label_login_program
            // 
            label_login_program.Dock = DockStyle.Fill;
            label_login_program.Font = new Font("Segoe UI", 12F);
            label_login_program.Location = new Point(379, 50);
            label_login_program.Name = "label_login_program";
            label_login_program.Size = new Size(294, 50);
            label_login_program.TabIndex = 1;
            label_login_program.Text = "ล็อกอินเพื่อใช้งานโปรแกรม";
            label_login_program.TextAlign = ContentAlignment.MiddleLeft;
            label_login_program.MouseEnter += Mouse_Enter;
            label_login_program.MouseLeave += Mouse_Leave;
            // 
            // use_item_medium_large
            // 
            use_item_medium_large.Dock = DockStyle.Fill;
            use_item_medium_large.Image = Properties.Resources.check;
            use_item_medium_large.Location = new Point(329, 103);
            use_item_medium_large.Name = "use_item_medium_large";
            use_item_medium_large.Size = new Size(44, 44);
            use_item_medium_large.SizeMode = PictureBoxSizeMode.Zoom;
            use_item_medium_large.TabIndex = 0;
            use_item_medium_large.TabStop = false;
            use_item_medium_large.Click += Click_Status;
            // 
            // label_use_item_medium_large
            // 
            label_use_item_medium_large.Dock = DockStyle.Fill;
            label_use_item_medium_large.Font = new Font("Segoe UI", 12F);
            label_use_item_medium_large.Location = new Point(379, 100);
            label_use_item_medium_large.Name = "label_use_item_medium_large";
            label_use_item_medium_large.Size = new Size(294, 50);
            label_use_item_medium_large.TabIndex = 1;
            label_use_item_medium_large.Text = "สินค้าหน่วยกลางหน่วยใหญ่";
            label_use_item_medium_large.TextAlign = ContentAlignment.MiddleLeft;
            label_use_item_medium_large.MouseEnter += Mouse_Enter;
            label_use_item_medium_large.MouseLeave += Mouse_Leave;
            // 
            // custom_cost_adjust
            // 
            custom_cost_adjust.Dock = DockStyle.Fill;
            custom_cost_adjust.Image = Properties.Resources.check;
            custom_cost_adjust.Location = new Point(329, 153);
            custom_cost_adjust.Name = "custom_cost_adjust";
            custom_cost_adjust.Size = new Size(44, 44);
            custom_cost_adjust.SizeMode = PictureBoxSizeMode.Zoom;
            custom_cost_adjust.TabIndex = 0;
            custom_cost_adjust.TabStop = false;
            custom_cost_adjust.Click += Click_Status;
            // 
            // label_custom_cost_adjust
            // 
            label_custom_cost_adjust.Dock = DockStyle.Fill;
            label_custom_cost_adjust.Font = new Font("Segoe UI", 12F);
            label_custom_cost_adjust.Location = new Point(379, 150);
            label_custom_cost_adjust.Name = "label_custom_cost_adjust";
            label_custom_cost_adjust.Size = new Size(294, 50);
            label_custom_cost_adjust.TabIndex = 1;
            label_custom_cost_adjust.Text = "กำหนดต้นทุนปรับจำนวน";
            label_custom_cost_adjust.TextAlign = ContentAlignment.MiddleLeft;
            label_custom_cost_adjust.MouseEnter += Mouse_Enter;
            label_custom_cost_adjust.MouseLeave += Mouse_Leave;
            // 
            // label_sale_show_hotkey
            // 
            label_sale_show_hotkey.Dock = DockStyle.Fill;
            label_sale_show_hotkey.Font = new Font("Segoe UI", 12F);
            label_sale_show_hotkey.Location = new Point(379, 200);
            label_sale_show_hotkey.Name = "label_sale_show_hotkey";
            label_sale_show_hotkey.Size = new Size(294, 50);
            label_sale_show_hotkey.TabIndex = 1;
            label_sale_show_hotkey.Text = "แสดงคีย์ลัดหน้าขายสินค้า";
            label_sale_show_hotkey.TextAlign = ContentAlignment.MiddleLeft;
            label_sale_show_hotkey.MouseEnter += Mouse_Enter;
            label_sale_show_hotkey.MouseLeave += Mouse_Leave;
            // 
            // label_pay_show_keypad
            // 
            label_pay_show_keypad.Dock = DockStyle.Fill;
            label_pay_show_keypad.Font = new Font("Segoe UI", 12F);
            label_pay_show_keypad.Location = new Point(379, 250);
            label_pay_show_keypad.Name = "label_pay_show_keypad";
            label_pay_show_keypad.Size = new Size(294, 50);
            label_pay_show_keypad.TabIndex = 1;
            label_pay_show_keypad.Text = "แสดงปุ่มกดหน้าชำระเงิน";
            label_pay_show_keypad.TextAlign = ContentAlignment.MiddleLeft;
            label_pay_show_keypad.MouseEnter += Mouse_Enter;
            label_pay_show_keypad.MouseLeave += Mouse_Leave;
            // 
            // sale_show_hotkey
            // 
            sale_show_hotkey.Dock = DockStyle.Fill;
            sale_show_hotkey.Image = Properties.Resources.check;
            sale_show_hotkey.Location = new Point(329, 203);
            sale_show_hotkey.Name = "sale_show_hotkey";
            sale_show_hotkey.Size = new Size(44, 44);
            sale_show_hotkey.SizeMode = PictureBoxSizeMode.Zoom;
            sale_show_hotkey.TabIndex = 0;
            sale_show_hotkey.TabStop = false;
            sale_show_hotkey.Click += Click_Status;
            // 
            // pay_show_keypad
            // 
            pay_show_keypad.Dock = DockStyle.Fill;
            pay_show_keypad.Image = Properties.Resources.check;
            pay_show_keypad.Location = new Point(329, 253);
            pay_show_keypad.Name = "pay_show_keypad";
            pay_show_keypad.Size = new Size(44, 44);
            pay_show_keypad.SizeMode = PictureBoxSizeMode.Zoom;
            pay_show_keypad.TabIndex = 0;
            pay_show_keypad.TabStop = false;
            pay_show_keypad.Click += Click_Status;
            // 
            // pay_show_change
            // 
            pay_show_change.Dock = DockStyle.Fill;
            pay_show_change.Image = Properties.Resources.check;
            pay_show_change.Location = new Point(329, 303);
            pay_show_change.Name = "pay_show_change";
            pay_show_change.Size = new Size(44, 44);
            pay_show_change.SizeMode = PictureBoxSizeMode.Zoom;
            pay_show_change.TabIndex = 0;
            pay_show_change.TabStop = false;
            pay_show_change.Click += Click_Status;
            // 
            // label_pay_show_change
            // 
            label_pay_show_change.Dock = DockStyle.Fill;
            label_pay_show_change.Font = new Font("Segoe UI", 12F);
            label_pay_show_change.Location = new Point(379, 300);
            label_pay_show_change.Name = "label_pay_show_change";
            label_pay_show_change.Size = new Size(294, 50);
            label_pay_show_change.TabIndex = 1;
            label_pay_show_change.Text = "แสดงหน้าจอเงินทอน";
            label_pay_show_change.TextAlign = ContentAlignment.MiddleLeft;
            label_pay_show_change.MouseEnter += Mouse_Enter;
            label_pay_show_change.MouseLeave += Mouse_Leave;
            // 
            // customGroupBox_back
            // 
            customGroupBox_back.BackColor = Color.Transparent;
            customGroupBox_back.BorderColor = Color.White;
            customGroupBox_back.BorderRadius = 30;
            customGroupBox_back.BorderThickness = 20;
            customGroupBox_back.Controls.Add(panel_back);
            customGroupBox_back.Dock = DockStyle.Fill;
            customGroupBox_back.Font = new Font("Segoe UI", 1F);
            customGroupBox_back.Location = new Point(0, 0);
            customGroupBox_back.Margin = new Padding(0);
            customGroupBox_back.Name = "customGroupBox_back";
            customGroupBox_back.Padding = new Padding(10);
            customGroupBox_back.Size = new Size(1023, 658);
            customGroupBox_back.TabIndex = 1;
            customGroupBox_back.TabStop = false;
            // 
            // Form_Setting_Configure
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cyan;
            ClientSize = new Size(1033, 661);
            ControlBox = false;
            Controls.Add(customGroupBox_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Setting_Configure";
            Padding = new Padding(0, 0, 10, 3);
            ShowIcon = false;
            panel_back.ResumeLayout(false);
            panel_back.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)login_program).EndInit();
            ((System.ComponentModel.ISupportInitialize)use_item_medium_large).EndInit();
            ((System.ComponentModel.ISupportInitialize)custom_cost_adjust).EndInit();
            ((System.ComponentModel.ISupportInitialize)sale_show_hotkey).EndInit();
            ((System.ComponentModel.ISupportInitialize)pay_show_keypad).EndInit();
            ((System.ComponentModel.ISupportInitialize)pay_show_change).EndInit();
            customGroupBox_back.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_back;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox login_program;
        private PictureBox use_item_medium_large;
        private Label label_login_program;
        private Label label_use_item_medium_large;
        private PictureBox custom_cost_adjust;
        private Label label_custom_cost_adjust;
        private Label label_sale_show_hotkey;
        private Label label_pay_show_keypad;
        private PictureBox sale_show_hotkey;
        private PictureBox pay_show_keypad;
        private PictureBox pay_show_change;
        private Label label_pay_show_change;
        private CustomGroupBox customGroupBox_back;
    }
}