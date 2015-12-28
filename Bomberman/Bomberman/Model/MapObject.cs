using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Bomberman.Model
{
    public abstract class MapObject
    {
        private IntPoint _position = new IntPoint();
        public IntPoint Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                ImageOnGrid.SetValue(Grid.RowProperty, _position.Y);
                ImageOnGrid.SetValue(Grid.ColumnProperty, _position.X);
            }
        }
        public Image ImageOnGrid = new Image();
        public Image ImageStock = new Image();
        public Image ImageDestroying = new Image();

        public MapObject(int x, int y)
        {
            Position = new IntPoint(x, y);
            FillImages();
        }
        public MapObject(IntPoint position_i)
        {
            Position = position_i;
            FillImages();
        }

        private void FillImages()
        {
            ImageStock.Source = new BitmapImage(new Uri(ImageSources.Null));
            ImageDestroying.Source = new BitmapImage(new Uri(ImageSources.Null));
        }
    }
}
