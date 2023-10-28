using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionController : MonoBehaviour
{
    [SerializeField] [ReadOnly] private GameObject _selectedGameObject;
    [SerializeField] [ReadOnly] private UnitComponent _selectedUnit;
    [SerializeField] [ReadOnly] private Tile _selectedTile;

    [SerializeField] private GridController _gridController;

    private const string UNIT_TAG = "Unit";
    private const string TILE_TAG = "Tile";

    public void SelectObejct(GameObject newSelectedObject)
    {
        if (_selectedGameObject == null)
        {
            _selectedGameObject = newSelectedObject;  
        }
        else
        {
            _selectedGameObject = newSelectedObject;
            switch(_selectedGameObject.tag)
            {
                case UNIT_TAG:
                    if (_selectedGameObject.TryGetComponent(out UnitComponent unitComponent))
                    {
                        _selectedUnit = unitComponent;
                        UnitSelectedHandler();
                    }
                    break;
                case TILE_TAG:
                    if (_selectedGameObject.TryGetComponent(out Tile tile))
                    {
                        _selectedTile = tile;
                        TileSelectedHandler();
                    }
                    break;
            }
        }
    }

    private void UnitSelectedHandler()
    {
        if (_selectedUnit == null)
        {
            return;
        }

        List<Vector2Int> highlightedCoordinates = _selectedUnit.UnitActionPattern.TargetPattern.GenerateTargetableTile(
            _selectedUnit.UnitTileDetector.CurrentCoordinate,
            _gridController.Tiles);
        _gridController.HighlightTiles(highlightedCoordinates);
    }

    private void TileSelectedHandler()
    {
        if (_selectedTile == null)
        {
            return;
        }

        if (_selectedUnit != null)
        {
            if (_selectedTile.IsHighlighted)
            {
                CharacterTakeAction();
            }
        }
    }

    //Temporary
    private void CharacterTakeAction()
    {
        _selectedUnit.UnitMovement.MoveToPos(_selectedTile.transform.position);

        ResetState();
    }

    private void ResetState()
    {
        _gridController.ClearHighlighted();
        _selectedGameObject = null;
        _selectedUnit = null;
        _selectedTile = null;
    }
}
