using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Modles
{
    public class Game
    {
        public Game()
        {
            this.NormalMoves = new List<NormalMoveDabModel>();
            this.Castlings = new List<Castling>();
            this.ProducingPawns = new List<ProducingPawn>();
            this.UsersGames = new List<UsersGame>();
        }
        [Key]
        public int Id { get; set; }

        public List<NormalMoveDabModel> NormalMoves { get; set; }
        public List<Castling> Castlings { get; set; }
        public List<ProducingPawn> ProducingPawns { get; set; }

        public List<UsersGame> UsersGames { get; set; }
    }
}
