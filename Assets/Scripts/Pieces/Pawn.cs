using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    //For double its movement on first move
    private bool firstMove = true;
    protected override List<Vector2Int> GenerateAllowedMovePosition()
    {
        List<Vector2Int> res = new List<Vector2Int>();
        ChessPiece[,] PiecesPosition = MatchManager.MM.GetPiecesPosition();
        //_____ WHITE _____
        if (MyPlayer == "WHITE")
        {
            //Forward
            if (MatchManager.MM.InsideBoard(X, Y + 1) && (PiecesPosition[X, Y + 1] == null))
            {
                res.Add(new Vector2Int(X, Y + 1));
                if(firstMove && PiecesPosition[X,Y+2] == null)
                {
                    firstMove = false;
                    res.Add(new Vector2Int(X, Y + 2));
                }
            }
            //Takes
            if (MatchManager.MM.InsideBoard(X + 1, Y + 1) && 
                PiecesPosition[X + 1, Y + 1] != null && 
                PiecesPosition[X + 1, Y + 1].GetMyPlayer() == "BLACK")
                    res.Add(new Vector2Int(X + 1, Y + 1));
            if (MatchManager.MM.InsideBoard(X - 1, Y + 1) && 
                PiecesPosition[X - 1, Y + 1] != null && 
                PiecesPosition[X - 1, Y + 1].GetMyPlayer() == "BLACK")
                    res.Add(new Vector2Int(X - 1, Y + 1));
        }

        // _____ BLACK _____
        else
        {   
            //Forward
            if (MatchManager.MM.InsideBoard(X, Y - 1) && (PiecesPosition[X, Y - 1] == null))
            {
                res.Add(new Vector2Int(X, Y - 1));

                if (firstMove && PiecesPosition[X, Y - 2] == null)
                {
                    firstMove = false;
                    res.Add(new Vector2Int(X, Y - 2));
                }
            }
            //Takes
            if (MatchManager.MM.InsideBoard(X + 1, Y - 1) && 
                PiecesPosition[X + 1, Y - 1] != null && 
                PiecesPosition[X + 1, Y - 1].GetMyPlayer() == "WHITE")
                    res.Add(new Vector2Int(X + 1, Y - 1));
            if (MatchManager.MM.InsideBoard(X - 1, Y - 1) && 
                PiecesPosition[X - 1, Y - 1] != null && 
                PiecesPosition[X - 1, Y - 1].GetMyPlayer() == "WHITE")
                    res.Add(new Vector2Int(X - 1, Y - 1));
        }

        return res;
    }

}
