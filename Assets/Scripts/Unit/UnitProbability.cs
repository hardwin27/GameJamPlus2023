using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProbability
{
    private UnitData _unitData;
    private float _chance;

    public UnitProbability(UnitData unitData, float chance)
    {
        _unitData = unitData;
        _chance = chance;
    }

    public UnitData UnitData{ get => _unitData; }
    public float Chance { get => _chance; }
}
