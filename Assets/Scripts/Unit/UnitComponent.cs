using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    [SerializeField] private UnityEntity _unityEntity;
    [SerializeField] private UnitMovement _unitMovement;
    [SerializeField] private UnitActionPattern _unitActionPattern;
    [SerializeField] private UnitTileDetector _unitTileDetector;

    public UnityEntity UnityEntity { get => _unityEntity; }
    public UnitMovement UnitMovement { get => _unitMovement; }
    public UnitActionPattern UnitActionPattern { get => _unitActionPattern; }
    public UnitTileDetector UnitTileDetector { get => _unitTileDetector; }
}
