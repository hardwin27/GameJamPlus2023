using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCombat : MonoBehaviour, IHaveAttack
{
    [SerializeField] private int _damage;

    public int Damage { get => _damage; }

    public void Attack(IHaveHealth iHaveHealth)
    {
        iHaveHealth.AddHealth(-Damage);
    }
}
