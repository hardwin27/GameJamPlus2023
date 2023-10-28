using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionController : MonoBehaviour
{
    [SerializeField] private bool _isActive = false;
    
    [SerializeField] private FactionSide _factionSide;
    
    [SerializeField] private List<UnitComponent> _factionUnits = new List<UnitComponent>();

    [SerializeField] [ReadOnly] private GameObject _selectedGameObject;
    [SerializeField] [ReadOnly] private UnitComponent _selectedUnit;
    [SerializeField] [ReadOnly] private Tile _selectedTile;

    [SerializeField] private GridController _gridController;

    public FactionSide Side { get => _factionSide; }
    public List<UnitComponent> FactionUnits = new List<UnitComponent>();

    public UnitComponent SelectedUnit { get => _selectedUnit; }

    public bool IsActive { set => _isActive = value; get => _isActive; }


    private const string UNIT_TAG = "Unit";
    private const string TILE_TAG = "Tile";

    private void Awake()
    {
        _isActive = false;
    }

    private void Start()
    {
        InitializeUnits();
    }

    private void InitializeUnits()
    {
        foreach(UnitComponent unitComponent in _factionUnits)
        {
            unitComponent.UnityEntity.SetFaction(Side);
        }
    }

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
                        UnitSelectedHandler(unitComponent);
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

    private void UnitSelectedHandler(UnitComponent unitComponent)
    {
        if (unitComponent.UnityEntity.Side == Side)
        {
            _selectedUnit = unitComponent;
            HighlightsUnitPattern();
        }
        else
        {
            if (_selectedUnit != null)
            {
                Vector2Int coordinate = unitComponent.UnitTileDetector.CurrentCoordinate;

                if (_gridController.Tiles[coordinate.x][coordinate.y].IsHighlighted)
                {
                    CharacterActionAttack(unitComponent);
                }
            }
        }
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
                CharacterActionMove();
            }
        }
    }

    private void HighlightsUnitPattern()
    {
        List<Vector2Int> highlightedCoordinates = _selectedUnit.UnitActionPattern.TargetPattern.GenerateTargetableTile(
            _selectedUnit.UnitTileDetector.CurrentCoordinate,
            _gridController.Tiles);
        _gridController.HighlightTiles(highlightedCoordinates);
    }

    //Temporary
    private void CharacterActionMove()
    {
        _selectedUnit.UnitMovement.MoveToPos(_selectedTile.transform.position);
        ResetState();
    }

    private void CharacterActionAttack(UnitComponent targetedUnit)
    {
        _selectedUnit.UnitCombat.Attack(targetedUnit.UnityEntity);
        ResetState();
    }

    public void ResetState()
    {
        _gridController.ClearHighlighted();
        _selectedGameObject = null;
        _selectedUnit = null;
        _selectedTile = null;
    }
}
