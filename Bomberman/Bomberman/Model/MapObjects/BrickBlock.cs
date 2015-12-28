using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Bomberman.Model.MapObjects
{
    public class BrickBlock : MapObject
    {
        public BrickBlock(int x, int y) : base(x, y)
        {
            SharedConstructor();
        }
        public BrickBlock(IntPoint position_i) : base(position_i)
        {
            SharedConstructor();
        }
        private void SharedConstructor()
        {
            ImageStock.Source = new BitmapImage(new Uri(ImageSources.BrickBlock));
            ImageOnGrid.Source = ImageStock.Source;
        }
    }
}
