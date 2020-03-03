using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Battleships";

            Player liam = new User("Liam");
            Player oppo = new Opponent();

            liam.SetOpponent(oppo);
            oppo.SetOpponent(liam);

            Random rnd = new Random();
            liam.PlaceShips(rnd);
            oppo.PlaceShips(rnd);
            
            for (int i = 0; i < 10; i += 3)
            {
                for (int j = 0; j < 10; j += 3)
                {
                    oppo.FireShot(new Position(i, j));
                    liam.FireShot(new Position(i, j));
                }
            }
            
            
            //liam.FireShot(new Position(1, 1));
            //liam.FireShot(new Position(8, 1));
            

            liam.PrintBoards();




            /*
            
            Console.WriteLine("\nLiam:\n");
            liam.ownBoard.Print(new Position(0, 3));

            Console.CursorLeft = 75;
            Console.CursorTop = 1;
            Console.Write("Opponent:\n");
            oppo.ownBoard.Print(new Position(75, 3));
            
            

            Console.WriteLine("\n\n");
            for (int i = 0; i < 10; i++)
            {
                oppo.FireShot(new Position(9 - i, 9 - i));

            }

            Console.Write("Liam:\n");
            liam.ownBoard.Update();
            liam.ownBoard.Print(new Position(0, 30));

            Console.CursorLeft = 75;
            Console.CursorTop = 28;
            Console.Write("Opponent:\n");
            oppo.ownBoard.Update();
            oppo.ownBoard.Print(new Position(75, 30));
            */
        }
    }
}
