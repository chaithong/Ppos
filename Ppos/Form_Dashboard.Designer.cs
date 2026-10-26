namespace Ppos
{
    partial class Form_Dashboard
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
            customGroupBox_back = new CustomGroupBox();
            SuspendLayout();
            // 
            // customGroupBox_back
            // 
            customGroupBox_back.BorderColor = Color.White;
            customGroupBox_back.BorderRadius = 30;
            customGroupBox_back.BorderThickness = 20;
            customGroupBox_back.Dock = DockStyle.Fill;
            customGroupBox_back.Font = new Font("Segoe UI", 1F);
            customGroupBox_back.Location = new Point(0, 0);
            customGroupBox_back.Margin = new Padding(0);
            customGroupBox_back.Name = "customGroupBox_back";
            customGroupBox_back.Padding = new Padding(10);
            customGroupBox_back.Size = new Size(790, 447);
            customGroupBox_back.TabIndex = 0;
            customGroupBox_back.TabStop = false;
            // 
            // Form_Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cyan;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(customGroupBox_back);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Dashboard";
            Padding = new Padding(0, 0, 10, 3);
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
        }

        #endregion

        private CustomGroupBox customGroupBox_back;
    }
}