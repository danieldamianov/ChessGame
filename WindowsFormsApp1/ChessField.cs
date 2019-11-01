using LogicForChessGame;
using LogicForChessGame.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ChessField : Button
    {
        public PositionOnTheBoard positionOnTheBoard;
        public Type chessFigure;
        public Colors? chessFigureColor;
    }
}