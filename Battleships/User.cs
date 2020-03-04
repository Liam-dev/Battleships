using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    class User : Player
    {
        protected string name;

        public User(string name)
        {
            this.name = name;
            Init();
        }


        public override void Turn()
        {
            Console.Clear();
            Console.WriteLine("Turn: {0}", name);
            PrintBoards();
            Console.CursorTop = 25;
            Console.CursorLeft = 0;
            Console.WriteLine("Where would you like to shoot?");
            Console.Write("X Coordinate: ");
            int x = Int32.Parse(Console.ReadLine());
            Console.Write("Y Coordinate: ");
            int y = Int32.Parse(Console.ReadLine());

            FireShot(new Position(x, y));

            PrintBoards();

        }

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
