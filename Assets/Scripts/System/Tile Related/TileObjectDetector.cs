using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class TileObjectDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _tileObjectLayerMask;
    [SerializeField] [ReadOnly] private GameObject _objectInTile;

    public GameObject ObjectInTile { get => _objectInTile; }

    private void OnTriggerEnter(Collider other)
    {
        if ((_tileObjectLayerMask & (1 << other.gameObject.layer)) != 0)
        {
            _objectInTile = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _objectInTile = null;
    }
}
