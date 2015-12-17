using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Model
{
    public class DeseaseBonus: Bonus
    {
        public DeseaseBonus(int x, int y) : base(x, y)
        { }

        public override void MakeEffectOnPlayer(Player player)
        {
            Random random;
            // TODO: implement and think about desease structure
        }
    }
}
