# ChessTest
This is a Unity 2019.4 project. Build from the editor and have fun :)

## How to add new piece to your board!
 - You can add new pieces by creating a new class derived from ChessPiece (see Examples of standard chess pieces in /Scripts/Pieces).
This new class has to implement the abstract method List<Vector2Int> GenerateAllowedMovePosition() that returns a List of allowed position where the piece can move from where it is.
 - Then, create the prefab (one for BLACK and one for WHITE) (see Examples in /Prefab)
 - Then, place the prefabs in the "FrontRow_BLACK", "FrontRow_WHITE" (or "BackRow_BLACK", "BackRow_WHITE") arrays in the MatchManager's inspector.
 
## Add new decisions' strategies
 - You can add new decision strategies by creating a new class derived from Strategies (see RandomStrategy example /Scripts/DecisionStrategies).
 This new class has to implement the abstract method Decision MakeDecision(List<ChessPiece> MyPieces) that returns a Decision, a class with a ChessPiece, int X and int Y. These are the future position of ChessPiece.
 - Then, create an Empty. Add component with this new strategy.
 - Then assign this component in the inspector of WHITE_Player and BLACK_Player (Actually, AI can be BLACK only, in future updates you can choose which colour you want to be)
