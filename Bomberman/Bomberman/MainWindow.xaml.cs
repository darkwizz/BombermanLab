using Bomberman.Scenarios;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bomberman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MediaElement MediaAA;

        TestScenario scenario;

        public MainWindow()
        {
            InitializeComponent();

            MediaAA = MusicAA;

            InitializeGameGrid(10, 10);

            scenario = new TestScenario(GameMapGrid, GameForegroundCanvas);
            this.KeyUp += new KeyEventHandler(scenario.KeyUpAction);
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
