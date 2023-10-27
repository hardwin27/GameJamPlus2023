using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    [SerializeField] private Vector2Int _tileCoordinate;
    
    public Vector2Int TileCoordinate { get => _tileCoordinate; }

    public void Initiate (Vector2Int tileCoordinate)
    {
        _tileCoordinate = tileCoordinate;
    }
 }
