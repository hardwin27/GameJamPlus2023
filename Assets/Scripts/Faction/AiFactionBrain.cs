using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFactionBrain : MonoBehaviour
{
    [SerializeField] private FactionController _factionController;
    [SerializeField] private GridController _gridController;

    private void Update()
    {
        if (_factionController.IsActive)
        {
            AiLogicHandler();
        }
    }

    // TEMPORARY RNG BASED LOGIC LESSGOOO XD
    private void AiLogicHandler()
    {
        if (_factionController.FactionUnits.Count > 0)
        {
            List<UnitController> availableUnits = _factionController.FactionUnits;

            while (availableUnits.Count > 0)
            {
                int randUnitInd = Random.Range(0, availableUnits.Count);

                _factionController.SelectObejct(availableUnits[randUnitInd].gameObject);

                if (_gridController.HighlightedTiles.Count > 0)
                {
                    break;
                }
                else
                {
                    availableUnits.Remove(availableUnits[randUnitInd]);
                }
            }

            if (_factionController.SelectedUnit != null && _gridController.HighlightedTiles.Count > 0)
            {
                int randTileInd = Random.Range(0, _gridController.HighlightedTiles.Count);

                _factionController.SelectObejct(_gridController.HighlightedTiles[randTileInd].gameObject);
            }
            else
            {
                _factionController.IsActive = false;
                return;
            }
        }
        else
        {
            _factionController.EndFactionAction();
        }

        /*_factionController.IsActive = false;*/
    }
}
