﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gr_editor;
using gr_editor.Interfaces;
using static System.Math;

namespace Rhombus
{
    class Rhombus : AbstrFigure, ISelectable, IMovable
    {
        public Rhombus(Point a, Point b) : base(a, b)
        {

        }



        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, x, y + h / 2, x + w / 2, y);
            g.DrawLine(pen, x + w / 2, y, x + w, y + h / 2);
            g.DrawLine(pen, x + w, y + h / 2, x + w / 2, y + h);
            g.DrawLine(pen, x + w / 2, y + h, x, y + h / 2);
            SolidBrush solidBrush = new SolidBrush(Color.Azure);
            Point point1 = new Point((int)x, ((int)(y + h / 2)));
            Point point2 = new Point((int)(x + w / 2), ((int)(y)));
            Point point3 = new Point((int)(x + w), ((int)(y + h / 2)));
            Point point4 = new Point((int)(x + w / 2), ((int)(y + h)));
            Point[] triPoints = { point1, point2, point3, point4 };
            g.FillPolygon(solidBrush, triPoints);
            if (isSelected)
            {
                ShowSelection(g);
            }
        }

        public override bool IsSelected(Point point)
        {
            float axis1 = w / 2;//принимается за меньшую
            float axis2 = h / 2;
            if (axis1 > axis2)
                axis1 = axis2;
            Point center = new Point((int)(x + w / 2), (int)(y + h / 2));
            float dist = (float)Sqrt(Pow((center.X - point.X), 2) + Pow((center.Y - point.Y), 2));
            if (dist < axis1)
                return true;
            else
                return false;
        }

        public override void ShowSelection(Graphics g)
        {
            base.ShowSelection(g);
        }
    }
}
