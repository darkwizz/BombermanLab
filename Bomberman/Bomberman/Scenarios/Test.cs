using Bomberman.Model;
using Bomberman.Model.MapObjects;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Bomberman.Scenarios
{
    public class TestScenario : IScenario
    {
        Field field;

        public TestScenario(Grid grid_i, Canvas canvas_i)
        {
            if (grid_i == null) throw new NullReferenceException("Grid is NULL");
            if (canvas_i == null) throw new NullReferenceException("Canvas is NULL");
            field = new Field(grid_i, canvas_i);
        }

        public void Execute()
        {
            field.FillMapRandomly();
            BrickBlock bb1 = new BrickBlock(new IntPoint(4, 4));
            bb1.ImageOnGrid.Source = new BitmapImage(new Uri(ImageSources.Cheburashka));
            field.AddObject(bb1);
            BrickBlock bb2 = new BrickBlock(new IntPoint(4, 7));
            bb2.ImageOnGrid.Source = new BitmapImage(new Uri(ImageSources.Dota));
            field.AddObject(bb2);
            BrickBlock bb3 = new BrickBlock(new IntPoint(6, 8));
            bb3.ImageOnGrid.Source = new BitmapImage(new Uri(ImageSources.Troll));
            field.AddObject(bb3);

            field.AddObject(new HumanPlayer(new IntPoint(2, 2)));
        }

        public void KeyUpAction(Object sender, KeyEventArgs args)
        {
            field.KeyAction(args.Key);
        }
    }
}
