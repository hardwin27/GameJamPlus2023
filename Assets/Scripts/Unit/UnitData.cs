using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data")]
public class UnitData : ScriptableObject
{
    [SerializeField] private GameObject _unitObject;
    [SerializeField] private float _appearanceChance;
    [SerializeField] private float _appearanceChanceIncrease;

    public GameObject UnitObject { get => _unitObject; }
    public float AppearanceChance { get => _appearanceChance; }
    public float AppearanceChanceIncrease { get => _appearanceChanceIncrease; }
    public UnitController UnitController
    {
        get
        {
            if ( _unitObject.TryGetComponent(out UnitController unitController))
            {
                return unitController;
            }

            return null;
        }
    }
}
