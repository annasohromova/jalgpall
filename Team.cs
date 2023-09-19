using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jalgpall;

namespace jalgpall
{
    public class Team
    {
        public List<Player> Players { get; } = new List<Player>(); // Список игроков в команде
        public string Name { get; private set; }  // Имя команды
        public Game Game { get; set; } // тип данных Game

        public Team(string name) // Конструктор класса Team, принимает имя команды
        { // Устанавливаем имя команды
            Name = name;
        }

        public void StartGame(int width, int height) // задает позицию для каждого игрока из списка на 11 строке . Метод для начала игры, устанавливает начальные позиции игроков на поле

        {
            Random rnd = new Random(); // Создаем объект Random для генерации случайных чисел
            foreach (var player in Players)// Для каждого игрока в списке Players
            {
                player.SetPosition(  // Устанавливаем случайные координаты для позиции игрока на поле

                    rnd.NextDouble() * width,
                    rnd.NextDouble() * height
                    );
            }
        }

        public void AddPlayer(Player player) // Метод для добавления игрока в команду

        {
            if (player.Team != null) return;// Если игрок уже принадлежит другой команде, завершаем выполнение метода
            Players.Add(player);// Добавляем игрока в список Players текущей команды
            player.Team = this;// Устанавливаем ссылку на текущую команду для игрока
        }

        public (double, double) GetBallPosition() // берем координаты мяча
        {
            return Game.GetBallPositionForTeam(this);// Вызываем метод GetBallPositionForTeam из объекта Game и передаем ссылку на текущую команду
        }

        public void SetBallSpeed(double vx, double vy) // устанавливаем скорость мяча
        {
            Game.SetBallSpeedForTeam(this, vx, vy);
        }

        public Player GetClosestPlayerToBall() // Ищем ближайшего игрока к мячу 
        {
            Player closestPlayer = Players[0]; // Инициализируем переменную closestPlayer первым игроком из списка
            double bestDistance = Double.MaxValue;// Инициализируем переменную bestDistance максимально возможным значением
            foreach (var player in Players)// Для каждого игрока в списке Players
            {
                var distance = player.GetDistanceToBall();// Вычисляем расстояние от текущего игрока до мяча
                if (distance < bestDistance)// Если это расстояние меньше лучшего найденного расстояния
                {// Обновляем ближайшего игрока и лучшее расстояние
                    closestPlayer = player;
                    bestDistance = distance;
                }
            }

            return closestPlayer;
        }

        public void Move()
        {// Вызываем метод MoveTowardsBall для ближайшего игрока к мячу
            GetClosestPlayerToBall().MoveTowardsBall(); //  двигает игрока к мячу
            Players.ForEach(player => player.Move());// Вызываем метод Move для всех игроков в команде
        }
    }
}
