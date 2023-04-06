using Unity.VisualScripting;
using UnityEngine;

public class King : ChessPiece
{
    public Sprite whiteKing, blackKing;
    void Start()
    {
        
    }

    public override void ChooseColor(bool IsWhite)
    {
        this.isWhite = IsWhite;
        if (IsWhite) 
        {
            PieceRenderer.sprite = whiteKing;
            Debug.Log("White king sprite set");
        }
        else 
        {
            PieceRenderer.sprite = blackKing;
            Debug.Log("Black king sprite set");
        }
    }
}