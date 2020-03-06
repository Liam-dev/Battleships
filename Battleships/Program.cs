using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Battleships";

            Random rnd = new Random();

            List<Player> players = new List<Player>()
            {
                new User("Liam"),
                new Opponent(rnd)
            };

            Game newGame = new Game(players, rnd);
            newGame.Play();
        }
    }
}
