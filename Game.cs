using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jalgpall;

namespace jalgpall
{
    public class Game
    {
        public Team HomeTeam { get; } // Свойство HomeTeam для хранения команды, принимающей игру
        public Team AwayTeam { get; } // Свойство AwayTeam для хранения команды гостей
        public Stadium Stadium { get; }  // Свойство Stadium для хранения информации о стадионе
        public Ball Ball { get; private set; } // Свойство Ball для хранения мяча

        public Game(Team homeTeam, Team awayTeam, Stadium stadium)// Конструктор класса Game, который принимает команду-хозяйку (HomeTeam), команду гостей (AwayTeam) и стадион (Stadium)

        {
            // Инициализируем свойства HomeTeam, AwayTeam и Stadium переданными значениями
            HomeTeam = homeTeam;
            homeTeam.Game = this;
            AwayTeam = awayTeam;
            awayTeam.Game = this;
            Stadium = stadium;
        }

        public void Start()// Метод Start, который начинает игру и инициализирует мяч и позиции игроков на стадионе
        {
            // Создаем мяч и устанавливаем его в центр стадиона
            Ball = new Ball(Stadium.Width / 2, Stadium.Height / 2, this);
            // Начинаем игру для команды-хозяйки и команды гостей
            HomeTeam.StartGame(Stadium.Width / 2, Stadium.Height);
            AwayTeam.StartGame(Stadium.Width / 2, Stadium.Height);
        }
        private (double, double) GetPositionForAwayTeam(double x, double y)// Приватный метод GetPositionForAwayTeam для вычисления позиции для команды гостей
        {
            return (Stadium.Width - x, Stadium.Height - y);// Вычисляем позицию относительно поля команды гостей
        }

        public (double, double) GetPositionForTeam(Team team, double x, double y)// Метод GetPositionForTeam для вычисления позиции для указанной команды (используется для мяча)
        {
            return team == HomeTeam ? (x, y) : GetPositionForAwayTeam(x, y);// Если команда - команда-хозяйка, то возвращаем позицию как есть, иначе используем GetPositionForAwayTeam
        }

        public (double, double) GetBallPositionForTeam(Team team)// Метод GetBallPositionForTeam для получения позиции мяча для указанной команды

        {
            return GetPositionForTeam(team, Ball.X, Ball.Y);// Использует GetPositionForTeam для определения позиции мяча
        }

        public void SetBallSpeedForTeam(Team team, double vx, double vy)// Метод SetBallSpeedForTeam для установки скорости мяча для указанной команды
        {
            if (team == HomeTeam)// Если команда - команда-хозяйка, устанавливаем скорости мяча, иначе инвертируем их
            {
                Ball.SetSpeed(vx, vy);
            }
            else
            {
                Ball.SetSpeed(-vx, -vy);
            }
        }

        public void Move()// Метод Move для выполнения движения команды-хозяйки, команды гостей и мяча
        {
            HomeTeam.Move();// Вызываем метод Move для команды-хозяйки
            AwayTeam.Move();// Вызываем метод Move для команды гостей
            Ball.Move(); // Вызываем метод Move для мяча
        }
    }
}
