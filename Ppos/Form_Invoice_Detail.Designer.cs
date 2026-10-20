namespace Ppos
{
    partial class Form_Invoice_Detail
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Invoice_Detail));
            tableLayoutPanel_bill = new TableLayoutPanel();
            dataGridView_item = new DataGridView();
            panel_bottom_bill = new Panel();
            tableLayoutPanel_bottom = new TableLayoutPanel();
            button_void = new Button();
            label_member = new Label();
            label_member_title = new Label();
            tableLayoutPanel_detail_sum = new TableLayoutPanel();
            label_price_net = new Label();
            label_dis_round = new Label();
            label6 = new Label();
            label5 = new Label();
            label_dis_point = new Label();
            label7 = new Label();
            label_dis_member = new Label();
            label4 = new Label();
            label_dis_pro = new Label();
            label3 = new Label();
            label_sum_price = new Label();
            label2 = new Label();
            label1 = new Label();
            label_sum_qty = new Label();
            backgroundWorker_void = new System.ComponentModel.BackgroundWorker();
            seq = new DataGridViewTextBoxColumn();
            id_temp = new DataGridViewTextBoxColumn();
            item_code = new DataGridViewTextBoxColumn();
            small_barcode = new DataGridViewTextBoxColumn();
            barcode = new DataGridViewTextBoxColumn();
            item_name = new DataGridViewTextBoxColumn();
            item_qty = new DataGridViewTextBoxColumn();
            item_unit = new DataGridViewTextBoxColumn();
            item_price = new DataGridViewTextBoxColumn();
            item_price_total = new DataGridViewTextBoxColumn();
            pro = new DataGridViewImageColumn();
            pro_id = new DataGridViewTextBoxColumn();
            pro_type = new DataGridViewTextBoxColumn();
            pro_desc = new DataGridViewTextBoxColumn();
            criterion_type = new DataGridViewTextBoxColumn();
            criterion_value = new DataGridViewTextBoxColumn();
            offer_type = new DataGridViewTextBoxColumn();
            offer_value = new DataGridViewTextBoxColumn();
            discount_type = new DataGridViewTextBoxColumn();
            repeat = new DataGridViewTextBoxColumn();
            premium = new DataGridViewTextBoxColumn();
            effective_member = new DataGridViewTextBoxColumn();
            sale_vat = new DataGridViewTextBoxColumn();
            tableLayoutPanel_bill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).BeginInit();
            tableLayoutPanel_bottom.SuspendLayout();
            tableLayoutPanel_detail_sum.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_bill
            // 
            tableLayoutPanel_bill.BackColor = Color.White;
            tableLayoutPanel_bill.ColumnCount = 1;
            tableLayoutPanel_bill.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_bill.Controls.Add(dataGridView_item, 0, 0);
            tableLayoutPanel_bill.Controls.Add(panel_bottom_bill, 0, 1);
            tableLayoutPanel_bill.Controls.Add(tableLayoutPanel_bottom, 0, 3);
            tableLayoutPanel_bill.Controls.Add(tableLayoutPanel_detail_sum, 0, 2);
            tableLayoutPanel_bill.Dock = DockStyle.Fill;
            tableLayoutPanel_bill.Location = new Point(0, 0);
            tableLayoutPanel_bill.Margin = new Padding(0);
            tableLayoutPanel_bill.Name = "tableLayoutPanel_bill";
            tableLayoutPanel_bill.RowCount = 4;
            tableLayoutPanel_bill.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_bill.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
            tableLayoutPanel_bill.RowStyles.Add(new RowStyle(SizeType.Absolute, 275F));
            tableLayoutPanel_bill.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_bill.Size = new Size(844, 851);
            tableLayoutPanel_bill.TabIndex = 0;
            // 
            // dataGridView_item
            // 
            dataGridView_item.AllowUserToAddRows = false;
            dataGridView_item.AllowUserToDeleteRows = false;
            dataGridView_item.AllowUserToResizeColumns = false;
            dataGridView_item.AllowUserToResizeRows = false;
            dataGridView_item.BackgroundColor = Color.White;
            dataGridView_item.BorderStyle = BorderStyle.None;
            dataGridView_item.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_item.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView_item.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_item.ColumnHeadersHeight = 40;
            dataGridView_item.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_item.Columns.AddRange(new DataGridViewColumn[] { seq, id_temp, item_code, small_barcode, barcode, item_name, item_qty, item_unit, item_price, item_price_total, pro, pro_id, pro_type, pro_desc, criterion_type, criterion_value, offer_type, offer_value, discount_type, repeat, premium, effective_member, sale_vat });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(192, 255, 255);
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dataGridView_item.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridView_item.Dock = DockStyle.Fill;
            dataGridView_item.GridColor = Color.Cyan;
            dataGridView_item.Location = new Point(0, 0);
            dataGridView_item.Margin = new Padding(0);
            dataGridView_item.MultiSelect = false;
            dataGridView_item.Name = "dataGridView_item";
            dataGridView_item.ReadOnly = true;
            dataGridView_item.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = Color.White;
            dataGridViewCellStyle9.SelectionForeColor = Color.Black;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dataGridView_item.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridView_item.RowHeadersVisible = false;
            dataGridView_item.RowHeadersWidth = 10;
            dataGridView_item.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView_item.RowTemplate.Height = 50;
            dataGridView_item.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView_item.ScrollBars = ScrollBars.None;
            dataGridView_item.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_item.Size = new Size(844, 471);
            dataGridView_item.TabIndex = 2;
            dataGridView_item.TabStop = false;
            dataGridView_item.CellMouseEnter += dataGridView_item_CellMouseEnter;
            dataGridView_item.CellMouseLeave += dataGridView_item_CellMouseLeave;
            // 
            // panel_bottom_bill
            // 
            panel_bottom_bill.BackColor = Color.Cyan;
            panel_bottom_bill.Dock = DockStyle.Fill;
            panel_bottom_bill.Location = new Point(0, 471);
            panel_bottom_bill.Margin = new Padding(0);
            panel_bottom_bill.Name = "panel_bottom_bill";
            panel_bottom_bill.Size = new Size(844, 5);
            panel_bottom_bill.TabIndex = 1;
            // 
            // tableLayoutPanel_bottom
            // 
            tableLayoutPanel_bottom.ColumnCount = 3;
            tableLayoutPanel_bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel_bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_bottom.Controls.Add(button_void, 2, 0);
            tableLayoutPanel_bottom.Controls.Add(label_member, 1, 0);
            tableLayoutPanel_bottom.Controls.Add(label_member_title, 0, 0);
            tableLayoutPanel_bottom.Dock = DockStyle.Fill;
            tableLayoutPanel_bottom.Location = new Point(0, 751);
            tableLayoutPanel_bottom.Margin = new Padding(0);
            tableLayoutPanel_bottom.Name = "tableLayoutPanel_bottom";
            tableLayoutPanel_bottom.RowCount = 1;
            tableLayoutPanel_bottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_bottom.Size = new Size(844, 100);
            tableLayoutPanel_bottom.TabIndex = 1;
            // 
            // button_void
            // 
            button_void.BackColor = Color.White;
            button_void.Dock = DockStyle.Fill;
            button_void.FlatAppearance.BorderSize = 0;
            button_void.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_void.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_void.FlatStyle = FlatStyle.Flat;
            button_void.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            button_void.ForeColor = Color.Red;
            button_void.Location = new Point(697, 3);
            button_void.Name = "button_void";
            button_void.Size = new Size(144, 94);
            button_void.TabIndex = 0;
            button_void.Text = "ยกเลิกบิล";
            button_void.TextAlign = ContentAlignment.BottomCenter;
            button_void.TextImageRelation = TextImageRelation.ImageAboveText;
            button_void.UseVisualStyleBackColor = false;
            button_void.Visible = false;
            button_void.Click += button_void_Click;
            button_void.MouseEnter += button_void_MouseEnter;
            button_void.MouseLeave += button_void_MouseLeave;
            // 
            // label_member
            // 
            label_member.AutoEllipsis = true;
            label_member.Dock = DockStyle.Fill;
            label_member.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_member.Location = new Point(200, 0);
            label_member.Margin = new Padding(0);
            label_member.Name = "label_member";
            label_member.Size = new Size(494, 100);
            label_member.TabIndex = 1;
            label_member.TextAlign = ContentAlignment.MiddleLeft;
            label_member.MouseEnter += label_enter;
            label_member.MouseLeave += label_leave;
            // 
            // label_member_title
            // 
            label_member_title.Dock = DockStyle.Fill;
            label_member_title.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_member_title.Location = new Point(0, 0);
            label_member_title.Margin = new Padding(0);
            label_member_title.Name = "label_member_title";
            label_member_title.Size = new Size(200, 100);
            label_member_title.TabIndex = 1;
            label_member_title.Text = "สมาชิก :";
            label_member_title.TextAlign = ContentAlignment.MiddleRight;
            label_member_title.MouseEnter += label_enter;
            label_member_title.MouseLeave += label_leave;
            // 
            // tableLayoutPanel_detail_sum
            // 
            tableLayoutPanel_detail_sum.ColumnCount = 3;
            tableLayoutPanel_detail_sum.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_detail_sum.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_detail_sum.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_detail_sum.Controls.Add(label_price_net, 1, 6);
            tableLayoutPanel_detail_sum.Controls.Add(label_dis_round, 1, 5);
            tableLayoutPanel_detail_sum.Controls.Add(label6, 0, 6);
            tableLayoutPanel_detail_sum.Controls.Add(label5, 0, 5);
            tableLayoutPanel_detail_sum.Controls.Add(label_dis_point, 1, 4);
            tableLayoutPanel_detail_sum.Controls.Add(label7, 0, 4);
            tableLayoutPanel_detail_sum.Controls.Add(label_dis_member, 1, 3);
            tableLayoutPanel_detail_sum.Controls.Add(label4, 0, 3);
            tableLayoutPanel_detail_sum.Controls.Add(label_dis_pro, 1, 2);
            tableLayoutPanel_detail_sum.Controls.Add(label3, 0, 2);
            tableLayoutPanel_detail_sum.Controls.Add(label_sum_price, 1, 1);
            tableLayoutPanel_detail_sum.Controls.Add(label2, 0, 1);
            tableLayoutPanel_detail_sum.Controls.Add(label1, 0, 0);
            tableLayoutPanel_detail_sum.Controls.Add(label_sum_qty, 1, 0);
            tableLayoutPanel_detail_sum.Dock = DockStyle.Fill;
            tableLayoutPanel_detail_sum.Location = new Point(0, 476);
            tableLayoutPanel_detail_sum.Margin = new Padding(0);
            tableLayoutPanel_detail_sum.Name = "tableLayoutPanel_detail_sum";
            tableLayoutPanel_detail_sum.RowCount = 7;
            tableLayoutPanel_detail_sum.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel_detail_sum.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel_detail_sum.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel_detail_sum.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel_detail_sum.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel_detail_sum.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel_detail_sum.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_detail_sum.Size = new Size(844, 275);
            tableLayoutPanel_detail_sum.TabIndex = 3;
            // 
            // label_price_net
            // 
            label_price_net.Dock = DockStyle.Fill;
            label_price_net.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_price_net.Location = new Point(200, 210);
            label_price_net.Margin = new Padding(0);
            label_price_net.Name = "label_price_net";
            label_price_net.Size = new Size(200, 65);
            label_price_net.TabIndex = 2;
            label_price_net.Text = "0.00";
            label_price_net.TextAlign = ContentAlignment.MiddleRight;
            label_price_net.MouseEnter += label_enter;
            label_price_net.MouseLeave += label_leave;
            // 
            // label_dis_round
            // 
            label_dis_round.Dock = DockStyle.Fill;
            label_dis_round.Font = new Font("Segoe UI", 12F);
            label_dis_round.Location = new Point(200, 175);
            label_dis_round.Margin = new Padding(0);
            label_dis_round.Name = "label_dis_round";
            label_dis_round.Padding = new Padding(0, 0, 6, 0);
            label_dis_round.Size = new Size(200, 35);
            label_dis_round.TabIndex = 2;
            label_dis_round.Text = "0.00";
            label_dis_round.TextAlign = ContentAlignment.MiddleRight;
            label_dis_round.MouseEnter += label_enter;
            label_dis_round.MouseLeave += label_leave;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(0, 210);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(200, 65);
            label6.TabIndex = 1;
            label6.Text = "ราคาสุทธิ :";
            label6.TextAlign = ContentAlignment.MiddleRight;
            label6.MouseEnter += label_enter;
            label6.MouseLeave += label_leave;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(0, 175);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Padding = new Padding(0, 0, 6, 0);
            label5.Size = new Size(200, 35);
            label5.TabIndex = 0;
            label5.Text = "ส่วนลดปัดเศษ :";
            label5.TextAlign = ContentAlignment.MiddleRight;
            label5.MouseEnter += label_enter;
            label5.MouseLeave += label_leave;
            // 
            // label_dis_point
            // 
            label_dis_point.Dock = DockStyle.Fill;
            label_dis_point.Font = new Font("Segoe UI", 12F);
            label_dis_point.Location = new Point(200, 140);
            label_dis_point.Margin = new Padding(0);
            label_dis_point.Name = "label_dis_point";
            label_dis_point.Padding = new Padding(0, 0, 6, 0);
            label_dis_point.Size = new Size(200, 35);
            label_dis_point.TabIndex = 2;
            label_dis_point.Text = "0.00";
            label_dis_point.TextAlign = ContentAlignment.MiddleRight;
            label_dis_point.MouseEnter += label_enter;
            label_dis_point.MouseLeave += label_leave;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(0, 140);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Padding = new Padding(0, 0, 6, 0);
            label7.Size = new Size(200, 35);
            label7.TabIndex = 0;
            label7.Text = "ส่วนลดแต้มสมาชิก :";
            label7.TextAlign = ContentAlignment.MiddleRight;
            label7.MouseEnter += label_enter;
            label7.MouseLeave += label_leave;
            // 
            // label_dis_member
            // 
            label_dis_member.Dock = DockStyle.Fill;
            label_dis_member.Font = new Font("Segoe UI", 12F);
            label_dis_member.Location = new Point(200, 105);
            label_dis_member.Margin = new Padding(0);
            label_dis_member.Name = "label_dis_member";
            label_dis_member.Padding = new Padding(0, 0, 6, 0);
            label_dis_member.Size = new Size(200, 35);
            label_dis_member.TabIndex = 2;
            label_dis_member.Text = "0.00";
            label_dis_member.TextAlign = ContentAlignment.MiddleRight;
            label_dis_member.MouseEnter += label_enter;
            label_dis_member.MouseLeave += label_leave;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(0, 105);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 0, 6, 0);
            label4.Size = new Size(200, 35);
            label4.TabIndex = 0;
            label4.Text = "ส่วนลดสมาชิก :";
            label4.TextAlign = ContentAlignment.MiddleRight;
            label4.MouseEnter += label_enter;
            label4.MouseLeave += label_leave;
            // 
            // label_dis_pro
            // 
            label_dis_pro.Dock = DockStyle.Fill;
            label_dis_pro.Font = new Font("Segoe UI", 12F);
            label_dis_pro.Location = new Point(200, 70);
            label_dis_pro.Margin = new Padding(0);
            label_dis_pro.Name = "label_dis_pro";
            label_dis_pro.Padding = new Padding(0, 0, 6, 0);
            label_dis_pro.Size = new Size(200, 35);
            label_dis_pro.TabIndex = 2;
            label_dis_pro.Text = "0.00";
            label_dis_pro.TextAlign = ContentAlignment.MiddleRight;
            label_dis_pro.MouseEnter += label_enter;
            label_dis_pro.MouseLeave += label_leave;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(0, 70);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 0, 6, 0);
            label3.Size = new Size(200, 35);
            label3.TabIndex = 0;
            label3.Text = "ส่วนลดโปรโมชั่น :";
            label3.TextAlign = ContentAlignment.MiddleRight;
            label3.MouseEnter += label_enter;
            label3.MouseLeave += label_leave;
            // 
            // label_sum_price
            // 
            label_sum_price.Dock = DockStyle.Fill;
            label_sum_price.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_sum_price.Location = new Point(200, 35);
            label_sum_price.Margin = new Padding(0);
            label_sum_price.Name = "label_sum_price";
            label_sum_price.Padding = new Padding(0, 0, 6, 0);
            label_sum_price.Size = new Size(200, 35);
            label_sum_price.TabIndex = 2;
            label_sum_price.Text = "0.00";
            label_sum_price.TextAlign = ContentAlignment.MiddleRight;
            label_sum_price.MouseEnter += label_enter;
            label_sum_price.MouseLeave += label_leave;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(0, 35);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 0, 6, 0);
            label2.Size = new Size(200, 35);
            label2.TabIndex = 1;
            label2.Text = "ราคารวม :";
            label2.TextAlign = ContentAlignment.MiddleRight;
            label2.MouseEnter += label_enter;
            label2.MouseLeave += label_leave;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 6, 0);
            label1.Size = new Size(200, 35);
            label1.TabIndex = 0;
            label1.Text = "จำนวนรวม :";
            label1.TextAlign = ContentAlignment.MiddleRight;
            label1.MouseEnter += label_enter;
            label1.MouseLeave += label_leave;
            // 
            // label_sum_qty
            // 
            label_sum_qty.Dock = DockStyle.Fill;
            label_sum_qty.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_sum_qty.Location = new Point(200, 0);
            label_sum_qty.Margin = new Padding(0);
            label_sum_qty.Name = "label_sum_qty";
            label_sum_qty.Padding = new Padding(0, 0, 6, 0);
            label_sum_qty.Size = new Size(200, 35);
            label_sum_qty.TabIndex = 2;
            label_sum_qty.Text = "0.000";
            label_sum_qty.TextAlign = ContentAlignment.MiddleRight;
            label_sum_qty.MouseEnter += label_enter;
            label_sum_qty.MouseLeave += label_leave;
            // 
            // backgroundWorker_void
            // 
            backgroundWorker_void.DoWork += backgroundWorker_void_DoWork;
            backgroundWorker_void.RunWorkerCompleted += backgroundWorker_void_RunWorkerCompleted;
            // 
            // seq
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            seq.DefaultCellStyle = dataGridViewCellStyle2;
            seq.HeaderText = "0";
            seq.MinimumWidth = 6;
            seq.Name = "seq";
            seq.ReadOnly = true;
            seq.Width = 125;
            // 
            // id_temp
            // 
            id_temp.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            id_temp.HeaderText = "";
            id_temp.MinimumWidth = 6;
            id_temp.Name = "id_temp";
            id_temp.ReadOnly = true;
            id_temp.Visible = false;
            id_temp.Width = 23;
            // 
            // item_code
            // 
            item_code.HeaderText = "item_code";
            item_code.MinimumWidth = 6;
            item_code.Name = "item_code";
            item_code.ReadOnly = true;
            item_code.Visible = false;
            item_code.Width = 125;
            // 
            // small_barcode
            // 
            small_barcode.HeaderText = "small_barcode";
            small_barcode.MinimumWidth = 6;
            small_barcode.Name = "small_barcode";
            small_barcode.ReadOnly = true;
            small_barcode.Visible = false;
            small_barcode.Width = 125;
            // 
            // barcode
            // 
            barcode.HeaderText = "barcode";
            barcode.MinimumWidth = 6;
            barcode.Name = "barcode";
            barcode.ReadOnly = true;
            barcode.Visible = false;
            barcode.Width = 125;
            // 
            // item_name
            // 
            item_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            item_name.HeaderText = "สินค้า";
            item_name.MinimumWidth = 6;
            item_name.Name = "item_name";
            item_name.ReadOnly = true;
            // 
            // item_qty
            // 
            item_qty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            item_qty.DefaultCellStyle = dataGridViewCellStyle3;
            item_qty.HeaderText = "จำนวน";
            item_qty.MinimumWidth = 6;
            item_qty.Name = "item_qty";
            item_qty.ReadOnly = true;
            item_qty.Width = 103;
            // 
            // item_unit
            // 
            item_unit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            item_unit.DefaultCellStyle = dataGridViewCellStyle4;
            item_unit.HeaderText = "";
            item_unit.MinimumWidth = 6;
            item_unit.Name = "item_unit";
            item_unit.ReadOnly = true;
            item_unit.Width = 23;
            // 
            // item_price
            // 
            item_price.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            item_price.DefaultCellStyle = dataGridViewCellStyle5;
            item_price.HeaderText = "ราคา";
            item_price.MinimumWidth = 6;
            item_price.Name = "item_price";
            item_price.ReadOnly = true;
            item_price.Width = 86;
            // 
            // item_price_total
            // 
            item_price_total.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            item_price_total.DefaultCellStyle = dataGridViewCellStyle6;
            item_price_total.HeaderText = "รวม";
            item_price_total.MinimumWidth = 6;
            item_price_total.Name = "item_price_total";
            item_price_total.ReadOnly = true;
            item_price_total.Width = 75;
            // 
            // pro
            // 
            pro.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.ForeColor = Color.Red;
            dataGridViewCellStyle7.NullValue = resources.GetObject("dataGridViewCellStyle7.NullValue");
            dataGridViewCellStyle7.SelectionForeColor = Color.Red;
            pro.DefaultCellStyle = dataGridViewCellStyle7;
            pro.HeaderText = "";
            pro.MinimumWidth = 6;
            pro.Name = "pro";
            pro.ReadOnly = true;
            pro.Resizable = DataGridViewTriState.True;
            pro.Width = 50;
            // 
            // pro_id
            // 
            pro_id.HeaderText = "pro_id";
            pro_id.MinimumWidth = 6;
            pro_id.Name = "pro_id";
            pro_id.ReadOnly = true;
            pro_id.Visible = false;
            pro_id.Width = 125;
            // 
            // pro_type
            // 
            pro_type.HeaderText = "pro_type";
            pro_type.MinimumWidth = 6;
            pro_type.Name = "pro_type";
            pro_type.ReadOnly = true;
            pro_type.Visible = false;
            pro_type.Width = 125;
            // 
            // pro_desc
            // 
            pro_desc.HeaderText = "pro_desc";
            pro_desc.MinimumWidth = 6;
            pro_desc.Name = "pro_desc";
            pro_desc.ReadOnly = true;
            pro_desc.Visible = false;
            pro_desc.Width = 125;
            // 
            // criterion_type
            // 
            criterion_type.HeaderText = "criterion_type";
            criterion_type.MinimumWidth = 6;
            criterion_type.Name = "criterion_type";
            criterion_type.ReadOnly = true;
            criterion_type.Visible = false;
            criterion_type.Width = 125;
            // 
            // criterion_value
            // 
            criterion_value.HeaderText = "criterion_value";
            criterion_value.MinimumWidth = 6;
            criterion_value.Name = "criterion_value";
            criterion_value.ReadOnly = true;
            criterion_value.Visible = false;
            criterion_value.Width = 125;
            // 
            // offer_type
            // 
            offer_type.HeaderText = "offer_type";
            offer_type.MinimumWidth = 6;
            offer_type.Name = "offer_type";
            offer_type.ReadOnly = true;
            offer_type.Visible = false;
            offer_type.Width = 125;
            // 
            // offer_value
            // 
            offer_value.HeaderText = "offer_value";
            offer_value.MinimumWidth = 6;
            offer_value.Name = "offer_value";
            offer_value.ReadOnly = true;
            offer_value.Visible = false;
            offer_value.Width = 125;
            // 
            // discount_type
            // 
            discount_type.HeaderText = "discount_type";
            discount_type.MinimumWidth = 6;
            discount_type.Name = "discount_type";
            discount_type.ReadOnly = true;
            discount_type.Visible = false;
            discount_type.Width = 125;
            // 
            // repeat
            // 
            repeat.HeaderText = "repeat";
            repeat.MinimumWidth = 6;
            repeat.Name = "repeat";
            repeat.ReadOnly = true;
            repeat.Visible = false;
            repeat.Width = 125;
            // 
            // premium
            // 
            premium.HeaderText = "premium";
            premium.MinimumWidth = 6;
            premium.Name = "premium";
            premium.ReadOnly = true;
            premium.Visible = false;
            premium.Width = 125;
            // 
            // effective_member
            // 
            effective_member.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            effective_member.HeaderText = "effective_member";
            effective_member.MinimumWidth = 6;
            effective_member.Name = "effective_member";
            effective_member.ReadOnly = true;
            effective_member.Visible = false;
            effective_member.Width = 211;
            // 
            // sale_vat
            // 
            sale_vat.HeaderText = "sale_vat";
            sale_vat.MinimumWidth = 6;
            sale_vat.Name = "sale_vat";
            sale_vat.ReadOnly = true;
            sale_vat.Visible = false;
            sale_vat.Width = 125;
            // 
            // Form_Invoice_Detail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(844, 851);
            Controls.Add(tableLayoutPanel_bill);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "Form_Invoice_Detail";
            StartPosition = FormStartPosition.CenterParent;
            Load += Form_Invoice_Detail_Load;
            tableLayoutPanel_bill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).EndInit();
            tableLayoutPanel_bottom.ResumeLayout(false);
            tableLayoutPanel_detail_sum.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel_bill;
        private DataGridView dataGridView_item;
        private Panel panel_bottom_bill;
        private Label label1;
        private Label label2;
        private Label label_sum_qty;
        private Label label_sum_price;
        private Label label3;
        private Label label_dis_pro;
        private Label label4;
        private Label label_dis_member;
        private Label label5;
        private Label label_dis_round;
        private Label label_price_net;
        private Label label6;
        private Label label7;
        private Label label_dis_point;
        private TableLayoutPanel tableLayoutPanel_bottom;
        private System.ComponentModel.BackgroundWorker backgroundWorker_void;
        private TableLayoutPanel tableLayoutPanel_detail_sum;
        private Label label_member;
        private Button button_void;
        private Label label_member_title;
        private DataGridViewTextBoxColumn seq;
        private DataGridViewTextBoxColumn id_temp;
        private DataGridViewTextBoxColumn item_code;
        private DataGridViewTextBoxColumn small_barcode;
        private DataGridViewTextBoxColumn barcode;
        private DataGridViewTextBoxColumn item_name;
        private DataGridViewTextBoxColumn item_qty;
        private DataGridViewTextBoxColumn item_unit;
        private DataGridViewTextBoxColumn item_price;
        private DataGridViewTextBoxColumn item_price_total;
        private DataGridViewImageColumn pro;
        private DataGridViewTextBoxColumn pro_id;
        private DataGridViewTextBoxColumn pro_type;
        private DataGridViewTextBoxColumn pro_desc;
        private DataGridViewTextBoxColumn criterion_type;
        private DataGridViewTextBoxColumn criterion_value;
        private DataGridViewTextBoxColumn offer_type;
        private DataGridViewTextBoxColumn offer_value;
        private DataGridViewTextBoxColumn discount_type;
        private DataGridViewTextBoxColumn repeat;
        private DataGridViewTextBoxColumn premium;
        private DataGridViewTextBoxColumn effective_member;
        private DataGridViewTextBoxColumn sale_vat;
    }
}