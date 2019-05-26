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

namespace Mestint_Chains
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int color = 0;
        int player = 1;    //black
        int opponent = 2;    //white

        public MainWindow()
        {
            InitializeComponent();
            StackPanel myStackPanel = MyStackPanel;
            Game game = new Game();

            CreateBoard();            
        }

        void CreateBoard()
        {
            List<int[]> originalBoard = new List<int[]>()
            {
                new int[]{0,0,0,0 },
                new int[]{0,0,0,0,0 },
                new int[]{0,0,0,0,0,0 },
                new int[]{0,0,0,0,0 },
                new int[]{0,0,0,0 },
            };

            Grid[] grids = new Grid[5]
            {
                FirstRow,
                SecondRow,
                ThirdRow,
                FourthRow,
                FifthRow
            };

            for (int i = 0; i < grids.Length; i++)
            {
                int[] row = originalBoard[i];
                for (int j = 0; j < row.Length; j++)
                {
                    Canvas canvas = new Canvas();
                    canvas.MouseDown += Canvas_MouseDown;
                    canvas.Background = Brushes.Wheat;
                    Grid.SetRow(canvas, i);
                    Grid.SetColumn(canvas, j);
                    grids[i].Children.Add(canvas);
                }
            }
        }

        //***************** EVENTS *****************
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int r = Grid.GetRow(sender as Canvas);
            int c = Grid.GetColumn(sender as Canvas);
            Canvas senderCanvas = sender as Canvas;

            if (color != 0 && senderCanvas.Children.Count == 0)
            {
                if (color == 1) //Player
                {
                    Circle newCircle = new Circle(17);
                    newCircle.Draw(sender as Canvas, Brushes.Black);
                }
                else if (color == 2)    //Opponent
                {
                    Circle newCircle = new Circle(17);
                    newCircle.Draw(sender as Canvas, Brushes.White);
                }
            }            
        }

        private void ChangeColor_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button.Name == "BlackButton")
            {
                color = 1;  //Player
            }
            else if (button.Name == "WhiteButton")
            {
                color = 2;  //Opponent
            }
        }
    }
}
