using System;
using System.Collections.Generic;
using HalconDotNet;

namespace Vision2D
{
    public class ShapeManager
    {
        private List<Shape2DBase> _shapes;

        private HWindow _window;

        private HImage _image;

        private int _activeShapeIdx = -1;

        private const double POSITIVERANGE = 20.0;  //鼠标有效操作范围

        private double _oSize = 2.0;

        public ShapeManager()
        {
            _shapes = new List<Shape2DBase>();
        }

        public void SetWindow(HWindow window)
        {
            _window = window;
        }

        public void UpdateImage(HImage image)
        {
            _image = image;
        }

        public void AddShape(Shape2DBase shape)
        {
            if (_shapes.Contains(shape))
                return;
            shape.OSize = _oSize;
            shape.Init(_window, _image);
            _shapes.Add(shape);
        }

        public void RemoveShape(Shape2DBase shape)
        {
            _shapes.Remove(shape);
        }

        public void SetOSize(double oSzie)
        {
            _oSize = oSzie;
            foreach (Shape2DBase shape in _shapes)
            {
                shape.OSize = oSzie;
            }
        }

        public void ClearShapes()
        {
            _shapes.Clear();
        }

        public void DrawShapes()
        {
            foreach (Shape2DBase shape in _shapes)
            {
                //_window.GetPart(out int row0, out int col0, out int row1, out int col1);
                //_window.GetWindowExtents(out int row, out int col, out _winWidth, out _winHeight);
                shape.Paint(_window);
            }
        }

        public int GetActiveShape(double imgX, double imgY)
        {
            if (_shapes.Count <= 0) return -1;

            double dist = 0.0;
            double max = 1000.0;
            _activeShapeIdx = -1;
            
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (!_shapes[i].IsEditable || !_shapes[i].IsVisible) continue;
                dist = _shapes[i].DistToClosestHandle(imgX, imgY);
                if (dist < max && dist < _oSize * 2)
                {
                    max = dist;
                    _activeShapeIdx = i;
                }
            }

            return _activeShapeIdx;
        }

        /// <summary>
		/// Reaction of ROI objects to the 'mouse button move' event: moving
		/// the active ROI.
		/// </summary>
		/// <param name="newX">x coordinate of mouse event</param>
		/// <param name="newY">y coordinate of mouse event</param>
		public void MoveOrZoomShape(double newX, double newY)
        {
            try
            {
                if (_activeShapeIdx == -1) return;
                _shapes[_activeShapeIdx].MoveOrZoom(newX, newY);
            }
            catch (Exception)
            {
                //没有显示roi的时候 移动鼠标会报错
            }
        }

        public void ResetActiveShapeIdx()
        {
            _activeShapeIdx = -1;
        }

        public Shape2DBase GetShapeByIndex(int idx)
        {
            return _shapes[_activeShapeIdx];
        }
    }
}
