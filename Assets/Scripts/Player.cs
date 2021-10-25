using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //All my pieces on board
    public List<ChessPiece> MyPieces;

    //BLACK or WHITE
    [SerializeField] private string Colour;

    //True: Player      False: AI
    private bool isPlayer;

    //My Decision strategy
    [SerializeField] private Strategy MyDecisionStrategy;


    //Piece take
    public void PieceTaken(ChessPiece piece)
    {
        MyPieces.Remove(piece);
    }

    //First function that initialize the instance
    public void init(ChessPiece[] pieces, bool isplayer, string MyColour)
    {
        MyPieces = new List<ChessPiece>(pieces);
        isPlayer = isplayer;
        Colour = MyColour;

        //If I'm AI
        if (!isPlayer) initAI();
    }


    private void initAI()
    {
        //Init my strategy
        MyDecisionStrategy.InitStrategy(Colour);

        //Subscribe to the event that tells me the turn has changed
        MatchManager.MM.TurnEnded += TurnChanged;
        MatchManager.MM.GameOver += GameOver;
    }

    public void TurnChanged()
    {
        //If it's not my turn, return;
        if (MatchManager.MM.CurrentPlayer != Colour) return;
        //If it's my turn:
        StartCoroutine(AIMoves());
    }

    private IEnumerator AIMoves()
    {
        //Wait some time before perform a move
        yield return new WaitForSeconds(0.5f);
        //If it's my turn:
        Decision D = MyDecisionStrategy.MakeDecision(MyPieces);
        //Move my piece
        D.Piece.MoveChessPiece(D.X, D.Y);
    }

    public void GameOver()
    {
        MatchManager.MM.TurnEnded -= TurnChanged;
        MatchManager.MM.GameOver -= GameOver;
    }

    //Getter
    public List<ChessPiece> GetMyPieces() => MyPieces;

}
