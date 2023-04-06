using Unity.VisualScripting;
using UnityEngine;

public class Pawn : ChessPiece
{
    public Sprite whitePawn, blackPawn;
    void Start()
    {
        
    }

    public override void ChooseColor(bool IsWhite)
    {
        this.isWhite = IsWhite;
        if (IsWhite) 
        {
            PieceRenderer.sprite = whitePawn;
            Debug.Log("White pawn sprite set");
        }
        else 
        {
            PieceRenderer.sprite = blackPawn;
            Debug.Log("Black pawn sprite set");
        }
    }
}
