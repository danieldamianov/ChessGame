using DatabaseModel;
using DatabaseModel.Modles;
using LogicForChessGame;
using LogicForChessGame.Enums;
using LogicForChessGame.Figures;
using LogicForChessGameFrameWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Enums;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ChessGame chessGame;
        private ChessField chessFieldSelected;
        private decimal firstPlayerTime = 0;
        private decimal secondPlayerTime = 0;
        private decimal MaxTimePerPlayer = 0;
        private ChessDbContext dbContext;

        public Form1(ChessDbContext dbContext)
        {
            InitializeComponent();
            InitialView();
            ConfigureBoardPanel();
            this.dbContext = dbContext;
        }

        private void ConfigureBoardPanel()
        {
            this.board = new ChessField[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this.board[i, j] = new ChessField();
                    this.board[i, j].Click += new EventHandler(this.MoveHandler);
                    ((ChessField)this.board[i, j]).positionOnTheBoard = new LogicForChessGame.PositionOnTheBoard(Convert.ToChar(j + 'a'), 8 - i);
                    this.board[i, j].FlatStyle = FlatStyle.Flat;
                    this.board[i, j].FlatAppearance.BorderSize = 0;
                    this.board[i, j].Size = new System.Drawing.Size(70, 70);
                    this.board[i, j].Margin = new Padding(0);
                    BoardPanel.Controls.Add(this.board[i, j]);

                }
            }
        }

        public void InitialView()
        {
            this.StartGameBox.Visible = true;
            this.BoardPanel.Visible = false;
            this.ConfigureGameTimeBox.Visible = false;
            this.TimeInfoBox.Visible = false;
            this.InitialPlayGameButton.Enabled = false;
            this.usernameLabel.Visible = false;
            this.usernameTextBox.Visible = false;
            this.passwordLabel.Visible = false;
            this.passwordTextBox.Visible = false;
            this.ConfirmUserButton.Visible = false;
            this.SignInButton.Visible = false;
            this.ChooseUserGameBox.Visible = false;
        }

        private void MoveHandler(object sender, EventArgs eventArgs)
        {
            if (this.chessFieldSelected == null)
            {
                this.chessFieldSelected = (ChessField)sender;

                List<PositionOnTheBoard> attackingPos = new List<PositionOnTheBoard>();

                for (char horizontal = 'a'; horizontal <= 'h'; horizontal++)
                {
                    for (int vertical = 1; vertical <= 8; vertical++)
                    {
                        if (this.chessGame.ValidateMove(new NormalMovePositions(this.chessFieldSelected.positionOnTheBoard
                            .Horizontal, this.chessFieldSelected.positionOnTheBoard.Vertical
                            , horizontal, vertical),
                            this.chessFieldSelected.chessFigure
                    , (Colors)this.chessFieldSelected.chessFigureColor) == null)
                        {
                            attackingPos.Add(new PositionOnTheBoard(horizontal, vertical));
                        }
                    }
                }

                foreach (var field in this.board)
                {
                    if (((ChessField)field).positionOnTheBoard.Equals(this.chessFieldSelected.positionOnTheBoard) == false
                        && attackingPos.Any(ap => ((ChessField)field).positionOnTheBoard.Equals(ap)) == false)
                    {
                        field.Enabled = false;
                    }
                    else
                    {
                        field.Enabled = true;
                    }
                }
            }
            else
            {

                var resultFormMove = this.chessGame.NormalMove(new NormalMovePositions(this.chessFieldSelected.positionOnTheBoard.Horizontal, this.chessFieldSelected.positionOnTheBoard.Vertical, ((ChessField)sender).positionOnTheBoard.Horizontal, ((ChessField)sender).positionOnTheBoard.Vertical)
                , chessFieldSelected.chessFigure, (Colors)chessFieldSelected.chessFigureColor);

                if (resultFormMove.HasTheFigurePawnProducedItself == true)
                {
                    Figure figureChosen = null;
                    DialogResult dialogResult = MessageBox.Show("Do you want to get a QUEEN?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        figureChosen = new Queen((Colors)chessFieldSelected.chessFigureColor);
                    }
                    else
                    {
                        DialogResult dialogResult2 = MessageBox.Show("Do you want to get a ROOK?", "", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            figureChosen = new Rook((Colors)chessFieldSelected.chessFigureColor);
                        }
                        else
                        {

                            DialogResult dialogResult3 = MessageBox.Show("Do you want to get a BISHOP?", "", MessageBoxButtons.YesNo);
                            if (dialogResult3 == DialogResult.Yes)
                            {
                                figureChosen = new Bishop((Colors)chessFieldSelected.chessFigureColor);
                            }
                            else
                            {

                                figureChosen = new Knight((Colors)chessFieldSelected.chessFigureColor);

                            }

                        }

                    }

                    this.chessGame.ProducePawn(new PositionOnTheBoard(((ChessField)sender).positionOnTheBoard.Horizontal, ((ChessField)sender).positionOnTheBoard.Vertical)
                        , figureChosen, figureChosen.color);
                }
                Colors chessFigureColor = (Colors)chessFieldSelected.chessFigureColor;

                this.InitialzeBoard(this.chessGame.chessBoard);


                if (this.chessGame.CheckForMate(chessFigureColor) && !this.chessGame.CheckForCheck(this.chessGame.chessBoard, SwitchColor(chessFigureColor)))
                {
                    MessageBox.Show("remi");
                    this.ChessGameHasEnded(EndGameInfo.Draw);
                }

                if (this.chessGame.CheckForMate(chessFigureColor) && this.chessGame.CheckForCheck(this.chessGame.chessBoard, SwitchColor(chessFigureColor)))
                {
                    MessageBox.Show("mate");
                    if (chessFigureColor == Colors.Black)
                    {
                        this.ChessGameHasEnded(EndGameInfo.BlackWin);
                    }
                    else
                    {
                        this.ChessGameHasEnded(EndGameInfo.WhiteWin);
                    }
                }

                this.chessFieldSelected = null;
            }

        }
        private static ConsoleColor ParseColor(Colors color)
        {
            if (color == Colors.Black)
            {
                return ConsoleColor.Black;
            }
            return ConsoleColor.Yellow;
        }

        private static Color SwitchColor(Color color)
        {
            if (color == Color.DarkGray)
            {
                return Color.White;
            }
            return Color.DarkGray;
        }

        private static Colors SwitchColor(Colors color)
        {
            if (color == Colors.White)
            {
                return Colors.Black;
            }
            return Colors.White;
        }


        private void InitialzeBoard(ChessBoard chessBoard)
        {
            Color color = Color.DarkGray;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this.board[i, j].BackColor = color;
                    if (chessBoard.board[i, j] != null)
                    {


                        this.board[i, j].Image =
                            (Image)typeof(Resources)
                            .GetProperty($"{(chessBoard.board[i, j]).GetType().Name}{chessBoard.board[i, j].color.ToString()}{color.Name}", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic).GetValue(null); //= chessBoard.board[i, j].GetFigureSymbol().ToString(); 
                        ((ChessField)this.board[i, j]).chessFigure = chessBoard.board[i, j].GetType();
                        ((ChessField)this.board[i, j]).chessFigureColor = chessBoard.board[i, j].color;



                    }
                    else
                    {
                        this.board[i, j].Image =
                                null;
                        ((ChessField)this.board[i, j]).chessFigure = null;
                        ((ChessField)this.board[i, j]).chessFigureColor = null;
                    }
                    if (((ChessField)this.board[i, j]).chessFigureColor != this.chessGame.PlayerOnTurn)
                    {
                        this.board[i, j].Enabled = false;
                    }
                    else
                    {
                        this.board[i, j].Enabled = true;
                    }

                    if (j != 7)
                    {
                        color = SwitchColor(color);
                    }
                }
            }
        }

        private void ButtonStartGame_Click_1(object sender, EventArgs e)
        {
            this.BoardPanel.Visible = true;
            timer1.Interval = 100;
            timer2.Interval = 100;
            MaxTimePerPlayer = (int)this.numericUpDownMinutesPerPlayer.Value;
            textBox1.Text = ParseSecondsToString((MaxTimePerPlayer * 60));
            firstPlayerTime = (MaxTimePerPlayer * 60);
            secondPlayerTime = (MaxTimePerPlayer * 60);
            textBox2.Text = ParseSecondsToString((MaxTimePerPlayer * 60));
            timer1.Start();
            this.TimeInfoBox.Visible = true;
            this.ConfigureGameTimeBox.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (chessGame.PlayerOnTurn == Colors.White)
            {
                firstPlayerTime -= 0.1m;
            }
            else
            {
                secondPlayerTime -= 0.1m;
            }
            textBox1.Text = ParseSecondsToString(firstPlayerTime);
            textBox2.Text = ParseSecondsToString(secondPlayerTime);
            if (firstPlayerTime == 0)
            {
                MessageBox.Show("Black win from time");
                this.ChessGameHasEnded(EndGameInfo.BlackWin);
            }
            if (secondPlayerTime == 0)
            {
                MessageBox.Show("White win from time");
                this.ChessGameHasEnded(EndGameInfo.WhiteWin);
            }
        }

        private void ChessGameHasEnded(EndGameInfo endGameInfo)
        {

            User user1 = this.dbContext.Users.Single(u => u.Username == this.chessGame.User1WhitesName);
            User user2 = this.dbContext.Users.Single(u => u.Username == this.chessGame.User2BlacksName);

            Game game = new Game()
            {
                NormalMoves = this.chessGame.movesInTheGame.Where(m => m is NormalMoveDabModel).Select(m => (NormalMoveDabModel)m).ToList(),
                Castlings = this.chessGame.movesInTheGame.Where(m => m is Castling).Select(m => (Castling)m).ToList(),
                ProducingPawns = this.chessGame.movesInTheGame.Where(m => m is ProducingPawn).Select(m => (ProducingPawn)m).ToList()
            };

            this.dbContext.UsersGames.Add
                    (new DatabaseModel.Modles.UsersGame() { FirstUser = user1, SecondUser = user2, Game = game, Result = endGameInfo.ToString() });

            this.dbContext.SaveChanges();

            this.InitialView();
            this.InitialPlayGameButton.Enabled = true;
        }

        private string ParseSecondsToString(decimal seconds)
        {
            int minutes = (int)Math.Floor(seconds) / 60;
            var secondsBehindMinute = seconds - minutes * 60;
            return $"{minutes}:{(secondsBehindMinute == 0 ? "00" : secondsBehindMinute.ToString("00.##"))}";
        }

        private void RegisterUserButton_Click(object sender, EventArgs e)
        {
            this.usernameLabel.Visible = true;
            this.usernameTextBox.Visible = true;
            this.passwordLabel.Visible = true;
            this.passwordTextBox.Visible = true;
            this.ConfirmUserButton.Visible = true;
        }

        private void ConfirmUserButton_Click(object sender, EventArgs e)
        {
            this.usernameLabel.Visible = false;
            this.usernameTextBox.Visible = false;
            this.passwordLabel.Visible = false;
            this.passwordTextBox.Visible = false;
            this.ConfirmUserButton.Visible = false;


            this.dbContext.Users.Add(new User() { Username = usernameTextBox.Text, Password = passwordTextBox.Text });
            this.dbContext.SaveChanges();

        }

        private void user1TextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(user1TextBox.Text) == false && string.IsNullOrWhiteSpace(user2TextBox.Text) == false)
            {
                this.InitialPlayGameButton.Enabled = true;
            }
            else
            {
                this.InitialPlayGameButton.Enabled = false;
            }
        }

        private void user2TextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(user1TextBox.Text) == false && string.IsNullOrWhiteSpace(user2TextBox.Text) == false)
            {
                this.InitialPlayGameButton.Enabled = true;
            }
            else
            {
                this.InitialPlayGameButton.Enabled = false;
            }
        }

        private void InitialPlayGameButton_Click(object sender, EventArgs e)
        {
                if (!this.dbContext.Users.Any(u => u.Username == user1TextBox.Text)
                    || !this.dbContext.Users.Any(u => u.Username == user2TextBox.Text))
                {
                    MessageBox.Show("Invalid user");
                    return;
                }
            
            this.ConfigureGameTimeBox.Visible = true;
            this.StartGameBox.Visible = false;
            this.chessGame = new ChessGame(user1TextBox.Text, user2TextBox.Text);
            this.InitialzeBoard(this.chessGame.chessBoard);

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.usernameLabel.Visible = true;
            this.usernameTextBox.Visible = true;
            this.passwordLabel.Visible = true;
            this.passwordTextBox.Visible = true;
            this.SignInButton.Visible = true;
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            this.usernameLabel.Visible = false;
            this.usernameTextBox.Visible = false;
            this.passwordLabel.Visible = false;
            this.passwordTextBox.Visible = false;
            this.SignInButton.Visible = false;
            this.ChooseUserGameBox.Visible = true;
            this.StartGameBox.Visible = false;
            this.nextButton.Visible = false;
            
                User user = this.dbContext.Users.Include(u => u.UsersGamesLikeBlack).Include(u => u.UsersGamesLikeWhite)
                    .Where(u => u.Username == usernameTextBox.Text && u.Password ==
                passwordTextBox.Text).FirstOrDefault();
                IList<UsersGame> usersGames = user.UsersGamesLikeWhite.Concat(user.UsersGamesLikeBlack).ToList();

                UsersGamesListBox.DataSource = usersGames.Select(ug => $"{this.dbContext.Users.Find(ug.FirstUserId).Username} " +
                $"{this.dbContext.Users.Find(ug.SecondUserId).Username}" +
                $" {ug.GameId} {ug.Result}")
                    .ToList();


            
        }

        private void ReplayGameButton_Click(object sender, EventArgs e)
        {
            string gameAsString = (string)UsersGamesListBox.SelectedItem;

            int gameId = int.Parse(gameAsString.Split()[2]);
            
                Game game = this.dbContext.Games.Include(g => g.Castlings)
                    .Include(g => g.NormalMoves)
                    .Include(g => g.ProducingPawns)
                    .FirstOrDefault(g => g.Id == gameId);
                List<NormalMoveDabModel> moves = game.NormalMoves.ToList();
                List<Castling> castlings = game.Castlings.ToList();
                List<ProducingPawn> producingPawns = game.ProducingPawns.ToList();

                this.chessGame = new ChessGame("", "");
                this.chessGame.movesInTheGame = moves.Select(m => (BaseMove)m).ToList();
                this.InitialzeBoard(this.chessGame.chessBoard);
                this.BoardPanel.Visible = true;
                moveCounter = 0;

            

            this.nextButton.Visible = true;

        }

        private int moveCounter;
        private void nextButton_Click(object sender, EventArgs e)
        {

            List<NormalMoveDabModel> moves = this.chessGame.movesInTheGame.Select(m => (NormalMoveDabModel)m)
                .OrderBy(m => m.OrderInTheGame).ToList();

            Assembly assembly = Assembly.LoadFile(@"D:\C#\ChessGame\ChessGame\LogicForChessGameFrameWork\obj\Debug\LogicForChessGameFrameWork.dll");
            string typeName = moves[moveCounter].FigureType;
            Type type = assembly.GetType("LogicForChessGame.Figures." + typeName);
            Colors color = (Colors)Enum.Parse(typeof(Colors), moves[moveCounter].FigureColor);

            this.chessGame.NormalMoveWithoutValidation(new NormalMovePositions(moves[moveCounter].InitialPosHorizontal,
                moves[moveCounter].InitialPosVertical, moves[moveCounter].TargetPosHorizontal,
                moves[moveCounter].TargetPosVertical), type, color);

            moveCounter++;

            this.InitialzeBoard(this.chessGame.chessBoard);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.InitialView();
            this.InitialPlayGameButton.Enabled = false;
        }
    }
}
