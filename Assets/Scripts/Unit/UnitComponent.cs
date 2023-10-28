using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    [SerializeField] private UnityEntity _unityEntity;
    [SerializeField] private UnitMovement _unitMovement;
    [SerializeField] private UnitCombat _unitCombat;
    [SerializeField] private UnitActionPattern _unitActionPattern;
    [SerializeField] private UnitTileDetector _unitTileDetector;

    public UnityEntity UnityEntity { get => _unityEntity; }
    public UnitMovement UnitMovement { get => _unitMovement; }
    public UnitCombat UnitCombat { get => _unitCombat; }
    public UnitActionPattern UnitActionPattern { get => _unitActionPattern; }
    public UnitTileDetector UnitTileDetector { get => _unitTileDetector; }
}
