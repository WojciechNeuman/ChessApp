using UnityEngine;

public class Bishop : ChessPiece
{
    protected override void AssignMoves(Vector2 position)
    {
        moves.Clear();

        int[,] directions = new int[,] { { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 } };

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            for (int j = 1; j < 8; j++)
            {
                int x = (int)position.x + j * directions[i, 0];
                int y = (int)position.y + j * directions[i, 1];

                if (x >= 0 && x < 8 && y >= 0 && y < 8)
                {
                    ChessPiece temp = GridManager.instance.GetChessPieceAtPosition(new Vector2(x, y));
                    if (temp == null)
                    {
                        moves.Add(new Vector2(x, y));
                    }
                    else
                    {
                        if (temp.isWhite != isWhite)
                        {
                            moves.Add(new Vector2(x, y));
                        }
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }

}