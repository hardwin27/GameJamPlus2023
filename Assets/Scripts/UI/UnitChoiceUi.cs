using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitChoiceUi : MonoBehaviour
{
    [SerializeField] private Image _imgUnitSprite;
    [SerializeField] private Text _txtUnitName;
    [SerializeField] private Text _txtUnitAttack;
    [SerializeField] private Text _txtUnitHealth;
    [SerializeField] private Button _btnSelectUnit;

    public Button BtnSelectUnit { get => _btnSelectUnit; }

    public void SetUnit(UnitData unitData)
    {
        _imgUnitSprite.sprite = unitData.UnitController.UnitVisual.UnitSprite;
        _txtUnitName.text = unitData.UnitController.UnitEntity.UnitName;
        _txtUnitAttack.text = unitData.UnitController.UnitCombat.Damage.ToString();
        _txtUnitName.text = unitData.UnitController.UnitEntity.MaxHealth.ToString();
    }
}
