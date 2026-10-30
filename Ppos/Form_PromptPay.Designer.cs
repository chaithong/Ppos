namespace Ppos
{
    partial class Form_PromptPay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PromptPay));
            tableLayoutPanel_back = new TableLayoutPanel();
            button_ok = new Button();
            button_confirm = new Button();
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
            pictureBox_QRCode = new PictureBox();
            label_amount = new Label();
            textBox_amount = new TextBox();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_keypad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_QRCode).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.White;
            tableLayoutPanel_back.ColumnCount = 2;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel_back.Controls.Add(button_ok, 1, 2);
            tableLayoutPanel_back.Controls.Add(button_confirm, 0, 2);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_keypad, 1, 1);
            tableLayoutPanel_back.Controls.Add(pictureBox_QRCode, 0, 1);
            tableLayoutPanel_back.Controls.Add(label_amount, 0, 0);
            tableLayoutPanel_back.Controls.Add(textBox_amount, 1, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(5);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 3;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.Size = new Size(782, 553);
            tableLayoutPanel_back.TabIndex = 0;
            // 
            // button_ok
            // 
            button_ok.BackColor = Color.White;
            button_ok.Dock = DockStyle.Fill;
            button_ok.FlatAppearance.BorderSize = 0;
            button_ok.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_ok.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_ok.FlatStyle = FlatStyle.Flat;
            button_ok.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_ok.Location = new Point(472, 456);
            button_ok.Name = "button_ok";
            button_ok.Size = new Size(307, 94);
            button_ok.TabIndex = 2;
            button_ok.TabStop = false;
            button_ok.Text = "ตกลง";
            button_ok.TextAlign = ContentAlignment.MiddleRight;
            button_ok.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_ok.UseVisualStyleBackColor = false;
            button_ok.Click += button_ok_Click;
            button_ok.MouseEnter += button_enter;
            button_ok.MouseLeave += button_leave;
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
            button_confirm.Size = new Size(463, 94);
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
            tableLayoutPanel_keypad.Location = new Point(469, 80);
            tableLayoutPanel_keypad.Margin = new Padding(0);
            tableLayoutPanel_keypad.Name = "tableLayoutPanel_keypad";
            tableLayoutPanel_keypad.RowCount = 4;
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.Size = new Size(313, 373);
            tableLayoutPanel_keypad.TabIndex = 0;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DimGray;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(98, 87);
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
            button2.Location = new Point(107, 3);
            button2.Name = "button2";
            button2.Size = new Size(98, 87);
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
            button3.Location = new Point(211, 3);
            button3.Name = "button3";
            button3.Size = new Size(99, 87);
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
            button4.Location = new Point(3, 96);
            button4.Name = "button4";
            button4.Size = new Size(98, 87);
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
            button5.Location = new Point(107, 96);
            button5.Name = "button5";
            button5.Size = new Size(98, 87);
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
            button6.Location = new Point(211, 96);
            button6.Name = "button6";
            button6.Size = new Size(99, 87);
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
            button7.Location = new Point(3, 189);
            button7.Name = "button7";
            button7.Size = new Size(98, 87);
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
            button8.Location = new Point(107, 189);
            button8.Name = "button8";
            button8.Size = new Size(98, 87);
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
            button9.Location = new Point(211, 189);
            button9.Name = "button9";
            button9.Size = new Size(99, 87);
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
            button10.Location = new Point(3, 282);
            button10.Name = "button10";
            button10.Size = new Size(98, 88);
            button10.TabIndex = 0;
            button10.TabStop = false;
            button10.Text = ".";
            button10.UseVisualStyleBackColor = true;
            button10.Visible = false;
            button10.Click += keypad_click;
            button10.MouseEnter += button_enter;
            button10.MouseLeave += button_leave;
            // 
            // button11
            // 
            button11.Dock = DockStyle.Fill;
            button11.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button11.ForeColor = Color.DimGray;
            button11.Location = new Point(107, 282);
            button11.Name = "button11";
            button11.Size = new Size(98, 88);
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
            button_delete.Location = new Point(211, 282);
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
            // pictureBox_QRCode
            // 
            pictureBox_QRCode.BackColor = Color.Transparent;
            pictureBox_QRCode.Dock = DockStyle.Fill;
            pictureBox_QRCode.Location = new Point(0, 80);
            pictureBox_QRCode.Margin = new Padding(0);
            pictureBox_QRCode.Name = "pictureBox_QRCode";
            pictureBox_QRCode.Size = new Size(469, 373);
            pictureBox_QRCode.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_QRCode.TabIndex = 0;
            pictureBox_QRCode.TabStop = false;
            // 
            // label_amount
            // 
            label_amount.Dock = DockStyle.Fill;
            label_amount.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_amount.Location = new Point(3, 0);
            label_amount.Name = "label_amount";
            label_amount.Size = new Size(463, 80);
            label_amount.TabIndex = 1;
            label_amount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox_amount
            // 
            textBox_amount.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_amount.BorderStyle = BorderStyle.None;
            textBox_amount.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_amount.Location = new Point(472, 8);
            textBox_amount.Name = "textBox_amount";
            textBox_amount.Size = new Size(307, 63);
            textBox_amount.TabIndex = 0;
            textBox_amount.TextAlign = HorizontalAlignment.Center;
            textBox_amount.TextChanged += textBox_amount_TextChanged;
            textBox_amount.KeyDown += textBox_amount_KeyDown;
            textBox_amount.KeyPress += textBox_amount_KeyPress;
            textBox_amount.Leave += textBox_amount_Leave;
            // 
            // Form_PromptPay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(782, 553);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_PromptPay";
            StartPosition = FormStartPosition.CenterParent;
            Text = "เงินโอน";
            Load += Form_PromptPay_Load;
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_back.PerformLayout();
            tableLayoutPanel_keypad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_QRCode).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_back;
        private PictureBox pictureBox_QRCode;
        private Label label_amount;
        private Button button_confirm;
        private TextBox textBox_amount;
        private Button button_ok;
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
    }
}