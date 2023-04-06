using Unity.VisualScripting;
using UnityEngine;

public class Rook : ChessPiece
{
    public Sprite whiteRook, blackRook;
    void Start()
    {
        
    }

    public override void ChooseColor(bool IsWhite)
    {
        this.isWhite = IsWhite;
        if (IsWhite) 
        {
            PieceRenderer.sprite = whiteRook;
            Debug.Log("White rook sprite set");
        }
        else 
        {
            PieceRenderer.sprite = blackRook;
            Debug.Log("Black rook sprite set");
        }
    }
}