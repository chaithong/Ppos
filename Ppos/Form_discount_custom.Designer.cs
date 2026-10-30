namespace Ppos
{
    partial class Form_discount_custom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_discount_custom));
            button_confirm = new Button();
            textBox_discount_price = new TextBox();
            tableLayoutPanel_back = new TableLayoutPanel();
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
            label1 = new Label();
            label_price_net = new Label();
            label3 = new Label();
            label_title = new Label();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_back_middle.SuspendLayout();
            tableLayoutPanel_keypad.SuspendLayout();
            tableLayoutPanel_detail.SuspendLayout();
            SuspendLayout();
            // 
            // button_confirm
            // 
            button_confirm.BackColor = Color.White;
            button_confirm.Dock = DockStyle.Fill;
            button_confirm.FlatAppearance.BorderSize = 0;
            button_confirm.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_confirm.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_confirm.FlatStyle = FlatStyle.Flat;
            button_confirm.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_confirm.Location = new Point(3, 456);
            button_confirm.Name = "button_confirm";
            button_confirm.Size = new Size(776, 94);
            button_confirm.TabIndex = 0;
            button_confirm.TabStop = false;
            button_confirm.Text = "ตกลง";
            button_confirm.TextAlign = ContentAlignment.MiddleRight;
            button_confirm.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_confirm.UseVisualStyleBackColor = false;
            button_confirm.Click += button_confirm_Click;
            button_confirm.MouseEnter += button_enter;
            button_confirm.MouseLeave += button_leave;
            // 
            // textBox_discount_price
            // 
            textBox_discount_price.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_discount_price.BorderStyle = BorderStyle.None;
            textBox_discount_price.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_discount_price.Location = new Point(3, 280);
            textBox_discount_price.Name = "textBox_discount_price";
            textBox_discount_price.Size = new Size(459, 80);
            textBox_discount_price.TabIndex = 1;
            textBox_discount_price.TextAlign = HorizontalAlignment.Center;
            textBox_discount_price.TextChanged += textBox_discount_price_TextChanged;
            textBox_discount_price.KeyDown += textBox_discount_price_KeyDown;
            textBox_discount_price.KeyPress += textBox_discount_price_KeyPress;
            textBox_discount_price.Leave += textBox_discount_price_Leave;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_back.Controls.Add(button_confirm, 0, 2);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_back_middle, 0, 1);
            tableLayoutPanel_back.Controls.Add(label_title, 0, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 3;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.Size = new Size(782, 553);
            tableLayoutPanel_back.TabIndex = 2;
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
            tableLayoutPanel_back_middle.Size = new Size(776, 367);
            tableLayoutPanel_back_middle.TabIndex = 1;
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
            tableLayoutPanel_keypad.Location = new Point(465, 0);
            tableLayoutPanel_keypad.Margin = new Padding(0);
            tableLayoutPanel_keypad.Name = "tableLayoutPanel_keypad";
            tableLayoutPanel_keypad.RowCount = 4;
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.Size = new Size(311, 367);
            tableLayoutPanel_keypad.TabIndex = 1;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DimGray;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(97, 85);
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
            button2.Location = new Point(106, 3);
            button2.Name = "button2";
            button2.Size = new Size(97, 85);
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
            button3.Location = new Point(209, 3);
            button3.Name = "button3";
            button3.Size = new Size(99, 85);
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
            button4.Location = new Point(3, 94);
            button4.Name = "button4";
            button4.Size = new Size(97, 85);
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
            button5.Location = new Point(106, 94);
            button5.Name = "button5";
            button5.Size = new Size(97, 85);
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
            button6.Location = new Point(209, 94);
            button6.Name = "button6";
            button6.Size = new Size(99, 85);
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
            button7.Location = new Point(3, 185);
            button7.Name = "button7";
            button7.Size = new Size(97, 85);
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
            button8.Location = new Point(106, 185);
            button8.Name = "button8";
            button8.Size = new Size(97, 85);
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
            button9.Location = new Point(209, 185);
            button9.Name = "button9";
            button9.Size = new Size(99, 85);
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
            button10.Location = new Point(3, 276);
            button10.Name = "button10";
            button10.Size = new Size(97, 88);
            button10.TabIndex = 0;
            button10.TabStop = false;
            button10.UseVisualStyleBackColor = true;
            button10.Visible = false;
            // 
            // button11
            // 
            button11.Dock = DockStyle.Fill;
            button11.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button11.ForeColor = Color.DimGray;
            button11.Location = new Point(106, 276);
            button11.Name = "button11";
            button11.Size = new Size(97, 88);
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
            button_delete.Location = new Point(209, 276);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(99, 88);
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
            tableLayoutPanel_detail.Controls.Add(textBox_discount_price, 0, 3);
            tableLayoutPanel_detail.Controls.Add(label1, 0, 0);
            tableLayoutPanel_detail.Controls.Add(label_price_net, 0, 1);
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
            tableLayoutPanel_detail.Size = new Size(465, 367);
            tableLayoutPanel_detail.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(459, 91);
            label1.TabIndex = 2;
            label1.Text = "มูลค่าสุทธิ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.MouseEnter += label_enter;
            label1.MouseLeave += label_leave;
            // 
            // label_price_net
            // 
            label_price_net.Dock = DockStyle.Fill;
            label_price_net.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_price_net.ForeColor = Color.Gray;
            label_price_net.Location = new Point(3, 91);
            label_price_net.Name = "label_price_net";
            label_price_net.Size = new Size(459, 91);
            label_price_net.TabIndex = 2;
            label_price_net.Text = "--";
            label_price_net.TextAlign = ContentAlignment.MiddleCenter;
            label_price_net.MouseEnter += label_enter;
            label_price_net.MouseLeave += label_leave;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 182);
            label3.Name = "label3";
            label3.Size = new Size(459, 91);
            label3.TabIndex = 2;
            label3.Text = "ส่วนลด";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.MouseEnter += label_enter;
            label3.MouseLeave += label_leave;
            // 
            // label_title
            // 
            label_title.Dock = DockStyle.Fill;
            label_title.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_title.Location = new Point(3, 0);
            label_title.Name = "label_title";
            label_title.Size = new Size(776, 80);
            label_title.TabIndex = 2;
            label_title.Text = "--";
            label_title.TextAlign = ContentAlignment.MiddleCenter;
            label_title.MouseEnter += label_enter;
            label_title.MouseLeave += label_leave;
            // 
            // Form_discount_custom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(782, 553);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_discount_custom";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ส่วนลดท้ายบิล";
            Load += Form_discount_custom_Load;
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_back_middle.ResumeLayout(false);
            tableLayoutPanel_keypad.ResumeLayout(false);
            tableLayoutPanel_detail.ResumeLayout(false);
            tableLayoutPanel_detail.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button_confirm;
        private TextBox textBox_discount_price;
        private TableLayoutPanel tableLayoutPanel_back;
        private TableLayoutPanel tableLayoutPanel_back_middle;
        private TableLayoutPanel tableLayoutPanel_detail;
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
        private Label label_title;
        private Label label1;
        private Label label_price_net;
        private Label label3;
    }
}