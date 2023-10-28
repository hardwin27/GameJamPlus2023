using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionPlayerInput : MonoBehaviour
{
    [SerializeField] private FactionController _playerFaction;

    private Camera _camera;

    [SerializeField] private LayerMask _clickableLayer;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_playerFaction.IsActive)
        {
            MouseClickHandler();
        }
    }

    private void MouseClickHandler()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray mouseRay = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit mouseHit;

            if (Physics.Raycast(mouseRay, out mouseHit, Mathf.Infinity, _clickableLayer))
            {
                _playerFaction.SelectObejct(mouseHit.collider.gameObject);
            }
        }
    }
}
