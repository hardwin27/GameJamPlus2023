using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    [SerializeField] private List<FactionController> _factionControllers = new List<FactionController>();

    [SerializeField] [ReadOnly] private int _currentFactionIndex;

    private void OnEnable()
    {
        foreach (FactionController factionController in _factionControllers)
        {
            factionController.FacitonActionEnded += FactionActionEndedHandler;
        }
    }

    private void OnDisable()
    {
        foreach (FactionController factionController in _factionControllers)
        {
            factionController.FacitonActionEnded -= FactionActionEndedHandler;
        }
    }

    private void Start()
    {
        if (_factionControllers.Count > 0)
        {
            _factionControllers[0].IsActive = true;
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
        if (_currentFactionIndex >= _factionControllers.Count)
        {
            _currentFactionIndex = 0;
        }
        _factionControllers[_currentFactionIndex].IsActive = true;
    }
}
