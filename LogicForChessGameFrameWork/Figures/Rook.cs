using System;
using System.Collections.Generic;
using System.Text;
using LogicForChessGame.Enums;
using LogicForChessGame.Exceptions;
using LogicForChessGameFrameWork.Figures.Interfaces;

namespace LogicForChessGame.Figures
{
    public class Rook : Figure, IUnableToJump, ICastlingFigure
    {
        public Rook(Colors color) : base(color)
        {
            this.HasBeenMovedFromTheStartOfTheGame = false;
        }

        public override char Sign => 'T';

        public bool HasBeenMovedFromTheStartOfTheGame { get; set; }

        public override bool AreMovePositionsPossible(NormalMovePositions move)
        {
            if ((move.InitialPosition.Horizontal == move.TargetPosition.Horizontal
                || move.InitialPosition.Vertical == move.TargetPosition.Vertical) && !move.InitialPosition.Equals(move.TargetPosition)
                )
            {
                return true;
            }

            return false;
        }

        public override char GetFigureSymbol()
        {
            if (this.color == Colors.White)
            {
                return '♖';
            }
            return '♜';
        }

        public List<PositionOnTheBoard> GetPositionsInTheWayOfMove(NormalMovePositions normalMove)
        {
            if (this.AreMovePositionsPossible(normalMove) == false)
            {
                throw new InvalidMoveException("InvalidMove");
            }

            List<PositionOnTheBoard> positionsOnTheBoard = new List<PositionOnTheBoard>();

            if (normalMove.InitialPosition.Horizontal == normalMove.TargetPosition.Horizontal)
            {
                for (int i = Math.Min(normalMove.InitialPosition.Vertical,normalMove.TargetPosition.Vertical) + 1; 
                    i < Math.Max(normalMove.InitialPosition.Vertical, normalMove.TargetPosition.Vertical); i++)
                {
                    positionsOnTheBoard.Add(new PositionOnTheBoard(normalMove.InitialPosition.Horizontal, i));
                }
            }

            if (normalMove.InitialPosition.Vertical == normalMove.TargetPosition.Vertical)
            {
                for (int i = Math.Min(normalMove.InitialPosition.Horizontal, normalMove.TargetPosition.Horizontal) + 1;
                    i < Math.Max(normalMove.InitialPosition.Horizontal, normalMove.TargetPosition.Horizontal); i++)
                {
                    positionsOnTheBoard.Add(new PositionOnTheBoard((char)i, normalMove.InitialPosition.Vertical));
                }
            }

            return positionsOnTheBoard;

        }
    }
}
