using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPattern_Straight : TargetPattern
{
    [SerializeField] private int _patternLength;
    [SerializeField] private bool _isDiagonal;
    [SerializeField] private bool _isOrthogonal;

    public override List<Vector2Int> GenerateTargetableTile(Vector2Int currentTile, List<Vector2Int> availableTiles)
    {
        if (_patternLength > 0)
        {
            
        }

        return new List<Vector2Int>();
    }

    
}
