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
            panel_video = new Panel();
            customGroupBox_back = new CustomGroupBox();
            panel_detail = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox_video).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_device).BeginInit();
            tableLayoutPanel_button.SuspendLayout();
            panel_video.SuspendLayout();
            customGroupBox_back.SuspendLayout();
            panel_detail.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox_video
            // 
            pictureBox_video.BackColor = Color.White;
            pictureBox_video.Dock = DockStyle.Top;
            pictureBox_video.Location = new Point(15, 59);
            pictureBox_video.Name = "pictureBox_video";
            pictureBox_video.Size = new Size(520, 400);
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
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
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
            dataGridView_device.Location = new Point(15, 514);
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
            dataGridView_device.Size = new Size(520, 76);
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
            button_refresh.Dock = DockStyle.Bottom;
            button_refresh.FlatAppearance.BorderSize = 0;
            button_refresh.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_refresh.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_refresh.FlatStyle = FlatStyle.Flat;
            button_refresh.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_refresh.Location = new Point(15, 590);
            button_refresh.Margin = new Padding(0);
            button_refresh.Name = "button_refresh";
            button_refresh.Size = new Size(520, 60);
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
            tableLayoutPanel_button.Dock = DockStyle.Top;
            tableLayoutPanel_button.Location = new Point(15, 459);
            tableLayoutPanel_button.Margin = new Padding(0);
            tableLayoutPanel_button.Name = "tableLayoutPanel_button";
            tableLayoutPanel_button.RowCount = 1;
            tableLayoutPanel_button.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_button.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_button.Size = new Size(520, 55);
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
            button_test.Size = new Size(260, 55);
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
            button_save.Location = new Point(260, 0);
            button_save.Margin = new Padding(0);
            button_save.Name = "button_save";
            button_save.Size = new Size(260, 55);
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
            textBox_device.BackColor = Color.White;
            textBox_device.BorderStyle = BorderStyle.None;
            textBox_device.Dock = DockStyle.Top;
            textBox_device.Enabled = false;
            textBox_device.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_device.Location = new Point(15, 15);
            textBox_device.Name = "textBox_device";
            textBox_device.Size = new Size(520, 44);
            textBox_device.TabIndex = 2;
            textBox_device.TextAlign = HorizontalAlignment.Center;
            // 
            // panel_video
            // 
            panel_video.BackColor = Color.Transparent;
            panel_video.Controls.Add(dataGridView_device);
            panel_video.Controls.Add(tableLayoutPanel_button);
            panel_video.Controls.Add(pictureBox_video);
            panel_video.Controls.Add(textBox_device);
            panel_video.Controls.Add(button_refresh);
            panel_video.Dock = DockStyle.Fill;
            panel_video.Location = new Point(25, 28);
            panel_video.Margin = new Padding(9);
            panel_video.Name = "panel_video";
            panel_video.Padding = new Padding(15);
            panel_video.Size = new Size(550, 665);
            panel_video.TabIndex = 2;
            // 
            // customGroupBox_back
            // 
            customGroupBox_back.Anchor = AnchorStyles.Top;
            customGroupBox_back.BorderColor = Color.Cyan;
            customGroupBox_back.BorderRadius = 30;
            customGroupBox_back.BorderThickness = 20;
            customGroupBox_back.Controls.Add(panel_video);
            customGroupBox_back.Font = new Font("Segoe UI", 1F);
            customGroupBox_back.Location = new Point(315, 19);
            customGroupBox_back.Margin = new Padding(9);
            customGroupBox_back.Name = "customGroupBox_back";
            customGroupBox_back.Padding = new Padding(25);
            customGroupBox_back.Size = new Size(600, 718);
            customGroupBox_back.TabIndex = 3;
            customGroupBox_back.TabStop = false;
            customGroupBox_back.Text = " ";
            // 
            // panel_detail
            // 
            panel_detail.AutoScroll = true;
            panel_detail.Controls.Add(customGroupBox_back);
            panel_detail.Dock = DockStyle.Fill;
            panel_detail.Location = new Point(0, 0);
            panel_detail.Name = "panel_detail";
            panel_detail.Size = new Size(1423, 964);
            panel_detail.TabIndex = 4;
            // 
            // Form_Setting_Camera
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1423, 964);
            Controls.Add(panel_detail);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Setting_Camera";
            Text = "Form_Setting_Other";
            Load += Form_Setting_Camera_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox_video).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_device).EndInit();
            tableLayoutPanel_button.ResumeLayout(false);
            panel_video.ResumeLayout(false);
            panel_video.PerformLayout();
            customGroupBox_back.ResumeLayout(false);
            panel_detail.ResumeLayout(false);
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
        private Panel panel_video;
        private CustomGroupBox customGroupBox_back;
        private Panel panel_detail;
    }
}