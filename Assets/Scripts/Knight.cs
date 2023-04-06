using Unity.VisualScripting;
using UnityEngine;

public class Knight : ChessPiece
{
    public Sprite whiteKnight, blackKnight;
    void Start()
    {
        
    }

    public override void ChooseColor(bool IsWhite)
    {
        this.isWhite = IsWhite;
        if (IsWhite) 
        {
            PieceRenderer.sprite = whiteKnight;
            Debug.Log("White knight sprite set");
        }
        else 
        {
            PieceRenderer.sprite = blackKnight;
            Debug.Log("Black knight sprite set");
        }
    }
}