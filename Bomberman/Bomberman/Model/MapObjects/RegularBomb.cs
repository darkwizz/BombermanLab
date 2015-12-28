using System;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Bomberman.Model.MapObjects
{
    public class RegularBomb : MapObject, IBomb
    {
        public delegate void OnExplodeHandler(RegularBomb bomb);
        public event OnExplodeHandler OnExplode;

        private DispatcherTimer timer;

        public int Strength = 1;

        public RegularBomb(IntPoint position_i, int interval) : base(position_i)
        {
            SharedConstructor();

            timer = new DispatcherTimer();
            timer.Tick += (s, e) =>
            {
                Explode();
            };
            timer.Interval = new TimeSpan(0, 0, 0, 0, interval);
            timer.Start();
        }
        private void SharedConstructor()
        {
            OnExplode += (b) => { };

            ImageStock.Source = new BitmapImage(new Uri(ImageSources.Bomb));
            ImageOnGrid.Source = ImageStock.Source;
        }

        public void Explode()
        {
            timer.Stop();
            OnExplode.Invoke(this);
        }
    }
}
