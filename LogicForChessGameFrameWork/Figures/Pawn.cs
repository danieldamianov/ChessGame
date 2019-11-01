using System;
using System.Collections.Generic;
using System.Text;
using LogicForChessGame.Enums;
using LogicForChessGame.Exceptions;
using LogicForChessGameFrameWork.Figures.Interfaces;

namespace LogicForChessGame.Figures
{
    public class Pawn : Figure, IUnableToJump
    {
        public override char Sign => 'П';

        public Pawn(Colors color) : base(color)
        {
        }

        public bool isPositionProducable(PositionOnTheBoard positionOnTheBoard)
        {
            if (this.color == Colors.White)
            {
                return positionOnTheBoard.Vertical == 8;
            }
            else
            {
                return positionOnTheBoard.Vertical == 1;
            }
        }

        public override bool AreMovePositionsPossible(NormalMovePositions move)
        {
            int differenceInHorizontal = Math.Abs(move.InitialPosition.Horizontal - move.TargetPosition.Horizontal);
            int differenceInVertical = Math.Abs(move.InitialPosition.Vertical - move.TargetPosition.Vertical);

            if (differenceInHorizontal == 0 && (differenceInVertical == 1 || differenceInVertical == 2))
            {
                if (this.color == Colors.White && move.InitialPosition.Vertical == 2 && move.TargetPosition.Vertical == 4)
                {
                    return true;
                }

                if (this.color == Colors.Black && move.InitialPosition.Vertical == 7 && move.TargetPosition.Vertical == 5)
                {
                    return true;
                }

                if (this.color == Colors.White && move.InitialPosition.Vertical + 1 == move.TargetPosition.Vertical)
                {
                    return true;
                }

                if (this.color == Colors.Black && move.InitialPosition.Vertical - 1 == move.TargetPosition.Vertical)
                {
                    return true;
                }

            }

            return false;
        }

        public bool IsAttackingMovePossible(NormalMovePositions move)
        {
            if (this.color == Colors.White)
            {
                int differenceInHorizontal = Math.Abs(move.InitialPosition.Horizontal - move.TargetPosition.Horizontal);
                int differenceInVertical = move.InitialPosition.Vertical - move.TargetPosition.Vertical;

                if (differenceInHorizontal == 1 && differenceInVertical == -1)
                {
                    return true;
                }
            }
            else
            {
                int differenceInHorizontal = Math.Abs(move.InitialPosition.Horizontal - move.TargetPosition.Horizontal);
                int differenceInVertical = move.InitialPosition.Vertical - move.TargetPosition.Vertical;

                if (differenceInHorizontal == 1 && differenceInVertical == 1)
                {
                    return true;
                }
            }

            return false;
        }

        public override char GetFigureSymbol()
        {
            if (this.color == Colors.White)
            {
                return '♙';
            }
            return '♟';
        }

        public List<PositionOnTheBoard> GetPositionsInTheWayOfMove(NormalMovePositions normalMove)
        {
            if (this.AreMovePositionsPossible(normalMove) == false && this.IsAttackingMovePossible(normalMove) == false)
            {
                throw new InvalidMoveException("");
            }
            if (this.IsAttackingMovePossible(normalMove))
            {
                return new List<PositionOnTheBoard>();
            }
            int differenceInHorizontal = Math.Abs(normalMove.InitialPosition.Horizontal - normalMove.TargetPosition.Horizontal);
            int differenceInVertical = Math.Abs(normalMove.InitialPosition.Vertical - normalMove.TargetPosition.Vertical);


            if (this.color == Colors.White && normalMove.InitialPosition.Vertical == 2 && normalMove.TargetPosition.Vertical == 4)
            {
                return new List<PositionOnTheBoard>() { new PositionOnTheBoard(normalMove.InitialPosition.Horizontal, 3) };
            }

            if (this.color == Colors.Black && normalMove.InitialPosition.Vertical == 7 && normalMove.TargetPosition.Vertical == 5)
            {
                return new List<PositionOnTheBoard>() { new PositionOnTheBoard(normalMove.InitialPosition.Horizontal, 6) };
            }



            return new List<PositionOnTheBoard>();
        }
    }
}
