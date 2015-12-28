using Bomberman.Model.MapObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Bomberman.Model
{
    #region MAIN
    public partial class Field
    {
        private Grid _gameMapGrid;
        private Canvas _gameForegroundCanvas;
        private List<MapObject> _mapObjects = new List<MapObject>();

        private MapObject _activePlayer;

        public Field(Grid grid_i, Canvas canvas_i)
        {
            _gameMapGrid = grid_i;
            _gameForegroundCanvas = canvas_i;
        }

        public async void FillMapRandomly()
        {
            Random random = new Random();
            for (int i = 0; i < _gameMapGrid.ColumnDefinitions.Count; i++)
            {
                for (int j = 0; j < _gameMapGrid.RowDefinitions.Count; j++)
                    if (random.Next(2) == 0)
                    {
                        await AddObject(new BrickBlock(i, j));
                    }
            }
        }

        public async Task AddObject(MapObject mapObject)
        {
            _gameMapGrid.Children.Add(mapObject.ImageOnGrid);
            _mapObjects.Add(mapObject);
            if ((mapObject as IPlayer) != null)
            {
                _activePlayer = mapObject;
            }
        }

        public void RemoveObject(MapObject mapObject)
        {
            _gameMapGrid.Children.Remove(mapObject.ImageOnGrid);
            _mapObjects.Remove(mapObject);
        }
        
        private void RemoveObjectsByPosition(IntPoint point)
        {
            for (int i = 0; i < _mapObjects.Count; i++)
            {
                if (_mapObjects[i].Position.X == point.X && _mapObjects[i].Position.Y == point.Y)
                {
                    if ((_mapObjects[i] as HumanPlayer) != null)
                    {
                        (_mapObjects[i] as HumanPlayer).ImageOnGrid.Source = (_mapObjects[i] as HumanPlayer).ImageDead.Source;
                        _isAlive = false;
                        MessageBox.Show("GAME OVER");
                    }
                    RemoveObject(_mapObjects[i]);
                    i--;
                }
            }
        }
    }
    #endregion

    #region KEY_HANDLING
    public partial class Field
    {
        private bool _isAlive = true;
        public void KeyAction(Key key)
        {
            if (!_isAlive) return;
            if ((_activePlayer as IPlayer) == null) return;
            
            switch (key)
            {
                case Key.Up:
                    PressUp();
                    break;
                case Key.Down:
                    PressDown();
                    break;
                case Key.Left:
                    PressLeft();
                    break;
                case Key.Right:
                    PressRight();
                    break;

                case Key.Space:
                    PressSpace();
                    break;
            }
        }
        private void PressUp()
        {
            GoUp();
        }
        private void PressDown()
        {
            GoDown();
        }
        private void PressLeft()
        {
            GoLeft();
        }
        private void PressRight()
        {
            GoRight();
        }
        private void PressSpace()
        {
            PlantBomb();
        }
    }
    #endregion

    #region MOVING
    public partial class Field
    {
        private void GoUp()
        {
            if (_activePlayer.Position.Y > 0)
            {
                if (!CheckPoint(new IntPoint(_activePlayer.Position.X, _activePlayer.Position.Y - 1)))
                {
                    _activePlayer.Position = new IntPoint(_activePlayer.Position.X, _activePlayer.Position.Y - 1);
                }
            }
        }
        private void GoDown()
        {
            if (_activePlayer.Position.Y < _gameMapGrid.RowDefinitions.Count - 1)
            {
                if (!CheckPoint(new IntPoint(_activePlayer.Position.X, _activePlayer.Position.Y + 1)))
                {
                    _activePlayer.Position = new IntPoint(_activePlayer.Position.X, _activePlayer.Position.Y + 1);
                }
            }
        }
        private void GoLeft()
        {
            if (_activePlayer.Position.X > 0)
            {
                if (!CheckPoint(new IntPoint(_activePlayer.Position.X - 1, _activePlayer.Position.Y)))
                {
                    _activePlayer.Position = new IntPoint(_activePlayer.Position.X - 1, _activePlayer.Position.Y);
                }
            }
        }
        private void GoRight()
        {
            if (_activePlayer.Position.X < _gameMapGrid.ColumnDefinitions.Count - 1)
            {
                if (!CheckPoint(new IntPoint(_activePlayer.Position.X + 1, _activePlayer.Position.Y)))
                {
                    _activePlayer.Position = new IntPoint(_activePlayer.Position.X + 1, _activePlayer.Position.Y);
                }
            }
        }

        private bool CheckPoint(IntPoint point)
        {
            foreach (MapObject item in _mapObjects)
            {
                if (item.Position.X == point.X && item.Position.Y == point.Y) return true;
            }
            return false;
        }
    }
    #endregion

    #region BOMBING
    public partial class Field
    {
        private async void PlantBomb()
        {
            MainWindow.MediaAA.Stop();
            MainWindow.MediaAA.Play();
            RegularBomb bomb = new RegularBomb(_activePlayer.Position, 2000);
            await AddObject(bomb);
            bomb.OnExplode += (bomb_res) =>
            {
                for (int i = 0; i < bomb_res.Strength; i++)
                {
                    RemoveObjectsByPosition(new IntPoint(bomb_res.Position.X + i + 1, bomb_res.Position.Y));
                    RemoveObjectsByPosition(new IntPoint(bomb_res.Position.X - i - 1, bomb_res.Position.Y));
                    RemoveObjectsByPosition(new IntPoint(bomb_res.Position.X, bomb_res.Position.Y + i + 1));
                    RemoveObjectsByPosition(new IntPoint(bomb_res.Position.X, bomb_res.Position.Y - i - 1));
                }
                RemoveObject(bomb_res);
                MainWindow.MediaAA.Stop();
            };
        }
    }
    #endregion
}
