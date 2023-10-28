using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionPattern : MonoBehaviour
{
    [SerializeField] private TargetPattern _targetPattern;

    public TargetPattern TargetPattern { get => _targetPattern; }
}
