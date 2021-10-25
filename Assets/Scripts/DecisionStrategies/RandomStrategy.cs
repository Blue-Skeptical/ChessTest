using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStrategy : Strategy
{
    //Select a RANDOM owned piece and perform a RANDOM allowed move
    public override Decision MakeDecision(List<ChessPiece> MyPieces)
    {
        //result
        Decision D = new Decision();

        ChessPiece piece = null;
        Vector2Int Move = new Vector2Int();
        List<Vector2Int> AllowedMoves = new List<Vector2Int>();

        //While i select a piece with no allowed moves
        while(AllowedMoves.Count == 0)
        {  
            //I randomize another piece
            piece = MyPieces[Random.Range(0, MyPieces.Count)];
            //Generate its allowed moves
            AllowedMoves = piece.GetAllowedMovePosition();
        }

        //Then I select a random allowed moves
        Move = AllowedMoves[Random.Range(0, AllowedMoves.Count)];

        D.Piece = piece;
        D.X = Move.x;
        D.Y = Move.y;

        return D;
    }
}
