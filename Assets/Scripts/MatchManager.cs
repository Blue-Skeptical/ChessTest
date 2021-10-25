using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MatchManager : MonoBehaviour
{
    public static MatchManager MM;

    //Reference to the Board and the piece selector icon
    [SerializeField] private GameObject Board;      //The board reference
    [SerializeField] private GameObject Selector;   //The selector icon reference
    [SerializeField] private GameObject MoveTilePrefab; //The MoveTile prefab reference
    [SerializeField] private GameObject WhiteWinsIcon; //"WHITE WINS" icon reference
    [SerializeField] private GameObject BlackWinsIcon; //"BLACK WINS" icon reference
    [SerializeField] private GameObject TurnIndicator; 

    [Space(20f)]
    [SerializeField] private Player WHITE;  //Reference to the instance of WHITE player
    [SerializeField] private Player BLACK;  //Reference to the instance of BLACK player

    //Tiles on a raw
    private const int ROW_SIZE = 8;
    //Tile size
    public float TILE_SIZE { get; private set; }

    [Space(20f)]
    //Possibility to customize how the board is built
    [SerializeField] private GameObject[] FrontRow_BLACK = new GameObject[ROW_SIZE];
    [SerializeField] private GameObject[] BackRow_BLACK = new GameObject[ROW_SIZE];
    [SerializeField] private GameObject[] FrontRow_WHITE = new GameObject[ROW_SIZE];
    [SerializeField] private GameObject[] BackRow_WHITE = new GameObject[ROW_SIZE];

    //Player's pieces
    private ChessPiece[,] PiecesPosition;

    //Current and last Chess pieces selected
    private ChessPiece CurrentPieceSelected;
    private ChessPiece LastPieceSelected;

    //Current player to play
    public string CurrentPlayer { get; private set; }

    //EVENT
    //Event that tells me the turn has changed
    public event Action TurnEnded;
    //Event raised when the match is over
    public event Action GameOver;

    void Awake()
    {   //Singleton
        if (MM == null) MM = this;
        else if (MM != this) Destroy(gameObject);
    }


    public void MatchBegin(bool isWhitePlayer, bool isBlackPlayer)
    {
        //Build the board
        BuildBoard();

        //Initialize the players
        InitPlayers(isWhitePlayer, isBlackPlayer);

        //Subscribe to the event that told me when a player
        //has moved a piece, therefore the turn ends
        ChessPiece.PieceMoved += EndTurn;

        //The white moves first
        CurrentPlayer = "WHITE";
    }

    //Initialize the board
    private void BuildBoard()
    {
        PiecesPosition = new ChessPiece[ROW_SIZE, ROW_SIZE];
        //The board it's supposed to be square
        TILE_SIZE = Board.GetComponent<SpriteRenderer>().sprite.texture.width * Board.transform.localScale.x /800;
        //aux variable to manage the initialization
        GameObject _go;
        ChessPiece _cp;
        //Activate the selector
        Selector.SetActive(true);
        MoveSelector(-1, -1);
        //Activate the turn indicator
        TurnIndicator.SetActive(true);

        for(int i=0; i<ROW_SIZE; i++)
        {
            //For each piece in FrontRow_WHITE (BackRow_WHITE, FrontRow_BLACK, BackRow_BLACK), we place it correctly on the board,
            //set its private variable and populate the corresponding player's pieces array.
            //
            //WHITE
            ////Front Row
            _go = Instantiate(FrontRow_WHITE[i], GetCoords(i,1), Quaternion.identity);
            _cp = _go.GetComponent<ChessPiece>();
            _cp.SetXY(i, 1);
            _cp.SetMyPlayer("WHITE");
            PiecesPosition[i, 1] = _cp;
            ////Back Row
            _go = Instantiate(BackRow_WHITE[i], GetCoords(i,0), Quaternion.identity);
            _cp = _go.GetComponent<ChessPiece>();
            _cp.SetXY(i, 0);
            _cp.SetMyPlayer("WHITE");
            PiecesPosition[i, 0] = _cp;
            //
            //BLACK
            ////Front Row
            _go = Instantiate(FrontRow_BLACK[i], GetCoords(i,6), Quaternion.identity);
            _cp = _go.GetComponent<ChessPiece>();
            _cp.SetXY(i, 6);
            _cp.SetMyPlayer("BLACK");
            PiecesPosition[i, ROW_SIZE-2] = _cp;
            ////Back Row
            _go = Instantiate(BackRow_BLACK[i], GetCoords(i,7), Quaternion.identity);
            _cp = _go.GetComponent<ChessPiece>();
            _cp.SetXY(i, 7);
            _cp.SetMyPlayer("BLACK");
            PiecesPosition[i, ROW_SIZE-1] = _cp;
            //
        }
    }

    //Initialize the players
    private void InitPlayers(bool isWhitePlayer, bool isBlackPlayer)
    {
        ChessPiece[] player_WHITE = new ChessPiece[ROW_SIZE * 2];
        ChessPiece[] player_BLACK = new ChessPiece[ROW_SIZE * 2];

        //I build up the ChessPiece array owned by the players
        for (int i = 0; i < ROW_SIZE; i++)
        {
            player_WHITE[i] = PiecesPosition[i % ROW_SIZE, 0];
            player_BLACK[i] = PiecesPosition[i % ROW_SIZE, ROW_SIZE - 2];
        }

        for (int i = 0; i < ROW_SIZE; i++)
        {
            player_WHITE[ROW_SIZE + i] = PiecesPosition[i % ROW_SIZE, 1];
            player_BLACK[ROW_SIZE + i] = PiecesPosition[i % ROW_SIZE, ROW_SIZE - 1];
        }

        WHITE.init(player_WHITE, isWhitePlayer,"WHITE");
        BLACK.init(player_BLACK, isBlackPlayer,"BLACK");
    }

    public void EndTurn()
    {
        if (CurrentPlayer == "WHITE")
        {
            CurrentPlayer = "BLACK";
            //Update the TurnIndicator Position
            MoveTurnIndicator("TOP");

        }
        else if (CurrentPlayer == "BLACK")
        {
            CurrentPlayer = "WHITE";
            //Update the TurnIndicator Position
            MoveTurnIndicator("DOWN");
        }
        //Rise the event
        TurnEnded?.Invoke();
    }
    
    //Function called when a piece is selected
    public void PieceSelected(ChessPiece p)
    {
        //Update the current selected piece
        LastPieceSelected = CurrentPieceSelected;
        CurrentPieceSelected = p;
        //Move the selector to the current piece selected
        MoveSelector(p.GetX(), p.GetY());
        //Delete all the Allowed move tiles generate by the last selected piece
        if (LastPieceSelected != null) LastPieceSelected.DeleteAllowedMoveTiles();
    }

    //Move the selector to a given location on the board
    public void MoveSelector(int x, int y)
    {
        if (x == -1 && y == -1) Selector.transform.position = new Vector3(0, 0, -1);
        else Selector.transform.position = GetCoords(x, y);
    }

    //From int X int Y, return the world coordinate (layer is for the Z axes, lower numbers are shown in front)
    public Vector3 GetCoords(int x, int y, int layer = -1)
    {
        Vector3 res = new Vector3();
        res.x = (x * TILE_SIZE - TILE_SIZE * 3.5f);
        res.y = (y * TILE_SIZE - TILE_SIZE * 3.5f);
        res.z = layer;
        return res;
    }

    //Function that update the pieces position matrix
    //And the player's pieces owned list
    //When a moves is performed (and eventually a take)
    public void UpdatePiecesPosition(int PrevX, int PrevY, int NextX, int NextY)
    {
        //If in the next position there's a piece, it means it's not mine
        //because this check is made when I generate the allowed move tiles
        if (PiecesPosition[NextX, NextY] != null)
        {
            //Update the players owned chess pieces list
            if (CurrentPlayer == "WHITE") BLACK.PieceTaken(PiecesPosition[NextX, NextY]);
            if (CurrentPlayer == "BLACK") WHITE.PieceTaken(PiecesPosition[NextX, NextY]);
            //Move out of the board (-1 means out of the board)
            PiecesPosition[NextX, NextY].SetXY(-1, -1);
            //If it's the king, the match is over
            if (PiecesPosition[NextX, NextY].GetComponent<King>() != null)
            {
                //Activate the victory icon
                if(PiecesPosition[NextX,NextY].GetMyPlayer() == "WHITE") BlackWinsIcon.SetActive(true);
                if(PiecesPosition[NextX, NextY].GetMyPlayer() == "BLACK") WhiteWinsIcon.SetActive(true);
                //Interupt the turns roll by not allowing to select any piece
                CurrentPlayer = "";
                //Unsubscribe from the event
                ChessPiece.PieceMoved -= EndTurn;
                Destroy(PiecesPosition[NextX, NextY].gameObject);
                return;
            }
            Destroy(PiecesPosition[NextX, NextY].gameObject);
        }
        //Update the matrix with this last move
        PiecesPosition[NextX, NextY] = PiecesPosition[PrevX, PrevY];
        PiecesPosition[NextX, NextY].SetXY(NextX, NextY);
        PiecesPosition[PrevX, PrevY] = null;

    }


    public void MoveTurnIndicator(string position)
    {
        if(position == "TOP")
        {
            TurnIndicator.transform.position = new Vector3(0f, 3f, 0);
            TurnIndicator.transform.rotation = Quaternion.Euler(0f, 0f, 180f);

        }
        if(position == "DOWN")
        {
            TurnIndicator.transform.position = new Vector3(0f, -3f, 0);
            TurnIndicator.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    //End Match function
    public void EndMatch()
    {
        //Delete ALL AllowedMove tiles
        if(CurrentPieceSelected != null) CurrentPieceSelected.DeleteAllowedMoveTiles();
        //Delete ALL the pieces
        if(PiecesPosition != null) foreach (ChessPiece p in PiecesPosition) if (p != null) Destroy(p.gameObject);
        //Delete all the reference
        PiecesPosition = null;
        CurrentPieceSelected = null;
        LastPieceSelected = null;
        //Reset the icons
        MoveSelector(-1, -1);
        MoveTurnIndicator("DOWN");
        //Unsubscribe from the event
        ChessPiece.PieceMoved -= EndTurn;
        //Deactivate icons
        WhiteWinsIcon.SetActive(false);
        BlackWinsIcon.SetActive(false);
        Selector.SetActive(false);
        TurnIndicator.SetActive(false);
        //Raise the event
        GameOver?.Invoke();
    }

    //Check whether position is inside the board
    public bool InsideBoard(int x, int y)
    {
        if (x < 0 || x >= ROW_SIZE) return false;
        if (y < 0 || y >= ROW_SIZE) return false;
        return true;
    }

    //Getter
    public ChessPiece[,] GetPiecesPosition() => PiecesPosition;
    public GameObject GetMoveTilePrefab() => MoveTilePrefab;
    public ChessPiece GetCurrentPiece() => CurrentPieceSelected;
    public int GetRowSize() => ROW_SIZE;

    //Validate the inspector
    //Front and Back rows MUST have *ROW_SIZE* elements
    void OnValidate()
    {
        if (FrontRow_BLACK.Length != ROW_SIZE)
        {
            Debug.LogWarning("Row size is: " + ROW_SIZE);
            Array.Resize(ref FrontRow_BLACK, ROW_SIZE);
        }
        if (BackRow_BLACK.Length != ROW_SIZE)
        {
            Debug.LogWarning("Row size is: " + ROW_SIZE);
            Array.Resize(ref BackRow_BLACK, ROW_SIZE);
        }
        if (FrontRow_WHITE.Length != ROW_SIZE)
        {
            Debug.LogWarning("Row size is: " + ROW_SIZE);
            Array.Resize(ref FrontRow_WHITE, ROW_SIZE);
        }
        if (BackRow_WHITE.Length != ROW_SIZE)
        {
            Debug.LogWarning("Row size is: " + ROW_SIZE);
            Array.Resize(ref BackRow_WHITE, ROW_SIZE);
        }
    }

    private void OnDestroy()
    {
        ChessPiece.PieceMoved -= EndTurn; //Unsubscribe from the event
    }

}
