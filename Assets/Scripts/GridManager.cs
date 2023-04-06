using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
 
public class GridManager : MonoBehaviour {
    [SerializeField] private int width, height; // visible in unity window even when private
 
    [SerializeField] private Tile tilePrefab;
 
    [SerializeField] private Transform myCamera;

    private Dictionary<Vector2, ChessPiece> _tiles;

    [SerializeField] private Pawn pawnGameObject;
    
    [SerializeField] private Rook rookGameObject;
    
    [SerializeField] private Bishop bishopGameObject;
    
    [SerializeField] private Knight knightGameObject;
    
    [SerializeField] private Queen queenGameObject;
    
    [SerializeField] private King kingGameObject;

    public List<ChessPiece> chessPieces;

    void Start() {
        GenerateGrid();
    }
 
    void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, ChessPiece>();
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
 
                var isOffset = (x + y) % 2 == 0;
                spawnedTile.Init(isOffset);

                _tiles[new Vector2(x, y)] = GeneratePiece(x, y);;
                Console.Out.Write(_tiles[new Vector2(x,y)]);
            }
        }
 
        myCamera.transform.position = new Vector3((float)width/2 -0.5f, (float)height / 2 - 0.5f,-10);
    }
    ChessPiece GeneratePiece(int x, int y)
    {
        if (y == 1)
        {
            var pawn = Instantiate(pawnGameObject, Vector3.zero, Quaternion.identity);
            pawn.transform.position = new Vector3(x, y, 0);
            pawn.name = $"WhitePawn{x}";
            pawn.ChooseColor(true);
            chessPieces.Add(pawn);
            return pawn;
        }
        else if (y == 6)
        {
            var pawn = Instantiate(pawnGameObject, Vector3.zero, Quaternion.identity);
            pawn.transform.position = new Vector3(x, y, 0);
            pawn.name = $"BlackPawn{x}";
            pawn.ChooseColor(false);
            chessPieces.Add(pawn);
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
            
            chessPieces.Add(rook);
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
            
            chessPieces.Add(knight);
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
            
            chessPieces.Add(bishop);
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
            
            chessPieces.Add(queen);
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

            chessPieces.Add(king);
            return king;
        }

        return null;
    }
    
    
    public ChessPiece GetTileAtPosition(Vector2 pos)
    {
        if(_tiles.TryGetValue(pos, out var tile)) return tile;
        
        return null;
    }
    
}