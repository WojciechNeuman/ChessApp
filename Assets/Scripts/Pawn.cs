using UnityEngine;

public class Pawn : ChessPiece
{
    protected override void AssignMoves(Vector2 position)
    {
        moves.Clear();
        var multiplier = isWhite ? 1 : -1;

        if ((Y < 7 && isWhite) || (Y > 0 && !isWhite))
        {
            if (GridManager.instance.GetChessPieceAtPosition(new Vector2(X + 0, Y + multiplier)) == null)
            {
                moves.Add(new Vector2(X + 0, Y + multiplier)); // move one square 
            }

            if (X > 0 && GridManager.instance.GetChessPieceAtPosition(new Vector2(X - 1, Y + multiplier)) != null)
            {
                if(GridManager.instance.GetChessPieceAtPosition(new Vector2(X - 1, Y + multiplier)).isWhite != isWhite)
                    moves.Add(new Vector2(X - 1, Y + multiplier)); // capture piece to the 'west'
            }
            
            if (X < 7 && GridManager.instance.GetChessPieceAtPosition(new Vector2(X + 1, Y + multiplier)) != null)
            {
                if(GridManager.instance.GetChessPieceAtPosition(new Vector2(X + 1, Y + multiplier)).isWhite != isWhite)
                    moves.Add(new Vector2(X + 1, Y + multiplier)); // capture piece to the 'east'
            }
            if(((Y == 1 && isWhite) || (Y == 6 && !isWhite)) && GridManager.instance.GetChessPieceAtPosition(new Vector2(X + 0, Y + 2 * multiplier)) == null)
            {
                moves.Add(new Vector2(X + 0, Y + 2 * multiplier)); // move two squares
            }
        }
        Debug.Log($"Number of moves {moves.Count} ");
        foreach(var move in moves)
        {
            Debug.Log($"Available {move}");
        }
    }
}
