using Unity.VisualScripting;
using UnityEngine;

public class Bishop : ChessPiece
{
    public Sprite whiteBishop, blackBishop;
    void Start()
    {
        
    }

    public override void ChooseColor(bool IsWhite)
    {
        this.isWhite = IsWhite;
        if (IsWhite) 
        {
            PieceRenderer.sprite = whiteBishop;
            Debug.Log("White bishop sprite set");
        }
        else 
        {
            PieceRenderer.sprite = blackBishop;
            Debug.Log("Black bishop sprite set");
        }
    }
}