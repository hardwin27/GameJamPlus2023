using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionController : MonoBehaviour
{
    [SerializeField] private GameObject _selectedGameObject;

    public void SelectObejct(GameObject selectedObject)
    {
        _selectedGameObject = selectedObject;
    }
}
