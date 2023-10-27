using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _gridTransform;

    [SerializeField] private List<GridTile> _tiles;
    [SerializeField] private Vector2Int _mapSize;
    [SerializeField] private Vector2 _tileDistance;

    public void Start()
    {
        GenerateTiles();
    }

    private void GenerateTiles()
    {
        for (int y = 0; y < _mapSize.y; y++)
        {
            for (int x = 0; x < _mapSize.x; x++)
            {
                GameObject tileObject = Instantiate(_tilePrefab, _gridTransform);
                tileObject.transform.position = new Vector3(x * _tileDistance.x, 0f, y * _tileDistance.y);

                if (tileObject.TryGetComponent(out GridTile gridTile))
                {
                    gridTile.Initiate(new Vector2Int(x, y));
                    _tiles.Add(gridTile);
                }
            }
        }
    }
}
