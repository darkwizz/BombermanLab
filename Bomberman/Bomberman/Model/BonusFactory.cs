using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Model
{
    public static class BonusFactory
    {
        public static Bonus GetBonus(BonusType type, int x, int y)
        {
            switch (type)
            {
                case BonusType.Bombs:
                    return new BombsBonus(x, y);
                case BonusType.FireIncrease:
                    return new IncreaseFireBonus(x, y);
                case BonusType.Speed:
                    return new SpeedBonus(x, y);
                default:
                    return new DeseaseBonus(x, y);
            }
        }
    }
}
