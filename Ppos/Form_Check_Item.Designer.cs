namespace Ppos
{
    partial class Form_Check_Item
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            textBox_search = new TextBox();
            dataGridView_item = new DataGridView();
            title = new DataGridViewTextBoxColumn();
            detail = new DataGridViewTextBoxColumn();
            customGroupBox_search = new CustomGroupBox();
            timer_search = new System.Windows.Forms.Timer(components);
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_top = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).BeginInit();
            customGroupBox_search.SuspendLayout();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_top.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_search
            // 
            textBox_search.BackColor = Color.FromArgb(128, 255, 255);
            textBox_search.BorderStyle = BorderStyle.None;
            textBox_search.Dock = DockStyle.Fill;
            textBox_search.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_search.ForeColor = Color.Black;
            textBox_search.Location = new Point(10, 13);
            textBox_search.Margin = new Padding(0);
            textBox_search.Name = "textBox_search";
            textBox_search.Size = new Size(474, 44);
            textBox_search.TabIndex = 0;
            textBox_search.TextAlign = HorizontalAlignment.Center;
            textBox_search.TextChanged += textBox_search_TextChanged;
            // 
            // dataGridView_item
            // 
            dataGridView_item.AllowUserToAddRows = false;
            dataGridView_item.AllowUserToDeleteRows = false;
            dataGridView_item.AllowUserToResizeColumns = false;
            dataGridView_item.AllowUserToResizeRows = false;
            dataGridView_item.BackgroundColor = Color.White;
            dataGridView_item.BorderStyle = BorderStyle.None;
            dataGridView_item.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView_item.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView_item.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_item.ColumnHeadersHeight = 4;
            dataGridView_item.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_item.Columns.AddRange(new DataGridViewColumn[] { title, detail });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.Desktop;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView_item.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView_item.Dock = DockStyle.Fill;
            dataGridView_item.GridColor = Color.White;
            dataGridView_item.Location = new Point(0, 105);
            dataGridView_item.Margin = new Padding(0);
            dataGridView_item.Name = "dataGridView_item";
            dataGridView_item.ReadOnly = true;
            dataGridView_item.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_item.RowHeadersVisible = false;
            dataGridView_item.RowHeadersWidth = 51;
            dataGridView_item.RowTemplate.Height = 50;
            dataGridView_item.ScrollBars = ScrollBars.None;
            dataGridView_item.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_item.Size = new Size(704, 496);
            dataGridView_item.TabIndex = 1;
            dataGridView_item.CellMouseEnter += dataGridView_item_CellMouseEnter;
            dataGridView_item.CellMouseLeave += dataGridView_item_CellMouseLeave;
            // 
            // title
            // 
            title.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            title.DefaultCellStyle = dataGridViewCellStyle2;
            title.HeaderText = "";
            title.MinimumWidth = 6;
            title.Name = "title";
            title.ReadOnly = true;
            // 
            // detail
            // 
            detail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            detail.DefaultCellStyle = dataGridViewCellStyle3;
            detail.HeaderText = "";
            detail.MinimumWidth = 6;
            detail.Name = "detail";
            detail.ReadOnly = true;
            // 
            // customGroupBox_search
            // 
            customGroupBox_search.BorderColor = Color.FromArgb(128, 255, 255);
            customGroupBox_search.BorderRadius = 30;
            customGroupBox_search.BorderThickness = 20;
            customGroupBox_search.Controls.Add(textBox_search);
            customGroupBox_search.Dock = DockStyle.Fill;
            customGroupBox_search.Font = new Font("Segoe UI", 1F);
            customGroupBox_search.Location = new Point(105, 18);
            customGroupBox_search.Name = "customGroupBox_search";
            customGroupBox_search.Padding = new Padding(10);
            customGroupBox_search.Size = new Size(494, 64);
            customGroupBox_search.TabIndex = 2;
            customGroupBox_search.TabStop = false;
            // 
            // timer_search
            // 
            timer_search.Tick += timer_search_Tick;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.Cyan;
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_top, 0, 0);
            tableLayoutPanel_back.Controls.Add(dataGridView_item, 0, 2);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 3;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(704, 601);
            tableLayoutPanel_back.TabIndex = 3;
            // 
            // tableLayoutPanel_top
            // 
            tableLayoutPanel_top.BackColor = Color.White;
            tableLayoutPanel_top.ColumnCount = 3;
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.Controls.Add(customGroupBox_search, 1, 1);
            tableLayoutPanel_top.Dock = DockStyle.Fill;
            tableLayoutPanel_top.Location = new Point(0, 0);
            tableLayoutPanel_top.Margin = new Padding(0);
            tableLayoutPanel_top.Name = "tableLayoutPanel_top";
            tableLayoutPanel_top.RowCount = 3;
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.Size = new Size(704, 100);
            tableLayoutPanel_top.TabIndex = 2;
            // 
            // Form_Check_Item
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(704, 601);
            Controls.Add(tableLayoutPanel_back);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Check_Item";
            Text = "Form_Check_Item";
            Load += Form_Check_Item_Load;
            Shown += Form_Check_Item_Shown;
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).EndInit();
            customGroupBox_search.ResumeLayout(false);
            customGroupBox_search.PerformLayout();
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_top.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox_search;
        private DataGridView dataGridView_item;
        private CustomGroupBox customGroupBox_search;
        private System.Windows.Forms.Timer timer_search;
        private TableLayoutPanel tableLayoutPanel_back;
        private TableLayoutPanel tableLayoutPanel_top;
        private DataGridViewTextBoxColumn title;
        private DataGridViewTextBoxColumn detail;
    }
}