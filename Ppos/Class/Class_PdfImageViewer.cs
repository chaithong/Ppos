using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PDFtoImage;

namespace YourProjectNamespace // <-- เปลี่ยนเป็น Namespace ของโปรเจกต์คุณ
{
    public class Class_PdfImageViewer : IDisposable
    {
        private readonly Panel _containerPanel;
        private readonly PictureBox _pictureBox;

        // ตัวแปรสำหรับลากภาพ (Pan)
        private bool _isDragging = false;
        private Point _startPoint;

        // ตัวแปรสำหรับซูม (Zoom)
        private float _zoomFactor = 1.0f;
        public float ZoomStep { get; set; } = 0.15f;
        public float MinZoom { get; set; } = 0.2f;
        public float MaxZoom { get; set; } = 5.0f;

        /// <summary>
        /// สร้างตัวจัดการแสดงผล PDF โดยรับ Panel และ PictureBox ที่อยู่ข้างในมาควบคุม
        /// </summary>
        public Class_PdfImageViewer(Panel containerPanel, PictureBox pictureBox)
        {
            _containerPanel = containerPanel ?? throw new ArgumentNullException(nameof(containerPanel));
            _pictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox));

            InitializeControls();
        }

        private void InitializeControls()
        {
            // ตั้งค่าพื้นฐานให้ PictureBox
            _pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
           // _pictureBox.Cursor = Cursors.Hand;

            // ผูก Events
            _pictureBox.MouseDown += PictureBox_MouseDown;
            _pictureBox.MouseMove += PictureBox_MouseMove;
            _pictureBox.MouseUp += PictureBox_MouseUp;
            _pictureBox.MouseWheel += PictureBox_MouseWheel;
            _pictureBox.MouseEnter += PictureBox_MouseEnter;
        }

        /// <summary>
        /// โหลดไฟล์ PDF ตาม Path และเลขหน้าที่ต้องการ (หน้าแรกคือ 0)
        /// </summary>
        public void LoadPdf(string pdfPath, int pageIndex = 0, int dpi = 200, bool fitToWindow = true)
        {
            if (!File.Exists(pdfPath))
                throw new FileNotFoundException("ไม่พบไฟล์ PDF ตามที่ระบุ", pdfPath);

            using (var pdfStream = File.OpenRead(pdfPath))
            using (var memoryStream = new MemoryStream())
            {
                Conversion.SavePng(memoryStream, pdfStream, page: pageIndex, options: new RenderOptions(Dpi: dpi));
                memoryStream.Position = 0;

                // ล้างรูปเก่าเพื่อป้องกัน Memory Leak
                if (_pictureBox.Image != null)
                {
                    _pictureBox.Image.Dispose();
                }

                using (var tempImage = Image.FromStream(memoryStream))
                {
                    _pictureBox.Image = new Bitmap(tempImage);
                }
            }

            if (fitToWindow)
            {
                FitToWindow();
            }
            else
            {
                ResetZoom();
            }
        }

        /// <summary>
        /// ปรับขนาดภาพให้พอดีกับกรอบ Panel และจัดกึ่งกลาง
        /// </summary>
        public void FitToWindow()
        {
            if (_pictureBox.Image == null) return;

            float ratioX = (float)_containerPanel.ClientSize.Width / _pictureBox.Image.Width;
            float ratioY = (float)_containerPanel.ClientSize.Height / _pictureBox.Image.Height;
            _zoomFactor = Math.Min(ratioX, ratioY);

            int newWidth = (int)(_pictureBox.Image.Width * _zoomFactor);
            int newHeight = (int)(_pictureBox.Image.Height * _zoomFactor);

            // จัดกึ่งกลาง Panel
            int centerX = (_containerPanel.ClientSize.Width - newWidth) / 2;
            int centerY = (_containerPanel.ClientSize.Height - newHeight) / 2;

            _pictureBox.SetBounds(centerX, centerY, newWidth, newHeight);
        }

        /// <summary>
        /// รีเซ็ตการซูมกลับไปที่ขนาดจริง 100% (มุมซ้ายบน)
        /// </summary>
        public void ResetZoom()
        {
            if (_pictureBox.Image == null) return;

            _zoomFactor = 1.0f;
            _pictureBox.SetBounds(0, 0, _pictureBox.Image.Width, _pictureBox.Image.Height);
        }

        // --- Events การลากและซูม ---

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            _pictureBox.Focus();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _pictureBox.Image != null)
            {
                _isDragging = true;
                _startPoint = e.Location;
               // _pictureBox.Cursor = Cursors.SizeAll;
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                int rawLeft = _pictureBox.Left + (e.X - _startPoint.X);
                int rawTop = _pictureBox.Top + (e.Y - _startPoint.Y);

                _pictureBox.Location = ClampPosition(rawLeft, rawTop, _pictureBox.Width, _pictureBox.Height);
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;
               // _pictureBox.Cursor = Cursors.Hand;
            }
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_pictureBox.Image == null) return;

            float oldZoom = _zoomFactor;

            if (e.Delta > 0)
                _zoomFactor = Math.Min(MaxZoom, _zoomFactor + ZoomStep);
            else if (e.Delta < 0)
                _zoomFactor = Math.Max(MinZoom, _zoomFactor - ZoomStep);

            if (Math.Abs(oldZoom - _zoomFactor) < 0.001f) return;

            float ratio = _zoomFactor / oldZoom;
            int newWidth = (int)(_pictureBox.Image.Width * _zoomFactor);
            int newHeight = (int)(_pictureBox.Image.Height * _zoomFactor);

            int rawLeft = (int)(_pictureBox.Left - (e.X * (ratio - 1)));
            int rawTop = (int)(_pictureBox.Top - (e.Y * (ratio - 1)));

            Point clampedPos = ClampPosition(rawLeft, rawTop, newWidth, newHeight);
            _pictureBox.SetBounds(clampedPos.X, clampedPos.Y, newWidth, newHeight);
        }

        // --- ล็อกขอบเขตไม่ให้ภาพหลุดนอกกรอบ Panel ---
        private Point ClampPosition(int targetLeft, int targetTop, int picWidth, int picHeight)
        {
            int minX, maxX, minY, maxY;

            if (picWidth > _containerPanel.ClientSize.Width)
            {
                minX = _containerPanel.ClientSize.Width - picWidth;
                maxX = 0;
            }
            else
            {
                minX = 0;
                maxX = _containerPanel.ClientSize.Width - picWidth;
            }

            if (picHeight > _containerPanel.ClientSize.Height)
            {
                minY = _containerPanel.ClientSize.Height - picHeight;
                maxY = 0;
            }
            else
            {
                minY = 0;
                maxY = _containerPanel.ClientSize.Height - picHeight;
            }

            return new Point(
                Math.Clamp(targetLeft, minX, maxX),
                Math.Clamp(targetTop, minY, maxY)
            );
        }

        // คืนทรัพยากรเมื่อปิดฟอร์ม
        public void Dispose()
        {
            _pictureBox.MouseDown -= PictureBox_MouseDown;
            _pictureBox.MouseMove -= PictureBox_MouseMove;
            _pictureBox.MouseUp -= PictureBox_MouseUp;
            _pictureBox.MouseWheel -= PictureBox_MouseWheel;
            _pictureBox.MouseEnter -= PictureBox_MouseEnter;

            if (_pictureBox.Image != null)
            {
                _pictureBox.Image.Dispose();
                _pictureBox.Image = null;
            }
        }
    }
}
