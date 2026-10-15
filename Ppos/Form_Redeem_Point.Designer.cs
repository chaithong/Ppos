namespace Ppos
{
    partial class Form_Redeem_Point
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Redeem_Point));
            tableLayoutPanel_back = new TableLayoutPanel();
            button_confirm = new Button();
            label_member = new Label();
            tableLayoutPanel_back_middle = new TableLayoutPanel();
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
            button10 = new Button();
            button11 = new Button();
            button_delete = new Button();
            tableLayoutPanel_detail = new TableLayoutPanel();
            textBox_point = new TextBox();
            label1 = new Label();
            label_point_all = new Label();
            label3 = new Label();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_back_middle.SuspendLayout();
            tableLayoutPanel_keypad.SuspendLayout();
            tableLayoutPanel_detail.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel_back.BackColor = Color.White;
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(button_confirm, 0, 2);
            tableLayoutPanel_back.Controls.Add(label_member, 0, 0);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_back_middle, 0, 1);
            tableLayoutPanel_back.Location = new Point(14, 14);
            tableLayoutPanel_back.Margin = new Padding(5);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 3;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.Size = new Size(754, 525);
            tableLayoutPanel_back.TabIndex = 4;
            // 
            // button_confirm
            // 
            button_confirm.BackColor = Color.Lime;
            button_confirm.Dock = DockStyle.Fill;
            button_confirm.FlatAppearance.BorderSize = 0;
            button_confirm.FlatAppearance.MouseDownBackColor = Color.Lime;
            button_confirm.FlatAppearance.MouseOverBackColor = Color.Lime;
            button_confirm.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_confirm.Location = new Point(3, 428);
            button_confirm.Name = "button_confirm";
            button_confirm.Size = new Size(748, 94);
            button_confirm.TabIndex = 0;
            button_confirm.TabStop = false;
            button_confirm.Text = "ยืนยัน";
            button_confirm.TextAlign = ContentAlignment.MiddleRight;
            button_confirm.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_confirm.UseVisualStyleBackColor = false;
            button_confirm.Click += button_confirm_Click;
            button_confirm.MouseEnter += button_enter;
            button_confirm.MouseLeave += button_leave;
            // 
            // label_member
            // 
            label_member.BackColor = Color.White;
            label_member.Dock = DockStyle.Fill;
            label_member.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_member.ForeColor = Color.Black;
            label_member.Location = new Point(3, 0);
            label_member.Name = "label_member";
            label_member.Size = new Size(748, 80);
            label_member.TabIndex = 1;
            label_member.Text = "...";
            label_member.TextAlign = ContentAlignment.MiddleCenter;
            label_member.MouseEnter += label_enter;
            label_member.MouseLeave += label_leave;
            // 
            // tableLayoutPanel_back_middle
            // 
            tableLayoutPanel_back_middle.ColumnCount = 2;
            tableLayoutPanel_back_middle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel_back_middle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel_back_middle.Controls.Add(tableLayoutPanel_keypad, 1, 0);
            tableLayoutPanel_back_middle.Controls.Add(tableLayoutPanel_detail, 0, 0);
            tableLayoutPanel_back_middle.Dock = DockStyle.Fill;
            tableLayoutPanel_back_middle.Location = new Point(3, 83);
            tableLayoutPanel_back_middle.Name = "tableLayoutPanel_back_middle";
            tableLayoutPanel_back_middle.RowCount = 1;
            tableLayoutPanel_back_middle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back_middle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_back_middle.Size = new Size(748, 339);
            tableLayoutPanel_back_middle.TabIndex = 0;
            // 
            // tableLayoutPanel_keypad
            // 
            tableLayoutPanel_keypad.BackColor = Color.Transparent;
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
            tableLayoutPanel_keypad.Controls.Add(button10, 0, 3);
            tableLayoutPanel_keypad.Controls.Add(button11, 1, 3);
            tableLayoutPanel_keypad.Controls.Add(button_delete, 2, 3);
            tableLayoutPanel_keypad.Dock = DockStyle.Fill;
            tableLayoutPanel_keypad.Location = new Point(448, 0);
            tableLayoutPanel_keypad.Margin = new Padding(0);
            tableLayoutPanel_keypad.Name = "tableLayoutPanel_keypad";
            tableLayoutPanel_keypad.RowCount = 4;
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.Size = new Size(300, 339);
            tableLayoutPanel_keypad.TabIndex = 0;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DimGray;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(94, 78);
            button1.TabIndex = 0;
            button1.TabStop = false;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += keypad_click;
            button1.MouseEnter += button_enter;
            button1.MouseLeave += button_leave;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.DimGray;
            button2.Location = new Point(103, 3);
            button2.Name = "button2";
            button2.Size = new Size(94, 78);
            button2.TabIndex = 0;
            button2.TabStop = false;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += keypad_click;
            button2.MouseEnter += button_enter;
            button2.MouseLeave += button_leave;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.DimGray;
            button3.Location = new Point(203, 3);
            button3.Name = "button3";
            button3.Size = new Size(94, 78);
            button3.TabIndex = 0;
            button3.TabStop = false;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += keypad_click;
            button3.MouseEnter += button_enter;
            button3.MouseLeave += button_leave;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Fill;
            button4.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.DimGray;
            button4.Location = new Point(3, 87);
            button4.Name = "button4";
            button4.Size = new Size(94, 78);
            button4.TabIndex = 0;
            button4.TabStop = false;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += keypad_click;
            button4.MouseEnter += button_enter;
            button4.MouseLeave += button_leave;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.DimGray;
            button5.Location = new Point(103, 87);
            button5.Name = "button5";
            button5.Size = new Size(94, 78);
            button5.TabIndex = 0;
            button5.TabStop = false;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += keypad_click;
            button5.MouseEnter += button_enter;
            button5.MouseLeave += button_leave;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Fill;
            button6.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.DimGray;
            button6.Location = new Point(203, 87);
            button6.Name = "button6";
            button6.Size = new Size(94, 78);
            button6.TabIndex = 0;
            button6.TabStop = false;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += keypad_click;
            button6.MouseEnter += button_enter;
            button6.MouseLeave += button_leave;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Fill;
            button7.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.DimGray;
            button7.Location = new Point(3, 171);
            button7.Name = "button7";
            button7.Size = new Size(94, 78);
            button7.TabIndex = 0;
            button7.TabStop = false;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += keypad_click;
            button7.MouseEnter += button_enter;
            button7.MouseLeave += button_leave;
            // 
            // button8
            // 
            button8.Dock = DockStyle.Fill;
            button8.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.DimGray;
            button8.Location = new Point(103, 171);
            button8.Name = "button8";
            button8.Size = new Size(94, 78);
            button8.TabIndex = 0;
            button8.TabStop = false;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += keypad_click;
            button8.MouseEnter += button_enter;
            button8.MouseLeave += button_leave;
            // 
            // button9
            // 
            button9.Dock = DockStyle.Fill;
            button9.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.DimGray;
            button9.Location = new Point(203, 171);
            button9.Name = "button9";
            button9.Size = new Size(94, 78);
            button9.TabIndex = 0;
            button9.TabStop = false;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += keypad_click;
            button9.MouseEnter += button_enter;
            button9.MouseLeave += button_leave;
            // 
            // button10
            // 
            button10.Dock = DockStyle.Fill;
            button10.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button10.ForeColor = Color.DimGray;
            button10.Location = new Point(3, 255);
            button10.Name = "button10";
            button10.Size = new Size(94, 81);
            button10.TabIndex = 0;
            button10.TabStop = false;
            button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Dock = DockStyle.Fill;
            button11.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button11.ForeColor = Color.DimGray;
            button11.Location = new Point(103, 255);
            button11.Name = "button11";
            button11.Size = new Size(94, 81);
            button11.TabIndex = 0;
            button11.TabStop = false;
            button11.Text = "0";
            button11.UseVisualStyleBackColor = true;
            button11.Click += keypad_click;
            button11.MouseEnter += button_enter;
            button11.MouseLeave += button_leave;
            // 
            // button_delete
            // 
            button_delete.Dock = DockStyle.Fill;
            button_delete.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_delete.ForeColor = Color.DimGray;
            button_delete.Location = new Point(203, 255);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(94, 81);
            button_delete.TabIndex = 0;
            button_delete.TabStop = false;
            button_delete.Text = "ลบ";
            button_delete.UseVisualStyleBackColor = true;
            button_delete.Click += keypad_click;
            button_delete.MouseEnter += button_enter;
            button_delete.MouseLeave += button_leave;
            // 
            // tableLayoutPanel_detail
            // 
            tableLayoutPanel_detail.ColumnCount = 1;
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_detail.Controls.Add(textBox_point, 0, 3);
            tableLayoutPanel_detail.Controls.Add(label1, 0, 0);
            tableLayoutPanel_detail.Controls.Add(label_point_all, 0, 1);
            tableLayoutPanel_detail.Controls.Add(label3, 0, 2);
            tableLayoutPanel_detail.Dock = DockStyle.Fill;
            tableLayoutPanel_detail.Location = new Point(0, 0);
            tableLayoutPanel_detail.Margin = new Padding(0);
            tableLayoutPanel_detail.Name = "tableLayoutPanel_detail";
            tableLayoutPanel_detail.RowCount = 4;
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_detail.Size = new Size(448, 339);
            tableLayoutPanel_detail.TabIndex = 1;
            // 
            // textBox_point
            // 
            textBox_point.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_point.BorderStyle = BorderStyle.None;
            textBox_point.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_point.Location = new Point(3, 255);
            textBox_point.Name = "textBox_point";
            textBox_point.Size = new Size(442, 80);
            textBox_point.TabIndex = 0;
            textBox_point.TextAlign = HorizontalAlignment.Center;
            textBox_point.TextChanged += textBox_point_TextChanged;
            textBox_point.KeyDown += textBox_point_KeyDown;
            textBox_point.KeyPress += textBox_point_KeyPress;
            textBox_point.Leave += textBox_point_Leave;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold | FontStyle.Underline);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(448, 84);
            label1.TabIndex = 1;
            label1.Text = "แต้มคงเหลือ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.MouseEnter += label_enter;
            label1.MouseLeave += label_leave;
            // 
            // label_point_all
            // 
            label_point_all.Dock = DockStyle.Fill;
            label_point_all.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_point_all.ForeColor = Color.DimGray;
            label_point_all.Location = new Point(3, 84);
            label_point_all.Name = "label_point_all";
            label_point_all.Size = new Size(442, 84);
            label_point_all.TabIndex = 1;
            label_point_all.Text = "0";
            label_point_all.TextAlign = ContentAlignment.MiddleCenter;
            label_point_all.MouseEnter += label_enter;
            label_point_all.MouseLeave += label_leave;
            // 
            // label3
            // 
            label3.BackColor = Color.White;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold | FontStyle.Underline);
            label3.Location = new Point(0, 168);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(448, 84);
            label3.TabIndex = 1;
            label3.Text = "ใช้แต้ม";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.MouseEnter += label_enter;
            label3.MouseLeave += label_leave;
            // 
            // Form_Redeem_Point
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lime;
            ClientSize = new Size(782, 553);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_Redeem_Point";
            StartPosition = FormStartPosition.CenterParent;
            Text = "แต้มสมาชิก";
            Load += Form_Redeem_Point_Load;
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_back_middle.ResumeLayout(false);
            tableLayoutPanel_keypad.ResumeLayout(false);
            tableLayoutPanel_detail.ResumeLayout(false);
            tableLayoutPanel_detail.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel_back_middle;
        private Button button_confirm;
        private Label label_member;
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
        private Button button10;
        private Button button11;
        private Button button_delete;
        private TableLayoutPanel tableLayoutPanel_detail;
        private TextBox textBox_point;
        private Label label1;
        private Label label_point_all;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel_back;
    }
}