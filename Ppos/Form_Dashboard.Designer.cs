namespace Ppos
{
    partial class Form_Dashboard
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
            tableLayoutPanel_back = new TableLayoutPanel();
            customGroupBox1 = new CustomGroupBox();
            tableLayoutPanel_date = new TableLayoutPanel();
            button_back_date = new Button();
            button_next_date = new Button();
            label_date = new Label();
            customGroupBox_detail = new CustomGroupBox();
            tableLayoutPanel_detail = new TableLayoutPanel();
            label6 = new Label();
            label_sum_price_net = new Label();
            label5 = new Label();
            label_sum_round = new Label();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label_dis_point = new Label();
            label_sum_dis_member = new Label();
            label_sum_dis_pro = new Label();
            label_sum_price = new Label();
            label_sum_qty = new Label();
            label8 = new Label();
            label9 = new Label();
            label_sum_item = new Label();
            label_sum_bill = new Label();
            backgroundWorker_load = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel_back.SuspendLayout();
            customGroupBox1.SuspendLayout();
            tableLayoutPanel_date.SuspendLayout();
            customGroupBox_detail.SuspendLayout();
            tableLayoutPanel_detail.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.Transparent;
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(customGroupBox1, 0, 0);
            tableLayoutPanel_back.Controls.Add(customGroupBox_detail, 0, 1);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(1092, 689);
            tableLayoutPanel_back.TabIndex = 0;
            // 
            // customGroupBox1
            // 
            customGroupBox1.BorderColor = Color.White;
            customGroupBox1.BorderRadius = 30;
            customGroupBox1.BorderThickness = 20;
            customGroupBox1.Controls.Add(tableLayoutPanel_date);
            customGroupBox1.Dock = DockStyle.Fill;
            customGroupBox1.Font = new Font("Segoe UI", 1F);
            customGroupBox1.Location = new Point(0, 0);
            customGroupBox1.Margin = new Padding(0, 0, 0, 10);
            customGroupBox1.Name = "customGroupBox1";
            customGroupBox1.Padding = new Padding(10);
            customGroupBox1.Size = new Size(1092, 110);
            customGroupBox1.TabIndex = 1;
            customGroupBox1.TabStop = false;
            customGroupBox1.Text = " ";
            // 
            // tableLayoutPanel_date
            // 
            tableLayoutPanel_date.BackColor = Color.White;
            tableLayoutPanel_date.ColumnCount = 5;
            tableLayoutPanel_date.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_date.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_date.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            tableLayoutPanel_date.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_date.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_date.Controls.Add(button_back_date, 1, 0);
            tableLayoutPanel_date.Controls.Add(button_next_date, 3, 0);
            tableLayoutPanel_date.Controls.Add(label_date, 2, 0);
            tableLayoutPanel_date.Dock = DockStyle.Fill;
            tableLayoutPanel_date.Enabled = false;
            tableLayoutPanel_date.Location = new Point(10, 13);
            tableLayoutPanel_date.Margin = new Padding(0);
            tableLayoutPanel_date.Name = "tableLayoutPanel_date";
            tableLayoutPanel_date.RowCount = 1;
            tableLayoutPanel_date.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_date.Size = new Size(1072, 87);
            tableLayoutPanel_date.TabIndex = 0;
            // 
            // button_back_date
            // 
            button_back_date.BackgroundImageLayout = ImageLayout.Zoom;
            button_back_date.Dock = DockStyle.Fill;
            button_back_date.FlatAppearance.BorderSize = 0;
            button_back_date.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_back_date.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_back_date.FlatStyle = FlatStyle.Flat;
            button_back_date.Location = new Point(189, 3);
            button_back_date.Name = "button_back_date";
            button_back_date.Size = new Size(94, 81);
            button_back_date.TabIndex = 0;
            button_back_date.TabStop = false;
            button_back_date.UseVisualStyleBackColor = true;
            button_back_date.Click += button_back_date_Click;
            button_back_date.MouseEnter += button_enter;
            button_back_date.MouseLeave += button_leave;
            // 
            // button_next_date
            // 
            button_next_date.BackgroundImageLayout = ImageLayout.Zoom;
            button_next_date.Dock = DockStyle.Fill;
            button_next_date.FlatAppearance.BorderSize = 0;
            button_next_date.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_next_date.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_next_date.FlatStyle = FlatStyle.Flat;
            button_next_date.Location = new Point(789, 3);
            button_next_date.Name = "button_next_date";
            button_next_date.Size = new Size(94, 81);
            button_next_date.TabIndex = 0;
            button_next_date.TabStop = false;
            button_next_date.UseVisualStyleBackColor = true;
            button_next_date.Click += button_next_date_Click;
            button_next_date.MouseEnter += button_enter;
            button_next_date.MouseLeave += button_leave;
            // 
            // label_date
            // 
            label_date.Dock = DockStyle.Fill;
            label_date.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_date.Location = new Point(289, 0);
            label_date.Name = "label_date";
            label_date.Size = new Size(494, 87);
            label_date.TabIndex = 1;
            label_date.Text = "--/--/----";
            label_date.TextAlign = ContentAlignment.MiddleCenter;
            label_date.Click += label_date_Click;
            label_date.MouseEnter += label_mouse_enter;
            label_date.MouseLeave += label_mouse_leave;
            // 
            // customGroupBox_detail
            // 
            customGroupBox_detail.BorderColor = Color.White;
            customGroupBox_detail.BorderRadius = 30;
            customGroupBox_detail.BorderThickness = 20;
            customGroupBox_detail.Controls.Add(tableLayoutPanel_detail);
            customGroupBox_detail.Dock = DockStyle.Fill;
            customGroupBox_detail.Font = new Font("Segoe UI", 1F, FontStyle.Regular, GraphicsUnit.Point, 0);
            customGroupBox_detail.Location = new Point(0, 120);
            customGroupBox_detail.Margin = new Padding(0);
            customGroupBox_detail.Name = "customGroupBox_detail";
            customGroupBox_detail.Padding = new Padding(10);
            customGroupBox_detail.Size = new Size(1092, 569);
            customGroupBox_detail.TabIndex = 1;
            customGroupBox_detail.TabStop = false;
            customGroupBox_detail.Text = " ";
            // 
            // tableLayoutPanel_detail
            // 
            tableLayoutPanel_detail.BackColor = Color.White;
            tableLayoutPanel_detail.ColumnCount = 4;
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tableLayoutPanel_detail.Controls.Add(label6, 1, 8);
            tableLayoutPanel_detail.Controls.Add(label_sum_price_net, 2, 8);
            tableLayoutPanel_detail.Controls.Add(label5, 1, 7);
            tableLayoutPanel_detail.Controls.Add(label_sum_round, 2, 7);
            tableLayoutPanel_detail.Controls.Add(label7, 1, 6);
            tableLayoutPanel_detail.Controls.Add(label4, 1, 5);
            tableLayoutPanel_detail.Controls.Add(label3, 1, 4);
            tableLayoutPanel_detail.Controls.Add(label2, 1, 3);
            tableLayoutPanel_detail.Controls.Add(label1, 1, 2);
            tableLayoutPanel_detail.Controls.Add(label_dis_point, 2, 6);
            tableLayoutPanel_detail.Controls.Add(label_sum_dis_member, 2, 5);
            tableLayoutPanel_detail.Controls.Add(label_sum_dis_pro, 2, 4);
            tableLayoutPanel_detail.Controls.Add(label_sum_price, 2, 3);
            tableLayoutPanel_detail.Controls.Add(label_sum_qty, 2, 2);
            tableLayoutPanel_detail.Controls.Add(label8, 1, 1);
            tableLayoutPanel_detail.Controls.Add(label9, 1, 0);
            tableLayoutPanel_detail.Controls.Add(label_sum_item, 2, 1);
            tableLayoutPanel_detail.Controls.Add(label_sum_bill, 2, 0);
            tableLayoutPanel_detail.Dock = DockStyle.Fill;
            tableLayoutPanel_detail.Location = new Point(10, 13);
            tableLayoutPanel_detail.Name = "tableLayoutPanel_detail";
            tableLayoutPanel_detail.RowCount = 9;
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel_detail.Size = new Size(1072, 546);
            tableLayoutPanel_detail.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoEllipsis = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            label6.Location = new Point(80, 432);
            label6.Name = "label6";
            label6.Size = new Size(394, 114);
            label6.TabIndex = 0;
            label6.Text = "รายรับสุทธิ :";
            label6.TextAlign = ContentAlignment.TopRight;
            label6.MouseEnter += label_mouse_enter;
            label6.MouseLeave += label_mouse_leave;
            // 
            // label_sum_price_net
            // 
            label_sum_price_net.AutoEllipsis = true;
            label_sum_price_net.Dock = DockStyle.Fill;
            label_sum_price_net.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            label_sum_price_net.Location = new Point(480, 432);
            label_sum_price_net.Name = "label_sum_price_net";
            label_sum_price_net.Size = new Size(494, 114);
            label_sum_price_net.TabIndex = 0;
            label_sum_price_net.TextAlign = ContentAlignment.TopRight;
            label_sum_price_net.MouseEnter += label_mouse_enter;
            label_sum_price_net.MouseLeave += label_mouse_leave;
            // 
            // label5
            // 
            label5.AutoEllipsis = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(80, 378);
            label5.Name = "label5";
            label5.Padding = new Padding(0, 0, 15, 0);
            label5.Size = new Size(394, 54);
            label5.TabIndex = 0;
            label5.Text = "ส่วนลดปัดเศษ :";
            label5.TextAlign = ContentAlignment.MiddleRight;
            label5.MouseEnter += label_mouse_enter;
            label5.MouseLeave += label_mouse_leave;
            // 
            // label_sum_round
            // 
            label_sum_round.AutoEllipsis = true;
            label_sum_round.Dock = DockStyle.Fill;
            label_sum_round.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_sum_round.Location = new Point(480, 378);
            label_sum_round.Name = "label_sum_round";
            label_sum_round.Padding = new Padding(0, 0, 15, 0);
            label_sum_round.Size = new Size(494, 54);
            label_sum_round.TabIndex = 0;
            label_sum_round.TextAlign = ContentAlignment.MiddleRight;
            label_sum_round.MouseEnter += label_mouse_enter;
            label_sum_round.MouseLeave += label_mouse_leave;
            // 
            // label7
            // 
            label7.AutoEllipsis = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(80, 324);
            label7.Name = "label7";
            label7.Padding = new Padding(0, 0, 15, 0);
            label7.Size = new Size(394, 54);
            label7.TabIndex = 0;
            label7.Text = "ส่วนลดแต้มสมาชิก :";
            label7.TextAlign = ContentAlignment.MiddleRight;
            label7.MouseEnter += label_mouse_enter;
            label7.MouseLeave += label_mouse_leave;
            // 
            // label4
            // 
            label4.AutoEllipsis = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(80, 270);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 0, 15, 0);
            label4.Size = new Size(394, 54);
            label4.TabIndex = 0;
            label4.Text = "ส่วนลดสมาชิก :";
            label4.TextAlign = ContentAlignment.MiddleRight;
            label4.MouseEnter += label_mouse_enter;
            label4.MouseLeave += label_mouse_leave;
            // 
            // label3
            // 
            label3.AutoEllipsis = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(80, 216);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 0, 15, 0);
            label3.Size = new Size(394, 54);
            label3.TabIndex = 0;
            label3.Text = "ส่วนลดโปรโมชั่น :";
            label3.TextAlign = ContentAlignment.MiddleRight;
            label3.MouseEnter += label_mouse_enter;
            label3.MouseLeave += label_mouse_leave;
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            label2.Location = new Point(80, 162);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 0, 10, 0);
            label2.Size = new Size(394, 54);
            label2.TabIndex = 0;
            label2.Text = "รายรับ :";
            label2.TextAlign = ContentAlignment.MiddleRight;
            label2.MouseEnter += label_mouse_enter;
            label2.MouseLeave += label_mouse_leave;
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            label1.Location = new Point(80, 108);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 10, 0);
            label1.Size = new Size(394, 54);
            label1.TabIndex = 0;
            label1.Text = "จำนวน :";
            label1.TextAlign = ContentAlignment.MiddleRight;
            label1.MouseEnter += label_mouse_enter;
            label1.MouseLeave += label_mouse_leave;
            // 
            // label_dis_point
            // 
            label_dis_point.AutoEllipsis = true;
            label_dis_point.Dock = DockStyle.Fill;
            label_dis_point.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_dis_point.Location = new Point(480, 324);
            label_dis_point.Name = "label_dis_point";
            label_dis_point.Padding = new Padding(0, 0, 15, 0);
            label_dis_point.Size = new Size(494, 54);
            label_dis_point.TabIndex = 0;
            label_dis_point.TextAlign = ContentAlignment.MiddleRight;
            label_dis_point.MouseEnter += label_mouse_enter;
            label_dis_point.MouseLeave += label_mouse_leave;
            // 
            // label_sum_dis_member
            // 
            label_sum_dis_member.AutoEllipsis = true;
            label_sum_dis_member.Dock = DockStyle.Fill;
            label_sum_dis_member.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_sum_dis_member.Location = new Point(480, 270);
            label_sum_dis_member.Name = "label_sum_dis_member";
            label_sum_dis_member.Padding = new Padding(0, 0, 15, 0);
            label_sum_dis_member.Size = new Size(494, 54);
            label_sum_dis_member.TabIndex = 0;
            label_sum_dis_member.TextAlign = ContentAlignment.MiddleRight;
            label_sum_dis_member.MouseEnter += label_mouse_enter;
            label_sum_dis_member.MouseLeave += label_mouse_leave;
            // 
            // label_sum_dis_pro
            // 
            label_sum_dis_pro.AutoEllipsis = true;
            label_sum_dis_pro.Dock = DockStyle.Fill;
            label_sum_dis_pro.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_sum_dis_pro.Location = new Point(480, 216);
            label_sum_dis_pro.Name = "label_sum_dis_pro";
            label_sum_dis_pro.Padding = new Padding(0, 0, 15, 0);
            label_sum_dis_pro.Size = new Size(494, 54);
            label_sum_dis_pro.TabIndex = 0;
            label_sum_dis_pro.TextAlign = ContentAlignment.MiddleRight;
            label_sum_dis_pro.MouseEnter += label_mouse_enter;
            label_sum_dis_pro.MouseLeave += label_mouse_leave;
            // 
            // label_sum_price
            // 
            label_sum_price.AutoEllipsis = true;
            label_sum_price.Dock = DockStyle.Fill;
            label_sum_price.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            label_sum_price.Location = new Point(480, 162);
            label_sum_price.Name = "label_sum_price";
            label_sum_price.Padding = new Padding(0, 0, 10, 0);
            label_sum_price.Size = new Size(494, 54);
            label_sum_price.TabIndex = 0;
            label_sum_price.TextAlign = ContentAlignment.MiddleRight;
            label_sum_price.MouseEnter += label_mouse_enter;
            label_sum_price.MouseLeave += label_mouse_leave;
            // 
            // label_sum_qty
            // 
            label_sum_qty.AutoEllipsis = true;
            label_sum_qty.Dock = DockStyle.Fill;
            label_sum_qty.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            label_sum_qty.Location = new Point(480, 108);
            label_sum_qty.Name = "label_sum_qty";
            label_sum_qty.Padding = new Padding(0, 0, 10, 0);
            label_sum_qty.Size = new Size(494, 54);
            label_sum_qty.TabIndex = 0;
            label_sum_qty.TextAlign = ContentAlignment.MiddleRight;
            label_sum_qty.MouseEnter += label_mouse_enter;
            label_sum_qty.MouseLeave += label_mouse_leave;
            // 
            // label8
            // 
            label8.AutoEllipsis = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            label8.Location = new Point(80, 54);
            label8.Name = "label8";
            label8.Padding = new Padding(0, 0, 10, 0);
            label8.Size = new Size(394, 54);
            label8.TabIndex = 0;
            label8.Text = "สินค้า :";
            label8.TextAlign = ContentAlignment.MiddleRight;
            label8.MouseEnter += label_mouse_enter;
            label8.MouseLeave += label_mouse_leave;
            // 
            // label9
            // 
            label9.AutoEllipsis = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            label9.Location = new Point(80, 0);
            label9.Name = "label9";
            label9.Padding = new Padding(0, 0, 10, 0);
            label9.Size = new Size(394, 54);
            label9.TabIndex = 0;
            label9.Text = "บิลขาย :";
            label9.TextAlign = ContentAlignment.MiddleRight;
            label9.MouseEnter += label_mouse_enter;
            label9.MouseLeave += label_mouse_leave;
            // 
            // label_sum_item
            // 
            label_sum_item.AutoEllipsis = true;
            label_sum_item.Dock = DockStyle.Fill;
            label_sum_item.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            label_sum_item.Location = new Point(480, 54);
            label_sum_item.Name = "label_sum_item";
            label_sum_item.Padding = new Padding(0, 0, 10, 0);
            label_sum_item.Size = new Size(494, 54);
            label_sum_item.TabIndex = 0;
            label_sum_item.TextAlign = ContentAlignment.MiddleRight;
            label_sum_item.MouseEnter += label_mouse_enter;
            label_sum_item.MouseLeave += label_mouse_leave;
            // 
            // label_sum_bill
            // 
            label_sum_bill.AutoEllipsis = true;
            label_sum_bill.Dock = DockStyle.Fill;
            label_sum_bill.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold);
            label_sum_bill.Location = new Point(480, 0);
            label_sum_bill.Name = "label_sum_bill";
            label_sum_bill.Padding = new Padding(0, 0, 10, 0);
            label_sum_bill.Size = new Size(494, 54);
            label_sum_bill.TabIndex = 0;
            label_sum_bill.TextAlign = ContentAlignment.MiddleRight;
            label_sum_bill.MouseEnter += label_mouse_enter;
            label_sum_bill.MouseLeave += label_mouse_leave;
            // 
            // backgroundWorker_load
            // 
            backgroundWorker_load.DoWork += backgroundWorker_load_DoWork;
            backgroundWorker_load.RunWorkerCompleted += backgroundWorker_load_RunWorkerCompleted;
            // 
            // Form_Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cyan;
            ClientSize = new Size(1102, 692);
            ControlBox = false;
            Controls.Add(tableLayoutPanel_back);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Dashboard";
            Padding = new Padding(0, 0, 10, 3);
            StartPosition = FormStartPosition.CenterParent;
            FormClosed += Form_Dashboard_FormClosed;
            Load += Form_Dashboard_Load;
            tableLayoutPanel_back.ResumeLayout(false);
            customGroupBox1.ResumeLayout(false);
            tableLayoutPanel_date.ResumeLayout(false);
            customGroupBox_detail.ResumeLayout(false);
            tableLayoutPanel_detail.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel_back;
        private TableLayoutPanel tableLayoutPanel_date;
        private TableLayoutPanel tableLayoutPanel_detail;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label_sum_price_net;
        private Label label_sum_round;
        private Label label_sum_dis_member;
        private Label label_sum_dis_pro;
        private Label label_sum_price;
        private Label label_sum_qty;
        private Button button_back_date;
        private Button button_next_date;
        private Label label_date;
        private System.ComponentModel.BackgroundWorker backgroundWorker_load;
        private Label label7;
        private Label label_dis_point;
        private CustomGroupBox customGroupBox_detail;
        private Label label8;
        private Label label9;
        private Label label_sum_item;
        private Label label_sum_bill;
        private CustomGroupBox customGroupBox1;
    }
}