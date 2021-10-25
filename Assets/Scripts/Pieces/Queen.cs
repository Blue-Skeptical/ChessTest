using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
{
    protected override List<Vector2Int> GenerateAllowedMovePosition()
    {
        List<Vector2Int> res = new List<Vector2Int>();

        if(MyPlayer == "WHITE")
        {
            //Rook pattern
            RookPatter(ref res, "BLACK");
            //Bishop pattern
            BishopPattern(ref res, "WHITE");
        }
        if(MyPlayer == "BLACK")
        {
            //Rook pattern
            RookPatter(ref res, "WHITE");
            //Bishop pattern
            BishopPattern(ref res, "BLACK");
        }


        return res;
    }


    private void RookPatter(ref List<Vector2Int> res, string OtherColor)
    {
        ChessPiece[,] PiecesPosition = MatchManager.MM.GetPiecesPosition();
        //Forward
        for (int y = Y + 1; y < MatchManager.MM.GetRowSize(); y++)
        {
            if (PiecesPosition[X, y] == null) res.Add(new Vector2Int(X, y));
            else if (PiecesPosition[X, y].GetMyPlayer() == OtherColor)
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
            else if (PiecesPosition[X, y].GetMyPlayer() == OtherColor)
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
            else if (PiecesPosition[x, Y].GetMyPlayer() == OtherColor)
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
            else if (PiecesPosition[x, Y].GetMyPlayer() == OtherColor)
            {
                res.Add(new Vector2Int(x, Y));
                break;
            }
            else break;
        }
    }
    private void BishopPattern(ref List<Vector2Int> res, string MyColor)
    {
        ChessPiece[,] PiecesPosition = MatchManager.MM.GetPiecesPosition();
        //North-East
        for (int i = 1; i < MatchManager.MM.GetRowSize(); i++)
        {
            if (!MatchManager.MM.InsideBoard(X + i, Y + i)) break;
            else if (PiecesPosition[X + i, Y + i] == null) res.Add(new Vector2Int(X + i, Y + i));
            else if (PiecesPosition[X + i, Y + i].GetMyPlayer() == MyColor) break;
            else
            {
                res.Add(new Vector2Int(X + i, Y + i));
                break;
            }
        }
        //North-West
        for (int i = 1; i < MatchManager.MM.GetRowSize(); i++)
        {
            if (!MatchManager.MM.InsideBoard(X - i, Y + i)) break;
            else if (PiecesPosition[X - i, Y + i] == null) res.Add(new Vector2Int(X - i, Y + i));
            else if (PiecesPosition[X - i, Y + i].GetMyPlayer() == MyColor) break;
            else
            {
                res.Add(new Vector2Int(X - i, Y + i));
                break;
            }
        }
        //South-East
        for (int i = 1; i < MatchManager.MM.GetRowSize(); i++)
        {
            if (!MatchManager.MM.InsideBoard(X + i, Y - i)) break;
            else if (PiecesPosition[X + i, Y - i] == null) res.Add(new Vector2Int(X + i, Y - i));
            else if (PiecesPosition[X + i, Y - i].GetMyPlayer() == MyColor) break;
            else
            {
                res.Add(new Vector2Int(X + i, Y - i));
                break;
            }
        }
        //South-West
        for (int i = 1; i < MatchManager.MM.GetRowSize(); i++)
        {
            if (!MatchManager.MM.InsideBoard(X - i, Y - i)) break;
            else if (PiecesPosition[X - i, Y - i] == null) res.Add(new Vector2Int(X - i, Y - i));
            else if (PiecesPosition[X - i, Y - i].GetMyPlayer() == MyColor) break;
            else
            {
                res.Add(new Vector2Int(X - i, Y - i));
                break;
            }
        }
    }
}
