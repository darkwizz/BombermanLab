using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Bomberman.Model.MapObjects
{
    public class HumanPlayer : MapObject, IPlayer
    {
        public Image ImageDead = new Image();

        public HumanPlayer(int x, int y) : base(x, y)
        {
            SharedConstructor();
        }
        public HumanPlayer(IntPoint point_i) : base(point_i)
        {
            SharedConstructor();
        }
        private void SharedConstructor()
        {
            ImageStock.Source = new BitmapImage(new Uri(ImageSources.BomberMan));
            ImageDead.Source = new BitmapImage(new Uri(ImageSources.BomberManDead));
            ImageOnGrid.Source = ImageStock.Source;
        }
    }
}
