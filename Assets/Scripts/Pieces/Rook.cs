using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    protected override List<Vector2Int> GenerateAllowedMovePosition()
    {
        List<Vector2Int> res = new List<Vector2Int>();

        ChessPiece[,] PiecesPosition = MatchManager.MM.GetPiecesPosition();

        if (MyPlayer == "WHITE")
        {
            //Forward
            for(int y=Y+1; y < MatchManager.MM.GetRowSize(); y++)
            {
                if (PiecesPosition[X, y] == null) res.Add(new Vector2Int(X, y));
                else if (PiecesPosition[X, y].GetMyPlayer() == "BLACK")
                {
                    res.Add(new Vector2Int(X, y));
                    break;
                }
                else break;
            }
            //Backward
            for (int y = Y - 1; y >= 0; y--)
            {
                if (PiecesPosition[X, y] == null) res.Add(new Vector2Int(X, y));
                else if (PiecesPosition[X, y].GetMyPlayer() == "BLACK")
                {
                    res.Add(new Vector2Int(X, y));
                    break;
                }
                else break;
            }
            //Right
            for (int x = X + 1; x < MatchManager.MM.GetRowSize(); x++)
            {
                if (PiecesPosition[x, Y] == null) res.Add(new Vector2Int(x, Y));
                else if (PiecesPosition[x, Y].GetMyPlayer() == "BLACK")
                {
                    res.Add(new Vector2Int(x, Y));
                    break;
                }
                else break;
            }
            //Left
            for (int x = X - 1; x >= 0; x--)
            {
                if (PiecesPosition[x, Y] == null) res.Add(new Vector2Int(x, Y));
                else if (PiecesPosition[x, Y].GetMyPlayer() == "BLACK")
                {
                    res.Add(new Vector2Int(x, Y));
                    break;
                }
                else break;
            }
        }
        if (MyPlayer == "BLACK")
        {
            //Forward
            for (int y = Y + 1; y < MatchManager.MM.GetRowSize(); y++)
            {
                if (PiecesPosition[X, y] == null) res.Add(new Vector2Int(X, y));
                else if (PiecesPosition[X, y].GetMyPlayer() == "WHITE")
                {
                    res.Add(new Vector2Int(X, y));
                    break;
                }
                else break;
            }
            //Backward
            for (int y = Y - 1; y >= 0; y--)
            {
                if (PiecesPosition[X, y] == null) res.Add(new Vector2Int(X, y));
                else if (PiecesPosition[X, y].GetMyPlayer() == "WHITE")
                {
                    res.Add(new Vector2Int(X, y));
                    break;
                }
                else break;
            }
            //Right
            for (int x = X + 1; x < MatchManager.MM.GetRowSize(); x++)
            {
                if (PiecesPosition[x, Y] == null) res.Add(new Vector2Int(x, Y));
                else if (PiecesPosition[x, Y].GetMyPlayer() == "WHITE")
                {
                    res.Add(new Vector2Int(x, Y));
                    break;
                }
                else break;
            }
            //Left
            for (int x = X - 1; x >= 0; x--)
            {
                if (PiecesPosition[x, Y] == null) res.Add(new Vector2Int(x, Y));
                else if (PiecesPosition[x, Y].GetMyPlayer() == "WHITE")
                {
                    res.Add(new Vector2Int(x, Y));
                    break;
                }
                else break;
            }

        }
        return res;
    }
}
