using System;
using System.Windows.Controls;

namespace Bomberman.Scenarios
{
    public class TestScenario : IScenario
    {
        private Grid _gameMapGrid;
        private Canvas _gameForegroundCanvas;

        public TestScenario(Grid grid_i, Canvas canvas_i)
        {
            if (grid_i == null) throw new NullReferenceException("Grid is NULL");
            if (canvas_i == null) throw new NullReferenceException("Canvas is NULL");

            _gameMapGrid = grid_i;
            _gameForegroundCanvas = canvas_i;
        }

        public void Execute()
        {

        }

        private void InitializeMap()
        {

        }
    }
}
