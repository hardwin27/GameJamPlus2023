using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    [SerializeField] private Vector2 _tileCoordinate;
    
    public Vector2 TileCoordinate { set => _tileCoordinate = value; get => _tileCoordinate; }
}
