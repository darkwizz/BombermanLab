using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bomberman.Model
{
    public enum Direction { Horizontal, Vertical }

    public class Player: MapObject
    {
        public int BombsCount { get; internal set; }
        public int BombsCurrentCount { get; internal set; }
        public int ExplosionRadiusBonus { get; internal set; }
        public int Speed { get; internal set; }

        public Player(int x, int y) : base(x, y)
        { }

        public void Move(int delta, Direction direction)
        {
            int x = direction == Direction.Horizontal ? (int)Position.X + delta : (int)Position.X;
            int y = direction == Direction.Vertical ? (int)Position.Y + delta : (int)Position.Y;
            Position = new Point(x, y);
        }
        
        public Bomb PlaceBomb(EventHandler bombExploded)
        {
            if (BombsCurrentCount != 0)
            {
                Bomb bomb = new Bomb(this, Bomb.EXPLOSION_DEFAULT_RADIUS + ExplosionRadiusBonus,
                    (int)Position.X, (int)Position.Y);
                bomb.BombExploded += bombExploded;
                BombsCurrentCount--;
                return bomb;
            }
            return null;
        }

        public void ResetBonuses()
        {
            BombsCount = 3;
            ExplosionRadiusBonus = 0;
            Speed = 1;
        }

        public void PickBonus(Bonus bonus)
        {
            bonus.MakeEffectOnPlayer(this);
        }

        public override void Destroy()
        {
            ResetBonuses();
            base.Destroy();
        }
    }
}
