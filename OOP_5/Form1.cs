using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tools.Add(null);
            tools.Add(new Circle.CircleCreator());
            tools.Add(new Rectangle.RectangleCreator());
            tools.Add(new Triangle.TriangleCreator());
        }

        int userChoise = 0;
        Graphics gr;
        Figure fig;
        int x, y;
        List<Figure> figureList = new List<Figure>();
        List<FigureCreator> tools = new List<FigureCreator>();
       
        //Выбор пункта меню
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Круг
            userChoise = 1;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Квадрат
            userChoise = 2;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Треугольник
            userChoise = 3;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //Очистка
            gr.Clear(Color.FromArgb(224, 224, 224));
            figureList.Clear();
            toolStripStatusLabel1.Text = "Клацнул на: ";
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            //Выбор фигуры
            userChoise = 4;
        }
        
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (userChoise)
            {
                //Круг
                case 1:                    
                    figureList.Add(tools[1].Create(x, e.X, y, e.Y));
                    tools[1].Create(x, e.X, y, e.Y).Draw(gr);
                    break;

                //Квадрат
                case 2:
                    figureList.Add(tools[2].Create(x, e.X, y, e.Y));
                    tools[2].Create(x, e.X, y, e.Y).Draw(gr);
                    break; 

                //Треугольник
                case 3:
                    figureList.Add(tools[3].Create(x, e.X, y, e.Y));
                    tools[3].Create(x, e.X, y, e.Y).Draw(gr);
                    break;

                //Выбор фигуры
                case 4:
                    fig = null;
                    foreach (Figure f in figureList)
                    {
                        if (f.Select(e.X, e.Y))
                        {
                            fig = f;
                        }
                    }
                    if (fig != null)
                    {
                        toolStripStatusLabel1.Text = "Клацнул на: " + fig.ToString().Substring(6);
                    }
                    break;
            }
           
        }

        //Отрисовываю все элементы которые пропадают
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure f in figureList)
            {
                f.Draw(gr);
            }
        }

        //Задаю графику
        private void Form1_Load(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
        }
    }

}
