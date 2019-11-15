using System;
using System.Collections.Generic;
using System.Text;
using LogicForChessGame.Enums;
using LogicForChessGameFrameWork.Figures.Interfaces;

namespace LogicForChessGame.Figures
{
    public class King : Figure,ICastlingFigure
    {
        public King(Colors color) : base(color)
        {
            this.HasBeenMovedFromTheStartOfTheGame = false;
        }

        public override char Sign => 'Ц';

        public bool HasBeenMovedFromTheStartOfTheGame { get ; set; }

        public override bool AreMovePositionsPossible(NormalMovePositions move)
        {
            int differenceInHorizontal = Math.Abs(move.InitialPosition.Horizontal - move.TargetPosition.Horizontal);
            int differenceInVertical = Math.Abs(move.InitialPosition.Vertical - move.TargetPosition.Vertical);

            if (differenceInHorizontal == 0 && differenceInVertical == 0)
            {
                return false;
            }

            if (differenceInHorizontal <= 1 && differenceInVertical <= 1)
            {
                return true;
            }

            return false;
        }

        public override char GetFigureSymbol()
        {
            if (this.color == Colors.White)
            {
                return '♔';
            }
            return '♚';
        }
    }
}

