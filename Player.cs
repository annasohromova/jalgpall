using jalgpall;
using System;

namespace jalgpall;

public class Player
{
    public string Name { get; } //задаем имя
    public double X { get; private set; } //х координата игрока
    public double Y { get; private set; } //y координата игрока
    private double _vx, _vy; // расстояние до мяча
    public Team? Team { get; set; } = null; // команда в которй играет игрок

    private const double MaxSpeed = 1; // скорость бега
    private const double MaxKickSpeed = 15; // скорость удара
    private const double BallKickDistance = 10; // расстояния полета мяча

    private Random _random = new Random(); // объект рандома
    //конструктор игрока
    public Player(string name) // конструктор игрока
    {
        Name = name; // задаем имя
    }
    // второй конструктор игрока
    public Player(string name, double x, double y, Team team) // игрок который на поле
    {
        //задаем ему значения на поле
        Name = name;
        X = x;
        Y = y;
        Team = team;
    }
    public void SetPosition(double x, double y)
    {
        //задаем позицию по двум координатам
        X = x;
        Y = y;
    }
    public (double, double) GetAbsolutePosition()
    {
        // возвращает позицию игрока при условии что Team не равен null
        return Team!.Game.GetPositionForTeam(Team, X, Y);
    }
    public double GetDistanceToBall()
    {
        // по теореме пифагора
        var ballPosition = Team!.GetBallPosition(); // получаем позицию мяча от команды игрока
        var dx = ballPosition.Item1 - X; // вычисляем разницу по X между игроком и мячом.
        var dy = ballPosition.Item2 - Y; // вычисляем разницу по Y между игроком и мячом.
        return Math.Sqrt(dx * dx + dy * dy); // возвращаем евклидово расстояние между игроком и мячом.
    }

    public void MoveTowardsBall()
    {
        var ballPosition = Team!.GetBallPosition(); // получаем позицию мяча от команды игрока.
        var dx = ballPosition.Item1 - X; // вычисляем разницу по X между игроком и мячом.
        var dy = ballPosition.Item2 - Y; // вычисляем разницу по Y между игроком и мячом.
        var ratio = Math.Sqrt(dx * dx + dy * dy) / MaxSpeed; // рассчитываем отношение расстояния к максимальной скорости.
        _vx = dx / ratio; // устанавливаем горизонтальную скорость для движения к мячу.
        _vy = dy / ratio; // устанавливаем вертикальную скорость для движения к мячу.
    }

    public void Move()
    {
        if (Team.GetClosestPlayerToBall() != this)
        {
            _vx = 0; // если игрок не ближайший к мячу, горизонтальная скорость = 0.
            _vy = 0; // если игрок не ближайший к мячу, вертикальная скорость = 0.
        }

        if (GetDistanceToBall() < BallKickDistance) // если дистанция до мяча меньше чем дистанция удара мяча то
        {
            Team.SetBallSpeed(
                MaxKickSpeed * _random.NextDouble(), // устанавливаем случайную горизонтальную скорость удара мяча.
                MaxKickSpeed * (_random.NextDouble() - 0.5) // устанавливаем случайную вертикальную скорость удара мяча.
            );
        }

        var newX = X + _vx; // рассчитываем новую x координату игрока.
        var newY = Y + _vy; // рассчитываем новую y координату игрока.
        var newAbsolutePosition = Team.Game.GetPositionForTeam(Team, newX, newY); // получаем новую абсолютную позицию игрока на поле.
        if (Team.Game.Stadium.IsIn(newAbsolutePosition.Item1, newAbsolutePosition.Item2))
        {
            X = newX; // если новая позиция в пределах поля, обновляем координаты игрока.
            Y = newY;
        }
        else
        {
            _vx = _vy = 0; // если новая позиция за пределами поля, устанавливаем скорость равную нулю.
        }
    }
}