using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jalgpall;

namespace jalgpall
{
    // Определение пространства имен "jalgpall".

    class Figure
    {
        // Определение класса "Figure".

        protected List<Point> pList;

        // Объявление защищенного поля "pList" типа List<Point>. Это поле будет содержать список точек, представляющих фигуру.

        public void Draw()
        {
            // Определение публичного метода "Draw".

            foreach (Point p in pList)
            {
                // Итерируемся по каждой точке в списке "pList".

                p.Draw();
                // Для каждой точки вызываем метод "Draw", который, вероятно, отвечает за отрисовку этой точки на экране.
            }
        }

        internal bool IsHit(Figure figure)
        {
            // Определение внутреннего метода "IsHit", который принимает объект типа "Figure" в качестве параметра.

            foreach (var p in pList)
            {
                // Итерируемся по каждой точке в списке "pList".

                if (figure.IsHit(p))
                    // Вызываем метод "IsHit" объекта "figure" для текущей точки.
                    // Этот метод, вероятно, проверяет, пересекает ли фигура "figure" данную точку "p".
                    return true; // Если пересечение обнаружено, возвращаем true.
            }
            return false; // Если пересечение не обнаружено, возвращаем false.
        }

        private bool IsHit(Point point)
        {
            // Определение частного метода "IsHit", который принимает объект типа "Point" в качестве параметра.

            foreach (var p in pList)
            {
                // Итерируемся по каждой точке в списке "pList".

                if (p.IsHit(point))
                    // Вызываем метод "IsHit" объекта "p" (точки) для данной точки "point".
                    // Этот метод, вероятно, проверяет, пересекает ли точка "point" данную точку "p".
                    return true; // Если пересечение обнаружено, возвращаем true.
            }
            return false; // Если пересечение не обнаружено, возвращаем false.
        }
    }
}
