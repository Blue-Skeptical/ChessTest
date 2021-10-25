using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    protected override List<Vector2Int> GenerateAllowedMovePosition()
    {
        List<Vector2Int> res = new List<Vector2Int>();
        ChessPiece[,] PiecesPosition = MatchManager.MM.GetPiecesPosition();


        if (MyPlayer == "WHITE")
        {
            //Up
            if (MatchManager.MM.InsideBoard(X + 1, Y + 2) &&
               (PiecesPosition[X + 1, Y + 2] == null || PiecesPosition[X + 1, Y + 2].GetMyPlayer() == "BLACK"))
                res.Add(new Vector2Int(X+1, Y+2));
            if (MatchManager.MM.InsideBoard(X - 1, Y + 2) &&
               (PiecesPosition[X - 1, Y + 2] == null || PiecesPosition[X - 1, Y + 2].GetMyPlayer() == "BLACK"))
                res.Add(new Vector2Int(X - 1, Y + 2));
            //Down
            if (MatchManager.MM.InsideBoard(X + 1, Y - 2) &&
               (PiecesPosition[X + 1, Y - 2] == null || PiecesPosition[X + 1, Y - 2].GetMyPlayer() == "BLACK"))
                res.Add(new Vector2Int(X + 1, Y - 2));
            if (MatchManager.MM.InsideBoard(X - 1, Y - 2) &&
               (PiecesPosition[X - 1, Y - 2] == null || PiecesPosition[X - 1, Y - 2].GetMyPlayer() == "BLACK"))
                res.Add(new Vector2Int(X - 1, Y - 2));
            //Left
            if (MatchManager.MM.InsideBoard(X + 2, Y + 1) &&
               (PiecesPosition[X + 2, Y +1] == null || PiecesPosition[X + 2, Y +1].GetMyPlayer() == "BLACK"))
                res.Add(new Vector2Int(X + 2, Y +1));
            if (MatchManager.MM.InsideBoard(X + 2, Y - 1) &&
               (PiecesPosition[X + 2, Y - 1] == null || PiecesPosition[X + 2, Y - 1].GetMyPlayer() == "BLACK"))
                res.Add(new Vector2Int(X + 2, Y - 1));
            //Right
            if (MatchManager.MM.InsideBoard(X - 2, Y + 1) &&
               (PiecesPosition[X - 2, Y + 1] == null || PiecesPosition[X - 2, Y + 1].GetMyPlayer() == "BLACK"))
                res.Add(new Vector2Int(X - 2, Y + 1));
            if (MatchManager.MM.InsideBoard(X - 2, Y - 1) &&
               (PiecesPosition[X - 2, Y - 1] == null || PiecesPosition[X - 2, Y - 1].GetMyPlayer() == "BLACK"))
                res.Add(new Vector2Int(X - 2, Y - 1));

        }
        if(MyPlayer == "BLACK")
        {
            //Up
            if (MatchManager.MM.InsideBoard(X + 1, Y + 2) &&
               (PiecesPosition[X + 1, Y + 2] == null || PiecesPosition[X + 1, Y + 2].GetMyPlayer() == "WHITE"))
                res.Add(new Vector2Int(X + 1, Y + 2));
            if (MatchManager.MM.InsideBoard(X - 1, Y + 2) &&
               (PiecesPosition[X - 1, Y + 2] == null || PiecesPosition[X - 1, Y + 2].GetMyPlayer() == "WHITE"))
                res.Add(new Vector2Int(X - 1, Y + 2));
            //Down
            if (MatchManager.MM.InsideBoard(X + 1, Y - 2) &&
               (PiecesPosition[X + 1, Y - 2] == null || PiecesPosition[X + 1, Y - 2].GetMyPlayer() == "WHITE"))
                res.Add(new Vector2Int(X + 1, Y - 2));
            if (MatchManager.MM.InsideBoard(X - 1, Y - 2) &&
               (PiecesPosition[X - 1, Y - 2] == null || PiecesPosition[X - 1, Y - 2].GetMyPlayer() == "WHITE"))
                res.Add(new Vector2Int(X - 1, Y - 2));
            //Left
            if (MatchManager.MM.InsideBoard(X + 2, Y + 1) &&
               (PiecesPosition[X + 2, Y + 1] == null || PiecesPosition[X + 2, Y + 1].GetMyPlayer() == "WHITE"))
                res.Add(new Vector2Int(X + 2, Y + 1));
            if (MatchManager.MM.InsideBoard(X + 2, Y - 1) &&
               (PiecesPosition[X + 2, Y - 1] == null || PiecesPosition[X + 2, Y - 1].GetMyPlayer() == "WHITE"))
                res.Add(new Vector2Int(X + 2, Y - 1));
            //Right
            if (MatchManager.MM.InsideBoard(X - 2, Y + 1) &&
               (PiecesPosition[X - 2, Y + 1] == null || PiecesPosition[X - 2, Y + 1].GetMyPlayer() == "WHITE"))
                res.Add(new Vector2Int(X - 2, Y + 1));
            if (MatchManager.MM.InsideBoard(X - 2, Y - 1) &&
               (PiecesPosition[X - 2, Y - 1] == null || PiecesPosition[X - 2, Y - 1].GetMyPlayer() == "WHITE"))
                res.Add(new Vector2Int(X - 2, Y - 1));
        }


        return res;
    }
}
