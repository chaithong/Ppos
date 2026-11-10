namespace Ppos
{
    partial class Form_Setting_Camera
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pictureBox_video = new PictureBox();
            dataGridView_device = new DataGridView();
            device_names = new DataGridViewTextBoxColumn();
            button_refresh = new Button();
            tableLayoutPanel_button = new TableLayoutPanel();
            button_test = new Button();
            button_save = new Button();
            textBox_device = new TextBox();
            customGroupBox_detail = new CustomGroupBox();
            tableLayoutPanel_detail = new TableLayoutPanel();
            panel_detail = new Panel();
            customGroupBox_back = new CustomGroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_video).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_device).BeginInit();
            tableLayoutPanel_button.SuspendLayout();
            customGroupBox_detail.SuspendLayout();
            tableLayoutPanel_detail.SuspendLayout();
            panel_detail.SuspendLayout();
            customGroupBox_back.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox_video
            // 
            pictureBox_video.BackColor = Color.White;
            pictureBox_video.Dock = DockStyle.Fill;
            pictureBox_video.Location = new Point(3, 53);
            pictureBox_video.Name = "pictureBox_video";
            pictureBox_video.Size = new Size(544, 251);
            pictureBox_video.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_video.TabIndex = 0;
            pictureBox_video.TabStop = false;
            // 
            // dataGridView_device
            // 
            dataGridView_device.AllowUserToAddRows = false;
            dataGridView_device.AllowUserToDeleteRows = false;
            dataGridView_device.AllowUserToResizeColumns = false;
            dataGridView_device.AllowUserToResizeRows = false;
            dataGridView_device.BackgroundColor = Color.White;
            dataGridView_device.BorderStyle = BorderStyle.None;
            dataGridView_device.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_device.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Cyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 1F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.Cyan;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView_device.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_device.ColumnHeadersHeight = 4;
            dataGridView_device.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_device.Columns.AddRange(new DataGridViewColumn[] { device_names });
            dataGridView_device.Dock = DockStyle.Fill;
            dataGridView_device.GridColor = Color.Cyan;
            dataGridView_device.Location = new Point(0, 357);
            dataGridView_device.Margin = new Padding(0);
            dataGridView_device.MultiSelect = false;
            dataGridView_device.Name = "dataGridView_device";
            dataGridView_device.ReadOnly = true;
            dataGridView_device.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_device.RowHeadersVisible = false;
            dataGridView_device.RowHeadersWidth = 4;
            dataGridView_device.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView_device.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView_device.RowTemplate.Height = 50;
            dataGridView_device.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_device.Size = new Size(550, 257);
            dataGridView_device.TabIndex = 1;
            dataGridView_device.CellMouseDown += dataGridView_device_CellMouseDown;
            // 
            // device_names
            // 
            device_names.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            device_names.HeaderText = "";
            device_names.MinimumWidth = 6;
            device_names.Name = "device_names";
            device_names.ReadOnly = true;
            // 
            // button_refresh
            // 
            button_refresh.BackColor = Color.Transparent;
            button_refresh.BackgroundImageLayout = ImageLayout.Zoom;
            button_refresh.Dock = DockStyle.Fill;
            button_refresh.FlatAppearance.BorderSize = 0;
            button_refresh.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_refresh.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_refresh.FlatStyle = FlatStyle.Flat;
            button_refresh.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_refresh.Location = new Point(0, 614);
            button_refresh.Margin = new Padding(0);
            button_refresh.Name = "button_refresh";
            button_refresh.Size = new Size(550, 51);
            button_refresh.TabIndex = 4;
            button_refresh.Text = "ค้นหากล้องอีกครั้ง";
            button_refresh.TextAlign = ContentAlignment.MiddleRight;
            button_refresh.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_refresh.UseVisualStyleBackColor = false;
            button_refresh.Click += button_refresh_Click;
            button_refresh.MouseEnter += button_MouseEnter;
            button_refresh.MouseLeave += button_MouseLeave;
            // 
            // tableLayoutPanel_button
            // 
            tableLayoutPanel_button.ColumnCount = 2;
            tableLayoutPanel_button.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_button.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_button.Controls.Add(button_test, 0, 0);
            tableLayoutPanel_button.Controls.Add(button_save, 1, 0);
            tableLayoutPanel_button.Dock = DockStyle.Fill;
            tableLayoutPanel_button.Location = new Point(0, 307);
            tableLayoutPanel_button.Margin = new Padding(0);
            tableLayoutPanel_button.Name = "tableLayoutPanel_button";
            tableLayoutPanel_button.RowCount = 1;
            tableLayoutPanel_button.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_button.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_button.Size = new Size(550, 50);
            tableLayoutPanel_button.TabIndex = 3;
            // 
            // button_test
            // 
            button_test.BackColor = Color.Cyan;
            button_test.Dock = DockStyle.Fill;
            button_test.Enabled = false;
            button_test.FlatAppearance.BorderSize = 0;
            button_test.FlatAppearance.MouseDownBackColor = Color.Cyan;
            button_test.FlatAppearance.MouseOverBackColor = Color.Cyan;
            button_test.FlatStyle = FlatStyle.Flat;
            button_test.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Underline);
            button_test.Location = new Point(0, 0);
            button_test.Margin = new Padding(0);
            button_test.Name = "button_test";
            button_test.Size = new Size(275, 50);
            button_test.TabIndex = 0;
            button_test.Text = "ทดสอบ";
            button_test.TextAlign = ContentAlignment.MiddleRight;
            button_test.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_test.UseVisualStyleBackColor = false;
            button_test.Click += button_test_Click;
            button_test.MouseEnter += button_MouseEnter;
            button_test.MouseLeave += button_MouseLeave;
            // 
            // button_save
            // 
            button_save.BackColor = Color.White;
            button_save.Dock = DockStyle.Fill;
            button_save.Enabled = false;
            button_save.FlatAppearance.BorderSize = 0;
            button_save.FlatAppearance.MouseDownBackColor = Color.White;
            button_save.FlatAppearance.MouseOverBackColor = Color.White;
            button_save.FlatStyle = FlatStyle.Flat;
            button_save.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Underline);
            button_save.Location = new Point(275, 0);
            button_save.Margin = new Padding(0);
            button_save.Name = "button_save";
            button_save.Size = new Size(275, 50);
            button_save.TabIndex = 0;
            button_save.Text = "บันทึก";
            button_save.TextAlign = ContentAlignment.MiddleRight;
            button_save.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            button_save.MouseEnter += button_MouseEnter;
            button_save.MouseLeave += button_MouseLeave;
            // 
            // textBox_device
            // 
            textBox_device.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_device.BackColor = Color.White;
            textBox_device.BorderStyle = BorderStyle.None;
            textBox_device.Enabled = false;
            textBox_device.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_device.Location = new Point(3, 3);
            textBox_device.Name = "textBox_device";
            textBox_device.Size = new Size(544, 44);
            textBox_device.TabIndex = 2;
            textBox_device.TextAlign = HorizontalAlignment.Center;
            // 
            // customGroupBox_detail
            // 
            customGroupBox_detail.BorderColor = Color.Cyan;
            customGroupBox_detail.BorderRadius = 30;
            customGroupBox_detail.BorderThickness = 20;
            customGroupBox_detail.Controls.Add(tableLayoutPanel_detail);
            customGroupBox_detail.Font = new Font("Segoe UI", 1F);
            customGroupBox_detail.Location = new Point(315, 19);
            customGroupBox_detail.Margin = new Padding(9);
            customGroupBox_detail.Name = "customGroupBox_detail";
            customGroupBox_detail.Padding = new Padding(25);
            customGroupBox_detail.Size = new Size(600, 718);
            customGroupBox_detail.TabIndex = 3;
            customGroupBox_detail.TabStop = false;
            customGroupBox_detail.Text = " ";
            // 
            // tableLayoutPanel_detail
            // 
            tableLayoutPanel_detail.ColumnCount = 1;
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_detail.Controls.Add(textBox_device, 0, 0);
            tableLayoutPanel_detail.Controls.Add(pictureBox_video, 0, 1);
            tableLayoutPanel_detail.Controls.Add(tableLayoutPanel_button, 0, 2);
            tableLayoutPanel_detail.Controls.Add(dataGridView_device, 0, 3);
            tableLayoutPanel_detail.Controls.Add(button_refresh, 0, 4);
            tableLayoutPanel_detail.Dock = DockStyle.Fill;
            tableLayoutPanel_detail.Location = new Point(25, 28);
            tableLayoutPanel_detail.Name = "tableLayoutPanel_detail";
            tableLayoutPanel_detail.RowCount = 5;
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_detail.Size = new Size(550, 665);
            tableLayoutPanel_detail.TabIndex = 0;
            // 
            // panel_detail
            // 
            panel_detail.AutoScroll = true;
            panel_detail.BackColor = Color.White;
            panel_detail.Controls.Add(customGroupBox_detail);
            panel_detail.Dock = DockStyle.Fill;
            panel_detail.Location = new Point(10, 13);
            panel_detail.Name = "panel_detail";
            panel_detail.Size = new Size(1393, 938);
            panel_detail.TabIndex = 4;
            // 
            // customGroupBox_back
            // 
            customGroupBox_back.BackColor = Color.Transparent;
            customGroupBox_back.BorderColor = Color.White;
            customGroupBox_back.BorderRadius = 30;
            customGroupBox_back.BorderThickness = 20;
            customGroupBox_back.Controls.Add(panel_detail);
            customGroupBox_back.Dock = DockStyle.Fill;
            customGroupBox_back.Font = new Font("Segoe UI", 1F);
            customGroupBox_back.Location = new Point(0, 0);
            customGroupBox_back.Margin = new Padding(0);
            customGroupBox_back.Name = "customGroupBox_back";
            customGroupBox_back.Padding = new Padding(10);
            customGroupBox_back.Size = new Size(1413, 961);
            customGroupBox_back.TabIndex = 5;
            customGroupBox_back.TabStop = false;
            // 
            // Form_Setting_Camera
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cyan;
            ClientSize = new Size(1423, 964);
            Controls.Add(customGroupBox_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Setting_Camera";
            Padding = new Padding(0, 0, 10, 3);
            Text = "Form_Setting_Other";
            Load += Form_Setting_Camera_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox_video).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_device).EndInit();
            tableLayoutPanel_button.ResumeLayout(false);
            customGroupBox_detail.ResumeLayout(false);
            tableLayoutPanel_detail.ResumeLayout(false);
            tableLayoutPanel_detail.PerformLayout();
            panel_detail.ResumeLayout(false);
            customGroupBox_back.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_video;
        private DataGridView dataGridView_device;
        private TableLayoutPanel tableLayoutPanel_button;
        private Button button_test;
        private Button button_save;
        private TextBox textBox_device;
        private Button button_refresh;
        private DataGridViewTextBoxColumn device_names;
        private CustomGroupBox customGroupBox_detail;
        private Panel panel_detail;
        private TableLayoutPanel tableLayoutPanel_detail;
        private CustomGroupBox customGroupBox_back;
    }
}