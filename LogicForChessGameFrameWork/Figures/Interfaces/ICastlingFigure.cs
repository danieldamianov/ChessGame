using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicForChessGameFrameWork.Figures.Interfaces
{
    interface ICastlingFigure
    {
        bool HasBeenMovedFromTheStartOfTheGame { get; set; }
    }
}
