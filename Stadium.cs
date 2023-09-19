using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jalgpall;

namespace jalgpall
{

    public class Stadium
    {// Свойство Width для хранения ширины стадиона
        public int Width { get; }

        // Свойство Height для хранения высоты стадиона
        public int Height { get; }

        // Конструктор класса Stadium, который принимает ширину и высоту стадиона

        public Stadium(int width, int height)
        { // Инициализируем свойства Width и Height значениями, переданными в конструктор

            Width = width;
            Height = height;
        }



        public bool IsIn(double x, double y) // Метод IsIn, который возвращает true или false в зависимости от того, находится ли точка внутри стадиона
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;// Проверяем, что координаты x и y находятся внутри границ стадиона

        }
    }
}
