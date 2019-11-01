using System;
using System.Collections.Generic;
using System.Text;

namespace LogicForChessGame.Exceptions
{
    class InvalidMoveException : Exception
    {
        public InvalidMoveException(string message) : base(message)
        {
        }
    }
}
