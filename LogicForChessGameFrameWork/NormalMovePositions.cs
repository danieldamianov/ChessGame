using LogicForChessGame.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicForChessGame
{
    public class NormalMovePositions
    {
        public NormalMovePositions(char InitialPositionHorizontal, int InitialPositionVertical, char TargetPositionHorizontal, int TargetPositionVertical)
        {
            if (InitialPositionHorizontal < 'a' || InitialPositionHorizontal > 'h' 
                || TargetPositionHorizontal < 'a' || TargetPositionHorizontal > 'h'
                || InitialPositionVertical < 1 || InitialPositionVertical > 8
                || TargetPositionVertical < 1 || TargetPositionVertical > 8 )
            {
                throw new InvalidMoveException("Positions are out of the board!");
            }
            this.InitialPosition = new PositionOnTheBoard(InitialPositionHorizontal, InitialPositionVertical);
            this.TargetPosition = new PositionOnTheBoard(TargetPositionHorizontal, TargetPositionVertical);
        }

        public readonly PositionOnTheBoard InitialPosition;

        public readonly PositionOnTheBoard TargetPosition;
    }
}
