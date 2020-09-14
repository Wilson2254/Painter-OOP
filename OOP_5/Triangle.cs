using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace OOP_5
{
    public class Triangle : Figure
    {

        //Отрисовка треугольника
        public override void Draw(Graphics g)
        {
            PointF p1 = new PointF((x1+x2)/2,y1);
            PointF p2 = new PointF(x1, y2);
            PointF p3 = new PointF(x2, y2);
            PointF[] points1 = new PointF[3] { p1, p2, p3 };
            g.DrawPolygon(new Pen(Color.Black, 3), points1);
        }

        //Конструктор
        public Triangle(int x1, int x2, int y1, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        //Фабрика
        public class TriangleCreator : FigureCreator
        {
            public override Figure Create(int x1, int x2, int y1, int y2)
            {
                return new Triangle(x1, x2, y1, y2);
            }
        }

        //Выбор треугольника
        public override bool Select(int sx, int sy)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(x1, y1, x2 - x1, y2 - y1);
            return path.IsVisible(sx, sy);
        }
    }
}
