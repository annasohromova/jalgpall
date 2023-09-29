
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using jalgpall;

namespace jalgpall
{
    internal class Program
    {
        public static void Main()
        {
            // Создаем домашнюю и гостевую команды.
            Team homeTeam = new Team("Home Team");
            Team awayTeam = new Team("Away Team");
            // Создаем стадион с указанными размерами.
            Stadium stadium = new Stadium(80, 20);
            // Создаем игру, передавая команды и стадион.
            Game game = new Game(homeTeam, awayTeam, stadium);
            // Создаем 22 игрока и добавляем их в команды.
            for (int i = 1; i <= 22; i++)
            {
                Player player = new Player($"Player {i}");
                if (i <= 11)
                {
                    homeTeam.AddPlayer(player);
                }
                else
                {
                    awayTeam.AddPlayer(player);
                }
            }
            game.Start();
            // Устанавливаем заголовок окна консоли и его размеры, основываясь на размерах стадиона.
            Console.Title = "Football Game";
            Console.WindowWidth = stadium.Width + 2; // Увеличиваем ширину окна на 2 для рамки.
            Console.WindowHeight = stadium.Height + 3; // Увеличиваем высоту окна на 3 для дополнительного места.

            while (true)
            {
                // Выполняем ход в игре.
                game.Move();
                // Отрисовываем поле игры с игроками и мячом.
                Functioon.DrawField(stadium.Width, stadium.Height, homeTeam.Players, awayTeam.Players, game.Ball);
                // Задерживаем выполнение программы на 100 миллисекунд для обновления состояния игры.
                Thread.Sleep(100);
                // Возвращаем курсор в начальную позицию (0, 0) для обновления вывода на консоль.
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
