using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Model
{
    public class Bomb: MapObject
    {
        public static readonly int EXPLOSION_DEFAULT_RADIUS = 2;

        public Player Owner { get; private set; }
        public int ExplosionTime
        {
            get
            {
                return 4;
            }
        }
        public int ExplosionRadius { get; private set; }
        public event EventHandler BombExploded;

        public Bomb(Player owner, int explosionRadius, int x, int y): base(x, y)
        {
            Owner = owner;
            ExplosionRadius = explosionRadius;
        }

        public void Explode()
        {
            Owner.BombsCurrentCount++;
            BombExploded(this, new EventArgs());
        }

        public override void Destroy()
        {
            Explode();
            base.Destroy();
        }
    }
}
