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
        public MainWindow()
        {
            InitializeComponent();
            StackPanel myStackPanel = MyStackPanel;
            Game game = new Game();

            Grid[] grids = new Grid[5]{
                FirstRow,
                SecondRow,
                ThirdRow,
                FourthRow,
                FifthRow
            };

            List<int[]> originalBoard = new List<int[]>()
            {
                new int[]{0,0,0,0 },
                new int[]{0,0,0,0,0 },
                new int[]{0,0,0,0,0,0 },
                new int[]{0,0,0,0,0 },
                new int[]{0,0,0,0 },
            };
            
            CreateBoard(grids,originalBoard);

            newBoard = originalBoard;
        }

        List<int[]> newBoard = new List<int[]>();
        int color = 0;
        int nextTurn = 0;
        //int player = 1;    //black
       // int opponent = 2;    //white

        void CreateBoard(Grid[] grids, List<int[]> originalBoard)
        {
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

        public int[] GetCurrentBoard()
        {
            int[] currentBoardQueue = new int[24];
            List<int> list = new List<int>();

            for (int i = 0; i < newBoard.Count; i++)
            {
                for (int j = 0; j < newBoard[i].Length; j++)
                {
                    list.Add(newBoard[i][j]);
                }
            }

            currentBoardQueue = list.ToArray();
            return currentBoardQueue;
        }

        private void ShowMinimaxed(int minimax)
        {
            //TODO
            throw new NotImplementedException();
        }

        //***************** EVENTS *****************
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //int r = Grid.GetRow(sender as Canvas);
            int c = Grid.GetColumn(sender as Canvas);
            Canvas senderCanvas = sender as Canvas;
            Grid parentGrid = senderCanvas.Parent as Grid;
            SolidColorBrush brushesColor = Brushes.Red;
            if (color != 0 && senderCanvas.Children.Count == 0)
            {
                if (color == 1) //Player
                {
                    brushesColor = Brushes.Black;
                }
                else if (color == 2)    //Opponent
                {
                    brushesColor = Brushes.White;
                }

                if (parentGrid.Name == "FirstRow")
                {
                    newBoard[0][c] = color;
                }
                else if (parentGrid.Name == "SecondRow")
                {
                    newBoard[1][c] = color;
                }
                else if (parentGrid.Name == "ThirdRow")
                {
                    newBoard[2][c] = color;
                }
                else if (parentGrid.Name == "FourthRow")
                {
                    newBoard[3][c] = color;
                }
                else if (parentGrid.Name == "FifthRow")
                {
                    newBoard[4][c] = color;
                }

                Circle newCircle = new Circle(17);
                newCircle.Draw(sender as Canvas, brushesColor);
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

        private void AI_Click(object sender, RoutedEventArgs e)
        {
            if (PlayersComboBox.SelectedIndex>=0)
            {
                if (PlayersComboBox.SelectedIndex == 0)
                {
                    nextTurn = 1;
                }
                else if (PlayersComboBox.SelectedIndex == 1)
                {
                    nextTurn = 2;
                }
                Game game = new Game();
                int minimaxedMove = game.Minimax(GetCurrentBoard(), nextTurn);
                ShowMinimaxed(minimaxedMove);
            }
            else
            {
                MessageBox.Show("Next turn?");
            }   
        }
    }
}
