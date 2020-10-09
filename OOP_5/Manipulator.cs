using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    class Manipulator : Figure
    {
        public Figure fig { get; private set; }
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Orange, 3), fig.x1 - 5, fig.y1 - 5, (fig.x2 - fig.x1) + 10, (fig.y2 - fig.y1) + 10);
        }

        public override bool Select(int sx, int sy)
        {
            throw new NotImplementedException();
        }

        public void Touch()
        {

        }

        public void Attach(Figure figure)
        {
            if (figure != null)
            fig = figure;
        }

        public void Clear()
        {

        }

        public void Update()
        {

        }

        public void Drag(double dx, double dy)
        {

        }
    }
}
