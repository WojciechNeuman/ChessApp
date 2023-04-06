using Unity.VisualScripting;
using UnityEngine;

public class Queen : ChessPiece
{
    public Sprite whiteQueen, blackQueen;
    void Start()
    {
        
    }

    public override void ChooseColor(bool IsWhite)
    {
        this.isWhite = IsWhite;
        if (IsWhite) 
        {
            PieceRenderer.sprite = whiteQueen;
            Debug.Log("White queen sprite set");
        }
        else 
        {
            PieceRenderer.sprite = blackQueen;
            Debug.Log("Black queen sprite set");
        }
    }
}