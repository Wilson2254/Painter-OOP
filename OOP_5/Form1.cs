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
            tools.Add(new Circle.CircleCreator());
            tools.Add(new Rectangle.RectangleCreator());
            tools.Add(new Triangle.TriangleCreator());
        }

        Graphics gr;
        Figure fig;
        int x, y;
        List<Figure> figureList = new List<Figure>();
        List<FigureCreator> tools = new List<FigureCreator>();
        FigureCreator currentTool;
        Manipulator manipulator = new Manipulator();

        //Выбор пункта меню
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Круг
            currentTool = tools[0];
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Квадрат
            currentTool = tools[1];
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Треугольник
            currentTool = tools[2];
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //Очистка
            gr.Clear(Color.FromArgb(224, 224, 224));
            figureList.Clear();
            toolStripStatusLabel1.Text = "Клацнул на: ";
        }

        //private void toolStripButton8_Click(object sender, EventArgs e)
        //{
        //    //Выбор фигуры
        //    currentTool = null;
        //}

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }


        private void DrawAll(Graphics g)
        {
            foreach (Figure f in figureList)
            {
                f.Draw(gr);
            }
            //Отрисовка манипулятора
            if (manipulator.fig != null)
                manipulator.Draw(gr);
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //ОТРИСОВКА ФИГУРЫ
            manipulator.Detach();
            if (currentTool != null)
            {
                currentTool.Create(x, e.X, y, e.Y).Draw(gr);
                figureList.Add(currentTool.Create(x, e.X, y, e.Y));
                currentTool = null;
            }

            //МОЙ SELECT
            else
            {
                fig = null;
                foreach (Figure f in figureList)
                {
                    if (f.Select(e.X, e.Y))
                    {
                        fig = f;
                        //Связываю манипулятор
                        manipulator.Attach(fig);
                    }
                }
                if (fig != null)
                {
                    //Прорверка на какой угол нажал
                    manipulator.Touch(e.X, e.Y);
                    toolStripStatusLabel1.Text = "Клацнул на: " + fig.ToString().Substring(6);
                }
            }
            //Обновляю полотно
            pictureBox1.Refresh();
            DrawAll(gr);
        }

        //Отрисовываю все элементы которые пропадают
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawAll(gr);
        }

        //Задаю графику
        private void Form1_Load(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
        }
    }

}
