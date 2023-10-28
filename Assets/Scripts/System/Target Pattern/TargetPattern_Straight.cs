using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPattern_Straight : TargetPattern
{
    [SerializeField] private int _patternLength;
    [SerializeField] private bool _isDiagonal;
    [SerializeField] private bool _isOrthogonal;

    public override List<Vector2Int> GenerateTargetableTile(Vector2Int currentTile, List<List<Tile>> availableTiles)
    {
        // Can make it recursive in the future for better performance
        // Algo is not enough flexible if the map size is not perfectly square (AxA sized)
        List<Vector2Int> targetableCoordinate = new List<Vector2Int>();
        if (_patternLength > 0)
        {
            int x;
            int y;
            int count;
            if (_isOrthogonal)
            {
                y = currentTile.y;

                x = currentTile.x + 1;
                count = _patternLength;
                while (x < availableTiles.Count && count > 0)
                {
                    if (availableTiles[x][y].IsBlocked)
                    {
                        break;
                    }
                    targetableCoordinate.Add(new Vector2Int(x, y));
                    x++;
                    count--;
                }

                x = currentTile.x - 1;
                count = _patternLength;
                while (x >= 0 && count > 0)
                {
                    if (availableTiles[x][y].IsBlocked)
                    {
                        break;
                    }
                    targetableCoordinate.Add(new Vector2Int(x, y));
                    x--;
                    count--;
                }

                x = currentTile.x;

                y = currentTile.y + 1;
                count = _patternLength;
                while (y < availableTiles[0].Count && count > 0)
                {
                    if (availableTiles[x][y].IsBlocked)
                    {
                        break;
                    }
                    targetableCoordinate.Add(new Vector2Int(x, y));
                    y++;
                    count--;
                }

                y = currentTile.y - 1;
                count = _patternLength;
                while (y >= 0 && count > 0)
                {
                    if (availableTiles[x][y].IsBlocked)
                    {
                        break;
                    }
                    targetableCoordinate.Add(new Vector2Int(x, y));
                    y--;
                    count--;
                }
            }
        }

        return targetableCoordinate;
    }
}
