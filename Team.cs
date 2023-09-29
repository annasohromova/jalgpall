using jalgpall;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace jalgpall;

public class Team
{
    public List<Player> Players { get; } = new List<Player>(); // список игроков в команде
    public string Name { get; private set; } // название команды
    public Game Game { get; set; } // ссылка на объект игры, в которой участвует команда
    // конструктор команды
    public Team(string name)
    {
        Name = name; 
    }

    public void StartGame(int width, int height)
    {
        Random rnd = new Random(); // создаем объект Random для генерации случайных чисел
        foreach (var player in Players)
        {
            // начальная позицию каждого игрока внутри игрового поля с использованием случайных координат
            player.SetPosition(
                rnd.NextDouble() * width,
                rnd.NextDouble() * height
            );
        }
    }

    public void AddPlayer(Player player)
    {
        // добавленяем игрока в команду
        if (player.Team != null) return; // если игрок уже находится в другой команде, то ничего не делаем
        Players.Add(player); // добавляем игрока в список игроков команды
        player.Team = this; // устанавливаем ссылку на текущую команду в объекте игрока
    }

    public (double, double) GetBallPosition()
    {
        return Game.GetBallPositionForTeam(this); 
    }

    public void SetBallSpeed(double vx, double vy)
    {
        Game.SetBallSpeedForTeam(this, vx, vy); 
    }

    public Player GetClosestPlayerToBall()
    {
        // получение ближайшего игрока к мячу.
        Player closestPlayer = Players[0]; // инициализируем первого игрока как ближайшего
        double bestDistance = Double.MaxValue; // инициализируем наилучшее расстояние максимальным значением
        foreach (var player in Players)
        {
            var distance = player.GetDistanceToBall(); // получаем расстояние текущего игрока до мяча
            if (distance < bestDistance) // если расстояние меньше наилучшего расстояния, обновляем ближайшего игрока
            {
                closestPlayer = player;
                bestDistance = distance;
            }
        }

        return closestPlayer; // возвращаем ближайшего игрока
    }

    public void Move()
    {
        // метод для выполнения действий команды во время движения
        GetClosestPlayerToBall().MoveTowardsBall(); // ближайший игрок движется в направлении мяча
        Players.ForEach(player => player.Move()); // все игроки в команде выполняют движение
    }
}