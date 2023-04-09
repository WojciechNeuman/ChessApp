using UnityEngine;

public class King : ChessPiece
{
    protected override void AssignMoves(Vector2 position)
    {
        moves.Clear();

        int[,] kingMoves = new int[,] {{1, 1}, {1, 0}, {1, -1}, {0, 1}, {0, -1}, {-1, 1}, {-1, 0}, {-1, -1}};

        for (int i = 0; i < kingMoves.GetLength(0); i++)
        {
            int x = (int)position.x + kingMoves[i, 0];
            int y = (int)position.y + kingMoves[i, 1];

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