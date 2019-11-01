using System;
using System.Collections.Generic;
using System.Text;
using LogicForChessGame.Enums;

namespace LogicForChessGame.Figures
{
    public class Knight : Figure
    {
        public Knight(Colors color) : base(color)
        {
        }

        public override char Sign => 'K';

        public override bool AreMovePositionsPossible(NormalMovePositions move)
        {
            int differenceInHorizontal = Math.Abs(move.InitialPosition.Horizontal - move.TargetPosition.Horizontal);
            int differenceInVertical = Math.Abs(move.InitialPosition.Vertical - move.TargetPosition.Vertical);

            if (differenceInHorizontal == 2 && differenceInVertical == 1)
            {
                return true;
            }

            if (differenceInHorizontal == 1 && differenceInVertical == 2)
            {
                return true;
            }

            return false;
        }

        public override char GetFigureSymbol()
        {
            if (this.color == Colors.White)
            {
                return '♘';
            }
            return '♞';
        }
    }
}
