﻿using DatabaseModel.Modles;
using LogicForChessGame.Enums;
using LogicForChessGame.Figures;
using LogicForChessGameFrameWork;
using LogicForChessGameFrameWork.Enums;
using LogicForChessGameFrameWork.Figures.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicForChessGame
{
    public class ChessGame
    {
        public Colors PlayerOnTurn { get; private set; }

        public ChessBoard chessBoard;

        public string User1WhitesName { get; set; }
        public string User2BlacksName { get; set; }
        private int counterOfTheMoves;

        public List<BaseMove> movesInTheGame;

        public ChessGame(string username1,string username2)
        {
            this.PlayerOnTurn = Colors.White;
            this.chessBoard = new ChessBoard();
            User1WhitesName = username1;
            User2BlacksName = username2;
            this.counterOfTheMoves = 1;
            this.movesInTheGame = new List<BaseMove>();
        }

        public void ProducePawn(PositionOnTheBoard positionOnTheBoard,Figure prodeucedFigure,Colors colors)
        {
            this.chessBoard.PutFigureOnPosition(positionOnTheBoard, prodeucedFigure);
            this.movesInTheGame.Add(new ProducingPawn() { OrderInTheGame = this.counterOfTheMoves});
            this.counterOfTheMoves++;
        }

        public InvalidMoveReason? ValidateMove(NormalMovePositions positions, Type FigureType, Colors color)
        {
            Figure figureToMove = this.chessBoard.GetFigureOnPosition(positions.InitialPosition);
            Type actuelFigureType = figureToMove.GetType();
            Figure figureOnTargetPosition = this.chessBoard.GetFigureOnPosition(positions.TargetPosition);
            if (figureToMove == null || actuelFigureType.FullName != FigureType.FullName || figureToMove.color != color)
            {
                return InvalidMoveReason.ThereIsntSuchFigureAndColorOnTheGivenPosition;
            }
            if (figureOnTargetPosition != null &&
                (figureOnTargetPosition.GetType() == typeof(King) || figureOnTargetPosition.color == figureToMove.color))
            {
                return InvalidMoveReason.TheFigureOnTheTargetPositionIsFriendlyOrEnemyKing;
            }

            if (figureToMove is Pawn)
            {

                if (((Pawn)figureToMove).AreMovePositionsPossible(positions) == true
                    && figureOnTargetPosition != null)
                {
                    return InvalidMoveReason.MovePositionsAreNotValid;
                }

                if (
                        ((((Pawn)figureToMove).AreMovePositionsPossible(positions) == false &&
                    ((Pawn)figureToMove).IsAttackingMovePossible(positions) == false) ||
                            (
                                ((Pawn)figureToMove).IsAttackingMovePossible(positions) &&
                                (figureOnTargetPosition == null
                                || figureOnTargetPosition.color == figureToMove.color)
                            )
                       ))
                {
                    return InvalidMoveReason.MovePositionsAreNotValid;
                }
            }
            else
            {
                if (figureToMove.AreMovePositionsPossible(positions) == false)
                {
                    return InvalidMoveReason.MovePositionsAreNotValid;
                }
            }

            if (figureToMove is IUnableToJump)
            {
                foreach (var position in ((IUnableToJump)figureToMove).GetPositionsInTheWayOfMove(positions))
                {
                    if (this.chessBoard.GetFigureOnPosition(position) != null)
                    {
                        return InvalidMoveReason.ThereAreOtherPiecesOnTheWay;
                    }
                }
            }

            ChessBoard chessBoard = this.chessBoard.GetVirtualChessBoardAfterMove(positions);

            if (CheckForCheck(chessBoard,color))
            {
                return InvalidMoveReason.MovementResultsInCheckOfTheFriendlyKing;
            }

            return null;
            
        }

        public InvalidMoveReason? ValidateMoveWithoutCheck(NormalMovePositions positions, Type FigureType, Colors color,ChessBoard chessBoardParam)
        {
            Figure figureToMove = chessBoardParam.GetFigureOnPosition(positions.InitialPosition);
            Figure figureOnTargetPosition = chessBoardParam.GetFigureOnPosition(positions.TargetPosition);
            if (figureToMove == null || figureToMove.GetType() != FigureType || figureToMove.color != color)
            {
                return InvalidMoveReason.ThereIsntSuchFigureAndColorOnTheGivenPosition;
            }
            if (figureOnTargetPosition != null &&
                (figureOnTargetPosition.color == figureToMove.color))
            {
                return InvalidMoveReason.TheFigureOnTheTargetPositionIsFriendlyOrEnemyKing;
            }

            if (figureToMove is Pawn)
            {

                if (((Pawn)figureToMove).AreMovePositionsPossible(positions) == true
                    && figureOnTargetPosition != null)
                {
                    return InvalidMoveReason.MovePositionsAreNotValid;
                }

                if (
                        ((((Pawn)figureToMove).AreMovePositionsPossible(positions) == false &&
                    ((Pawn)figureToMove).IsAttackingMovePossible(positions) == false) ||
                            (
                                ((Pawn)figureToMove).IsAttackingMovePossible(positions) &&
                                (figureOnTargetPosition == null
                                || figureOnTargetPosition.color == figureToMove.color)
                            )
                       ))
                {
                    return InvalidMoveReason.MovePositionsAreNotValid;
                }
            }
            else
            {
                if (figureToMove.AreMovePositionsPossible(positions) == false)
                {
                    return InvalidMoveReason.MovePositionsAreNotValid;
                }
            }

            if (figureToMove is IUnableToJump)
            {
                foreach (var position in ((IUnableToJump)figureToMove).GetPositionsInTheWayOfMove(positions))
                {
                    if (chessBoardParam.GetFigureOnPosition(position) != null)
                    {
                        return InvalidMoveReason.ThereAreOtherPiecesOnTheWay;
                    }
                }
            }

            return null;

        }

        public bool CheckForMate(Colors AttackingColor)
        {

            for (char i = 'a'; i <= 'h'; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    Figure figureFromDefensiveSide = this.chessBoard.GetFigureOnPosition(new PositionOnTheBoard(i, j));

                    if (figureFromDefensiveSide == null || figureFromDefensiveSide.color == AttackingColor)
                    {
                        continue;
                    }

                    for (char horizontal = 'a'; horizontal <= 'h'; horizontal++)
                    {
                        for (int vertical = 1; vertical <= 8; vertical++)
                        {
                            if (this.ValidateMove(new NormalMovePositions(i, j
                                , horizontal, vertical),
                                figureFromDefensiveSide.GetType()
                        , OppositeColor(AttackingColor)) == null)
                            {
                                return false;
                            }
                        }
                    }
                } 
            }
            return true;
        }

        public bool CheckForCheck(ChessBoard chessBoard, Colors color)
        {
            for (char horizontal = 'a'; horizontal <= 'h'; horizontal++)
            {
                for (int vertical = 1; vertical <= 8; vertical++)
                {
                    var figure = chessBoard.GetFigureOnPosition(new PositionOnTheBoard(horizontal, vertical));
                    if (figure == null || figure.color == color)
                    {
                        continue;
                    }

                    List<PositionOnTheBoard> positionsAttacked =
                        this.PossiblePositionsMovement(figure.GetType(), new PositionOnTheBoard(horizontal, vertical), OppositeColor(color)
                        ,chessBoard)
                        ;

                    foreach (var position in positionsAttacked)
                    {
                        Figure gifureOnPosition = chessBoard.GetFigureOnPosition(position);
                        if (gifureOnPosition is King && gifureOnPosition.color == color)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private Colors OppositeColor(Colors color)
        {
            if (color == Colors.Black)
            {
                return Colors.White;
            }
            return Colors.Black;
        }

        public List<PositionOnTheBoard> PossiblePositionsMovement(Type figure, PositionOnTheBoard position, Colors colors,ChessBoard chessBoardParam)
        {
            List<PositionOnTheBoard> positions = new List<PositionOnTheBoard>();
            for (char horizontal = 'a'; horizontal <= 'h'; horizontal++)
            {
                for (int vertical = 1; vertical <= 8; vertical++)
                {
                    if (this.ValidateMoveWithoutCheck(new NormalMovePositions(position.Horizontal,position.Vertical,horizontal,vertical)
                        ,figure,colors,chessBoardParam) == null)
                    {
                        positions.Add(new PositionOnTheBoard(horizontal, vertical));
                    }
                }
            }

            return positions;
        }

        public NormalMoveResultInfo NormalMove(NormalMovePositions positions,Type FigureType,Colors color)
        {
            Figure figure = this.chessBoard.GetFigureOnPosition(positions.InitialPosition);

            NormalMoveResultInfo normalMoveResultInfo = new NormalMoveResultInfo();

            normalMoveResultInfo.IsTheMoveValid = this.ValidateMove(positions, FigureType, color);

            if (normalMoveResultInfo.IsTheMoveValid == null)
            {

                chessBoard.RemoveFigureOnPosition(positions.InitialPosition);
                chessBoard.PutFigureOnPosition(positions.TargetPosition, figure);

                this.movesInTheGame.Add(new NormalMoveDabModel(positions.InitialPosition.Horizontal
                    ,positions.InitialPosition.Vertical,positions.TargetPosition.Horizontal,positions.TargetPosition.Vertical
                    ,FigureType.Name,color.ToString(),this.counterOfTheMoves));

                this.counterOfTheMoves++;

                if (figure is Pawn && ((Pawn)figure).isPositionProducable(positions.TargetPosition))
                {
                    normalMoveResultInfo.HasTheFigurePawnProducedItself = true;
                }

                this.PlayerOnTurn = ChangePlayer();
            }

            return normalMoveResultInfo;
        }

        private Colors ChangePlayer()
        {
            if (this.PlayerOnTurn == Colors.Black)
            {
                return Colors.White;
            }
            return Colors.Black;
        }

        public void NormalMoveWithoutValidation(NormalMovePositions normalMovePositions, Type type, Colors color)
        {
            Figure figure = this.chessBoard.GetFigureOnPosition(normalMovePositions.InitialPosition);

            //NormalMoveResultInfo normalMoveResultInfo = new NormalMoveResultInfo();

            

                chessBoard.RemoveFigureOnPosition(normalMovePositions.InitialPosition);
                chessBoard.PutFigureOnPosition(normalMovePositions.TargetPosition, figure);

                //this.movesInTheGame.Add(new NormalMoveDabModel(normalMovePositions.InitialPosition.Horizontal
                //    , normalMovePositions.InitialPosition.Vertical, normalMovePositions.TargetPosition.Horizontal, normalMovePositions.TargetPosition.Vertical
                //    , type.Name, color.ToString(), this.counterOfTheMoves));

                //this.counterOfTheMoves++;

                //if (figure is Pawn && ((Pawn)figure).isPositionProducable(normalMovePositions.TargetPosition))
                //{
                //    normalMoveResultInfo.HasTheFigurePawnProducedItself = true;
                //}

                this.PlayerOnTurn = ChangePlayer();
            
        }
    }
}