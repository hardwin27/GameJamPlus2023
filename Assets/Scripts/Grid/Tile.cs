using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] [ReadOnly] private Vector2Int _tileCoordinate;
    [SerializeField] [ReadOnly] private bool _isHighlighted = false;
    [SerializeField] [ReadOnly] private bool _isBlocked = false;

    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _nomalColor;
    [SerializeField] private Color _highlightedColor;

    public bool IsHighlighted { get => _isHighlighted; }
    public bool IsBlocked { get => _isBlocked; }
    
    public Vector2Int TileCoordinate { get => _tileCoordinate; }

    private void Start()
    {
        UpdateTileVisual();
    }

    private void UpdateTileVisual()
    {
        _meshRenderer.material.color = (_isHighlighted) ? _highlightedColor : _nomalColor;
    }

    public void Initiate (Vector2Int tileCoordinate)
    {
        _tileCoordinate = tileCoordinate;
    }

    public void ToggleHighlight (bool isHighlighted)
    {
        _isHighlighted = isHighlighted;
        UpdateTileVisual();
    }
 }
