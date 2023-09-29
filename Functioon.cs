
using jalgpall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpall
{
    internal class Functioon
    {
        public static void DrawField(int width, int height, List<Player> homePlayers, List<Player> awayPlayers, Ball ball)
        {
            char borderSymbol = ':';
            char fieldSymbol = ' ';
            char homePlayerSymbol = 'H';
            char awayPlayerSymbol = 'G';
            char ballSymbol = 'O';

            DrawBorders(width, height, borderSymbol);
            DrawPlayers(width, height, homePlayers, homePlayerSymbol);
            DrawPlayers(width, height, awayPlayers, awayPlayerSymbol);
            DrawBall(width, height, ball, ballSymbol);
        }

        private static void DrawBorders(int width, int height, char borderSymbol)
        {
            for (int y = 0; y < height; y++)
            {
                Console.SetCursorPosition(0, y + 1);
                Console.Write(borderSymbol); 
                for (int x = 1; x < width - 1; x++)
                {
                    Console.Write(" "); 
                }
                Console.Write(borderSymbol);
            }

            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < width; i++)
            {
                Console.Write(borderSymbol); 
            }

            Console.SetCursorPosition(0, height + 1);
            for (int i = 0; i < width; i++)
            {
                Console.Write(borderSymbol);
            }
        }

        private static void DrawPlayers(int width, int height, List<Player> players, char playerSymbol)
        {
            foreach (var player in players)
            {
                int x = (int)Math.Round(player.X);
                int y = (int)Math.Round(player.Y);

                if (x > 0 && x < width - 1 && y > 0 && y < height)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = playerSymbol == 'H' ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.Write(playerSymbol);
                    Console.ResetColor();
                }
            }
        }

        private static void DrawBall(int width, int height, Ball ball, char ballSymbol)
        {
            int x = (int)Math.Round(ball.X);
            int y = (int)Math.Round(ball.Y);

            if (x > 0 && x < width - 1 && y > 0 && y < height)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(ballSymbol);
            }
        }
    }
}
