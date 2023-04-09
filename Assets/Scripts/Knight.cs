using UnityEngine;

public class Knight : ChessPiece
{
    protected override void AssignMoves(Vector2 position)
    {
        moves.Clear();

        int[,] knightMoves = new int[,] {{2, 1}, {1, 2}, {-1, 2}, {-2, 1}, {-2, -1}, {-1, -2}, {1, -2}, {2, -1}};

        for (int i = 0; i < knightMoves.GetLength(0); i++){
            int x = (int) position.x + knightMoves[i, 0];
            int y = (int) position.y + knightMoves[i, 1];

            if (x >= 0 && x < 8 && y >= 0 && y < 8)
            {
                ChessPiece temp = GridManager.instance.GetChessPieceAtPosition(new Vector2(x, y));
                if (temp == null || temp.isWhite != isWhite)
                {
                    moves.Add(new Vector2(x, y));
                }
            }
        }
    }
}