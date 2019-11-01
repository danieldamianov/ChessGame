using LogicForChessGame.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicForChessGame.Figures
{
    public abstract class Figure
    {
        public Figure(Colors color)
        {
            this.color = color;
        }

        public abstract bool AreMovePositionsPossible(NormalMovePositions move);

        public abstract char GetFigureSymbol();

        public Colors color;

        public abstract char Sign { get;  }

    }
}
