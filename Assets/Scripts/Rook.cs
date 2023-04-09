using UnityEngine;

public class Rook : ChessPiece
{
    protected override void AssignMoves(Vector2 position)
    {
        moves.Clear();

        // Check moves in all four directions
        for (int i = 0; i < 4; i++)
        {
            int x = (int)position.x;
            int y = (int)position.y;
        
            // Check moves in positive direction
            while (true)
            {
                x += (i == 0) ? 1 : 0; // Check right
                y += (i == 1) ? 1 : 0; // Check up
                x -= (i == 2) ? 1 : 0; // Check left
                y -= (i == 3) ? 1 : 0; // Check down
            
                // Break if we've gone out of bounds
                if (x < 0 || x >= 8 || y < 0 || y >= 8)
                {
                    break;
                }

                ChessPiece temp = GridManager.instance.GetChessPieceAtPosition(new Vector2(x, y));
            
                // If the tile is empty, add the move and keep going
                if (temp == null)
                {
                    moves.Add(new Vector2(x, y));
                }
                // If the tile has an enemy piece, add the move and break
                else if (temp.isWhite != isWhite)
                {
                    moves.Add(new Vector2(x, y));
                    break;
                }
                // If the tile has an ally piece, break
                else
                {
                    break;
                }
            }
        }
    }

}