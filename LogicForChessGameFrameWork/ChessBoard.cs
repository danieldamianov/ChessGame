using LogicForChessGame;
using LogicForChessGame.Enums;
using LogicForChessGame.Exceptions;
using LogicForChessGame.Figures;
using LogicForChessGameFrameWork.Figures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicForChessGameFrameWork
{
    public class ChessBoard
    {
        public Figure[,] board;

        public ChessBoard()
        {
            this.board = new Figure[8, 8];
            this.InitializeBoard();
        }

        public ChessBoard(Figure[,] figures)
        {
            this.board = figures;
        }

        private void InitializeBoard()
        {
            InitializeRooks();
            InitializeKnights();
            InializeBishops();

            InitializeQueens();
            InitializeKings();

            InitializePawns();
        }

        private void InitializePawns()
        {
            for (int i = 0; i <= 7; i++)
            {
                this.board[1, i] = new Pawn(Colors.Black);
            }

            for (int i = 0; i <= 7; i++)
            {
                this.board[6, i] = new Pawn(Colors.White);
            }
        }

        private void InitializeQueens()
        {
            this.board[0, 3] = new Queen(Colors.Black);
            this.board[7, 3] = new Queen(Colors.White);
        }

        private void InitializeKings()
        {
            this.board[0, 4] = new King(Colors.Black);
            this.board[7, 4] = new King(Colors.White);
        }

        private void InializeBishops()
        {
            this.board[0, 2] = new Bishop(Colors.Black);
            this.board[7, 5] = new Bishop(Colors.White);
            this.board[0, 5] = new Bishop(Colors.Black);
            this.board[7, 2] = new Bishop(Colors.White);
        }

        private void InitializeKnights()
        {
            this.board[0, 1] = new Knight(Colors.Black);
            this.board[7, 6] = new Knight(Colors.White);
            this.board[0, 6] = new Knight(Colors.Black);
            this.board[7, 1] = new Knight(Colors.White);
        }

        private void InitializeRooks()
        {
            this.board[0, 0] = new Rook(Colors.Black);
            this.board[7, 7] = new Rook(Colors.White);
            this.board[0, 7] = new Rook(Colors.Black);
            this.board[7, 0] = new Rook(Colors.White);
        }

        public void RemoveFigureOnPosition(PositionOnTheBoard positionOnTheBoard)
        {
            ValidatePosition(positionOnTheBoard);

            board[8 - positionOnTheBoard.Vertical, positionOnTheBoard.Horizontal - 'a'] = null;
        }

        private static void ValidatePosition(PositionOnTheBoard positionOnTheBoard)
        {
            if (positionOnTheBoard.Horizontal < 'a' || positionOnTheBoard.Horizontal > 'h'
                            || positionOnTheBoard.Vertical < 1 || positionOnTheBoard.Vertical > 8
                            )
            {
                throw new InvalidMoveException("Positions are out of the board!");
            }
        }

        public Figure GetFigureOnPosition(PositionOnTheBoard positionOnTheBoard)
        {
            ValidatePosition(positionOnTheBoard);

            return board[8 - positionOnTheBoard.Vertical, positionOnTheBoard.Horizontal - 'a'];
        }

        public void PutFigureOnPosition(PositionOnTheBoard positionOnTheBoard, Figure figure)
        {
            ValidatePosition(positionOnTheBoard);

            board[8 - positionOnTheBoard.Vertical, positionOnTheBoard.Horizontal - 'a'] = figure;

            if (figure is ICastlingFigure)
            {
                ((ICastlingFigure)figure).HasBeenMovedFromTheStartOfTheGame = true;
            }
        }

        public void PutFigureOnPositionWithoutMovingItActualy(PositionOnTheBoard positionOnTheBoard, Figure figure)
        {
            ValidatePosition(positionOnTheBoard);

            board[8 - positionOnTheBoard.Vertical, positionOnTheBoard.Horizontal - 'a'] = figure;

            //if (figure is ICastlingFigure)
            //{
            //    ((ICastlingFigure)figure).HasBeenMovedFromTheStartOfTheGame = true;
            //}
        }

        public ChessBoard GetVirtualChessBoardAfterMove(NormalMovePositions normalMove)
        {
            ChessBoard chessBoard = CopyCurrentChessBoard();
            var figure = chessBoard.GetFigureOnPosition(normalMove.InitialPosition);
            chessBoard.RemoveFigureOnPosition(normalMove.InitialPosition);
            chessBoard.PutFigureOnPositionWithoutMovingItActualy(normalMove.TargetPosition, figure);

            return chessBoard;
        }

        private ChessBoard CopyCurrentChessBoard()
        {
            Figure[,] newFigures = new Figure[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    newFigures[i, j] = this.board[i, j];
                }
            }

            ChessBoard chessBoard = new ChessBoard(newFigures);

            return chessBoard;
        }
    }
}
