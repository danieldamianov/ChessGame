using LogicForChessGame;
using LogicForChessGame.Enums;
using LogicForChessGame.Figures;
using LogicForChessGameFrameWork;
using System;
using System.Reflection;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            ChessGame chessGame = new ChessGame("","");
            DisplayBoard(chessGame.chessBoard);
            while (true)
            {
                char initialPosHor = char.Parse(Console.ReadLine());
                int initialPosVert = int.Parse(Console.ReadLine());
                char targetPosHor = char.Parse(Console.ReadLine());
                int targetPosVert = int.Parse(Console.ReadLine());

                Assembly assembly = Assembly.LoadFile(@"D:\C#\ChessGame\ChessGame\LogicForChessGameFrameWork\obj\Debug\LogicForChessGameFrameWork.dll");
                string typeName = Console.ReadLine();
                Type type = assembly.GetType("LogicForChessGame.Figures." + typeName);
                Colors color = (Colors)Enum.Parse(typeof(Colors), Console.ReadLine());

                var x = chessGame.NormalMove(new NormalMovePositions(initialPosHor, initialPosVert, targetPosHor, targetPosVert)
                    , type, color);

                DisplayBoard(chessGame.chessBoard);
                
            }
            //ChessBoard chessBoard = new ChessBoard();

            //Rook rook = new Rook(Colors.Black);

            //Console.WriteLine(rook.GetPositionsInTheWayOfMove(new NormalMovePositions('d', 5, 'd', 8)));//true
            //Console.WriteLine(rook.GetPositionsInTheWayOfMove(new NormalMovePositions('d', 5, 'h', 5)));//true
            //Console.WriteLine(rook.GetPositionsInTheWayOfMove(new NormalMovePositions('d', 5, 'd', 1)));//false
            //Console.WriteLine(rook.GetPositionsInTheWayOfMove(new NormalMovePositions('d', 5, 'a', 5)));//false

            //Console.WriteLine();

            //Bishop bishop = new Bishop(Colors.Black);

            //Console.WriteLine(bishop.GetPositionsInTheWayOfMove(new NormalMovePositions('d', 5, 'g', 8)));//true
            //Console.WriteLine(bishop.GetPositionsInTheWayOfMove(new NormalMovePositions('d', 5, 'h', 1)));//true
            //Console.WriteLine(bishop.GetPositionsInTheWayOfMove(new NormalMovePositions('d', 5, 'a', 2)));//true
            //Console.WriteLine(bishop.GetPositionsInTheWayOfMove(new NormalMovePositions('d', 5, 'a', 8)));//true
        }

        public static void DisplayBoard(ChessBoard chessBoard)
        {
            ConsoleColor consoleColor = ConsoleColor.Gray;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.BackgroundColor = consoleColor;
                    if (chessBoard.board[i, j] != null)
                    {
                        Console.ForegroundColor = ParseColor(chessBoard.board[i, j].color);
                        Console.Write(chessBoard.board[i, j].Sign); 
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    if (j != 7)
                    {
                    consoleColor = SwitchColor(consoleColor);

                    }
                    ConsoleColor old = consoleColor;
                    Console.BackgroundColor = ConsoleColor.Red;
                    if (j == 7)
                    {
                        Console.Write(8 - i);
                    }
                    Console.BackgroundColor = old;
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Red;
            for (char i = 'a'; i <= 'h'; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }

        private static ConsoleColor ParseColor(Colors color)
        {
            if (color == Colors.Black)
            {
                return ConsoleColor.Black;
            }
            return ConsoleColor.Yellow;
        }

        private static ConsoleColor SwitchColor(ConsoleColor consoleColor)
        {
            if (consoleColor == ConsoleColor.DarkGray)
            {
                return ConsoleColor.Gray;
            }
            return ConsoleColor.DarkGray;
        }
    }
}
