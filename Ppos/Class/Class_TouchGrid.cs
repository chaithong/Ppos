using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppos.Class
{
    internal class Class_TouchGrid
    {
        private readonly DataGridView _View;
        int startDragRowHandle = -1;
        int startDragColumnHandle = -1; //////////////////////////////

        int topRowIndex = -1;
        int topColumnIndex = -1;  //////////////////////////////

        private bool _IsDragging;

        public bool IsDragging
        {
            get { return _IsDragging; }
            set { _IsDragging = value; }
        }
        public Class_TouchGrid(DataGridView view)
        {
            _View = view;
            InitViewProperties();
        }
        private void InitViewProperties()
        {
            _View.Cursor = Cursors.Hand;
            _View.MultiSelect = false;
            _View.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _View.MouseDown += _View_MouseDown;
            _View.MouseMove += _View_MouseMove;
            _View.MouseUp += _View_MouseUp;
            _View.Layout += new LayoutEventHandler(_View_Layout!);
            _View.DataError += new DataGridViewDataErrorEventHandler(_View_DataError!);

        }
        private void _View_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        DataGridView.HitTestInfo myHitTest;

        private int GetRowUnderCursor(Point location)
        {
            myHitTest = _View.HitTest(location.X, location.Y);

            return myHitTest.RowIndex;
        }      
        void _View_Layout(object sender, LayoutEventArgs e)
        {
            try
            {
                IsDragging = false;
            }
            catch { }
        }
        private void DoScroll(int deltaRow)
        {
            try
            {
                if (deltaRow == 0)
                {
                    return;
                }

                if (deltaRow < 0 && _View.FirstDisplayedScrollingRowIndex == 0)
                {
                    deltaRow = 0;
                }

                _View.FirstDisplayedScrollingRowIndex += deltaRow;
            }
            catch
            {

            }


        }
        private void DoScroll2(int deltaColumn) //////////////////////////////////////////////////////////
        {
            try
            {
                if (deltaColumn == 0)
                {
                    return;
                }

                if (deltaColumn < 0 && _View.FirstDisplayedScrollingColumnIndex == 0)
                {
                    deltaColumn = 0;
                }
                _View.HorizontalScrollingOffset = deltaColumn;
            }
            catch
            {

            }


        }
        private void _View_MouseUp(object? sender, MouseEventArgs e)
        {
            try
            {
                IsDragging = false;
            }
            catch { }

        }

        private void _View_MouseMove(object? sender, MouseEventArgs e)
        {
            try
            {
                if (IsDragging)
                {                 
                    int newRow = GetRowUnderCursor(e.Location);
                    if (newRow >= 0)
                    {
                        int deltaRow = startDragRowHandle - newRow;
                        DoScroll(deltaRow);
                    }

                    DoScroll2(topColumnIndex - (e.X - startDragColumnHandle));

                }
            }
            catch { }
        }

        private void _View_MouseDown(object? sender, MouseEventArgs e)
        {
            try
            {
                IsDragging = true;
                startDragRowHandle = GetRowUnderCursor(e.Location);
                topRowIndex = _View.FirstDisplayedScrollingRowIndex;

                startDragColumnHandle = e.X;
                topColumnIndex = _View.HorizontalScrollingOffset;
            }
            catch { }
        }
    }
}
