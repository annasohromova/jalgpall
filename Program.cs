using System;
using System.Collections.Generic;
using System.Drawing; // Подключение пространства имен для Point класса
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jalgpall;


namespace jalgpall
{
    public class Program
    {
        public static void Main()
        {
            Console.SetWindowSize(80, 20);
            Console.ForegroundColor = ConsoleColor.Green;
            Walls walls = new Walls(80, 25);
            walls.Draw();
            Console.ReadLine();
            Console.Clear();

        }
    }
}
