using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetPattern : MonoBehaviour
{
    public abstract List<Vector2Int> GenerateTargetableTile(Vector2Int currentTile, List<Vector2Int> availableTiles);
}
