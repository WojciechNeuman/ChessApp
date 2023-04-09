using System.Collections.Generic;
using UnityEngine;
 
public class GridManager : MonoBehaviour {
    public static GridManager instance;
    
    [SerializeField] private int width, height; // visible in unity window even when private
 
    [SerializeField] private Tile tilePrefab;
 
    [SerializeField] private Transform myCamera;

    private static Dictionary<Vector2, ChessPiece> _chessPiecesDictionary;

    [SerializeField] private Pawn pawnGameObject;
    
    [SerializeField] private Rook rookGameObject;
    
    [SerializeField] private Bishop bishopGameObject;
    
    [SerializeField] private Knight knightGameObject;
    
    [SerializeField] private Queen queenGameObject;
    
    [SerializeField] private King kingGameObject;

    private static Tile[,] _tiles;
    private static List<ChessPiece> _chessPieces;

    private void Awake()
    {
        instance = this;
    }
    void Start() {
        _chessPieces = new List<ChessPiece>();
        _chessPiecesDictionary = new Dictionary<Vector2, ChessPiece>();
        _tiles = new Tile[8, 8];
        GenerateGrid();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main == null) return;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int xMouse = Mathf.RoundToInt(mousePosition.x);
            int yMouse = Mathf.RoundToInt(mousePosition.y);

