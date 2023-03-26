using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Tetris { 
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] tileImages = new ImageSource[]
         {
                new BitmapImage(new Uri("Assets/EmptyTile.png", UriKind.Relative)),
                new BitmapImage(new Uri("Assets/BlueTile.png", UriKind.Relative)),
                new BitmapImage(new Uri("Assets/DarkBlueTile.png", UriKind.Relative)),
                new BitmapImage(new Uri("Assets/GreenTile.png", UriKind.Relative)),
                new BitmapImage(new Uri("Assets/OrangeTile.png", UriKind.Relative)),
                new BitmapImage(new Uri("Assets/PinkTile.png", UriKind.Relative)),
                new BitmapImage(new Uri("Assets/RedTile.png", UriKind.Relative)),
                new BitmapImage(new Uri("Assets/YellowTile.png", UriKind.Relative))
         };

        private readonly Image[,] imageControls;
        private readonly int maxDelay = 1000;
        private readonly int minDelay = 75;
        private readonly int delayDecrease = 25;

        private Game game = new Game();

        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(game.Gameboard);
        }

        private Image[,] SetupGameCanvas(Gameboard board)
        {
            Image[,] imageControls = new Image[board.Rows, board.Columns];
            int cellSize = 25;

            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize
                    };

                    Canvas.SetTop(imageControl, (i - 2) * cellSize);
                    Canvas.SetLeft(imageControl, j * cellSize);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[i, j] = imageControl;
                }
            }

            return imageControls;
        }

        private void DrawBoard(Gameboard board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    int id = board.GetElement(i, j);
                    imageControls[i, j].Opacity = 1;
                    imageControls[i, j].Source = tileImages[id];
                }
            }
        }

        private void DrawBlock(Block block)
        {
            foreach (Point p in block.TilePoints())
            {
                imageControls[p.Row, p.Column].Opacity = 1;
                imageControls[p.Row, p.Column].Source = tileImages[block.Id];
            }
        }

        private void DrawGhostBlock(Block block)
        {
            int dropDistance = game.BlockDropDistance();

            foreach (Point p in block.TilePoints())
            {
                imageControls[p.Row + dropDistance, p.Column].Opacity = 0.25;
                imageControls[p.Row + dropDistance, p.Column].Source = tileImages[block.Id];
            }
        }

        private void Draw(Game game)
        {
            DrawBoard(game.Gameboard);
            DrawGhostBlock(game.CurrentBlock);
            DrawBlock(game.CurrentBlock);
            ScoreText.Text = $"Score: {game.Score}";
        }

        private async Task GameLoop()
        {
            Draw(game);

            while (!game.GameOver)
            {
                int delay = Math.Max(minDelay, maxDelay - (game.Score * delayDecrease));
                await Task.Delay(delay);
                game.MoveBlockDown();
                Draw(game);
            }

            GameOverMenu.Visibility = Visibility.Visible;
            FinalScoreText.Text = $"Score: {game.Score}";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (game.GameOver)
            {
                if( e.Key == Key.Enter )
                {
                    PlayAgain_Click(sender, e);
                }
                else
                {
                    return;
                }
            }

            switch (e.Key)
            {
                case Key.Left:
                    game.MoveBlockLeft();
                    break;
                case Key.Right:
                    game.MoveBlockRight();
                    break;
                case Key.Down:
                    game.MoveBlockDown();
                    break;
                case Key.Up:
                    game.RotateBlockClockwise();
                    break;
                case Key.X:
                    game.RotateBlockClockwise();
                    break;
                case Key.Z:
                    game.RotateBlockCounterclockwise();
                    break;
                case Key.Space:
                    game.DropBlock();
                    break;
                default:
                    return;
            }

            Draw(game);
        }

        private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            await GameLoop();
        }

        private async void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            game = new Game();
            GameOverMenu.Visibility = Visibility.Hidden;
            await GameLoop();
        }
    }
}
