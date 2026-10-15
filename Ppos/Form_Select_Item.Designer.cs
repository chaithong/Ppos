namespace Ppos
{
    partial class Form_Select_Item
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Select_Item));
            customGroupBox_back = new CustomGroupBox();
            tableLayoutPanel_back = new TableLayoutPanel();
            dataGridView_item = new DataGridView();
            code = new DataGridViewTextBoxColumn();
            picture = new DataGridViewImageColumn();
            item_barcode = new DataGridViewTextBoxColumn();
            item_name = new DataGridViewTextBoxColumn();
            item_on_hand = new DataGridViewTextBoxColumn();
            item_unit = new DataGridViewTextBoxColumn();
            item_price = new DataGridViewTextBoxColumn();
            select = new DataGridViewImageColumn();
            textBox_search = new TextBox();
            backgroundWorker_search = new System.ComponentModel.BackgroundWorker();
            timer_search = new System.Windows.Forms.Timer(components);
            customGroupBox_back.SuspendLayout();
            tableLayoutPanel_back.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).BeginInit();
            SuspendLayout();
            // 
            // customGroupBox_back
            // 
            customGroupBox_back.BorderColor = Color.Cyan;
            customGroupBox_back.BorderRadius = 10;
            customGroupBox_back.BorderThickness = 10;
            customGroupBox_back.Controls.Add(tableLayoutPanel_back);
            customGroupBox_back.Dock = DockStyle.Fill;
            customGroupBox_back.Font = new Font("Segoe UI", 1F);
            customGroupBox_back.Location = new Point(0, 0);
            customGroupBox_back.Margin = new Padding(0);
            customGroupBox_back.Name = "customGroupBox_back";
            customGroupBox_back.Padding = new Padding(20);
            customGroupBox_back.Size = new Size(886, 565);
            customGroupBox_back.TabIndex = 4;
            customGroupBox_back.TabStop = false;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.Transparent;
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_back.Controls.Add(dataGridView_item, 0, 1);
            tableLayoutPanel_back.Controls.Add(textBox_search, 0, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(20, 23);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(846, 522);
            tableLayoutPanel_back.TabIndex = 2;
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
            dataGridViewCellStyle1.SelectionBackColor = Color.Cyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView_item.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_item.ColumnHeadersHeight = 50;
            dataGridView_item.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_item.Columns.AddRange(new DataGridViewColumn[] { code, picture, item_barcode, item_name, item_on_hand, item_unit, item_price, select });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.Cyan;
            dataGridViewCellStyle7.SelectionForeColor = Color.Black;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dataGridView_item.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridView_item.Dock = DockStyle.Fill;
            dataGridView_item.Enabled = false;
            dataGridView_item.GridColor = Color.Cyan;
            dataGridView_item.Location = new Point(0, 100);
            dataGridView_item.Margin = new Padding(0);
            dataGridView_item.MultiSelect = false;
            dataGridView_item.Name = "dataGridView_item";
            dataGridView_item.ReadOnly = true;
            dataGridView_item.RowHeadersVisible = false;
            dataGridView_item.RowHeadersWidth = 51;
            dataGridView_item.RowTemplate.Height = 50;
            dataGridView_item.RowTemplate.ReadOnly = true;
            dataGridView_item.ScrollBars = ScrollBars.None;
            dataGridView_item.Size = new Size(846, 422);
            dataGridView_item.TabIndex = 0;
            dataGridView_item.CellMouseDoubleClick += dataGridView_item_CellMouseDoubleClick;
            dataGridView_item.CellMouseEnter += dataGridView_item_CellMouseEnter;
            dataGridView_item.CellMouseLeave += dataGridView_item_CellMouseLeave;
            dataGridView_item.CellMouseUp += dataGridView_item_CellMouseUp;
            // 
            // code
            // 
            code.HeaderText = "";
            code.MinimumWidth = 6;
            code.Name = "code";
            code.ReadOnly = true;
            code.Visible = false;
            code.Width = 125;
            // 
            // picture
            // 
            picture.HeaderText = "0/0";
            picture.ImageLayout = DataGridViewImageCellLayout.Zoom;
            picture.MinimumWidth = 6;
            picture.Name = "picture";
            picture.ReadOnly = true;
            picture.Resizable = DataGridViewTriState.True;
            picture.SortMode = DataGridViewColumnSortMode.Automatic;
            picture.Width = 125;
            // 
            // item_barcode
            // 
            item_barcode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            item_barcode.DefaultCellStyle = dataGridViewCellStyle2;
            item_barcode.HeaderText = "บาร์โค้ด";
            item_barcode.MinimumWidth = 6;
            item_barcode.Name = "item_barcode";
            item_barcode.ReadOnly = true;
            item_barcode.Width = 109;
            // 
            // item_name
            // 
            item_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            item_name.DefaultCellStyle = dataGridViewCellStyle3;
            item_name.HeaderText = "ชื่อสินค้า";
            item_name.MinimumWidth = 6;
            item_name.Name = "item_name";
            item_name.ReadOnly = true;
            // 
            // item_on_hand
            // 
            item_on_hand.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            item_on_hand.DefaultCellStyle = dataGridViewCellStyle4;
            item_on_hand.HeaderText = "คงเหลือ";
            item_on_hand.MinimumWidth = 6;
            item_on_hand.Name = "item_on_hand";
            item_on_hand.ReadOnly = true;
            item_on_hand.Width = 107;
            // 
            // item_unit
            // 
            item_unit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            item_unit.DefaultCellStyle = dataGridViewCellStyle5;
            item_unit.HeaderText = "";
            item_unit.MinimumWidth = 6;
            item_unit.Name = "item_unit";
            item_unit.ReadOnly = true;
            item_unit.Width = 23;
            // 
            // item_price
            // 
            item_price.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            item_price.DefaultCellStyle = dataGridViewCellStyle6;
            item_price.HeaderText = "ราคา";
            item_price.MinimumWidth = 6;
            item_price.Name = "item_price";
            item_price.ReadOnly = true;
            item_price.Width = 86;
            // 
            // select
            // 
            select.HeaderText = "";
            select.MinimumWidth = 6;
            select.Name = "select";
            select.ReadOnly = true;
            select.Resizable = DataGridViewTriState.True;
            select.SortMode = DataGridViewColumnSortMode.Automatic;
            select.Width = 125;
            // 
            // textBox_search
            // 
            textBox_search.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_search.Enabled = false;
            textBox_search.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_search.Location = new Point(3, 24);
            textBox_search.Name = "textBox_search";
            textBox_search.Size = new Size(840, 51);
            textBox_search.TabIndex = 1;
            textBox_search.TextAlign = HorizontalAlignment.Center;
            textBox_search.TextChanged += textBox_search_TextChanged;
            textBox_search.KeyDown += textBox_search_KeyDown;
            textBox_search.Leave += textBox_search_Leave;
            // 
            // backgroundWorker_search
            // 
            backgroundWorker_search.DoWork += backgroundWorker_search_DoWork;
            backgroundWorker_search.RunWorkerCompleted += backgroundWorker_search_RunWorkerCompleted;
            // 
            // timer_search
            // 
            timer_search.Tick += timer_search_Tick;
            // 
            // Form_Select_Item
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(886, 565);
            Controls.Add(customGroupBox_back);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "Form_Select_Item";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ค้นหาสินค้า";
            Load += Form_Select_Item_Load;
            customGroupBox_back.ResumeLayout(false);
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_back.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CustomGroupBox customGroupBox_back;
        private TableLayoutPanel tableLayoutPanel_back;
        private DataGridView dataGridView_item;
        private TextBox textBox_search;
        private System.ComponentModel.BackgroundWorker backgroundWorker_search;
        private System.Windows.Forms.Timer timer_search;
        private DataGridViewTextBoxColumn code;
        private DataGridViewImageColumn picture;
        private DataGridViewTextBoxColumn item_barcode;
        private DataGridViewTextBoxColumn item_name;
        private DataGridViewTextBoxColumn item_on_hand;
        private DataGridViewTextBoxColumn item_unit;
        private DataGridViewTextBoxColumn item_price;
        private DataGridViewImageColumn select;
    }
}