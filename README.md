# ChessTest
This is a Unity 2019.4 project. Build from the editor and have fun :)

## How to add new piece to your board!
 - You can add new pieces by creating a new class derived from ChessPiece (see Examples of standard chess pieces in /Scripts/Pieces).
This new class has to implement the abstract method List<Vector2Int> GenerateAllowedMovePosition() that returns a List of allowed position where the piece can move from where it is.
 - Then, create the prefab (one for BLACK and one for WHITE) (see Examples in /Prefab)
 - Then, place the prefabs in the "FrontRow_BLACK", "FrontRow_WHITE" (or "BackRow_BLACK", "BackRow_WHITE") arrays in the MatchManager's inspector.
##
