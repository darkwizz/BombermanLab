using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Model
{
    public enum BonusType
    {
        FireIncrease,
        Desease,
        Speed,
        Bombs
    }

    public abstract class Bonus: MapObject
    {
        public BonusType Type { get; protected set; }

        public Bonus(int x, int y) : base(x, y)
        { }

        public abstract void MakeEffectOnPlayer(Player player);
    }
}
