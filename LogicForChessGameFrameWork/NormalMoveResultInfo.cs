using LogicForChessGameFrameWork.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicForChessGameFrameWork
{
    public class NormalMoveResultInfo
    {
        public NormalMoveResultInfo()
        {

        }

        public NormalMoveResultInfo(
            InvalidMoveReason? isTheMoveValid,
            bool? hasTheFigurePawnProducedItself)
        {
            this.IsTheMoveValid = isTheMoveValid;
            HasTheFigurePawnProducedItself = hasTheFigurePawnProducedItself;
            
        }

        public InvalidMoveReason? IsTheMoveValid { get; set; }
        public bool? HasTheFigurePawnProducedItself { get; set; }
        
    }
}
