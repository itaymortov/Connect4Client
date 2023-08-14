using ClientSideConnect4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace ClientSideConnect4
{

    public partial class Form1 : Form
    {
        
        private Connect4Database db = new Connect4Database();
        static HttpClient client = new HttpClient();
        private Bitmap bitmap;
        private Timer timer;
        const int EmptyCell = 0;
        const int Player1Token = 1;
        const int Player2Token = 2;
        const int numColumns = 7;
        const int numRows = 6;


        private int moveNum = 0;
        private bool turn = true;
        static Player player;
        private int gameID;

        private int[,] gameBoard = new int[numRows, numColumns];
        private Rectangle[,] Rects = new Rectangle[numRows, numColumns];
        private int rowCount = 0;
        private int column;
        private int row;
        private List<Move> gameMove;

        public Form1()
        {

            InitializeComponent();
            // disable logout button
            buttonLogout.Enabled = false;
            buttonLogout.Visible = false;
            timer = new Timer();
            timer.Interval = 200;
            pictureBox1.Enabled = false;
            StartGameButton.Enabled = false;
            GamesComboBox.Enabled = false;
            GamesComboBox.Visible = false;
            TextGame.Visible = false;
        }


        private async void start_Game()
        {
            timer.Stop();
            bool checkIsStartGame = await StartGameAsync("StartGame/", player.ID);
            if (checkIsStartGame)
            {
                New_Game();
                if(db.Games.Where(game => game.GameID == gameID).ToList().Count == 0)
                    db.AddGame(gameID, player.ID);
            }
        }

        private void New_Game()
        {
            turn = true;
            pictureBox1.Enabled = true;
            initGameBoard();
            initPictureBox();
            timer.Tick -= Timer_Tick;
            timer.Tick -= Timer_recreate;
            timer.Tick += Timer_Tick;
            pictureBox1.MouseClick += PictureBox1_Click;// Fetch the games by the player's ID.
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            client.BaseAddress = new Uri("https://localhost:7229/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        private void initGameBoard()
        {
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    gameBoard.SetValue(0, i, j);
                }
            }
        }

        private void initPictureBox()
        {

            bitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            int cellSize = this.pictureBox1.Width / numColumns;
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Blue);
                for (int row = 0; row < numRows; row++)
                {
                    for (int column = 0; column < numColumns; column++)
                    {
                        int x = column * cellSize;
                        int y = row * cellSize;

                        // Draw the cell
                        Rects[row, column] = new Rectangle(x, y, cellSize, cellSize);
                        g.DrawRectangle(Pens.Black, Rects[row, column]);

                        Rectangle cellRect = new Rectangle(x + 5, y + 5, cellSize - 10, cellSize - 10);
                        g.FillEllipse(Brushes.White, cellRect);
                    }
                }
            }
            pictureBox1.Image = bitmap;
        }

        private async Task<bool> StartGameAsync(string path, int myID)
        {
            var id = new { value = myID };
            HttpResponseMessage response = await client.PostAsJsonAsync(
                path, id);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                MessageBox.Show(responseContent, "MSG from server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.gameID = Int32.Parse(responseContent);
                return true;
            }
            return false;
        }

        static async void EndGameAsync(string path, string myID, bool isPlayerWin, int gameID)
        {
            var end_data = new
            {
                GameID = gameID,
                IsPlayerWin = isPlayerWin
            };
            HttpResponseMessage response = await client.PostAsJsonAsync(
                path, end_data);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                MessageBox.Show(responseContent, "MSG from server", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void serverTurn()
        {

            int servCol = await StepAsync("step/");
            if (servCol == -1)
            {
                servCol = await StepAsync("step/");
            }
            else
            {
                row = -1;
                int cellSize = pictureBox1.Width / numColumns;
                while (row == -1)
                {
                    row = CheckEmptyRow(servCol);
                    if (row == -1)
                        servCol = await StepAsync("step/");
                }
                column = servCol;

                db.AddMove(gameID, column, moveNum, turn);
                moveNum++;
                makeMove();
            }
        }

        static async Task<int> StepAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                int randomNumber = int.Parse(responseContent);
                return randomNumber;
            }

            return -1;
        }

        static async Task<IEnumerable<Player>> GetPlayersAsync(string path)
        {
            IEnumerable<Player> players = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                players = await response.Content.ReadAsAsync<IEnumerable<Player>>();
            }
            return players;
        }

        static async Task<Player> GetPlayerAsync(string path)
        {
            Player player = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    player = await response.Content.ReadAsAsync<Player>();
                }
                catch
                {
                    player = null;
                }
            }
            return player;
        }

        private void Register_Func(object sender, EventArgs e)
        {
            var specificUrl = "https://localhost:7229/Players/create";

            // Open the URL in a new tab
            System.Diagnostics.Process.Start(specificUrl);

        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            Task<Player> playerTask;
            try
            {
                playerTask = GetPlayerAsync("DetailsPlayers/" + this.textBoxID.Text);
            }
            catch
            {
                playerTask = null;
            }
            player = await playerTask;
            if (player != null)
            {
                this.labelAccount.Text = player.ID + "";
                this.labelAccountName.Text = player.FirstName;
                this.labelAccountPhone.Text = player.Phone;
                this.labelAccountCountry.Text = player.Country;
                buttonLogin.Enabled = false;
                buttonLogin.Visible = false;
                buttonRegister.Enabled = false;
                buttonRegister.Visible = false;
                buttonLogout.Enabled = true;
                buttonLogout.Visible = true;
                StartGameButton.Enabled = true;
                GamesComboBox.Enabled = true;
                GamesComboBox.Visible = true;
                TextGame.Visible = true;
                StartGameText.Text = "Click down here to start a game:";
                GamesComboBox.Visible = true;
                GamesComboBox.SelectedIndexChanged -= GamesComboBox_SelectedIndexChanged;
                List<Game> playerGames = db.GetGamesByPlayerId(player.ID);
                // Set the ComboBox data source and configure how items are displayed.
                GamesComboBox.DataSource = playerGames;
                GamesComboBox.DisplayMember = "GameId"; 
                GamesComboBox.ValueMember = "GameId"; 
                GamesComboBox.SelectedIndexChanged += GamesComboBox_SelectedIndexChanged;
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.labelAccount.Text = "";
            this.labelAccountName.Text = "";
            this.labelAccountPhone.Text = "";
            this.labelAccountCountry.Text = "";
            buttonLogin.Enabled = true;
            buttonLogin.Visible = true;
            buttonRegister.Enabled = true;
            buttonRegister.Visible = true;
            buttonLogout.Enabled = false;
            buttonLogout.Visible = false;
            StartGameButton.Enabled = false;
            Terminate_Game();
        }

        private void PictureBox1_Click(object sender, MouseEventArgs e)
        {
            if (pictureBox1.ClientRectangle.Contains(e.Location) && turn == true && !timer.Enabled)
            {
                int cellSize = pictureBox1.Width / numColumns;
                column = e.X / cellSize;
                row = CheckEmptyRow(column);
                if(row != -1)
                {
                    db.AddMove(gameID, column, moveNum, turn);
                    moveNum++;
                    makeMove();
                }

            }

        }
        private void makeMove()
        {
            if (turn == true)
            {
                if (column >= 0 && column < numColumns && row != -1)
                {
                    gameBoard[rowCount, column] = 1;
                    timer.Start();
                }
            }
            else if (turn == false)
            {
                if (column >= 0 && column < numColumns && row != -1)
                {

                    gameBoard[rowCount, column] = 2;
                    timer.Start();

                }
            }

        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            paintBox();
            if (rowCount != row)
            {
                gameBoard[rowCount, column] = 0;
            }
            rowCount++;
            if (rowCount == row + 1)
            {
                timer.Stop();
                rowCount = 0;
                turn = !turn;
                if (CheckForWin(1))
                {
                    EndGameAsync("EndGame/", player.ID + "", true, this.gameID);
                    EndGame();
                    paintBox();
                    winnerText.Text = "Client won";
                    return;
                }
                if (CheckForWin(2))
                {
                    EndGameAsync("EndGame/", player.ID + "", false, this.gameID);
                    EndGame();
                    paintBox();
                    winnerText.Text = "Computer won";
                    return;
                }

                if (turn == false)
                    serverTurn();
                return;
            }
            if (turn == true)
                gameBoard[rowCount, column] = 1;
            else if (turn == false)
                gameBoard[rowCount, column] = 2;
            pictureBox1.Image = bitmap;
           
        }



        private int CheckEmptyRow(int column)
        {
            if (gameBoard[0, column] != EmptyCell)
                return -1;
            for (int row = 0; row < numRows; row++)
            {
                if (gameBoard[row, column] != EmptyCell)
                {
                    if (gameBoard[row - 1, column] == EmptyCell)
                        return row - 1; // Return the row index where the token can be placed
                    else
                        break;
                }
            }
            if (gameBoard[numRows - 1, column] == EmptyCell)
                return numRows - 1;// Return the row index where the token can be placed
            return -1;
        }

        private void paintBox()
        {
            int cellSize = this.pictureBox1.Width / numColumns;
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Blue);
                for (int row = 0; row < numRows; row++)
                {
                    for (int column = 0; column < numColumns; column++)
                    {
                        int x = column * cellSize;
                        int y = row * cellSize;
                        g.DrawRectangle(Pens.Black, Rects[row, column]);

                        // Fill the cell with the corresponding token color
                        Brush cellColor = (gameBoard[row, column] == 3) ? Brushes.LightGreen :
                                (gameBoard[row, column] == Player1Token) ? Brushes.Red :
                                (gameBoard[row, column] == Player2Token) ? Brushes.Yellow : Brushes.White;
                        Rectangle cellRect = new Rectangle(x + 5, y + 5, cellSize - 10, cellSize - 10);
                        g.FillEllipse(cellColor, cellRect);
                    }
                }
            }
            pictureBox1.Image = bitmap;
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            start_Game();
        }
        private void Terminate_Game()
        {
            winnerText.Text = "";
            initGameBoard();
            initPictureBox();
            pictureBox1.Enabled = false;
            GamesComboBox.Enabled = false;
            TextGame.Visible = false;
            timer.Stop();
            rowCount = 0;
            StartGameText.Text = "Please login to play a game.";
            moveNum = 0;
        }

        private void EndGame()
        {
            pictureBox1.MouseClick -= PictureBox1_Click;
            timer.Stop();
            rowCount = 0;
            StartGameText.Text = "Click again to start the game";
            turn = true;
            GamesComboBox.SelectedIndexChanged -= GamesComboBox_SelectedIndexChanged;
            List<Game> playerGames = db.GetGamesByPlayerId(player.ID);
            // Set the ComboBox data source and configure how items are displayed.
            GamesComboBox.DataSource = playerGames;
            GamesComboBox.DisplayMember = "GameId";
            GamesComboBox.ValueMember = "GameId";
            GamesComboBox.SelectedIndexChanged += GamesComboBox_SelectedIndexChanged;
        }


        private bool CheckForWin(int playerID)
        {
            // Check for horizontal endGame
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numColumns - 3; col++)
                {
                    if (gameBoard[row, col] == playerID &&
                        gameBoard[row, col + 1] == playerID &&
                        gameBoard[row, col + 2] == playerID &&
                        gameBoard[row, col + 3] == playerID)
                    {
                        gameBoard[row, col] = 3;
                        gameBoard[row, col + 1] = 3;
                        gameBoard[row, col + 2] = 3;
                        gameBoard[row, col + 3] = 3;
                        return true;
                    }
                }
            }

            // Check for vertical endGame
            for (int row = 0; row < numRows - 3; row++)
            {
                for (int col = 0; col < numColumns; col++)
                {
                    if (gameBoard[row, col] == playerID &&
                        gameBoard[row + 1, col] == playerID &&
                        gameBoard[row + 2, col] == playerID &&
                        gameBoard[row + 3, col] == playerID)
                    {
                        gameBoard[row, col] = 3;
                        gameBoard[row + 1, col] = 3;
                        gameBoard[row + 2, col] = 3;
                        gameBoard[row + 3, col] = 3;
                        return true;
                    }
                }
            }

            // Check for diagonal (ascending) endGame
            for (int row = 3; row < numRows; row++)
            {
                for (int col = 0; col < numColumns - 3; col++)
                {
                    if (gameBoard[row, col] == playerID &&
                        gameBoard[row - 1, col + 1] == playerID &&
                        gameBoard[row - 2, col + 2] == playerID &&
                        gameBoard[row - 3, col + 3] == playerID)
                    {
                        gameBoard[row, col] = 3;
                        gameBoard[row - 1, col + 1] = 3;
                        gameBoard[row - 2, col + 2] = 3;
                        gameBoard[row - 3, col + 3] = 3;
                        return true;
                    }
                }
            }

            // Check for diagonal (descending) endGame
            for (int row = 0; row < numRows - 3; row++)
            {
                for (int col = 0; col < numColumns - 3; col++)
                {
                    if (gameBoard[row, col] == playerID &&
                        gameBoard[row + 1, col + 1] == playerID &&
                        gameBoard[row + 2, col + 2] == playerID &&
                        gameBoard[row + 3, col + 3] == playerID)
                    {
                        gameBoard[row, col] = 3;
                        gameBoard[row + 1, col + 1] = 3;
                        gameBoard[row + 2, col + 2] = 3;
                        gameBoard[row + 3, col + 3] = 3;
                        return true;
                    }
                }
            }

            return false;
        }

        private void Timer_recreate(object sender, EventArgs e)
        {
            paintBox();
            if (rowCount != row)
            {
                gameBoard[rowCount, column] = 0;
            }
            rowCount++;
            if (rowCount == row + 1)
            {
                moveNum++;
                if(moveNum >= gameMove.Count)
                {
                    turn = !turn;
                    moveNum = 0;
                    timer.Stop();
                    if (CheckForWin(1))
                    {
                        EndGame();
                        timer.Tick -= Timer_recreate;
                        timer.Tick += Timer_Tick;
                        timer.Stop();
                        paintBox();

                        winnerText.Text = "Client won";
                        return;
                    }
                    if (CheckForWin(2))
                    {
                        EndGame();
                        timer.Tick -= Timer_recreate;
                        timer.Tick += Timer_Tick;
                        timer.Stop();
                        paintBox();

                        winnerText.Text = "Computer won";
                        return;
                    }

                    timer.Tick -= Timer_recreate;
                    timer.Tick += Timer_Tick;
                    pictureBox1.Enabled = true;
                    pictureBox1.MouseClick += PictureBox1_Click;

                }
                column = gameMove[moveNum].Column;
                row = CheckEmptyRow(column);
                turn = gameMove[moveNum].isPlayer;
                rowCount = 0;
                
                return;
            }
            if (turn == true)
                gameBoard[rowCount, column] = 1;
            else if (turn == false)
                gameBoard[rowCount, column] = 2;
            pictureBox1.Image = bitmap;

        }

        private void reCreateGame(int gameId)
        {
            winnerText.Text = "";
            gameID = gameId;
            initGameBoard();
            initPictureBox();
            gameMove = db.GetMoveListByGameID(gameID);
            if (gameMove.Count == 0)
            {
                timer.Tick -= Timer_recreate;
                timer.Tick += Timer_Tick;
                pictureBox1.Enabled = true;
                pictureBox1.MouseClick += PictureBox1_Click;
                return;
            }
                
            column = gameMove[0].Column;
            row = CheckEmptyRow(column);
            moveNum = 0;
            rowCount = 0;
            timer.Tick += Timer_recreate;
            timer.Tick -= Timer_Tick;
            timer.Start();
        }

        private void TextGame_Click(object sender, EventArgs e)
        {

        }

        private void GamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cmb = (System.Windows.Forms.ComboBox)sender;
            Game game = (Game)cmb.SelectedItem;
            reCreateGame(game.GameID);
        }
    }
}
