using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    protected override List<Vector2Int> GenerateAllowedMovePosition()
    {
        List<Vector2Int> res = new List<Vector2Int>();
        ChessPiece[,] PiecesPosition = MatchManager.MM.GetPiecesPosition();

        if(MyPlayer == "WHITE")
        {
            //Up
            if (MatchManager.MM.InsideBoard(X, Y + 1) &&
               ((PiecesPosition[X, Y + 1] == null) || (PiecesPosition[X, Y + 1].GetMyPlayer() == "BLACK")))
                res.Add(new Vector2Int(X, Y + 1));
            //Down
            if (MatchManager.MM.InsideBoard(X, Y - 1) &&
               ((PiecesPosition[X, Y - 1] == null) || (PiecesPosition[X, Y - 1].GetMyPlayer() == "BLACK")))
                res.Add(new Vector2Int(X, Y - 1));
            //Right
            if (MatchManager.MM.InsideBoard(X + 1, Y) &&
               ((PiecesPosition[X + 1, Y] == null) || (PiecesPosition[X + 1, Y].GetMyPlayer() == "BLACK")))
                res.Add(new Vector2Int(X + 1, Y));
            //Left
            if (MatchManager.MM.InsideBoard(X - 1, Y) &&
               ((PiecesPosition[X - 1, Y] == null) || (PiecesPosition[X - 1, Y].GetMyPlayer() == "BLACK")))
                res.Add(new Vector2Int(X - 1, Y));
            //N-E
            if (MatchManager.MM.InsideBoard(X + 1, Y + 1) &&
               ((PiecesPosition[X + 1, Y + 1] == null) || (PiecesPosition[X + 1, Y + 1].GetMyPlayer() == "BLACK")))
                res.Add(new Vector2Int(X + 1, Y + 1));
            //N-O
            if (MatchManager.MM.InsideBoard(X - 1, Y + 1) &&
               ((PiecesPosition[X - 1, Y + 1] == null) || (PiecesPosition[X - 1, Y + 1].GetMyPlayer() == "BLACK")))
                res.Add(new Vector2Int(X - 1, Y + 1));
            //S-E
            if (MatchManager.MM.InsideBoard(X + 1, Y - 1) &&
               ((PiecesPosition[X + 1, Y - 1] == null) || (PiecesPosition[X + 1, Y - 1].GetMyPlayer() == "BLACK")))
                res.Add(new Vector2Int(X + 1, Y - 1));
            //S-O
            if (MatchManager.MM.InsideBoard(X - 1, Y - 1) &&
               ((PiecesPosition[X - 1, Y - 1] == null) || (PiecesPosition[X - 1, Y - 1].GetMyPlayer() == "BLACK")))
                res.Add(new Vector2Int(X - 1, Y - 1));
        }
        if (MyPlayer == "BLACK")
        {
            //Up
            if (MatchManager.MM.InsideBoard(X, Y + 1) &&
               ((PiecesPosition[X, Y + 1] == null) || (PiecesPosition[X, Y + 1].GetMyPlayer() == "WHITE")))
                res.Add(new Vector2Int(X, Y + 1));
            //Down
            if (MatchManager.MM.InsideBoard(X, Y - 1) &&
               ((PiecesPosition[X, Y - 1] == null) || (PiecesPosition[X, Y - 1].GetMyPlayer() == "WHITE")))
                res.Add(new Vector2Int(X, Y - 1));
            //Right
            if (MatchManager.MM.InsideBoard(X + 1, Y) &&
               ((PiecesPosition[X + 1, Y] == null) || (PiecesPosition[X + 1, Y].GetMyPlayer() == "WHITE")))
                res.Add(new Vector2Int(X + 1, Y));
            //Left
            if (MatchManager.MM.InsideBoard(X - 1, Y) &&
               ((PiecesPosition[X - 1, Y] == null) || (PiecesPosition[X - 1, Y].GetMyPlayer() == "WHITE")))
                res.Add(new Vector2Int(X - 1, Y));
            //N-E
            if (MatchManager.MM.InsideBoard(X + 1, Y + 1) &&
               ((PiecesPosition[X + 1, Y + 1] == null) || (PiecesPosition[X + 1, Y + 1].GetMyPlayer() == "WHITE")))
                res.Add(new Vector2Int(X + 1, Y + 1));
            //N-O
            if (MatchManager.MM.InsideBoard(X - 1, Y + 1) &&
               ((PiecesPosition[X - 1, Y + 1] == null) || (PiecesPosition[X - 1, Y + 1].GetMyPlayer() == "WHITE")))
                res.Add(new Vector2Int(X - 1, Y + 1));
            //S-E
            if (MatchManager.MM.InsideBoard(X + 1, Y - 1) &&
               ((PiecesPosition[X + 1, Y - 1] == null) || (PiecesPosition[X + 1, Y - 1].GetMyPlayer() == "WHITE")))
                res.Add(new Vector2Int(X + 1, Y - 1));
            //S-O
            if (MatchManager.MM.InsideBoard(X - 1, Y - 1) &&
               ((PiecesPosition[X - 1, Y - 1] == null) || (PiecesPosition[X - 1, Y - 1].GetMyPlayer() == "WHITE")))
                res.Add(new Vector2Int(X - 1, Y - 1));
        }

        return res;
    }
}
