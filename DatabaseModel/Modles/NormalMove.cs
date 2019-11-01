using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Modles
{
    public class NormalMoveDabModel : BaseMove
    {
        public NormalMoveDabModel(char initialPosHorizontal,
            int initialPosVertical, char targetPosHorizontal,
            int targetPosVertical, string figureType,
            string figureColor, int orderInTheGame)
        {
            InitialPosHorizontal = initialPosHorizontal;
            InitialPosVertical = initialPosVertical;
            TargetPosHorizontal = targetPosHorizontal;
            TargetPosVertical = targetPosVertical;
            FigureType = figureType;
            FigureColor = figureColor;
            this.OrderInTheGame = orderInTheGame;
        }

        [Key]
        public int Id { get; set; }

        public char InitialPosHorizontal { get; set; }
        public int InitialPosVertical { get; set; }
        public char TargetPosHorizontal { get; set; }
        public int TargetPosVertical { get; set; }

        public int OrderInTheGame { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        [Required]
        public string FigureType { get; set; }

        [Required]
        public string FigureColor { get; set; }
    }
}
