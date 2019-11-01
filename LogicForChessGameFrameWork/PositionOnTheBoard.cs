using LogicForChessGame.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicForChessGame
{
    public class PositionOnTheBoard : IEquatable<PositionOnTheBoard>
    {
        public readonly char Horizontal;

        public readonly int Vertical;

        public PositionOnTheBoard(char horizontal, int vertical)
        {
            if (ValidatePosition(horizontal, vertical) == false)
            {
                throw new InvalidMoveException("Positions are out of the board!");
            }

            Horizontal = horizontal;
            Vertical = vertical;
        }

        public bool Equals(PositionOnTheBoard other)
        {
            if (this.Horizontal == other.Horizontal && this.Vertical == other.Vertical)
            {
                return true;
            }

            return false;
        }

        public static bool ValidatePosition(char horizontal, int vertical)
        {
            if (horizontal < 'a' || horizontal > 'h')
            {
                return false;
            }

            if (vertical < 1 || vertical > 8)
            {
                return false;
            }

            return true;
        }
    }
}
