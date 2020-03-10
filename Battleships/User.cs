using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    class User : Player
    {
        public User(string name)
        {
            Name = name;
            Init();
        }

        //displayes boards, asks user for next firing position, then displayes updated boards
        public override Position Turn()
        {
            Console.Clear();
            Console.WriteLine("Turn: {0}", Name);
            PrintBoards();
            Console.CursorTop = 25;
            Console.CursorLeft = 0;
            Console.WriteLine("Where would you like to target?");
            int x = -1;
            do
            {
                Console.Write("X Coordinate: ");
                try
                {
                    x = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Enter a number between 0 and 10");
                }                

            } while (!(x >= 0 && x < 10));

            int y = -1;
            do
            {
                Console.Write("Y Coordinate: ");
                try
                {
                    y = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Enter a number between 0 and 10");
                }

            } while (!(x >= 0 && x < 10));

            return new Position(x, y);
        }

        //prints out all the user's boards side by side
        public void PrintBoards()
        {
            Console.Clear();
            for (int i = 0; i < boards.Length; i++)
            {
                Board board = boards[i];
                board.Update();
                board.Print(new Position(60 * i + 2, 2));
            }
        }     
    }
}
