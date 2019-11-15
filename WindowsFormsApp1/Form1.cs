using LogicForChessGame;
using LogicForChessGame.Enums;
using LogicForChessGame.Figures;
using LogicForChessGameFrameWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
       

        public Form1()
        {
            InitializeComponent();
            InitialView();
            ConfigureBoardPanel();
            this.chessGame = new ChessGame();
            this.InitialzeBoard(this.chessGame.chessBoard);
            
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
            
            this.BoardPanel.Visible = false;
            this.ConfigureGameTimeBox.Visible = true;
            this.TimeInfoBox.Visible = false;
            
        }

        private void MoveHandler(object sender, EventArgs eventArgs)
        {
            if (this.chessFieldSelected == null)
            {
                this.chessFieldSelected = (ChessField)sender;

                List<PositionOnTheBoard> attackingPos =
                    this.chessGame.GetAllPossiblePositionsOfPlacingTheFigure(this.chessFieldSelected.positionOnTheBoard
                    , this.chessFieldSelected.chessFigure, (Colors)this.chessFieldSelected.chessFigureColor);

                if (this.chessFieldSelected.chessFigure.FullName == typeof(King).FullName)
                {
                    attackingPos.AddRange(this.chessGame.GetAllPossiblePositionsOfRookWhenCastlingTheKing(this.chessFieldSelected.positionOnTheBoard
                        , (Colors)this.chessFieldSelected.chessFigureColor));
                }

                if (this.chessFieldSelected.chessFigure.FullName == typeof(Rook).FullName)
                {
                    PositionOnTheBoard kingPos = this.chessGame.GetPossiblePositionOfKingWhenCastlingTheRook(this.chessFieldSelected.positionOnTheBoard
                        , (Colors)this.chessFieldSelected.chessFigureColor);

                    if (kingPos != null)
                    {
                        attackingPos.Add(kingPos);
                    }
                    attackingPos.AddRange(this.chessGame.GetAllPossiblePositionsOfRookWhenCastlingTheKing(this.chessFieldSelected.positionOnTheBoard
                        , (Colors)this.chessFieldSelected.chessFigureColor));
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

                if (this.chessFieldSelected.chessFigure.FullName == typeof(King).FullName
                    && this.chessGame.MakeCastling(this.chessFieldSelected.positionOnTheBoard,
                        ((ChessField)sender).positionOnTheBoard, (Colors)this.chessFieldSelected.chessFigureColor)) ;
                else if (this.chessFieldSelected.chessFigure.FullName == typeof(Rook).FullName
                    && this.chessGame.MakeCastling(
                           ((ChessField)sender).positionOnTheBoard, this.chessFieldSelected.positionOnTheBoard
                           , (Colors)this.chessFieldSelected.chessFigureColor));
                else
                {
                    var resultFormMove = this.chessGame.NormalMove(new NormalMovePositions
                    (this.chessFieldSelected.positionOnTheBoard.Horizontal,
                    this.chessFieldSelected.positionOnTheBoard.Vertical,
                    ((ChessField)sender).positionOnTheBoard.Horizontal,
                    ((ChessField)sender).positionOnTheBoard.Vertical)
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

            

            this.InitialView();
        }

        private string ParseSecondsToString(decimal seconds)
        {
            int minutes = (int)Math.Floor(seconds) / 60;
            var secondsBehindMinute = seconds - minutes * 60;
            return $"{minutes}:{(secondsBehindMinute == 0 ? "00" : secondsBehindMinute.ToString("00.##"))}";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.InitialView();
            
        }
    }
}
