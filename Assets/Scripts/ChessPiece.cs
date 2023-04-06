using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ChessPiece : MonoBehaviour
{
    private int _x;
    private int _y;
    public bool isWhite;
    [SerializeField] protected SpriteRenderer PieceRenderer;

    // public Sprite blackBishop, blackKing, blackKnight, blackPawn, blackQueen, blackRook;

    // public Sprite whiteBishop, whiteKing, whiteKnight, whitePawn, whiteQueen, whiteRook;

    public abstract void ChooseColor(bool isOffset);

}
