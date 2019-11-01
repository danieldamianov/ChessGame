using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Modles
{
    public class UsersGame
    {
        public int FirstUserId { get; set; }
        public User FirstUser { get; set; }

        public int SecondUserId { get; set; }
        public User SecondUser { get; set; }

        public string Result { get; set; } // WhiteWin,BlackWin,Draw

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
