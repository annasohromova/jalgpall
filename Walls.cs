using System;
using System.Collections.Generic;
using System.Drawing; // Подключение пространства имен для Point класса
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jalgpall;


namespace jalgpall
{
    internal class Walls
    {
        List<Figure> wallList;
        public Walls(int mapWidth, int mapHeight)
        {
            //конструктор класса "Walls" с двумя аргументами: шириной и высотой игровой карты.
            wallList = new List<Figure>();
            // Отрисовка рамочки
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');

            // создание горизонтальных и вертикальных линий, представляющих верхнюю, нижнюю, левую и правую границы игрового поля.

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);

            // добавление линий в список стен.
        }

        internal bool IsHit(Figure figure)
        {
            //метод "IsHit" для проверки пересечения фигуры с стенами.

            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }

            // вызываем метод "IsHit" для каждой стены.
            // Если есть пересечение между фигурой и стеной, возвращаем true.

            return false;
            //возвращаем false.
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}

