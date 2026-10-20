namespace Ppos
{
    partial class Form_Load_Price
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
            panel_load = new Panel();
            panel_back = new Panel();
            customGroupBox_all_item = new CustomGroupBox();
            tableLayoutPanel_all_item = new TableLayoutPanel();
            label1 = new Label();
            label_item_all = new Label();
            customGroupBox_add_item = new CustomGroupBox();
            tableLayoutPanel_load = new TableLayoutPanel();
            label2 = new Label();
            label_item_load_complete = new Label();
            label4 = new Label();
            label_item_load = new Label();
            label7 = new Label();
            label_item_load_error = new Label();
            tableLayoutPanel_button = new TableLayoutPanel();
            panel_download_templete = new Panel();
            button_load_template = new Button();
            pictureBox_load = new PictureBox();
            panel_download_error = new Panel();
            button_load_error = new Button();
            pictureBox_load_error = new PictureBox();
            button_upload = new Button();
            button_download_all_item = new Button();
            pictureBox_load_all_item = new PictureBox();
            tableLayoutPanel_back = new TableLayoutPanel();
            backgroundWorker_load_all_item = new System.ComponentModel.BackgroundWorker();
            backgroundWorker_template = new System.ComponentModel.BackgroundWorker();
            backgroundWorker_upload = new System.ComponentModel.BackgroundWorker();
            backgroundWorker_error = new System.ComponentModel.BackgroundWorker();
            panel_back.SuspendLayout();
            customGroupBox_all_item.SuspendLayout();
            tableLayoutPanel_all_item.SuspendLayout();
            customGroupBox_add_item.SuspendLayout();
            tableLayoutPanel_load.SuspendLayout();
            tableLayoutPanel_button.SuspendLayout();
            panel_download_templete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_load).BeginInit();
            panel_download_error.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_load_error).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_load_all_item).BeginInit();
            tableLayoutPanel_back.SuspendLayout();
            SuspendLayout();
            // 
            // panel_load
            // 
            panel_load.BackColor = Color.Lime;
            panel_load.Dock = DockStyle.Left;
            panel_load.Location = new Point(0, 0);
            panel_load.Margin = new Padding(0);
            panel_load.Name = "panel_load";
            panel_load.Size = new Size(0, 20);
            panel_load.TabIndex = 4;
            // 
            // panel_back
            // 
            panel_back.AutoScroll = true;
            panel_back.BackColor = Color.White;
            panel_back.Controls.Add(customGroupBox_all_item);
            panel_back.Controls.Add(customGroupBox_add_item);
            panel_back.Controls.Add(button_download_all_item);
            panel_back.Controls.Add(pictureBox_load_all_item);
            panel_back.Dock = DockStyle.Fill;
            panel_back.Location = new Point(0, 20);
            panel_back.Margin = new Padding(0);
            panel_back.Name = "panel_back";
            panel_back.Size = new Size(1348, 680);
            panel_back.TabIndex = 3;
            // 
            // customGroupBox_all_item
            // 
            customGroupBox_all_item.Anchor = AnchorStyles.Top;
            customGroupBox_all_item.BorderColor = Color.Lime;
            customGroupBox_all_item.BorderRadius = 30;
            customGroupBox_all_item.BorderThickness = 20;
            customGroupBox_all_item.Controls.Add(tableLayoutPanel_all_item);
            customGroupBox_all_item.Font = new Font("Segoe UI", 1F);
            customGroupBox_all_item.Location = new Point(393, 157);
            customGroupBox_all_item.Name = "customGroupBox_all_item";
            customGroupBox_all_item.Padding = new Padding(10);
            customGroupBox_all_item.Size = new Size(600, 100);
            customGroupBox_all_item.TabIndex = 6;
            customGroupBox_all_item.TabStop = false;
            // 
            // tableLayoutPanel_all_item
            // 
            tableLayoutPanel_all_item.BackColor = Color.Lime;
            tableLayoutPanel_all_item.ColumnCount = 2;
            tableLayoutPanel_all_item.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_all_item.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_all_item.Controls.Add(label1, 0, 0);
            tableLayoutPanel_all_item.Controls.Add(label_item_all, 1, 0);
            tableLayoutPanel_all_item.Dock = DockStyle.Fill;
            tableLayoutPanel_all_item.Location = new Point(10, 13);
            tableLayoutPanel_all_item.Name = "tableLayoutPanel_all_item";
            tableLayoutPanel_all_item.RowCount = 1;
            tableLayoutPanel_all_item.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_all_item.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_all_item.Size = new Size(580, 77);
            tableLayoutPanel_all_item.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(284, 77);
            label1.TabIndex = 0;
            label1.Text = "สินค้าทั้งหมด :";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_item_all
            // 
            label_item_all.Dock = DockStyle.Fill;
            label_item_all.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_item_all.Location = new Point(293, 0);
            label_item_all.Name = "label_item_all";
            label_item_all.Size = new Size(284, 77);
            label_item_all.TabIndex = 1;
            label_item_all.Text = "0";
            label_item_all.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // customGroupBox_add_item
            // 
            customGroupBox_add_item.Anchor = AnchorStyles.Top;
            customGroupBox_add_item.BorderColor = Color.FromArgb(128, 255, 128);
            customGroupBox_add_item.BorderRadius = 30;
            customGroupBox_add_item.BorderThickness = 20;
            customGroupBox_add_item.Controls.Add(tableLayoutPanel_load);
            customGroupBox_add_item.Controls.Add(tableLayoutPanel_button);
            customGroupBox_add_item.Controls.Add(button_upload);
            customGroupBox_add_item.Location = new Point(393, 276);
            customGroupBox_add_item.Name = "customGroupBox_add_item";
            customGroupBox_add_item.Padding = new Padding(10);
            customGroupBox_add_item.Size = new Size(600, 400);
            customGroupBox_add_item.TabIndex = 4;
            customGroupBox_add_item.TabStop = false;
            customGroupBox_add_item.Text = " ";
            // 
            // tableLayoutPanel_load
            // 
            tableLayoutPanel_load.BackColor = Color.Transparent;
            tableLayoutPanel_load.ColumnCount = 2;
            tableLayoutPanel_load.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_load.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_load.Controls.Add(label2, 0, 1);
            tableLayoutPanel_load.Controls.Add(label_item_load_complete, 1, 1);
            tableLayoutPanel_load.Controls.Add(label4, 0, 0);
            tableLayoutPanel_load.Controls.Add(label_item_load, 1, 0);
            tableLayoutPanel_load.Controls.Add(label7, 0, 2);
            tableLayoutPanel_load.Controls.Add(label_item_load_error, 1, 2);
            tableLayoutPanel_load.Dock = DockStyle.Fill;
            tableLayoutPanel_load.Location = new Point(10, 110);
            tableLayoutPanel_load.Name = "tableLayoutPanel_load";
            tableLayoutPanel_load.RowCount = 3;
            tableLayoutPanel_load.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33332F));
            tableLayoutPanel_load.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33334F));
            tableLayoutPanel_load.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333473F));
            tableLayoutPanel_load.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_load.Size = new Size(580, 210);
            tableLayoutPanel_load.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Lime;
            label2.Location = new Point(3, 69);
            label2.Name = "label2";
            label2.Size = new Size(284, 70);
            label2.TabIndex = 0;
            label2.Text = "อัพโหลดเรียบร้อย :";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_item_load_complete
            // 
            label_item_load_complete.Dock = DockStyle.Fill;
            label_item_load_complete.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_item_load_complete.ForeColor = Color.Lime;
            label_item_load_complete.Location = new Point(293, 69);
            label_item_load_complete.Name = "label_item_load_complete";
            label_item_load_complete.Size = new Size(284, 70);
            label_item_load_complete.TabIndex = 1;
            label_item_load_complete.Text = "0";
            label_item_load_complete.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(284, 69);
            label4.TabIndex = 0;
            label4.Text = "อัพโหลดสินค้า :";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_item_load
            // 
            label_item_load.Dock = DockStyle.Fill;
            label_item_load.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_item_load.ForeColor = Color.Black;
            label_item_load.Location = new Point(293, 0);
            label_item_load.Name = "label_item_load";
            label_item_load.Size = new Size(284, 69);
            label_item_load.TabIndex = 1;
            label_item_load.Text = "0";
            label_item_load.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(3, 139);
            label7.Name = "label7";
            label7.Size = new Size(284, 71);
            label7.TabIndex = 0;
            label7.Text = "ข้อมูลไม่ถูกต้อง :";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_item_load_error
            // 
            label_item_load_error.Dock = DockStyle.Fill;
            label_item_load_error.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_item_load_error.ForeColor = Color.Red;
            label_item_load_error.Location = new Point(293, 139);
            label_item_load_error.Name = "label_item_load_error";
            label_item_load_error.Size = new Size(284, 71);
            label_item_load_error.TabIndex = 1;
            label_item_load_error.Text = "0";
            label_item_load_error.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel_button
            // 
            tableLayoutPanel_button.BackColor = Color.Transparent;
            tableLayoutPanel_button.ColumnCount = 2;
            tableLayoutPanel_button.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_button.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_button.Controls.Add(panel_download_templete, 0, 0);
            tableLayoutPanel_button.Controls.Add(panel_download_error, 1, 0);
            tableLayoutPanel_button.Dock = DockStyle.Bottom;
            tableLayoutPanel_button.Location = new Point(10, 320);
            tableLayoutPanel_button.Name = "tableLayoutPanel_button";
            tableLayoutPanel_button.RowCount = 1;
            tableLayoutPanel_button.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_button.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_button.Size = new Size(580, 70);
            tableLayoutPanel_button.TabIndex = 6;
            // 
            // panel_download_templete
            // 
            panel_download_templete.Controls.Add(button_load_template);
            panel_download_templete.Controls.Add(pictureBox_load);
            panel_download_templete.Dock = DockStyle.Fill;
            panel_download_templete.Location = new Point(3, 3);
            panel_download_templete.Name = "panel_download_templete";
            panel_download_templete.Size = new Size(284, 64);
            panel_download_templete.TabIndex = 0;
            // 
            // button_load_template
            // 
            button_load_template.BackColor = Color.FromArgb(128, 255, 128);
            button_load_template.BackgroundImageLayout = ImageLayout.Zoom;
            button_load_template.Dock = DockStyle.Fill;
            button_load_template.FlatAppearance.BorderSize = 0;
            button_load_template.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_load_template.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_load_template.FlatStyle = FlatStyle.Flat;
            button_load_template.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_load_template.Location = new Point(0, 0);
            button_load_template.Name = "button_load_template";
            button_load_template.Size = new Size(284, 64);
            button_load_template.TabIndex = 0;
            button_load_template.TabStop = false;
            button_load_template.Text = "รูปแบบปรับราคา";
            button_load_template.TextAlign = ContentAlignment.MiddleRight;
            button_load_template.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_load_template.UseVisualStyleBackColor = false;
            button_load_template.Click += button_load_template_Click;
            button_load_template.MouseEnter += button_MouseEnter;
            button_load_template.MouseLeave += button_MouseLeave;
            // 
            // pictureBox_load
            // 
            pictureBox_load.BackColor = Color.Transparent;
            pictureBox_load.Dock = DockStyle.Fill;
            pictureBox_load.Image = Properties.Resources.load;
            pictureBox_load.Location = new Point(0, 0);
            pictureBox_load.Name = "pictureBox_load";
            pictureBox_load.Size = new Size(284, 64);
            pictureBox_load.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_load.TabIndex = 1;
            pictureBox_load.TabStop = false;
            // 
            // panel_download_error
            // 
            panel_download_error.Controls.Add(button_load_error);
            panel_download_error.Controls.Add(pictureBox_load_error);
            panel_download_error.Dock = DockStyle.Fill;
            panel_download_error.Location = new Point(293, 3);
            panel_download_error.Name = "panel_download_error";
            panel_download_error.Size = new Size(284, 64);
            panel_download_error.TabIndex = 1;
            // 
            // button_load_error
            // 
            button_load_error.BackColor = Color.FromArgb(128, 255, 128);
            button_load_error.BackgroundImageLayout = ImageLayout.Zoom;
            button_load_error.Dock = DockStyle.Fill;
            button_load_error.FlatAppearance.BorderSize = 0;
            button_load_error.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_load_error.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_load_error.FlatStyle = FlatStyle.Flat;
            button_load_error.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_load_error.ForeColor = Color.Red;
            button_load_error.Location = new Point(0, 0);
            button_load_error.Name = "button_load_error";
            button_load_error.Size = new Size(284, 64);
            button_load_error.TabIndex = 0;
            button_load_error.TabStop = false;
            button_load_error.Text = "ข้อมูลไม่ถูกต้อง";
            button_load_error.TextAlign = ContentAlignment.MiddleRight;
            button_load_error.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_load_error.UseVisualStyleBackColor = false;
            button_load_error.Visible = false;
            button_load_error.Click += button_load_error_Click;
            button_load_error.MouseEnter += button_MouseEnter;
            button_load_error.MouseLeave += button_MouseLeave;
            // 
            // pictureBox_load_error
            // 
            pictureBox_load_error.BackColor = Color.Transparent;
            pictureBox_load_error.Dock = DockStyle.Fill;
            pictureBox_load_error.Image = Properties.Resources.load;
            pictureBox_load_error.Location = new Point(0, 0);
            pictureBox_load_error.Name = "pictureBox_load_error";
            pictureBox_load_error.Size = new Size(284, 64);
            pictureBox_load_error.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_load_error.TabIndex = 1;
            pictureBox_load_error.TabStop = false;
            pictureBox_load_error.Visible = false;
            // 
            // button_upload
            // 
            button_upload.BackColor = Color.FromArgb(128, 255, 128);
            button_upload.BackgroundImageLayout = ImageLayout.Zoom;
            button_upload.Dock = DockStyle.Top;
            button_upload.FlatAppearance.BorderSize = 0;
            button_upload.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
            button_upload.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128);
            button_upload.FlatStyle = FlatStyle.Flat;
            button_upload.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_upload.Location = new Point(10, 30);
            button_upload.Name = "button_upload";
            button_upload.Size = new Size(580, 80);
            button_upload.TabIndex = 0;
            button_upload.TabStop = false;
            button_upload.Text = "อัพโหลดราคาสินค้า";
            button_upload.TextAlign = ContentAlignment.MiddleRight;
            button_upload.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_upload.UseVisualStyleBackColor = false;
            button_upload.Click += button_upload_Click;
            button_upload.MouseEnter += button_MouseEnter;
            button_upload.MouseLeave += button_MouseLeave;
            // 
            // button_download_all_item
            // 
            button_download_all_item.Anchor = AnchorStyles.Top;
            button_download_all_item.BackColor = Color.White;
            button_download_all_item.BackgroundImageLayout = ImageLayout.Zoom;
            button_download_all_item.FlatAppearance.BorderSize = 0;
            button_download_all_item.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_download_all_item.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_download_all_item.FlatStyle = FlatStyle.Flat;
            button_download_all_item.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_download_all_item.Location = new Point(393, 19);
            button_download_all_item.Margin = new Padding(5);
            button_download_all_item.Name = "button_download_all_item";
            button_download_all_item.Size = new Size(600, 130);
            button_download_all_item.TabIndex = 1;
            button_download_all_item.TabStop = false;
            button_download_all_item.Text = ">>ดาวน์โหลดสินค้าทั้งหมด<<";
            button_download_all_item.TextAlign = ContentAlignment.BottomCenter;
            button_download_all_item.TextImageRelation = TextImageRelation.ImageAboveText;
            button_download_all_item.UseVisualStyleBackColor = false;
            button_download_all_item.Click += button_download_all_item_Click;
            button_download_all_item.MouseEnter += button_download_all_item_MouseEnter;
            button_download_all_item.MouseLeave += button_download_all_item_MouseLeave;
            // 
            // pictureBox_load_all_item
            // 
            pictureBox_load_all_item.Anchor = AnchorStyles.Top;
            pictureBox_load_all_item.BackColor = Color.Transparent;
            pictureBox_load_all_item.Image = Properties.Resources.load;
            pictureBox_load_all_item.Location = new Point(393, 19);
            pictureBox_load_all_item.Name = "pictureBox_load_all_item";
            pictureBox_load_all_item.Size = new Size(600, 130);
            pictureBox_load_all_item.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_load_all_item.TabIndex = 5;
            pictureBox_load_all_item.TabStop = false;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.White;
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(panel_back, 0, 1);
            tableLayoutPanel_back.Controls.Add(panel_load, 0, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(1348, 700);
            tableLayoutPanel_back.TabIndex = 1;
            // 
            // backgroundWorker_load_all_item
            // 
            backgroundWorker_load_all_item.DoWork += backgroundWorker_load_all_item_DoWork;
            backgroundWorker_load_all_item.RunWorkerCompleted += backgroundWorker_load_all_item_RunWorkerCompleted;
            // 
            // backgroundWorker_template
            // 
            backgroundWorker_template.DoWork += backgroundWorker_template_DoWork;
            backgroundWorker_template.RunWorkerCompleted += backgroundWorker_template_RunWorkerCompleted;
            // 
            // backgroundWorker_upload
            // 
            backgroundWorker_upload.DoWork += backgroundWorker_upload_DoWork;
            backgroundWorker_upload.RunWorkerCompleted += backgroundWorker_upload_RunWorkerCompleted;
            // 
            // backgroundWorker_error
            // 
            backgroundWorker_error.DoWork += backgroundWorker_error_DoWork;
            backgroundWorker_error.RunWorkerCompleted += backgroundWorker_error_RunWorkerCompleted;
            // 
            // Form_Load_Price
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1348, 700);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Load_Price";
            Text = "Form_Load_Price";
            panel_back.ResumeLayout(false);
            customGroupBox_all_item.ResumeLayout(false);
            tableLayoutPanel_all_item.ResumeLayout(false);
            customGroupBox_add_item.ResumeLayout(false);
            tableLayoutPanel_load.ResumeLayout(false);
            tableLayoutPanel_load.PerformLayout();
            tableLayoutPanel_button.ResumeLayout(false);
            panel_download_templete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_load).EndInit();
            panel_download_error.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_load_error).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_load_all_item).EndInit();
            tableLayoutPanel_back.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_load;
        private Panel panel_back;
        private TableLayoutPanel tableLayoutPanel_back;
        private Button button_download_all_item;
        private Label label_item_all;
        private Label label1;
        private CustomGroupBox customGroupBox_add_item;
        private TableLayoutPanel tableLayoutPanel_load;
        private Label label2;
        private Label label_item_load_complete;
        private Label label4;
        private Label label_item_load;
        private Label label7;
        private Label label_item_load_error;
        private Button button_load_error;
        private Button button_load_template;
        private PictureBox pictureBox_load_error;
        private PictureBox pictureBox_load;
        private Button button_upload;
        private PictureBox pictureBox_load_all_item;
        private System.ComponentModel.BackgroundWorker backgroundWorker_load_all_item;
        private System.ComponentModel.BackgroundWorker backgroundWorker_template;
        private System.ComponentModel.BackgroundWorker backgroundWorker_upload;
        private System.ComponentModel.BackgroundWorker backgroundWorker_error;
        private TableLayoutPanel tableLayoutPanel_button;
        private Panel panel_download_templete;
        private Panel panel_download_error;
        private CustomGroupBox customGroupBox_all_item;
        private TableLayoutPanel tableLayoutPanel_all_item;
    }
}