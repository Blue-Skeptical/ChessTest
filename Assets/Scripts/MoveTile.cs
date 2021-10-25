using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
    private int X;
    private int Y;

    //If I click on this tile, the current piece moves
    private void OnMouseDown()
    { 
        //Move the piece to a given location
        MatchManager.MM.GetCurrentPiece().MoveChessPiece(X, Y);
        //Move the Selector to my position (it's nicer to see)
        MatchManager.MM.MoveSelector(X, Y);
        //Delete all the Allowed move tiles generate previusly
        MatchManager.MM.GetCurrentPiece().DeleteAllowedMoveTiles();
    }

    public void SetXY(int x, int y)
    {
        X = x;
        Y = y;
    }
}
