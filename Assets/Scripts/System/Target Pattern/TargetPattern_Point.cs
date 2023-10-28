using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPattern_Point : TargetPattern
{
    [SerializeField] private List<Vector2Int> _targetPoints;

    public override List<Vector2Int> GenerateTargetableTile(Vector2Int currentTile, List<List<Tile>> availableTiles)
    {
        List<Vector2Int> targetableCoordinate = new List<Vector2Int>();

        foreach(Vector2Int targetPoint in _targetPoints)
        {
            Vector2Int targetCoordinate = targetPoint + currentTile;

            if (targetCoordinate.x > 0 && targetCoordinate.x < availableTiles.Count)
            {
                if (targetCoordinate.y > 0 && targetCoordinate.y < availableTiles[targetCoordinate.x].Count)
                {
                    if (!availableTiles[targetCoordinate.x][targetCoordinate.y].IsBlocked)
                    {
                        targetableCoordinate.Add(targetCoordinate);
                    }
                }
            }
        }

        return targetableCoordinate;
    }
}
