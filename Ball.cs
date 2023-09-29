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
        public double X { get; private set; } // координата X мяча, задается только внутри класса
        public double Y { get; private set; } // координата Y мяча, задается только внутри класса

        private double _vx, _vy; // поля для хранения скорости мяча по осям X и Y

        private Game _game; // Приватное поле для хранения ссылки на объект игры.
        private void ResetToCenter()
        {
            X = _game.Stadium.Width / 2;
            Y = _game.Stadium.Height / 2;
            _vx = _vy = 0;
        }
        public Ball(double x, double y, Game game)
        {
            _game = game; // устанавливаем ссылку на объект игры
            X = x; // начальная координата X мяча
            Y = y; // начальная координата Y мяча
        }

        public void SetSpeed(double vx, double vy)
        {
            _vx = vx; // устанавливаем x скорость мяча
            _vy = vy; // устанавливаем y скорость мяча
        }

        public void Move()
        {
            double newX = X + _vx; // вычисляем новую x координату мяча
            double newY = Y + _vy; // вычисляем новую y координату мяча
            if (_game.Stadium.IsIn(newX, newY)) // Проверяем, остается ли мяч в пределах поля стадиона
            {
                X = newX; // если мяч остается в пределах поля, обновляем его координаты
                Y = newY;
            }
            else
            {
                // если мяч покидает пределы поля, скорость = 0
                ResetToCenter();
            }
        }
    }
}
