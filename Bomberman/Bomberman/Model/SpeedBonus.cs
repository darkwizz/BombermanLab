using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Model
{
    public class SpeedBonus: Bonus
    {
        public SpeedBonus(int x, int y) : base(x, y)
        {
            Type = BonusType.Speed;
        }

        public override void MakeEffectOnPlayer(Player player)
        {
            player.Speed++;
        }
    }
}
