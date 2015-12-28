using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bomberman.Model
{
    public class Detonator
    {
        public delegate void OnExplodeHandler();
        public event OnExplodeHandler OnExplode;

        private int _delay = 1000;

        public Detonator(int delay)
        {
            _delay = delay;

            OnExplode += () => { };

            Plant();
        }

        private async void Plant()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(_delay);
                OnExplode.Invoke();
            });
        }
    }
}
