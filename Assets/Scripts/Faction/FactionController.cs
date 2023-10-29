using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionController : MonoBehaviour
{
    [SerializeField] private string _factionName;

    [SerializeField] private bool _isActive = false;
    
    [SerializeField] private FactionSide _factionSide;
    
    [SerializeField] private List<UnitController> _factionUnits = new List<UnitController>();

    [SerializeField] [ReadOnly] private GameObject _selectedGameObject;
    [SerializeField] [ReadOnly] private UnitController _selectedUnit;
    [SerializeField] [ReadOnly] private Tile _selectedTile;

    [SerializeField] private GridController _gridController;


    public string FactionName { get => _factionName; }
    public FactionSide Side { get => _factionSide; }

    public List<UnitController> FactionUnits { get => _factionUnits; }

    public UnitController SelectedUnit { get => _selectedUnit; }

    public bool IsActive { set => _isActive = value; get => _isActive; }

    public delegate void FactionControllerEvent();
    public event FactionControllerEvent FacitonActionEnded;

    public delegate void FactionControllerSelfEvent(FactionController factionController);
    public event FactionControllerSelfEvent FactionWipedOut;

    public delegate void FactionControllerGameObjectEvent(GameObject param);
    public event FactionControllerGameObjectEvent SelectedObjectChanged;

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
        foreach(UnitController unitController in _factionUnits)
        {
            unitController.UnitEntity.SetFaction(Side);
            unitController.UnitEntity.Died += OnUnitDiedHandler;
        }
    }

    public void AddUnit(UnitController unit)
    {
        _factionUnits.Add(unit);
    }

    private void SetSelectedObject(GameObject selectedGameObject)
    {
        _selectedGameObject = selectedGameObject;
        SelectedObjectChanged?.Invoke(_selectedGameObject);
    }

    private void OnUnitDiedHandler(GameObject diedObject)
    {
        if (diedObject.TryGetComponent(out UnitController unitController))
        {
            _factionUnits.Remove(unitController);

            if (_factionUnits.Count <= 0)
            {
                FactionWipedOut?.Invoke(this);
            }
        }
    }

    public void SelectObejct(GameObject newSelectedObject)
    {
        SetSelectedObject(newSelectedObject);
        switch (_selectedGameObject.tag)
        {
            case UNIT_TAG:
                if (_selectedGameObject.TryGetComponent(out UnitController unitController))
                {
                    UnitSelectedHandler(unitController);
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

    private void UnitSelectedHandler(UnitController unitController)
    {
        if (unitController.UnitEntity.Side == Side)
        {
            _selectedUnit = unitController;
            HighlightsUnitPattern();
        }
        else
        {
            if (_selectedUnit != null)
            {
                Vector2Int coordinate = unitController.UnitTileDetector.CurrentCoordinate;

                if (_gridController.Tiles[coordinate.x][coordinate.y].IsHighlighted)
                {
                    CharacterActionAttack(unitController);
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
                if (_selectedTile.TileObjectDetector.ObjectInTile == null)
                {
                    CharacterActionMove();
                }
                else
                {
                    if (_selectedTile.TileObjectDetector.ObjectInTile.TryGetComponent(out UnitController unitController))
                    {
                        SelectObejct(unitController.gameObject);
                    }
                    else
                    {
                        ResetState();
                    }
                }
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

    //Temporary. Prolly should be handler by each unit (?) idk not sure
    private void CharacterActionMove()
    {
        _selectedUnit.UnitMovement.MoveToPos(_selectedTile.transform.position);
        EndFactionAction();
    }

    private void CharacterActionAttack(UnitController targetedUnit)
    {
        _selectedUnit.UnitCombat.Attack(targetedUnit.UnitEntity);
        EndFactionAction();
    }

    private void ResetState()
    {
        _gridController.ClearHighlighted();
        SetSelectedObject(null);
        _selectedUnit = null;
        _selectedTile = null;
    }

    public void EndFactionAction()
    {
        ResetState();
        _isActive = false;
        FacitonActionEnded?.Invoke();
    }
}
