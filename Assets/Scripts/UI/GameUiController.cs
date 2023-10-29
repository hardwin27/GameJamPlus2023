using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUiController : MonoBehaviour
{
    [SerializeField] private GameObject _newUnitPanel;
    [SerializeField] private GameObject _unitChoicePanel;
    [SerializeField] private GameObject _unitChoiceUiPrefab;
    [SerializeField] private GameObject _inBattlePanel;
    [SerializeField] private GameObject _gameOverPanel;

    private void Awake()
    {
        _newUnitPanel.SetActive(false);
        _inBattlePanel.SetActive(false);
        _gameOverPanel.SetActive(false);
    }

    public void ShowUnitChoices(List<UnitData> unitChoices)
    {
        _newUnitPanel.SetActive(true);
        _inBattlePanel.SetActive(false);
        _gameOverPanel.SetActive(false);

        foreach (Transform unitCoiceTransform in _unitChoicePanel.transform)
        {
            Destroy(unitCoiceTransform);
        }

        foreach (UnitData unitData in unitChoices)
        {

        }
    }
}
