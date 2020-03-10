using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    class Game
    {
        protected List<Player> players;
        protected Random rnd;

        public Game(List<Player> players, Random rnd)
        {
            this.rnd = rnd;

            this.players = players;

            foreach (Player player in players)
            {
                player.PlaceShips(rnd, false);
            }
        }

        public void Play()
        {
            //plays game until all of a players ships destroyed
            while (players.FindAll(player => player.HasLost).Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    Player player = players[i];
                    Player opponent = players[1 - i];

                    Position shot = player.Turn();
                    bool hit = opponent.ReceiveShot(shot);
                    player.ReceiveHitConfirmation(shot, hit);
                }
            }
        }
    }
}
