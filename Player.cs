using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jalgpall;

namespace jalgpall
{
    public class Player
    {
        //väljud
        public string Name { get; } //mängija nimi
        public double X { get; private set; } //mängija x koordinaat
        public double Y { get; private set; } //mängija y koordinaat
        private double _vx, _vy; //mängija ja palli kaugus
        public Team? Team { get; set; } = null; // команда, kus mängija mängib

        private const double MaxSpeed = 5; //скорость бега
        private const double MaxKickSpeed = 25; // скорость удара
        private const double BallKickDistance = 10; // расстояние полета мячв

        private Random _random = new Random(); // создаем объект рандом


        //konstruktorid
        public Player(string name) //создаем конструктор. Зависит от строки и приравнивается полю Name
        {
            Name = name;
        }

        public Player(string name, double x, double y, Team team) //игрок который на поле
        {
            Name = name;
            X = x;
            Y = y;
            Team = team;
        }

        public void SetPosition(double x, double y) // устанавливаем позицию для перемещения и расстановки игроков
        {
            X = x;
            Y = y;
        }

        public (double, double) GetAbsolutePosition() // возвращает команду игрока и его позицию 
        {
            return Team!.Game.GetPositionForTeam(Team, X, Y);
        }

        public double GetDistanceToBall() // возвращает дистанцию до мяча
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X; // 1 катет
            var dy = ballPosition.Item2 - Y; // 2 катет
            return Math.Sqrt(dx * dx + dy * dy); // передвигаемся по гипотенузе
        }

        public void MoveTowardsBall() // Передвигаем игрока к мячу 
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            var ratio = Math.Sqrt(dx * dx + dy * dy) / MaxSpeed;
            _vx = dx / ratio; // расчитываем путь к мячу
            _vy = dy / ratio; 
        }

        public void Move()
        {
            if (Team.GetClosestPlayerToBall() != this)
            {
                _vx = 0;
                _vy = 0;
            }

            if (GetDistanceToBall() < BallKickDistance) //если расстояние до мяча меньше, чем требуется для удара, то задаем скорость мячу
            {
                Team.SetBallSpeed(
                    MaxKickSpeed * _random.NextDouble(),
                    MaxKickSpeed * (_random.NextDouble() - 0.5)
                    );
            }

            var newX = X + _vx; 
            var newY = Y + _vy;
            var newAbsolutePosition = Team.Game.GetPositionForTeam(Team, newX, newY);
            if (Team.Game.Stadium.IsIn(newAbsolutePosition.Item1, newAbsolutePosition.Item2)) //если игрок вышел за поле, то задаем новую позицию
            {
                X = newX;
                Y = newY;
            }
            else
            {
                _vx = _vy = 0;
            }
        }
    }
}
