using System;
using System.Collections.Generic;
using System.Text;
using LogicForChessGame.Enums;
using LogicForChessGame.Exceptions;
using LogicForChessGameFrameWork.Figures.Interfaces;

namespace LogicForChessGame.Figures
{
    public class Queen : Figure, IUnableToJump
    {
        public Queen(Colors color) : base(color)
        {
        }

        public override char Sign => 'Д';

        public override bool AreMovePositionsPossible(NormalMovePositions move)
        {
            Rook rook = new Rook(Colors.Black);
            Bishop bishop = new Bishop(Colors.Black);

            return rook.AreMovePositionsPossible(move) || bishop.AreMovePositionsPossible(move);
        }

        public override char GetFigureSymbol()
        {
            if (this.color == Colors.White)
            {
                return '♕';
            }
            return '♛';
        }

        public List<PositionOnTheBoard> GetPositionsInTheWayOfMove(NormalMovePositions normalMove)
        {
            if (this.AreMovePositionsPossible(normalMove) == false)
            {
                throw new InvalidMoveException("InvalidMove");
            }

            List<PositionOnTheBoard> positionsOnTheBoard = new List<PositionOnTheBoard>();

            Rook rook = new Rook(Colors.Black);
            Bishop bishop = new Bishop(Colors.Black);

            if (rook.AreMovePositionsPossible(normalMove))
            {
                positionsOnTheBoard =  rook.GetPositionsInTheWayOfMove(normalMove);
            }

            if (bishop.AreMovePositionsPossible(normalMove))
            {
                positionsOnTheBoard =  bishop.GetPositionsInTheWayOfMove(normalMove);
            }

            return positionsOnTheBoard;
        }
    }
}
