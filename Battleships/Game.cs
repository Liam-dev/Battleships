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
        Random rnd;

        public Game(List<Player> players, Random rnd)
        {
            this.rnd = rnd;

            this.players = players;
            players[0].SetOpponent(players[1]);
            players[1].SetOpponent(players[0]);

            foreach (Player player in players)
            {
                player.PlaceShips(rnd, false);
            }
        }

        public void Play()
        {

            while (players.FindAll(player => player.HasLost).Count == 0)
            {
                foreach (Player player in players)
                {
                    player.Turn();
                }
            }
        }
    }
}
