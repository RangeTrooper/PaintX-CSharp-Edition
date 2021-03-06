﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gr_editor.Interfaces;
using static System.Math;

namespace gr_editor
{
    [Serializable]
    public abstract class AbstrFigure
    {
        [NonSerialized]
        public Graphics gc;
        [NonSerialized]
        public Point leftUpVert;
        [NonSerialized]
        public Point rightBotVert;
        [NonSerialized]
        public Pen myPen;
        public float x, y, w, h;
        [NonSerialized]
        public bool isSelected;

        public AbstrFigure(Point a,Point b)
        {
            leftUpVert = a;
            rightBotVert = b;
            SetDimensions(leftUpVert, rightBotVert);
            
        }
       
        public virtual void Draw(Graphics g,Pen pen)
        {
           
        }
        public virtual void Clear()
        {

        }

        public void SetDimensions(Point a,Point b)
        {
            if (b.X > a.X)
            {
                if (b.Y > a.Y)
                {
                    x = a.X;
                    y = a.Y;
                    w = b.X - a.X;
                    h = b.Y - a.Y;
                }
                else
                {
                    x = a.X;
                    y = b.Y;
                    w = b.X - a.X;
                    h = a.Y - b.Y;
                }
            }
            else
            {
                if (b.Y < a.Y)
                {
                    x = b.X;
                    y = b.Y;
                    w = a.X - b.X;
                    h = a.Y - b.Y;
                }
                else
                {
                    x = b.X;
                    y = a.Y;
                    w = a.X - b.X;
                    h = b.Y - a.Y;
                }
            }
        }

        

        public void Resize(Point rbv)
        {
            rightBotVert = rbv;
            SetDimensions(leftUpVert, rightBotVert);
        }

        public virtual bool IsSelected(Point point)
        {
            return true;
        }

        public virtual void ShowSelection(Graphics g)
        {
            SolidBrush solidBrush = new SolidBrush(Color.LimeGreen);
            g.FillRectangle(solidBrush, x - 10, y - 10, 10, 10);
            g.FillRectangle(solidBrush, x + w, y - 10, 10, 10);
            g.FillRectangle(solidBrush, x - 10, y + h, 10, 10);
            g.FillRectangle(solidBrush, x + w, y + h, 10, 10);
            Pen pen = new Pen(Color.Black, 2);
            g.DrawRectangle(pen, x, y, w, h);
        }

        public virtual void Move(Point a, Point b)
        {
            float dx = Abs(b.X - a.X);
            float dy = Abs(b.Y - a.Y);
            
            if (b.X > a.X)
            {
                if (b.Y > a.Y)
                {
                    x = x + dx;
                    y = y + dy;
                    leftUpVert.X +=(int) dx;
                    leftUpVert.Y += (int)dy;
                    rightBotVert.X += (int)dx;
                    rightBotVert.Y += (int)dy;
                }
                else
                {
                    x = x+dx;
                    y = y-dy;
                    leftUpVert.X += (int)dx;
                    leftUpVert.Y -= (int)dy;
                    rightBotVert.X += (int)dx;
                    rightBotVert.Y -= (int)dy;
                }
            }
            else
            {
                if (b.Y < a.Y)
                {
                    x = x-dx;
                    y = y-dy;
                    leftUpVert.X -= (int)dx;
                    leftUpVert.Y -= (int)dy;
                    rightBotVert.X -= (int)dx;
                    rightBotVert.Y -= (int)dy;
                }
                else
                {
                    x = x-dx;
                    y = y+dy;
                    leftUpVert.X -= (int)dx;
                    leftUpVert.Y += (int)dy;
                    rightBotVert.X -= (int)dx;
                    rightBotVert.Y += (int)dy;
                }
            }
        }
    }
}
