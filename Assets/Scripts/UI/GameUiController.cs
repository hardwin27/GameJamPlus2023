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

    public delegate void GameUiControllerUnitDataEvent(UnitData unitData);
    public event GameUiControllerUnitDataEvent UnitChoiceSelected;

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
            GameObject unitChoiceUiObject = Instantiate(_unitChoiceUiPrefab, _unitChoicePanel.transform);

            if (unitChoiceUiObject.TryGetComponent(out UnitChoiceUi unitChoiceUi))
            {
                unitChoiceUi.SetUnit(unitData);
                unitChoiceUi.BtnSelectUnit.onClick.AddListener(() => SelectUnitChoice(unitData));
            }
        }
    }

    private void SelectUnitChoice(UnitData unit)
    {
        UnitChoiceSelected?.Invoke(unit);
    }
}
