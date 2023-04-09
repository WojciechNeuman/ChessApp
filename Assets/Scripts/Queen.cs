using UnityEngine;

public class Queen : ChessPiece
{
    protected override void AssignMoves(Vector2 position)
    {
        moves.Clear();

        // Bishop-like moves
        for (int x = (int)position.x + 1, y = (int)position.y + 1; x < 8 && y < 8; x++, y++)
        {
            if (!AddMoveIfValid(new Vector2(x, y)))
                break;
        }

        for (int x = (int)position.x - 1, y = (int)position.y + 1; x >= 0 && y < 8; x--, y++)
        {
            if (!AddMoveIfValid(new Vector2(x, y)))
                break;
        }

        for (int x = (int)position.x - 1, y = (int)position.y - 1; x >= 0 && y >= 0; x--, y--)
        {
            if (!AddMoveIfValid(new Vector2(x, y)))
                break;
        }

        for (int x = (int)position.x + 1, y = (int)position.y - 1; x < 8 && y >= 0; x++, y--)
        {
            if (!AddMoveIfValid(new Vector2(x, y)))
                break;
        }

        // Rook-like moves
        for (int x = (int)position.x + 1; x < 8; x++)
        {
            if (!AddMoveIfValid(new Vector2(x, position.y)))
                break;
        }

        for (int x = (int)position.x - 1; x >= 0; x--)
        {
            if (!AddMoveIfValid(new Vector2(x, position.y)))
                break;
        }

        for (int y = (int)position.y + 1; y < 8; y++)
        {
            if (!AddMoveIfValid(new Vector2(position.x, y)))
                break;
        }

        for (int y = (int)position.y - 1; y >= 0; y--)
        {
            if (!AddMoveIfValid(new Vector2(position.x, y)))
                break;
        }
    }

}