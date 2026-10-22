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
            label1 = new Label();
            use_item_medium_large = new PictureBox();
            label2 = new Label();
            custom_cost_adjust = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            sale_show_hotkey = new PictureBox();
            pay_show_keypad = new PictureBox();
            panel_back.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)login_program).BeginInit();
            ((System.ComponentModel.ISupportInitialize)use_item_medium_large).BeginInit();
            ((System.ComponentModel.ISupportInitialize)custom_cost_adjust).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sale_show_hotkey).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pay_show_keypad).BeginInit();
            SuspendLayout();
            // 
            // panel_back
            // 
            panel_back.AutoScroll = true;
            panel_back.Controls.Add(tableLayoutPanel1);
            panel_back.Dock = DockStyle.Fill;
            panel_back.Location = new Point(0, 0);
            panel_back.Name = "panel_back";
            panel_back.Size = new Size(1033, 661);
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
            tableLayoutPanel1.Controls.Add(label1, 2, 1);
            tableLayoutPanel1.Controls.Add(use_item_medium_large, 1, 2);
            tableLayoutPanel1.Controls.Add(label2, 2, 2);
            tableLayoutPanel1.Controls.Add(custom_cost_adjust, 1, 3);
            tableLayoutPanel1.Controls.Add(label3, 2, 3);
            tableLayoutPanel1.Controls.Add(label4, 2, 4);
            tableLayoutPanel1.Controls.Add(label5, 2, 5);
            tableLayoutPanel1.Controls.Add(sale_show_hotkey, 1, 4);
            tableLayoutPanel1.Controls.Add(pay_show_keypad, 1, 5);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(1033, 300);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // login_program
            // 
            login_program.Dock = DockStyle.Fill;
            login_program.Image = Properties.Resources.check;
            login_program.Location = new Point(344, 53);
            login_program.Name = "login_program";
            login_program.Size = new Size(44, 44);
            login_program.SizeMode = PictureBoxSizeMode.Zoom;
            login_program.TabIndex = 0;
            login_program.TabStop = false;
            login_program.Click += Click_Status;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(394, 50);
            label1.Name = "label1";
            label1.Size = new Size(294, 50);
            label1.TabIndex = 1;
            label1.Text = "ล็อกอินเพื่อใช้งานโปรแกรม";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.MouseEnter += Mouse_Enter;
            label1.MouseLeave += Mouse_Leave;
            // 
            // use_item_medium_large
            // 
            use_item_medium_large.Dock = DockStyle.Fill;
            use_item_medium_large.Image = Properties.Resources.check;
            use_item_medium_large.Location = new Point(344, 103);
            use_item_medium_large.Name = "use_item_medium_large";
            use_item_medium_large.Size = new Size(44, 44);
            use_item_medium_large.SizeMode = PictureBoxSizeMode.Zoom;
            use_item_medium_large.TabIndex = 0;
            use_item_medium_large.TabStop = false;
            use_item_medium_large.Click += Click_Status;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(394, 100);
            label2.Name = "label2";
            label2.Size = new Size(294, 50);
            label2.TabIndex = 1;
            label2.Text = "สินค้าหน่วยกลางหน่วยใหญ่";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.MouseEnter += Mouse_Enter;
            label2.MouseLeave += Mouse_Leave;
            // 
            // custom_cost_adjust
            // 
            custom_cost_adjust.Dock = DockStyle.Fill;
            custom_cost_adjust.Image = Properties.Resources.check;
            custom_cost_adjust.Location = new Point(344, 153);
            custom_cost_adjust.Name = "custom_cost_adjust";
            custom_cost_adjust.Size = new Size(44, 44);
            custom_cost_adjust.SizeMode = PictureBoxSizeMode.Zoom;
            custom_cost_adjust.TabIndex = 0;
            custom_cost_adjust.TabStop = false;
            custom_cost_adjust.Click += Click_Status;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(394, 150);
            label3.Name = "label3";
            label3.Size = new Size(294, 50);
            label3.TabIndex = 1;
            label3.Text = "กำหนดต้นทุนปรับจำนวน";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            label3.MouseEnter += Mouse_Enter;
            label3.MouseLeave += Mouse_Leave;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(394, 200);
            label4.Name = "label4";
            label4.Size = new Size(294, 50);
            label4.TabIndex = 1;
            label4.Text = "แสดงคีย์ลัดหน้าขายสินค้า";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            label4.MouseEnter += Mouse_Enter;
            label4.MouseLeave += Mouse_Leave;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(394, 250);
            label5.Name = "label5";
            label5.Size = new Size(294, 50);
            label5.TabIndex = 1;
            label5.Text = "แสดงปุ่มกดหน้าชำระเงิน";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            label5.MouseEnter += Mouse_Enter;
            label5.MouseLeave += Mouse_Leave;
            // 
            // sale_show_hotkey
            // 
            sale_show_hotkey.Dock = DockStyle.Fill;
            sale_show_hotkey.Image = Properties.Resources.check;
            sale_show_hotkey.Location = new Point(344, 203);
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
            pay_show_keypad.Location = new Point(344, 253);
            pay_show_keypad.Name = "pay_show_keypad";
            pay_show_keypad.Size = new Size(44, 44);
            pay_show_keypad.SizeMode = PictureBoxSizeMode.Zoom;
            pay_show_keypad.TabIndex = 0;
            pay_show_keypad.TabStop = false;
            pay_show_keypad.Click += Click_Status;
            // 
            // Form_Setting_Configure
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1033, 661);
            ControlBox = false;
            Controls.Add(panel_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Setting_Configure";
            ShowIcon = false;
            panel_back.ResumeLayout(false);
            panel_back.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)login_program).EndInit();
            ((System.ComponentModel.ISupportInitialize)use_item_medium_large).EndInit();
            ((System.ComponentModel.ISupportInitialize)custom_cost_adjust).EndInit();
            ((System.ComponentModel.ISupportInitialize)sale_show_hotkey).EndInit();
            ((System.ComponentModel.ISupportInitialize)pay_show_keypad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_back;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox login_program;
        private PictureBox use_item_medium_large;
        private Label label1;
        private Label label2;
        private PictureBox custom_cost_adjust;
        private Label label3;
        private Label label4;
        private Label label5;
        private PictureBox sale_show_hotkey;
        private PictureBox pay_show_keypad;
    }
}