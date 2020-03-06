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

        public Game(List<Player> players)
        {
            this.players = players;

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