            if(GetChessPieceAtPosition(new Vector2(xMouse, yMouse)) != null)
            {
                GetChessPieceAtPosition(new Vector2(xMouse, yMouse)).SelectPiece(xMouse, yMouse);
            } 
        }
    }
 
    private void GenerateGrid()
    {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++)
            {
                _tiles[x, y] = GenerateTile(x, y); // Add tiles that create a board

                _chessPiecesDictionary[new Vector2(x, y)] = GeneratePiece(x, y); // Add piece on the board
            }
        }
 
        myCamera.transform.position = new Vector3((float)width/2 -0.5f, (float)height / 2 - 0.5f,-10);
    }

    private Tile GenerateTile(int x, int y)
    {
        var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
        spawnedTile.name = $"Tile {x} {y}";
 
        var isOffset = (x + y) % 2 == 0;
        spawnedTile.Init(isOffset);

        return spawnedTile;
    }
    private ChessPiece GeneratePiece(int x, int y)
    {
        if (y == 1)
        {
            var pawn = Instantiate(pawnGameObject, Vector3.zero, Quaternion.identity);
            pawn.transform.position = new Vector3(x, y, 0);
            pawn.name = $"WhitePawn{x}";
            pawn.X = x;
            pawn.Y = y;
            pawn.ChooseColor(true);
            _chessPieces.Add(pawn);
            return pawn;
        }
        else if (y == 6)
        {
            var pawn = Instantiate(pawnGameObject, Vector3.zero, Quaternion.identity);
            pawn.transform.position = new Vector3(x, y, 0);
            pawn.name = $"BlackPawn{x}";
            pawn.X = x;
            pawn.Y = y;
            pawn.ChooseColor(false);
            _chessPieces.Add(pawn);
            return pawn;
        }
        else if (((x == 0) || (x == 7)) && ((y == 0) || (y == 7)))
        {
            var rook = Instantiate(rookGameObject, Vector3.zero, Quaternion.identity);
            rook.transform.position = new Vector3(x, y, 0);
            if (y == 0)
            {
                rook.name = $"WhiteRook{x}";
                rook.ChooseColor(true);
            }
            else
            {
                rook.name = $"BlackRook{x}";
                rook.ChooseColor(false);
            }
            rook.X = x;
            rook.Y = y;
            _chessPieces.Add(rook);
            return rook;
        }
        else if (((x == 1) || (x == 6)) && ((y == 0) || (y == 7)))
        {
            var knight = Instantiate(knightGameObject, Vector3.zero, Quaternion.identity);
            knight.transform.position = new Vector3(x, y, 0);
            if (y == 0)
            {
                knight.name = $"WhiteKnight{x}";
                knight.ChooseColor(true);
            }
            else
            {
                knight.name = $"BlackKnight{x}";
                knight.ChooseColor(false);
            }
            knight.X = x;
            knight.Y = y;
            _chessPieces.Add(knight);
            return knight;
        }
        else if (((x == 2) || (x == 5)) && ((y == 0) || (y == 7)))
        {
            var bishop = Instantiate(bishopGameObject, Vector3.zero, Quaternion.identity);
            bishop.transform.position = new Vector3(x, y, 0);
            if (y == 0)
            {
                bishop.name = $"WhiteBishop{x}";
                bishop.ChooseColor(true);
            }
            else
            {
                bishop.name = $"BlackBishop{x}";
                bishop.ChooseColor(false);
            }

            bishop.X = x;
            bishop.Y = y;
            _chessPieces.Add(bishop);
            return bishop;
        }
        else if ((x == 3) && ((y == 0) || (y == 7)))
        {
            var queen = Instantiate(queenGameObject, Vector3.zero, Quaternion.identity);
            queen.transform.position = new Vector3(x, y, 0);
            if (y == 0)
            {
                queen.name = $"WhiteQueen{x}";
                queen.ChooseColor(true);
            }
            else
            {
                queen.name = $"BlackQueen{x}";
                queen.ChooseColor(false);
            }

            queen.X = x;
            queen.Y = y;
            _chessPieces.Add(queen);
            return queen;
        }
        else if ((x == 4) && ((y == 0) || (y == 7)))
        {
            var king = Instantiate(kingGameObject, Vector3.zero, Quaternion.identity);
            king.transform.position = new Vector3(x, y, 0);
            if (y == 0)
            {
                king.name = $"WhiteKing{x}";
                king.ChooseColor(true);
            }
            else
            {
                king.name = $"BlackKing{x}";
                king.ChooseColor(false);
            }

            king.X = x;
            king.Y = y;
            _chessPieces.Add(king);
            return king;
        }
        else return null;
    }
    public void RemoveCapturedPiece(Vector2 position, ChessPiece movedPiece)
    {
        // update chesspieces dictionary with a new position of a piece
        // remove piece that was on a square that moved piece moved to from dict, list and game
        if (_chessPiecesDictionary[position] != null)
        {
            Debug.Log($"WHY {name}");
            ChessPiece pieceToRemove = _chessPiecesDictionary[position];
            _chessPiecesDictionary.Remove(position);
            _chessPieces.Remove(pieceToRemove);
            Destroy(pieceToRemove.gameObject);
        }
        _chessPiecesDictionary[new Vector2(movedPiece.X, movedPiece.Y)] = movedPiece;
        Debug.Log($"dictionary Count {_chessPiecesDictionary.Count}");
        Debug.Log($" chessPieces Count{_chessPieces.Count}");
    }
    public void ChessPieceAtPositionToNull(Vector2 pos)
    {
        _chessPiecesDictionary[pos] = null;
        Debug.Log($"Chess piece from {pos.x} {pos.y} removed");
    }
    public ChessPiece GetChessPieceAtPosition(Vector2 pos)
    {
        if (_chessPiecesDictionary.TryGetValue(pos, out var chessPiece)) return chessPiece;
        return null;
    }

    public void MarkTiles(List<Vector2> tilesToMark)
    {
        foreach (Vector2 tileToMark in tilesToMark)
        {
            _tiles[Mathf.RoundToInt(tileToMark.x), Mathf.RoundToInt(tileToMark.y)].Mark();
        }
    }
    public void UnmarkTiles(List<Vector2> tilesToUnmark)
    {
        foreach (Vector2 tileToMark in tilesToUnmark)
        {
            _tiles[Mathf.RoundToInt(tileToMark.x), Mathf.RoundToInt(tileToMark.y)].Unmark();
        }
    }

    public void Highlight(int x, int y)
    {
        _tiles[x, y].Highlight();
    }
    public void Unhighlight(int x, int y)
    {
        _tiles[x, y].Unhighlight();
    }
    
}