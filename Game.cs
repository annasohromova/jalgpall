
using jalgpall;

public class Game
{
    public Team HomeTeam { get; } // объект команда HomeTeam
    public Team AwayTeam { get; } // объект команда AwayTeam
    public Stadium Stadium { get; } // Публичное свойство для доступа к объекту стадиона. Только для чтения
    public Ball Ball { get; private set; } // объект мяча с возможностью установки только внутри класса
    public bool IsRunning { get; private set; } = true;

    public void Stop()
    {
        IsRunning = false;
    }
    public Game(Team homeTeam, Team awayTeam, Stadium stadium)
    {
        HomeTeam = homeTeam; // объект команды HomeTeam
        homeTeam.Game = this; // устанавливаем объекту команды HomeTeam ссылку на текущий объект игры
        AwayTeam = awayTeam; // объект команды AwayTeam
        awayTeam.Game = this; // устанавливаем объекту команды AwayTeam ссылку на текущий объект игры
        Stadium = stadium; // объект стадиона
    }
    public void Start()
    {
        Ball = new Ball(Stadium.Width / 2, Stadium.Height / 2, this); // создаем объект мяча и устанавливаем его в центре стадиона
        HomeTeam.StartGame(Stadium.Width / 2, Stadium.Height); // запускаем игру для команды HomeTeam
        AwayTeam.StartGame(Stadium.Width / 2, Stadium.Height); // запускаем игру для команды AwayTeam
    }

    private (double, double) GetPositionForAwayTeam(double x, double y)
    {
        return (Stadium.Width - x, Stadium.Height - y); // вычисляем позицию для команды AwayTeam на основе переданных координат
    }

    public (double, double) GetPositionForTeam(Team team, double x, double y)
    {
        return team == HomeTeam ? (x, y) : GetPositionForAwayTeam(x, y); // определяем позицию для указанной команды на основе переданных координат
    }

    public (double, double) GetBallPositionForTeam(Team team)
    {
        return GetPositionForTeam(team, Ball.X, Ball.Y); // получаем позицию мяча для указанной команды
    }

    public void SetBallSpeedForTeam(Team team, double vx, double vy)
    {
        if (team == HomeTeam)
        {
            Ball.SetSpeed(vx, vy); // скорость мяча для команды HomeTeam
        }
        else
        {
            Ball.SetSpeed(-vx, -vy); // скорость мяча для команды AwayTeam
        }
    }

    public void Move()
    {
        HomeTeam.Move(); // вызываем метод движения для команды HomeTeam
        AwayTeam.Move(); // вызываем метод движения для команды AwayTeam
        Ball.Move(); // вызываем метод движения для мяча
    }
}