using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _gridTransform;

    [SerializeField] private List<List<Tile>> _tiles = new List<List<Tile>>();
    [SerializeField] [ReadOnly] private List<Tile> _highlightedTiles = new List<Tile>();
    [SerializeField] [ReadOnly] private List<Vector2Int> _highlightedCoordinate = new List<Vector2Int>();

    public List<List<Tile>> Tiles { get => _tiles; }
    public List<Tile> HighlightedTiles { get => _highlightedTiles; }

    [SerializeField] private Vector2Int _mapSize;
    [SerializeField] private Vector2 _tileDistance;

    [SerializeField] private Vector2Int _disableIndex = Vector2Int.zero;

    public void Start()
    {
        GenerateTiles();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _tiles[_disableIndex.x][_disableIndex.y].gameObject.SetActive(!_tiles[_disableIndex.x][_disableIndex.y].gameObject.activeSelf);
        }
    }

    private void GenerateTiles()
    {
        for (int x= 0; x < _mapSize.x; x++)
        {
            List<Tile> tileOnX = new List<Tile>();
            for (int y = 0; y < _mapSize.y; y++)
            {
                GameObject tileObject = Instantiate(_tilePrefab, _gridTransform);
                tileObject.transform.position = new Vector3(x * _tileDistance.x, 0f, y * _tileDistance.y);

                if (tileObject.TryGetComponent(out Tile tile))
                {
                    tile.Initiate(new Vector2Int(x, y));
                    tileOnX.Add(tile);
                }
            }

            _tiles.Add(tileOnX);
        }
    }

    public void HighlightTiles(List<Vector2Int> highlightedCoordinates)
    {
        _highlightedCoordinate = highlightedCoordinates;
        ClearHighlighted();
        foreach(Vector2Int coordinate in highlightedCoordinates)
        {
            _tiles[coordinate.x][coordinate.y].ToggleHighlight(true);
            _highlightedTiles.Add(_tiles[coordinate.x][coordinate.y]);
        }
    }

    public void ClearHighlighted()
    {
        foreach(Tile highlightedTile in _highlightedTiles)
        {
            highlightedTile.ToggleHighlight(false);
        }

        _highlightedTiles.Clear();
    }
}
