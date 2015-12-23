using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Bomberman.Model.MapObject
{
    public abstract class MapObject
    {
        public Point Position { get; internal set; }
        public ImageSource ImageOnCanvas { get; set; }
        public ImageSource ImageStock { get; set; }
        public ImageSource ImageDestroying { get; set; }

        public MapObject(int x, int y)
        {
            Position = new Point(x, y);
            FillImages();
        }
        public MapObject(Point position_i)
        {
            Position = position_i;
            FillImages();
        }

        private void FillImages()
        {
            ImageStock = new BitmapImage(new Uri("ms-appx:///Assets/MapObject/NULL.png"));
            ImageDestroying = new BitmapImage(new Uri("ms-appx:///Assets/MapObject/NULL.png"));
            ImageOnCanvas = ImageStock;
        }
    }
}
