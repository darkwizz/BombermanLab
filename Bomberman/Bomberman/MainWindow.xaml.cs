using Bomberman.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bomberman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IScenario scenario;

        public MainWindow()
        {
            InitializeComponent();

            scenario = new TestScenario(GameMapGrid, GameForegroundCanvas);
            scenario.Execute();
        }

        private void InitializeGameGrid(int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                GameMapGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < width; i++)
            {
                GameMapGrid.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void RecalculateGameGridSize()
        {
            if (GameGridOrient.ActualWidth > GameGridOrient.ActualHeight)
            {
                GameMapGrid.Width = GameGridOrient.ActualHeight;
                GameMapGrid.Height = GameGridOrient.ActualHeight;
            }
            else
            {
                GameMapGrid.Width = GameGridOrient.ActualWidth;
                GameMapGrid.Height = GameGridOrient.ActualWidth;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            RecalculateGameGridSize();
        }
    }
}
