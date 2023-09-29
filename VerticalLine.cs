using jalgpall;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jalgpall;

namespace jalgpall
{
    class VerticalLine : Figure
    {   
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            //конструктор класса с четырьмя параметрами.

            pList = new List<Point>();
            //Создание списка точек для вертикальной линии.

            for (int y = yUp; y <= yDown; y++)
            {
                //Цикл, который проходит через все координаты по вертикали от "yUp" до "yDown".

                Point p = new Point(x, y, sym);
                //Создание новой точки с координатами (x, y) и символом "sym".

                pList.Add(p);
                //Добавление созданной точки в список "pList".
            }
        }
    }
}