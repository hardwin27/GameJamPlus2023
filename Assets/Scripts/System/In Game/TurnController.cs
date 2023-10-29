using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    [SerializeField] private List<FactionController> _factions= new List<FactionController>();

    [SerializeField] [ReadOnly] private int _currentFactionIndex;

    public List<FactionController> Factions { get => _factions; }

    public delegate void TurnControllerEvent(FactionController factionController);
    public event TurnControllerEvent FactionWon;

    private void OnEnable()
    {
        foreach (FactionController factionController in _factions)
        {
            factionController.FacitonActionEnded += FactionActionEndedHandler;
            factionController.FactionWipedOut += FactionWipedHandler;
        }
    }

    private void OnDisable()
    {
        foreach (FactionController factionController in _factions)
        {
            factionController.FacitonActionEnded -= FactionActionEndedHandler;
            factionController.FactionWipedOut -= FactionWipedHandler;
        }
    }

    private void Awake()
    {
        ResetFactionTurn();
    }

    private void Start()
    {
        
    }

    public void ResetFactionTurn()
    {
        _currentFactionIndex = 0;
        foreach (FactionController faction in _factions)
        {
            faction.ResetFaction();
        }
    }

    public void StartTurnSystem()
    {
        if (_factions.Count > 0)
        {
            _factions[0].IsActive = true;
            _currentFactionIndex = 0;
        }
    }

    private void FactionActionEndedHandler()
    {
        StartCoroutine(ChangeTurn());
    }

    private IEnumerator ChangeTurn()
    {
        yield return new WaitForSeconds(0.5f);
        _currentFactionIndex++;
        if (_currentFactionIndex >= _factions.Count)
        {
            _currentFactionIndex = 0;
        }
        _factions[_currentFactionIndex].IsActive = true;
    }

    private void FactionWipedHandler(FactionController wipedFaction)
    {
        _factions.Remove(wipedFaction);
        if (_factions.Count == 1)
        {
            FactionWon?.Invoke(_factions[0]);
        }
    }
}
