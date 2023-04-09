// using System;
// using System.Collections.Generic;
// using System.Net;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ChessPiece : MonoBehaviour
{
    // static fields
    private static bool _somePieceIsSelected;
    protected static bool whiteToMove = true;
    
    // fields
    public int X { get; set; }
    public int Y { get; set; }
    public bool isWhite = true;
    [SerializeField] protected SpriteRenderer pieceRenderer;
    [SerializeField] private Sprite whitePieceSprite, blackPieceSprite;

    private Vector3 _target;
    protected List<Vector2> moves;
    

    public void ChooseColor(bool chosenColor)
    {
        this.isWhite = chosenColor;
        moves = new List<Vector2>();
        this.AssignMoves(new Vector2(X, Y));
        
        pieceRenderer.sprite = isWhite ? whitePieceSprite : blackPieceSprite;
    }

    protected abstract void AssignMoves(Vector2 position);
    
    protected bool AddMoveIfValid(Vector2 move)
    {
        ChessPiece temp = GridManager.instance.GetChessPieceAtPosition(move);
        if (temp == null || temp.isWhite != isWhite)
        {
            moves.Add(move);
            return temp == null; // return true if the move is valid and empty, false otherwise
        }
        return false;
    }

    public void SelectPiece(int xMouse, int yMouse)
    {
        Debug.Log($"PIECE SELECTION. PIECE: {name}. SQUARE: {X} {Y}");
        if (!_somePieceIsSelected && isWhite == whiteToMove)
        {
            _somePieceIsSelected = true;
            AssignMoves(new Vector2(X, Y));
            
            GridManager.instance.Highlight(X, Y);
            GridManager.instance.MarkTiles(moves);
            
            StartCoroutine(MovePiece());
        }
    }

    private IEnumerator MovePiece()
    {
        Debug.Log($"MOVE PIECE HAS STARTED");

        var clickCount = 0;

        while (clickCount < 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (clickCount == 0)
                {
                    clickCount = 1;
                    yield return new WaitForSeconds(0.2f);
                }
                else if (clickCount == 1)
                {
                    // Second click detected, move the piece to the new location
                    if (Camera.main == null) continue;
                    int xMouse = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
                    int yMouse = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

                    if (!moves.Contains(new Vector2(xMouse, yMouse)))
                    {
                        Debug.Log($"INSIDE the IF of {name}");
                        xMouse = X; // don't change the position
                        yMouse = Y;
                        whiteToMove = !whiteToMove; // change the side to move twice
                    }
                    
                    _target.x = xMouse;
                    _target.y = yMouse;

                    GridManager.instance.ChessPieceAtPositionToNull(new Vector2(X, Y));
                    
                    GridManager.instance.Unhighlight(X, Y);
                    this.X = xMouse;
                    this.Y = yMouse;

                    transform.position = _target;
                    
                    GridManager.instance.RemoveCapturedPiece(new Vector2(xMouse, yMouse), this);
                    
                    GridManager.instance.UnmarkTiles(moves);
                    
                    AssignMoves(new Vector2(X, Y)); // ? assing in SelectPiece for safety
                    
                    _somePieceIsSelected = false;
                    
                    whiteToMove = !whiteToMove;

                    clickCount = 2;
                }
            }
            yield return null;
        }
    }

}
