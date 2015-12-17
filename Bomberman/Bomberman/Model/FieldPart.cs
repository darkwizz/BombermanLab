using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Model
{
    public class FieldPart: MapObject
    {
        private bool hasBlock;

        public event EventHandler BlockDestroyed;
        public bool HasBlock
        {
            get
            {
                return hasBlock;
            }
            set
            {
                if (hasBlock && !value)
                {
                    EventHandler temp = BlockDestroyed;
                    if (temp != null)
                    {
                        BlockDestroyed(this, new EventArgs());
                    }
                }
                hasBlock = value;
            }
        }
        public Bonus Bonus { get; set; }

        public FieldPart(int x, int y) : base(x, y)
        { }
    }
}
