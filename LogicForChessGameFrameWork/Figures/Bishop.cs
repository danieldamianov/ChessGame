using System;
using System.Collections.Generic;
using System.Text;
using LogicForChessGame.Enums;
using LogicForChessGame.Exceptions;
using LogicForChessGameFrameWork.Figures.Interfaces;

namespace LogicForChessGame.Figures
{
    public class Bishop : Figure, IUnableToJump
    {
        public Bishop(Colors color) : base(color)
        {
        }

        public override char Sign => 'О';

        public override bool AreMovePositionsPossible(NormalMovePositions move)
        {
            int differenceInHorizontal = Math.Abs(move.InitialPosition.Horizontal - move.TargetPosition.Horizontal);
            int differenceInVertical = Math.Abs(move.InitialPosition.Vertical - move.TargetPosition.Vertical);

            if (differenceInHorizontal == differenceInVertical && differenceInVertical != 0)
            {
                return true;
            }

            return false;
        }

        public override char GetFigureSymbol()
        {
            if (this.color == Colors.White)
            {
                return '♗';
            }
            return '♝';
        }

        public List<PositionOnTheBoard> GetPositionsInTheWayOfMove(NormalMovePositions normalMove)
        {
            if (this.AreMovePositionsPossible(normalMove) == false)
            {
                throw new InvalidMoveException("InvalidMove");
            }

            List<PositionOnTheBoard> positionsOnTheBoard = new List<PositionOnTheBoard>();

            int differenceInHorizontal = normalMove.InitialPosition.Horizontal - normalMove.TargetPosition.Horizontal;
            int differenceInVertical = normalMove.InitialPosition.Vertical - normalMove.TargetPosition.Vertical;

            for (int i = 1; i < Math.Abs(differenceInHorizontal); i++)
            {
                if (differenceInHorizontal > 0 && differenceInVertical > 0)
                {
                    positionsOnTheBoard.Add(new PositionOnTheBoard((char)(normalMove.InitialPosition.Horizontal - i), normalMove.InitialPosition.Vertical - i));
                }
                if (differenceInHorizontal < 0 && differenceInVertical > 0)
                {
                    positionsOnTheBoard.Add(new PositionOnTheBoard((char)(normalMove.InitialPosition.Horizontal + i), normalMove.InitialPosition.Vertical - i));
                }
                if (differenceInHorizontal > 0 && differenceInVertical < 0)
                {
                    positionsOnTheBoard.Add(new PositionOnTheBoard((char)(normalMove.InitialPosition.Horizontal - i), normalMove.InitialPosition.Vertical + i));
                }
                if (differenceInHorizontal < 0 && differenceInVertical < 0)
                {
                    positionsOnTheBoard.Add(new PositionOnTheBoard((char)(normalMove.InitialPosition.Horizontal + i), normalMove.InitialPosition.Vertical + i));
                }
            }

            return positionsOnTheBoard;
            //if (differenceInHorizontal > 0)
            //{
            //    for (int i = 1; i < differenceInHorizontal; i++)
            //    {
            //        positionOnTheBoard.Add(new PositionOnTheBoard((char)(normalMove.InitialPosition.Horizontal + i), normalMove.InitialPosition.Vertical + i));
            //    } 
            //}
            //else
            //{
            //    for (int i = -1; i > differenceInHorizontal; i++)
            //    {
            //        positionOnTheBoard.Add(new PositionOnTheBoard((char)(normalMove.InitialPosition.Horizontal + i), normalMove.InitialPosition.Vertical + i));
            //    }
            //}
        }
    }
}
