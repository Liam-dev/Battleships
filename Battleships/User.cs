using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsFinal
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
            
        }
    }

}
