using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Model
{
    public class BombsBonus: Bonus
    {
        public BombsBonus(int x, int y) : base(x, y)
        {
            Type = BonusType.Bombs;
        }

        public override void MakeEffectOnPlayer(Player player)
        {
            player.BombsCount++;
        }
    }
}
