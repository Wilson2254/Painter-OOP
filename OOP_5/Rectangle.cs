using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace OOP_5
{
    public class Rectangle : Figure
    {

        //Отрисовка квадрата
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Black, 3), x1, y1, x2 - x1, y2 - y1);
        }

        //Наследуем от предка
        public Rectangle(int x1, int x2, int y1, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        public class RectangleCreator : FigureCreator
        {
            public override Figure Create(int x1, int x2, int y1, int y2)
            {
                return new Rectangle(x1, x2, y1, y2);
            }
        }        

        //Выбираем квадрат
        public override bool Select(int sx, int sy)
        {
            GraphicsPath path = new GraphicsPath();
            RectangleF myrect = new RectangleF(x1, y1, x2 - x1, y2 - y1);
            path.AddRectangle(myrect);
            return path.IsVisible(sx, sy);
        }
    }
}
