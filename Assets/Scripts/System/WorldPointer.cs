using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPointer : MonoBehaviour
{
    [SerializeField] private LayerMask _characterLayer;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        MouseClickHandler();
    }

    private void MouseClickHandler()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray mouseRay = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit mouseHit;

            if (Physics.Raycast(mouseRay, out mouseHit, Mathf.Infinity, _characterLayer))
            {
                
            }
        }
    }
}
