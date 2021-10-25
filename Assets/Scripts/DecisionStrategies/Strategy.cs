using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision
{
    public ChessPiece Piece;
    public int X;
    public int Y;
}

public abstract class Strategy : MonoBehaviour
{
    //The player that want to perform my strategy
    private string MyPlayer;
    //Function that makes decisions
    public abstract Decision MakeDecision(List<ChessPiece> MyPieces);

    public void InitStrategy(string Player)
    {
        MyPlayer = Player;
    }
}
