using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class UnitTileDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _tileLayerMask;
    [SerializeField] [ReadOnly] private Vector2Int _currentCoordinate;

    public Vector2Int CurrentCoordinate { get => _currentCoordinate; }

    private void OnTriggerEnter(Collider other)
    {
        
        if ((_tileLayerMask & (1 << other.gameObject.layer)) != 0)
        {
            if (other.gameObject.TryGetComponent(out Tile tile))
            {
                _currentCoordinate = tile.TileCoordinate;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
