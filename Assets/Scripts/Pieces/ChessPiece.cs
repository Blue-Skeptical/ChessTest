using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    //Position on board (0:0 to 7:7)
    //-1 is for out of the board
    protected int X = -1;
    protected int Y = -1;

    //Event rised when a piece moves. The turn finishes.
    //MatchManager subscribe to change the player's turn;
    public static event Action PieceMoved;

    //WHITE or BLACK
    protected string MyPlayer = "";

    //List of all Allowed move tile game object generated when clicked on this piece
    private List<GameObject> AllowedMovesGameObject = new List<GameObject>();

    //When I select this piece
    private void OnMouseDown()
    {
        //If it's not the turn of my player, I return
        if (MyPlayer != MatchManager.MM.CurrentPlayer) return;

        MatchManager.MM.PieceSelected(this);
        ShowAllowedMoves();
    }

    private void ShowAllowedMoves()
    {
        //aux GameObject
        GameObject _go;
        foreach(Vector2Int pos in GenerateAllowedMovePosition())
        {
            _go = Instantiate(MatchManager.MM.GetMoveTilePrefab(), MatchManager.MM.GetCoords(pos.x, pos.y,-2), Quaternion.identity);
            AllowedMovesGameObject.Add(_go);
            _go.GetComponent<MoveTile>().SetXY(pos.x,pos.y);
        }
    }
    //Return a list of all the positions allowed
    protected abstract List<Vector2Int> GenerateAllowedMovePosition();

    //Getter of the allowed move positions
    public List<Vector2Int> GetAllowedMovePosition()
    {
        return GenerateAllowedMovePosition();
    }


    //Used to remove all the Allowed moves tile gameobjects
    public void DeleteAllowedMoveTiles()
    {
        foreach (GameObject g in AllowedMovesGameObject) Destroy(g);
    }

    //When I move a pieces
    public void MoveChessPiece(int x, int y)
    {
        //Update the matrix of all pieces on the board
        MatchManager.MM.UpdatePiecesPosition(X, Y, x, y);
        //Change my coordinate
        SetXY(x, y);
        transform.position = MatchManager.MM.GetCoords(x, y);
        //Raise the event
        PieceMoved?.Invoke();
    }

    //Getter Setter
    public void SetX(int x) => X = x;
    public void SetY(int y) => Y = y;
    public int GetX() => X;
    public int GetY() => Y;
    public string GetMyPlayer() => MyPlayer;
    public void SetMyPlayer(string s) => MyPlayer = s;
    public void SetXY(int x, int y)
    {
        X = x;
        Y = y;
    }
}
