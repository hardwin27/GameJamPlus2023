using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] private UnitEntity _unitEntity;
    [SerializeField] private UnitVisual _unitVisual;
    [SerializeField] private UnitMovement _unitMovement;
    [SerializeField] private UnitCombat _unitCombat;
    [SerializeField] private UnitActionPattern _unitActionPattern;
    [SerializeField] private UnitTileDetector _unitTileDetector;

    public UnitEntity UnitEntity { get => _unitEntity; }
    public UnitVisual UnitVisual { get => _unitVisual; }
    public UnitMovement UnitMovement { get => _unitMovement; }
    public UnitCombat UnitCombat { get => _unitCombat; }
    public UnitActionPattern UnitActionPattern { get => _unitActionPattern; }
    public UnitTileDetector UnitTileDetector { get => _unitTileDetector; }

    private void OnEnable()
    {
        if (UnitCombat != null)
        {
            UnitCombat.KillGained +=  UnitKilledHandler;
        }
    }

    private void OnDisable()
    {
        if (UnitCombat != null)
        {
            UnitCombat.KillGained -= UnitKilledHandler;
        }
    }

    private void UnitKilledHandler(IHaveHealth haveHealthComp)
    {
        UnitEntity.AddHealth(UnitCombat.OnKillHeal);
        UnitMovement.MoveToPos(haveHealthComp.Owner.transform.position);
    }
}
