using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Model
{
    public class IncreaseFireBonus: Bonus
    {
        public IncreaseFireBonus(int x, int y) : base(x, y)
        {
            Type = BonusType.FireIncrease;
        }

        public override void MakeEffectOnPlayer(Player player)
        {
            player.ExplosionRadiusBonus++;
        }
    }
}
