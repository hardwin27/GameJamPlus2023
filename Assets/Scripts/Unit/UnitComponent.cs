using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    [SerializeField] private UnitMovement _unitMovement;

    public UnitMovement UnitMovement { get => _unitMovement; }
}
