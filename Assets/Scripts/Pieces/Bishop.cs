using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
{
    protected override List<Vector2Int> GenerateAllowedMovePosition()
    {
        List<Vector2Int> res = new List<Vector2Int>();
        ChessPiece[,] PiecesPosition = MatchManager.MM.GetPiecesPosition();
        
        if(MyPlayer == "WHITE")
        {
            //North-East
            for(int i=1; i < MatchManager.MM.GetRowSize(); i++)
            {
                if (!MatchManager.MM.InsideBoard(X + i, Y + i)) break;
                else if (PiecesPosition[X + i, Y + i] == null) res.Add(new Vector2Int(X + i, Y + i));
                else if (PiecesPosition[X + i, Y + i].GetMyPlayer() == "WHITE") break;
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
                else if (PiecesPosition[X - i, Y + i].GetMyPlayer() == "WHITE") break;
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
                else if (PiecesPosition[X + i, Y - i].GetMyPlayer() == "WHITE") break;
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
                else if (PiecesPosition[X - i, Y - i].GetMyPlayer() == "WHITE") break;
                else
                {
                    res.Add(new Vector2Int(X - i, Y - i));
                    break;
                }
            }
        }
        if(MyPlayer == "BLACK")
        {
            //North-East
            for (int i = 1; i < MatchManager.MM.GetRowSize(); i++)
            {
                if (!MatchManager.MM.InsideBoard(X + i, Y + i)) break;
                else if (PiecesPosition[X + i, Y + i] == null) res.Add(new Vector2Int(X + i, Y + i));
                else if (PiecesPosition[X + i, Y + i].GetMyPlayer() == "BLACK") break;
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
                else if (PiecesPosition[X - i, Y + i].GetMyPlayer() == "BLACK") break;
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
                else if (PiecesPosition[X + i, Y - i].GetMyPlayer() == "BLACK") break;
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
                else if (PiecesPosition[X - i, Y - i].GetMyPlayer() == "BLACK") break;
                else
                {
                    res.Add(new Vector2Int(X - i, Y - i));
                    break;
                }
            }
        }


        return res;
    }
}
