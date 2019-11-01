using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicForChessGameFrameWork.Enums
{
    public enum InvalidMoveReason
    {
        ThereIsntSuchFigureAndColorOnTheGivenPosition,
        TheFigureOnTheTargetPositionIsFriendlyOrEnemyKing,
        MovePositionsAreNotValid,
        ThereAreOtherPiecesOnTheWay,
        MovementResultsInCheckOfTheFriendlyKing,
    }
}
