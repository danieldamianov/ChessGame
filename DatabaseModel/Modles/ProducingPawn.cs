using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Modles
{
    public class ProducingPawn : BaseMove
    {
        [Key]
        public int Id { get; set; }

        public int OrderInTheGame { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
