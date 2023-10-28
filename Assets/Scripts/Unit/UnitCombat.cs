using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCombat : MonoBehaviour, IHaveAttack
{
    [SerializeField] private int _damage;

    [SerializeField] private int _onKillHeal;

    public int OnKillHeal { get => _onKillHeal; }

    public delegate void UnitCombatEvent(IHaveHealth iHaveHealth);
    public event UnitCombatEvent KillGained;

    public int Damage { get => _damage; }

    public void Attack(IHaveHealth iHaveHealth)
    {
        iHaveHealth.AddHealth(-Damage);

        if (!iHaveHealth.IsAlive)
        {
            KillGained?.Invoke(iHaveHealth);
        }
    }
}
