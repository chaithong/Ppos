namespace Ppos
{
    partial class Form_Item_Detail_Small
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            customGroupBox_item = new CustomGroupBox();
            tableLayoutPanel_group = new TableLayoutPanel();
            label1 = new Label();
            textBox_group_main = new TextBox();
            textBox_group_sub = new TextBox();
            label2 = new Label();
            tableLayoutPanel_item = new TableLayoutPanel();
            label_item_name = new Label();
            textBox_name = new TextBox();
            label6 = new Label();
            textBox_small_barcode = new TextBox();
            tableLayoutPanel_cost = new TableLayoutPanel();
            label7 = new Label();
            textBox_small_unit = new TextBox();
            label_small_price = new Label();
            textBox_small_price = new TextBox();
            label_small_cost_avg = new Label();
            textBox_small_cost_avg = new TextBox();
            label_small_qty = new Label();
            textBox_small_qty = new TextBox();
            label3 = new Label();
            textBox_small_cost_last = new TextBox();
            tableLayoutPanel_affective = new TableLayoutPanel();
            button_item_weight = new Button();
            button_effective_member = new Button();
            button_effective_promotion = new Button();
            button_sale_vat = new Button();
            button_effective_hotkey = new Button();
            button_sale_negative = new Button();
            timer_search = new System.Windows.Forms.Timer(components);
            button_delete_picture = new Button();
            button_edit_picture = new Button();
            pictureBox_item = new PictureBox();
            tableLayoutPanel_button_picture = new TableLayoutPanel();
            button_camera = new Button();
            customGroupBox_picture = new CustomGroupBox();
            large_qty = new DataGridViewTextBoxColumn();
            large_cost_avg = new DataGridViewTextBoxColumn();
            large_cost_last = new DataGridViewTextBoxColumn();
            large_price = new DataGridViewTextBoxColumn();
            large_unit = new DataGridViewTextBoxColumn();
            large_barcode = new DataGridViewTextBoxColumn();
            medium_qty_small = new DataGridViewTextBoxColumn();
            medium_qty = new DataGridViewTextBoxColumn();
            medium_cost_avg = new DataGridViewTextBoxColumn();
            medium_cost_last = new DataGridViewTextBoxColumn();
            medium_price = new DataGridViewTextBoxColumn();
            medium_unit = new DataGridViewTextBoxColumn();
            medium_barcode = new DataGridViewTextBoxColumn();
            small_qty = new DataGridViewTextBoxColumn();
            small_cost_avg = new DataGridViewTextBoxColumn();
            small_cost_last = new DataGridViewTextBoxColumn();
            small_price = new DataGridViewTextBoxColumn();
            small_unit = new DataGridViewTextBoxColumn();
            small_barcode = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            group_sub = new DataGridViewTextBoxColumn();
            group_main = new DataGridViewTextBoxColumn();
            code = new DataGridViewTextBoxColumn();
            large_qty_small = new DataGridViewTextBoxColumn();
            dataGridView_item = new DataGridView();
            sale_vat = new DataGridViewTextBoxColumn();
            sale_negative = new DataGridViewTextBoxColumn();
            item_weight = new DataGridViewTextBoxColumn();
            effective_promotion = new DataGridViewTextBoxColumn();
            effective_member = new DataGridViewTextBoxColumn();
            effective_hotkey = new DataGridViewTextBoxColumn();
            delete = new DataGridViewImageColumn();
            tableLayoutPanel_back_detail_item = new TableLayoutPanel();
            panel_detail = new Panel();
            tableLayoutPanel_bottom = new TableLayoutPanel();
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_top = new TableLayoutPanel();
            panel_search = new Panel();
            label_search = new Label();
            textBox_search = new TextBox();
            button_cancel = new Button();
            button_edit_save = new Button();
            button_add_save = new Button();
            timer_show = new System.Windows.Forms.Timer(components);
            customGroupBox_item.SuspendLayout();
            tableLayoutPanel_group.SuspendLayout();
            tableLayoutPanel_item.SuspendLayout();
            tableLayoutPanel_cost.SuspendLayout();
            tableLayoutPanel_affective.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_item).BeginInit();
            tableLayoutPanel_button_picture.SuspendLayout();
            customGroupBox_picture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).BeginInit();
            tableLayoutPanel_back_detail_item.SuspendLayout();
            panel_detail.SuspendLayout();
            tableLayoutPanel_bottom.SuspendLayout();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_top.SuspendLayout();
            panel_search.SuspendLayout();
            SuspendLayout();
            // 
            // customGroupBox_item
            // 
            customGroupBox_item.BorderColor = Color.Lime;
            customGroupBox_item.BorderRadius = 30;
            customGroupBox_item.BorderThickness = 10;
            customGroupBox_item.Controls.Add(tableLayoutPanel_group);
            customGroupBox_item.Controls.Add(tableLayoutPanel_item);
            customGroupBox_item.Controls.Add(tableLayoutPanel_cost);
            customGroupBox_item.Controls.Add(tableLayoutPanel_affective);
            customGroupBox_item.Dock = DockStyle.Top;
            customGroupBox_item.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            customGroupBox_item.Location = new Point(3, 283);
            customGroupBox_item.Name = "customGroupBox_item";
            customGroupBox_item.Padding = new Padding(15);
            customGroupBox_item.Size = new Size(544, 600);
            customGroupBox_item.TabIndex = 14;
            customGroupBox_item.TabStop = false;
            customGroupBox_item.Text = "สินค้า";
            // 
            // tableLayoutPanel_group
            // 
            tableLayoutPanel_group.AutoSize = true;
            tableLayoutPanel_group.BackColor = Color.Transparent;
            tableLayoutPanel_group.ColumnCount = 2;
            tableLayoutPanel_group.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel_group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_group.Controls.Add(label1, 0, 1);
            tableLayoutPanel_group.Controls.Add(textBox_group_main, 1, 0);
            tableLayoutPanel_group.Controls.Add(textBox_group_sub, 1, 1);
            tableLayoutPanel_group.Controls.Add(label2, 0, 0);
            tableLayoutPanel_group.Dock = DockStyle.Bottom;
            tableLayoutPanel_group.Location = new Point(15, 78);
            tableLayoutPanel_group.Margin = new Padding(3, 9, 3, 3);
            tableLayoutPanel_group.Name = "tableLayoutPanel_group";
            tableLayoutPanel_group.RowCount = 2;
            tableLayoutPanel_group.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_group.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_group.Size = new Size(514, 100);
            tableLayoutPanel_group.TabIndex = 12;
            tableLayoutPanel_group.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(3, 50);
            label1.Name = "label1";
            label1.Size = new Size(144, 50);
            label1.TabIndex = 6;
            label1.Text = "กลุ่มย่อย :";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_group_main
            // 
            textBox_group_main.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_group_main.BackColor = Color.FromArgb(192, 255, 192);
            textBox_group_main.Enabled = false;
            textBox_group_main.Font = new Font("Segoe UI", 13.8F);
            textBox_group_main.Location = new Point(153, 6);
            textBox_group_main.Margin = new Padding(3, 3, 10, 3);
            textBox_group_main.Name = "textBox_group_main";
            textBox_group_main.Size = new Size(351, 38);
            textBox_group_main.TabIndex = 2;
            textBox_group_main.TabStop = false;
            textBox_group_main.KeyDown += textBox_KeyDown;
            // 
            // textBox_group_sub
            // 
            textBox_group_sub.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_group_sub.BackColor = Color.FromArgb(192, 255, 192);
            textBox_group_sub.Enabled = false;
            textBox_group_sub.Font = new Font("Segoe UI", 13.8F);
            textBox_group_sub.Location = new Point(153, 56);
            textBox_group_sub.Margin = new Padding(3, 3, 10, 3);
            textBox_group_sub.Name = "textBox_group_sub";
            textBox_group_sub.Size = new Size(351, 38);
            textBox_group_sub.TabIndex = 2;
            textBox_group_sub.TabStop = false;
            textBox_group_sub.KeyDown += textBox_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(144, 50);
            label2.TabIndex = 6;
            label2.Text = "กลุ่มหลัก :";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel_item
            // 
            tableLayoutPanel_item.AutoSize = true;
            tableLayoutPanel_item.BackColor = Color.Transparent;
            tableLayoutPanel_item.ColumnCount = 2;
            tableLayoutPanel_item.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel_item.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_item.Controls.Add(label_item_name, 0, 0);
            tableLayoutPanel_item.Controls.Add(textBox_name, 1, 0);
            tableLayoutPanel_item.Controls.Add(label6, 0, 1);
            tableLayoutPanel_item.Controls.Add(textBox_small_barcode, 1, 1);
            tableLayoutPanel_item.Dock = DockStyle.Bottom;
            tableLayoutPanel_item.Location = new Point(15, 178);
            tableLayoutPanel_item.Name = "tableLayoutPanel_item";
            tableLayoutPanel_item.RowCount = 2;
            tableLayoutPanel_item.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_item.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_item.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_item.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_item.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_item.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_item.Size = new Size(514, 100);
            tableLayoutPanel_item.TabIndex = 10;
            tableLayoutPanel_item.Visible = false;
            // 
            // label_item_name
            // 
            label_item_name.AutoSize = true;
            label_item_name.Dock = DockStyle.Fill;
            label_item_name.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_item_name.ForeColor = Color.DimGray;
            label_item_name.Location = new Point(3, 0);
            label_item_name.Name = "label_item_name";
            label_item_name.Size = new Size(144, 50);
            label_item_name.TabIndex = 6;
            label_item_name.Text = "ชื่อสินค้า :";
            label_item_name.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_name
            // 
            textBox_name.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_name.BackColor = Color.FromArgb(192, 255, 192);
            textBox_name.Enabled = false;
            textBox_name.Font = new Font("Segoe UI", 13.8F);
            textBox_name.Location = new Point(153, 6);
            textBox_name.Margin = new Padding(3, 3, 10, 3);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(351, 38);
            textBox_name.TabIndex = 2;
            textBox_name.TabStop = false;
            textBox_name.KeyDown += textBox_KeyDown;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label6.ForeColor = Color.DimGray;
            label6.Location = new Point(3, 50);
            label6.Name = "label6";
            label6.Size = new Size(144, 50);
            label6.TabIndex = 5;
            label6.Text = "บาร์โค้ด :";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_small_barcode
            // 
            textBox_small_barcode.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_small_barcode.BackColor = Color.FromArgb(192, 255, 192);
            textBox_small_barcode.Enabled = false;
            textBox_small_barcode.Font = new Font("Segoe UI", 13.8F);
            textBox_small_barcode.Location = new Point(153, 56);
            textBox_small_barcode.Margin = new Padding(3, 3, 10, 3);
            textBox_small_barcode.Name = "textBox_small_barcode";
            textBox_small_barcode.Size = new Size(351, 38);
            textBox_small_barcode.TabIndex = 5;
            textBox_small_barcode.TabStop = false;
            textBox_small_barcode.KeyDown += textBox_KeyDown;
            textBox_small_barcode.KeyPress += KeyPress_Number;
            // 
            // tableLayoutPanel_cost
            // 
            tableLayoutPanel_cost.AutoSize = true;
            tableLayoutPanel_cost.BackColor = Color.Transparent;
            tableLayoutPanel_cost.ColumnCount = 4;
            tableLayoutPanel_cost.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel_cost.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_cost.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tableLayoutPanel_cost.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_cost.Controls.Add(label7, 0, 0);
            tableLayoutPanel_cost.Controls.Add(textBox_small_unit, 1, 0);
            tableLayoutPanel_cost.Controls.Add(label_small_price, 2, 0);
            tableLayoutPanel_cost.Controls.Add(textBox_small_price, 3, 0);
            tableLayoutPanel_cost.Controls.Add(label_small_cost_avg, 0, 2);
            tableLayoutPanel_cost.Controls.Add(textBox_small_cost_avg, 1, 2);
            tableLayoutPanel_cost.Controls.Add(label_small_qty, 2, 1);
            tableLayoutPanel_cost.Controls.Add(textBox_small_qty, 3, 1);
            tableLayoutPanel_cost.Controls.Add(label3, 0, 1);
            tableLayoutPanel_cost.Controls.Add(textBox_small_cost_last, 1, 1);
            tableLayoutPanel_cost.Dock = DockStyle.Bottom;
            tableLayoutPanel_cost.Location = new Point(15, 278);
            tableLayoutPanel_cost.Name = "tableLayoutPanel_cost";
            tableLayoutPanel_cost.RowCount = 3;
            tableLayoutPanel_cost.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_cost.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_cost.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_cost.Size = new Size(514, 150);
            tableLayoutPanel_cost.TabIndex = 11;
            tableLayoutPanel_cost.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label7.ForeColor = Color.DimGray;
            label7.Location = new Point(3, 0);
            label7.Name = "label7";
            label7.Size = new Size(144, 50);
            label7.TabIndex = 6;
            label7.Text = "หน่วย :";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_small_unit
            // 
            textBox_small_unit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_small_unit.BackColor = Color.FromArgb(192, 255, 192);
            textBox_small_unit.Enabled = false;
            textBox_small_unit.Font = new Font("Segoe UI", 13.8F);
            textBox_small_unit.Location = new Point(153, 6);
            textBox_small_unit.Name = "textBox_small_unit";
            textBox_small_unit.Size = new Size(111, 38);
            textBox_small_unit.TabIndex = 6;
            textBox_small_unit.TabStop = false;
            textBox_small_unit.TextAlign = HorizontalAlignment.Center;
            textBox_small_unit.KeyDown += textBox_KeyDown;
            // 
            // label_small_price
            // 
            label_small_price.AutoSize = true;
            label_small_price.Dock = DockStyle.Fill;
            label_small_price.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_small_price.ForeColor = Color.DimGray;
            label_small_price.Location = new Point(270, 0);
            label_small_price.Name = "label_small_price";
            label_small_price.Size = new Size(124, 50);
            label_small_price.TabIndex = 6;
            label_small_price.Text = "ราคาขาย :";
            label_small_price.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_small_price
            // 
            textBox_small_price.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_small_price.BackColor = Color.FromArgb(192, 255, 192);
            textBox_small_price.Enabled = false;
            textBox_small_price.Font = new Font("Segoe UI", 13.8F);
            textBox_small_price.Location = new Point(400, 6);
            textBox_small_price.Margin = new Padding(3, 3, 10, 3);
            textBox_small_price.Name = "textBox_small_price";
            textBox_small_price.Size = new Size(104, 38);
            textBox_small_price.TabIndex = 6;
            textBox_small_price.TabStop = false;
            textBox_small_price.TextAlign = HorizontalAlignment.Center;
            textBox_small_price.KeyDown += textBox_KeyDown;
            textBox_small_price.KeyPress += textBox_small_price_KeyPress;
            // 
            // label_small_cost_avg
            // 
            label_small_cost_avg.AutoSize = true;
            label_small_cost_avg.Dock = DockStyle.Fill;
            label_small_cost_avg.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_small_cost_avg.ForeColor = Color.DimGray;
            label_small_cost_avg.Location = new Point(3, 100);
            label_small_cost_avg.Name = "label_small_cost_avg";
            label_small_cost_avg.Size = new Size(144, 50);
            label_small_cost_avg.TabIndex = 9;
            label_small_cost_avg.Text = "ต้นทุนเฉลี่ย :";
            label_small_cost_avg.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_small_cost_avg
            // 
            textBox_small_cost_avg.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_small_cost_avg.BackColor = Color.FromArgb(192, 255, 192);
            textBox_small_cost_avg.Enabled = false;
            textBox_small_cost_avg.Font = new Font("Segoe UI", 13.8F);
            textBox_small_cost_avg.Location = new Point(153, 106);
            textBox_small_cost_avg.Name = "textBox_small_cost_avg";
            textBox_small_cost_avg.Size = new Size(111, 38);
            textBox_small_cost_avg.TabIndex = 8;
            textBox_small_cost_avg.TabStop = false;
            textBox_small_cost_avg.TextAlign = HorizontalAlignment.Center;
            // 
            // label_small_qty
            // 
            label_small_qty.AutoSize = true;
            label_small_qty.Dock = DockStyle.Fill;
            label_small_qty.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_small_qty.ForeColor = Color.DimGray;
            label_small_qty.Location = new Point(270, 50);
            label_small_qty.Name = "label_small_qty";
            label_small_qty.Size = new Size(124, 50);
            label_small_qty.TabIndex = 6;
            label_small_qty.Text = "คงเหลือ :";
            label_small_qty.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_small_qty
            // 
            textBox_small_qty.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_small_qty.BackColor = Color.FromArgb(192, 255, 192);
            textBox_small_qty.Enabled = false;
            textBox_small_qty.Font = new Font("Segoe UI", 13.8F);
            textBox_small_qty.Location = new Point(400, 56);
            textBox_small_qty.Margin = new Padding(3, 3, 10, 3);
            textBox_small_qty.Name = "textBox_small_qty";
            textBox_small_qty.Size = new Size(104, 38);
            textBox_small_qty.TabIndex = 4;
            textBox_small_qty.TabStop = false;
            textBox_small_qty.TextAlign = HorizontalAlignment.Center;
            textBox_small_qty.KeyDown += textBox_KeyDown;
            textBox_small_qty.KeyPress += textBox_small_qty_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(3, 50);
            label3.Name = "label3";
            label3.Size = new Size(144, 50);
            label3.TabIndex = 9;
            label3.Text = "ต้นทุนล่าสุด :";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_small_cost_last
            // 
            textBox_small_cost_last.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_small_cost_last.BackColor = Color.FromArgb(192, 255, 192);
            textBox_small_cost_last.Enabled = false;
            textBox_small_cost_last.Font = new Font("Segoe UI", 13.8F);
            textBox_small_cost_last.Location = new Point(153, 56);
            textBox_small_cost_last.Name = "textBox_small_cost_last";
            textBox_small_cost_last.Size = new Size(111, 38);
            textBox_small_cost_last.TabIndex = 8;
            textBox_small_cost_last.TabStop = false;
            textBox_small_cost_last.TextAlign = HorizontalAlignment.Center;
            textBox_small_cost_last.KeyDown += textBox_KeyDown;
            textBox_small_cost_last.KeyPress += textBox_small_cost_last_KeyPress;
            // 
            // tableLayoutPanel_affective
            // 
            tableLayoutPanel_affective.BackColor = Color.Transparent;
            tableLayoutPanel_affective.ColumnCount = 2;
            tableLayoutPanel_affective.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_affective.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_affective.Controls.Add(button_item_weight, 0, 0);
            tableLayoutPanel_affective.Controls.Add(button_effective_member, 1, 1);
            tableLayoutPanel_affective.Controls.Add(button_effective_promotion, 1, 0);
            tableLayoutPanel_affective.Controls.Add(button_sale_vat, 0, 1);
            tableLayoutPanel_affective.Controls.Add(button_effective_hotkey, 1, 2);
            tableLayoutPanel_affective.Controls.Add(button_sale_negative, 0, 2);
            tableLayoutPanel_affective.Dock = DockStyle.Bottom;
            tableLayoutPanel_affective.Location = new Point(15, 428);
            tableLayoutPanel_affective.Margin = new Padding(9);
            tableLayoutPanel_affective.Name = "tableLayoutPanel_affective";
            tableLayoutPanel_affective.RowCount = 3;
            tableLayoutPanel_affective.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_affective.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_affective.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_affective.Size = new Size(514, 157);
            tableLayoutPanel_affective.TabIndex = 19;
            tableLayoutPanel_affective.Visible = false;
            // 
            // button_item_weight
            // 
            button_item_weight.AutoSize = true;
            button_item_weight.BackgroundImageLayout = ImageLayout.Zoom;
            button_item_weight.Dock = DockStyle.Fill;
            button_item_weight.FlatAppearance.BorderSize = 0;
            button_item_weight.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_item_weight.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_item_weight.FlatStyle = FlatStyle.Flat;
            button_item_weight.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_item_weight.ForeColor = Color.DimGray;
            button_item_weight.ImageAlign = ContentAlignment.MiddleLeft;
            button_item_weight.Location = new Point(3, 3);
            button_item_weight.Name = "button_item_weight";
            button_item_weight.Size = new Size(251, 46);
            button_item_weight.TabIndex = 15;
            button_item_weight.TabStop = false;
            button_item_weight.Text = "สินค้าชั่งน้ำหนัก";
            button_item_weight.TextAlign = ContentAlignment.MiddleLeft;
            button_item_weight.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_item_weight.UseVisualStyleBackColor = true;
            button_item_weight.Click += button_status_Click;
            button_item_weight.MouseEnter += button_MouseEnter;
            button_item_weight.MouseLeave += button_MouseLeave;
            // 
            // button_effective_member
            // 
            button_effective_member.AutoSize = true;
            button_effective_member.Dock = DockStyle.Fill;
            button_effective_member.FlatAppearance.BorderSize = 0;
            button_effective_member.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_effective_member.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_effective_member.FlatStyle = FlatStyle.Flat;
            button_effective_member.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_effective_member.ForeColor = Color.DimGray;
            button_effective_member.ImageAlign = ContentAlignment.MiddleLeft;
            button_effective_member.Location = new Point(260, 55);
            button_effective_member.Name = "button_effective_member";
            button_effective_member.Size = new Size(251, 46);
            button_effective_member.TabIndex = 18;
            button_effective_member.TabStop = false;
            button_effective_member.Text = "ใช้กับสมาชิก";
            button_effective_member.TextAlign = ContentAlignment.MiddleLeft;
            button_effective_member.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_effective_member.UseVisualStyleBackColor = true;
            button_effective_member.Click += button_status_Click;
            button_effective_member.MouseEnter += button_MouseEnter;
            button_effective_member.MouseLeave += button_MouseLeave;
            // 
            // button_effective_promotion
            // 
            button_effective_promotion.AutoSize = true;
            button_effective_promotion.Dock = DockStyle.Fill;
            button_effective_promotion.FlatAppearance.BorderSize = 0;
            button_effective_promotion.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_effective_promotion.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_effective_promotion.FlatStyle = FlatStyle.Flat;
            button_effective_promotion.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_effective_promotion.ForeColor = Color.DimGray;
            button_effective_promotion.ImageAlign = ContentAlignment.MiddleLeft;
            button_effective_promotion.Location = new Point(260, 3);
            button_effective_promotion.Name = "button_effective_promotion";
            button_effective_promotion.Size = new Size(251, 46);
            button_effective_promotion.TabIndex = 14;
            button_effective_promotion.TabStop = false;
            button_effective_promotion.Text = "ใช้กับโปรโมชั่น";
            button_effective_promotion.TextAlign = ContentAlignment.MiddleLeft;
            button_effective_promotion.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_effective_promotion.UseVisualStyleBackColor = true;
            button_effective_promotion.Click += button_status_Click;
            button_effective_promotion.MouseEnter += button_MouseEnter;
            button_effective_promotion.MouseLeave += button_MouseLeave;
            // 
            // button_sale_vat
            // 
            button_sale_vat.AutoSize = true;
            button_sale_vat.Dock = DockStyle.Fill;
            button_sale_vat.FlatAppearance.BorderSize = 0;
            button_sale_vat.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_sale_vat.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_sale_vat.FlatStyle = FlatStyle.Flat;
            button_sale_vat.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_sale_vat.ForeColor = Color.DimGray;
            button_sale_vat.ImageAlign = ContentAlignment.MiddleLeft;
            button_sale_vat.Location = new Point(3, 55);
            button_sale_vat.Name = "button_sale_vat";
            button_sale_vat.Size = new Size(251, 46);
            button_sale_vat.TabIndex = 17;
            button_sale_vat.TabStop = false;
            button_sale_vat.Text = "มีภาษีขาย";
            button_sale_vat.TextAlign = ContentAlignment.MiddleLeft;
            button_sale_vat.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_sale_vat.UseVisualStyleBackColor = true;
            button_sale_vat.Click += button_status_Click;
            button_sale_vat.MouseEnter += button_MouseEnter;
            button_sale_vat.MouseLeave += button_MouseLeave;
            // 
            // button_effective_hotkey
            // 
            button_effective_hotkey.AutoSize = true;
            button_effective_hotkey.Dock = DockStyle.Fill;
            button_effective_hotkey.FlatAppearance.BorderSize = 0;
            button_effective_hotkey.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_effective_hotkey.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_effective_hotkey.FlatStyle = FlatStyle.Flat;
            button_effective_hotkey.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_effective_hotkey.ForeColor = Color.DimGray;
            button_effective_hotkey.ImageAlign = ContentAlignment.MiddleLeft;
            button_effective_hotkey.Location = new Point(260, 107);
            button_effective_hotkey.Name = "button_effective_hotkey";
            button_effective_hotkey.Size = new Size(251, 47);
            button_effective_hotkey.TabIndex = 7;
            button_effective_hotkey.TabStop = false;
            button_effective_hotkey.Text = "คีย์ลัดหน้าขาย";
            button_effective_hotkey.TextAlign = ContentAlignment.MiddleLeft;
            button_effective_hotkey.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_effective_hotkey.UseVisualStyleBackColor = true;
            button_effective_hotkey.Click += button_status_Click;
            button_effective_hotkey.MouseEnter += button_MouseEnter;
            button_effective_hotkey.MouseLeave += button_MouseLeave;
            // 
            // button_sale_negative
            // 
            button_sale_negative.AutoSize = true;
            button_sale_negative.Dock = DockStyle.Fill;
            button_sale_negative.FlatAppearance.BorderSize = 0;
            button_sale_negative.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_sale_negative.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_sale_negative.FlatStyle = FlatStyle.Flat;
            button_sale_negative.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_sale_negative.ForeColor = Color.DimGray;
            button_sale_negative.ImageAlign = ContentAlignment.MiddleLeft;
            button_sale_negative.Location = new Point(3, 107);
            button_sale_negative.Name = "button_sale_negative";
            button_sale_negative.Size = new Size(251, 47);
            button_sale_negative.TabIndex = 16;
            button_sale_negative.TabStop = false;
            button_sale_negative.Text = "ขายติดลบ";
            button_sale_negative.TextAlign = ContentAlignment.MiddleLeft;
            button_sale_negative.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_sale_negative.UseVisualStyleBackColor = true;
            button_sale_negative.Click += button_status_Click;
            button_sale_negative.MouseEnter += button_MouseEnter;
            button_sale_negative.MouseLeave += button_MouseLeave;
            // 
            // timer_search
            // 
            timer_search.Tick += timer_search_Tick;
            // 
            // button_delete_picture
            // 
            button_delete_picture.BackColor = Color.FromArgb(255, 192, 192);
            button_delete_picture.Dock = DockStyle.Fill;
            button_delete_picture.Enabled = false;
            button_delete_picture.FlatAppearance.BorderSize = 0;
            button_delete_picture.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_delete_picture.Location = new Point(342, 0);
            button_delete_picture.Margin = new Padding(0);
            button_delete_picture.Name = "button_delete_picture";
            button_delete_picture.Size = new Size(172, 50);
            button_delete_picture.TabIndex = 4;
            button_delete_picture.TabStop = false;
            button_delete_picture.Text = "ลบภาพ";
            button_delete_picture.TextAlign = ContentAlignment.MiddleRight;
            button_delete_picture.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_delete_picture.UseVisualStyleBackColor = false;
            button_delete_picture.Click += button_delete_picture_Click;
            button_delete_picture.MouseEnter += button_MouseEnter;
            button_delete_picture.MouseLeave += button_MouseLeave;
            // 
            // button_edit_picture
            // 
            button_edit_picture.BackColor = Color.FromArgb(128, 255, 128);
            button_edit_picture.Dock = DockStyle.Fill;
            button_edit_picture.Enabled = false;
            button_edit_picture.FlatAppearance.BorderSize = 0;
            button_edit_picture.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_edit_picture.Location = new Point(0, 0);
            button_edit_picture.Margin = new Padding(0);
            button_edit_picture.Name = "button_edit_picture";
            button_edit_picture.Size = new Size(171, 50);
            button_edit_picture.TabIndex = 4;
            button_edit_picture.TabStop = false;
            button_edit_picture.Text = "เลือกภาพ";
            button_edit_picture.TextAlign = ContentAlignment.MiddleRight;
            button_edit_picture.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_edit_picture.UseVisualStyleBackColor = false;
            button_edit_picture.Click += button_edit_picture_Click;
            button_edit_picture.MouseEnter += button_MouseEnter;
            button_edit_picture.MouseLeave += button_MouseLeave;
            // 
            // pictureBox_item
            // 
            pictureBox_item.BackColor = Color.Transparent;
            pictureBox_item.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox_item.Dock = DockStyle.Fill;
            pictureBox_item.Enabled = false;
            pictureBox_item.Location = new Point(15, 51);
            pictureBox_item.Margin = new Padding(10, 10, 10, 3);
            pictureBox_item.Name = "pictureBox_item";
            pictureBox_item.Size = new Size(514, 158);
            pictureBox_item.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_item.TabIndex = 3;
            pictureBox_item.TabStop = false;
            pictureBox_item.Visible = false;
            // 
            // tableLayoutPanel_button_picture
            // 
            tableLayoutPanel_button_picture.ColumnCount = 3;
            tableLayoutPanel_button_picture.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_button_picture.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_button_picture.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_button_picture.Controls.Add(button_delete_picture, 2, 0);
            tableLayoutPanel_button_picture.Controls.Add(button_edit_picture, 0, 0);
            tableLayoutPanel_button_picture.Controls.Add(button_camera, 1, 0);
            tableLayoutPanel_button_picture.Dock = DockStyle.Bottom;
            tableLayoutPanel_button_picture.Location = new Point(15, 209);
            tableLayoutPanel_button_picture.Margin = new Padding(10);
            tableLayoutPanel_button_picture.Name = "tableLayoutPanel_button_picture";
            tableLayoutPanel_button_picture.RowCount = 1;
            tableLayoutPanel_button_picture.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_button_picture.Size = new Size(514, 50);
            tableLayoutPanel_button_picture.TabIndex = 4;
            tableLayoutPanel_button_picture.Visible = false;
            // 
            // button_camera
            // 
            button_camera.BackColor = Color.FromArgb(192, 192, 255);
            button_camera.BackgroundImageLayout = ImageLayout.Zoom;
            button_camera.Dock = DockStyle.Fill;
            button_camera.Enabled = false;
            button_camera.FlatAppearance.BorderSize = 0;
            button_camera.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_camera.Location = new Point(171, 0);
            button_camera.Margin = new Padding(0);
            button_camera.Name = "button_camera";
            button_camera.Size = new Size(171, 50);
            button_camera.TabIndex = 4;
            button_camera.TabStop = false;
            button_camera.Text = "ถ่ายภาพ";
            button_camera.TextAlign = ContentAlignment.MiddleRight;
            button_camera.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_camera.UseVisualStyleBackColor = false;
            button_camera.Click += button_camera_Click;
            button_camera.MouseEnter += button_MouseEnter;
            button_camera.MouseLeave += button_MouseLeave;
            // 
            // customGroupBox_picture
            // 
            customGroupBox_picture.AutoSize = true;
            customGroupBox_picture.BackColor = Color.White;
            customGroupBox_picture.BorderColor = Color.Lime;
            customGroupBox_picture.BorderRadius = 30;
            customGroupBox_picture.BorderThickness = 10;
            customGroupBox_picture.Controls.Add(pictureBox_item);
            customGroupBox_picture.Controls.Add(tableLayoutPanel_button_picture);
            customGroupBox_picture.Dock = DockStyle.Fill;
            customGroupBox_picture.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            customGroupBox_picture.Location = new Point(3, 3);
            customGroupBox_picture.Name = "customGroupBox_picture";
            customGroupBox_picture.Padding = new Padding(15);
            customGroupBox_picture.Size = new Size(544, 274);
            customGroupBox_picture.TabIndex = 5;
            customGroupBox_picture.TabStop = false;
            customGroupBox_picture.Text = "รูปภาพ";
            // 
            // large_qty
            // 
            large_qty.HeaderText = "large_qty";
            large_qty.MinimumWidth = 6;
            large_qty.Name = "large_qty";
            large_qty.ReadOnly = true;
            large_qty.Visible = false;
            large_qty.Width = 125;
            // 
            // large_cost_avg
            // 
            large_cost_avg.HeaderText = "large_cost_avg";
            large_cost_avg.MinimumWidth = 6;
            large_cost_avg.Name = "large_cost_avg";
            large_cost_avg.ReadOnly = true;
            large_cost_avg.Visible = false;
            large_cost_avg.Width = 125;
            // 
            // large_cost_last
            // 
            large_cost_last.HeaderText = "large_cost_last";
            large_cost_last.MinimumWidth = 6;
            large_cost_last.Name = "large_cost_last";
            large_cost_last.ReadOnly = true;
            large_cost_last.Visible = false;
            large_cost_last.Width = 125;
            // 
            // large_price
            // 
            large_price.HeaderText = "large_price";
            large_price.MinimumWidth = 6;
            large_price.Name = "large_price";
            large_price.ReadOnly = true;
            large_price.Visible = false;
            large_price.Width = 125;
            // 
            // large_unit
            // 
            large_unit.HeaderText = "large_unit";
            large_unit.MinimumWidth = 6;
            large_unit.Name = "large_unit";
            large_unit.ReadOnly = true;
            large_unit.Visible = false;
            large_unit.Width = 125;
            // 
            // large_barcode
            // 
            large_barcode.HeaderText = "large_barcode";
            large_barcode.MinimumWidth = 6;
            large_barcode.Name = "large_barcode";
            large_barcode.ReadOnly = true;
            large_barcode.Visible = false;
            large_barcode.Width = 125;
            // 
            // medium_qty_small
            // 
            medium_qty_small.HeaderText = "medium_qty_small";
            medium_qty_small.MinimumWidth = 6;
            medium_qty_small.Name = "medium_qty_small";
            medium_qty_small.ReadOnly = true;
            medium_qty_small.Visible = false;
            medium_qty_small.Width = 125;
            // 
            // medium_qty
            // 
            medium_qty.HeaderText = "medium_qty";
            medium_qty.MinimumWidth = 6;
            medium_qty.Name = "medium_qty";
            medium_qty.ReadOnly = true;
            medium_qty.Visible = false;
            medium_qty.Width = 125;
            // 
            // medium_cost_avg
            // 
            medium_cost_avg.HeaderText = "medium_cost_avg";
            medium_cost_avg.MinimumWidth = 6;
            medium_cost_avg.Name = "medium_cost_avg";
            medium_cost_avg.ReadOnly = true;
            medium_cost_avg.Visible = false;
            medium_cost_avg.Width = 125;
            // 
            // medium_cost_last
            // 
            medium_cost_last.HeaderText = "medium_cost_last";
            medium_cost_last.MinimumWidth = 6;
            medium_cost_last.Name = "medium_cost_last";
            medium_cost_last.ReadOnly = true;
            medium_cost_last.Visible = false;
            medium_cost_last.Width = 125;
            // 
            // medium_price
            // 
            medium_price.HeaderText = "medium_price";
            medium_price.MinimumWidth = 6;
            medium_price.Name = "medium_price";
            medium_price.ReadOnly = true;
            medium_price.Visible = false;
            medium_price.Width = 125;
            // 
            // medium_unit
            // 
            medium_unit.HeaderText = "medium_unit";
            medium_unit.MinimumWidth = 6;
            medium_unit.Name = "medium_unit";
            medium_unit.ReadOnly = true;
            medium_unit.Visible = false;
            medium_unit.Width = 125;
            // 
            // medium_barcode
            // 
            medium_barcode.HeaderText = "medium_barcode";
            medium_barcode.MinimumWidth = 6;
            medium_barcode.Name = "medium_barcode";
            medium_barcode.ReadOnly = true;
            medium_barcode.Visible = false;
            medium_barcode.Width = 125;
            // 
            // small_qty
            // 
            small_qty.HeaderText = "small_qty";
            small_qty.MinimumWidth = 6;
            small_qty.Name = "small_qty";
            small_qty.ReadOnly = true;
            small_qty.Visible = false;
            small_qty.Width = 125;
            // 
            // small_cost_avg
            // 
            small_cost_avg.HeaderText = "small_cost_avg";
            small_cost_avg.MinimumWidth = 6;
            small_cost_avg.Name = "small_cost_avg";
            small_cost_avg.ReadOnly = true;
            small_cost_avg.Visible = false;
            small_cost_avg.Width = 125;
            // 
            // small_cost_last
            // 
            small_cost_last.HeaderText = "small_cost_last";
            small_cost_last.MinimumWidth = 6;
            small_cost_last.Name = "small_cost_last";
            small_cost_last.ReadOnly = true;
            small_cost_last.Visible = false;
            small_cost_last.Width = 125;
            // 
            // small_price
            // 
            small_price.HeaderText = "small_price";
            small_price.MinimumWidth = 6;
            small_price.Name = "small_price";
            small_price.ReadOnly = true;
            small_price.Visible = false;
            small_price.Width = 125;
            // 
            // small_unit
            // 
            small_unit.HeaderText = "small_unit";
            small_unit.MinimumWidth = 6;
            small_unit.Name = "small_unit";
            small_unit.ReadOnly = true;
            small_unit.Visible = false;
            small_unit.Width = 125;
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
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            name.DefaultCellStyle = dataGridViewCellStyle1;
            name.HeaderText = "สินค้า (0)";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.ReadOnly = true;
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
            // group_main
            // 
            group_main.HeaderText = "group_main";
            group_main.MinimumWidth = 6;
            group_main.Name = "group_main";
            group_main.ReadOnly = true;
            group_main.Visible = false;
            group_main.Width = 125;
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
            // large_qty_small
            // 
            large_qty_small.HeaderText = "large_qty_small";
            large_qty_small.MinimumWidth = 6;
            large_qty_small.Name = "large_qty_small";
            large_qty_small.ReadOnly = true;
            large_qty_small.Visible = false;
            large_qty_small.Width = 125;
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Gray;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Lime;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView_item.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView_item.ColumnHeadersHeight = 10;
            dataGridView_item.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_item.Columns.AddRange(new DataGridViewColumn[] { code, group_main, group_sub, name, small_barcode, small_unit, small_price, small_cost_last, small_cost_avg, small_qty, medium_barcode, medium_unit, medium_price, medium_cost_last, medium_cost_avg, medium_qty, medium_qty_small, large_barcode, large_unit, large_price, large_cost_last, large_cost_avg, large_qty, large_qty_small, sale_vat, sale_negative, item_weight, effective_promotion, effective_member, effective_hotkey, delete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 13.8F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView_item.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridView_item.Size = new Size(400, 834);
            dataGridView_item.TabIndex = 0;
            dataGridView_item.TabStop = false;
            dataGridView_item.CellMouseDown += dataGridView_item_CellMouseDown;
            dataGridView_item.CellMouseEnter += dataGridView_item_CellMouseEnter;
            dataGridView_item.CellMouseLeave += dataGridView_item_CellMouseLeave;
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
            // sale_negative
            // 
            sale_negative.HeaderText = "sale_negative";
            sale_negative.MinimumWidth = 6;
            sale_negative.Name = "sale_negative";
            sale_negative.ReadOnly = true;
            sale_negative.Visible = false;
            sale_negative.Width = 125;
            // 
            // item_weight
            // 
            item_weight.HeaderText = "item_weight";
            item_weight.MinimumWidth = 6;
            item_weight.Name = "item_weight";
            item_weight.ReadOnly = true;
            item_weight.Visible = false;
            item_weight.Width = 125;
            // 
            // effective_promotion
            // 
            effective_promotion.HeaderText = "effective_promotion";
            effective_promotion.MinimumWidth = 6;
            effective_promotion.Name = "effective_promotion";
            effective_promotion.ReadOnly = true;
            effective_promotion.Visible = false;
            effective_promotion.Width = 125;
            // 
            // effective_member
            // 
            effective_member.HeaderText = "effective_member";
            effective_member.MinimumWidth = 6;
            effective_member.Name = "effective_member";
            effective_member.ReadOnly = true;
            effective_member.Visible = false;
            effective_member.Width = 125;
            // 
            // effective_hotkey
            // 
            effective_hotkey.HeaderText = "effective_hotkey";
            effective_hotkey.MinimumWidth = 6;
            effective_hotkey.Name = "effective_hotkey";
            effective_hotkey.ReadOnly = true;
            effective_hotkey.Visible = false;
            effective_hotkey.Width = 125;
            // 
            // delete
            // 
            delete.HeaderText = "";
            delete.MinimumWidth = 6;
            delete.Name = "delete";
            delete.ReadOnly = true;
            delete.Resizable = DataGridViewTriState.True;
            delete.SortMode = DataGridViewColumnSortMode.Automatic;
            delete.Width = 50;
            // 
            // tableLayoutPanel_back_detail_item
            // 
            tableLayoutPanel_back_detail_item.Anchor = AnchorStyles.Top;
            tableLayoutPanel_back_detail_item.AutoSize = true;
            tableLayoutPanel_back_detail_item.ColumnCount = 1;
            tableLayoutPanel_back_detail_item.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back_detail_item.Controls.Add(customGroupBox_item, 0, 1);
            tableLayoutPanel_back_detail_item.Controls.Add(customGroupBox_picture, 0, 0);
            tableLayoutPanel_back_detail_item.Location = new Point(68, 0);
            tableLayoutPanel_back_detail_item.Name = "tableLayoutPanel_back_detail_item";
            tableLayoutPanel_back_detail_item.RowCount = 2;
            tableLayoutPanel_back_detail_item.RowStyles.Add(new RowStyle(SizeType.Absolute, 280F));
            tableLayoutPanel_back_detail_item.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back_detail_item.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_back_detail_item.Size = new Size(550, 886);
            tableLayoutPanel_back_detail_item.TabIndex = 13;
            // 
            // panel_detail
            // 
            panel_detail.AutoScroll = true;
            panel_detail.AutoSize = true;
            panel_detail.BackColor = Color.White;
            panel_detail.Controls.Add(tableLayoutPanel_back_detail_item);
            panel_detail.Dock = DockStyle.Fill;
            panel_detail.Location = new Point(410, 10);
            panel_detail.Margin = new Padding(10, 10, 0, 0);
            panel_detail.Name = "panel_detail";
            panel_detail.Size = new Size(714, 824);
            panel_detail.TabIndex = 1;
            // 
            // tableLayoutPanel_bottom
            // 
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
            tableLayoutPanel_bottom.Size = new Size(1124, 834);
            tableLayoutPanel_bottom.TabIndex = 2;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.Lime;
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_top, 0, 0);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_bottom, 0, 1);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(1124, 934);
            tableLayoutPanel_back.TabIndex = 4;
            // 
            // tableLayoutPanel_top
            // 
            tableLayoutPanel_top.BackColor = Color.Lime;
            tableLayoutPanel_top.ColumnCount = 6;
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.142857F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714283F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714283F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714283F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.142857F));
            tableLayoutPanel_top.Controls.Add(panel_search, 0, 0);
            tableLayoutPanel_top.Controls.Add(button_cancel, 4, 0);
            tableLayoutPanel_top.Controls.Add(button_edit_save, 3, 0);
            tableLayoutPanel_top.Controls.Add(button_add_save, 2, 0);
            tableLayoutPanel_top.Dock = DockStyle.Fill;
            tableLayoutPanel_top.Location = new Point(0, 0);
            tableLayoutPanel_top.Margin = new Padding(0);
            tableLayoutPanel_top.Name = "tableLayoutPanel_top";
            tableLayoutPanel_top.RowCount = 1;
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_top.Size = new Size(1124, 100);
            tableLayoutPanel_top.TabIndex = 1;
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
            panel_search.TabIndex = 0;
            // 
            // label_search
            // 
            label_search.Dock = DockStyle.Fill;
            label_search.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold);
            label_search.ForeColor = Color.Gray;
            label_search.Location = new Point(0, 0);
            label_search.Name = "label_search";
            label_search.Size = new Size(400, 64);
            label_search.TabIndex = 1;
            label_search.Text = "--";
            label_search.TextAlign = ContentAlignment.BottomRight;
            // 
            // textBox_search
            // 
            textBox_search.BackColor = Color.White;
            textBox_search.BorderStyle = BorderStyle.None;
            textBox_search.Dock = DockStyle.Bottom;
            textBox_search.Font = new Font("Segoe UI", 16.2F);
            textBox_search.Location = new Point(0, 64);
            textBox_search.Margin = new Padding(0);
            textBox_search.Name = "textBox_search";
            textBox_search.Size = new Size(400, 36);
            textBox_search.TabIndex = 0;
            textBox_search.TabStop = false;
            textBox_search.TextAlign = HorizontalAlignment.Center;
            textBox_search.TextChanged += textBox_search_TextChanged;
            // 
            // button_cancel
            // 
            button_cancel.BackColor = Color.Lime;
            button_cancel.BackgroundImageLayout = ImageLayout.Zoom;
            button_cancel.Dock = DockStyle.Fill;
            button_cancel.Enabled = false;
            button_cancel.FlatAppearance.BorderSize = 0;
            button_cancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_cancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 192);
            button_cancel.FlatStyle = FlatStyle.Flat;
            button_cancel.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            button_cancel.Location = new Point(863, 0);
            button_cancel.Margin = new Padding(0);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new Size(206, 100);
            button_cancel.TabIndex = 1;
            button_cancel.TabStop = false;
            button_cancel.Text = " ยกเลิก";
            button_cancel.TextAlign = ContentAlignment.BottomCenter;
            button_cancel.TextImageRelation = TextImageRelation.ImageAboveText;
            button_cancel.UseVisualStyleBackColor = false;
            button_cancel.Click += button_cancel_Click;
            button_cancel.MouseEnter += button_MouseEnter;
            button_cancel.MouseLeave += button_MouseLeave;
            // 
            // button_edit_save
            // 
            button_edit_save.BackColor = Color.Lime;
            button_edit_save.BackgroundImageLayout = ImageLayout.Zoom;
            button_edit_save.Dock = DockStyle.Fill;
            button_edit_save.Enabled = false;
            button_edit_save.FlatAppearance.BorderSize = 0;
            button_edit_save.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_edit_save.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 192);
            button_edit_save.FlatStyle = FlatStyle.Flat;
            button_edit_save.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            button_edit_save.Location = new Point(657, 0);
            button_edit_save.Margin = new Padding(0);
            button_edit_save.Name = "button_edit_save";
            button_edit_save.Size = new Size(206, 100);
            button_edit_save.TabIndex = 1;
            button_edit_save.TabStop = false;
            button_edit_save.Text = "แก้ไข";
            button_edit_save.TextAlign = ContentAlignment.BottomCenter;
            button_edit_save.TextImageRelation = TextImageRelation.ImageAboveText;
            button_edit_save.UseVisualStyleBackColor = false;
            button_edit_save.Click += button_edit_save_Click;
            button_edit_save.MouseEnter += button_MouseEnter;
            button_edit_save.MouseLeave += button_MouseLeave;
            // 
            // button_add_save
            // 
            button_add_save.BackColor = Color.Lime;
            button_add_save.BackgroundImageLayout = ImageLayout.Zoom;
            button_add_save.Dock = DockStyle.Fill;
            button_add_save.FlatAppearance.BorderSize = 0;
            button_add_save.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_add_save.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 192);
            button_add_save.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            button_add_save.Location = new Point(451, 0);
            button_add_save.Margin = new Padding(0);
            button_add_save.Name = "button_add_save";
            button_add_save.Size = new Size(206, 100);
            button_add_save.TabIndex = 1;
            button_add_save.TabStop = false;
            button_add_save.Text = " เพิ่ม";
            button_add_save.TextAlign = ContentAlignment.BottomCenter;
            button_add_save.TextImageRelation = TextImageRelation.ImageAboveText;
            button_add_save.UseVisualStyleBackColor = false;
            button_add_save.Click += button_add_item_Click;
            button_add_save.MouseEnter += button_MouseEnter;
            button_add_save.MouseLeave += button_MouseLeave;
            // 
            // timer_show
            // 
            timer_show.Interval = 50;
            timer_show.Tick += timer_show_Tick;
            // 
            // Form_Item_Detail_Small
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1124, 934);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Item_Detail_Small";
            Text = "Form_Item_Detail_Small";
            Load += Form_Item_Detail_Small_Load;
            customGroupBox_item.ResumeLayout(false);
            customGroupBox_item.PerformLayout();
            tableLayoutPanel_group.ResumeLayout(false);
            tableLayoutPanel_group.PerformLayout();
            tableLayoutPanel_item.ResumeLayout(false);
            tableLayoutPanel_item.PerformLayout();
            tableLayoutPanel_cost.ResumeLayout(false);
            tableLayoutPanel_cost.PerformLayout();
            tableLayoutPanel_affective.ResumeLayout(false);
            tableLayoutPanel_affective.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_item).EndInit();
            tableLayoutPanel_button_picture.ResumeLayout(false);
            customGroupBox_picture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).EndInit();
            tableLayoutPanel_back_detail_item.ResumeLayout(false);
            tableLayoutPanel_back_detail_item.PerformLayout();
            panel_detail.ResumeLayout(false);
            panel_detail.PerformLayout();
            tableLayoutPanel_bottom.ResumeLayout(false);
            tableLayoutPanel_bottom.PerformLayout();
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_top.ResumeLayout(false);
            panel_search.ResumeLayout(false);
            panel_search.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private CustomGroupBox customGroupBox_item;
        private Label label_item_name;
        public TextBox textBox_name;
        private System.Windows.Forms.Timer timer_search;
        private Button button_delete_picture;
        private Button button_edit_picture;
        private PictureBox pictureBox_item;
        private TableLayoutPanel tableLayoutPanel_button_picture;
        private Button button_camera;
        private CustomGroupBox customGroupBox_picture;
        private TextBox textBox_small_price;
        private TextBox textBox_small_qty;
        private TextBox textBox_small_unit;
        private Label label_small_qty;
        private Label label_small_price;
        private TextBox textBox_small_barcode;
        private Label label6;
        private Label label7;
        private DataGridViewTextBoxColumn large_qty;
        private DataGridViewTextBoxColumn large_cost_avg;
        private DataGridViewTextBoxColumn large_cost_last;
        private DataGridViewTextBoxColumn large_price;
        private DataGridViewTextBoxColumn large_unit;
        private DataGridViewTextBoxColumn large_barcode;
        private DataGridViewTextBoxColumn medium_qty_small;
        private DataGridViewTextBoxColumn medium_qty;
        private DataGridViewTextBoxColumn medium_cost_avg;
        private DataGridViewTextBoxColumn medium_cost_last;
        private DataGridViewTextBoxColumn medium_price;
        private DataGridViewTextBoxColumn medium_unit;
        private DataGridViewTextBoxColumn medium_barcode;
        private DataGridViewTextBoxColumn small_qty;
        private DataGridViewTextBoxColumn small_cost_avg;
        private DataGridViewTextBoxColumn small_cost_last;
        private DataGridViewTextBoxColumn small_price;
        private DataGridViewTextBoxColumn small_unit;
        private DataGridViewTextBoxColumn small_barcode;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn group_sub;
        private DataGridViewTextBoxColumn group_main;
        private DataGridViewTextBoxColumn code;
        private DataGridViewTextBoxColumn large_qty_small;
        private DataGridView dataGridView_item;
        private DataGridViewTextBoxColumn sale_vat;
        private DataGridViewTextBoxColumn sale_negative;
        private DataGridViewTextBoxColumn item_weight;
        private DataGridViewTextBoxColumn effective_promotion;
        private DataGridViewTextBoxColumn effective_member;
        private DataGridViewTextBoxColumn effective_hotkey;
        private DataGridViewImageColumn delete;
        private TableLayoutPanel tableLayoutPanel_back_detail_item;
        public Panel panel_detail;
        public TableLayoutPanel tableLayoutPanel_bottom;
        public TableLayoutPanel tableLayoutPanel_back;
        private TableLayoutPanel tableLayoutPanel_top;
        private Panel panel_search;
        private Label label_search;
        private TextBox textBox_search;
        private Button button_edit_save;
        private Button button_add_save;
        private Button button_cancel;
        private Button button_effective_hotkey;
        private TextBox textBox_small_cost_avg;
        private Label label_small_cost_avg;
        private TableLayoutPanel tableLayoutPanel_item;
        private TableLayoutPanel tableLayoutPanel_cost;
        private TableLayoutPanel tableLayoutPanel_group;
        public TextBox textBox_group_main;
        public TextBox textBox_group_sub;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox_small_cost_last;
        private Button button_effective_promotion;
        private Button button_item_weight;
        private Button button_sale_negative;
        private Button button_sale_vat;
        private Button button_effective_member;
        private TableLayoutPanel tableLayoutPanel_affective;
        private System.Windows.Forms.Timer timer_show;
    }
}