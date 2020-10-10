using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace OOP_5
{
    class Manipulator : Figure
    {
        public Figure fig { get; private set; }
        private int corner = -1;
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Orange, 3), fig.x1, fig.y1 , (fig.x2 - fig.x1),  (fig.y2 - fig.y1) );   
            g.DrawRectangle(new Pen(Color.Orange, 3), fig.x1, fig.y1, 10, 10);
            g.DrawRectangle(new Pen(Color.Orange, 3), fig.x2-10, fig.y2-10, 10, 10);
            g.DrawRectangle(new Pen(Color.Orange, 3), fig.x1, fig.y2 - 10, 10, 10);
            g.DrawRectangle(new Pen(Color.Orange, 3), fig.x2 - 10, fig.y1, 10, 10);
            switch (corner)
            {
                //Заливаю выбранный угол
                case 1: g.FillEllipse(new SolidBrush(Color.Orange), fig.x1, fig.y1, 10, 10);
                    break;
                case 2:
                    g.FillEllipse(new SolidBrush(Color.Orange), fig.x2 - 10, fig.y2 - 10, 10, 10);
                    break;
                case 3:
                    g.FillEllipse(new SolidBrush(Color.Orange), fig.x1, fig.y2 - 10, 10, 10);
                    break;
                case 4:
                    g.FillEllipse(new SolidBrush(Color.Orange), fig.x2 - 10, fig.y1, 10, 10);
                    break;
            }
        }
    
        public override bool Select(int sx, int sy)
        {
            throw new NotImplementedException();
        }

        //Выбор угла
        public void Touch(int sx, int sy)
        {
            if (isInside(sx, sy, new RectangleF(fig.x1, fig.y1, 10, 10)))
                corner = 1;
            else if (isInside(sx, sy, new RectangleF(fig.x2 - 10, fig.y2 - 10, 10, 10)))
                corner = 2;
            else if (isInside(sx, sy, new RectangleF(fig.x1, fig.y2 - 10, 10, 10)))
                corner = 3;
            else if (isInside(sx, sy, new RectangleF(fig.x2 - 10, fig.y1, 10, 10)))
                corner = 4;
            else
            corner = -1;
        }

        //Связываю манипулятор с фигурой
        public void Attach(Figure figure)
        {
            if (figure != null)
            fig = figure;
        }

        //Отвязываю
        public void Detach()
        {
            fig = null;
        }

        public void Update(Figure figure)
        {
            Attach(figure);
        }

        public void Drag(double dx, double dy)
        {

        }

        //Проверка на нажатие на конкретный угол
        private bool isInside(int sx, int sy, RectangleF rect)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            return path.IsVisible(sx, sy);
        }
    }
}
