using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Bomberman.Model.MapObject
{
    public class BrickBlock : MapObject
    {
        public BrickBlock(int x, int y) : base(x, y)
        {
            SharedConstructor();
        }
        public BrickBlock(Point position_i) : base(position_i)
        {
            SharedConstructor();
        }
        private void SharedConstructor()
        {
            ImageStock = new BitmapImage(new Uri("ms-appx:///Assets/MapObject/Brick_Block.png"));
        }
    }
}
