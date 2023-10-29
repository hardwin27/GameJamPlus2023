using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitDatabase : MonoBehaviour
{
    [SerializeField] private List<UnitData> _unitDatas;

    public List<UnitData> UnitDatas { get => _unitDatas; }
}
