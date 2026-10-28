namespace Ppos
{
    partial class Form_Item_Adjust
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_search = new TableLayoutPanel();
            panel_search = new Panel();
            label_search = new Label();
            textBox_search = new TextBox();
            button_increase = new Button();
            button_decrease = new Button();
            button_custom = new Button();
            tableLayoutPanel_bottom = new TableLayoutPanel();
            panel_detail = new Panel();
            customGroupBox = new CustomGroupBox();
            tableLayoutPanel_back_cost = new TableLayoutPanel();
            tableLayoutPanel_cost = new TableLayoutPanel();
            label_per_unit = new Label();
            textBox_cost = new TextBox();
            label_cost = new Label();
            label2 = new Label();
            tableLayoutPanel_cost_last = new TableLayoutPanel();
            label7 = new Label();
            textBox_cost_last = new TextBox();
            tableLayoutPanel_cost_avg = new TableLayoutPanel();
            label8 = new Label();
            textBox_cost_avg = new TextBox();
            label3 = new Label();
            tableLayoutPanel_item_detail = new TableLayoutPanel();
            label_item_name = new Label();
            label6 = new Label();
            textBox_name = new TextBox();
            textBox_barcode = new TextBox();
            tableLayoutPanel_onhand = new TableLayoutPanel();
            label_onhand_unit = new Label();
            textBox_qty_last = new TextBox();
            label1 = new Label();
            tableLayoutPanel_qty_unit = new TableLayoutPanel();
            label_unit = new Label();
            textBox_qty = new TextBox();
            label_type_adjust = new Label();
            tableLayoutPanel_group = new TableLayoutPanel();
            label4 = new Label();
            label5 = new Label();
            textBox_group_main = new TextBox();
            textBox_group_sub = new TextBox();
            tableLayoutPanel_button_adjust = new TableLayoutPanel();
            button_cost_custom = new Button();
            button_cost_avg = new Button();
            button_cost_last = new Button();
            tableLayoutPanel_per_unit = new TableLayoutPanel();
            button_cost_per_unit = new Button();
            button_cost_all = new Button();
            button_confirm = new Button();
            pictureBox_item = new PictureBox();
            dataGridView_item = new DataGridView();
            small_barcode = new DataGridViewTextBoxColumn();
            code = new DataGridViewTextBoxColumn();
            group_main = new DataGridViewTextBoxColumn();
            group_sub = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            barcode = new DataGridViewTextBoxColumn();
            qty = new DataGridViewTextBoxColumn();
            unit = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            cost_last = new DataGridViewTextBoxColumn();
            cost_avg = new DataGridViewTextBoxColumn();
            qty_small = new DataGridViewTextBoxColumn();
            size = new DataGridViewTextBoxColumn();
            timer_search = new System.Windows.Forms.Timer(components);
            timer_show = new System.Windows.Forms.Timer(components);
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_search.SuspendLayout();
            panel_search.SuspendLayout();
            tableLayoutPanel_bottom.SuspendLayout();
            panel_detail.SuspendLayout();
            customGroupBox.SuspendLayout();
            tableLayoutPanel_back_cost.SuspendLayout();
            tableLayoutPanel_cost.SuspendLayout();
            tableLayoutPanel_cost_last.SuspendLayout();
            tableLayoutPanel_cost_avg.SuspendLayout();
            tableLayoutPanel_item_detail.SuspendLayout();
            tableLayoutPanel_onhand.SuspendLayout();
            tableLayoutPanel_qty_unit.SuspendLayout();
            tableLayoutPanel_group.SuspendLayout();
            tableLayoutPanel_button_adjust.SuspendLayout();
            tableLayoutPanel_per_unit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_item).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.FromArgb(128, 255, 128);
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_search, 0, 0);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_bottom, 0, 1);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(1342, 1000);
            tableLayoutPanel_back.TabIndex = 0;
            // 
            // tableLayoutPanel_search
            // 
            tableLayoutPanel_search.BackColor = Color.FromArgb(128, 255, 128);
            tableLayoutPanel_search.ColumnCount = 6;
            tableLayoutPanel_search.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel_search.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.84615421F));
            tableLayoutPanel_search.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.7692337F));
            tableLayoutPanel_search.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.7692337F));
            tableLayoutPanel_search.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.7692337F));
            tableLayoutPanel_search.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.84615421F));
            tableLayoutPanel_search.Controls.Add(panel_search, 0, 0);
            tableLayoutPanel_search.Controls.Add(button_increase, 2, 0);
            tableLayoutPanel_search.Controls.Add(button_decrease, 3, 0);
            tableLayoutPanel_search.Controls.Add(button_custom, 4, 0);
            tableLayoutPanel_search.Dock = DockStyle.Fill;
            tableLayoutPanel_search.Location = new Point(0, 0);
            tableLayoutPanel_search.Margin = new Padding(0);
            tableLayoutPanel_search.Name = "tableLayoutPanel_search";
            tableLayoutPanel_search.RowCount = 1;
            tableLayoutPanel_search.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_search.Size = new Size(1342, 100);
            tableLayoutPanel_search.TabIndex = 0;
            // 
            // panel_search
            // 
            panel_search.Controls.Add(label_search);
            panel_search.Controls.Add(textBox_search);
            panel_search.Dock = DockStyle.Fill;
            panel_search.Location = new Point(0, 0);
            panel_search.Margin = new Padding(0);
            panel_search.Name = "panel_search";
            panel_search.Size = new Size(400, 100);
            panel_search.TabIndex = 2;
            // 
            // label_search
            // 
            label_search.Dock = DockStyle.Fill;
            label_search.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold);
            label_search.ForeColor = Color.Gray;
            label_search.Location = new Point(0, 0);
            label_search.Name = "label_search";
            label_search.Size = new Size(400, 64);
            label_search.TabIndex = 2;
            label_search.Text = "--";
            label_search.TextAlign = ContentAlignment.BottomRight;
            // 
            // textBox_search
            // 
            textBox_search.BorderStyle = BorderStyle.None;
            textBox_search.Dock = DockStyle.Bottom;
            textBox_search.Font = new Font("Segoe UI", 16.2F);
            textBox_search.Location = new Point(0, 64);
            textBox_search.Margin = new Padding(0);
            textBox_search.Name = "textBox_search";
            textBox_search.Size = new Size(400, 36);
            textBox_search.TabIndex = 1;
            textBox_search.TextAlign = HorizontalAlignment.Center;
            textBox_search.TextChanged += textBox_search_TextChanged;
            // 
            // button_increase
            // 
            button_increase.BackColor = Color.FromArgb(128, 255, 128);
            button_increase.BackgroundImageLayout = ImageLayout.Zoom;
            button_increase.Dock = DockStyle.Fill;
            button_increase.FlatAppearance.BorderSize = 0;
            button_increase.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_increase.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_increase.FlatStyle = FlatStyle.Flat;
            button_increase.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            button_increase.ForeColor = Color.Gray;
            button_increase.Location = new Point(436, 0);
            button_increase.Margin = new Padding(0);
            button_increase.Name = "button_increase";
            button_increase.Size = new Size(289, 100);
            button_increase.TabIndex = 3;
            button_increase.TabStop = false;
            button_increase.Text = "ปรับเพิ่ม";
            button_increase.TextAlign = ContentAlignment.BottomCenter;
            button_increase.TextImageRelation = TextImageRelation.ImageAboveText;
            button_increase.UseVisualStyleBackColor = false;
            button_increase.Click += button_type_adjust_Click;
            button_increase.MouseEnter += button_MouseEnter;
            button_increase.MouseLeave += button_MouseLeave;
            // 
            // button_decrease
            // 
            button_decrease.Dock = DockStyle.Fill;
            button_decrease.FlatAppearance.BorderSize = 0;
            button_decrease.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_decrease.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_decrease.FlatStyle = FlatStyle.Flat;
            button_decrease.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            button_decrease.ForeColor = Color.Gray;
            button_decrease.Location = new Point(725, 0);
            button_decrease.Margin = new Padding(0);
            button_decrease.Name = "button_decrease";
            button_decrease.Size = new Size(289, 100);
            button_decrease.TabIndex = 3;
            button_decrease.TabStop = false;
            button_decrease.Text = "ปรับลด";
            button_decrease.TextAlign = ContentAlignment.BottomCenter;
            button_decrease.TextImageRelation = TextImageRelation.ImageAboveText;
            button_decrease.UseVisualStyleBackColor = true;
            button_decrease.Click += button_type_adjust_Click;
            button_decrease.MouseEnter += button_MouseEnter;
            button_decrease.MouseLeave += button_MouseLeave;
            // 
            // button_custom
            // 
            button_custom.Dock = DockStyle.Fill;
            button_custom.FlatAppearance.BorderSize = 0;
            button_custom.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_custom.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_custom.FlatStyle = FlatStyle.Flat;
            button_custom.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            button_custom.ForeColor = Color.Gray;
            button_custom.Location = new Point(1014, 0);
            button_custom.Margin = new Padding(0);
            button_custom.Name = "button_custom";
            button_custom.Size = new Size(289, 100);
            button_custom.TabIndex = 3;
            button_custom.TabStop = false;
            button_custom.Text = "กำหนด";
            button_custom.TextAlign = ContentAlignment.BottomCenter;
            button_custom.TextImageRelation = TextImageRelation.ImageAboveText;
            button_custom.UseVisualStyleBackColor = true;
            button_custom.Click += button_type_adjust_Click;
            button_custom.MouseEnter += button_MouseEnter;
            button_custom.MouseLeave += button_MouseLeave;
            // 
            // tableLayoutPanel_bottom
            // 
            tableLayoutPanel_bottom.BackColor = Color.FromArgb(128, 255, 128);
            tableLayoutPanel_bottom.ColumnCount = 2;
            tableLayoutPanel_bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel_bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_bottom.Controls.Add(panel_detail, 1, 0);
            tableLayoutPanel_bottom.Controls.Add(dataGridView_item, 0, 0);
            tableLayoutPanel_bottom.Dock = DockStyle.Fill;
            tableLayoutPanel_bottom.Location = new Point(0, 100);
            tableLayoutPanel_bottom.Margin = new Padding(0);
            tableLayoutPanel_bottom.Name = "tableLayoutPanel_bottom";
            tableLayoutPanel_bottom.RowCount = 1;
            tableLayoutPanel_bottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_bottom.Size = new Size(1342, 900);
            tableLayoutPanel_bottom.TabIndex = 1;
            // 
            // panel_detail
            // 
            panel_detail.AutoScroll = true;
            panel_detail.BackColor = Color.White;
            panel_detail.Controls.Add(customGroupBox);
            panel_detail.Dock = DockStyle.Fill;
            panel_detail.Location = new Point(410, 10);
            panel_detail.Margin = new Padding(10, 10, 0, 0);
            panel_detail.Name = "panel_detail";
            panel_detail.Size = new Size(932, 890);
            panel_detail.TabIndex = 0;
            // 
            // customGroupBox
            // 
            customGroupBox.Anchor = AnchorStyles.Top;
            customGroupBox.BackColor = Color.White;
            customGroupBox.BorderColor = Color.FromArgb(128, 255, 128);
            customGroupBox.BorderRadius = 30;
            customGroupBox.BorderThickness = 15;
            customGroupBox.Controls.Add(tableLayoutPanel_back_cost);
            customGroupBox.Controls.Add(tableLayoutPanel_item_detail);
            customGroupBox.Controls.Add(tableLayoutPanel_group);
            customGroupBox.Controls.Add(tableLayoutPanel_button_adjust);
            customGroupBox.Controls.Add(tableLayoutPanel_per_unit);
            customGroupBox.Controls.Add(button_confirm);
            customGroupBox.Controls.Add(pictureBox_item);
            customGroupBox.Location = new Point(168, 9);
            customGroupBox.Margin = new Padding(15);
            customGroupBox.Name = "customGroupBox";
            customGroupBox.Padding = new Padding(10);
            customGroupBox.Size = new Size(600, 800);
            customGroupBox.TabIndex = 2;
            customGroupBox.TabStop = false;
            // 
            // tableLayoutPanel_back_cost
            // 
            tableLayoutPanel_back_cost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel_back_cost.AutoSize = true;
            tableLayoutPanel_back_cost.BackColor = Color.Transparent;
            tableLayoutPanel_back_cost.ColumnCount = 2;
            tableLayoutPanel_back_cost.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            tableLayoutPanel_back_cost.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back_cost.Controls.Add(tableLayoutPanel_cost, 1, 2);
            tableLayoutPanel_back_cost.Controls.Add(label_cost, 0, 2);
            tableLayoutPanel_back_cost.Controls.Add(label2, 0, 0);
            tableLayoutPanel_back_cost.Controls.Add(tableLayoutPanel_cost_last, 1, 0);
            tableLayoutPanel_back_cost.Controls.Add(tableLayoutPanel_cost_avg, 1, 1);
            tableLayoutPanel_back_cost.Controls.Add(label3, 0, 1);
            tableLayoutPanel_back_cost.Location = new Point(10, 470);
            tableLayoutPanel_back_cost.Name = "tableLayoutPanel_back_cost";
            tableLayoutPanel_back_cost.RowCount = 4;
            tableLayoutPanel_back_cost.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_back_cost.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_back_cost.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel_back_cost.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            tableLayoutPanel_back_cost.Size = new Size(580, 170);
            tableLayoutPanel_back_cost.TabIndex = 18;
            tableLayoutPanel_back_cost.Visible = false;
            // 
            // tableLayoutPanel_cost
            // 
            tableLayoutPanel_cost.ColumnCount = 2;
            tableLayoutPanel_cost.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_cost.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_cost.Controls.Add(label_per_unit, 1, 0);
            tableLayoutPanel_cost.Controls.Add(textBox_cost, 0, 0);
            tableLayoutPanel_cost.Dock = DockStyle.Fill;
            tableLayoutPanel_cost.Location = new Point(170, 100);
            tableLayoutPanel_cost.Margin = new Padding(0);
            tableLayoutPanel_cost.Name = "tableLayoutPanel_cost";
            tableLayoutPanel_cost.RowCount = 1;
            tableLayoutPanel_cost.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_cost.Size = new Size(410, 60);
            tableLayoutPanel_cost.TabIndex = 16;
            // 
            // label_per_unit
            // 
            label_per_unit.AutoEllipsis = true;
            label_per_unit.Dock = DockStyle.Fill;
            label_per_unit.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_per_unit.ForeColor = Color.Black;
            label_per_unit.Location = new Point(213, 0);
            label_per_unit.Name = "label_per_unit";
            label_per_unit.Size = new Size(194, 60);
            label_per_unit.TabIndex = 13;
            label_per_unit.Text = "ต่อหน่วย";
            label_per_unit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_cost
            // 
            textBox_cost.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_cost.BackColor = Color.White;
            textBox_cost.Enabled = false;
            textBox_cost.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold);
            textBox_cost.Location = new Point(3, 4);
            textBox_cost.Name = "textBox_cost";
            textBox_cost.Size = new Size(204, 51);
            textBox_cost.TabIndex = 1;
            textBox_cost.TextAlign = HorizontalAlignment.Center;
            textBox_cost.KeyDown += textBox_KeyDown;
            textBox_cost.KeyPress += textBox_cost_KeyPress;
            // 
            // label_cost
            // 
            label_cost.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_cost.ForeColor = Color.Black;
            label_cost.Location = new Point(3, 100);
            label_cost.Margin = new Padding(3, 0, 0, 0);
            label_cost.Name = "label_cost";
            label_cost.RightToLeft = RightToLeft.No;
            label_cost.Size = new Size(167, 45);
            label_cost.TabIndex = 13;
            label_cost.Text = "--";
            label_cost.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(164, 45);
            label2.TabIndex = 13;
            label2.Text = "ต้นทุนล่าสุด :";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel_cost_last
            // 
            tableLayoutPanel_cost_last.ColumnCount = 2;
            tableLayoutPanel_cost_last.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_cost_last.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_cost_last.Controls.Add(label7, 1, 0);
            tableLayoutPanel_cost_last.Controls.Add(textBox_cost_last, 0, 0);
            tableLayoutPanel_cost_last.Dock = DockStyle.Fill;
            tableLayoutPanel_cost_last.Location = new Point(170, 0);
            tableLayoutPanel_cost_last.Margin = new Padding(0);
            tableLayoutPanel_cost_last.Name = "tableLayoutPanel_cost_last";
            tableLayoutPanel_cost_last.RowCount = 1;
            tableLayoutPanel_cost_last.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_cost_last.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_cost_last.Size = new Size(410, 50);
            tableLayoutPanel_cost_last.TabIndex = 17;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label7.ForeColor = Color.DimGray;
            label7.Location = new Point(213, 0);
            label7.Name = "label7";
            label7.Padding = new Padding(3, 0, 0, 0);
            label7.Size = new Size(194, 50);
            label7.TabIndex = 13;
            label7.Text = "ต่อหน่วย";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_cost_last
            // 
            textBox_cost_last.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_cost_last.BackColor = Color.FromArgb(192, 255, 192);
            textBox_cost_last.Enabled = false;
            textBox_cost_last.Font = new Font("Segoe UI", 13.8F);
            textBox_cost_last.Location = new Point(3, 6);
            textBox_cost_last.Name = "textBox_cost_last";
            textBox_cost_last.Size = new Size(204, 38);
            textBox_cost_last.TabIndex = 12;
            textBox_cost_last.TabStop = false;
            textBox_cost_last.TextAlign = HorizontalAlignment.Center;
            // 
            // tableLayoutPanel_cost_avg
            // 
            tableLayoutPanel_cost_avg.ColumnCount = 2;
            tableLayoutPanel_cost_avg.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_cost_avg.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_cost_avg.Controls.Add(label8, 1, 0);
            tableLayoutPanel_cost_avg.Controls.Add(textBox_cost_avg, 0, 0);
            tableLayoutPanel_cost_avg.Dock = DockStyle.Fill;
            tableLayoutPanel_cost_avg.Location = new Point(170, 50);
            tableLayoutPanel_cost_avg.Margin = new Padding(0);
            tableLayoutPanel_cost_avg.Name = "tableLayoutPanel_cost_avg";
            tableLayoutPanel_cost_avg.RowCount = 1;
            tableLayoutPanel_cost_avg.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_cost_avg.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_cost_avg.Size = new Size(410, 50);
            tableLayoutPanel_cost_avg.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoEllipsis = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label8.ForeColor = Color.DimGray;
            label8.Location = new Point(213, 0);
            label8.Name = "label8";
            label8.Padding = new Padding(3, 0, 0, 0);
            label8.Size = new Size(194, 50);
            label8.TabIndex = 13;
            label8.Text = "ต่อหน่วย";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_cost_avg
            // 
            textBox_cost_avg.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_cost_avg.BackColor = Color.FromArgb(192, 255, 192);
            textBox_cost_avg.Enabled = false;
            textBox_cost_avg.Font = new Font("Segoe UI", 13.8F);
            textBox_cost_avg.Location = new Point(3, 6);
            textBox_cost_avg.Name = "textBox_cost_avg";
            textBox_cost_avg.Size = new Size(204, 38);
            textBox_cost_avg.TabIndex = 12;
            textBox_cost_avg.TabStop = false;
            textBox_cost_avg.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(3, 50);
            label3.Name = "label3";
            label3.Size = new Size(164, 45);
            label3.TabIndex = 13;
            label3.Text = "ต้นทุนเฉลี่ย :";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel_item_detail
            // 
            tableLayoutPanel_item_detail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel_item_detail.AutoSize = true;
            tableLayoutPanel_item_detail.BackColor = Color.Transparent;
            tableLayoutPanel_item_detail.ColumnCount = 2;
            tableLayoutPanel_item_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            tableLayoutPanel_item_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_item_detail.Controls.Add(label_item_name, 0, 0);
            tableLayoutPanel_item_detail.Controls.Add(label6, 0, 1);
            tableLayoutPanel_item_detail.Controls.Add(textBox_name, 1, 0);
            tableLayoutPanel_item_detail.Controls.Add(textBox_barcode, 1, 1);
            tableLayoutPanel_item_detail.Controls.Add(tableLayoutPanel_onhand, 1, 2);
            tableLayoutPanel_item_detail.Controls.Add(label1, 0, 2);
            tableLayoutPanel_item_detail.Controls.Add(tableLayoutPanel_qty_unit, 1, 3);
            tableLayoutPanel_item_detail.Controls.Add(label_type_adjust, 0, 3);
            tableLayoutPanel_item_detail.Location = new Point(10, 275);
            tableLayoutPanel_item_detail.Name = "tableLayoutPanel_item_detail";
            tableLayoutPanel_item_detail.RowCount = 4;
            tableLayoutPanel_item_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel_item_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel_item_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel_item_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel_item_detail.Size = new Size(580, 195);
            tableLayoutPanel_item_detail.TabIndex = 15;
            tableLayoutPanel_item_detail.Visible = false;
            // 
            // label_item_name
            // 
            label_item_name.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_item_name.ForeColor = Color.DimGray;
            label_item_name.Location = new Point(3, 0);
            label_item_name.Name = "label_item_name";
            label_item_name.Size = new Size(164, 45);
            label_item_name.TabIndex = 11;
            label_item_name.Text = "ชื่อสินค้า :";
            label_item_name.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label6.ForeColor = Color.DimGray;
            label6.Location = new Point(3, 45);
            label6.Name = "label6";
            label6.Size = new Size(164, 45);
            label6.TabIndex = 13;
            label6.Text = "บาร์โค้ด :";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_name
            // 
            textBox_name.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_name.BackColor = Color.FromArgb(192, 255, 192);
            textBox_name.Enabled = false;
            textBox_name.Font = new Font("Segoe UI", 13.8F);
            textBox_name.Location = new Point(173, 3);
            textBox_name.Margin = new Padding(3, 3, 20, 3);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(387, 38);
            textBox_name.TabIndex = 8;
            textBox_name.TabStop = false;
            // 
            // textBox_barcode
            // 
            textBox_barcode.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_barcode.BackColor = Color.FromArgb(192, 255, 192);
            textBox_barcode.Enabled = false;
            textBox_barcode.Font = new Font("Segoe UI", 13.8F);
            textBox_barcode.Location = new Point(173, 48);
            textBox_barcode.Margin = new Padding(3, 3, 20, 3);
            textBox_barcode.Name = "textBox_barcode";
            textBox_barcode.Size = new Size(387, 38);
            textBox_barcode.TabIndex = 12;
            textBox_barcode.TabStop = false;
            // 
            // tableLayoutPanel_onhand
            // 
            tableLayoutPanel_onhand.ColumnCount = 2;
            tableLayoutPanel_onhand.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_onhand.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_onhand.Controls.Add(label_onhand_unit, 1, 0);
            tableLayoutPanel_onhand.Controls.Add(textBox_qty_last, 0, 0);
            tableLayoutPanel_onhand.Dock = DockStyle.Fill;
            tableLayoutPanel_onhand.Location = new Point(170, 90);
            tableLayoutPanel_onhand.Margin = new Padding(0);
            tableLayoutPanel_onhand.Name = "tableLayoutPanel_onhand";
            tableLayoutPanel_onhand.RowCount = 1;
            tableLayoutPanel_onhand.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_onhand.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_onhand.Size = new Size(410, 45);
            tableLayoutPanel_onhand.TabIndex = 18;
            // 
            // label_onhand_unit
            // 
            label_onhand_unit.Dock = DockStyle.Fill;
            label_onhand_unit.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_onhand_unit.ForeColor = Color.DimGray;
            label_onhand_unit.Location = new Point(213, 0);
            label_onhand_unit.Name = "label_onhand_unit";
            label_onhand_unit.Padding = new Padding(3, 0, 0, 0);
            label_onhand_unit.Size = new Size(194, 45);
            label_onhand_unit.TabIndex = 13;
            label_onhand_unit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_qty_last
            // 
            textBox_qty_last.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_qty_last.BackColor = Color.FromArgb(192, 255, 192);
            textBox_qty_last.Enabled = false;
            textBox_qty_last.Font = new Font("Segoe UI", 13.8F);
            textBox_qty_last.Location = new Point(3, 3);
            textBox_qty_last.Name = "textBox_qty_last";
            textBox_qty_last.Size = new Size(204, 38);
            textBox_qty_last.TabIndex = 12;
            textBox_qty_last.TabStop = false;
            textBox_qty_last.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(3, 90);
            label1.Name = "label1";
            label1.Size = new Size(164, 45);
            label1.TabIndex = 13;
            label1.Text = "คงเหลือ :";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel_qty_unit
            // 
            tableLayoutPanel_qty_unit.ColumnCount = 2;
            tableLayoutPanel_qty_unit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_qty_unit.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_qty_unit.Controls.Add(label_unit, 1, 0);
            tableLayoutPanel_qty_unit.Controls.Add(textBox_qty, 0, 0);
            tableLayoutPanel_qty_unit.Dock = DockStyle.Fill;
            tableLayoutPanel_qty_unit.Location = new Point(170, 135);
            tableLayoutPanel_qty_unit.Margin = new Padding(0);
            tableLayoutPanel_qty_unit.Name = "tableLayoutPanel_qty_unit";
            tableLayoutPanel_qty_unit.RowCount = 1;
            tableLayoutPanel_qty_unit.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_qty_unit.Size = new Size(410, 60);
            tableLayoutPanel_qty_unit.TabIndex = 14;
            // 
            // label_unit
            // 
            label_unit.AutoEllipsis = true;
            label_unit.Dock = DockStyle.Fill;
            label_unit.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_unit.ForeColor = Color.Black;
            label_unit.Location = new Point(213, 0);
            label_unit.Name = "label_unit";
            label_unit.Size = new Size(194, 60);
            label_unit.TabIndex = 13;
            label_unit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_qty
            // 
            textBox_qty.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_qty.BackColor = Color.White;
            textBox_qty.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold);
            textBox_qty.Location = new Point(3, 4);
            textBox_qty.Name = "textBox_qty";
            textBox_qty.Size = new Size(204, 51);
            textBox_qty.TabIndex = 0;
            textBox_qty.TextAlign = HorizontalAlignment.Center;
            textBox_qty.KeyDown += textBox_KeyDown;
            textBox_qty.KeyPress += textBox_qty_KeyPress;
            // 
            // label_type_adjust
            // 
            label_type_adjust.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_type_adjust.ForeColor = Color.Black;
            label_type_adjust.Location = new Point(3, 135);
            label_type_adjust.Margin = new Padding(3, 0, 0, 0);
            label_type_adjust.Name = "label_type_adjust";
            label_type_adjust.RightToLeft = RightToLeft.No;
            label_type_adjust.Size = new Size(167, 45);
            label_type_adjust.TabIndex = 13;
            label_type_adjust.Text = "--";
            label_type_adjust.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel_group
            // 
            tableLayoutPanel_group.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel_group.AutoSize = true;
            tableLayoutPanel_group.BackColor = Color.Transparent;
            tableLayoutPanel_group.ColumnCount = 2;
            tableLayoutPanel_group.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            tableLayoutPanel_group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_group.Controls.Add(label4, 0, 1);
            tableLayoutPanel_group.Controls.Add(label5, 0, 0);
            tableLayoutPanel_group.Controls.Add(textBox_group_main, 1, 0);
            tableLayoutPanel_group.Controls.Add(textBox_group_sub, 1, 1);
            tableLayoutPanel_group.Location = new Point(10, 175);
            tableLayoutPanel_group.Name = "tableLayoutPanel_group";
            tableLayoutPanel_group.RowCount = 2;
            tableLayoutPanel_group.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_group.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_group.Size = new Size(580, 100);
            tableLayoutPanel_group.TabIndex = 17;
            tableLayoutPanel_group.Visible = false;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(3, 50);
            label4.Name = "label4";
            label4.Size = new Size(164, 45);
            label4.TabIndex = 10;
            label4.Text = "กลุ่มย่อย :";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label5.ForeColor = Color.DimGray;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(164, 45);
            label5.TabIndex = 9;
            label5.Text = "กลุ่มหลัก :";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_group_main
            // 
            textBox_group_main.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_group_main.BackColor = Color.FromArgb(192, 255, 192);
            textBox_group_main.Enabled = false;
            textBox_group_main.Font = new Font("Segoe UI", 13.8F);
            textBox_group_main.Location = new Point(173, 6);
            textBox_group_main.Margin = new Padding(3, 3, 20, 3);
            textBox_group_main.Name = "textBox_group_main";
            textBox_group_main.Size = new Size(387, 38);
            textBox_group_main.TabIndex = 1;
            textBox_group_main.TabStop = false;
            // 
            // textBox_group_sub
            // 
            textBox_group_sub.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_group_sub.BackColor = Color.FromArgb(192, 255, 192);
            textBox_group_sub.Enabled = false;
            textBox_group_sub.Font = new Font("Segoe UI", 13.8F);
            textBox_group_sub.Location = new Point(173, 56);
            textBox_group_sub.Margin = new Padding(3, 3, 20, 3);
            textBox_group_sub.Name = "textBox_group_sub";
            textBox_group_sub.Size = new Size(387, 38);
            textBox_group_sub.TabIndex = 7;
            textBox_group_sub.TabStop = false;
            // 
            // tableLayoutPanel_button_adjust
            // 
            tableLayoutPanel_button_adjust.BackColor = Color.Transparent;
            tableLayoutPanel_button_adjust.ColumnCount = 3;
            tableLayoutPanel_button_adjust.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3344421F));
            tableLayoutPanel_button_adjust.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3344421F));
            tableLayoutPanel_button_adjust.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3311157F));
            tableLayoutPanel_button_adjust.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_button_adjust.Controls.Add(button_cost_custom, 2, 0);
            tableLayoutPanel_button_adjust.Controls.Add(button_cost_avg, 0, 0);
            tableLayoutPanel_button_adjust.Controls.Add(button_cost_last, 1, 0);
            tableLayoutPanel_button_adjust.Dock = DockStyle.Bottom;
            tableLayoutPanel_button_adjust.Location = new Point(10, 630);
            tableLayoutPanel_button_adjust.Margin = new Padding(0);
            tableLayoutPanel_button_adjust.Name = "tableLayoutPanel_button_adjust";
            tableLayoutPanel_button_adjust.RowCount = 1;
            tableLayoutPanel_button_adjust.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_button_adjust.Size = new Size(580, 45);
            tableLayoutPanel_button_adjust.TabIndex = 0;
            // 
            // button_cost_custom
            // 
            button_cost_custom.BackColor = Color.Transparent;
            button_cost_custom.Dock = DockStyle.Fill;
            button_cost_custom.FlatAppearance.BorderSize = 0;
            button_cost_custom.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
            button_cost_custom.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128);
            button_cost_custom.FlatStyle = FlatStyle.Flat;
            button_cost_custom.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_cost_custom.ForeColor = Color.Gray;
            button_cost_custom.Location = new Point(386, 0);
            button_cost_custom.Margin = new Padding(0, 0, 0, 3);
            button_cost_custom.Name = "button_cost_custom";
            button_cost_custom.Size = new Size(194, 42);
            button_cost_custom.TabIndex = 0;
            button_cost_custom.TabStop = false;
            button_cost_custom.Text = "กำหนดทุน";
            button_cost_custom.UseVisualStyleBackColor = false;
            button_cost_custom.Click += cost_type_click;
            button_cost_custom.MouseEnter += button_MouseEnter;
            button_cost_custom.MouseLeave += button_MouseLeave;
            // 
            // button_cost_avg
            // 
            button_cost_avg.BackColor = Color.FromArgb(128, 255, 128);
            button_cost_avg.BackgroundImageLayout = ImageLayout.Zoom;
            button_cost_avg.Dock = DockStyle.Fill;
            button_cost_avg.FlatAppearance.BorderSize = 0;
            button_cost_avg.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
            button_cost_avg.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128);
            button_cost_avg.FlatStyle = FlatStyle.Flat;
            button_cost_avg.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_cost_avg.Location = new Point(0, 0);
            button_cost_avg.Margin = new Padding(0, 0, 0, 3);
            button_cost_avg.Name = "button_cost_avg";
            button_cost_avg.Size = new Size(193, 42);
            button_cost_avg.TabIndex = 0;
            button_cost_avg.TabStop = false;
            button_cost_avg.Text = "ทุนเฉลี่ย";
            button_cost_avg.UseVisualStyleBackColor = false;
            button_cost_avg.Click += cost_type_click;
            button_cost_avg.MouseEnter += button_MouseEnter;
            button_cost_avg.MouseLeave += button_MouseLeave;
            // 
            // button_cost_last
            // 
            button_cost_last.BackColor = Color.Transparent;
            button_cost_last.Dock = DockStyle.Fill;
            button_cost_last.FlatAppearance.BorderSize = 0;
            button_cost_last.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
            button_cost_last.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128);
            button_cost_last.FlatStyle = FlatStyle.Flat;
            button_cost_last.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_cost_last.ForeColor = Color.Gray;
            button_cost_last.Location = new Point(196, 0);
            button_cost_last.Margin = new Padding(3, 0, 3, 3);
            button_cost_last.Name = "button_cost_last";
            button_cost_last.Size = new Size(187, 42);
            button_cost_last.TabIndex = 0;
            button_cost_last.TabStop = false;
            button_cost_last.Text = "ทุนล่าสุด";
            button_cost_last.UseVisualStyleBackColor = false;
            button_cost_last.Click += cost_type_click;
            button_cost_last.MouseEnter += button_MouseEnter;
            button_cost_last.MouseLeave += button_MouseLeave;
            // 
            // tableLayoutPanel_per_unit
            // 
            tableLayoutPanel_per_unit.BackColor = Color.Transparent;
            tableLayoutPanel_per_unit.ColumnCount = 2;
            tableLayoutPanel_per_unit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_per_unit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_per_unit.Controls.Add(button_cost_per_unit, 0, 0);
            tableLayoutPanel_per_unit.Controls.Add(button_cost_all, 1, 0);
            tableLayoutPanel_per_unit.Dock = DockStyle.Bottom;
            tableLayoutPanel_per_unit.Location = new Point(10, 675);
            tableLayoutPanel_per_unit.Margin = new Padding(0);
            tableLayoutPanel_per_unit.Name = "tableLayoutPanel_per_unit";
            tableLayoutPanel_per_unit.RowCount = 1;
            tableLayoutPanel_per_unit.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_per_unit.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_per_unit.Size = new Size(580, 45);
            tableLayoutPanel_per_unit.TabIndex = 15;
            // 
            // button_cost_per_unit
            // 
            button_cost_per_unit.BackColor = Color.FromArgb(128, 255, 128);
            button_cost_per_unit.Dock = DockStyle.Fill;
            button_cost_per_unit.FlatAppearance.BorderSize = 0;
            button_cost_per_unit.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
            button_cost_per_unit.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128);
            button_cost_per_unit.FlatStyle = FlatStyle.Flat;
            button_cost_per_unit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_cost_per_unit.Location = new Point(0, 0);
            button_cost_per_unit.Margin = new Padding(0, 0, 3, 3);
            button_cost_per_unit.Name = "button_cost_per_unit";
            button_cost_per_unit.Size = new Size(287, 42);
            button_cost_per_unit.TabIndex = 0;
            button_cost_per_unit.TabStop = false;
            button_cost_per_unit.Text = "ต่อหน่วย";
            button_cost_per_unit.UseVisualStyleBackColor = false;
            button_cost_per_unit.Click += cost_per_click;
            button_cost_per_unit.MouseEnter += button_MouseEnter;
            button_cost_per_unit.MouseLeave += button_MouseLeave;
            // 
            // button_cost_all
            // 
            button_cost_all.BackColor = Color.Transparent;
            button_cost_all.Dock = DockStyle.Fill;
            button_cost_all.FlatAppearance.BorderSize = 0;
            button_cost_all.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
            button_cost_all.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128);
            button_cost_all.FlatStyle = FlatStyle.Flat;
            button_cost_all.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_cost_all.ForeColor = Color.Gray;
            button_cost_all.Location = new Point(293, 0);
            button_cost_all.Margin = new Padding(3, 0, 0, 3);
            button_cost_all.Name = "button_cost_all";
            button_cost_all.Size = new Size(287, 42);
            button_cost_all.TabIndex = 0;
            button_cost_all.TabStop = false;
            button_cost_all.Text = "รวมทั้งหมด";
            button_cost_all.UseVisualStyleBackColor = false;
            button_cost_all.Click += cost_per_click;
            button_cost_all.MouseEnter += button_MouseEnter;
            button_cost_all.MouseLeave += button_MouseLeave;
            // 
            // button_confirm
            // 
            button_confirm.BackColor = Color.FromArgb(128, 255, 128);
            button_confirm.BackgroundImageLayout = ImageLayout.Zoom;
            button_confirm.Dock = DockStyle.Bottom;
            button_confirm.FlatAppearance.BorderSize = 0;
            button_confirm.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
            button_confirm.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128);
            button_confirm.FlatStyle = FlatStyle.Flat;
            button_confirm.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold);
            button_confirm.Location = new Point(10, 720);
            button_confirm.Margin = new Padding(0);
            button_confirm.Name = "button_confirm";
            button_confirm.Size = new Size(580, 70);
            button_confirm.TabIndex = 16;
            button_confirm.TabStop = false;
            button_confirm.Text = "ยืนยัน";
            button_confirm.TextAlign = ContentAlignment.MiddleRight;
            button_confirm.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_confirm.UseVisualStyleBackColor = false;
            button_confirm.Click += button_confirm_Click;
            button_confirm.MouseEnter += button_MouseEnter;
            button_confirm.MouseLeave += button_MouseLeave;
            // 
            // pictureBox_item
            // 
            pictureBox_item.BackColor = Color.Transparent;
            pictureBox_item.Dock = DockStyle.Top;
            pictureBox_item.Location = new Point(10, 30);
            pictureBox_item.Name = "pictureBox_item";
            pictureBox_item.Size = new Size(580, 145);
            pictureBox_item.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_item.TabIndex = 0;
            pictureBox_item.TabStop = false;
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
            dataGridViewCellStyle1.BackColor = Color.Gray;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(128, 255, 128);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView_item.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_item.ColumnHeadersHeight = 10;
            dataGridView_item.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_item.Columns.AddRange(new DataGridViewColumn[] { small_barcode, code, group_main, group_sub, name, barcode, qty, unit, price, cost_last, cost_avg, qty_small, size });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 13.8F);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView_item.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView_item.Dock = DockStyle.Fill;
            dataGridView_item.GridColor = Color.Lime;
            dataGridView_item.Location = new Point(0, 0);
            dataGridView_item.Margin = new Padding(0);
            dataGridView_item.MultiSelect = false;
            dataGridView_item.Name = "dataGridView_item";
            dataGridView_item.ReadOnly = true;
            dataGridView_item.RowHeadersVisible = false;
            dataGridView_item.RowHeadersWidth = 51;
            dataGridView_item.RowTemplate.Height = 50;
            dataGridView_item.ScrollBars = ScrollBars.None;
            dataGridView_item.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_item.ShowCellToolTips = false;
            dataGridView_item.Size = new Size(400, 900);
            dataGridView_item.TabIndex = 1;
            dataGridView_item.TabStop = false;
            dataGridView_item.CellMouseDown += dataGridView_item_CellMouseDown;
            dataGridView_item.CellMouseEnter += dataGridView_item_CellMouseEnter;
            dataGridView_item.CellMouseLeave += dataGridView_item_CellMouseLeave;
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
            // code
            // 
            code.HeaderText = "code";
            code.MinimumWidth = 6;
            code.Name = "code";
            code.ReadOnly = true;
            code.Visible = false;
            code.Width = 50;
            // 
            // group_main
            // 
            group_main.HeaderText = "group_main";
            group_main.MinimumWidth = 6;
            group_main.Name = "group_main";
            group_main.ReadOnly = true;
            group_main.Visible = false;
            group_main.Width = 125;
            // 
            // group_sub
            // 
            group_sub.HeaderText = "group_sub";
            group_sub.MinimumWidth = 6;
            group_sub.Name = "group_sub";
            group_sub.ReadOnly = true;
            group_sub.Visible = false;
            group_sub.Width = 125;
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            name.DefaultCellStyle = dataGridViewCellStyle2;
            name.HeaderText = "สินค้า (0)";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.ReadOnly = true;
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
            // qty
            // 
            qty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            qty.DefaultCellStyle = dataGridViewCellStyle3;
            qty.HeaderText = "";
            qty.MinimumWidth = 6;
            qty.Name = "qty";
            qty.ReadOnly = true;
            qty.Visible = false;
            qty.Width = 125;
            // 
            // unit
            // 
            unit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            unit.DefaultCellStyle = dataGridViewCellStyle4;
            unit.HeaderText = "";
            unit.MinimumWidth = 6;
            unit.Name = "unit";
            unit.ReadOnly = true;
            unit.Visible = false;
            unit.Width = 125;
            // 
            // price
            // 
            price.HeaderText = "price";
            price.MinimumWidth = 6;
            price.Name = "price";
            price.ReadOnly = true;
            price.Visible = false;
            price.Width = 125;
            // 
            // cost_last
            // 
            cost_last.HeaderText = "cost_last";
            cost_last.MinimumWidth = 6;
            cost_last.Name = "cost_last";
            cost_last.ReadOnly = true;
            cost_last.Visible = false;
            cost_last.Width = 125;
            // 
            // cost_avg
            // 
            cost_avg.HeaderText = "cost_avg";
            cost_avg.MinimumWidth = 6;
            cost_avg.Name = "cost_avg";
            cost_avg.ReadOnly = true;
            cost_avg.Visible = false;
            cost_avg.Width = 125;
            // 
            // qty_small
            // 
            qty_small.HeaderText = "qty_small";
            qty_small.MinimumWidth = 6;
            qty_small.Name = "qty_small";
            qty_small.ReadOnly = true;
            qty_small.Visible = false;
            qty_small.Width = 125;
            // 
            // size
            // 
            size.HeaderText = "size";
            size.MinimumWidth = 6;
            size.Name = "size";
            size.ReadOnly = true;
            size.Visible = false;
            size.Width = 125;
            // 
            // timer_search
            // 
            timer_search.Tick += timer_search_Tick;
            // 
            // timer_show
            // 
            timer_show.Interval = 20;
            timer_show.Tick += timer_show_Tick;
            // 
            // Form_Item_Adjust
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1342, 1000);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Item_Adjust";
            Text = "Form_Item_Adjust";
            Load += Form_Item_Adjust_Load;
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_search.ResumeLayout(false);
            panel_search.ResumeLayout(false);
            panel_search.PerformLayout();
            tableLayoutPanel_bottom.ResumeLayout(false);
            panel_detail.ResumeLayout(false);
            customGroupBox.ResumeLayout(false);
            customGroupBox.PerformLayout();
            tableLayoutPanel_back_cost.ResumeLayout(false);
            tableLayoutPanel_cost.ResumeLayout(false);
            tableLayoutPanel_cost.PerformLayout();
            tableLayoutPanel_cost_last.ResumeLayout(false);
            tableLayoutPanel_cost_last.PerformLayout();
            tableLayoutPanel_cost_avg.ResumeLayout(false);
            tableLayoutPanel_cost_avg.PerformLayout();
            tableLayoutPanel_item_detail.ResumeLayout(false);
            tableLayoutPanel_item_detail.PerformLayout();
            tableLayoutPanel_onhand.ResumeLayout(false);
            tableLayoutPanel_onhand.PerformLayout();
            tableLayoutPanel_qty_unit.ResumeLayout(false);
            tableLayoutPanel_qty_unit.PerformLayout();
            tableLayoutPanel_group.ResumeLayout(false);
            tableLayoutPanel_group.PerformLayout();
            tableLayoutPanel_button_adjust.ResumeLayout(false);
            tableLayoutPanel_per_unit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_item).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_back;
        private TableLayoutPanel tableLayoutPanel_search;
        private TextBox textBox_search;
        private TableLayoutPanel tableLayoutPanel_bottom;
        private DataGridView dataGridView_item;
        private Panel panel_search;
        private Label label_search;
        private System.Windows.Forms.Timer timer_search;
        private Button button_increase;
        private Button button_decrease;
        private Button button_custom;
        private Panel panel_detail;
        private PictureBox pictureBox_item;
        private TextBox textBox_group_main;
        private Label label5;
        private TextBox textBox_group_sub;
        private Label label4;
        public TextBox textBox_name;
        private Label label_item_name;
        private TextBox textBox_barcode;
        private Label label6;
        private TextBox textBox_qty;
        private Label label_type_adjust;
        private TableLayoutPanel tableLayoutPanel_item_detail;
        private TableLayoutPanel tableLayoutPanel_qty_unit;
        private TableLayoutPanel tableLayoutPanel_button_adjust;
        private TextBox textBox_cost;
        private Button button_cost_last;
        private Button button_cost_avg;
        private Button button_cost_custom;
        private Label label_cost;
        private Button button_confirm;
        private Label label1;
        private TextBox textBox_qty_last;
        private TableLayoutPanel tableLayoutPanel_per_unit;
        private Button button_cost_per_unit;
        private Button button_cost_all;
        private TableLayoutPanel tableLayoutPanel_cost;
        private Label label2;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel_cost_avg;
        private Label label8;
        private TableLayoutPanel tableLayoutPanel_cost_last;
        private Label label7;
        private TextBox textBox_cost_avg;
        private TextBox textBox_cost_last;
        private Label label_per_unit;
        private Label label_unit;
        private TableLayoutPanel tableLayoutPanel_onhand;
        private Label label_onhand_unit;
        private CustomGroupBox customGroupBox;
        private TableLayoutPanel tableLayoutPanel_group;
        private TableLayoutPanel tableLayoutPanel_back_cost;
        private System.Windows.Forms.Timer timer_show;
        private DataGridViewTextBoxColumn small_barcode;
        private DataGridViewTextBoxColumn code;
        private DataGridViewTextBoxColumn group_main;
        private DataGridViewTextBoxColumn group_sub;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn barcode;
        private DataGridViewTextBoxColumn qty;
        private DataGridViewTextBoxColumn unit;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn cost_last;
        private DataGridViewTextBoxColumn cost_avg;
        private DataGridViewTextBoxColumn qty_small;
        private DataGridViewTextBoxColumn size;
    }
}