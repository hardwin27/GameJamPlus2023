using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Opening,
    Starting,
    Battling,
    Ending,
    Closing,
}

public class GameController : MonoBehaviour
{
    [SerializeField] [ReadOnly] private GameState _currentState;

    [SerializeField] private TurnController _turnController;
    [SerializeField] private FactionController _winnerFaction;
    [SerializeField] private FactionController _playerfaction;

    [SerializeField] private UnitDatabase _unitDatabase;
    [SerializeField] private LevelController _levelController;
    [SerializeField] private GameUiController _gameUiController;
    [SerializeField] private GridController _gridController;
    [SerializeField] private Transform _unitParents;


    private void Start()
    {
        SetState(GameState.Opening);
    }

    private void OnEnable()
    {
        if (_turnController != null)
        {
            _turnController.FactionWon += FactionWonHandler;
        }
    }

    private void OnDisable()
    {
        if (_turnController != null)
        {
            _turnController.FactionWon -= FactionWonHandler;
        }
    }

    private void SetState(GameState gameState)
    {
        _currentState = gameState;

        switch(_currentState)
        {
            case GameState.Opening:
                OpeningStateHandler();
                break;
            case GameState.Starting:
                StartingStateHandler();
                break;
            case GameState.Battling:
                BattlingStateHandler();
                break;
            case GameState.Ending:
                EndingStateHandler();
                break;
            case GameState.Closing:
                ClosingStateHandler();
                break;
        }
    }

    private void OpeningStateHandler()
    {
        _gameUiController.ShowUnitChoices(GenerateUnitChoices());
    }

    private void StartingStateHandler()
    {

    }

    private void BattlingStateHandler()
    {

    }

    private void EndingStateHandler()
    {

    }

    private void ClosingStateHandler()
    {

    }

    private void FactionWonHandler(FactionController faction)
    {
        _winnerFaction = faction;
        SetState(GameState.Ending);
    }

    private List<UnitData> GenerateUnitChoices()
    {
        List<UnitData> unitChoices = new List<UnitData>();

        int level = _levelController.CurrentLevel;

        float totalChance = 0f;

        List<UnitProbability> unitProbabilities = new List<UnitProbability>();
        foreach(UnitData unitData in _unitDatabase.UnitDatas)
        {
            UnitProbability unitProbability = new UnitProbability(
                    unitData,
                    unitData.AppearanceChance + (unitData.AppearanceChanceIncrease * level)
                );
            totalChance += unitProbability.Chance;
            unitProbabilities.Add(unitProbability);
        }

        for(int tryCount = 0; tryCount < 3; tryCount++)
        {

            float randChance = Random.Range(0f, totalChance);
            float chance = 0f;
            foreach (UnitProbability unitProbability in unitProbabilities)
            {
                chance += unitProbability.Chance;
                if (randChance <= chance)
                {
                    unitChoices.Add(unitProbability.UnitData);
                }
            }
        }

        return unitChoices;
    }
}
