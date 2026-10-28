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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Item_Weight));
            button_confirm = new Button();
            textBox_weight = new TextBox();
            tableLayoutPanel_back_detail = new TableLayoutPanel();
            pictureBox_item = new PictureBox();
            tableLayoutPanel_detail = new TableLayoutPanel();
            label_weight = new Label();
            label_bar = new Label();
            label_price = new Label();
            label_unit = new Label();
            label_name = new Label();
            label_barcode = new Label();
            label_item_name = new Label();
            label_item_unit = new Label();
            label_item_price = new Label();
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
            tableLayoutPanel_back_detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_item).BeginInit();
            tableLayoutPanel_detail.SuspendLayout();
            tableLayoutPanel_keypad.SuspendLayout();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_left.SuspendLayout();
            SuspendLayout();
            // 
            // button_confirm
            // 
            button_confirm.BackColor = Color.White;
            button_confirm.BackgroundImageLayout = ImageLayout.Zoom;
            button_confirm.Dock = DockStyle.Fill;
            button_confirm.FlatAppearance.BorderSize = 0;
            button_confirm.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_confirm.FlatAppearance.MouseOverBackColor = Color.Lime;
            button_confirm.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_confirm.Location = new Point(3, 456);
            button_confirm.Name = "button_confirm";
            button_confirm.Size = new Size(463, 94);
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
            textBox_weight.BackColor = Color.White;
            textBox_weight.BorderStyle = BorderStyle.None;
            textBox_weight.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_weight.Location = new Point(157, 208);
            textBox_weight.Margin = new Padding(0);
            textBox_weight.Name = "textBox_weight";
            textBox_weight.Size = new Size(292, 63);
            textBox_weight.TabIndex = 1;
            textBox_weight.KeyDown += textBox_weight_KeyDown;
            textBox_weight.KeyPress += textBox_weight_KeyPress;
            textBox_weight.Leave += textBox_weight_Leave;
            // 
            // tableLayoutPanel_back_detail
            // 
            tableLayoutPanel_back_detail.BackColor = Color.Transparent;
            tableLayoutPanel_back_detail.ColumnCount = 1;
            tableLayoutPanel_back_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back_detail.Controls.Add(pictureBox_item, 0, 0);
            tableLayoutPanel_back_detail.Controls.Add(tableLayoutPanel_detail, 0, 1);
            tableLayoutPanel_back_detail.Dock = DockStyle.Fill;
            tableLayoutPanel_back_detail.Location = new Point(10, 10);
            tableLayoutPanel_back_detail.Margin = new Padding(10);
            tableLayoutPanel_back_detail.Name = "tableLayoutPanel_back_detail";
            tableLayoutPanel_back_detail.RowCount = 2;
            tableLayoutPanel_back_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tableLayoutPanel_back_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_back_detail.Size = new Size(449, 433);
            tableLayoutPanel_back_detail.TabIndex = 2;
            // 
            // pictureBox_item
            // 
            pictureBox_item.Dock = DockStyle.Fill;
            pictureBox_item.Location = new Point(0, 0);
            pictureBox_item.Margin = new Padding(0);
            pictureBox_item.Name = "pictureBox_item";
            pictureBox_item.Size = new Size(449, 150);
            pictureBox_item.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_item.TabIndex = 1;
            pictureBox_item.TabStop = false;
            pictureBox_item.WaitOnLoad = true;
            pictureBox_item.MouseEnter += pictureBox_item_MouseEnter;
            pictureBox_item.MouseLeave += pictureBox_item_MouseLeave;
            // 
            // tableLayoutPanel_detail
            // 
            tableLayoutPanel_detail.ColumnCount = 2;
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel_detail.Controls.Add(textBox_weight, 1, 4);
            tableLayoutPanel_detail.Controls.Add(label_weight, 0, 4);
            tableLayoutPanel_detail.Controls.Add(label_bar, 0, 0);
            tableLayoutPanel_detail.Controls.Add(label_price, 0, 3);
            tableLayoutPanel_detail.Controls.Add(label_unit, 0, 2);
            tableLayoutPanel_detail.Controls.Add(label_name, 0, 1);
            tableLayoutPanel_detail.Controls.Add(label_barcode, 1, 0);
            tableLayoutPanel_detail.Controls.Add(label_item_name, 1, 1);
            tableLayoutPanel_detail.Controls.Add(label_item_unit, 1, 2);
            tableLayoutPanel_detail.Controls.Add(label_item_price, 1, 3);
            tableLayoutPanel_detail.Dock = DockStyle.Fill;
            tableLayoutPanel_detail.Location = new Point(0, 150);
            tableLayoutPanel_detail.Margin = new Padding(0);
            tableLayoutPanel_detail.Name = "tableLayoutPanel_detail";
            tableLayoutPanel_detail.RowCount = 5;
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 17.391304F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 17.391304F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 17.391304F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 17.391304F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 30.434782F));
            tableLayoutPanel_detail.Size = new Size(449, 283);
            tableLayoutPanel_detail.TabIndex = 2;
            // 
            // label_weight
            // 
            label_weight.BackColor = Color.White;
            label_weight.Dock = DockStyle.Fill;
            label_weight.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_weight.Location = new Point(0, 196);
            label_weight.Margin = new Padding(0);
            label_weight.Name = "label_weight";
            label_weight.Size = new Size(157, 87);
            label_weight.TabIndex = 0;
            label_weight.Text = "จำนวน :";
            label_weight.TextAlign = ContentAlignment.MiddleRight;
            label_weight.MouseEnter += weight_enter;
            label_weight.MouseLeave += weight_leave;
            // 
            // label_bar
            // 
            label_bar.Dock = DockStyle.Fill;
            label_bar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_bar.ForeColor = Color.Gray;
            label_bar.Location = new Point(0, 0);
            label_bar.Margin = new Padding(0);
            label_bar.Name = "label_bar";
            label_bar.Padding = new Padding(0, 0, 5, 0);
            label_bar.Size = new Size(157, 49);
            label_bar.TabIndex = 0;
            label_bar.Text = "บาร์โค้ด :";
            label_bar.TextAlign = ContentAlignment.MiddleRight;
            label_bar.MouseEnter += bar_enter;
            label_bar.MouseLeave += bar_leave;
            // 
            // label_price
            // 
            label_price.Dock = DockStyle.Fill;
            label_price.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_price.ForeColor = Color.Gray;
            label_price.Location = new Point(0, 147);
            label_price.Margin = new Padding(0);
            label_price.Name = "label_price";
            label_price.Padding = new Padding(0, 0, 5, 0);
            label_price.Size = new Size(157, 49);
            label_price.TabIndex = 0;
            label_price.Text = "ราคาขาย :";
            label_price.TextAlign = ContentAlignment.MiddleRight;
            label_price.MouseEnter += bar_enter;
            label_price.MouseLeave += bar_leave;
            // 
            // label_unit
            // 
            label_unit.Dock = DockStyle.Fill;
            label_unit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_unit.ForeColor = Color.Gray;
            label_unit.Location = new Point(0, 98);
            label_unit.Margin = new Padding(0);
            label_unit.Name = "label_unit";
            label_unit.Padding = new Padding(0, 0, 5, 0);
            label_unit.Size = new Size(157, 49);
            label_unit.TabIndex = 0;
            label_unit.Text = "หน่วย :";
            label_unit.TextAlign = ContentAlignment.MiddleRight;
            label_unit.MouseEnter += bar_enter;
            label_unit.MouseLeave += bar_leave;
            // 
            // label_name
            // 
            label_name.Dock = DockStyle.Fill;
            label_name.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_name.ForeColor = Color.Gray;
            label_name.Location = new Point(0, 49);
            label_name.Margin = new Padding(0);
            label_name.Name = "label_name";
            label_name.Padding = new Padding(0, 0, 5, 0);
            label_name.Size = new Size(157, 49);
            label_name.TabIndex = 0;
            label_name.Text = "ชื่อสินค้า :";
            label_name.TextAlign = ContentAlignment.MiddleRight;
            label_name.MouseEnter += bar_enter;
            label_name.MouseLeave += bar_leave;
            // 
            // label_barcode
            // 
            label_barcode.AutoEllipsis = true;
            label_barcode.Dock = DockStyle.Fill;
            label_barcode.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_barcode.ForeColor = Color.Gray;
            label_barcode.Location = new Point(160, 0);
            label_barcode.Name = "label_barcode";
            label_barcode.Size = new Size(286, 49);
            label_barcode.TabIndex = 2;
            label_barcode.TextAlign = ContentAlignment.MiddleLeft;
            label_barcode.MouseEnter += bar_enter;
            label_barcode.MouseLeave += bar_leave;
            // 
            // label_item_name
            // 
            label_item_name.AutoEllipsis = true;
            label_item_name.Dock = DockStyle.Fill;
            label_item_name.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_item_name.ForeColor = Color.Gray;
            label_item_name.Location = new Point(160, 49);
            label_item_name.Name = "label_item_name";
            label_item_name.Size = new Size(286, 49);
            label_item_name.TabIndex = 2;
            label_item_name.TextAlign = ContentAlignment.MiddleLeft;
            label_item_name.MouseEnter += bar_enter;
            label_item_name.MouseLeave += bar_leave;
            // 
            // label_item_unit
            // 
            label_item_unit.AutoEllipsis = true;
            label_item_unit.Dock = DockStyle.Fill;
            label_item_unit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_item_unit.ForeColor = Color.Gray;
            label_item_unit.Location = new Point(160, 98);
            label_item_unit.Name = "label_item_unit";
            label_item_unit.Size = new Size(286, 49);
            label_item_unit.TabIndex = 2;
            label_item_unit.TextAlign = ContentAlignment.MiddleLeft;
            label_item_unit.MouseEnter += bar_enter;
            label_item_unit.MouseLeave += bar_leave;
            // 
            // label_item_price
            // 
            label_item_price.AutoEllipsis = true;
            label_item_price.Dock = DockStyle.Fill;
            label_item_price.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_item_price.ForeColor = Color.Gray;
            label_item_price.Location = new Point(160, 147);
            label_item_price.Name = "label_item_price";
            label_item_price.Size = new Size(286, 49);
            label_item_price.TabIndex = 2;
            label_item_price.TextAlign = ContentAlignment.MiddleLeft;
            label_item_price.MouseEnter += bar_enter;
            label_item_price.MouseLeave += bar_leave;
            // 
            // tableLayoutPanel_keypad
            // 
            tableLayoutPanel_keypad.BackColor = Color.White;
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
            tableLayoutPanel_keypad.Location = new Point(469, 0);
            tableLayoutPanel_keypad.Margin = new Padding(0);
            tableLayoutPanel_keypad.Name = "tableLayoutPanel_keypad";
            tableLayoutPanel_keypad.RowCount = 4;
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel_keypad.Size = new Size(313, 553);
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
            button1.Size = new Size(98, 132);
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
            button2.Size = new Size(98, 132);
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
            button3.Size = new Size(99, 132);
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
            button4.Location = new Point(3, 141);
            button4.Name = "button4";
            button4.Size = new Size(98, 132);
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
            button5.Location = new Point(107, 141);
            button5.Name = "button5";
            button5.Size = new Size(98, 132);
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
            button6.Location = new Point(211, 141);
            button6.Name = "button6";
            button6.Size = new Size(99, 132);
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
            button7.Location = new Point(3, 279);
            button7.Name = "button7";
            button7.Size = new Size(98, 132);
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
            button8.Location = new Point(107, 279);
            button8.Name = "button8";
            button8.Size = new Size(98, 132);
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
            button9.Location = new Point(211, 279);
            button9.Name = "button9";
            button9.Size = new Size(99, 132);
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
            button_point.Location = new Point(3, 417);
            button_point.Name = "button_point";
            button_point.Size = new Size(98, 133);
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
            button0.Location = new Point(107, 417);
            button0.Name = "button0";
            button0.Size = new Size(98, 133);
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
            button_delete.Location = new Point(211, 417);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(99, 133);
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
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_keypad, 1, 0);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_left, 0, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 1;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(782, 553);
            tableLayoutPanel_back.TabIndex = 9;
            // 
            // tableLayoutPanel_left
            // 
            tableLayoutPanel_left.ColumnCount = 1;
            tableLayoutPanel_left.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_left.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_left.Controls.Add(tableLayoutPanel_back_detail, 0, 0);
            tableLayoutPanel_left.Controls.Add(button_confirm, 0, 1);
            tableLayoutPanel_left.Dock = DockStyle.Fill;
            tableLayoutPanel_left.Location = new Point(0, 0);
            tableLayoutPanel_left.Margin = new Padding(0);
            tableLayoutPanel_left.Name = "tableLayoutPanel_left";
            tableLayoutPanel_left.RowCount = 2;
            tableLayoutPanel_left.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_left.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_left.Size = new Size(469, 553);
            tableLayoutPanel_left.TabIndex = 9;
            // 
            // Form_Item_Weight
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
            Name = "Form_Item_Weight";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "แก้ไขจำนวน";
            Shown += Form_Item_Weight_Shown;
            tableLayoutPanel_back_detail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_item).EndInit();
            tableLayoutPanel_detail.ResumeLayout(false);
            tableLayoutPanel_detail.PerformLayout();
            tableLayoutPanel_keypad.ResumeLayout(false);
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_left.ResumeLayout(false);
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
        private TableLayoutPanel tableLayoutPanel_detail;
        private Label label_barcode;
        private Label label_item_name;
        private Label label_item_unit;
        private Label label_item_price;
    }
}