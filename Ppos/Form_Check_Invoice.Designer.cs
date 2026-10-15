namespace Ppos
{
    partial class Form_Check_Invoice
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
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle32 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle27 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle29 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle30 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle31 = new DataGridViewCellStyle();
            dataGridView_invoice = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            seq = new DataGridViewTextBoxColumn();
            void_bill = new DataGridViewImageColumn();
            id = new DataGridViewTextBoxColumn();
            created_by = new DataGridViewTextBoxColumn();
            created_date = new DataGridViewTextBoxColumn();
            created_time = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            trx_no = new DataGridViewTextBoxColumn();
            id_member = new DataGridViewTextBoxColumn();
            phone = new DataGridViewTextBoxColumn();
            item_qty = new DataGridViewTextBoxColumn();
            price_sum = new DataGridViewTextBoxColumn();
            percent_discount_member = new DataGridViewTextBoxColumn();
            point_increase = new DataGridViewTextBoxColumn();
            discount_promotion = new DataGridViewTextBoxColumn();
            discount_member = new DataGridViewTextBoxColumn();
            discount_custom = new DataGridViewTextBoxColumn();
            discount_point = new DataGridViewTextBoxColumn();
            discount_round = new DataGridViewTextBoxColumn();
            price_net = new DataGridViewTextBoxColumn();
            pay_cash = new DataGridViewTextBoxColumn();
            pay_transfer = new DataGridViewTextBoxColumn();
            change = new DataGridViewTextBoxColumn();
            price_non_vat = new DataGridViewTextBoxColumn();
            price_vat = new DataGridViewTextBoxColumn();
            vat = new DataGridViewTextBoxColumn();
            void_date = new DataGridViewTextBoxColumn();
            return_date = new DataGridViewTextBoxColumn();
            trx_no_reference = new DataGridViewTextBoxColumn();
            detail = new DataGridViewImageColumn();
            Column2 = new DataGridViewTextBoxColumn();
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_top = new TableLayoutPanel();
            customGroupBox_search = new CustomGroupBox();
            textBox_search = new TextBox();
            backgroundWorker_void = new System.ComponentModel.BackgroundWorker();
            timer_search = new System.Windows.Forms.Timer(components);
            backgroundWorker_search = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)dataGridView_invoice).BeginInit();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_top.SuspendLayout();
            customGroupBox_search.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView_invoice
            // 
            dataGridView_invoice.AllowUserToAddRows = false;
            dataGridView_invoice.AllowUserToDeleteRows = false;
            dataGridView_invoice.AllowUserToResizeColumns = false;
            dataGridView_invoice.AllowUserToResizeRows = false;
            dataGridView_invoice.BackgroundColor = Color.White;
            dataGridView_invoice.BorderStyle = BorderStyle.None;
            dataGridView_invoice.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_invoice.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = Color.White;
            dataGridViewCellStyle17.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle17.ForeColor = Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = Color.White;
            dataGridViewCellStyle17.SelectionForeColor = Color.Black;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            dataGridView_invoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dataGridView_invoice.ColumnHeadersHeight = 50;
            dataGridView_invoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_invoice.Columns.AddRange(new DataGridViewColumn[] { Column1, seq, void_bill, id, created_by, created_date, created_time, status, trx_no, id_member, phone, item_qty, price_sum, percent_discount_member, point_increase, discount_promotion, discount_member, discount_custom, discount_point, discount_round, price_net, pay_cash, pay_transfer, change, price_non_vat, price_vat, vat, void_date, return_date, trx_no_reference, detail, Column2 });
            dataGridViewCellStyle32.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = Color.White;
            dataGridViewCellStyle32.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle32.ForeColor = Color.Black;
            dataGridViewCellStyle32.SelectionBackColor = Color.White;
            dataGridViewCellStyle32.SelectionForeColor = Color.Black;
            dataGridViewCellStyle32.WrapMode = DataGridViewTriState.False;
            dataGridView_invoice.DefaultCellStyle = dataGridViewCellStyle32;
            dataGridView_invoice.Dock = DockStyle.Fill;
            dataGridView_invoice.Enabled = false;
            dataGridView_invoice.GridColor = Color.Cyan;
            dataGridView_invoice.Location = new Point(0, 100);
            dataGridView_invoice.Margin = new Padding(0);
            dataGridView_invoice.MultiSelect = false;
            dataGridView_invoice.Name = "dataGridView_invoice";
            dataGridView_invoice.ReadOnly = true;
            dataGridView_invoice.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_invoice.RowHeadersVisible = false;
            dataGridView_invoice.RowHeadersWidth = 51;
            dataGridView_invoice.RowTemplate.Height = 50;
            dataGridView_invoice.RowTemplate.ReadOnly = true;
            dataGridView_invoice.ScrollBars = ScrollBars.None;
            dataGridView_invoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_invoice.Size = new Size(1061, 622);
            dataGridView_invoice.TabIndex = 0;
            dataGridView_invoice.CellDoubleClick += dataGridView_invoice_CellDoubleClick;
            dataGridView_invoice.CellMouseEnter += dataGridView_invoice_CellMouseEnter;
            dataGridView_invoice.CellMouseLeave += dataGridView_invoice_CellMouseLeave;
            dataGridView_invoice.CellMouseUp += dataGridView_invoice_CellMouseUp;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // seq
            // 
            seq.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
            seq.DefaultCellStyle = dataGridViewCellStyle18;
            seq.HeaderText = "";
            seq.MinimumWidth = 6;
            seq.Name = "seq";
            seq.ReadOnly = true;
            seq.Width = 23;
            // 
            // void_bill
            // 
            void_bill.HeaderText = "";
            void_bill.MinimumWidth = 6;
            void_bill.Name = "void_bill";
            void_bill.ReadOnly = true;
            void_bill.Width = 125;
            // 
            // id
            // 
            id.HeaderText = "id";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            id.Width = 125;
            // 
            // created_by
            // 
            created_by.HeaderText = "created_by";
            created_by.MinimumWidth = 6;
            created_by.Name = "created_by";
            created_by.ReadOnly = true;
            created_by.Visible = false;
            created_by.Width = 125;
            // 
            // created_date
            // 
            created_date.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            created_date.HeaderText = "วันที่";
            created_date.MinimumWidth = 6;
            created_date.Name = "created_date";
            created_date.ReadOnly = true;
            created_date.Width = 87;
            // 
            // created_time
            // 
            created_time.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleCenter;
            created_time.DefaultCellStyle = dataGridViewCellStyle19;
            created_time.HeaderText = "เวลา";
            created_time.MinimumWidth = 6;
            created_time.Name = "created_time";
            created_time.ReadOnly = true;
            created_time.Width = 88;
            // 
            // status
            // 
            status.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleCenter;
            status.DefaultCellStyle = dataGridViewCellStyle20;
            status.HeaderText = "สถานะ";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.ReadOnly = true;
            status.Width = 108;
            // 
            // trx_no
            // 
            trx_no.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleCenter;
            trx_no.DefaultCellStyle = dataGridViewCellStyle21;
            trx_no.HeaderText = "เลขบิล";
            trx_no.MinimumWidth = 200;
            trx_no.Name = "trx_no";
            trx_no.ReadOnly = true;
            trx_no.Width = 200;
            // 
            // id_member
            // 
            id_member.HeaderText = "id_member";
            id_member.MinimumWidth = 6;
            id_member.Name = "id_member";
            id_member.ReadOnly = true;
            id_member.Visible = false;
            id_member.Width = 125;
            // 
            // phone
            // 
            phone.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            phone.HeaderText = "สมาชิก";
            phone.MinimumWidth = 6;
            phone.Name = "phone";
            phone.ReadOnly = true;
            phone.Width = 115;
            // 
            // item_qty
            // 
            item_qty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleRight;
            item_qty.DefaultCellStyle = dataGridViewCellStyle22;
            item_qty.HeaderText = "สินค้า";
            item_qty.MinimumWidth = 6;
            item_qty.Name = "item_qty";
            item_qty.ReadOnly = true;
            // 
            // price_sum
            // 
            price_sum.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleRight;
            price_sum.DefaultCellStyle = dataGridViewCellStyle23;
            price_sum.HeaderText = "มูลค่า";
            price_sum.MinimumWidth = 6;
            price_sum.Name = "price_sum";
            price_sum.ReadOnly = true;
            price_sum.Width = 99;
            // 
            // percent_discount_member
            // 
            percent_discount_member.HeaderText = "percent_discount_member";
            percent_discount_member.MinimumWidth = 6;
            percent_discount_member.Name = "percent_discount_member";
            percent_discount_member.ReadOnly = true;
            percent_discount_member.Visible = false;
            percent_discount_member.Width = 125;
            // 
            // point_increase
            // 
            point_increase.HeaderText = "point_increase";
            point_increase.MinimumWidth = 6;
            point_increase.Name = "point_increase";
            point_increase.ReadOnly = true;
            point_increase.Visible = false;
            point_increase.Width = 125;
            // 
            // discount_promotion
            // 
            discount_promotion.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleRight;
            discount_promotion.DefaultCellStyle = dataGridViewCellStyle24;
            discount_promotion.HeaderText = "ลดโปร";
            discount_promotion.MinimumWidth = 6;
            discount_promotion.Name = "discount_promotion";
            discount_promotion.ReadOnly = true;
            discount_promotion.Width = 108;
            // 
            // discount_member
            // 
            discount_member.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle25.Alignment = DataGridViewContentAlignment.MiddleRight;
            discount_member.DefaultCellStyle = dataGridViewCellStyle25;
            discount_member.HeaderText = "ลดสมาชิก";
            discount_member.MinimumWidth = 6;
            discount_member.Name = "discount_member";
            discount_member.ReadOnly = true;
            discount_member.Width = 144;
            // 
            // discount_custom
            // 
            discount_custom.HeaderText = "discount_custom";
            discount_custom.MinimumWidth = 6;
            discount_custom.Name = "discount_custom";
            discount_custom.ReadOnly = true;
            discount_custom.Visible = false;
            discount_custom.Width = 125;
            // 
            // discount_point
            // 
            discount_point.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle26.Alignment = DataGridViewContentAlignment.MiddleRight;
            discount_point.DefaultCellStyle = dataGridViewCellStyle26;
            discount_point.HeaderText = "ลดแต้ม";
            discount_point.MinimumWidth = 6;
            discount_point.Name = "discount_point";
            discount_point.ReadOnly = true;
            discount_point.Width = 115;
            // 
            // discount_round
            // 
            discount_round.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleRight;
            discount_round.DefaultCellStyle = dataGridViewCellStyle27;
            discount_round.HeaderText = "ปัดเศษ";
            discount_round.MinimumWidth = 6;
            discount_round.Name = "discount_round";
            discount_round.ReadOnly = true;
            discount_round.Width = 110;
            // 
            // price_net
            // 
            price_net.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle28.Alignment = DataGridViewContentAlignment.MiddleRight;
            price_net.DefaultCellStyle = dataGridViewCellStyle28;
            price_net.HeaderText = "มูลค่าสุทธิ";
            price_net.MinimumWidth = 6;
            price_net.Name = "price_net";
            price_net.ReadOnly = true;
            price_net.Width = 142;
            // 
            // pay_cash
            // 
            pay_cash.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle29.Alignment = DataGridViewContentAlignment.MiddleRight;
            pay_cash.DefaultCellStyle = dataGridViewCellStyle29;
            pay_cash.HeaderText = "เงินสด";
            pay_cash.MinimumWidth = 6;
            pay_cash.Name = "pay_cash";
            pay_cash.ReadOnly = true;
            pay_cash.Width = 106;
            // 
            // pay_transfer
            // 
            pay_transfer.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle30.Alignment = DataGridViewContentAlignment.MiddleRight;
            pay_transfer.DefaultCellStyle = dataGridViewCellStyle30;
            pay_transfer.HeaderText = "เงินโอน";
            pay_transfer.MinimumWidth = 6;
            pay_transfer.Name = "pay_transfer";
            pay_transfer.ReadOnly = true;
            pay_transfer.Width = 117;
            // 
            // change
            // 
            change.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleRight;
            change.DefaultCellStyle = dataGridViewCellStyle31;
            change.HeaderText = "เงินทอน";
            change.MinimumWidth = 6;
            change.Name = "change";
            change.ReadOnly = true;
            change.Width = 123;
            // 
            // price_non_vat
            // 
            price_non_vat.HeaderText = "price_non_vat";
            price_non_vat.MinimumWidth = 6;
            price_non_vat.Name = "price_non_vat";
            price_non_vat.ReadOnly = true;
            price_non_vat.Visible = false;
            price_non_vat.Width = 125;
            // 
            // price_vat
            // 
            price_vat.HeaderText = "price_vat";
            price_vat.MinimumWidth = 6;
            price_vat.Name = "price_vat";
            price_vat.ReadOnly = true;
            price_vat.Visible = false;
            price_vat.Width = 125;
            // 
            // vat
            // 
            vat.HeaderText = "vat";
            vat.MinimumWidth = 6;
            vat.Name = "vat";
            vat.ReadOnly = true;
            vat.Visible = false;
            vat.Width = 125;
            // 
            // void_date
            // 
            void_date.HeaderText = "void_date";
            void_date.MinimumWidth = 6;
            void_date.Name = "void_date";
            void_date.ReadOnly = true;
            void_date.Visible = false;
            void_date.Width = 125;
            // 
            // return_date
            // 
            return_date.HeaderText = "return_date";
            return_date.MinimumWidth = 6;
            return_date.Name = "return_date";
            return_date.ReadOnly = true;
            return_date.Visible = false;
            return_date.Width = 125;
            // 
            // trx_no_reference
            // 
            trx_no_reference.HeaderText = "trx_no_reference";
            trx_no_reference.MinimumWidth = 6;
            trx_no_reference.Name = "trx_no_reference";
            trx_no_reference.ReadOnly = true;
            trx_no_reference.Visible = false;
            trx_no_reference.Width = 125;
            // 
            // detail
            // 
            detail.HeaderText = "";
            detail.MinimumWidth = 6;
            detail.Name = "detail";
            detail.ReadOnly = true;
            detail.Resizable = DataGridViewTriState.True;
            detail.SortMode = DataGridViewColumnSortMode.Automatic;
            detail.Width = 125;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.White;
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_back.Controls.Add(dataGridView_invoice, 0, 1);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_top, 0, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(1061, 722);
            tableLayoutPanel_back.TabIndex = 1;
            // 
            // tableLayoutPanel_top
            // 
            tableLayoutPanel_top.ColumnCount = 3;
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.Controls.Add(customGroupBox_search, 1, 1);
            tableLayoutPanel_top.Dock = DockStyle.Fill;
            tableLayoutPanel_top.Location = new Point(3, 3);
            tableLayoutPanel_top.Name = "tableLayoutPanel_top";
            tableLayoutPanel_top.RowCount = 3;
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.Size = new Size(1055, 94);
            tableLayoutPanel_top.TabIndex = 1;
            // 
            // customGroupBox_search
            // 
            customGroupBox_search.BackColor = Color.White;
            customGroupBox_search.BorderColor = Color.FromArgb(128, 255, 255);
            customGroupBox_search.BorderRadius = 30;
            customGroupBox_search.BorderThickness = 20;
            customGroupBox_search.Controls.Add(textBox_search);
            customGroupBox_search.Dock = DockStyle.Fill;
            customGroupBox_search.Font = new Font("Segoe UI", 1F);
            customGroupBox_search.Location = new Point(280, 15);
            customGroupBox_search.Name = "customGroupBox_search";
            customGroupBox_search.Padding = new Padding(10);
            customGroupBox_search.Size = new Size(494, 64);
            customGroupBox_search.TabIndex = 0;
            customGroupBox_search.TabStop = false;
            // 
            // textBox_search
            // 
            textBox_search.BackColor = Color.FromArgb(128, 255, 255);
            textBox_search.BorderStyle = BorderStyle.None;
            textBox_search.Dock = DockStyle.Fill;
            textBox_search.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_search.Location = new Point(10, 13);
            textBox_search.Name = "textBox_search";
            textBox_search.Size = new Size(474, 44);
            textBox_search.TabIndex = 0;
            textBox_search.TextAlign = HorizontalAlignment.Center;
            textBox_search.TextChanged += textBox_search_TextChanged;
            // 
            // backgroundWorker_void
            // 
            backgroundWorker_void.DoWork += backgroundWorker_void_DoWork;
            backgroundWorker_void.RunWorkerCompleted += backgroundWorker_void_RunWorkerCompleted;
            // 
            // timer_search
            // 
            timer_search.Tick += timer_search_Tick;
            // 
            // backgroundWorker_search
            // 
            backgroundWorker_search.DoWork += backgroundWorker_search_DoWork;
            backgroundWorker_search.RunWorkerCompleted += backgroundWorker_search_RunWorkerCompleted;
            // 
            // Form_Check_Invoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1061, 722);
            Controls.Add(tableLayoutPanel_back);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Check_Invoice";
            Text = "Form_Check_Invoice";
            Load += Form_Check_Invoice_Load;
            Shown += Form_Check_Invoice_Shown;
            ((System.ComponentModel.ISupportInitialize)dataGridView_invoice).EndInit();
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_top.ResumeLayout(false);
            customGroupBox_search.ResumeLayout(false);
            customGroupBox_search.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView_invoice;
        private TableLayoutPanel tableLayoutPanel_back;
        private System.ComponentModel.BackgroundWorker backgroundWorker_void;
        private TableLayoutPanel tableLayoutPanel_top;
        private CustomGroupBox customGroupBox_search;
        private TextBox textBox_search;
        private System.Windows.Forms.Timer timer_search;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn seq;
        private DataGridViewImageColumn void_bill;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn created_by;
        private DataGridViewTextBoxColumn created_date;
        private DataGridViewTextBoxColumn created_time;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn trx_no;
        private DataGridViewTextBoxColumn id_member;
        private DataGridViewTextBoxColumn phone;
        private DataGridViewTextBoxColumn item_qty;
        private DataGridViewTextBoxColumn price_sum;
        private DataGridViewTextBoxColumn percent_discount_member;
        private DataGridViewTextBoxColumn point_increase;
        private DataGridViewTextBoxColumn discount_promotion;
        private DataGridViewTextBoxColumn discount_member;
        private DataGridViewTextBoxColumn discount_custom;
        private DataGridViewTextBoxColumn discount_point;
        private DataGridViewTextBoxColumn discount_round;
        private DataGridViewTextBoxColumn price_net;
        private DataGridViewTextBoxColumn pay_cash;
        private DataGridViewTextBoxColumn pay_transfer;
        private DataGridViewTextBoxColumn change;
        private DataGridViewTextBoxColumn price_non_vat;
        private DataGridViewTextBoxColumn price_vat;
        private DataGridViewTextBoxColumn vat;
        private DataGridViewTextBoxColumn void_date;
        private DataGridViewTextBoxColumn return_date;
        private DataGridViewTextBoxColumn trx_no_reference;
        private DataGridViewImageColumn detail;
        private DataGridViewTextBoxColumn Column2;
        private System.ComponentModel.BackgroundWorker backgroundWorker_search;
    }
}