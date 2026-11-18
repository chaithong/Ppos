namespace Ppos
{
    partial class Form_Setting_Invoice
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
            panel_invoice = new Panel();
            pictureBox_invoice = new PictureBox();
            customGroupBox_invoice = new CustomGroupBox();
            tableLayoutPanel_invoice = new TableLayoutPanel();
            textBox_trx_no = new TextBox();
            tableLayoutPanel_back = new TableLayoutPanel();
            customGroupBox_set = new CustomGroupBox();
            panel_set = new Panel();
            timer_search = new System.Windows.Forms.Timer(components);
            panel_invoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_invoice).BeginInit();
            customGroupBox_invoice.SuspendLayout();
            tableLayoutPanel_invoice.SuspendLayout();
            tableLayoutPanel_back.SuspendLayout();
            customGroupBox_set.SuspendLayout();
            SuspendLayout();
            // 
            // panel_invoice
            // 
            panel_invoice.BackColor = Color.White;
            panel_invoice.Controls.Add(pictureBox_invoice);
            panel_invoice.Dock = DockStyle.Fill;
            panel_invoice.Location = new Point(3, 53);
            panel_invoice.Name = "panel_invoice";
            panel_invoice.Size = new Size(515, 619);
            panel_invoice.TabIndex = 0;
            panel_invoice.Resize += panel_invoice_Resize;
            // 
            // pictureBox_invoice
            // 
            pictureBox_invoice.Location = new Point(0, 0);
            pictureBox_invoice.Margin = new Padding(0);
            pictureBox_invoice.Name = "pictureBox_invoice";
            pictureBox_invoice.Size = new Size(515, 619);
            pictureBox_invoice.TabIndex = 0;
            pictureBox_invoice.TabStop = false;
            pictureBox_invoice.DoubleClick += pictureBox_invoice_DoubleClick;
            // 
            // customGroupBox_invoice
            // 
            customGroupBox_invoice.BorderColor = Color.White;
            customGroupBox_invoice.BorderRadius = 30;
            customGroupBox_invoice.BorderThickness = 20;
            customGroupBox_invoice.Controls.Add(tableLayoutPanel_invoice);
            customGroupBox_invoice.Dock = DockStyle.Fill;
            customGroupBox_invoice.Font = new Font("Segoe UI", 1F);
            customGroupBox_invoice.Location = new Point(3, 3);
            customGroupBox_invoice.Name = "customGroupBox_invoice";
            customGroupBox_invoice.Padding = new Padding(10);
            customGroupBox_invoice.Size = new Size(541, 698);
            customGroupBox_invoice.TabIndex = 1;
            customGroupBox_invoice.TabStop = false;
            // 
            // tableLayoutPanel_invoice
            // 
            tableLayoutPanel_invoice.BackColor = Color.White;
            tableLayoutPanel_invoice.ColumnCount = 1;
            tableLayoutPanel_invoice.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_invoice.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_invoice.Controls.Add(panel_invoice, 0, 1);
            tableLayoutPanel_invoice.Controls.Add(textBox_trx_no, 0, 0);
            tableLayoutPanel_invoice.Dock = DockStyle.Fill;
            tableLayoutPanel_invoice.Location = new Point(10, 13);
            tableLayoutPanel_invoice.Name = "tableLayoutPanel_invoice";
            tableLayoutPanel_invoice.RowCount = 2;
            tableLayoutPanel_invoice.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_invoice.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_invoice.Size = new Size(521, 675);
            tableLayoutPanel_invoice.TabIndex = 0;
            // 
            // textBox_trx_no
            // 
            textBox_trx_no.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_trx_no.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_trx_no.Location = new Point(3, 3);
            textBox_trx_no.Name = "textBox_trx_no";
            textBox_trx_no.Size = new Size(515, 43);
            textBox_trx_no.TabIndex = 1;
            textBox_trx_no.TextAlign = HorizontalAlignment.Center;
            textBox_trx_no.TextChanged += textBox_trx_no_TextChanged;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.ColumnCount = 2;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_back.Controls.Add(customGroupBox_invoice, 0, 0);
            tableLayoutPanel_back.Controls.Add(customGroupBox_set, 1, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 1;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_back.Size = new Size(1094, 704);
            tableLayoutPanel_back.TabIndex = 2;
            // 
            // customGroupBox_set
            // 
            customGroupBox_set.BackColor = Color.Transparent;
            customGroupBox_set.BorderColor = Color.White;
            customGroupBox_set.BorderRadius = 30;
            customGroupBox_set.BorderThickness = 20;
            customGroupBox_set.Controls.Add(panel_set);
            customGroupBox_set.Dock = DockStyle.Fill;
            customGroupBox_set.Font = new Font("Segoe UI", 1F);
            customGroupBox_set.Location = new Point(550, 3);
            customGroupBox_set.Name = "customGroupBox_set";
            customGroupBox_set.Padding = new Padding(10);
            customGroupBox_set.Size = new Size(541, 698);
            customGroupBox_set.TabIndex = 2;
            customGroupBox_set.TabStop = false;
            // 
            // panel_set
            // 
            panel_set.Dock = DockStyle.Fill;
            panel_set.Location = new Point(10, 13);
            panel_set.Name = "panel_set";
            panel_set.Size = new Size(521, 675);
            panel_set.TabIndex = 0;
            // 
            // timer_search
            // 
            timer_search.Tick += timer_search_Tick;
            // 
            // Form_Setting_Invoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cyan;
            ClientSize = new Size(1094, 704);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Setting_Invoice";
            Text = "Form_Setting_Invoice";
            FormClosed += Form_Setting_Invoice_FormClosed;
            Load += Form_Setting_Invoice_Load;
            panel_invoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_invoice).EndInit();
            customGroupBox_invoice.ResumeLayout(false);
            tableLayoutPanel_invoice.ResumeLayout(false);
            tableLayoutPanel_invoice.PerformLayout();
            tableLayoutPanel_back.ResumeLayout(false);
            customGroupBox_set.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_invoice;
        private PictureBox pictureBox_invoice;
        private CustomGroupBox customGroupBox_invoice;
        private TableLayoutPanel tableLayoutPanel_invoice;
        private TextBox textBox_trx_no;
        private TableLayoutPanel tableLayoutPanel_back;
        private CustomGroupBox customGroupBox_set;
        private Panel panel_set;
        private System.Windows.Forms.Timer timer_search;
    }
}