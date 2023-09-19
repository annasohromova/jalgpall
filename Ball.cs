using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jalgpall;

namespace jalgpall
{
    public class Ball
    {
        public double X { get; private set; } // Свойство X для хранения позиции мяча по горизонтали
        public double Y { get; private set; }// Свойство Y для хранения позиции мяча по вертикали

        private double _vx, _vy;// Приватные переменные для хранения скоростей мяча по горизонтали и вертикали

        private Game _game;// Приватное поле для хранения ссылки на объект Game

        public Ball(double x, double y, Game game) // Конструктор класса Ball, который принимает начальные координаты мяча (x, y) и объект Game
        {
            _game = game;// Инициализируем поле _game ссылкой на объект Game
            // Устанавливаем начальные координаты мяча
            X = x;
            Y = y;
        }

        // Метод для установки скорости мяча (vx - скорость по горизонтали, vy - скорость по вертикали)
        public void SetSpeed(double vx, double vy) // устанавливаем скорость
        {// Устанавливаем значения скоростей в приватные переменные _vx и _vy

            _vx = vx;
            _vy = vy;
        }

        // Метод для перемещения мяча
        public void Move()
        {// Вычисляем новые координаты мяча на основе текущих координат и скоростей

            double newX = X + _vx;
            double newY = Y + _vy;
            if (_game.Stadium.IsIn(newX, newY)) // Проверяем, находится ли новая позиция мяча в пределах игрового поля (стадиона)
            {
                X = newX;// Если новая позиция в пределах поля, обновляем координаты мяча
                Y = newY;
            }
            else
            {
                _vx = 0; // Если новая позиция находится за пределами поля, сбрасываем скорости мяча
                _vy = 0;
            }
        }

    }
}
