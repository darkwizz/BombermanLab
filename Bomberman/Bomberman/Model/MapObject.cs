using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Bomberman.Model
{
    public abstract class MapObject
    {
        public Point Position { get; internal set; }
        public bool IsAlive { get; private set; }
        public Image Surface { get; set; }

        public MapObject(int x, int y)
        {
            IsAlive = true;
            Position = new Point(x, y);
        }

        public virtual void Destroy()
        {
            IsAlive = false;
        }
    }
}
